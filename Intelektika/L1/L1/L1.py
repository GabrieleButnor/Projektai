
# Intelektikos pagrindai 2021
# Gabrielė Butnoriūtė IFF-8/7
# Pirmas laboratorinis darbas: "Duomenų apdorojimas ir analizė"

# bibliotekos
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sn
import pandas
import plotly.express as px
import math
from collections import Counter

#data_file = "L1\PradiniaiDuom_PILNI.txt"
data_file = "L1\Duom.txt"


#------------------------------------------------------------------------------
# Duomenų kokybės analizė
#------------------------------------------------------------------------------

# Randa skaitinių trūkstamų reikšmių procentą 
def MissingValues(data_set_values, missing, n):
    count = 0
    for element in data_set_values:
        if (math.isnan(element)):
           count += 1           
    missing.append(float(count*100/n))

# Randa tekstinių  trūkstamų reikšmių procentą 
def MissingValuesSTR(data_set_values, missing, n):
    count = 0
    for element in data_set_values:
        if (type(element) is float):
            count += 1
    missing.append(float(count*100/n))

# Randa konkrečios reikšmės pasikartojimų skaičių
def ModeRate(data, value):
    count = 0
    for i in data:
        if (i == value):
            count += 1
    return count

# Randa konkrečios reikšmės pasikartojimo procentą
def ModeProc(all_count, value_count):
    return value_count * 100 / all_count


# Išveda gautus rezultatus į terminalą formatu
def PrintToTerminal(text, headers, numbers, comma):
    print(text)
    for i in range(0, len(headers)):        
        line = "  {} : {}"
        if(comma == 1):
            print(line.format(headers[i], "%.3f" % numbers[i]))
        else:
            print(line.format(headers[i], numbers[i]))
    print()


#------------------------------------------------------------------------------
# Duomenų histogramos
#------------------------------------------------------------------------------


# Kategorinių duomenų atvaizdavimas histograma
def HistogramSTR(data, name, bins):
    plt.subplot(211)
    plt.hist(data, bins = bins, rwidth = 0.85, color='purple')
    plt.title(name)
    plt.xlabel("Categories")
    plt.ylabel("Number of data")
    plt.xticks(rotation='vertical')
    plt.show()

# Tolydinių duomenų atvaizdavimas histograma
def HistogramValues(data, name):
    plt.subplot(211)    
    plt.ticklabel_format(style='plain')
    bins = round(1 + 3.22 * math.log(len(data)))
    plt.hist(data, bins = bins,  rwidth = 0.85, color='purple')    
    plt.title(name)
    plt.xlabel("Categories")
    plt.ylabel("Number of data")
    plt.xticks(rotation='vertical')
    plt.show()


#------------------------------------------------------------------------------
# Duomenų kokybė problemų analizė, sprendimas
#------------------------------------------------------------------------------

# Kritinių atributo reikšmių ribų radimas
def CriticalValues(q1, q3):
    qrange = q3 - q1
    lower = q1 - 3 * qrange
    upper = q3 + 3 * qrange
    return lower, upper

# Atributo ūselių ribų radimas
def TendrilsValues(q1, q3):
    qrange = q3 - q1
    lower = q1 - 1.5 * qrange
    upper = q3 + 1.5 * qrange
    return lower, upper

# Kritinių atributo išskirčių kiekių radimas
def OutlierCount(q1, q3, data):
    count_lower = 0
    count_upper = 0
    lower, upper = CriticalValues(q1, q3)
    for item in data:
        if(item < lower):
            count_lower += 1
        if(item > upper):
            count_upper += 1
    return count_lower, count_upper

# Kritinių atributo išskirčių kiekių išvedimas
def OutlierAnalysis(q1, q3, header, data):
    count_lower, count_upper = OutlierCount(q1, q3, data)
    print()
    print(header)
    if(count_lower != 0):
        print( "  Ekstremalios apatinėse reikšmėse. " + str(count_lower))
    if(count_upper != 0):
        print( "  Ekstremalios viršutinėse reikšmėse.  " + str(count_upper))
    print()

# Kritinių atributų išskirčių reikšmių panaikinimas keičiant į ūselio reikšmes
def OutlierFix(q1, q3, data, i):
    c_lower, c_upper = CriticalValues(q1, q3)
    lower, upper = TendrilsValues(q1, q3)
    if(data_set[data].values[i] > c_upper):        
       data_set.loc[i, data] = upper
    if(data_set[data].values[i] < c_lower):
       data_set.loc[i, data] = lower

# Bendro vidaus produkto atributo tuščių laukų užpildymas
def GdpForYearFix( i, average_element):    
    element = average_element[3]      
    if (math.isnan(data_set.gdp_for_year.values[i])):
        find_country = data_set.country.values[i]
        find_data = data_set.year.values[i]
        rows = data_set.loc[(data_set['country'] == find_country) & (data_set['year'] == find_data)]
        for r in rows.gdp_for_year:
            if (math.isnan(r) == False):
                element = r
                break
        data_set.loc[i, 'gdp_for_year'] = element


#------------------------------------------------------------------------------
# Tolydinio tipo atributų sąryšių vizualizacijos
#------------------------------------------------------------------------------

# „Scatter plot“ tipo diagramos braižymas
def ScatterD(datax, datay):
    plt.ticklabel_format(style='plain')
    plt.scatter(data_set[datax].values, data_set[datay].values , alpha=0.5, color='purple')
    plt.title(datax + " / " + datay)
    plt.xlabel(datax)
    plt.ylabel(datay)
    plt.show()


#------------------------------------------------------------------------------
# Kategorinio tipo atributų sąryšių vizualizacijos
#------------------------------------------------------------------------------

# „Bar plot“ tipo diagramos grupavimo kiekių radimas
def BarPlotValues(unique, comparison, index, column):
    count = 0
    for element in data_set.values:
        if (element[index] == unique and element[column] == comparison):
            count = count + 1
    return count 

# „BarPlot“ tipo diagramos braižymas
def BarPlot(data1, data2, name1, name2):
    plt.subplot(211)
    plt.bar(data1, data2, color='purple')
    plt.title(name2)
    plt.xlabel(name1)
    plt.ylabel("Count")
    plt.xticks(rotation='vertical')
    plt.show()

#------------------------------------------------------------------------------
# Kovariacijos ir koreliacijos  (ryšiai tarp tolydinių atributų)
#------------------------------------------------------------------------------

# Kovariacijos reikšmių radimas
def Covariations(size, data1, data2, average1, average2):
    sum  = 0
    for i in range(0, size):
        difference = (data1[i] - average1) * (data2[i] - average2) 
        sum = sum + difference
    b = (1 / (size - 1))
    return b * sum

# Koreliacijos reikšmių radimas
def Correlation(cov, sd1, sd2):
    sd = sd1 * sd2
    return cov / sd


#------------------------------------------------------------------------------
# Duomenų normalizacija ( rėžiai [0;1] )
#------------------------------------------------------------------------------

# Tolydinio tipo atributų normalizacija
def Normalization(column, i, min, max):
    high = 1
    low  = 0
    z = (data_set[column].values[i] - min) / (max - min)
    norm = z * (high - low) + low
    data_set.loc[i, column] = norm


#------------------------------------------------------------------------------
# Kategorinio tipo kintamųjų vertimas į tolydinio tipo kintamuosius
#------------------------------------------------------------------------------

# Kategorinių atributų keitimas tolydinio tipo kintamuoju
def Conversion(element, number, column):
    for i in data_set.index:
        if (data_set[column].values[i] == element):
            data_set.loc[i, column] = number


#------------------------------------------------------------------------------
# Pagrindinis procesas
#------------------------------------------------------------------------------

# Nuskaitomas duomenų failas
data_set = pandas.read_csv(filepath_or_buffer = data_file, sep=";", header = "infer")

# Antraščių  išskyrimas (visų, kategorinių, tolydinių) atributams
n = data_set.shape[0]
headers = list(data_set.columns)
headers_str = ["country", "year", "gender", "age", "generation"]
headers_nr = ["suicides_no", "population", "HDI_for_year", "gdp_for_year", "gdp_per_capital"]


#------------------------------------------------------------------------------
# Pirminių duomenų kokybės analizė
#------------------------------------------------------------------------------

seperate = "---------------------------------"
print();print(seperate)
print("Pirminių duomenų kokybės analizė")
print(seperate)

print("\nEilučių kiekis, stulpelių kiekis:")
print(data_set.shape); print()

# Trūkstamų reikšmių procento radimas
missing_count = []
MissingValuesSTR(data_set.country, missing_count, n)
MissingValuesSTR(data_set.year, missing_count, n)
MissingValuesSTR(data_set.gender, missing_count, n)
MissingValuesSTR(data_set.age, missing_count, n)
MissingValues(data_set.suicides_no, missing_count, n)
MissingValues(data_set.population, missing_count, n)
MissingValues(data_set.HDI_for_year, missing_count, n)
MissingValues(data_set.gdp_for_year, missing_count, n)
MissingValues(data_set.gdp_per_capital, missing_count, n)
MissingValuesSTR(data_set.generation, missing_count, n)
PrintToTerminal("Trūkstamos reikšmės, %", headers, missing_count,1)

# Unikalių reikšmių kiekio radimas
unique_count = []
unique_count.append(len(data_set.country.dropna().unique()))
unique_count.append(len(data_set.year.dropna().unique()))
unique_count.append(len(data_set.gender.dropna().unique()))
unique_count.append(len(data_set.age.dropna().unique()))
unique_count.append(len(data_set.suicides_no.dropna().unique()))
unique_count.append(len(data_set.population.dropna().unique()))
unique_count.append(len(data_set.HDI_for_year.dropna().unique()))
unique_count.append(len(data_set.gdp_for_year.dropna().unique()))
unique_count.append(len(data_set.gdp_per_capital.dropna().unique()))
unique_count.append(len(data_set.generation.dropna().unique()))
PrintToTerminal("Kardinalumas", headers, unique_count,0)

# Tolydinių atributų maksimalių reikšmių radimas
max_element = []
max_element.append(data_set.suicides_no.max())
max_element.append(data_set.population.max())
max_element.append(data_set.HDI_for_year.max())
max_element.append(data_set.gdp_for_year.max())
max_element.append(data_set.gdp_per_capital.max())
PrintToTerminal("Maksimalios reikšmės", headers_nr, max_element,0)

# Tolydinių atributų minimalių reikšmių radimas
min_element = []
min_element.append(data_set.suicides_no.min())
min_element.append(data_set.population.min())
min_element.append(data_set.HDI_for_year.min())
min_element.append(data_set.gdp_for_year.min())
min_element.append(data_set.gdp_per_capital.min())
PrintToTerminal("Minimalios reikšmės", headers_nr, min_element,0)

# Tolydinių atributų pirmojo kvantilio reikšmių radimas
q1_25_element = []
q1_25_element.append(data_set.suicides_no.quantile(0.25))
q1_25_element.append(data_set.population.quantile(0.25))
q1_25_element.append(data_set.HDI_for_year.quantile(0.25))
q1_25_element.append(data_set.gdp_for_year.quantile(0.25))
q1_25_element.append(data_set.gdp_per_capital.quantile(0.25))
PrintToTerminal("1-asis kvartilis", headers_nr, q1_25_element,0)

# Tolydinių atributų trečiojo kvatilio reikšmių radimas
q3_75_element = []
q3_75_element.append(data_set.suicides_no.quantile(0.75))
q3_75_element.append(data_set.population.quantile(0.75))
q3_75_element.append(data_set.HDI_for_year.quantile(0.75))
q3_75_element.append(data_set.gdp_for_year.quantile(0.75))
q3_75_element.append(data_set.gdp_per_capital.quantile(0.75))
PrintToTerminal("3-asis kvartilis", headers_nr, q3_75_element,0)

# Tolydinių atributų vidurkio reikšmių radimas
average_element = []
average_element.append(data_set.suicides_no.mean())
average_element.append(data_set.population.mean())
average_element.append(data_set.HDI_for_year.mean())
average_element.append(data_set.gdp_for_year.mean())
average_element.append(data_set.gdp_per_capital.mean())
PrintToTerminal("Vidurkis", headers_nr, average_element, 1)

# Tolydinių atributų medianos reikšmių radimas
median_element = []
median_element.append(data_set.suicides_no.median())
median_element.append(data_set.population.median())
median_element.append(data_set.HDI_for_year.median())
median_element.append(data_set.gdp_for_year.median())
median_element.append(data_set.gdp_per_capital.median())
PrintToTerminal("Mediana", headers_nr, median_element, 0)

# Tolydinių atributų standartinio nuokrypio reikšmių radimas
sd_element = []
sd_element.append(data_set.suicides_no.std())
sd_element.append(data_set.population.std())
sd_element.append(data_set.HDI_for_year.std())
sd_element.append(data_set.gdp_for_year.std())
sd_element.append(data_set.gdp_per_capital.std())
PrintToTerminal("Standartinis nuokrypis", headers_nr, sd_element, 1)

# Kategorinių atributų modos reikšmių radimas
mode_element = []
mode_element.append(Counter(data_set.country).most_common()[0][0])
mode_element.append(Counter(data_set.year).most_common()[0][0])
mode_element.append(Counter(data_set.gender).most_common()[0][0])
mode_element.append(Counter(data_set.age).most_common()[0][0])
mode_element.append(Counter(data_set.generation).most_common()[0][0])
PrintToTerminal("Moda", headers_str, mode_element, 0)

# Kategorinių atributų modos dažnumo reikšmių radimas
mode_rate = []
mode_rate.append(ModeRate(data_set.country, mode_element[0]))
mode_rate.append(ModeRate(data_set.year, mode_element[1]))
mode_rate.append(ModeRate(data_set.gender, mode_element[2]))
mode_rate.append(ModeRate(data_set.age, mode_element[3]))
mode_rate.append(ModeRate(data_set.generation, mode_element[4]))
PrintToTerminal("Modos dažnumas", headers_str, mode_rate, 0)

# Kategorinių atributų modos dažnumo procento reikšmių radimas
mode_proc = []
mode_proc.append(ModeProc(len(data_set.country), mode_rate[0]))
mode_proc.append(ModeProc(len(data_set.year), mode_rate[1]))
mode_proc.append(ModeProc(len(data_set.gender), mode_rate[2]))
mode_proc.append(ModeProc(len(data_set.age), mode_rate[3]))
mode_proc.append(ModeProc(len(data_set.generation), mode_rate[4]))
PrintToTerminal("Moda, %", headers_str, mode_proc, 1)


# Kategorinių atributų antros modos reikšmių radimas
mode_2_element = []
mode_2_element.append(Counter(data_set.country).most_common()[1][0])
mode_2_element.append(Counter(data_set.year).most_common()[1][0])
mode_2_element.append(Counter(data_set.gender).most_common()[1][0])
mode_2_element.append(Counter(data_set.age).most_common()[1][0])
mode_2_element.append(Counter(data_set.generation).most_common()[1][0])
PrintToTerminal("Anroji moda", headers_str, mode_2_element, 0)

# Kategorinių atributų antros modos dažnumo reikšmių radimas
mode_2_rate = []
mode_2_rate.append(ModeRate(data_set.country, mode_2_element[0]))
mode_2_rate.append(ModeRate(data_set.year, mode_2_element[1]))
mode_2_rate.append(ModeRate(data_set.gender, mode_2_element[2]))
mode_2_rate.append(ModeRate(data_set.age, mode_2_element[3]))
mode_2_rate.append(ModeRate(data_set.generation, mode_2_element[4]))
PrintToTerminal("Antros modos dažnumas", headers_str, mode_2_rate, 0)

# Kategorinių atributų modos dažnumo procento reikšmių radimas
mode_2_proc = []
mode_2_proc.append(ModeProc(len(data_set.country), mode_2_rate[0]))
mode_2_proc.append(ModeProc(len(data_set.year), mode_2_rate[1]))
mode_2_proc.append(ModeProc(len(data_set.gender), mode_2_rate[2]))
mode_2_proc.append(ModeProc(len(data_set.age), mode_2_rate[3]))
mode_2_proc.append(ModeProc(len(data_set.generation), mode_2_rate[4]))
PrintToTerminal("Antra moda, %", headers_str, mode_2_proc, 1)


#------------------------------------------------------------------------------
# Duomenų histogramos
#------------------------------------------------------------------------------

# Kategorinių duomenų histogramos
HistogramSTR(data_set.country.values, headers_str[0], unique_count[0])
HistogramSTR(data_set.year.values.astype('str'), headers_str[1], unique_count[1])
HistogramSTR(data_set.gender.dropna().values, headers_str[2], unique_count[2])
HistogramSTR(data_set.age.values, headers_str[3], unique_count[3])
HistogramSTR(data_set.generation.values, headers_str[4], unique_count[9])

# Tolydinių duomenų histogramos
HistogramValues(data_set.suicides_no.values, headers_nr[0])
HistogramValues(data_set.population.dropna().values, headers_nr[1])
HistogramValues(data_set.HDI_for_year.dropna().values, headers_nr[2])
HistogramValues(data_set.gdp_for_year.values, headers_nr[3])
HistogramValues(data_set.gdp_per_capital.values, headers_nr[4])


#------------------------------------------------------------------------------
# Duomenų kokybė problemų analizė, sprendimas
#------------------------------------------------------------------------------

print();print(seperate)
print("Atributų ekstremalių reikšmių patikra:")
print(seperate)
# Atributų kritinių reikšmių analizė
OutlierAnalysis( q1_25_element[0], q3_75_element[0], headers_nr[0], data_set.suicides_no.values)
OutlierAnalysis( q1_25_element[1], q3_75_element[1], headers_nr[1], data_set.population.values)
OutlierAnalysis( q1_25_element[2], q3_75_element[2], headers_nr[2], data_set.HDI_for_year.dropna().values)
OutlierAnalysis( q1_25_element[3], q3_75_element[3], headers_nr[3], data_set.gdp_for_year.values)
OutlierAnalysis( q1_25_element[4], q3_75_element[4], headers_nr[4], data_set.gdp_per_capital.values)

# Trūkstamų reikšmių analizės problemų sprendimai
data_set.drop(['HDI_for_year'], inplace = True, axis=1)
headers_nr.remove("HDI_for_year")
headers = list(data_set.columns)

nan_value = float("NaN")
value = mode_element[2]
data_set.gender.replace(nan_value, value, inplace=True)

# Kritinių reikšmių pakeitimas
for i in data_set.index:  
    GdpForYearFix(i, average_element)
    OutlierFix(q1_25_element[0], q3_75_element[0], 'suicides_no', i)
    OutlierFix(q1_25_element[1], q3_75_element[1], 'population',i)


#------------------------------------------------------------------------------
# Koreguotų duomenų kokybės analizė
#------------------------------------------------------------------------------

print();print(seperate)
print("Koreguotų duomenų kokybės analizė")
print(seperate)

print("\nEilučių kiekis, stulpelių kiekis:")
print(data_set.shape); print()

#Trūkstamų reikšmių procento radimas
missing_count.clear()
MissingValuesSTR(data_set.country, missing_count, n)
MissingValuesSTR(data_set.year, missing_count, n)
MissingValuesSTR(data_set.gender, missing_count, n)
MissingValuesSTR(data_set.age, missing_count, n)
MissingValues(data_set.suicides_no, missing_count, n)
MissingValues(data_set.population, missing_count, n)
MissingValues(data_set.gdp_for_year, missing_count, n)
MissingValues(data_set.gdp_per_capital, missing_count, n)
MissingValuesSTR(data_set.generation, missing_count, n)
PrintToTerminal("Trūkstamos reikšmės, %", headers, missing_count,1)

# Unikalių reikšmių kiekio radimas
unique_count.clear()
unique_count.append(len(data_set.country.dropna().unique()))
unique_count.append(len(data_set.year.dropna().unique()))
unique_count.append(len(data_set.gender.dropna().unique()))
unique_count.append(len(data_set.age.dropna().unique()))
unique_count.append(len(data_set.suicides_no.dropna().unique()))
unique_count.append(len(data_set.population.dropna().unique()))
unique_count.append(len(data_set.gdp_for_year.dropna().unique()))
unique_count.append(len(data_set.gdp_per_capital.dropna().unique()))
unique_count.append(len(data_set.generation.dropna().unique()))
PrintToTerminal("Kardinalumas", headers, unique_count,0)

# Tolydinių atributų maksimalių reikšmių radimas
max_element.clear()
max_element.append(data_set.suicides_no.max())
max_element.append(data_set.population.max())
max_element.append(data_set.gdp_for_year.max())
max_element.append(data_set.gdp_per_capital.max())
PrintToTerminal("Maksimalios reikšmės", headers_nr, max_element,0)

# Tolydinių atributų minimalių reikšmių radimas
min_element.clear()
min_element.append(data_set.suicides_no.min())
min_element.append(data_set.population.min())
min_element.append(data_set.gdp_for_year.min())
min_element.append(data_set.gdp_per_capital.min())
PrintToTerminal("Minimalios reikšmės", headers_nr, min_element,0)

# Tolydinių atributų pirmojo kvantilio reikšmių radimas
q1_25_element.clear()
q1_25_element.append(data_set.suicides_no.quantile(0.25))
q1_25_element.append(data_set.population.quantile(0.25))
q1_25_element.append(data_set.gdp_for_year.quantile(0.25))
q1_25_element.append(data_set.gdp_per_capital.quantile(0.25))
PrintToTerminal("1-asis kvartilis", headers_nr, q1_25_element,0)

# Tolydinių atributų trečiojo kvatilio reikšmių radimas
q3_75_element.clear()
q3_75_element.append(data_set.suicides_no.quantile(0.75))
q3_75_element.append(data_set.population.quantile(0.75))
q3_75_element.append(data_set.gdp_for_year.quantile(0.75))
q3_75_element.append(data_set.gdp_per_capital.quantile(0.75))
PrintToTerminal("3-asis kvartilis", headers_nr, q3_75_element,0)

# Tolydinių atributų vidurkio reikšmių radimas
average_element.clear()
average_element.append(data_set.suicides_no.mean())
average_element.append(data_set.population.mean())
average_element.append(data_set.gdp_for_year.mean())
average_element.append(data_set.gdp_per_capital.mean())
PrintToTerminal("Vidurkis", headers_nr, average_element, 1)

# Tolydinių atributų medianos reikšmių radimas
median_element.clear()
median_element.append(data_set.suicides_no.median())
median_element.append(data_set.population.median())
median_element.append(data_set.gdp_for_year.median())
median_element.append(data_set.gdp_per_capital.median())
PrintToTerminal("Mediana", headers_nr, median_element, 0)

# Tolydinių atributų standartinio nuokrypio reikšmių radimas
sd_element.clear()
sd_element.append(data_set.suicides_no.std())
sd_element.append(data_set.population.std())
sd_element.append(data_set.gdp_for_year.std())
sd_element.append(data_set.gdp_per_capital.std())
PrintToTerminal("Standartinis nuokrypis", headers_nr, sd_element, 1)

# Kategorinių atributų modos reikšmių radimas
mode_element.clear()
mode_element.append(Counter(data_set.country).most_common()[0][0])
mode_element.append(Counter(data_set.year).most_common()[0][0])
mode_element.append(Counter(data_set.gender).most_common()[0][0])
mode_element.append(Counter(data_set.age).most_common()[0][0])
mode_element.append(Counter(data_set.generation).most_common()[0][0])
PrintToTerminal("Moda", headers_str, mode_element, 0)

# Kategorinių atributų modos dažnumo reikšmių radimas
mode_rate.clear()
mode_rate.append(ModeRate(data_set.country, mode_element[0]))
mode_rate.append(ModeRate(data_set.year, mode_element[1]))
mode_rate.append(ModeRate(data_set.gender, mode_element[2]))
mode_rate.append(ModeRate(data_set.age, mode_element[3]))
mode_rate.append(ModeRate(data_set.generation, mode_element[4]))
PrintToTerminal("Modos dažnumas", headers_str, mode_rate, 0)

# Kategorinių atributų modos dažnumo procento reikšmių radimas
mode_proc.clear()
mode_proc.append(ModeProc(len(data_set.country), mode_rate[0]))
mode_proc.append(ModeProc(len(data_set.year), mode_rate[1]))
mode_proc.append(ModeProc(len(data_set.gender), mode_rate[2]))
mode_proc.append(ModeProc(len(data_set.age), mode_rate[3]))
mode_proc.append(ModeProc(len(data_set.generation), mode_rate[4]))
PrintToTerminal("Moda, %", headers_str, mode_proc, 1)


# Kategorinių atributų antros modos reikšmių radimas
mode_2_element.clear()
mode_2_element.append(Counter(data_set.country).most_common()[1][0])
mode_2_element.append(Counter(data_set.year).most_common()[1][0])
mode_2_element.append(Counter(data_set.gender).most_common()[1][0])
mode_2_element.append(Counter(data_set.age).most_common()[1][0])
mode_2_element.append(Counter(data_set.generation).most_common()[1][0])
PrintToTerminal("Anroji moda", headers_str, mode_2_element, 0)

# Kategorinių atributų antros modos dažnumo reikšmių radimas
mode_2_rate.clear()
mode_2_rate.append(ModeRate(data_set.country, mode_2_element[0]))
mode_2_rate.append(ModeRate(data_set.year, mode_2_element[1]))
mode_2_rate.append(ModeRate(data_set.gender, mode_2_element[2]))
mode_2_rate.append(ModeRate(data_set.age, mode_2_element[3]))
mode_2_rate.append(ModeRate(data_set.generation, mode_2_element[4]))
PrintToTerminal("Antros modos dažnumas", headers_str, mode_2_rate, 0)

# Kategorinių atributų modos dažnumo procento reikšmių radimas
mode_2_proc.clear()
mode_2_proc.append(ModeProc(len(data_set.country), mode_2_rate[0]))
mode_2_proc.append(ModeProc(len(data_set.year), mode_2_rate[1]))
mode_2_proc.append(ModeProc(len(data_set.gender), mode_2_rate[2]))
mode_2_proc.append(ModeProc(len(data_set.age), mode_2_rate[3]))
mode_2_proc.append(ModeProc(len(data_set.generation), mode_2_rate[4]))
PrintToTerminal("Antra moda, %", headers_str, mode_2_proc, 1)


#------------------------------------------------------------------------------
# Tolydinio tipo atributų sąryšių vizualizacijos
#------------------------------------------------------------------------------

# Tolydinio tipo atributų „scatter plot“ tipo diagramos
ScatterD('suicides_no', 'population')
ScatterD('suicides_no', 'gdp_for_year')
ScatterD('suicides_no', 'gdp_per_capital')
ScatterD('population', 'gdp_for_year')
ScatterD('population', 'gdp_per_capital')
ScatterD('gdp_for_year', 'gdp_per_capital')

# SPLOM diagrama (Scatter Plot Matrix)
matrix_data = data_set.copy()
matrix_data.drop(['country'], inplace = True, axis=1)
matrix_data.drop(['year'], inplace = True, axis=1)
matrix_data.drop(['gender'], inplace = True, axis=1)
matrix_data.drop(['age'], inplace = True, axis=1)
matrix_data.drop(['generation'], inplace = True, axis=1)
fig = px.scatter_matrix(data_set)
fig.show()
fig = px.scatter_matrix(matrix_data)
fig.show()


#------------------------------------------------------------------------------
# Kategorinio tipo atributų sąryšių vizualizacijos
#------------------------------------------------------------------------------

# Atributų unikalių reikšmių radimai
unique_gender= data_set.gender.unique()
unique_age = data_set.age.unique()
unique_year = data_set.year.unique()
unique_country = data_set.country.unique()
unique_generation = data_set.generation.unique()

age_cout = []
age_male_count = []; age_female_count = []

# Amžius pagal lytį 
for element in unique_age:
    age_cout.append(ModeRate(data_set['age'], element))
    age_male_count.append(BarPlotValues(element, "male", 3, 2))
    age_female_count.append(BarPlotValues(element, "female", 3, 2))

BarPlot(unique_age, age_cout, "Age", " ")
BarPlot(unique_age, age_male_count, "Age", "Male")
BarPlot(unique_age, age_female_count, "Age", "Female")

country_cout = []
country_male_count = []; country_female_count  = []
age1_country = []; age2_country = []; age3_country = []; age4_country = []; age5_country = []; age6_country = []; 

# Šalis pagal lytį ir šalis pagal amžių
for element in unique_country:
    country_cout.append(ModeRate(data_set['country'], element))
    country_male_count.append(BarPlotValues(element, "male", 0,2))
    country_female_count.append(BarPlotValues(element, "female",0, 2))
    age1_country.append(BarPlotValues(element, "25-34 years", 0,3))
    age2_country.append(BarPlotValues(element, "15-24 years", 0,3))
    age3_country.append(BarPlotValues(element, "75+ years", 0,3))
    age4_country.append(BarPlotValues(element, "35-54 years", 0,3))
    age5_country.append(BarPlotValues(element, "55-74 years", 0,3))
    age6_country.append(BarPlotValues(element, "5-14 years", 0,3))

BarPlot(unique_country, country_cout, "Country", " ")
BarPlot(unique_country, country_male_count, "Country", "Male")
BarPlot(unique_country, country_female_count, "Country", "Female")
BarPlot(unique_country, age1_country, "Country", "25-34 years")
BarPlot(unique_country, age2_country, "Country", "15-24 years")
BarPlot(unique_country, age3_country, "Country", "75+ years")
BarPlot(unique_country, age4_country, "Country", "35-54 years")
BarPlot(unique_country, age5_country, "Country", "55-74 years")
BarPlot(unique_country, age6_country, "Country", "5-14 years")

year_cout = []
year_male_count = []; year_female_count = []
age1_year = []; age2_year = []; age3_year = []; age4_year = []; age5_year = []; age6_year = []; 

# Metai pagal lytį ir metai pagal amžių
for element in unique_year:
    year_cout.append(ModeRate(data_set['year'], element))
    year_male_count.append(BarPlotValues(element, "male", 1, 2))
    year_female_count.append(BarPlotValues(element, "female", 1, 2))
    age1_year.append(BarPlotValues(element, "25-34 years", 1,3))
    age2_year.append(BarPlotValues(element, "15-24 years", 1,3))
    age3_year.append(BarPlotValues(element, "75+ years", 1,3))
    age4_year.append(BarPlotValues(element, "35-54 years", 1,3))
    age5_year.append(BarPlotValues(element, "55-74 years", 1,3))
    age6_year.append(BarPlotValues(element, "5-14 years", 1,3))

BarPlot(unique_year, year_cout, "Year", " ")
BarPlot(unique_year, year_male_count, "Year", "Male")
BarPlot(unique_year, year_female_count, "Year", "Female")
BarPlot(unique_year, age1_year, "Year", "25-34 years")
BarPlot(unique_year, age2_year, "Year", "15-24 years")
BarPlot(unique_year, age3_year, "Year", "75+ years")
BarPlot(unique_year, age4_year, "Year", "35-54 years")
BarPlot(unique_year, age5_year, "Year", "55-74 years")
BarPlot(unique_year, age6_year, "Year", "5-14 years")


#------------------------------------------------------------------------------
# Tolydinio ir kategorinio tipo atributų sąryšių vizualizacijos
#------------------------------------------------------------------------------

plt.ticklabel_format(style='plain')
data_set.boxplot('suicides_no')
plt.show()
data_set.boxplot('suicides_no', 'gender')
plt.show()
data_set.boxplot('suicides_no', 'year')
plt.show()
data_set.boxplot('suicides_no', 'country')
plt.show()
data_set.boxplot('suicides_no', 'age')
plt.show()

data_set.boxplot('population')
plt.show()
data_set.boxplot('population', 'gender')
plt.show()
data_set.boxplot('population', 'year')
plt.show()
data_set.boxplot('population', 'country')
plt.show()
data_set.boxplot('population', 'age')
plt.show()

data_set.boxplot('gdp_for_year')
plt.show()
data_set.boxplot('gdp_for_year', 'gender')
plt.show()
data_set.boxplot('gdp_for_year', 'year')
plt.show()
data_set.boxplot('gdp_for_year', 'country')
plt.show()
data_set.boxplot('gdp_for_year', 'age')
plt.show()


#------------------------------------------------------------------------------
# Kovariacijos ir koreliacijos  (ryšiai tarp tolydinių atributų)
#------------------------------------------------------------------------------

print();print(seperate)
print("Kovariacijos")
print(seperate);print()

suicides_suicides = Covariations(n, data_set['suicides_no'], data_set['suicides_no'], average_element[0], average_element[0])
print("Suicides_no ir suicides_no : ","%.3f" % suicides_suicides )
suicides_population = Covariations(n, data_set['suicides_no'],data_set['population'],average_element[0], average_element[1])
print("Suicides_no ir population : ","%.3f" % suicides_population )
suicides_gdp_for_year = Covariations(n, data_set['suicides_no'],data_set['gdp_for_year'],average_element[0], average_element[2])
print("Suicides_no ir gdp_for_year : ","%.3f" % suicides_gdp_for_year )
suicides_gdp_per_capital = Covariations(n, data_set['suicides_no'],data_set['gdp_per_capital'],average_element[0], average_element[3])
print("Suicides_no ir gdp_per_capital : ","%.3f" % suicides_gdp_per_capital )

population_population = Covariations(n, data_set['population'],data_set['population'],average_element[1], average_element[1])
print("Population ir population : ","%.3f" % population_population )
population_gdp_for_year = Covariations(n, data_set['population'],data_set['gdp_for_year'],average_element[1], average_element[2])
print("Population ir gdp_for_year : ","%.3f" % population_gdp_for_year )
population_gdp_per_capital = Covariations(n, data_set['population'],data_set['gdp_per_capital'],average_element[1], average_element[3])
print("Population ir gdp_per_capital : ","%.3f" % population_gdp_per_capital )

gdp_for_year_gdp_for_year = Covariations(n, data_set['gdp_for_year'],data_set['gdp_for_year'],average_element[2], average_element[2])
print("Gdp_for_year ir gdp_for_year : ","%.3f" % gdp_for_year_gdp_for_year )
gdp_for_year_gdp_per_capital = Covariations(n, data_set['gdp_for_year'],data_set['gdp_per_capital'],average_element[2], average_element[3])
print("Gdp_for_year ir gdp_per_capital : ","%.3f" % gdp_for_year_gdp_per_capital )

gdp_per_capital_gdp_per_capital = Covariations(n, data_set['gdp_per_capital'],data_set['gdp_per_capital'],average_element[3], average_element[3])
print("Gdp_per_capital ir gdp_per_capital : ","%.3f" % gdp_per_capital_gdp_per_capital )
print()


print();print(seperate)
print("Koreliacija")
print(seperate);print()

print("Suicides_no ir suicides_no  : ","%.3f" % Correlation(suicides_suicides,sd_element[0],sd_element[0]) )
print("Suicides_no ir population   : ","%.3f" % Correlation(suicides_population,sd_element[0],sd_element[1]) )
print("Suicides_no ir gdp_for_year   : ","%.3f" % Correlation(suicides_gdp_for_year,sd_element[0],sd_element[2]) )
print("Suicides_no ir gdp_per_capital   : ","%.3f" % Correlation(suicides_gdp_per_capital,sd_element[0],sd_element[3]) )
print("Population ir population   : ","%.3f" % Correlation(population_population,sd_element[1],sd_element[1]) )
print("Population ir gdp_for_year  : ","%.3f" % Correlation(population_gdp_for_year,sd_element[1],sd_element[2]) )
print("Population ir gdp_per_capital   : ","%.3f" % Correlation(population_gdp_per_capital,sd_element[1],sd_element[3]) )
print("Gdp_for_year ir gdp_for_year  : ","%.3f" % Correlation(gdp_for_year_gdp_for_year,sd_element[2],sd_element[2]) )
print("Gdp_for_year ir gdp_per_capital  : ","%.3f" % Correlation(gdp_for_year_gdp_per_capital,sd_element[2],sd_element[3]) )
print("Gdp_per_capital ir gdp_per_capital  : ","%.3f" % Correlation(gdp_per_capital_gdp_per_capital,sd_element[3],sd_element[3]) )
print()

corrMatrix = matrix_data.corr()
sn.heatmap(corrMatrix, annot=True)
plt.yticks(rotation=0)
plt.xticks(rotation='horizontal')
plt.show()


#------------------------------------------------------------------------------
# Duomenų normalizacija ( rėžiai [0;1] )
#------------------------------------------------------------------------------
 
print();print(seperate)
print("Normalizacija")
print(seperate);print()
print(data_set)
for i in data_set.index:  
    Normalization('suicides_no', i, min_element[0], max_element[0])
    Normalization('population', i, min_element[1], max_element[1])
    Normalization('gdp_for_year', i, min_element[2], max_element[2])
    Normalization('gdp_per_capital', i, min_element[3], max_element[3])
print(data_set)


#------------------------------------------------------------------------------
# Kategorinio tipo kintamųjų vertimas į tolydinio tipo kintamuosius
#------------------------------------------------------------------------------

print();print(seperate)
print("Atributų pervertimas")
print(seperate);print()
print(data_set)

number = 0
for el in unique_country:
    number = number + 1
    Conversion(el, number, 'country')

number = 0
for el in unique_year:
    number = number + 1
    Conversion(el, number, 'year')

number = 0
for el in unique_gender:
    number = number + 1
    Conversion(el, number, 'gender')

number = 0
for el in unique_age:
    number = number + 1
    Conversion(el, number, 'age')

number = 0
for el in unique_generation:
    number = number + 1
    Conversion(el, number, 'generation')
