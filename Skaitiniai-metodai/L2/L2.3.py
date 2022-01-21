import numpy as np
import matplotlib.pyplot as plt
import math
import random
import matplotlib as mpl


def generavimas(n):
    taskai = []
    for _ in range(0, n):
        x = np.random.uniform(-10, 10)
        y = np.random.uniform(-10, 10)
        taskai.append((x, y))
    return np.array(taskai)


# tasku atvaizdavimas grafike
def atvaizdavimas(x, y, n, fiksuoti):
    plt.axis((-10, 10, -10, 10))
    for i in range(0, n):
        if i < fiksuoti:
            plt.plot(x[i], y[i], 'mo')      # fiksuoti taskai
        else:
            plt.plot(x[i], y[i], 'bo')      # papildomi (laisvi) taskai
    plt.show()


def vidutinis(x, y, n):
    sumab = 0.0
    for i in range(0, n):
        suma = 0.0              
        for j in range(0, n):
            if i != j:
                suma += np.sqrt((x[j] - x[i])**2 + (y[j] - y[i])**2)
        sumab += suma
    vid = sumab / (n * (n - 1))
    return vid


def tikslo(x,y,n,vid):
    s = 0.0
    for i in range(0, n):
        suma = 0.0
        for j in range(0,n):
            suma = suma + (np.sqrt((x[j] - x[i])**2 + (y[j] - y[i])**2) - vid)**2
        s += suma / (n * (n - 1)) + x[i] * np.e**(-((x[i]**2 * y[i]**2) / 10)) + 1.5
    return s


def gradiantas(x,y,n,vid):
    dh = 1e-2
    gradx = np.zeros(n) 
    grady = np.zeros(n)
    f = tikslo(x,y,n,vid)
    for i in range(3, n):
        xx = np.array(x, copy=True)
        xx[i] = xx[i] + dh
        f1 = tikslo(xx,y,n,vid)
        gradx[i] = (f1 - f) / dh
    for j in range(3, n):
        yy = np.array(y, copy=True)
        yy[j] = yy[j] + dh
        f1 = tikslo(x,yy,n,vid)
        grady[j] = (f1 - f) / dh
    grad = ([gradx, grady])
    return grad

# pagrindas
plt.figure(1)
plt.xlabel("x")
plt.ylabel("y")
plt.grid()


n = 7               # tasku skaicius
fiksuoti = 3        # fiksuotu tasku skaicius
taskai = generavimas(n)
x = taskai[:, 0]
y = taskai[:, 1]
print("Turimos pradinės koordinatės taškų: ")
print(x)
print(y)
atvaizdavimas(x,y,n, fiksuoti)

vidurkis = vidutinis(x, y, n)
print("Pradinė vidurkio reikšmė:  = {}".format(vidurkis))

plt.figure(1)
plt.xlabel("x")
plt.ylabel("y")
plt.grid()
# Gradientinis metodas
zingsnisprad = 0.1
maxiter = 100
tiksreik = 1e-8

f = tikslo(x,y,n,vidurkis)
print("Pradinė tikslo funkcijos reikšmė:  = {}".format(f))
visosTikslo = []

# Greiciausio nusileidimo metodas
for i in range(1, maxiter):
    grad = gradiantas(x,y,n,vidurkis)
    g = grad / np.linalg.norm(grad)
    f1 = tikslo(x,y,n,vidurkis)
    zingsnis = zingsnisprad
    
    for j in range(0,30):
        deltax = grad / np.linalg.norm(grad) * zingsnis
        x = x - deltax[0].transpose()
        y = y - deltax[1].transpose()
        vidurkis = vidutinis(x, y, n)
        f2 = tikslo(x,y,n,vidurkis)
        tiksl = np.abs(f1 - f2) / (np.abs(f1) + np.abs(f2))
        if tiksl < tiksreik:
            break
        if f2 > f1:
            x = x + deltax[0].transpose()
            y = y + deltax[1].transpose()
            zingsnis = zingsnis / 2
        else:
            f1 = f2
            visosTikslo.append(f1)

    zingsnis = zingsnisprad
    
    if tiksl < tiksreik:
        print("Sprendinys = {} {} " .format(x, y))
        atvaizdavimas(x,y,n,fiksuoti)
        print("Tikslumas = {}".format(tiksl))
        break
    elif i + 1 == maxiter:
        print("Tikslumas nepasiektas.")
        break

print("Tikslo funkcjos reiksme= {} , iteracija = {} ".format(f1, len(visosTikslo) )); print()

plt.figure(2)
plt.plot(visosTikslo)
plt.grid()
plt.xlabel("Iteracijų")
plt.ylabel("Tikslo funkcija")
plt.show()