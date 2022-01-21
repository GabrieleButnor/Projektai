import numpy as np;
import matplotlib.pyplot as plt;

# sudaryta netiesinė lygtis
def fc(c):
  return -30 + (882 / c) * (1 - np.e**-(7*c/180) )
#  return (-30*c*np.e**(7*c/180) + 882*np.e**(7*c/180) - 882 ) / c*np.e**(7*c/180)
#   return -30 + (882 / c) * (1 - np.e**-(0.0388*c) )

# kintamieji
taskai = [] 
tiks = 1e-10

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


#--------------------------------------------------------------

def atvaizdavimas(func, xr):   
    x = np.linspace(5, 8, 100)
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

# lygties šaknų intervalo atvaizdavimas
x = np.linspace(5, 8, 100)
y = fc(x)
plt.plot(x,y)
plt.show()

# šaknų intervalų atkyrimas
skenavimas(fc, 0.1, 15)

# radimas šaknų kirstiniu metodu
i = 0
while i < len(taskai):
    x = kirstiniu(fc, taskai[i])
    atvaizdavimas(fc, x)
    print('Metodas : {0:11}  Artiniai: {1}    Sprendinys x = {2:5}'.format('Kvazi_Niutono(kirstiniu)',taskai[i], x) )
    print()
    i = i + 2  
print()

