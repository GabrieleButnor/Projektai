import numpy as np
import matplotlib.pyplot as plt

# zingsniai laiko pokyčio
dt = 0.1

dt1 = 0.2
dt2 = 0.05
dt3 = 0.01
dt4 = 0.05

# laiko koordinatės
t = np.arange(0, 160, dt)

# zigsniu kitimas
t1 = np.arange(0, 160, dt1)
t2 = np.arange(0, 160, dt2)
t3 = np.arange(0, 160, dt3)
t4 = np.arange(0, 160, dt4)
#-----

# masė
m1 = 100
m2 =15
m = m1 + m2

h0 = 3000       # pradinis aukštis
tg = 40         # parašiuto išsiskleidimo laikas

k1 = 0.5        # laisvo kritimo oro pasipriešinimo koeficientas
k2 = 10         # su parašiutu kritimo oro pasipriešinimo koeficientas
v0 = 0          # pradinis greitis iššokus iš l4ktuvo

v = np.zeros(shape = t.shape)       # greičio koordinatės laike
h = np.zeros(shape = t.shape)       # aukščio koordinatės laike
v[0] = v0
h[0] = h0

# zigsniu kitimas
vd1 = np.zeros(shape = t1.shape)       # greičio koordinatės laike
vd1[0] = v0
vd2 = np.zeros(shape = t2.shape)       # greičio koordinatės laike
vd2[0] = v0
vd3 = np.zeros(shape = t3.shape)       # greičio koordinatės laike
vd3[0] = v0
vd4 = np.zeros(shape = t4.shape)       # greičio koordinatės laike
vd4[0] = v0

# greičio, auščio koordinačių radimas
for i in range(1, t.shape[0]):
    if (t[i] < 40 ):
        v1 = v[i-1] + dt/2 * ( (m * 9.8 - k1 * (v[i-1])**2) / m)
        v2 = v[i-1] + dt/2 * ( (m * 9.8 - k1 * v1**2) / m)
        v3 = v[i-1] + dt * ( (m * 9.8 - k1 * v2**2) / m)
        v[i] = v[i-1] + (dt/6) * ( ( (m * 9.8 - k1 * (v[i-1])**2) / m) + 2 * ( (m * 9.8 - k1 * v1**2) / m) + 2 * ( (m * 9.8 - k1 * v2**2) / m) + ( (m * 9.8 - k1 * v3**2) / m) )
        h[i] = h[i-1] - (v[i] * dt) 
    else:
        v1 = v[i-1] + dt/2 * ( (m * 9.8 - k2 * (v[i-1])**2) / m)
        v2 = v[i-1] + dt/2 * ( (m * 9.8 - k2 * v1**2) / m)
        v3 = v[i-1] + dt * ( (m * 9.8 - k2 * v2**2) / m)
        v[i] = v[i-1] + (dt/6) * ( ( (m * 9.8 - k2 * (v[i-1])**2) / m) + 2 * ( (m * 9.8 - k2 * v1**2) / m) + 2 * ( (m * 9.8 - k2 * v2**2) / m) + ( (m * 9.8 - k2 * v3**2) / m) )
        h[i] = h[i-1] - (v[i] * dt) 


# klausymu atsakymai
vzemes = 0
tzemes = 0
hparasiuto = 0

for i in range(0, h.shape[0]):
    if(h[i] < 0 ):     
        vzemes = v[i-1]
        tzemes = t[i-1]
        break
for i in range(0, t.shape[0]):
    if(t[i] == 40):
        hparasiuto = h[i]

print()
print("Parašiutininkui pasiekus žemę jo greitis bus lygus ( m / s ): " );print(vzemes); print()
print("Parašiutininkas žemę pasieks (sekundę) : " );print(tzemes); print()
print("Parašiutas išsiskleis aukštyje ( m ) : " );print(hparasiuto); print()


# -----------------------------
for i in range(1, t1.shape[0]):
    if (t1[i] < 40 ):
        v1 = vd1[i-1] + dt1/2 * ( (m * 9.8 - k1 * (vd1[i-1])**2) / m)
        v2 = vd1[i-1] + dt1/2 * ( (m * 9.8 - k1 * v1**2) / m)
        v3 = vd1[i-1] + dt1 * ( (m * 9.8 - k1 * v2**2) / m)
        vd1[i] = vd1[i-1] + (dt1/6) * ( ( (m * 9.8 - k1 * (vd1[i-1])**2) / m) + 2 * ( (m * 9.8 - k1 * v1**2) / m) + 2 * ( (m * 9.8 - k1 * v2**2) / m) + ( (m * 9.8 - k1 * v3**2) / m) ) 
    else:
        v1 = vd1[i-1] + dt1/2 * ( (m * 9.8 - k2 * (vd1[i-1])**2) / m)
        v2 = vd1[i-1] + dt1/2 * ( (m * 9.8 - k2 * v1**2) / m)
        v3 = vd1[i-1] + dt1 * ( (m * 9.8 - k2 * v2**2) / m)
        vd1[i] = vd1[i-1] + (dt1/6) * ( ( (m * 9.8 - k2 * (vd1[i-1])**2) / m) + 2 * ( (m * 9.8 - k2 * v1**2) / m) + 2 * ( (m * 9.8 - k2 * v2**2) / m) + ( (m * 9.8 - k2 * v3**2) / m) )
 
for i in range(1, t2.shape[0]):
    if (t2[i] < 40 ):
        v1 = vd2[i-1] + dt2/2 * ( (m * 9.8 - k1 * (vd2[i-1])**2) / m)
        v2 = vd2[i-1] + dt2/2 * ( (m * 9.8 - k1 * v1**2) / m)
        v3 = vd2[i-1] + dt2 * ( (m * 9.8 - k1 * v2**2) / m)
        vd2[i] = vd2[i-1] + (dt2/6) * ( ( (m * 9.8 - k1 * (vd2[i-1])**2) / m) + 2 * ( (m * 9.8 - k1 * v1**2) / m) + 2 * ( (m * 9.8 - k1 * v2**2) / m) + ( (m * 9.8 - k1 * v3**2) / m) ) 
    else:
        v1 = vd2[i-1] + dt2/2 * ( (m * 9.8 - k2 * (vd2[i-1])**2) / m)
        v2 = vd2[i-1] + dt2/2 * ( (m * 9.8 - k2 * v1**2) / m)
        v3 = vd2[i-1] + dt2 * ( (m * 9.8 - k2 * v2**2) / m)
        vd2[i] = vd2[i-1] + (dt2/6) * ( ( (m * 9.8 - k2 * (vd2[i-1])**2) / m) + 2 * ( (m * 9.8 - k2 * v1**2) / m) + 2 * ( (m * 9.8 - k2 * v2**2) / m) + ( (m * 9.8 - k2 * v3**2) / m) )
 
for i in range(1, t3.shape[0]):
    if (t3[i] < 40 ):
        v1 = vd3[i-1] + dt3/2 * ( (m * 9.8 - k1 * (vd3[i-1])**2) / m)
        v2 = vd3[i-1] + dt3/2 * ( (m * 9.8 - k1 * v1**2) / m)
        v3 = vd3[i-1] + dt3 * ( (m * 9.8 - k1 * v2**2) / m)
        vd3[i] = vd3[i-1] + (dt3/6) * ( ( (m * 9.8 - k1 * (vd3[i-1])**2) / m) + 2 * ( (m * 9.8 - k1 * v1**2) / m) + 2 * ( (m * 9.8 - k1 * v2**2) / m) + ( (m * 9.8 - k1 * v3**2) / m) ) 
    else:
        v1 = vd3[i-1] + dt3/2 * ( (m * 9.8 - k2 * (vd3[i-1])**2) / m)
        v2 = vd3[i-1] + dt3/2 * ( (m * 9.8 - k2 * v1**2) / m)
        v3 = vd3[i-1] + dt3 * ( (m * 9.8 - k2 * v2**2) / m)
        vd3[i] = vd3[i-1] + (dt3/6) * ( ( (m * 9.8 - k2 * (vd3[i-1])**2) / m) + 2 * ( (m * 9.8 - k2 * v1**2) / m) + 2 * ( (m * 9.8 - k2 * v2**2) / m) + ( (m * 9.8 - k2 * v3**2) / m) )

for i in range(1, t4.shape[0]):
    if (t4[i] < 40 ):
        v1 = vd4[i-1] + dt4/2 * ( (m * 9.8 - k1 * (vd4[i-1])**2) / m)
        v2 = vd4[i-1] + dt4/2 * ( (m * 9.8 - k1 * v1**2) / m)
        v3 = vd4[i-1] + dt4 * ( (m * 9.8 - k1 * v2**2) / m)
        vd4[i] = vd4[i-1] + (dt4/6) * ( ( (m * 9.8 - k1 * (vd4[i-1])**2) / m) + 2 * ( (m * 9.8 - k1 * v1**2) / m) + 2 * ( (m * 9.8 - k1 * v2**2) / m) + ( (m * 9.8 - k1 * v3**2) / m) ) 
    else:
        v1 = vd4[i-1] + dt4/2 * ( (m * 9.8 - k2 * (vd4[i-1])**2) / m)
        v2 = vd4[i-1] + dt4/2 * ( (m * 9.8 - k2 * v1**2) / m)
        v3 = vd4[i-1] + dt4 * ( (m * 9.8 - k2 * v2**2) / m)
        vd4[i] = vd4[i-1] + (dt4/6) * ( ( (m * 9.8 - k2 * (vd4[i-1])**2) / m) + 2 * ( (m * 9.8 - k2 * v1**2) / m) + 2 * ( (m * 9.8 - k2 * v2**2) / m) + ( (m * 9.8 - k2 * v3**2) / m) )

# -----------------------------    



fig = plt.figure(figsize=(10,5))
ax = fig.add_subplot()
ax.plot(t, v, color="black", label = "Parašiutininko greičio kitimas laike")
plt.title("Parašiutininko greičio kitimas laike.")
plt.xlabel('laikas sekundėmis ( t , s )')  
plt.ylabel('greitis ( v , m/s )')  
plt.grid(1)
plt.legend()
plt.show()

fig = plt.figure(figsize=(10,5))
ax = fig.add_subplot()
ax.plot(t, h, color="red", label = "Parašiutininko aukščio kitimas laike")
plt.title("Parašiutininko aukščio kitimas laike.")
plt.xlabel('laikas sekundėmis ( t , s )')  
plt.ylabel('aukštis ( h , m )')  
plt.grid(1)
plt.legend()
plt.show()


fig = plt.figure(figsize=(10,5))
ax = fig.add_subplot()
ax.plot(t, v, color="blue", label = "Žingsnis 0.1")
ax.plot(t1, vd1, color="y", label = "Žingsnis 0.2")
ax.plot(t2, vd2, color="g", label = "Žingsnis 0.5")
ax.plot(t3, vd3, color="m", label = "Žingsnis 0.01")
ax.plot(t4, vd4, color="c", label = "Žingsnis 0.05")
plt.title("Parašiutininko greičio kitimas laike, įvairiais žingsniais.")
plt.xlabel('laikas sekundėmis ( t , s )')  
plt.ylabel('greitis ( v , m/s )')  
plt.grid(1)
plt.legend()
plt.show()