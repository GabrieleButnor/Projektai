# Intelektikos pagrindai 2021
# Gabrielė Butnoriūtė IFF-8/7
# Trečias laboratorinis darbas: "Dirbtiniai neuroniniai tinklai"

import numpy as np
import matplotlib.pyplot as plt
from numpy.core.defchararray import array
import pandas 
from collections import Counter
from sklearn.preprocessing import StandardScaler
import math

np.seterr(over='ignore')

# Apmokymo procesas, atnaujinant svorius
def fit(weight, X, y, rate):
      output = net_input(weight, X)
      errors = y - output
      weight[1:] = weight[1:] + (rate * X.T.dot(errors))
      weight[0] += rate * errors.sum()
      return weight

# Tiesinės aktyvavimo funkcjos išraiška
def net_input(weight, X):
    return np.dot(X, weight[1:]) + weight[0]

# Rezultatų, prognozuojamų reikšmių radimas
def predict(weight, X):
    return net_input(weight, X)



# Kategorinių atributų keitimas tolydinio tipo kintamuoju
def conversion(element, number, column):
    for i in data_set.index:
        if (data_set[column].values[i] == element):
            data_set.loc[i, column] = number

# Vidutinės kvadratinės prognozės klaidos reikšmės radimas
def MseCalculation(M):
    m = len(M)
    sum = 0
    for i in range(m):
        sum = sum + (M[i] * M[i])
    mse = (1 / m)  * sum
    return mse

# Duomenų failas
data_file = "L3\Duom.txt"

# Nuskaitomas duomenų failas
data_set = pandas.read_csv(filepath_or_buffer = data_file, sep=";", header = "infer")



# Lyties tuščių laukų panaikinimas užpildant dažniausio pasikartojančia reikšme
nan_value = float("NaN")
value = (Counter(data_set.gender).most_common()[0][0])
data_set.gender.replace(nan_value, value, inplace=True)

# Kategorinio tipo duomenų unikalių reikšmių skaičiaus radimas
unique_gender= data_set.gender.unique()
unique_age = data_set.age.unique()
unique_year = data_set.year.unique()
unique_country = data_set.country.unique()
unique_generation = data_set.generation.unique()

# Kategorinio tipo duomenų pavertimas tolydinio tipo, skaitinėmis reikšmėmis
number = 0
for el in unique_country:
    number = number + 1
    conversion(el, number, 'country')
number = 0
for el in unique_year:
    number = number + 1
    conversion(el, number, 'year')
number = 0
for el in unique_gender:
    number = number + 1
    conversion(el, number, 'gender')
number = 0
for el in unique_age:
    number = number + 1
    conversion(el, number, 'age')
number = 0
for el in unique_generation:
    number = number + 1
    conversion(el, number, 'generation')


# Lyties tuščių laukų panaikinimas užpildant dažniausio pasikartojančia reikšme
nan_value = float("NaN")
value = (Counter(data_set.gender).most_common()[0][0])
data_set.gender.replace(nan_value, value, inplace=True)


#  Išvesties duomenų masyvas
Y = data_set["suicides_no"].values
Yall = data_set["suicides_no"].values

# Panaikinimas didelių reikšmių stulpelių
data = data_set.drop("HDI_for_year", axis=1)
data = data.drop("gdp_for_year", axis=1)
data = data.drop("gdp_per_capital", axis=1)
data = data.drop("population", axis=1)
# Iš įvesčių pašalinamas išvesties stulpelis
data = data.drop("suicides_no", axis=1)

# Įvesčių duomenų masyvas
X = data.values
Xall = data.values

# Duomenų blokai, epochų sk, mokymosi greitis
#parts = 5
# parts = 20
parts = 10
epoch = 1000
lr = 0.0001
# lr = 0.001
# lr = 0.00001
# lr = 0.000001

# Duomenų išskyrimas blokais, validavimui ir mokymui
X = np.array_split(X, parts)
Y = np.array_split(Y, parts)

# Pirminių svorių atsitiktinis sugeneravimas
weights = np.random.rand(len(X[0][0])+1)
print("Svorių keoficientų reikšmės prieš apmokymą:")
print(weights)
print()

# Kryžminės patikros, mokymo metodas
mseall = []
for epo in range(epoch):                               # epochos
    mse = []
    for iter in range(parts):                          # iteracijos
        for part in range(parts):                      # duomenų poaibiai
            if(iter == part):                          # validavimo atvejis
                layer0 = X[part]                       # pirmas sluoksnis - tapatybės
                layer1 =  predict(weights, X[part])    # antras sluoksnis - tiesinis
            else:                                      # mokymo atvejis
                layer0 = X[part]
                weights = fit(weights, X[part], Y[part], lr)
        res = predict(weights, Xall)
        error = Yall - res
        mse.append(MseCalculation(error))

    # kievinos epochos visų iteracijų MSE reišmės
    print("Epocha " + str(epo) + "  :  " + "mse = " + str(mse))     

print()
print("Svorių keoficientų reikšmės po apmokymą:")
print(weights)
res = predict(weights, Xall)
error = Yall - res
mseall.append(MseCalculation(error))
print()
print("MSE reikšmė:")
print(mseall)

