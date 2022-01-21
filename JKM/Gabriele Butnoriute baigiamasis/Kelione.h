#pragma once
#include "Automobilis.h"
#include "Salis.h"
namespace Darbas {
	using namespace System;

	public ref class Kelione
	{
	private:
		Automobilis^ _masina;
		DateTime^ _data;
		Salis^ _salis_is;
		String^ _miestas_is;
		Salis^ _salis_i;
		String^ _miestas_i;
		double _atstumas;
		double _kuro_sanaudos;
	public:
		Kelione()
		{
			this->_masina = nullptr;
			this->_data = nullptr;
			this->_salis_is = nullptr;
			this->_miestas_is = "";
			this->_salis_i = nullptr;
			this->_miestas_i = "";
			this->_atstumas = 0.0;
			this->_kuro_sanaudos = 0.0;
		}

		Kelione(Automobilis^% arg_masina, DateTime^ arg_data, Salis^% arg_salis_is, String^ arg_miestas_is, Salis^% arg_salis_i, String^ arg_miestas_i, double arg_atstumas, double arg_kuro_sanaudos) {
			this->_masina = arg_masina;
			this->_data = arg_data;
			this->_salis_is = arg_salis_is;
			this->_miestas_is = arg_miestas_is;
			this->_salis_i = arg_salis_i;
			this->_miestas_i = arg_miestas_i;
			this->_atstumas = arg_atstumas;
			this->_kuro_sanaudos = arg_kuro_sanaudos;
		}


		~Kelione()
		{
		}

		property String^ ValNr {
			String^ get() {
				return this->_masina->ValNr;
			}
		}

		Automobilis^ Masina() {
			return this->_masina;
		}

		void Nurodyti_Masina(Automobilis^% arg_masina) {
			this->_masina = arg_masina;
		}

		property DateTime^ Data {
			DateTime^ get() {
				return this->_data;
			}
		}

		String^ Data_Tekstu() {
			return this->_data->ToString("yyyy.MM.dd");
		}

		void Nurodyti_Data(DateTime^ arg_data) {
			this->_data = arg_data;
		}

		bool Nurodyti_Data_Tekstu(String^ arg_data) {
			bool resultatas = false;
			DateTime tmp;
			resultatas = DateTime::TryParse(arg_data, tmp);
			if (resultatas) {
				this->_data = tmp;
			}
			return resultatas;
		}

		property String^ Is_Salies_Kodas {
			String^ get() {
				return this->_salis_is->Kodas();
			}
		}


		Salis^ Is_Salies() {
			return this->_salis_is;
		}
		void Nurodyti_Sali_Is(Salis^% arg_salis) {
			this->_salis_is = arg_salis;
		}

		property String^ Is_Miesto {
			String^ get() {
				return this->_miestas_is;
			}
		}

		void Nurodyti_Miesta_Is(String^ arg_miestas) {
			this->_miestas_is = arg_miestas;
		}

		property String^ I_Salies_Kodas {
			String^ get() {
				return this->_salis_i->Kodas();
			}
		}

		Salis^ I_Sali() {
			return this->_salis_i;
		}

		void Nurodyti_Sali_I(Salis^% arg_salis) {
			this->_salis_i = arg_salis;
		}

		property String^ I_Miesta {
			String^ get() {
				return this->_miestas_i;
			}
		}


		void Nurodyti_Miesta_I(String^ arg_miestas) {
			this->_miestas_i = arg_miestas;
		}

		property double Atstumas {
			double get() {
				return this->_atstumas;
			}
		}


		void Nurodyti_Atstuma(double arg_atstumas) {
			this->_atstumas = arg_atstumas;
		}

		property double Kuro_Sanaudos {
			double get() {
				return this->_kuro_sanaudos;
			}
		}
 
		void SuskaiciuokSanaudas() {
			double sanaudu_norma = 0;
			// ziemos norma nuo lapkricio 1 iki balandzio 1
			if ((1 <= this->_data->Month && this->_data->Month < 4) || (11 <= this->_data->Month && this->_data->Month <= 12)) {
				sanaudu_norma = this->Masina()->Sanaudu_Norma_Ziema;
			}
			else
			{
				sanaudu_norma = this->Masina()->Sanaudu_Norma_Vasara;
			}

			this->_kuro_sanaudos = (this->_atstumas / 100) * sanaudu_norma;
		}

	};

}