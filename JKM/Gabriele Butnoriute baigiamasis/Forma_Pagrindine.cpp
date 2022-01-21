#include "Forma_Pagrindine.h"

using namespace System;
using namespace System::Windows::Forms;


[STAThread]
int main()//(array<System::String ^> ^args)
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Darbas::Forma_Pagrindine form;
	Application::Run(%form);
}


