#pragma once
#include <fstream>
#include <iostream>
#include <sstream>
#include "KuroTipai.h"
#include "Automobiliai.h"
#include "Salys.h"
#include "Keliones.h"
#include "Ataskaita.h"

namespace Darbas {
	using namespace std;
	using namespace System;
	using namespace System::Collections;
	using namespace System::Collections::Generic;
	using namespace System::IO;
	using namespace System::Text;
	using namespace System::Globalization;

	public ref class Duomenys
	{
	private:
		Salys^ _salys;
		KuroTipai^ _kuroTipai;
		Automobiliai^ _automobiliai;
		Keliones^ _keliones;
		Ataskaita^ _ataskaita;

	public:

		Duomenys()
		{


			this->_salys = gcnew Salys();
			this->_kuroTipai = gcnew KuroTipai();
			this->_automobiliai = gcnew Automobiliai(this->_kuroTipai);
			this->_keliones = gcnew Keliones(this->_automobiliai, this->_salys);
			this->_ataskaita = gcnew Ataskaita(this->_automobiliai, this->_keliones);

		}


		~Duomenys()
		{
			delete this->_salys;
			delete this->_kuroTipai;
			delete this->_automobiliai;
			delete this->_keliones;
			delete this->_ataskaita;
		}


		Salys^ VisosSalys() {
			return this->_salys;
		}

		KuroTipai^ VisiKuroTipai() {
			return this->_kuroTipai;
		}

		Automobiliai^ VisiAutomobiliai() {
			return this->_automobiliai;
		}

		Keliones^ VisosKeliones() {
			return this->_keliones;
		}

		Ataskaita^ VisaAtaskaita() {
			return this->_ataskaita;
		}

		KuroTipai^ Nuskaityti_KuroTipus(String^% arg_pranesimas) {
			ifstream fin;
			fin.open("Kuras.txt");
			if (!fin) {
				arg_pranesimas = "Nepavyko atidaryti bylos Kuras.txt";
				return nullptr;
			}
			else
			{
				if (this->_kuroTipai == nullptr) {
					this->_kuroTipai = gcnew KuroTipai();
				}
				string laikinas_pavad;
				while (fin >> laikinas_pavad) {
					this->_kuroTipai->Sukurti(gcnew String(laikinas_pavad.c_str()));
				}
				fin.close();
				return this->_kuroTipai;
			}
		}

		Salys^ Nuskaityti_Salis(String^% arg_pranesimas) {
			ifstream fin;
			fin.open("Salys.txt");
			if (!fin) {
				arg_pranesimas = "Nepavyko atidaryti bylos Salys.txt";
				return nullptr;
			}
			else
			{
				if (this->_salys == nullptr) {
					this->_salys = gcnew Salys();
				}
				string laikinas_Kodas;
				string laikinas_Pavad;
				string eilute;
				while (getline(fin, eilute))
				{
					istringstream lin(eilute);
					getline(lin, laikinas_Kodas, '\t');
					getline(lin, laikinas_Pavad, '\n');
					this->_salys->Sukurti(gcnew String(laikinas_Kodas.c_str()), gcnew String(laikinas_Pavad.c_str()));
				}

				/*
				nestandartinis formatas
				while (fin >> laikinas_Kodas >> laikinas_Pavad) {
				this->_salys->Sukurti(laikinas_Kodas, laikinas_Pavad);
				}*/
				fin.close();
				return this->_salys;
			}
		}

		Automobiliai^ Nuskaityti_Automobilius(String^ arg_pranesimas) {

			string byla = "Auto.txt";
			ifstream fin_tikrinti(byla);
			if (!fin_tikrinti.good()) {
				ofstream fout;
				fout.open(byla);
				fout.close();
			}
			fin_tikrinti.close();

			ifstream fin;
			fin.open(byla);
			if (!fin) {
				arg_pranesimas = "Nepavyko atidaryti bylos " + gcnew String(byla.c_str());
				return nullptr;
			}
			else
			{
				if (this->_kuroTipai == nullptr || (this->_kuroTipai != nullptr && this->_kuroTipai->ElementuKiekis() == 0)) {
					if (Nuskaityti_KuroTipus(arg_pranesimas) == nullptr) {
						return nullptr;
					}
				}
				if (this->_automobiliai == nullptr ) {
					this->_automobiliai = gcnew Automobiliai(this->_kuroTipai);
				}
				CultureInfo^ culture = CultureInfo::CurrentCulture;
				string laikinas_valNr;
				string laikinas_marke;
				string laikinas_kuroRusies_pavad;
				string laikinas_sanaudu_norma_V_str;
				double laikinas_sanaudu_norma_V;
				string laikinas_sanaudu_norma_Z_str;
				double laikinas_sanaudu_norma_Z;
				string laikinas_tarsosKoef_str;
				double laikinas_tarsosKoef;

				string eilute;
				String^ reiksme = "";
				while (getline(fin, eilute))
				{
					istringstream lin(eilute);
					getline(lin, laikinas_valNr, '\t');
					getline(lin, laikinas_marke, '\t');
					getline(lin, laikinas_kuroRusies_pavad, '\t');

					getline(lin, laikinas_sanaudu_norma_V_str, '\t');

					
					reiksme = gcnew String(laikinas_sanaudu_norma_V_str.c_str());
					reiksme->Replace(".", culture->NumberFormat->NumberDecimalSeparator);
					if (!double::TryParse(reiksme, laikinas_sanaudu_norma_V))
					{
						laikinas_sanaudu_norma_V = 0;
					}
			 
					getline(lin, laikinas_sanaudu_norma_Z_str, '\t');

					reiksme = gcnew String(laikinas_sanaudu_norma_Z_str.c_str());
					reiksme->Replace(".", culture->NumberFormat->NumberDecimalSeparator);

					if (!double::TryParse(reiksme, laikinas_sanaudu_norma_Z))
					{
						laikinas_sanaudu_norma_Z = 0;
					}

			
					getline(lin, laikinas_tarsosKoef_str, '\n');

					reiksme = gcnew String(laikinas_tarsosKoef_str.c_str());
					reiksme->Replace(".", culture->NumberFormat->NumberDecimalSeparator);

					if (!double::TryParse(reiksme, laikinas_tarsosKoef))
					{
						laikinas_tarsosKoef = 0;
					}
				
					this->_automobiliai->Sukurti(gcnew String(laikinas_valNr.c_str()), gcnew String(laikinas_marke.c_str()), gcnew String(laikinas_kuroRusies_pavad.c_str()), laikinas_sanaudu_norma_Z, laikinas_sanaudu_norma_V, laikinas_tarsosKoef);
				}


				/*while (fin >> laikinas_valNr >> laikinas_marke >> laikinas_kuroRusies_pavad >> laikinas_sanaudu_norma_V >> laikinas_sanaudu_norma_Z >> laikinas_tarsosKoef) {
				this->_automobiliai->Sukurti(laikinas_valNr, laikinas_marke, laikinas_kuroRusies_pavad, laikinas_sanaudu_norma_Z, laikinas_sanaudu_norma_V, laikinas_tarsosKoef);
				}*/

				fin.close();
				return this->_automobiliai;
			}
		}

		Keliones^ Nuskaityti_Keliones(String^% arg_pranesimas) {

			string byla = "Duomenys.txt";
			ifstream fin_tikrinti(byla);
			if (!fin_tikrinti.good()) {
				ofstream fout;
				fout.open(byla);
				fout.close();
			}
			fin_tikrinti.close();

			ifstream fin;
			fin.open(byla);
			if (!fin) {
				arg_pranesimas = "Nepavyko atidaryti bylos " + gcnew String(byla.c_str());
				return nullptr;
			}
			else
			{
				if (this->_salys == nullptr || (this->_salys != nullptr && this->_salys->ElementuKiekis() == 0)) {
					if (Nuskaityti_Salis(arg_pranesimas) == nullptr) {
						return nullptr;
					}
				}
				if (this->_automobiliai == nullptr || (this->_automobiliai != nullptr && this->_automobiliai->ElementuKiekis() == 0)) {
					if (Nuskaityti_Automobilius(arg_pranesimas) == nullptr) {
						return nullptr;
					}
				}
				if (this->_keliones == nullptr) {
					this->_keliones = gcnew Keliones(this->_automobiliai, this->_salys);
				}
				CultureInfo^ culture = CultureInfo::CurrentCulture;

				string laikinas_valNr;
				string laikinas_data;
				string laikinas_salies_kodas_is;
				string laikinas_miestas_is;
				string laikinas_salies_kodas_i;
				string laikinas_miestas_i;
				string laikinas_atstumas_str;
				double laikinas_atstumas;
				string laikinas_kuro_sanaudos_str;
				double laikinas_kuro_sanaudos;

				string eilute; String^ reiksme = "";
				while (getline(fin, eilute))
				{
					istringstream lin(eilute);
					getline(lin, laikinas_valNr, '\t');
					getline(lin, laikinas_data, '\t');
					getline(lin, laikinas_salies_kodas_is, '\t');
					getline(lin, laikinas_miestas_is, '\t');
					getline(lin, laikinas_salies_kodas_i, '\t');
					getline(lin, laikinas_miestas_i, '\t');


					getline(lin, laikinas_atstumas_str, '\t');

					reiksme = gcnew String(laikinas_atstumas_str.c_str());
					reiksme->Replace(".", culture->NumberFormat->NumberDecimalSeparator);

					if (!double::TryParse(reiksme, laikinas_atstumas))
					{
						laikinas_atstumas = 0;
					}



					getline(lin, laikinas_kuro_sanaudos_str, '\n');

					reiksme = gcnew String(laikinas_kuro_sanaudos_str.c_str());
					reiksme->Replace(".", culture->NumberFormat->NumberDecimalSeparator);

					if (!double::TryParse(reiksme, laikinas_kuro_sanaudos))
					{
						laikinas_kuro_sanaudos = 0;
					}

					this->_keliones->Sukurti(gcnew String(laikinas_valNr.c_str()), gcnew String(laikinas_data.c_str()), gcnew String(laikinas_salies_kodas_is.c_str()), gcnew String(laikinas_miestas_is.c_str()), gcnew String(laikinas_salies_kodas_i.c_str()), gcnew String(laikinas_miestas_i.c_str()), laikinas_atstumas, laikinas_kuro_sanaudos);
				}
				/*
				while (fin >> laikinas_valNr >> laikinas_data >> laikinas_salies_kodas_is >> laikinas_miestas_is >> laikinas_salies_kodas_i >> laikinas_miestas_i >> laikinas_atstumas >> _kuro_sanaudos) {
				this->_keliones->Sukurti(laikinas_valNr, laikinas_data, laikinas_salies_kodas_is, laikinas_miestas_is, laikinas_salies_kodas_i, laikinas_miestas_i, laikinas_atstumas, _kuro_sanaudos);
				}*/

				fin.close();
				return this->_keliones;
			}

		}

		Ataskaita^ Nuskaityti_Ataskaita(String^% arg_pranesimas) {

			string byla = "Ataskaita.txt";
			ifstream fin_tikrinti(byla);
			if (!fin_tikrinti.good()) {
				ofstream fout;
				fout.open(byla);
				fout.close();
			}
			fin_tikrinti.close();


			ifstream fin;
			fin.open(byla);
			if (!fin) {
				arg_pranesimas = "Nepavyko atidaryti bylos " + gcnew String(byla.c_str());
				return nullptr;
			}
			else
			{
				if (this->_kuroTipai == nullptr || (this->_kuroTipai != nullptr && this->_kuroTipai->ElementuKiekis() == 0)) {
					if (Nuskaityti_KuroTipus(arg_pranesimas) == nullptr) {
						return nullptr;
					}
				}

				if (this->_automobiliai == nullptr || (this->_automobiliai != nullptr && this->_automobiliai->ElementuKiekis() == 0)) {
					if (Nuskaityti_Automobilius(arg_pranesimas) == nullptr) {
						return nullptr;
					}

				}


				if (this->_ataskaita == nullptr) {
					this->_ataskaita = gcnew Ataskaita(this->_automobiliai, this->_keliones);
				}
				CultureInfo^ culture = CultureInfo::CurrentCulture;

				string laikinas_valNr;
				string laikinas_kuroRusis;
				string laikinas_visosSanaudos_str;
				double laikinas_visosSanaudos;
				string laikinas_tarsos_koef_str;
				double laikinas_tarsos_koef;

				string eilute; String^ reiksme = "";
				while (getline(fin, eilute))
				{
					istringstream lin(eilute);
					getline(lin, laikinas_valNr, '\t');
					getline(lin, laikinas_kuroRusis, '\t');

					getline(lin, laikinas_visosSanaudos_str, '\t');

					reiksme = gcnew String(laikinas_visosSanaudos_str.c_str());
					reiksme->Replace(".", culture->NumberFormat->NumberDecimalSeparator);

					if (!double::TryParse(reiksme, laikinas_visosSanaudos))
					{
						laikinas_visosSanaudos = 0;
					}


					getline(lin, laikinas_tarsos_koef_str, '\n');

					reiksme = gcnew String(laikinas_tarsos_koef_str.c_str());
					reiksme->Replace(".", culture->NumberFormat->NumberDecimalSeparator);

					if (!double::TryParse(reiksme, laikinas_tarsos_koef))
					{
						laikinas_tarsos_koef = 0;
					}

					this->_ataskaita->Sukurti(gcnew String(laikinas_valNr.c_str()), laikinas_visosSanaudos);
				}

				/*
				while (fin >> laikinas_valNr >> laikinas_kuroRusis >> laikinas_visosSanaudos >> laikinas_tarsos_koef) {
				this->_ataskaita->Sukurti(laikinas_valNr, laikinas_visosSanaudos);
				}
				*/

				fin.close();
				return this->_ataskaita;
			}

		}

		bool Issaugok_KuroTipus(String^% arg_pranesimas) {
			string byla = "Kuras.txt";
			ofstream fout;
			fout.open(byla);
			if (!fout) {
				arg_pranesimas = "Nepavyko atidaryti bylos "  + gcnew String( byla.c_str());
				return false;
			}
			else if (this->_kuroTipai == nullptr) {
				arg_pranesimas = "Kuro tipai nesukurti";
				return false;
			}
			else
			{
				fout.close();

				

				FileStream^ fs = File::Create(gcnew String(byla.c_str()));
				StreamWriter^ sw = gcnew StreamWriter(fs, System::Text::Encoding::ASCII);
				try
				{
					for (int laikinas_indeksas = 0; laikinas_indeksas < this->_kuroTipai->ElementuKiekis(); laikinas_indeksas++) {
						KuroTipas^ kuroTipas = this->_kuroTipai->Rasti_PagalIndeksa(laikinas_indeksas);
						if (kuroTipas != nullptr) {
							sw->WriteLine(kuroTipas->Pavad);
						}
					}
				}
				finally
				{
					if (sw)
						delete (IDisposable^)sw;
					if (fs)
						delete (IDisposable^)fs;
				}
				
				return true;
			}
		}

		bool Issaugok_Salis(String^% arg_pranesimas) {
			string byla = "Salys.txt";

			ofstream fout;
			fout.open(byla);
			if (!fout) {
				arg_pranesimas = "Nepavyko atidaryti bylos " + gcnew String(byla.c_str());
				return false;
			}
			else if (this->_salys == nullptr) {
				arg_pranesimas = "Salys nesukurtos";
				return false;
			}
			else
			{
				fout.close();
				FileStream^ fs = File::Create(gcnew String(byla.c_str()));
				StreamWriter^ sw = gcnew StreamWriter(fs, System::Text::Encoding::ASCII);
				try
				{

					for (int laikinas_indeksas = 0; laikinas_indeksas < this->_salys->ElementuKiekis(); laikinas_indeksas++) {
						Salis^ salis = this->_salys->Rasti_PagalIndeksa(laikinas_indeksas);
						if (salis != nullptr) {
							sw->WriteLine(salis->Kodas() + "\t"  + salis->Pavad());
						}
					}
				}
				finally
				{
					if (sw)
						delete (IDisposable^)sw;
					if (fs)
						delete (IDisposable^)fs;
				}


				return true;
			}
		}

		bool Issaugok_Automobilius(String^% arg_pranesimas) {
			string byla = "Auto.txt";
			ofstream fout;
			fout.open(byla);
			if (!fout) {
				arg_pranesimas = "Nepavyko atidaryti bylos " + gcnew String(byla.c_str());
				return false;
			}
			else if (this->_automobiliai == nullptr) {
				arg_pranesimas = "Automobiliai nesukurti";
				return false;
			}
			else
			{
				fout.close();
				FileStream^ fs = File::Create(gcnew String(byla.c_str()));
				StreamWriter^ sw = gcnew StreamWriter(fs, System::Text::Encoding::ASCII);
				try
				{


					for (int laikinas_indeksas = 0; laikinas_indeksas < this->_automobiliai->ElementuKiekis(); laikinas_indeksas++) {
						Automobilis^ automobilis = this->_automobiliai->Rasti_PagalIndeksa(laikinas_indeksas);
						if (automobilis != nullptr) {
							sw->WriteLine(automobilis->ValNr + "\t" + automobilis->Marke + "\t" + automobilis->KuroRusis->Pavad + "\t" + automobilis->Sanaudu_Norma_Vasara + "\t" + automobilis->Sanaudu_Norma_Ziema + "\t" + automobilis->Tarsos_Koeficentas);
						}
					}

				}
				finally
				{
					if (sw)
						delete (IDisposable^)sw;
					if (fs)
						delete (IDisposable^)fs;
				}

				return true;
			}
		}

		bool Issaugok_Keliones(String^% arg_pranesimas) {
			string byla = "Duomenys.txt";
			ofstream fout;
			fout.open(byla);
			if (!fout) {
				arg_pranesimas = "Nepavyko atidaryti bylos " + gcnew String(byla.c_str());
				return false;
			}
			else if (this->_kuroTipai == nullptr) {
				arg_pranesimas = "Keliones nesukurtos";
				return false;
			}
			else
			{
				fout.close();

				FileStream^ fs = File::Create(gcnew String(byla.c_str()));
				StreamWriter^ sw = gcnew StreamWriter(fs, System::Text::Encoding::ASCII);
				try
				{

					for (int laikinas_indeksas = 0; laikinas_indeksas < this->_keliones->ElementuKiekis(); laikinas_indeksas++) {
						Kelione^ kelione = this->_keliones->Rasti_PagalIndeksa(laikinas_indeksas);
						if (kelione != nullptr) {
							sw->WriteLine(kelione->Masina()->ValNr + "\t" + kelione->Data_Tekstu() + "\t" + kelione->Is_Salies()->Kodas() + "\t" + kelione->Is_Miesto + "\t" + kelione->I_Sali()->Kodas() + "\t" + kelione->I_Miesta + "\t" + kelione->Atstumas + "\t" + kelione->Kuro_Sanaudos);
						}
					}

				}
				finally
				{
					if (sw)
						delete (IDisposable^)sw;
					if (fs)
						delete (IDisposable^)fs;
				}


				
				return true;
			}
		}

		bool Issaugok_Ataskaita(String^% arg_pranesimas) {
			string byla = "Ataskaita.txt";
			ofstream fout;
			fout.open(byla);
			if (!fout) {
				arg_pranesimas = "Nepavyko atidaryti bylos " + gcnew String(byla.c_str());
				return false;
			}
			else if (this->_ataskaita == nullptr) {
				arg_pranesimas = "Ataskaita nesukurta";
				return false;
			}
			else
			{
				fout.close();
				FileStream^ fs = File::Create(gcnew String(byla.c_str()));
				StreamWriter^ sw = gcnew StreamWriter(fs, System::Text::Encoding::ASCII);
				try
				{
					for (int laikinas_indeksas = 0; laikinas_indeksas < this->_keliones->ElementuKiekis(); laikinas_indeksas++) {
						AtaskaitosAtranka^ ataskaitosAtranka = this->_ataskaita->Rasti_PagalIndeksa(laikinas_indeksas);
						if (ataskaitosAtranka != nullptr) {
							sw->WriteLine(ataskaitosAtranka->ValstybinisNumeris + "\t" + ataskaitosAtranka->KuroRusis + "\t" + ataskaitosAtranka->Visos_Kuro_Sanaudos + "\t" + ataskaitosAtranka->Tarsos_Koeficentas);
						}
					}

				}
				finally
				{
					if (sw)
						delete (IDisposable^)sw;
					if (fs)
						delete (IDisposable^)fs;
				}




				
				return true;
			}
		}

	};

}