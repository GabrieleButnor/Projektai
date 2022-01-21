#pragma once
#include "Vartotojai.h"
#include "Vartotojas.h"
namespace Darbas {
	using namespace System;
	public ref class Prisijungimas
	{
	private:
		Vartotojai^ _vartotojai;
		Vartotojas^ _prisijunges;

	public:
		Prisijungimas()
		{
			this->_vartotojai = gcnew Vartotojai();
			this->_prisijunges = nullptr;
		}


		~Prisijungimas()
		{
			if (this->_prisijunges != nullptr) {
				this->_prisijunges = nullptr;
			}

			if (this->_vartotojai != nullptr) {
				delete this->_vartotojai;
				this->_vartotojai = nullptr;
			}
		}

		void Sukurk_Vartotojus() {
			this->_vartotojai->Sukurti("Gabriele", "Butnoriute", true);
			this->_vartotojai->Sukurti("Darbuotojas", "Auto", false);

		}

		bool Prisijungti(String^ arg_vardas, String^ arg_slaptazodis, String^% arg_pranesimas) {
			bool rezultatas = false;
			if (arg_vardas == "") {
				arg_pranesimas = "Nenurodytas vartotojo vardas";
			}
			else if (arg_slaptazodis == "") {
				arg_pranesimas = "Nenurodytas vartotojo slaptaþodis";
			}
			else {

				Vartotojas^ vartotojas = this->_vartotojai->Rasti_pagalVarda(arg_vardas);
				if (vartotojas != nullptr) {
					if (vartotojas->ArAtitinkaSlaptazodis(arg_slaptazodis)) {
						_prisijunges = vartotojas;
						rezultatas = true;
					}
					else
					{
						arg_pranesimas = "Neteisingas slaptaþodis";
					}
				}
				else
				{
					arg_pranesimas = "Vartotojas nerastas";
				}
			}
			return rezultatas;
		}

		void Atsijungti() {
			this->_prisijunges = nullptr;
		};

		bool ArPrisijunges() {
			return (this->_prisijunges != nullptr);
		}

		Vartotojas^ PrisijungesKaip() {
			return this->_prisijunges;
		}


	};
}
