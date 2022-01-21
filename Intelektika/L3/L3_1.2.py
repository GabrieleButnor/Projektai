
# Intelektikos pagrindai 2021
# Gabrielė Butnoriūtė IFF-8/7
# Trečias laboratorinis darbas: "Dirbtiniai neuroniniai tinklai"

import decimal
import numpy as np
from numpy.core.numeric import NaN
import pandas as pd
import matplotlib.pyplot as plt
import math
from decimal import *
np.seterr(over='ignore')

# Tiesinio neurono klasė
class AdaptiveLinearNeuron(object):
   def __init__(self, rate = 0.01, niter = 10):
      self.rate = rate
      self.niter = niter

   # Neurono pradinių svorių ir poslinkio atsitintinių reikšmių suteikimas  
   def fit(self, X, y):
      self.weight = np.random.rand(1 + X.shape[1])
      print(self.weight)
      self.errors = []
      self.cost = []
      self.mse = []

      for i in range(self.niter):
         output = self.net_input(X)
         errors = y - output
         self.weight[1:] += self.rate * X.T.dot(errors)
         self.weight[0] += self.rate * errors.sum()
         cost = (errors**2).sum() / 2.0
         self.cost.append(cost)
         mse = (errors**2).sum() / len(errors)
         self.mse.append(mse)
      return self

    # Reikšmių prognozavimo sakičiavimas
   def net_input(self, X):
      return np.dot(X, self.weight[1:]) + self.weight[0]

   def activation(self, X):
      return self.net_input(X)

   def predict(self, X):
      return self.activation(X)


# Duomenų failo nuskaitymas
def readFileData(file):
    data = []
    years = []
    sunsports = []
    f = open(file, "r")
    lines = f.readlines()
    for line in lines:
        values = line.split('\t')
        years.append(int(values[0]))
        sunsports.append(int(values[1]))     
    f.close()
    data.append(years)
    data.append(sunsports)
    return data

# Duomenų grafiko atvaizdavimas
def dataPlotGraph(data):
    plt.plot(data[0], data[1], color="purple", marker='.')
    plt.title("Saulės dėmių aktyvumo grafikas 1700-2014 metais")
    plt.xlabel("Metai")
    plt.ylabel("Saulės dėmių skaičius")
    plt.grid()
    plt.show()

# Įvesčių ir išvesčių duomenų matricos sudarymas 
def dataMatrixFormating(sunspots, n):
    P = []
    T = []
    for m in range(len(sunspots) - n ):
        temp = []
        for i in range(m, m + n):
            temp.append(sunspots[i])
        else:
            T.append(sunspots[i + 1])
        P.append(temp)
    return P, T

# Trimatė diagrama, vaizduojanti dvi įvesties ir išvesties duomenis
def dataPlot3DGraph(P, T):
    fig = plt.figure()
    ax = fig.add_subplot(111, projection='3d')
    ax.scatter(P[0], P[1], T, color="purple")
    ax.set_title('Įvesčių ir išvesties duomenų grafikas')
    ax.set_xlabel('Pirmos įvesties saulės dėmių skaičius')
    ax.set_ylabel('Antros įvesties saulės dėmių skaičius')
    ax.set_zlabel('Išvesties saulės dėmių skaičius') 
    plt.show()

# Mokymui ir testavimui metų duomenų atskyrimas
def yearSplit(years, count, n):
    Yu = []
    Yv = []
    m = len(years)
    for i in range(n , m):
        if(i < count + n):
            Yu.append(years[i])
        else:
            Yv.append(years[i])
    return Yu, Yv

# Mokymui ir testavimui dėmių duomenų atskyrimas n = 2
def dataSplit(P, T, count):
    Pu = []
    Tu = []
    Pv = []
    Tv = []
    m = len(T)
    print('\n', "Duomenų rinkinio dydis:")
    print( "  " , m)
    for i in range(m):
        if(i < count):
            Pu.append( [P[0, i], P[1, i]] )
            Tu.append(T[i])
        else:
            Pv.append( [P[0, i], P[1, i]] )
            Tv.append(T[i])
    return Pu,Tu,Pv,Tv

# Mokymui ir testavimui dėmių duomenų atskyrimas n = 6
def dataSplitTo6(P, T, count):
    Pu = []
    Tu = []
    Pv = []
    Tv = []
    m = len(T)
    print('\n', "Duomenų rinkinio dydis:")
    print( "  " , m)
    for i in range(m):
        if(i < count):
            Pu.append( [P[0, i], P[1, i], P[2, i], P[3, i], P[4, i], P[5, i]] )
            Tu.append(T[i])
        else:
            Pv.append( [P[0, i], P[1, i], P[2, i], P[3, i], P[4, i], P[5, i]] )
            Tv.append(T[i])
    return Pu,Tu,Pv,Tv

# Mokymui ir testavimui dėmių duomenų atskyrimas n = 10
def dataSplitTo10(P, T, count):
    Pu = []
    Tu = []
    Pv = []
    Tv = []
    m = len(T)
    print('\n', "Duomenų rinkinio dydis:")
    print( "  " , m)
    for i in range(m):
        if(i < count):
            Pu.append( [P[0, i], P[1, i], P[2, i], P[3, i], P[4, i], P[5, i],P[6, i],P[7, i], P[8, i],P[9, i]] )
            Tu.append(T[i])
        else:
            Pv.append( [P[0, i], P[1, i], P[2, i], P[3, i], P[4, i], P[5, i],P[6, i],P[7, i], P[8, i],P[9, i]] )
            Tv.append(T[i])
    return Pu,Tu,Pv,Tv


# Realių ir prognozuojant gautų reikšmių palyginymų garfikas
def dataCompareGraph(T, Ts, Y, title):
    plt.plot(Y, T, color="purple", marker='.', label='Tikėtinos reikšmės')
    plt.plot(Y, Ts, color="green", marker='.', label='Prognozuojamos reikšmės')  
    plt.title(title)
    plt.legend(loc='upper left', frameon=True)
    plt.xlabel("Metai")
    plt.ylabel("Saulės dėmių skaičius")
    plt.grid()
    plt.show()

# Klaidų vektoriaus sudarymas
def mistakesVector(T, Ts):
    M = []
    m = len(T)
    for i in range(m):
        mistake = T[i] - Ts[i]
        M.append(mistake)
    return M

# Klaidų vektoriaus grafikas
def mistakesPlotGraph(M, Y, title):
    plt.plot(M, Y, color="purple", marker='.')
    plt.title(title)
    plt.xlabel("Metai")
    plt.ylabel("Paklaida")
    plt.grid()
    plt.show()

# Klaidų vektoriaus histograma
def mistakeHistogram(M, title):
    plt.hist(M, color='purple', ec='black')
    plt.title(title)
    plt.xlabel("Paklaida")
    plt.ylabel("Dažnis")
    plt.grid(axis = 'y')
    plt.show()

# Vidutinės kvadratinės prognozės klaidos reikšmės radimas
def MseCalculation(M):
    m = len(M)
    sum = 0
    for i in range(m):
        sum = sum + (M[i] * M[i])
    mse = (1 / m)  * sum
    return mse

# Prognozės absoliutaus nuokrypio medianos radimas
def MadCalculation(M):
    mad = np.median(np.absolute(M))
    return mad


# Kvadratinės klaidos(mse) keitimosi grafikas
def plotGraph(iter, mse, lr):
    plt.plot(iter, mse, color="purple")
    plt.title("Kvadratinės klaidos(mse) grafikas. Mokymosi greitis: {:n}".format(lr))
    plt.xlabel("Epochos")
    plt.ylabel("MSE reikšmės")
    plt.grid()
    plt.show()


#--------------------------------------------------------------------------------
# main
#--------------------------------------------------------------------------------

data = []
data = readFileData("L3\sunspot.txt")
# print('\n',"Duomenų matrica:", '\n')
# print(data); print('\n')
dataPlotGraph(data)

#--------------------------------------------------------------------------------
# n = 2
#--------------------------------------------------------------------------------

print(" n = 2")
print("------------------------------------------") 

# Duomenų matrica
n = 2
P, T = dataMatrixFormating(data[1], n)
P = np.transpose(P)
dataPlot3DGraph(P, T)

# Testavimo, mokymo rinkiniai
count = 200
Yu, Yv = yearSplit(data[0], count, n)
Pu, Tu, Pv, Tv = dataSplit(P,T, count)
print('\n',"Mokymo duomenų rinkinio dydis:")
print("  " , len(Pu))
print('\n',"Testavimo duomenų rinkinio dydis:")
print("  " , len(Pv))

# Mokymosi greičio ir epochų nustatymas
lr = 0.01
epoch = 1000

inter = []
for i in range(0,1000,1):
    inter.append(i)

# Tiesionio neurono mokymas mažinant mokymosi greitį
mse_value = 1000
Pu = np.array(Pu)
while math.isnan(mse_value) or mse_value < 150 or mse_value > 300 :
    aln1 = AdaptiveLinearNeuron(lr, epoch).fit(Pu,Tu)
    plotGraph(inter, aln1.mse, lr)
    mse_value = aln1.mse[len(aln1.mse) - 1]
    lr = lr / 10

print('\n',"Tiesinio neurono iteracinis modelis (n = 2)")
print("------------------------------------------")
print('\n',"Svorių koeficientų ir poslinkio (bias) reikšmės:")
for i in range(1,len(aln1.weight)):
    print("  w" + str(i) + " = " + str(aln1.weight[i]))
print("  b = ", aln1.weight[0])


# Tiesinio neurono iteracinio modelio prognozės mokymo rinkiniui
Tsu = aln1.predict(Pu)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (mokymo rinkinys) n = 2"
dataCompareGraph(Tu, Tsu, Yu, title)

# Tiesinio neurono iteracinio modelio prognozės  testavimo rinkinio
Tsv = aln1.predict(Pv)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (testavimo rinkinys) n = 2"
dataCompareGraph(Tv, Tsv, Yv, title)


# Paklaidos radimas mokymo rinkiniui, grfaikas, histograma 
Mu = mistakesVector(Tu, Tsu)
title = "Mokymo rinkinio prognozės paklaidos grafikas n = 2"
mistakesPlotGraph(Yu, Mu, title)
mistakeHistogram(Mu, title)

# Paklaidos radimas testavimo rinkiniui, grfaikas, histograma 
Mv = mistakesVector(Tv, Tsv)
title = "Testavimo rinkinio prognozės paklaidos grafikas n = 2"
mistakesPlotGraph(Yv, Mv, title)
mistakeHistogram(Mv, title)

# Vidutinės kvadratinės prognozės klaida mokymo rinkiniui
mse_u = MseCalculation(Mu)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (mokymo rinkinio) n = 2: ")
print("  ", mse_u)

# Vidutinės kvadratinės prognozės klaida testavimo rinkiniui
mse_v = MseCalculation(Mv)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (testavimo rinkinio) n = 2: ")
print("  ", mse_v)

# Absoliutaus nuokrypio mediana mokymo rinkinui
mad_u = MadCalculation(Mu)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (mokymo rinkinio) n = 2: ")
print("  ", mad_u)

# Absoliutaus nuokrypio mediana testavimo rinkinui
mad_v = MadCalculation(Mv)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (testavimo rinkinio) n = 2: ")
print("  ", mad_v)

print('\n')

# --------------------------------------------------------------------------------
# n = 6
# --------------------------------------------------------------------------------

print(" n = 6")
print("------------------------------------------") 

# Duomenų matrica
n = 6
P, T = dataMatrixFormating(data[1], n)
P = np.transpose(P)


# Testavimo, mokymo rinkiniai
count = 200
Yu, Yv = yearSplit(data[0], count, n)
Pu, Tu, Pv, Tv = dataSplitTo6(P,T, count)
print('\n',"Mokymo duomenų rinkinio dydis:")
print("  " , len(Pu))
print('\n',"Testavimo duomenų rinkinio dydis:")
print("  " , len(Pv))

# Mokymosi greičio ir epochų nustatymas
lr = 0.01
epoch = 1000

inter = []
for i in range(0,1000,1):
    inter.append(i)

# Tiesionio neurono mokymas mažinant mokymosi greitį
mse_value = 1000
Pu = np.array(Pu)
while math.isnan(mse_value) or mse_value < 150 or mse_value > 300 :
    aln1 = AdaptiveLinearNeuron(lr, epoch).fit(Pu,Tu)
    plotGraph(inter, aln1.mse, lr)
    mse_value = aln1.mse[len(aln1.mse) - 1]
    lr = lr / 10

print('\n',"Tiesinio neurono iteracinis modelis (n = 6)")
print("------------------------------------------")
print('\n',"Svorių koeficientų ir poslinkio (bias) reikšmės:")
for i in range(1,len(aln1.weight)):
    print("  w" + str(i) + " = " + str(aln1.weight[i]))
print("  b = ", aln1.weight[0])



# Tiesinio neurono iteracinio modelio prognozės mokymo rinkiniui
Tsu = aln1.predict(Pu)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (mokymo rinkinys) n = 6"
dataCompareGraph(Tu, Tsu, Yu, title)

# Tiesinio neurono iteracinio modelio prognozės  testavimo rinkinio
Tsv = aln1.predict(Pv)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (testavimo rinkinys) n = 6"
dataCompareGraph(Tv, Tsv, Yv, title)


# Paklaidos radimas mokymo rinkiniui, grfaikas, histograma 
Mu = mistakesVector(Tu, Tsu)
title = "Mokymo rinkinio prognozės paklaidos grafikas n = 6"
mistakesPlotGraph(Yu, Mu, title)
mistakeHistogram(Mu, title)

# Paklaidos radimas testavimo rinkiniui, grfaikas, histograma 
Mv = mistakesVector(Tv, Tsv)
title = "Testavimo rinkinio prognozės paklaidos grafikas n = 6"
mistakesPlotGraph(Yv, Mv, title)
mistakeHistogram(Mv, title)

# Vidutinės kvadratinės prognozės klaida mokymo rinkiniui
mse_u = MseCalculation(Mu)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (mokymo rinkinio) n = 6: ")
print("  ", mse_u)

# Vidutinės kvadratinės prognozės klaida testavimo rinkiniui
mse_v = MseCalculation(Mv)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (testavimo rinkinio) n = 6: ")
print("  ", mse_v)

# Absoliutaus nuokrypio mediana mokymo rinkinui
mad_u = MadCalculation(Mu)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (mokymo rinkinio) n = 6: ")
print("  ", mad_u)

# Absoliutaus nuokrypio mediana testavimo rinkinui
mad_v = MadCalculation(Mv)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (testavimo rinkinio) n = 6: ")
print("  ", mad_v)

print('\n')


#--------------------------------------------------------------------------------
# n = 10
#--------------------------------------------------------------------------------

print(" n = 10")
print("------------------------------------------") 

# Duomenų matrica
n = 10
P, T = dataMatrixFormating(data[1], n)
P = np.transpose(P)


# Testavimo, mokymo rinkiniai
count = 200
Yu, Yv = yearSplit(data[0], count, n)
Pu, Tu, Pv, Tv = dataSplitTo10(P,T, count)
print('\n',"Mokymo duomenų rinkinio dydis:")
print("  " , len(Pu))
print('\n',"Testavimo duomenų rinkinio dydis:")
print("  " , len(Pv))

# Mokymosi greičio ir epochų nustatymas
lr = 0.01
epoch = 1000

inter = []
for i in range(0,1000,1):
    inter.append(i)

# Tiesionio neurono mokymas mažinant mokymosi greitį
mse_value = 1000
Pu = np.array(Pu)
while math.isnan(mse_value) or mse_value < 150 or mse_value > 300 :
    aln1 = AdaptiveLinearNeuron(lr, epoch).fit(Pu,Tu)
    plotGraph(inter, aln1.mse, lr)
    mse_value = aln1.mse[len(aln1.mse) - 1]
    lr = lr / 10

print('\n',"Tiesinio neurono iteracinis modelis (n = 10)")
print("------------------------------------------")
print('\n',"Svorių koeficientų ir poslinkio (bias) reikšmės n = 10:")
for i in range(1,len(aln1.weight)):
    print("  w" + str(i) + " = " + str(aln1.weight[i]))
print("  b = ", aln1.weight[0])



# Tiesinio neurono iteracinio modelio prognozės mokymo rinkiniui
Tsu = aln1.predict(Pu)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (mokymo rinkinys) n = 10"
dataCompareGraph(Tu, Tsu, Yu, title)

# Tiesinio neurono iteracinio modelio prognozės  testavimo rinkinio
Tsv = aln1.predict(Pv)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (testavimo rinkinys) n = 10"
dataCompareGraph(Tv, Tsv, Yv, title)


# Paklaidos radimas mokymo rinkiniui, grfaikas, histograma 
Mu = mistakesVector(Tu, Tsu)
title = "Mokymo rinkinio prognozės paklaidos grafikas n = 10"
mistakesPlotGraph(Yu, Mu, title)
mistakeHistogram(Mu, title)

# Paklaidos radimas testavimo rinkiniui, grfaikas, histograma 
Mv = mistakesVector(Tv, Tsv)
title = "Testavimo rinkinio prognozės paklaidos grafikas n = 10"
mistakesPlotGraph(Yv, Mv, title)
mistakeHistogram(Mv, title)

# Vidutinės kvadratinės prognozės klaida mokymo rinkiniui
mse_u = MseCalculation(Mu)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (mokymo rinkinio) n = 10: ")
print("  ", mse_u)

# Vidutinės kvadratinės prognozės klaida testavimo rinkiniui
mse_v = MseCalculation(Mv)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (testavimo rinkinio) n = 10: ")
print("  ", mse_v)

# Absoliutaus nuokrypio mediana mokymo rinkinui
mad_u = MadCalculation(Mu)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (mokymo rinkinio) n = 10: ")
print("  ", mad_u)

# Absoliutaus nuokrypio mediana testavimo rinkinui
mad_v = MadCalculation(Mv)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (testavimo rinkinio) n = 10:")
print("  ", mad_v)

print('\n')