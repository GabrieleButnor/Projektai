
# Intelektikos pagrindai 2021
# Gabrielė Butnoriūtė IFF-8/7
# Antrasis laboratorinis darbas: "Fuzzy – Miglotosios logikos"

import numpy as np
import matplotlib.pyplot as plt
import skfuzzy as fuzz

# Duomenų grafikinis atvaizdavimas
def dataPlot(x1, x2, x3, range, first, second, third, name, xlabel):
    plt.plot(range,x1, color='purple', linewidth=2, label=first)
    plt.plot(range,x2, color='red', linewidth=2, label=second)
    plt.plot(range,x3, color='green', linewidth=2, label=third)
    plt.title(name)
    plt.xlabel(xlabel)
    plt.legend(loc='center right', frameon=True)
    plt.show()
   
# Tikrumo įverčių apskaičiavimas trapecijos formulėmis
def estimation(x, a, b, c, d):
    if(x < a): return 0
    elif(a <= x < b): return (x - a) / (b - a)
    elif(b <= x < c): return 1
    elif(c <= x < d): return (d - x) / (d - c)
    else: return 0

# ---------------------------------
# main
# ---------------------------------

# Sugeneruojamos įvesčių ir išvesties intervalų reikšmės
age_range = np.arange(0, 81, 1)
populacion_range = np.arange(0, 61, 1) # milijonai
gdp_range = np.arange(0, 91, 1) # mijardais
suicides_range = np.arange(0, 2701, 1)

# Fuzzy aibių išskyrimas trapecine kreive 
age_young = fuzz.trapmf(age_range, [0, 0, 15, 30])
age_mature = fuzz.trapmf(age_range, [18, 30, 50, 60])
age_older = fuzz.trapmf(age_range, [50, 65, 80, 80])

populacion_small = fuzz.trapmf(populacion_range, [0, 0, 5, 15])
populacion_mid = fuzz.trapmf(populacion_range, [8, 20, 30, 40])
populacion_large = fuzz.trapmf(populacion_range, [30, 45, 60, 60])

gdb_small = fuzz.trapmf(gdp_range, [0, 0, 15, 30])
gdb_mid = fuzz.trapmf(gdp_range, [22, 30, 50, 65])
gdb_large = fuzz.trapmf(gdp_range, [45, 70, 90, 90])

suicides_small = fuzz.trapmf(suicides_range, [0, 0, 300, 500])
suicides_mid = fuzz.trapmf(suicides_range, [300, 800, 1400, 1700])
suicides_large = fuzz.trapmf(suicides_range, [1200, 2000, 2700, 2700])



# # Duomenų trapecinių kreivių atvaizdavimas
# name = "Žmogau amžius"
# dataPlot(age_young,age_mature,age_older, age_range,'Jaunas', 'Subrendes', 'Senyvas', name, "amžius")
# name = "Populiacijos dydis"
# dataPlot(populacion_small,populacion_mid,populacion_large, populacion_range,'Maža', 'Vidutinė', 'Didelė', name, "milijonai")
# name = "Bendras vidaus produktas"
# dataPlot(gdb_small,gdb_mid,gdb_large, gdp_range,'Mažas', 'Vidutinis', 'Didelis', name, "milijardai")
# name = "Savižudybių skaičius"
# dataPlot(suicides_small,suicides_mid,suicides_large, suicides_range,'Mažas', 'Vidutinis', 'Didelis', name, "savižudybės")

# ---------------------------------

# Pirmas testavimas
# age = 25
# population = 35
# gdb = 23

# age = 60
# population = 2
# gdb = 80

age = 40
population = 50
gdb = 23

# ---------------------------------
# Tikrumo įverčių apskaičiavimas
# ---------------------------------

age_young_estimate = estimation(age, 0, 0, 15, 30)
age_mature_estimate = estimation(age, 18, 30, 50, 60)
age_older_estimate = estimation(age, 50, 65, 80, 80)

populatio_small_estimate = estimation(population, 0, 0, 5, 15)
populatio_mid_estimate = estimation(population, 8, 20, 30, 40)
populatio_high_estimate = estimation(population, 30, 45, 60, 60)

gdb_small_estimate = estimation(gdb, 0, 0, 15, 30)
gdb_mid_estimate = estimation(gdb, 22, 30, 50, 65)
gdb_high_estimate = estimation(gdb, 45, 70, 90, 90)


# ---------------------------------
# Implikacija
# ---------------------------------

# Taisyklių sudarymas - mažas savižudybių tikimybė
rule1 = min(age_young_estimate, populatio_small_estimate)
rule7 = min(age_older_estimate, populatio_small_estimate)
rule8 = min(age_older_estimate, populatio_mid_estimate)
rule12 = min(age_young_estimate, gdb_high_estimate)
rule17 = min(age_older_estimate, gdb_mid_estimate)
rule18 = min(age_older_estimate, gdb_high_estimate)
rule20 = min(populatio_small_estimate, gdb_mid_estimate)
rule21 =  min(populatio_small_estimate, gdb_high_estimate)

rule30 = min( min(age_young_estimate, populatio_small_estimate), gdb_high_estimate)
rule39 = min( min(age_mature_estimate, populatio_small_estimate), gdb_high_estimate)
rule46 = min( min(age_older_estimate, populatio_small_estimate), gdb_small_estimate)
rule47 = min( min(age_older_estimate, populatio_small_estimate), gdb_mid_estimate)
rule48 = min( min(age_older_estimate, populatio_small_estimate), gdb_high_estimate)
rule51 = min( min(age_older_estimate, populatio_mid_estimate), gdb_high_estimate)
rule54 = min( min(age_older_estimate, populatio_high_estimate), gdb_high_estimate)

rule57 = max( max(age_older_estimate, populatio_small_estimate), gdb_high_estimate)


small_probabiluty = max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(rule1, rule7), rule8), rule12), rule17), rule18), rule20), rule21), rule30), rule39), rule46), rule47), rule48), rule51), rule54), rule57)
print("Mažo savižudybių skaičiaus tikmybė:")
print(small_probabiluty)

# Taisyklių sudarymas - vidutinė savižudybių tikimybė
rule2 = min(age_young_estimate, populatio_mid_estimate)
rule3 = min(age_young_estimate, populatio_high_estimate)
rule4 = min(age_mature_estimate, populatio_small_estimate)
rule9 = min(age_older_estimate, populatio_high_estimate)
rule10 = min(age_young_estimate, gdb_small_estimate)
rule11 = min(age_young_estimate, gdb_mid_estimate)
rule15 = min(age_mature_estimate, gdb_high_estimate)
rule16 = min(age_older_estimate, gdb_small_estimate)
rule19 = min(populatio_small_estimate, gdb_small_estimate)
rule23 = min(populatio_mid_estimate, gdb_mid_estimate)
rule24 = min(populatio_mid_estimate, gdb_high_estimate)
rule27 = min(populatio_high_estimate, gdb_high_estimate)

rule28 = min( min(age_young_estimate,populatio_small_estimate), gdb_small_estimate)
rule29 = min( min(age_young_estimate,populatio_small_estimate), gdb_mid_estimate)
rule31 = min( min(age_young_estimate, populatio_mid_estimate), gdb_small_estimate)
rule32 = min( min(age_young_estimate, populatio_mid_estimate), gdb_mid_estimate)
rule33 = min( min(age_young_estimate, populatio_mid_estimate), gdb_high_estimate)
rule35 = min( min(age_young_estimate,populatio_high_estimate), gdb_mid_estimate)
rule36 = min( min(age_young_estimate,populatio_high_estimate), gdb_high_estimate)
rule38 = min( min(age_mature_estimate, populatio_small_estimate), gdb_mid_estimate)
rule42 = min( min(age_mature_estimate, populatio_mid_estimate), gdb_high_estimate)
rule45 = min( min(age_mature_estimate,populatio_high_estimate), gdb_high_estimate)
rule49 = min( min(age_older_estimate, populatio_mid_estimate), gdb_small_estimate)
rule50 = min( min(age_older_estimate, populatio_mid_estimate), gdb_mid_estimate)
rule53 = min( min(age_older_estimate, populatio_high_estimate), gdb_mid_estimate)

rule55 = max( max(age_young_estimate, populatio_mid_estimate), gdb_mid_estimate)


mid_probabiluty = max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(max(rule2, rule3), rule4), rule9), rule10), rule11), rule15), rule16), rule30), rule19), rule23), rule24), rule27), rule28), rule29), rule31), rule32), rule33), rule35), rule36), rule38), rule42), rule45), rule49), rule50), rule53), rule55)
print("Vidutinė savižudybių skaičiaus tikmybė:")
print(mid_probabiluty)


# Taisyklių sudarymas - didel4 savižudybių tikimybė
rule5 = min(age_mature_estimate, populatio_mid_estimate)
rule6 = min(age_mature_estimate, populatio_high_estimate)
rule13 = min(age_mature_estimate, gdb_small_estimate)
rule14 = min(age_mature_estimate, gdb_mid_estimate)
rule22 = min(populatio_mid_estimate, gdb_small_estimate)
rule25 = min(populatio_high_estimate, gdb_small_estimate)
rule26 = min(populatio_high_estimate, gdb_mid_estimate)

rule34 = min( min(age_young_estimate, populatio_high_estimate), gdb_small_estimate)
rule37 = min( min(age_mature_estimate, populatio_small_estimate), gdb_small_estimate)
rule40 = min( min(age_mature_estimate, populatio_mid_estimate), gdb_small_estimate)
rule41 = min( min(age_mature_estimate, populatio_mid_estimate), gdb_mid_estimate)
rule43 = min( min(age_mature_estimate, populatio_high_estimate), gdb_small_estimate)
rule44 = min( min(age_mature_estimate, populatio_high_estimate), gdb_mid_estimate)
rule52 = min( min(age_older_estimate, populatio_high_estimate), gdb_small_estimate)

rule56 = max( max(age_mature_estimate, populatio_high_estimate), gdb_small_estimate)


high_probabiluty = max(max(max(max(max(max(max(max(max(max(max(max(max(max(rule5, rule6), rule13), rule14), rule22), rule25), rule26), rule34), rule37), rule40), rule41), rule43), rule44), rule52), rule56)
print("Didelė savižudybių skaičiaus tikmybė:")
print(high_probabiluty)

# ---------------------------------
# Agregacija
# ---------------------------------

# Apjungiame visas aktyvuotas taisykles
suicides_activation_small = np.fmin(small_probabiluty, suicides_small)
suicides_activation_mid = np.fmin(mid_probabiluty, suicides_mid)
suicides_activation_high = np.fmin(high_probabiluty, suicides_large)

aggregated = np.fmax(suicides_activation_small, np.fmax(suicides_activation_mid, suicides_activation_high))


# Gautų išėjimo reikšmių atvaizdavimas.
win = np.zeros_like(suicides_range)
plt.fill_between(suicides_range, win, suicides_activation_small, facecolor='purple', alpha=0.4) 
plt.plot(suicides_range, suicides_small, 'purple', linewidth=1)
plt.fill_between(suicides_range, win, suicides_activation_mid, facecolor='red', alpha=0.4) 
plt.plot(suicides_range, suicides_mid, 'red', linewidth=1)
plt.fill_between(suicides_range, win, suicides_activation_high, facecolor='green', alpha=0.4) 
plt.plot(suicides_range, suicides_large, 'green', linewidth=1)
plt.title("Gautų išėjimo reikšmių atvaizdavimas")
plt.show()

# ---------------------------------
# Defuzifikacija
# ---------------------------------

# Svorio centro - centroid
suicides_centroid = fuzz.defuzz(suicides_range, aggregated, 'centroid') 
# maksimumo vidurkio - MOM
suicides_mom = fuzz.defuzz(suicides_range, aggregated, 'mom') 

print()
print("Įvestys: amžius - " + str(age)+ ", populiacija - " + str(population) + ", BVP - " + str(gdb))
print()
print("Prognozuojamas savižudybių skaičius:")
print("  Rezultatai svorio centro metodu:")
print( "   " + str(np.round(suicides_centroid,3)))
print("  Rezultatai maksimalaus vidurkio metodu:")
print( "   " + str(np.round(suicides_mom,3)))
print()
