import inline as inline
import numpy as np
import matplotlib.pyplot as plt
from matplotlib.image import imread
import pandas as pd
import seaborn as sns
from sklearn.datasets._samples_generator import (make_blobs,
                                                make_circles,
                                                make_moons)
from sklearn.cluster import KMeans, SpectralClustering
from sklearn.preprocessing import StandardScaler
from sklearn.metrics import silhouette_samples, silhouette_score
from somlib import som
from sklearn import datasets
from sklearn.preprocessing import minmax_scale


sns.set_context('notebook')
plt.style.use('fivethirtyeight')
from warnings import filterwarnings

filterwarnings('ignore')
#df = pd.read_csv('C:\\Users\\Greta\\Desktop\\studijos\\III kursas\\II semestras\\Intelektikos pagrindai\\4\\4lab300.csv')

df = pd.read_csv('D:\\KTU\\6 semestras\\Intelektikos pagrindai\\komandinis\\4\\4lab300.csv')


dataSet = 1
# dataSet = 2
# dataSet = 3

if (dataSet == 1):
    plt.figure(figsize=(6, 6))
    plt.scatter(df.iloc[:, 1], df.iloc[:, 3])
    plt.xlabel('Taškai')
    plt.ylabel('Rezultatyvūs perdavimai')
    plt.title('Įmestų taškų ir rezultatyvių perdavimų diagrama (PTS x AST)')
    plt.show()
    new = np.column_stack((df.iloc[:, 1], df.iloc[:, 3]))
if (dataSet == 2):
    plt.figure(figsize=(6, 6))
    plt.scatter(df.iloc[:, 5], df.iloc[:, 2])
    plt.xlabel('Ūgis')
    plt.ylabel('Atkovoti kamuoliai')
    plt.title('Ūgio ir atkovotų kamuolių diagrama (UGIS x REB)')
    plt.show()
    new = np.column_stack((df.iloc[:, 5], df.iloc[:, 2]))
if (dataSet == 3):
    plt.figure(figsize=(6, 6))
    plt.scatter(df.iloc[:, 0], df.iloc[:, 4])
    plt.xlabel('Amžius')
    plt.ylabel('Sužaista rungtynių')
    plt.title('Amžiaus ir sužaistų ringtynių diagrama(AGE x GP)')
    plt.show()
    new = np.column_stack((df.iloc[:, 0], df.iloc[:, 4]))


clustSk = []
iner = []

X_std = StandardScaler().fit_transform(new)
SSE = []
for i, k in enumerate([2, 3, 4]):
    fig, (ax1, ax2) = plt.subplots(1, 2)
    fig.set_size_inches(18, 7)

    # K-virdukiu algoritmas
    km = KMeans(n_clusters=k)
    labels = km.fit_predict(X_std)
    centroids = km.cluster_centers_
    Silhouette_vals = silhouette_samples(X_std, labels)
    inertia = km.inertia_
    SSE.append(inertia)

    # Silhouette grafikas
    y_ticks = []
    y_lower, y_upper = 0, 0
    for i, cluster in enumerate(np.unique(labels)):
        cluster_Silhouette_vals = Silhouette_vals[labels == cluster]
        cluster_Silhouette_vals.sort()
        y_upper += len(cluster_Silhouette_vals)
        ax1.barh(range(y_lower, y_upper), cluster_Silhouette_vals, edgecolor='none', height=1)
        ax1.text(-0.03, (y_lower + y_upper) / 2, str(i + 1))
        y_lower += len(cluster_Silhouette_vals)

    # Get the average Silhouette score and plot it
    avg_score = np.mean(Silhouette_vals)
    avg_score_inertia = np.mean(inertia)

    ax1.axvline(avg_score, linestyle='--', linewidth=2, color='green')
    ax1.set_yticks([])
    ax1.set_xlim([-0.1, 1])
    if (cluster == 1):
        ax1.set_xlabel('Reikšmė')
        ax1.set_ylabel('Klasteris')
        ax1.set_title(f'Klasterių skaičius {k}', y=1.02)
    if (cluster == 2):
        ax1.set_xlabel('Reikšmė')
        ax1.set_ylabel('Klasteris')
        ax1.set_title(f'Klasterių skaičius  {k}', y=1.02)
    if (cluster == 3):
        ax1.set_xlabel('Reikšmė')
        ax1.set_ylabel('Klasteris')
        ax1.set_title(f'Klasterių skaičius  {k}', y=1.02)

    ax2.scatter(X_std[:, 0], X_std[:, 1], c=labels)
    ax2.scatter(centroids[:, 0], centroids[:, 1], marker='*', c='r', s=250)

    if (dataSet == 1):
        # ax2.set_xlim([-2, 3])
        # ax2.set_ylim([-1.5, 5])
        ax2.set_xlabel('Taškai')
        ax2.set_ylabel('Rezultatyvūs perdavimai')
        ax2.set_title('Įmesti taškai ir rezultatyviūs perdavimai (PTS x AST)', y=1.02)
    if (dataSet == 2):
        # ax2.set_xlim([-3, 4])
        # ax2.set_ylim([-2, 5])
        ax2.set_xlabel('Ūgis')
        ax2.set_ylabel('Atkovoti kamuoliai')
        ax2.set_title('Ūgis ir atkovoti kamuoliai  (UGIS x REB)', y=1.02)
    if (dataSet == 3):
        # ax2.set_xlim([-2, 3])
        # ax2.set_ylim([-3, 1.5])
        ax2.set_xlabel('Amžius')
        ax2.set_ylabel('Sužaista rungtynių')
        ax2.set_title('Amžius ir sužaistos ringtynės (AGE x GP)', y=1.02)


    clustSk.append(k)
    iner.append(avg_score_inertia)


    ax2.set_aspect('equal')
    plt.tight_layout()
    print(f'\nKlasteriu skaicius {k}')
    print(f'Silhouette reiksme {avg_score}')
    print(f'Inercijos koeficientas {avg_score_inertia}\n')
    plt.show()


plt.plot(clustSk, iner, color='purple', marker='o',linewidth=2)
plt.xticks(np.arange(1,6,1))
plt.title("Inercijos ir klasterių priklausomybės kreivė")
plt.xlabel("Klaterių skaičius")
plt.ylabel("Inercija")
plt.show()

