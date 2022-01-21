import numpy as np;
import matplotlib.pyplot as plt;
import array as arr;
import sympy 
import  math

# funkcija sin(𝑥) (𝑥2 − 1)(𝑥 + 3) − 0,9
def gx(x):
  return np.sin(x) * (x**2 - 1) * (x + 3) - 0.9

# kintamieji
Rneig = -10         
Rteig = 10
taskai = [] 
tiks = 1e-10


#--------------------------------------------------------------

#skenavimo metodas su nekintančiu žingsniu
def skenavimas(func, xNuo, xIki):
    zingsnis = 0.5
    while(xNuo <= xIki):
        pirmas = func(xNuo)
        antras =  func(xNuo + zingsnis)        
        if (np.sign(pirmas) != np.sign(antras)):            
            taskai.append(xNuo)
            taskai.append(xNuo + zingsnis)
        xNuo = xNuo + zingsnis


#tinkslinimas stygų metodu
def stygu(func, xNuo, xIki):
    k = np.abs(func(xNuo) / func(xIki))
    xvid = (xNuo + k * xIki) / (1 + k)
    inter_fx_s = 0
    while(np.abs(func(xvid)) >  tiks):
        inter_fx_s = inter_fx_s + 1
        if (np.sign(func(xvid)) == np.sign(func(xNuo))):
            xNuo =xvid
        else:
            xIki = xvid
        k = np.abs(func(xNuo) / func(xIki))
        xvid = (xNuo + k * xIki) / (1 + k)
    s = tikslumas(xNuo, xIki, func(xNuo), func(xIki), tiks)
    print('Tikslumas = {0:10} , Iteracijų skaičius: {1:5}' .format( s, inter_fx_s) )
    return xvid

#tinkslinimas kirstiniu metodu
def kirstiniu(func, x):
    intr = 0
    h = 0.000001
    while(np.abs(func(x)) >  tiks):
        intr += 1
        x = x - ( ( ( func(x) - func(x-h) ) /  ( x - (x - h) ) )**-1) * func(x)
    s = tikslumas(x, x-h, func(x), func(x-h), tiks)
    print('Tikslumas = {0:10} , Iteracijų skaičius: {1:5}' .format( s, intr) )
    return x


#skenavimo metodas su kintačiu žingsniu
def skenavimasS(func, xNuo, xIki):
    zingsnis = 0.1
    intr = 0
    while(np.abs(xNuo - xIki) > 1e-4):
        intr += 1
        pirmas = func(xNuo)
        antras = func(xNuo + zingsnis)               
        if (np.sign(pirmas) != np.sign(antras)):
            xIki =  xNuo + zingsnis
            zingsnis = zingsnis - 0.00008
            if(zingsnis < 0):
                return 0
        else:
            xNuo = xNuo + zingsnis
    s = tikslumas(xNuo, xIki, func(xNuo), func(xIki), 1e-4)
    print('Tikslumas = {0:10} , Iteracijų skaičius: {1:5}' .format( s, intr) )
    return xNuo


#--------------------------------------------------------------

def atvaizdavimas(func, xr):   
    x = np.linspace(-10, 10, 100)
    y = func(x)
    plt.plot(x,y)
    plt.plot(xr, func(xr), markersize=10, marker='o')
    plt.show()

def tikslumas(x1,x2,f1,f2,eps): 
    if np.isscalar(x1):
            if np.abs(x1+x2) > eps:
                   s=  np.abs(x1-x2)/(np.abs(x1+x2)+np.abs(f1)+np.abs(f2))
            else:  s=  np.abs(x1-x2)+abs(f1)+abs(f2);  
    else:
        if (sum(np.abs(x1+x2)) > eps):
               s=  sum(np.abs(x1-x2))/sum(np.abs(x1+x2)+np.abs(f1)+np.abs(f2))
        else:  s=  sum(np.abs(x1-x2)+abs(f1)+abs(f2));  
    return s

#--------------------------------------------------------------

# funkcijos šaknų intervalo atvaizdavimas
x = np.linspace(-10, 10, 100)
y = gx(x)
plt.plot(x,y)
plt.show()

# šaknų intervalų atkyrimas
skenavimas(gx, Rneig, Rteig)

print('Funkcija: ')
print()
# radimas šaknų stygų metodu
i = 0
while i < len(taskai):
    x = stygu(gx, taskai[i] , taskai[i+1])
    atvaizdavimas(gx, x)
    print('Metodas : {0:11}  Intervalas: {1} / {2}     Sprendinys x = {3:5}'.format('Stygų',taskai[i], taskai[i+1], x) )
    print()
    i = i + 2  
print()

# radimas šaknų kirstiniu metodu
i = 0
while i < len(taskai):
    x = kirstiniu(gx, taskai[i])
    atvaizdavimas(gx, x)
    print('Metodas : {0:11}  Artiniai: {1}    Sprendinys x = {2:5}'.format('Kvazi_Niutono(kirstiniu)',taskai[i], x) )
    print()
    i = i + 2  
print()

# radimas šaknų skenavimo kintančių žingsniu metodu
i = 0
while i < len(taskai):
    x = skenavimasS(gx, taskai[i] , taskai[i+1])
    atvaizdavimas(gx, x)
    print('Metodas : {0:11}  Intervalas: {1} / {2}     Sprendinys x = {3:5}'.format('Skenavimo su kintančiu žingsniu',taskai[i], taskai[i+1], x) )
    print()
    i = i + 2  
print()

print("Patikrinimas:")

x,f,fp,df=sympy.symbols(('x','f','fp','df'))

f=sympy.sin(x) * (x**2 - 1) * (x + 3) - 0.9 
x0=-10
N=31 
fp=f.subs(x,x0)
for i in range (1,N+1): 
    f=f.diff(x)
    fp=fp+f.subs(x,x0)/math.factorial(i)*(x-x0)**i; 
a=sympy.Poly(fp,x)
kf=np.array(a.all_coeffs())
saknys=np.roots(kf)
print(saknys)
