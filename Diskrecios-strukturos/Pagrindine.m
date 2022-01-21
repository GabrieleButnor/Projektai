clc; close all; clear all 

%-------------------------------------------------------------------------------
% vienakryptiskai jungus 
V = [1 2 3 4 5 6 7 8]; 
U = {[1 2],[2 3],[4 3],[3 5],[2 5],[5 4],[4 7],[1 6],[7 8],[5 6],[5 8], [1 8], [6 7]};
Ukom = [ 1 2; 2 3; 4 3; 3 5; 2 5; 5 4; 4 7; 1 6; 7 8; 5 6; 5 8; 1 8; 6 7 ];

% stipriai jungus 
%V = [1 2 3 4 5 6]; 
%U = {[1 2],[2 3],[3 4],[3 1],[2 5],[4 5],[5 6],[6 4],[6 1]};
%Ukom = [ 1 2; 2 3; 3 4; 3 1; 2 5; 4 5; 5 6; 6 4; 6 1 ];

% grafas nera jungus 
%V = [1 2 3 4 5 6 7 8]; 
%U = {[1 3],[3 4],[6 4],[6 3],[8 1],[8 6],[2 7],[7 5],[5 2]};
%Ukom = [ 1 3; 3 4; 6 4; 6 3; 8 1; 8 6; 2 7; 7 5; 5 2 ];

% silpnai jungus 
%V = [1 2 3 4 5]; 
%U = {[1 5],[2 5],[4 5],[4 3],[2 3],[2 1],[5 3]};
%Ukom = [ 1 5; 2 5; 4 5; 4 3; 2 3; 2 1; 5 3];

% vienakryptiskai jungus paprastas
%V = [1 2 3 4];
%U = {[1 2],[2 3],[3 4],[1 3],[1 4]}; 
%Ukom = [ 1 2; 2 3; 3 4; 1 3; 1 4 ];   % Briaunø matrica jungumui tikrinti 

% nejungus grafas
%V = [1 2 3 4];
%U = {[1 2],[4 2],[1 4]}; 
%Ukom = [ 1 2; 4 2; 1 4 ];   % Briaunø matrica jungumui tikrinti 

% stipriai jungus paprastas
%V = [1 2 3 4];
%U = {[1 2],[2 3],[3 4],[1 3],[4 1]}; 
%Ukom = [ 1 2; 2 3; 3 4; 1 3; 4 1 ];   % Briaunø matrica jungumui tikrinti 

% silpnai jungus paprastas
%V = [1 2 3 4];
%U = {[1 2],[2 3],[4 3],[1 3],[1 4]}; 
%Ukom = [ 1 2; 2 3; 4 3; 1 3; 1 4 ];   % Briaunø matrica jungumui tikrinti 

%-------------------------------------------------------------------------------

m = length(U);
n = length(V);
Vkor = []; 

disp('Darbo pradzia')
disp(' ');
% Pradiniai priskyrimai
orgraf = 1;   % grafas orentuotas 1

% Pradinio grafo brezimas
arc = 0; poz = 0; Fontsize = 16; lstor = 1; spalva = 'b';
figure(1)
title('Duotasis grafas')
Vkor = plotGraphVU(V,U,orgraf,arc,Vkor,poz,Fontsize,lstor,spalva);
hold on; pause(1)

% Grafo jungumo tikrinimas 
JungiujuKSk = 0;
JungiosiosKomp = zeros(1, n);
 
while any(JungiosiosKomp == 0)
    NeturinciosJungK = V(JungiosiosKomp == 0);
    PirmaBeJungK = NeturinciosJungK(1); 
    JungiujuKSk = JungiujuKSk + 1;
    JungiosiosKomp(PirmaBeJungK) = JungiujuKSk;
    
    ArTesti = true;
    while ArTesti
        JungiosiosKompBackup = JungiosiosKomp;
        for BriaunosNr = 1:m
            if (JungiosiosKomp(Ukom(BriaunosNr, 1)) == JungiujuKSk)
                JungiosiosKomp(Ukom(BriaunosNr, 2)) = JungiujuKSk;
            end
            if (JungiosiosKomp(Ukom(BriaunosNr, 2)) == JungiujuKSk)
                JungiosiosKomp(Ukom(BriaunosNr, 1)) = JungiujuKSk;
            end
        end
        ArTesti = any(JungiosiosKompBackup ~= JungiosiosKomp);
    end
end
 disp('Jungmo komponenèiø skaièius:' ); 
 disp(JungiujuKSk);  
 disp(' ');  
% atitinkamai pagal junguma atliekami veiksmai    
if (JungiujuKSk == 1)  
    d = []; 
    % atstumu nuo kiekvieno virsunes masyvo formavimas
    for kelioPradzia = 1:n
      [d{kelioPradzia}] = deikstrosAtstumai(V,U,kelioPradzia,orgraf,Vkor);   % visu virsuniu atstumu masyvas
    end
    % atstumu nuo kiekvieno virsunes masyvo isvedimas
    disp('Virðûniø atstumø matrica:');  
    disp(' ');  
    for prd = 1:n
          disp(d{prd});
    end

    netinka = m + 1;   % reiksme kuri rodo kad virsune nedasiekia kito virsunes
    busena = 'Grafas stipriai jungus'; 
    ar = false;
    
    % atstumu masyvo tikrinimas
    for i = 1:n
        eilute = d{i};
        [~,nn] = size(eilute);
        for j = 1:nn
            reiksme = eilute(1,j);
            if(reiksme == netinka)
               kita = d{j};
               [~,nnk] = size(kita);
               for k = 1:nnk
                 if (k == i)
                   kitareik = kita(1,k);  
                   if(kitareik ~= netinka)
                      busena = 'Grafas vienakryptiskai jungus';
                   end
                   if(kitareik == netinka)
                      busena = 'Grafas silpnai jungus'; 
                      ar = true;
                      break;
                   end
                 end
               end 
               if(ar == true)
                break;
               end               
            end           
        end 
        if(ar == true)
         break;
        end 
    end
    
    title(busena);
    disp(' ');
    disp(busena);
  
end

if (JungiujuKSk ~= 1)
     disp(' ');
    disp('Duotasis grafas nëra jungus');
    title('Duotasis grafas nëra jungus')
end   

disp(' ');
disp('Darbo pabaiga')