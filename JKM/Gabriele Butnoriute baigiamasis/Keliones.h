#pragma once
#include "Kelione.h"
#include "Automobiliai.h"
#include "Salys.h"
namespace Darbas {
	using namespace System;
	using namespace System::Collections;
	using namespace System::Collections::Generic;

	public ref class Keliones
	{
	private:
		Automobiliai ^ _automobiliai;
		Salys^ _salys;
		List<Kelione^>^ _keliones;


	public:

		Keliones(Automobiliai^ arg_automobiliai, Salys^ arg_Salys)
		{
			this->_automobiliai = arg_automobiliai;
			this->_salys = arg_Salys;
			this->_keliones = gcnew List<Kelione^>();
		}


		~Keliones()
		{
			for (int indeksas = 0; indeksas < this->_keliones->Count; indeksas++) {
				delete this->_keliones[indeksas];
			}
			this->_keliones->Clear();
			this->_automobiliai = nullptr;
			this->_salys = nullptr;
		}

		Kelione^ Sukurti(String^ arg_valNr, String^ arg_data, String^ arg_salies_kodas_is, String^ arg_miestas_is, String^ arg_salies_kodas_i, String^ arg_miestas_i, double arg_atstumas, double arg_kuro_sanaudos) {
			Automobilis^ automobilis = this->_automobiliai->Rasti_PagalValstybiniNumeri(arg_valNr);
			Salis^ salis_is = this->_salys->Rasti_PagalKoda(arg_salies_kodas_is);
			Salis^ salis_i = this->_salys->Rasti_PagalKoda(arg_salies_kodas_i);
			if (automobilis == nullptr) {
				automobilis = this->_automobiliai->Nerastas();
			}
			if (salis_is == nullptr) {
				salis_is = this->_salys->Nerasta();
			}
			if (salis_i == nullptr) {
				salis_i = this->_salys->Nerasta();
			}

			DateTime arg_data_date;
			bool datos_vertimas = DateTime::TryParse(arg_data, arg_data_date);
			if (automobilis != nullptr && salis_is != nullptr && salis_i != nullptr && datos_vertimas) {
				Kelione^ kelione = Sukurti(automobilis, arg_data_date, salis_is, arg_miestas_is, salis_i, arg_miestas_i, arg_atstumas, arg_kuro_sanaudos);
				return kelione;
			}
			else return nullptr;
		}

		Kelione^ Sukurti(Automobilis^ arg_auto, String^ arg_data, Salis^ arg_salis_is, String^ arg_miestas_is, Salis^ arg_salies_i, String^ arg_miestas_i, double arg_atstumas, double arg_kuro_sanaudos) {
			DateTime arg_data_date;
			Kelione^ kelione = nullptr;
			bool datos_vertimas = DateTime::TryParse(arg_data, arg_data_date);
			if (datos_vertimas) {

				kelione = Sukurti(arg_auto, arg_data_date, arg_salis_is, arg_miestas_is, arg_salies_i, arg_miestas_i, arg_atstumas, arg_kuro_sanaudos);
				kelione->SuskaiciuokSanaudas();
			}
			return kelione;
		}

		Kelione^ Sukurti(Automobilis^ arg_auto, DateTime arg_data, Salis^ arg_salis_is, String^ arg_miestas_is, Salis^ arg_salies_i, String^ arg_miestas_i, double arg_atstumas, double arg_kuro_sanaudos) {
			Kelione^ kelione = gcnew Kelione(arg_auto, arg_data, arg_salis_is, arg_miestas_is, arg_salies_i, arg_miestas_i, arg_atstumas, arg_kuro_sanaudos);
			_keliones->Add(kelione);
			return kelione;
		}

		void Pasalinti(Kelione^ arg_kelione) {
			int indeksas = this->_keliones->IndexOf(arg_kelione);
			if (indeksas > -1) {
				this->_keliones->RemoveAt(indeksas);
				delete arg_kelione;
			}
		}

		Kelione^ Rasti_PagalIndeksa(int arg_indeksas) {
			if (-1 < arg_indeksas && arg_indeksas < this->_keliones->Count) {
				return this->_keliones[arg_indeksas];
			}
			else return nullptr;
		}

		List<Kelione^>^ Duok_Sarasa() {
			return this->_keliones;
		}

		int ElementuKiekis() {
			return this->_keliones->Count;
		}

		void Valyti() {
			for (int indeksas = 0; indeksas < this->_keliones->Count; indeksas++) {
				delete this->_keliones[indeksas];
			}
			this->_keliones->Clear();
		}


	};
}
