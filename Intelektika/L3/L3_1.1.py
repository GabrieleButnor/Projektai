
# Intelektikos pagrindai 2021
# Gabrielė Butnoriūtė IFF-8/7
# Trečias laboratorinis darbas: "Dirbtiniai neuroniniai tinklai"

import numpy as np
from sklearn.linear_model import LinearRegression
import matplotlib.pyplot as plt


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

# Mokymui ir testavimui dėmių duomenų atskyrimas kai n = 2
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

# Realių ir prognozuojant gautų reikšmių palyginimų grafikas
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


#--------------------------------------------------------------------------------
# main
#--------------------------------------------------------------------------------

data = []
data = readFileData("L3\sunspot.txt")
#print('\n',"Duomenų matrica:", '\n')
#print(data); print('\n')
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


# Tiesinės autoregresijos modelis, svoriai ir poslinkis (bias)
model = LinearRegression()
model.fit(Pu, Tu)
w1 = model.coef_[0]
w2 = model.coef_[1]
b = model.intercept_
print('\n',"Tiesinės autoregresijos modelis (n = 2)")
print("------------------------------------------")
print('\n',"Svorių koeficientų ir poslinkio (bias) reikšmės:")
print("  w1 = " , w1)
print("  w2 = ", w2)
print("  b = ", b)


# Tiesinės autoregresijos modelio prognozės mokymo rinkiniui
Tsu = model.predict(Pu)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (mokymo rinkinys) n = 2"
dataCompareGraph(Tu, Tsu, Yu, title)

# Tiesinės autoregresijos modelio prognozės testavimo rinkinio
Tsv = model.predict(Pv)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (testavimo rinkinys) n = 2"
dataCompareGraph(Tv, Tsv, Yv, title)


# Paklaidos radimas mokymo rinkiniui, grafikas, histograma 
Mu = mistakesVector(Tu, Tsu)
title = "Mokymo rinkinio prognozės paklaidos grafikas n = 2"
mistakesPlotGraph(Yu, Mu, title)
mistakeHistogram(Mu, title)

# Paklaidos radimas testavimo rinkiniui, grafikas, histograma 
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

#--------------------------------------------------------------------------------
# n = 6
#--------------------------------------------------------------------------------

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


# Tiesinės autoregresijos modelis, svoriai ir poslinkis (bias)
model6 = LinearRegression()
model6.fit(Pu, Tu)
w1 = model6.coef_[0]
w2 = model6.coef_[1]
w3 = model6.coef_[2]
w4 = model6.coef_[3]
w5 = model6.coef_[4]
w6 = model6.coef_[5]
b = model6.intercept_
print('\n',"Tiesinės autoregresijos modelis (n = 6)")
print("------------------------------------------")
print('\n',"Svorių koeficientų ir poslinkio (bias) reikšmės:")
print("  w1 = " , w1)
print("  w2 = ", w2)
print("  w3 = ", w3)
print("  w4 = ", w4)
print("  w5 = ", w5)
print("  w6 = ", w6)
print("  b = ", b)


# Tiesinės autoregresijos modelio prognozės mokymo rinkiniui
Tsu6 = model6.predict(Pu)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (mokymo rinkinys) n = 6"
dataCompareGraph(Tu, Tsu6, Yu, title)

# Tiesinės autoregresijos modelio prognozės testavimo rinkinio
Tsv6 = model6.predict(Pv)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (testavimo rinkinys) n = 6"
dataCompareGraph(Tv, Tsv6, Yv, title)

# Paklaidos radimas mokymo rinkiniui, grfaikas, histograma 
Mu6 = mistakesVector(Tu, Tsu6)
title = "Mokymo rinkinio prognozės paklaidos grafikas n = 6"
mistakesPlotGraph(Yu, Mu6, title)
mistakeHistogram(Mu6, title)

# Paklaidos radimas testavimo rinkiniui, grfaikas, histograma 
Mv6 = mistakesVector(Tv, Tsv6)
title = "Testavimo rinkinio prognozės paklaidos grafikas n = 6"
mistakesPlotGraph(Yv, Mv6, title)
mistakeHistogram(Mv6, title)


# Vidutinės kvadratinės prognozės klaida mokymo rinkiniui
mse_u6 = MseCalculation(Mu6)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (mokymo rinkinio) n = 6: ")
print("  ", mse_u6)

# Vidutinės kvadratinės prognozės klaida testavimo rinkiniui
mse_v6 = MseCalculation(Mv6)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (testavimo rinkinio) n = 6: ")
print("  ", mse_v6)

# Absoliutaus nuokrypio mediana mokymo rinkinui
mad_u6 = MadCalculation(Mu6)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (mokymo rinkinio) n = 6: ")
print("  ", mad_u6)

# Absoliutaus nuokrypio mediana testavimo rinkinui
mad_v6 = MadCalculation(Mv6)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (testavimo rinkinio) n = 6: ")
print("  ", mad_v6)

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


# Tiesinės autoregresijos modelis, svoriai ir poslinkis (bias)
model10 = LinearRegression()
model10.fit(Pu, Tu)
w1 = model10.coef_[0]
w2 = model10.coef_[1]
w3 = model10.coef_[2]
w4 = model10.coef_[3]
w5 = model10.coef_[4]
w6 = model10.coef_[5]
w7 = model10.coef_[6]
w8 = model10.coef_[7]
w9 = model10.coef_[8]
w10 = model10.coef_[9]
b = model10.intercept_
print('\n',"Tiesinės autoregresijos modelis (n = 10)")
print("------------------------------------------")
print('\n',"Svorių koeficientų ir poslinkio (bias) reikšmės:")
print("  w1 = " , w1)
print("  w2 = ", w2)
print("  w3 = ", w3)
print("  w4 = ", w4)
print("  w5 = ", w5)
print("  w6 = ", w6)
print("  w7 = ", w7)
print("  w8 = ", w8)
print("  w9 = ", w9)
print("  w10 = ", w10)
print("  b = ", b)


# Tiesinės autoregresijos modelio prognozės mokymo rinkiniui
Tsu10 = model10.predict(Pu)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (mokymo rinkinys) n = 10"
dataCompareGraph(Tu, Tsu10, Yu, title)

# Tiesinės autoregresijos modelio prognozės testavimo rinkinio
Tsv10 = model10.predict(Pv)
title = "Tikrųjų ir prognozuojamų reikšmių palyginimas (testavimo rinkinys) n = 10"
dataCompareGraph(Tv, Tsv10, Yv, title)

# Paklaidos radimas mokymo rinkiniui, grfaikas, histograma 
Mu10 = mistakesVector(Tu, Tsu10)
title = "Mokymo rinkinio prognozės paklaidos grafikas n = 10"
mistakesPlotGraph(Yu, Mu10, title)
mistakeHistogram(Mu10, title)

# Paklaidos radimas testavimo rinkiniui, grfaikas, histograma 
Mv10 = mistakesVector(Tv, Tsv10)
title = "Testavimo rinkinio prognozės paklaidos grafikas n = 10"
mistakesPlotGraph(Yv, Mv10, title)
mistakeHistogram(Mv10, title)


# Vidutinės kvadratinės prognozės klaida mokymo rinkiniui
mse_u10 = MseCalculation(Mu10)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (mokymo rinkinio) n = 10: ")
print("  ", mse_u10)

# Vidutinės kvadratinės prognozės klaida testavimo rinkiniui
mse_v10 = MseCalculation(Mv10)
print('\n',"Vidutinės kvadratinės prognozės klaidos reikšmė (testavimo rinkinio) n = 10: ")
print("  ", mse_v10)

# Absoliutaus nuokrypio mediana mokymo rinkinui
mad_u10 = MadCalculation(Mu10)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (mokymo rinkinio) n = 10: ")
print("  ", mad_u10)

# Absoliutaus nuokrypio mediana testavimo rinkinui
mad_v10 = MadCalculation(Mv10)
print('\n',"Prognozės absoliutaus nuokrypio medianos reikšmė (testavimo rinkinio) n = 10: ")
print("  ", mad_v10)

print('\n')