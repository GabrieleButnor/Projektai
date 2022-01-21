import numpy as np
import matplotlib.pyplot as plt
from scipy.optimize import fsolve
from mpl_toolkits import mplot3d
from PyFunkcijos import *
import math

# 3*𝑥1 + 5*𝑥2 + 3*𝑥3 + 𝑥4 − 8 = 0
# 𝑥1^2 + 2*𝑥2*𝑥4 − 5 = 0
# −3*𝑥2^2 − 3*𝑥1*𝑥2 + 2*𝑥4^3 + 16 = 0
# 5*𝑥1 − 15*𝑥2 + 3*𝑥4 + 22 = 0

#netiesinių lygčių sistema matricos pavidalu
def LF(x):  
    s=np.array( [ [3 * x[0] + 5 * x[1] + 3 * x[2] + x[3] - 8],
                 [x[0]**2 + 2 * x[1] * x[3] - 5],
                 [-3 * x[1]**2 - 3 * x[0] * x[1] + 2 * x[3]**3 + 16],
                 [5 * x[0] - 15 * x[1] + 3 * x[3] + 22]
                ])
    s.shape=(4,1)
    s=np.matrix(s)
    return s

def LFisores(x):
    f1 = 3 * x[0] + 5 * x[1] + 3 * x[2] + x[3] - 8
    f2 = x[0]**2 + 2 * x[1] * x[3] - 5
    f3 = -3 * x[1]**2 - 3 * x[0] * x[1] + 2 * x[3]**3 + 16
    f4 = 5 * x[0] - 15 * x[1] + 3 * x[3] + 22
    return[f1, f2, f3, f4]

#Broideno metodas

n = 4               # lygčių skaičius
x = np.matrix(np.zeros(shape=(n,1)))    # atsakymu matricos suformavimas (nulias užpildymas)
maxiter = 1000       #didžiausias leistinas iteracijų skaičius
tiksreik = 1e-8    #reikalaujamas tikslumas 

# pirminis artinys
x[0] = 0; x[1] = -1; x[2] = 0; x[3] = 0
#x[0] = -1; x[1] = -1; x[2] = -1; x[3] = -1
#x[0] = 0; x[1] = 0; x[2] = -1; x[3] = 0
 
#Jakobio matrica pradine (skaitiskai)

h = 0.1       # dx pradiniam Jakobio matricos iverciui, pokytis
A = np.matrix(np.zeros(shape=(n,n)))  # Jakobo matiricos išskyrimas 
x1 = np.zeros(shape=(n,1))            # seknačio, gretimo artinio matricos išskyrimas

# Skaitiskai randama Jakobio matrica 
for i in range (0, n):
    x1 = np.matrix(x)
    x1[i] += h
    A[:,i] = (LF(x1) - LF(x)) / h

f = LF(x)       # pradinio artinio funkcijų reikšmės

#Broideno metodas
for i in range (1, maxiter):
    pokytis = -np.linalg.solve(A,f)        # x reikšmių pokyčio radimas
    x1 = np.matrix(x + pokytis)            # naujo artinio x reiksmiu radimas
    f1 = LF(x1)                            # naujo artinio funkcijos reiksmiu radimas
    y = f1 - f                             # funkcijos reiksmiu pokytis
    # atnaujinta Jakobio matrica
    A = A + ( (y - A * pokytis) * pokytis.transpose() ) / (pokytis.transpose() * pokytis)
    tiksl = tikslumas(x, x1, f, f1, tiksreik) 
    print("Pradinis artinys = {} , tikslumas = {} , iteracija = {} ".format(x, tiksl, i)); print()
    if tiksl < tiksreik:
        print("Sprendinys =  "); print(x);print()
        break
    elif i + 1 == maxiter:
        print("Tikslumas nepasiektas.")
        break
    # nauju artiniu priskirimas i pradinius artinius sekancia zingsniui
    f = f1
    x = x1

# tikrinimas sprendinio isoriniais istekliais
X = fsolve(LFisores, x)
print("Tikrinimas vidinėmis funkcijomis")
print("Sprendinys = {}  ".format(X)); print()