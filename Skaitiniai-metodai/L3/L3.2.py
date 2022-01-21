import numpy as np
import matplotlib.pyplot as plt


# Niutono interpoliavimas
def niutono_interpoliavimas(X,Y,x):
    ysuma = Y[0]                      # pridedamas a0, kuris lygus y0 turimu mazgu (pirmam taskui)
    n = len(X)                        # mazgu kiekis
    skirt = np.zeros([n,n])           # santykiniu skirtumu reiksmems saugoti matrica 
    for i in range(0, n):
        skirt[i,0] = Y[i]             #i pirmus stulpelius sudedam mazgu y koordinates
    tarpYsuma = 1.0                     
    for i in range(1, n):
        tarpYsuma = tarpYsuma * (x-X[i-1])  # einamojo atvaizdavimo tasko x ir mazgu x koordinaciu skirtumu sandauga       
        for j in range(i,n):
            skirt[j,i] = (skirt[j,i-1] - skirt[j-1,i-1]) / (X[j]-X[j-i])      # a koefiientu nustatymai
        ysuma += tarpYsuma * skirt[i,i]         # atitinkamu poziciju a*(x-xi)... galutine, visu suma 
    return ysuma


# Malis 2006 metai
X = [1,2,3,4,5,6,7,8,9,10,11,12]
Y = [22.8806, 24.1999, 28.4987, 31.6118, 33.1856, 34.3569, 32.8721, 30.9421, 30.8454, 30.3405, 25.7535, 21.5325]
# vaizduojamu tasku x koordinates
xs = np.linspace(1,12,160)

fy =[]                              
for i in xs:
    fy.append(niutono_interpoliavimas(X,Y,i))


plt.axis([-1,15,18,37])
plt.title("Malis. 2006 metai. Temperatura")
plt.plot(xs, fy, color = "blue", label = "Interpoliuojanti kreive")
plt.scatter(X, Y, color = "purple", marker="o", label = "Temperaturu taskai (mazgai)")
plt.grid(1)
plt.legend()
plt.show()

