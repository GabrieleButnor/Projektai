import numpy as np;
import matplotlib.pyplot as plt;
import array as arr;

# daugianaris: - 0.63*x**4 + 3.92*x**3 - 7.95*x**2 + 5.50*x -0.53

# pertvrakytas daugianaris, su teigiamu aukščiausio laipsnio koeficientu
def fx(x):
  return 0.63*x**4 - 3.92*x**3 + 7.95*x**2 - 5.50*x + 0.53

# kintamieji
Rneig = 0         
Rteig = 9.73
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
    x = np.linspace(0, 3, 100)
    y = func(x)
    plt.plot(x,y)
    plt.plot(xr, func(xr), markersize=10, marker='o')
    plt.show()

def tikslumas(x1,x2,f1,f2,eps): 
    if np.isscalar(x1):
            if np.abs(x1+x2) > eps:
                   s=  np.abs(x1-x2)/(np.abs(x1+x2)+np.abs(f1)+np.abs(f2))
            else:  
                s=  np.abs(x1-x2)+abs(f1)+abs(f2);  
    else:
        if (sum(np.abs(x1+x2)) > eps):
               s=  sum(np.abs(x1-x2))/sum(np.abs(x1+x2)+np.abs(f1)+np.abs(f2))
        else:  
            s=  sum(np.abs(x1-x2)+abs(f1)+abs(f2));  
    return s

#--------------------------------------------------------------

# daugianario šaknų intervalo atvaizdavimas
x = np.linspace(-7, 10, 100)
y = fx(x)
plt.plot(x,y)
plt.plot(Rneig, fx(Rneig), markersize=10, marker='o')
plt.plot(Rteig, fx(Rteig), markersize=10, marker='o')
plt.show()

# daugianario atvaizdavimas
x = np.linspace(0, 3, 100)
y = fx(x)
plt.plot(x,y)
plt.show()


# šaknų intervalų atkyrimas
skenavimas(fx, Rneig, Rteig)

print('Daugianaris: ')
print()
# radimas šaknų stygų metodu
i = 0
while i < len(taskai):
    x = stygu(fx, taskai[i] , taskai[i+1])
    atvaizdavimas(fx, x)
    print('Metodas : {0:11}  Intervalas: {1} / {2}     Sprendinys x = {3:5}'.format('Stygų',taskai[i], taskai[i+1], x) )
    print()
    i = i + 2  
print()

# radimas šaknų kirstiniu metodu
i = 0
while i < len(taskai):
    x = kirstiniu(fx, taskai[i])
    atvaizdavimas(fx, x)
    print('Metodas : {0:11}  Artiniai: {1}    Sprendinys x = {2:5}'.format('Kvazi_Niutono(kirstiniu)',taskai[i], x) )
    print()
    i = i + 2  
print()

# radimas šaknų skenavimo kintančių žingsniu metodu
i = 0
while i < len(taskai):
    x = skenavimasS(fx, taskai[i] , taskai[i+1])
    atvaizdavimas(fx, x)
    print('Metodas : {0:11}  Intervalas: {1} / {2}     Sprendinys x = {3:5}'.format('Skenavimo su kintančiu žingsniu',taskai[i], taskai[i+1], x) )
    print()
    i = i + 2  
print()

print("Patikrinimas:")
koef = [0.63, -3.92, 7.95, -5.50 ,0.53]
print(np.roots(koef))
