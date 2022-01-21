import numpy as np
from matplotlib import pyplot as plt

# Baziniu funkciju reiksmiu radimas
# m - eile, n - tasku sk, x - duotu tasku koordiate x
# kokia eile tiek baziniu funkciju ir iskosime (kiekvienam taskui duotam)

def bazinesGfunkcijos(m, n, x):
    g = np.zeros([n, m])            # kiek tasku tiek eiluciu, stulpeliu tiek kokia eile aproksimuojame
    for i in range(n):            # per tasku
        for j in range(m):        # bazines funkcijas
            g[i,j] = x[i]**j   # tasko bazines funkcjos reiksme atitinkamos eiles
    return g

# c koeficiento apskaiciavimas
def koeficientasC(g, y):
    gg = np.matmul(g.transpose(), g)        
    gy = np.matmul(g.transpose(), y)
    c = np.linalg.solve(gg, gy)             # gT * g * c = gT * y
    return c

# Malis 2006 metai
X = [1,2,3,4,5,6,7,8,9,10,11,12]
#Y = [22.8806, 24.1999, 28.4987, 31.6118, 33.1856, 34.3569, 32.8721, 30.9421, 30.8454, 30.3405, 25.7535, 21.5325]
Y = [22.8806, 24.1999, 28.4987, 31.6118, 33.1856, 34.3569, 32.8721, 30.9421, 30.8454, 30.3405, 25.7535, 35.5325]

n = len(X)      # tasku (mazgu) kiekis
# aproksimavimo eile (baziniu funkciju  skaicius)
m = 2
#m = 3
#m = 4
#m = 5

# turimu tasku bazines funkcijos reiksmes ir koeficientu reiksmes
G = bazinesGfunkcijos(m, n, X)
C = koeficientasC(G, Y)
print("Temperaturos tasku baziniu funkciju reiksmes: "); print(G)
print(" ")
print("Temperaturos tasku koefiinetu C reiksmes: "); print(C)

natv = 160
step = (X[n-1]-X[0]) / natv    # atvaiduojamu tasku zinsginis einamame intervale 
# atvaziudojamu tasku x koordinates interavale
xatv = np.arange(X[0], X[n-1], step) 

# atvazidavimo tasku baziniu funkcju reiksmes
Gatv = bazinesGfunkcijos(m, natv, xatv)
# koeficientu c zinome pagal mazgus
f = Gatv.dot(C)

plt.axis([0,13,18,40])
plt.xticks(np.arange(13), np.arange(0, 13))
plt.title("Malis. 2006 metai. Temperatura")
plt.scatter(X, Y, color = "purple", marker="o", label = "Temperaturu taskai (mazgai)")
plt.plot(xatv, f, color = "blue", label = "Aproksimavimo kreive.")
plt.grid(1)
plt.legend()
plt.show()



