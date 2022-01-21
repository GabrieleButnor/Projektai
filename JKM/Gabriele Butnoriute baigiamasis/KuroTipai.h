#pragma once
#include "KuroTipas.h"
namespace Darbas {
	using namespace System;
	using namespace System::Collections;
	using namespace System::Collections::Generic;

	public ref class KuroTipai
	{
	private:
		KuroTipas^ _nerastas;
		List<KuroTipas^>^ _kuroTipai;

	public:

		KuroTipai()
		{
			this->_kuroTipai = gcnew List<KuroTipas^>();
			this->_nerastas = gcnew KuroTipas("Nerastas");
		}


		~KuroTipai()
		{
			for (int indeksas = 0; indeksas < this->_kuroTipai->Count; indeksas++) {
				delete this->_kuroTipai[indeksas];
			}
			this->_kuroTipai->Clear();
			delete this->_nerastas;
			this->_nerastas = nullptr;
		}

		KuroTipas ^ Sukurti(String^ arg_pavad) {
			KuroTipas^ kuroTipas = gcnew KuroTipas(arg_pavad);
			_kuroTipai->Add(kuroTipas);
			return kuroTipas;
		}

		void Pasalinti(KuroTipas^% arg_kuroTipas) {
			int indeksas = this->_kuroTipai->IndexOf(arg_kuroTipas);
			if (indeksas > -1) {
				this->_kuroTipai->RemoveAt(indeksas);
				delete arg_kuroTipas;
			}
		}

		KuroTipas^ Rasti_PagalPavadinima(String^ arg_pavad) {

			int laikinas_indekas = this->_kuroTipai->Count, resultatas_indekas = -1;
			while (laikinas_indekas > 0) {
				laikinas_indekas--;
				if (this->_kuroTipai[laikinas_indekas]->Pavad == arg_pavad) {
					resultatas_indekas = laikinas_indekas;
					break;
				}
			}
			if (resultatas_indekas > -1) {
				return this->_kuroTipai[resultatas_indekas];
			}
			else return nullptr;
		}

		KuroTipas^ Rasti_PagalIndeksa(int arg_indeksas) {
			if (-1 < arg_indeksas && arg_indeksas < this->_kuroTipai->Count) {
				return this->_kuroTipai[arg_indeksas];
			}
			else return nullptr;
		}

		int ElementuKiekis() {
			return this->_kuroTipai->Count;
		}

		KuroTipas^ Nerastas() {
			return this->_nerastas;
		}
	};

}