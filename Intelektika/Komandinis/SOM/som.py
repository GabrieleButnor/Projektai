
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
import math 
from sklearn.preprocessing import StandardScaler


# Svorių reikšmių atnaujinimas
def UpdateWeights(weights, sample, C, alpha) :          
    for i in range( len(sample) ) :
        weights[C][i] = weights[C][i] + alpha * (sample[i] - weights[C][i])   
    return weights

# Duomenų skirstymas į du klasterius
def Winner2Clusters(weights, sample) :          
    D0 = 0       
    D1 = 0    
    for i  in range( len(sample) ) :              
        D0 = D0 + math.pow( (sample[i] - weights[0][i]), 2 )
        D1 = D1 + math.pow( (sample[i] - weights[1][i]), 2 )
    if D0 > D1 :
        return 1
    else : 
        return 0  

# Duomenų skirstymas į tris klasterius
def Winner3Clusters(weights, sample) :          
    D0 = 0       
    D1 = 0    
    D2 = 0
    for i  in range( len(sample) ) :              
        D0 = D0 + math.pow( (sample[i] - weights[0][i]), 2 )
        D1 = D1 + math.pow( (sample[i] - weights[1][i]), 2 )
        D2 = D2 + math.pow( (sample[i] - weights[2][i]), 2 )
    if D0 < D1 and D0 < D2 :
        return 0
    elif D1 < D0 and D1 < D2:
        return 1
    else: 
        return 2 

# Duomenų skirstymas į keturis klasterius
def Winner4Clusters(weights, sample) :          
    D0 = 0       
    D1 = 0    
    D2 = 0
    D3 = 0 
    for i  in range( len(sample) ) :              
        D0 = D0 + math.pow( (sample[i] - weights[0][i]), 2 )
        D1 = D1 + math.pow( (sample[i] - weights[1][i]), 2 )
        D2 = D2 + math.pow( (sample[i] - weights[2][i]), 2 )
        D3 = D3 + math.pow( (sample[i] - weights[3][i]), 2 )
    if D0 < D1 and D0 < D2 and D0 < D3:
        return 0
    elif D1 < D0 and D1 < D2 and D1 < D3:
        return 1
    elif D2 < D0 and D2 < D1 and D2 < D3:
        return 2        
    else: 
        return 3


#-----------------------------------
# main blokas 
#-----------------------------------

# Duomenų failas
#df = pd.read_csv('C:\\Users\\Greta\\Desktop\\studijos\\III kursas\\II semestras\\Intelektikos pagrindai\\SOM\\4lab300.csv')
df = pd.read_csv('D:\\KTU\\6 semestras\\Intelektikos pagrindai\\komandinis\\SOM\\4lab300.csv')

# Duomenų rinkinio nustatymas
dataSet = 1
#dataSet = 2
#dataSet = 3

# Skirstymas duomenų pagal įmestus taškus ir rezultatyvius perdavimus
if(dataSet == 1):    
    title = "Įmestų taškų ir rezultatyvių perdavimų diagrama"
    xlabel = "Taškai"
    ylabel = "Rezultatyvūs perdavimai"
    plt.scatter(df.iloc[:, 1], df.iloc[:, 3], color="purple", marker='.')
    plt.grid()
    plt.title(title)
    plt.xlabel(xlabel)
    plt.ylabel(ylabel)
    plt.show()
    data = np.column_stack((df.iloc[:, 1], df.iloc[:, 3]))
    
# Skirstymas duomenų pagal ūgį ir atkovotus kamuolius
if(dataSet == 2):    
    title = "Ūgio ir atkovotų kamuolių diagrama"
    xlabel = "Ūgis"
    ylabel = "Atkovoti kamuoliai"
    plt.scatter(df.iloc[:, 5], df.iloc[:, 2], color="purple", marker='.')
    plt.grid()
    plt.title(title)
    plt.xlabel(xlabel)
    plt.ylabel(ylabel)
    plt.show()
    data = np.column_stack((df.iloc[:, 5], df.iloc[:, 2]))

# Skirstymas duomenų pagal ūgį ir atkovotus kamuolius
if(dataSet == 3):    
    title = "Amžiaus ir sužaistų ringtynių diagrama"
    xlabel = "Amžius"
    ylabel = "Sužaistos rungtynės"
    plt.scatter(df.iloc[:, 0], df.iloc[:, 4], color="purple", marker='.')
    plt.grid()
    plt.title(title)
    plt.xlabel(xlabel)
    plt.ylabel(ylabel)
    plt.show()
    data = np.column_stack((df.iloc[:, 0], df.iloc[:, 4]))
    
# Duomenų rinkinio bei skaičiavimų parametrai
rows, colums = len(data), len(data[0])
alpha = 0.5
stepsMax = 1000



#-------------------------------------------------------------------
# Skirstymas į 2 klasterius
#-------------------------------------------------------------------

clusters = 2

weights = np.random.random_sample(size=(rows,clusters))
weights =  np.transpose(weights)

data = StandardScaler().fit_transform(data) 

for i in range(stepsMax):
    for j in range(rows):
        sample = data[j]
        C = Winner2Clusters(weights, sample)
        weights = UpdateWeights(weights, sample, C, alpha)

data_y = []
for j in range(rows):
    sample = data[j]
    C = Winner2Clusters(weights, sample)
    data_y.append(C)


for j in range(rows):
    if(data_y[j] == 0):
        plt.scatter(data[j][0], data[j][1], color="blue", marker='.')
    if(data_y[j] == 1):
        plt.scatter(data[j][0], data[j][1], color="red", marker='.')

plt.grid()
plt.title(title)
plt.xlabel(xlabel)
plt.ylabel(ylabel)
plt.show()


#-------------------------------------------------------------------
# Skirstymas į 3 klasterius
#-------------------------------------------------------------------

clusters = 3

weights = np.random.random_sample(size=(rows,clusters))
weights =  np.transpose(weights)

data = StandardScaler().fit_transform(data) 

for i in range(stepsMax):
    for j in range(rows):
        sample = data[j]
        C = Winner3Clusters(weights, sample)
        weights = UpdateWeights(weights, sample, C, alpha)

data_y = []
for j in range(rows):
    sample = data[j]
    C = Winner3Clusters(weights, sample)
    data_y.append(C)

for j in range(rows):
    if(data_y[j] == 0):
        plt.scatter(data[j][0], data[j][1], color="blue", marker='.')
    if(data_y[j] == 1):
        plt.scatter(data[j][0], data[j][1], color="red", marker='.')
    if(data_y[j] == 2):
        plt.scatter(data[j][0], data[j][1], color="green", marker='.')
plt.title(title)
plt.grid()
plt.xlabel(xlabel)
plt.ylabel(ylabel)
plt.show()



#-------------------------------------------------------------------
# Skirstymas į 4 klasterius
#-------------------------------------------------------------------

clusters = 4

weights = np.random.random_sample(size=(rows,clusters))
weights =  np.transpose(weights)

data = StandardScaler().fit_transform(data) 

for i in range(stepsMax):
    for j in range(rows):
        sample = data[j]
        C = Winner4Clusters(weights, sample)
        weights = UpdateWeights(weights, sample, C, alpha)

data_y = []
for j in range(rows):
    sample = data[j]
    C = Winner4Clusters(weights, sample)
    data_y.append(C)

for j in range(rows):
    if(data_y[j] == 0):
        plt.scatter(data[j][0], data[j][1], color="blue", marker='.')
    if(data_y[j] == 1):
        plt.scatter(data[j][0], data[j][1], color="red", marker='.')
    if(data_y[j] == 2):
        plt.scatter(data[j][0], data[j][1], color="green", marker='.')
    if(data_y[j] == 3):
        plt.scatter(data[j][0], data[j][1], color="purple", marker='.')
plt.title(title)
plt.grid()
plt.xlabel(xlabel)
plt.ylabel(ylabel)
plt.show()