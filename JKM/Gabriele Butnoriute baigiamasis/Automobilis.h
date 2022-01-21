#include "KuroTipas.h"
#pragma once
namespace Darbas {
	using namespace System;

	public ref class Automobilis
	{

	private:
		String^ _valNr;
		String^ _marke;
		KuroTipas^ _kuroRusis;
		double _sanaudu_norma_Z;
		double _sanaudu_norma_V;
		double _tarsosKoef;
	public:

		Automobilis()
		{
			this->_valNr = "";
			this->_marke = "";
			this->_kuroRusis = nullptr;
			this->_sanaudu_norma_V = 0.0;
			this->_sanaudu_norma_Z = 0.0;
			this->_tarsosKoef = 0.0;
		}

		Automobilis(String^ arg_valNr, String^ arg_marke, KuroTipas^ arg_kuroRusis, double arg_san_norma_v, double arg_san_norma_z, double arg_tarsos_koef) {
			this->_valNr = arg_valNr;
			this->_marke = arg_marke;
			this->_kuroRusis = arg_kuroRusis;
			this->_sanaudu_norma_V = arg_san_norma_v;
			this->_sanaudu_norma_Z = arg_san_norma_z;
			this->_tarsosKoef = arg_tarsos_koef;
		}


		~Automobilis()
		{
		}

		property String^ ValNr {
			String^ get() {
				return this->_valNr;
			}
		}

		property String^ Marke {
			String^ get() {
				return this->_marke;
			}
		}

		property KuroTipas^ KuroRusis {
			KuroTipas^ get() {
				return this->_kuroRusis;
			}
		}

		property String^ KuroRusiesPavad {
			String^ get() {
				return this->_kuroRusis->Pavad;
			}
		}

		property double Sanaudu_Norma_Vasara {
			double get() {
				return this->_sanaudu_norma_V;
			}
		}

		property double Sanaudu_Norma_Ziema {
			double get() {
				return this->_sanaudu_norma_Z;
			}
		}
		 
		property double Tarsos_Koeficentas {
			double get() {
				return this->_tarsosKoef;
			}
		}


	};
}

