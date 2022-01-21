function sysCall_init()
    corout = coroutine.create(coroutineMain)
    colorSensor = sim.getObjectHandle('ePuck_lightSensor')

    leftMotor = sim.getObjectHandle("ePuck_leftJoint")
    rightMotor = sim.getObjectHandle("ePuck_rightJoint")

    fRightSensor = sim.getObjectHandle("ePuck_frontRightSensor")
    bRightSensor = sim.getObjectHandle("ePuck_backRightSensor")

    frontSensor = sim.getObjectHandle("ePuck_frontSensor")
    backSensor = sim.getObjectHandle("ePuck_backSensor")

    beacon = sim.getObjectHandle("BEACON")
    beaconSensor = sim.getObjectHandle("ePuck_beaconSensor")

    sim.setJointTargetVelocity(leftMotor, 0.0)
    sim.setJointTargetVelocity(rightMotor, 0.0)
    -- set speeds
    maxSpeed = 2
    minSpeed = maxSpeed * 0.8
    direction = 1 -- 1- right, -1 left
    turnLeftSpeed, turnRightSpeed, minTurnTime = getTurnSpeeds()
    curveLeftSpeed, curveRightSpeed, minCurveTime = getCurveSpeeds()

    distanceToWall = 2
    detectionDistance = 0.2
    state = 4
    lastTime = 0
end

getLightSensors = function()
    local img = sim.getVisionSensorImage(colorSensor)
    return {img[1], img[22], img[94]}
end

function sysCall_actuation()
    local wL, wR
    if (state == 1) then
        wL, wR = followWall()
    elseif (state == 2) then
        wL = turnLeftSpeed
        wR = turnRightSpeed
    elseif (state == 3) then
        wL = curveLeftSpeed
        wR = curveRightSpeed
    elseif (state == 4) then
        wL, wR = followLine()
    elseif (state == 5) then
        local targetInRange
        wL, wR, targetInRange = followOther()
        -- print("Target in range", targetInRange)
        if not targetInRange then
            state = 1
        end

    else
        wL = 0
        wR = 0
    end

    sim.setJointTargetVelocity(leftMotor, wL)
    sim.setJointTargetVelocity(rightMotor, wR)

    if coroutine.status(corout) ~= 'dead' then
        local ok, errorMsg = coroutine.resume(corout)
        if errorMsg then
            error(debug.traceback(corout, errorMsg), 2)
        end
    end
end

function lineDetected(lightSens)
    if ((lightSens[1] < 0.5) or (lightSens[2] < 0.5) or (lightSens[3] < 0.5)) then
        return true
    end
    return false
end

function beaconDetected()
    local detected = sim.checkProximitySensor(beaconSensor, beacon)
    return detected == 1
end

function sysCall_sensing()
    local isOnLine = lineDetected(getLightSensors())
    local wallInFront = isWallInFront()
    local wallOnSide = isWallOnRightSide()

    if not isOnLine then
        handleStateResetAfterLine(isOnLine)

        if (state == 1) then
            handleFirstState(wallInFront, wallOnSide)
        elseif (state == 2) then
            handleSecondState(wallOnSide)
        elseif (state == 3) then
            handleThirdState(wallOnSide)
        elseif (state == 5) then
            handleFifthState()
        end
    else
        handleForthState()
    end
end

function isWallOnRightSide()
    rightSensorVal = getDistance(fRightSensor)
    if (rightSensorVal > distanceToWall - 0.001) then
        return false
    end
    return true

end

function isWallInFront()
    local frontSensorVal = getDistance(frontSensor)

    if (frontSensorVal < distanceToWall) then
        return true
    end
    return false
end

function handleStateResetAfterLine(onLine)
    if (state == 4 and not onLine) then
        state = 1
    end
end

function handleFirstState(wallInFront, wallOnSide)
    lastTime = sim.getSimulationTime()
    local isBeaconDetected = beaconDetected()

    if isBeaconDetected then
        state = 5
        return
    end

    if wallInFront then
        state = 2
    end

    if not wallOnSide then
        state = 3
    end
end

function handleSecondState(wallOnSide)
    -- print("I AM IN STATE 2")
    local timeElapsed = ((sim.getSimulationTime() - lastTime) > minTurnTime)
    if wallOnSide and timeElapsed then
        state = 1
    end
end

function handleThirdState(wallOnSide)
    -- print("I AM IN STATE 3")
    local timeElapsed = ((sim.getSimulationTime() - lastTime) > minCurveTime)
    if wallOnSide and timeElapsed then
        state = 1
    end
end

function handleForthState()
    -- print("I AM IN STATE 4")
    state = 4
end

function handleFifthState()
    -- print("I AM STATE 5")
end

function followLine()
    local wL = sim.getJointTargetVelocity(leftMotor)
    local wR = sim.getJointTargetVelocity(rightMotor)
    lightSens = getLightSensors()
    if lightSens and (lineDetected(lightSens)) then
        if (lightSens[1] > 0.5) then
            wL = maxSpeed
        else
            wL = maxSpeed * 0.25
        end
        if (lightSens[3] > 0.5) then
            wR = maxSpeed
        else
            wR = maxSpeed * 0.25
        end
    end
    return wL, wR
end

function getSpeedsBasedOnVector(baseSpeed, vector)
    -- 2-y
    -- 3 -x
    local wL = baseSpeed
    local wR = baseSpeed
    local x = vector[2]
    local y = vector[3]
    local mult = 5
    wR = wR + baseSpeed * -x * mult
    wL = wL + baseSpeed * x * mult

    if (y > 0.05) then
        wR = wR + wR * y * 0.5
        wL = wL + wL * y * 0.5
    else
        wR = 0
        wL = 0
    end
    return wL, wR
end

function followOther()
    local wL, wR
    minDist = 0.5
    local distace, target = getDistanceToTarget(beaconSensor, beacon)
    wL, wR = getSpeedsBasedOnVector(maxSpeed, target)
    local targetIsInRange = false
    if (distace > 0) then
        targetIsInRange = true
    end
    return wL, wR, targetIsInRange
end

function getDistance(sensor)
    local d, dist
    d, dist = sim.readProximitySensor(sensor)
    if (d < 1) then
        dist = distanceToWall
    end
    return dist
end

function getDistanceToTarget(sensor, target)
    local detected, dist, point = sim.checkProximitySensor(sensor, target)
    if (detected < 1) then
        return -1, {0, 0, 0}
    end
    return dist, point
end

function getSpeed(handle)
    local speed = sim.getJointTargetVelocity(handle)
    return speed
end

function followWall()
    local desiredDistance = 0.06
    local phi, d, alpha
    local wL = getSpeed(leftMotor)
    local wR = getSpeed(rightMotor)
    local dFR = getDistance(fRightSensor)
    local dBR = getDistance(bRightSensor)

    local diff = math.abs(dFR - dBR)

    local mult = 10 + diff * 10
    local frontVal = (dFR - desiredDistance) * mult
    local backVal = (dBR - desiredDistance) * mult

    if (direction == 1) then
        if (frontVal > 0) then
            wL = minSpeed + frontVal * maxSpeed
            wR = minSpeed - frontVal * maxSpeed
        elseif (frontVal < 0) then
            wR = minSpeed - frontVal * maxSpeed
            wL = minSpeed + frontVal * maxSpeed
        end
    end
    return wL, wR
end

function getTurnSpeeds()
    local wL, wR, t
    if (direction > 0) then
        wL = -maxSpeed
        wR = maxSpeed
    else
        wL = maxSpeed
        wR = -maxSpeed
    end
    t = 0.8
    return wL, wR, t
end

function getCurveSpeeds()
    local wL, wR, t
    if (direction > 0) then
        wL = maxSpeed * 1
        wR = maxSpeed * 0.6
    else
        wL = maxSpeed * 0.2
        wR = maxSpeed
    end
    t = 3.1
    return wL, wR, t
end

function coroutineMain()
    while true do
        sim.switchThread() -- Don't waste too much time in here (simulation time will anyway only change in next thread switch)
    end
end

function sysCall_cleanup()
    -- Put some clean-up code here:
end
