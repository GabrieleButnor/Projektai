import numpy as np
import matplotlib.pyplot as plt
from scipy.optimize import fsolve
from mpl_toolkits import mplot3d
from PyFunkcijos import *
import math

# 𝑥1 * (𝑥2 + 2 * cos(𝑥1)) − 1 = 0
# 𝑥1^4 + 𝑥2^4 − 64 = 0

#netiesinių lygčių sistema matricos pavidalu
def LF(x):  
   # s = np.matrix( [ [x[0] * ( x[1] + 2 * cos(x[0]) ) - 1], [x[0]**4 + x[1]**4 - 64] ])
    s=np.array( [ [x[0] * ( x[1] + 2 * cos(x[0]) ) - 1], [x[0]**4 + x[1]**4 - 64] ])
    s.shape=(2,1)
    s=np.matrix(s)
    return s

def LFisores(x):
    f1 = x[0] * ( x[1] + 2 * cos(x[0]) ) - 1
    f2 = x[0]**4 + x[1]**4 - 64
    return[f1, f2]


#erdvių (triju) susidarymas ir ašiu pavadinimas
fig1 = plt.figure(1,figsize=plt.figaspect(0.5))
ax1 = fig1.add_subplot(1, 3, 1, projection='3d');ax1.set_xlabel('x');ax1.set_ylabel('y');ax1.set_zlabel('z')
ax2 = fig1.add_subplot(1, 3, 2, projection='3d');ax2.set_xlabel('x');ax2.set_ylabel('y');ax2.set_zlabel('z')
ax3 = fig1.add_subplot(1, 3, 3, projection='3d');ax3.set_xlabel('x');ax3.set_ylabel('y');ax3.set_zlabel('z')

#tinklelio ir jo erdves nustatymas, sukūrimas paviršiaus
xx = np.linspace(-3,3,20)
yy = np.linspace(-3,3,20)
X, Y = np.meshgrid(xx, yy)
Z = Pavirsius(X,Y,LF)

# pirmos funkcijos atvaizdavimas
#nupiešimas paviršiaus
surf1 = ax1.plot_surface(X, Y, Z[:,:,0], color='blue', alpha=0.4)
#nupiešimas tinklelis
wire1 = ax1.plot_wireframe(X, Y, Z[:,:,0], color='black', alpha=1, linewidth=0.5, antialiased=True)
#išryškinamos nulio reikšmių linijos
CS11 = ax1.contour(X, Y, Z[:,:,0],[0],colors='blue')

# antros funkcijos atvaizdavimas
surf2 = ax2.plot_surface(X, Y, Z[:,:,1], color='purple', alpha=0.4)
wire2 = ax2.plot_wireframe(X, Y, Z[:,:,1], color='black', alpha=1, linewidth=0.5, antialiased=True)
CS12 = ax2.contour(X, Y, Z[:,:,1],[0],colors='green')

#abiejų nulio reikšmių linijų susikirtimai yra sprendinio taškai
CS1 = ax3.contour(X, Y, Z[:,:,0],[0],colors='blue')
CS2 = ax3.contour(X, Y, Z[:,:,1],[0],colors='green')

#nulines plokštumos išskyrimas
XX = np.linspace(-5,5,2);  YY = XX; XX, YY = np.meshgrid(XX, YY); ZZ = XX*0
zeroplane = ax1.plot_surface(XX, YY, ZZ, color='gray', alpha=0.4, linewidth=0, antialiased=True)
zeroplane = ax2.plot_surface(XX, YY, ZZ, color='gray', alpha=0.4, linewidth=0, antialiased=True)
zeroplane = ax3.plot_surface(XX, YY, ZZ, color='gray', alpha=0.4, linewidth=0, antialiased=True)

plt.show()


#Broideno metodas

n = 2               # lygčių skaičius
x = np.matrix(np.zeros(shape=(n,1)))    # atsakymu matricos suformavimas (nulias užpildymas)
maxiter = 100       #didžiausias leistinas iteracijų skaičius
tiksreik = 1e-6     #reikalaujamas tikslumas 

# pirma pirminių artinių pora
x[0] = -3; x[1] = 1
# antra pirminių artinių pora
#x[0] = -1; x[1] = -2
# trecia pirminių artinių pora
#x[0] = 0; x[1] = 4
# ketvirta pirminių artinių pora
#x[0] = 2; x[1] = 2
 
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
    elif i == maxiter:
        print("Tikslumas nepasiektas.")
        break
    # nauju artiniu priskirimas i pradinius artinius sekancia zingsniui
    f = f1
    x = x1

# tikrinimas sprendinio isoriniais istekliais
X = fsolve(LFisores, x)
print("Tikrinimas vidinėmis funkcijomis")
print("Sprendinys = {}  ".format(X)); print()

