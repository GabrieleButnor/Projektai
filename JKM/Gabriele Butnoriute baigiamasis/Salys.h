#pragma once
#include "Salis.h"
namespace Darbas {
	using namespace System;
	using namespace System::Collections;
	using namespace System::Collections::Generic;


	public ref class Salys
	{
	private:
		int _Kiekis;
		List<Salis^>^ _salys;
		Salis^ _nerasta;
	public:

		Salys()
		{
			this->_Kiekis = 0;
		    this->_salys = gcnew List<Salis^>();
			this->_nerasta = gcnew Salis("Nerasta", "Nerasta");
		}


		~Salys()
		{
			for (int indeksas = 0; indeksas < this->_salys->Count; indeksas++) {
				delete this->_salys[indeksas];
			}
			this->_salys->Clear();
			delete this->_salys;
			this->_salys = nullptr;
			delete this->_nerasta;
			this->_nerasta = nullptr;
		}


		Salis^ Sukurti(String^ arg_salies_kodas, String^ arg_salies_pavad) {
			Salis^ salis = gcnew Salis(arg_salies_kodas, arg_salies_pavad);
			_salys->Add(salis);
			return salis;
		}

		void Pasalinti(Salis^% arg_salis) {
			int indeksas = this->_salys->IndexOf(arg_salis);
			if (indeksas > -1) {
				this->_salys->RemoveAt(indeksas);
				delete arg_salis;
			}
		}

		Salis^ Rasti_PagalKoda(String^ arg_salies_kodas) {
			int laikinas_indekas = this->_salys->Count, resultatas_indekas = -1;
			while (laikinas_indekas > 0) {
				laikinas_indekas--;
				if (this->_salys[laikinas_indekas]->Kodas() == arg_salies_kodas) {
					resultatas_indekas = laikinas_indekas;
					break;
				}
			}
			if (resultatas_indekas > -1) {
				return this->_salys[resultatas_indekas];
			}
			else return nullptr;
		}

		Salis^ Rasti_PagalIndeksa(int arg_indeksas) {
			if (-1 < arg_indeksas && arg_indeksas < _salys->Count) {
				return this->_salys[arg_indeksas];
			}
			else return nullptr;
		}

		int ElementuKiekis() {
			return _salys->Count;
		}

		Salis^ Nerasta() {
			return this->_nerasta;
		}



	};

}