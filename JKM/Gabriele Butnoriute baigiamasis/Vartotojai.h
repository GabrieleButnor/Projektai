#pragma once
#include "Vartotojas.h"
namespace Darbas {
	using namespace System;
	using namespace System::Collections;
	using namespace System::Collections::Generic;

	public ref class Vartotojai
	{

	private:
		List<Vartotojas^>^ _vartotojai;

	public:

		Vartotojai()
		{
			this->_vartotojai = gcnew List<Vartotojas^>();
		}

		~Vartotojai()
		{
			for (int indeksas = 0; indeksas < this->_vartotojai->Count; indeksas++) {
				delete this->_vartotojai[indeksas];
			}
			this->_vartotojai->Clear();
		}


		Vartotojas^ Sukurti(String^ arg_vardas, String^ arg_slaptas, bool arg_admin) {
			Vartotojas^ vartotojas = gcnew Vartotojas(arg_vardas, arg_slaptas, arg_admin);
			_vartotojai->Add(vartotojas);
			return vartotojas;
		}

		void Pasalinti(Vartotojas^% arg_vartotojas) {
			int indeksas = this->_vartotojai->IndexOf(arg_vartotojas);
			if (indeksas > -1) {
				this->_vartotojai->RemoveAt(indeksas);
				delete arg_vartotojas;
			}
		}

		Vartotojas^ Rasti_pagalVarda(String ^arg_vardas) {

			int laikinas_indekas = this->_vartotojai->Count, resultatas_indekas = -1;
			while (laikinas_indekas > 0) {
				laikinas_indekas--;
				if (_vartotojai[laikinas_indekas]->Vardas() == arg_vardas) {
					resultatas_indekas = laikinas_indekas;
					break;
				}
			}
			if (resultatas_indekas > -1) {
				return this->_vartotojai[resultatas_indekas];
			}
			else return nullptr;
		}

	};
}

