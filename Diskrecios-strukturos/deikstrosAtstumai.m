function [d] = deikstrosAtstumai(V,U,kelioPradzia,orgraf,Vkor);

% DEIKSTRA funkcija apskaiciuoja trumpiausius kelius grafe
%
%    Formalûs parametrai
% V    - grafo virsuniu aibe,
% U    - grafo briaunu aibe;
% s    - pradine kelio virsune,
% orgraf = 1 grafas orientuotasis, 
% Vkor - grafo virsuniu koordinates; parametras nebutinas;
%        Vkor nenurodytas arba Vkor =[], tai grafo virsunes
%        isdestomos apskritimu;
% d    - atstumai tarp virsuniu

% Paruosiamieji veiksmai

n = numel(V); m = numel(U); 
dz = zeros(1,n);  % virsuniu dazymo pozymiu masyvas
d = zeros(1,n);   % virsuniu atstumu masyvas
svoris = 1; 
for i = 1:m
    svoris = svoris + 1;
end
d = d + svoris;
d(kelioPradzia) = 0; 
t = true; 

% Gretimumo strukturos apskaiciavimas
GAM = UtoGAM(V,U,orgraf);

% Pagrindiniai skaiciavimai
% kol nera nudazytos viso virsunes
while (~all(dz)==1) && t
    % Randame virsune, iki kurios trumpiausias kelias nusistovejes
    kilgis = min(d(dz==0));
    indeksas = find((d==kilgis)&~dz);
    k = V(indeksas(1)); 
    dz(k) = 1;    % nudazome virsune "k"
    
    % Perskaiciuojame masyvu d elementus
    a = GAM{k};
    [~,nn] = size(a);
    for i = 1:nn
        u = a(1,i);
        if (dz(u)==0) && (d(u)>d(k) + 1)
            d(u) = d(k) + 1;
        end
    end  
end  

return