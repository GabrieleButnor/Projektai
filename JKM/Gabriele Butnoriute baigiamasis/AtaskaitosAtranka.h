#pragma once
#include "Automobilis.h"

namespace Darbas {
	using namespace System;

	public ref class AtaskaitosAtranka
	{

	private:
		Automobilis^ _masina;
		double _visosKuroSanaudos;

	public:
		AtaskaitosAtranka(Automobilis^% arg_masina, double arg_visos_kuro_sanaudos)
		{
			this->_masina = arg_masina;
			this->_visosKuroSanaudos = arg_visos_kuro_sanaudos;
		}


		~AtaskaitosAtranka()
		{
			this->_masina = nullptr;
		}

		Automobilis^ Masina() {
			return this->_masina;
		}

		
		property String^ ValstybinisNumeris {
			String^ get() {
				return this->_masina->ValNr;
			}
		}

		property String^ KuroRusis {
			String^ get() {
				return this->_masina->KuroRusis->Pavad;
			}
		}

	
		property double Visos_Kuro_Sanaudos {
			double get() {
				return this->_visosKuroSanaudos;
			}
		}

		void Nurodyti_Visas_Kuro_Sanaudas(double arg_visos_kuro_sanaodos) {
			this->_visosKuroSanaudos = arg_visos_kuro_sanaodos;
		}

		property double Tarsos_Koeficentas {
			double get() {
				return this->_masina->Tarsos_Koeficentas;
			}
		}
		


	};
}

