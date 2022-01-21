#pragma once
namespace Darbas {
	using namespace System;

	public ref class KuroTipas
	{
	private:
		String^ _pavad;
	public:

		KuroTipas()
		{
		}

		KuroTipas(String^ arg_pavad)
		{
			this->_pavad = arg_pavad;
		}


		~KuroTipas()
		{
		}


		property String^ Pavad {
			String^ get() {
				return this->_pavad;
			}
		}


	};
}

