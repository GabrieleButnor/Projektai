import numpy as np
import matplotlib.pyplot as plt

 #Lagranzo daugianaris 
def Lagranzas(X, j, x):
    n = X.shape[0]
    L = np.ones(x.shape, dtype=np.double)
    for i in range(0, n):    # intervalo 2 taskai
        if (j != i):
            # esant visiems vaizudojamiems taskams, tik vieno mazgo atzvilgiu 
            L = L * ((x - X[i]) / (X[j] - X[i]))  
    return L


 #Lagranzo daugianario isvestine
def LagranzoIsvestine(X, j, x):
    n = X.shape[0]
    DL = np.zeros(x.shape, dtype=np.double)
    for i in range(0, n):
        if (j == i): 
            continue
        Lds = np.ones(x.shape, dtype=np.double)
        for k in range(0,n):
            if ((j != k) and (i != k)):
                Lds = Lds * (x - X[k])
        DL += Lds
    Ldv = np.ones(x.shape, dtype=np.double)
    for k in range(0, n):
        if (k != j): 
            Ldv = Ldv*(X[j] - X[k])
    DL = DL/Ldv
    return DL


# Ermito daugianaris
# konkreciam taskui skaiciuojamas 
def Ermitas(X, j, x):
    L = Lagranzas(X, j, x)             # Lagranzo daugianaris
    DL = LagranzoIsvestine(X, j, X[j]) #Lagranzo daugianario isvestine
    U = (1 - 2 * DL * (x - X[j]))*(L**2)
    V = (x - X[j])*(L**2)
    return U, V
    

# akima formules (skaitinis diferenciavimas)
# tasko isvestines radimas. Pirmas parametras einamas taskas.
def AkimaFormule(x, ximinus1, xi, xiplius1, yi, yiminus1, yiplius1): 
    f = (2*x-xi-xiplius1) / ((ximinus1-xi)*(ximinus1-xiplius1))*yiminus1 
    f += (2*x-ximinus1-xiplius1) / ((xi-ximinus1)*(xi-xiplius1))*yi 
    f += (2*x-ximinus1-xi) / ((xiplius1-ximinus1)*(xiplius1-xi))*yiplius1
    return f

# tasku pozicijos nustatytas isvestiniai skaiciuoti
def Akima(x,y):
    n = x.shape[0]
    DY = np.zeros(x.shape, dtype=np.double) 
    for i in range(n):           # einama per visus dotuosius taskus
        if (i == 0):             # jeigu taskas pats pirmas
            ximinus1 = x[0]      # intervalo pradzia pirmas takas x
            xi = x[1]            # intervalo vidurys seknatis x
            xiplius1 = x[2]      # intervalo galas dar sekantis x
            yiminus1 = y[0]      # intervalo pradzia pirmas takas y
            yi = y[1]            # intervalo vidurys seknatis y
            yiplius1 = y[2]      # intervalo galas dar sekantis y  
            DY[i] = AkimaFormule(ximinus1, ximinus1, xi, xiplius1, yi, yiminus1, yiplius1) 
        elif (i == n-1):         # jeigu taskas pats pirmas
            ximinus1 = x[n-3] 
            xi = x[n-2]  
            xiplius1 = x[n-1] 
            yiminus1 = y[n-3]
            yi = y[n-2]
            yiplius1 = y[n-1]
            DY[n-1] = AkimaFormule(xiplius1, ximinus1, xi, xiplius1, yi, yiminus1, yiplius1)
        else:                   # jeigu viduriniai ne galu taskai
            ximinus1 = x[i-1] 
            xi = x[i] 
            xiplius1 = x[i+1] 
            yiminus1 = y[i-1]
            yi = y[i]
            yiplius1 = y[i+1] 
            DY[i] = AkimaFormule(xi, ximinus1, xi, xiplius1, yi, yiminus1, yiplius1)
    return DY

#--------------------------------------------------------------------------

# Malis 2006 metai
X = np.array([1,2,3,4,5,6,7,8,9,10,11,12])
Y = np.array([22.8806, 24.1999, 28.4987, 31.6118, 33.1856, 34.3569, 32.8721, 30.9421, 30.8454, 30.3405, 25.7535, 21.5325])

plt.axis([-1,15,18,37])
plt.title("Malis. 2006 metai. Temperatura")
plt.scatter(X, Y, color = "purple", marker="o", label = "Temperaturu taskai (mazgai)")

# randame kiekvieno temperaturos tasko isvestine
DY = Akima(X, Y)    # y isvestine pagal x
n = X.shape[0]

# Ermito splainas, kadangi ieskome interpoliavimo kreives tarp 2 tasku (atskiria kiekvienima intervalui)
for i in range(0, n-1):         # einame per visus taskus
    m = 100                     # atvaizudojamu tasku sk
    step = (X[i+1]-X[i]) / m    # atvaiduojamu tasku zinsginis einamame intervale 
    # atvaziudojamu tasku x koordinates interavale
    xatv = np.arange(X[i], X[i + 1], step)  
    f = np.zeros(xatv.shape, dtype=np.double)
    for j in range(0,2):
        U,V = Ermitas(X[i:i+2], j, xatv)        # paduodame intrvalo taskus, 0 arba 1, visus atvaizdavimo taskus
        f = f + U * Y[i+j] + V * DY[i+j]        # randame intervalo interpoliacine kreive
    plt.plot(xatv, f, color = "blue")


plt.grid(1)
plt.legend()
plt.show()
