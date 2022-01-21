import numpy as np
import matplotlib.pyplot as plt


# 6 uzduoties funkcija
def F(x):
    y = np.log(x) / (np.sin(2*x)+1.5) + x / 5
    return y


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



# n-os eiles Čiobyševo abcisemis randami interpoliavimo tasku (mazgu) x koordinates
# intervalas [a,b], mazgas, eile (vzisu mazgu kiekis)
def CiobysevoMazgai(a,b,i,n):
    return ((b - a) / 2) * np.cos(np.pi * (2 * i + 1) / (2 * n) ) + ( (b + a) / 2 )
    
#---------------------------------------------------------

# intervalas reiksmiu
xmin = 2
xmax = 10
# mazgu skaicius
#m = 7 
m = 10 
#m = 16 
#m = 30
# interpoliavimo mazgu tolygaus pokycio zingsnis, pagal mazgu skaiciu
step = (xmax - xmin) / m            

x = np.arange(xmin, xmax, 0.05)     # duotos funkcijos tasku x koordinates
y = F(x)                            # duotos funkcijos tasku y koordinates

xtaskai = np.arange(xmin, xmax, step)  # interpoliavimo mazgu x koordinate, pasiskirste tolygiai
ytaskai = F(xtaskai)                   # interpoliavimo mazgu y koordinate, pasiskirste tolygiai 

n = len(x)              # atvazidavimo tasku skaicius
xs=np.linspace(2,10,n)  # atvaizdavimo tasku tolygiai pasiskirsciusios x koordinates intervale

# gaunamos y koordinates interpoliacines funkcijos
fy =[]                              
for i in xs:
    fy.append(niutono_interpoliavimas(xtaskai,ytaskai,i))

# funkciju atvaizdavimas
plt.axis([1,11,0,7])
plt.title("Niutono interpoliacija. Taskai pasiskirste tolygiai")
plt.plot(x, y, color = "blue", label = "Duota funkcija")
plt.scatter(xtaskai, ytaskai, color = "black", marker="o", label = "Interpoliavimo mazgai")
plt.plot(xs, fy, color = "green", label = "Interpoliuota")
plt.xlabel('x')  
plt.ylabel('y')  
plt.grid()
plt.legend()
plt.show()

# funkciju ir netikties atvaizdavimas
plt.axis([1,11,-3,9])
plt.title("Niutono interpoliacija. Taskai pasiskirste tolygiai")
plt.plot(x, y, color = "blue", label = "Duota funkcija")
plt.scatter(xtaskai, ytaskai, color = "black", marker="o", label = "Interpoliavimo mazgai")
plt.plot(xs, fy, color = "green", label = "Interpoliuota")
plt.plot(xs, y - fy, color = "red", label = "Netiktis")
plt.xlabel('x')  
plt.ylabel('y')  
plt.grid()
plt.legend()
plt.show()

#---------------------------------------------------------


i = np.arange(m)
# interpoliavimo tasku susiradimas pagal Ciobysevo abscises (intervala, kuris mazgas, mazgu kiekis)
xc = CiobysevoMazgai(xmin,xmax,i,m)

yc = []
for c in xc:
    yc.append(F(c))

# interpoliacines funkcijos radimas,Niutono metodu
Cfy =[]                              
for i in xs:
    Cfy.append(niutono_interpoliavimas(xc,yc,i))

# funkciju atvaizdavimas
plt.axis([1,11,0,7])
plt.title("Niutono interpoliacija. Čiobyševo abscises.")
plt.plot(x, y, color = "blue", label = "Duota funkcija")
plt.scatter(xc, yc, color = "black", marker="o", label = "Interpoliavimo mazgai")
plt.plot(xs, Cfy, color = "green", label = "Interpoliuota")
plt.grid()
plt.legend()
plt.show()

# funkciju ir netikties atvaizdavimas
plt.axis([1,11,-3,9])
plt.title("Niutono interpoliacija. Čiobyševo abscises.")
plt.plot(x, y, color = "blue", label = "Duota funkcija")
plt.scatter(xc, yc, color = "black", marker="o", label = "Interpoliavimo mazgai")
plt.plot(xs, Cfy, color = "green", label = "Interpoliuota")
plt.plot(xs, y - Cfy, color = "red", label = "Netiktis")
plt.grid()
plt.legend()
plt.show()
