#pragma once
#include "Automobiliai.h"
#include "Keliones.h"
#include "AtaskaitosAtranka.h"
namespace Darbas {
	using namespace System;
	using namespace System::Collections;
	using namespace System::Collections::Generic;

	public ref class Ataskaita
	{
	private:
		Automobiliai ^ _automobiliai;
		Keliones ^ _keliones;
		List<AtaskaitosAtranka^>^ _atranka;


	public:

		Ataskaita(Automobiliai^ arg_automobiliai, Keliones^ arg_keliones)
		{
		   this->_atranka = gcnew List<AtaskaitosAtranka^>();
			this->_automobiliai = arg_automobiliai;
			this->_keliones = arg_keliones;
		}


		~Ataskaita()
		{
			for (int indeksas = 0; indeksas < this->_atranka->Count; indeksas++) {
				delete this->_atranka[indeksas];
			}
			this->_atranka->Clear();
			this->_automobiliai = nullptr;
			this->_keliones = nullptr;

		}


		AtaskaitosAtranka^ Sukurti(Automobilis^ arg_masina, double arg_visos_kuro_sanaudos) {
			AtaskaitosAtranka^ atranka = gcnew AtaskaitosAtranka(arg_masina, arg_visos_kuro_sanaudos);
			_atranka->Add(atranka);
			return atranka;
		}

		AtaskaitosAtranka^ Rasti_PagalAutomobili(Automobilis^ arg_masina) {
			int laikinas_indekas = this->_atranka->Count, resultatas_indekas = -1;
			while (laikinas_indekas > 0) {
				laikinas_indekas--;
				if (this->_atranka[laikinas_indekas]->Masina() == arg_masina) {
					resultatas_indekas = laikinas_indekas;
					break;
				}
			}
			if (resultatas_indekas > -1) {
				return this->_atranka[resultatas_indekas];
			}
			else return nullptr;
		}


		AtaskaitosAtranka^ Sukurti(String^ arg_valNr, double arg_visos_kuro_sanaudos) {
			Automobilis^ automobilis = this->_automobiliai->Rasti_PagalValstybiniNumeri(arg_valNr);
			if (automobilis == nullptr) {
				automobilis = this->_automobiliai->Nerastas();
			}
			if (automobilis != nullptr) {
				AtaskaitosAtranka^ atrankas = Sukurti(automobilis, arg_visos_kuro_sanaudos);
				return atrankas;
			}
			else return nullptr;

		}



		bool Atrinkti(DateTime^ arg_data_nuo, DateTime^ arg_data_iki) {
			bool resultatas = false;
			if (this->_keliones != nullptr) {
				this->Valyti();

				for (int keliones_indekas = 0; keliones_indekas < this->_keliones->ElementuKiekis(); keliones_indekas++) {

					Kelione ^ kelione = this->_keliones->Rasti_PagalIndeksa(keliones_indekas);
					if (arg_data_nuo->Ticks <= kelione->Data->Ticks && kelione->Data->Ticks <= arg_data_iki->Ticks
						&& (
							kelione->Is_Salies()->Kodas() == "LT"
							&& kelione->I_Sali()->Kodas() == "LT"
							)
						)
					{
						resultatas = true;
						AtaskaitosAtranka^ atranka = Rasti_PagalAutomobili(kelione->Masina());
						if (atranka == nullptr) {
							atranka = Sukurti(kelione->Masina(), 0);
						}
						kelione->SuskaiciuokSanaudas();
						atranka->Nurodyti_Visas_Kuro_Sanaudas(atranka->Visos_Kuro_Sanaudos + kelione->Kuro_Sanaudos);
					}
				}
			}
			return resultatas;
		}

		AtaskaitosAtranka^ Rasti_PagalIndeksa(int arg_indeksas) {
			if (-1 < arg_indeksas && arg_indeksas < this->_atranka->Count) {
				return this->_atranka[arg_indeksas];
			}
			else return nullptr;
		}

		List<AtaskaitosAtranka^>^ Duok_Sarasa() {
			return this->_atranka;
		}


		int ElementuKiekis() {
			return this->_atranka->Count;
		}

		void Valyti() {
			for (int indeksas = 0; indeksas < this->_atranka->Count; indeksas++) {
				delete this->_atranka[indeksas];
			}
			this->_atranka->Clear();
		}


	};

}