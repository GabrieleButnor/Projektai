#pragma once
namespace Darbas {
	using namespace System;

	public ref class Salis
	{
	private:
		String^ _kodas;
		String^ _pavad;

	public:

		Salis()
		{
			this->_kodas = "";
			this->_pavad = "";
		}

		// konstruktorius
		// metodo iskvieciamas kai sukuriams klases Salis objektas
		// argumentas arg_kodas : salies kodas
		// argumentas arg_pavad : salies pavadinimas
		Salis(String^ arg_kodas, String^ arg_pavad)
		{
			this->_kodas = arg_kodas;
			this->_pavad = arg_pavad;
		}

		//destruktorius
		// metodo iskvieciamas kai sunaikinamas klases Salis objektas
		~Salis()
		{
		}

		String^ Kodas() {
			return this->_kodas;
		}

		String^ Pavad() {
			return this->_pavad;
		}

	};
}


