#pragma once
namespace Darbas {
	using namespace System;
	public ref class Vartotojas
	{
	private:
		String^ _vardas;
		String^ _slaptas;
		bool _ar_admin;

	public:

		Vartotojas()
		{
					this->_vardas = "";
		          this->_slaptas = "";
		this->_ar_admin = false;

		}

		Vartotojas(String ^arg_vardas, String ^arg_slapt, bool arg_ar_admin)
		{
			this->_vardas = arg_vardas;
			this->_slaptas = arg_slapt;
			this->_ar_admin = arg_ar_admin;
		}

		~Vartotojas()
		{
		}


		String^ Vardas() {
			return this->_vardas;
		}

		bool ArAtitinkaSlaptazodis(String ^arg_slaptas) {
			return (this->_slaptas == arg_slaptas);
		}

		bool ArAdministratorius() {
			return this->_ar_admin;
		}
		
	};
}

