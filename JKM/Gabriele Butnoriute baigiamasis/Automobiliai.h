#pragma once
#include "Automobilis.h"
#include "KuroTipai.h"
namespace Darbas {
	using namespace System;
	using namespace System::Collections;
	using namespace System::Collections::Generic;

	public ref class Automobiliai
	{
	private:
		KuroTipai^ _kuroTipai;
		Automobilis^ _nerastas;
		List<Automobilis^>^ _automobiliai;
		Automobilis^ _pasirinktas;
	public:
		
		Automobiliai(KuroTipai^ arg_kuroTipai)
		{
			this->_kuroTipai = nullptr;
		this->_nerastas = nullptr;
		this->_automobiliai = gcnew List<Automobilis^>();
		this->_pasirinktas = nullptr;

			this->_kuroTipai = arg_kuroTipai;
			this->_nerastas = gcnew Automobilis("Nerastas", "Neþinoma", arg_kuroTipai->Nerastas(), 0.0, 0.0, 0.0);
		}

		~Automobiliai()
		{
			
			for (int indeksas = 0; indeksas < this->_automobiliai->Count; indeksas++) {
				delete this->_automobiliai[indeksas];
			}
			this->_automobiliai->Clear();
			delete this->_nerastas;
			this->_nerastas = nullptr;
			this->_pasirinktas = nullptr;
		}

		Automobilis^ Sukurti(String^ arg_valNr, String^ arg_marke, String^ arg_kuroRusis_kodas, double arg_sanaudu_norma_Z, double arg_sanaudu_norma_V, double arg_tarsosKoef) {
			KuroTipas^ kuroRusis = _kuroTipai->Rasti_PagalPavadinima(arg_kuroRusis_kodas);
			if (kuroRusis == nullptr) {
				kuroRusis = this->_kuroTipai->Nerastas();
			}
			if (kuroRusis != nullptr) {
				Automobilis ^ automobilis = Sukurti(arg_valNr, arg_marke, kuroRusis, arg_sanaudu_norma_Z, arg_sanaudu_norma_V, arg_tarsosKoef);
				return automobilis;
			}
			else return nullptr;
		}

		Automobilis^ Sukurti(String^ arg_valNr, String^ arg_marke, KuroTipas^ arg_kuroRusis, double arg_sanaudu_norma_Z, double arg_sanaudu_norma_V, double arg_tarsosKoef) {
			Automobilis^ automobilis = gcnew Automobilis(arg_valNr, arg_marke, arg_kuroRusis, arg_sanaudu_norma_Z, arg_sanaudu_norma_V, arg_tarsosKoef);
			_automobiliai->Add(automobilis);
			return automobilis;
		}


		void Pasalinti(Automobilis^ arg_automobilis) {
			int indeksas = this->_automobiliai->IndexOf(arg_automobilis);
			if (indeksas > -1) {
				this->_automobiliai->RemoveAt(indeksas);
				delete arg_automobilis;
			}
		}

		Automobilis^ Rasti_PagalValstybiniNumeri(String^ arg_valNr) {
			int laikinas_indekas = this->_automobiliai->Count, resultatas_indekas = -1;
			while (laikinas_indekas > 0) {
				laikinas_indekas--;
				if (this->_automobiliai[laikinas_indekas]->ValNr == arg_valNr) {
					resultatas_indekas = laikinas_indekas;
					break;
				}
			}
			if (resultatas_indekas > -1) {
				return this->_automobiliai[resultatas_indekas];
			}
			else return nullptr;
		}

		Automobilis^ Rasti_PagalIndeksa(int arg_indeksas) {
			if (-1 < arg_indeksas && arg_indeksas < this->_automobiliai->Count) {
				return this->_automobiliai[arg_indeksas];
			}
			else return nullptr;
		}

		List<Automobilis^>^ Duok_Sarasa() {
			return this->_automobiliai;
		}

		int ElementuKiekis() {
			return this->_automobiliai->Count;
		}

		Automobilis^ Nerastas() {
			return this->_nerastas;
		}



		void Isvalyti_AktyvuAutomobili() {
			this->_pasirinktas = nullptr;
		}

		void Nurodyti_AktyvuAutomobiliPagalValNr(String^ arg_valNr) {
			this->_pasirinktas = Rasti_PagalValstybiniNumeri(arg_valNr);
		}

		Automobilis^ AktyvusAutomobilis() {
			return this->_pasirinktas;
		}

		void Valyti() {
			for (int indeksas = 0; indeksas < this->_automobiliai->Count; indeksas++) {
				delete this->_automobiliai[indeksas];
			}
			this->_automobiliai->Clear();
		}

	};
}

