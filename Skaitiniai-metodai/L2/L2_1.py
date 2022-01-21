import numpy as np
from PyFunkcijos import *

# užduotis 6:
# 3𝑥1 + 𝑥2 − 𝑥3 + 5𝑥4 = 20
# − 3𝑥1 + 4𝑥2 − 8𝑥3 − 𝑥4 = −36
# 𝑥1 − 3𝑥2 + 7𝑥3 + 6𝑥4 = 41
# 5𝑥2 − 9𝑥3 + 4𝑥4 = −16


 # koeficientu matrica
A = np.matrix([[ 3,  1, -1,  5],
             [-3,  4, -8, -1],
             [ 1, -3,  7,  6],
             [ 0,  5, -9,  4]]).astype(np.float)   

#matrica prieš pakeitimus, tikrinimui
A1 = np.matrix([[ 3,  1, -1,  5],
             [-3,  4, -8, -1],
             [ 1, -3,  7,  6],
             [ 0,  5, -9,  4]]).astype(np.float)     

#laisvuju nariu vektorius
b=(np.matrix([20, -36, 41, -16])).transpose().astype(np.float)

n=(np.shape(A))[0]   # lygciu skaicius
nb=(np.shape(b))[1]  # laisvuju nariu vektoriu skaicius

AA=np.hstack((A,b))  #isplestoji matrica

#užduoties matricų išvedimas
print("Užduoties sąlyga:")
print("A =");print(A);print()
print("b = ");print(b);print()
print("lygciu skaicius n = ");print(n);print()
print("laisvuju nariu vektoriu skaicius nb = ");print(nb);print()
print("Išplėstoji matrica:")
print("AA = ");print(AA);print()


# QR skaida
Q=np.identity(n)
for i in range (0, n-1):
    z = A[i:n,i]                      #stupelis matricos
    zp = np.zeros(np.shape(z))        #atspindzio vaktorius nuliais
    zp[0] = np.linalg.norm(z)         #atspindzio vektorius 
    skirtumas = z-zp
    normale = skirtumas / np.linalg.norm(skirtumas)
    Qi = np.identity(n-i) - 2 * normale * normale.transpose()
    #pertvarkom A matricos dali
    A[i:n,:] = Qi.dot(A[i:n,:])   
    # tarpiniai
    # print("Tarpinė skaidos matrica")
    # print(Qi);print()
    print("Tarpinė, pertvarkoma koeficientų matrica")
    print(A);print()
    #pildom qr skaidos galutene matricą
    Q = Q.dot(
        np.vstack(
        (
            np.hstack((np.identity(i),np.zeros(shape=(i,n-i)))),
            np.hstack((np.zeros(shape=(n-i,i)),Qi))
        )
        )
    )

print("Q matrica")
print(Q);print()
print("R matrica")
print(A);print()

# QR skaida atgalinis etapas
b1 = Q.transpose().dot(b)
x = np.zeros(shape=(n,nb))
tikslumas=1e-5
#pr, pab, žingsnis
for i in range (n-1, -1, -1):
   x[i,:] = (b1[i,:] - A[i,i+1:n] * x[i+1:n,:]) / A[i,i]


print("Turima koeficientų matrica yra singuliari, turi be galo daug sprendinių.")
print("Lygčių sistemos determianatas: ")
d = np.linalg.det(A1)
print(d);print()

print("QR skaida gautas atsakymas:"); print()
print("x = "); print(x);print()


# patikrinimas skaidų matricų
Qp,Rp = np.linalg.qr(A1)
print("Q patikrinta : "); print(Qp); print()
print("R patikrinta : "); print(Rp); print()

# patikrinimas istačius reikšmes
rez = A1 * x
print("Istačius x reikšmes į pradinę sąlygą laisvus narius gauname: "); print(rez);print()

laisvi = Q.dot(A)
print("Apskaičiuota mradinės matricos reikšmė naudojantis gautomis Q, R reikšmėmis:");print(laisvi);print()
laisvi =laisvi*x
print("Apskaičiuoti laisvi nariai naudojantis gautomis Q, R ir x reikšmėmis:");print(laisvi);print()

