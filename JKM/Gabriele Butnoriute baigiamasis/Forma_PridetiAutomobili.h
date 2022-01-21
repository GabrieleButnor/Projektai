#pragma once
#include "Duomenys.h"


namespace Darbas {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;


	/// <summary>
	/// Summary for Forma_PridetiAutomobili
	/// </summary>
	public ref class Forma_PridetiAutomobili : public System::Windows::Forms::Form
	{
	public:
		Forma_PridetiAutomobili(Duomenys^ arg_duomenys)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
			this->_duomenys = arg_duomenys;
		}

	private: Duomenys^ _duomenys;
	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Forma_PridetiAutomobili()
		{
			if (components)
			{
				delete components;
			}
			this->_duomenys = nullptr;
		}
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::TextBox^  textBox_ValNr;
	private: System::Windows::Forms::TextBox^  textBox_Marke;
	private: System::Windows::Forms::TextBox^  textBox_KuroRusis;
	private: System::Windows::Forms::TextBox^  textBox_NormaV;
	protected:




	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::TextBox^  textBox_NormaZ;
	private: System::Windows::Forms::TextBox^  textBox_TarsosKoef;


	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::Label^  label7;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::Button^  button2;

	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->textBox_ValNr = (gcnew System::Windows::Forms::TextBox());
			this->textBox_Marke = (gcnew System::Windows::Forms::TextBox());
			this->textBox_KuroRusis = (gcnew System::Windows::Forms::TextBox());
			this->textBox_NormaV = (gcnew System::Windows::Forms::TextBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->textBox_NormaZ = (gcnew System::Windows::Forms::TextBox());
			this->textBox_TarsosKoef = (gcnew System::Windows::Forms::TextBox());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label1->Location = System::Drawing::Point(48, 77);
			this->label1->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(133, 17);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Valstybinis numeris:";
			// 
			// textBox_ValNr
			// 
			this->textBox_ValNr->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->textBox_ValNr->Location = System::Drawing::Point(190, 67);
			this->textBox_ValNr->Margin = System::Windows::Forms::Padding(2);
			this->textBox_ValNr->Multiline = true;
			this->textBox_ValNr->Name = L"textBox_ValNr";
			this->textBox_ValNr->Size = System::Drawing::Size(134, 27);
			this->textBox_ValNr->TabIndex = 1;
			// 
			// textBox_Marke
			// 
			this->textBox_Marke->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->textBox_Marke->Location = System::Drawing::Point(190, 103);
			this->textBox_Marke->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Marke->Multiline = true;
			this->textBox_Marke->Name = L"textBox_Marke";
			this->textBox_Marke->Size = System::Drawing::Size(134, 25);
			this->textBox_Marke->TabIndex = 2;
			// 
			// textBox_KuroRusis
			// 
			this->textBox_KuroRusis->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->textBox_KuroRusis->Location = System::Drawing::Point(190, 140);
			this->textBox_KuroRusis->Margin = System::Windows::Forms::Padding(2);
			this->textBox_KuroRusis->Multiline = true;
			this->textBox_KuroRusis->Name = L"textBox_KuroRusis";
			this->textBox_KuroRusis->Size = System::Drawing::Size(134, 26);
			this->textBox_KuroRusis->TabIndex = 3;
			// 
			// textBox_NormaV
			// 
			this->textBox_NormaV->Location = System::Drawing::Point(190, 177);
			this->textBox_NormaV->Margin = System::Windows::Forms::Padding(2);
			this->textBox_NormaV->Multiline = true;
			this->textBox_NormaV->Name = L"textBox_NormaV";
			this->textBox_NormaV->Size = System::Drawing::Size(134, 26);
			this->textBox_NormaV->TabIndex = 4;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label2->Location = System::Drawing::Point(48, 110);
			this->label2->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(51, 17);
			this->label2->TabIndex = 5;
			this->label2->Text = L"Markë:";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label3->Location = System::Drawing::Point(48, 142);
			this->label3->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(76, 17);
			this->label3->TabIndex = 6;
			this->label3->Text = L"Kuro rûðis:";
			// 
			// textBox_NormaZ
			// 
			this->textBox_NormaZ->Location = System::Drawing::Point(190, 214);
			this->textBox_NormaZ->Margin = System::Windows::Forms::Padding(2);
			this->textBox_NormaZ->Multiline = true;
			this->textBox_NormaZ->Name = L"textBox_NormaZ";
			this->textBox_NormaZ->Size = System::Drawing::Size(134, 26);
			this->textBox_NormaZ->TabIndex = 7;
			// 
			// textBox_TarsosKoef
			// 
			this->textBox_TarsosKoef->Location = System::Drawing::Point(190, 252);
			this->textBox_TarsosKoef->Margin = System::Windows::Forms::Padding(2);
			this->textBox_TarsosKoef->Multiline = true;
			this->textBox_TarsosKoef->Name = L"textBox_TarsosKoef";
			this->textBox_TarsosKoef->Size = System::Drawing::Size(134, 26);
			this->textBox_TarsosKoef->TabIndex = 8;
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label4->Location = System::Drawing::Point(51, 177);
			this->label4->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(133, 17);
			this->label4->TabIndex = 9;
			this->label4->Text = L"Kuro norma vasara:";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label5->Location = System::Drawing::Point(55, 220);
			this->label5->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(127, 17);
			this->label5->TabIndex = 10;
			this->label5->Text = L"Kuro norma þiema:";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label6->Location = System::Drawing::Point(55, 261);
			this->label6->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(127, 17);
			this->label6->TabIndex = 11;
			this->label6->Text = L"Tarðos koficientas:";
			// 
			// label7
			// 
			this->label7->AutoSize = true;
			this->label7->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label7->Location = System::Drawing::Point(19, 27);
			this->label7->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(243, 17);
			this->label7->TabIndex = 12;
			this->label7->Text = L"Áveskite naujo  automobilio duomenis:";
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(139, 302);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(89, 39);
			this->button1->TabIndex = 13;
			this->button1->Text = L"Iðsaugoti";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_PridetiAutomobili::button1_Click);
			// 
			// button2
			// 
			this->button2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button2->Location = System::Drawing::Point(321, 317);
			this->button2->Margin = System::Windows::Forms::Padding(2);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(50, 24);
			this->button2->TabIndex = 14;
			this->button2->Text = L"Atgal";
			this->button2->UseVisualStyleBackColor = false;
			this->button2->Click += gcnew System::EventHandler(this, &Forma_PridetiAutomobili::button2_Click);
			// 
			// Forma_PridetiAutomobili
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(379, 349);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->label7);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->textBox_TarsosKoef);
			this->Controls->Add(this->textBox_NormaZ);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->textBox_NormaV);
			this->Controls->Add(this->textBox_KuroRusis);
			this->Controls->Add(this->textBox_Marke);
			this->Controls->Add(this->textBox_ValNr);
			this->Controls->Add(this->label1);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_PridetiAutomobili";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Pridëti";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion



private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
			 this-> Close();
		 }
private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

	String^ pranesimas = "";
	if (this->_duomenys->VisiKuroTipai() == nullptr || (this->_duomenys->VisiKuroTipai() != nullptr && this->_duomenys->VisiKuroTipai()->ElementuKiekis() == 0) && !this->_duomenys->Nuskaityti_KuroTipus(pranesimas)) {

		MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
	}

	if (this->_duomenys->VisiAutomobiliai() == nullptr || (this->_duomenys->VisiAutomobiliai() != nullptr && this->_duomenys->VisiAutomobiliai()->ElementuKiekis() == 0) && !this->_duomenys->Nuskaityti_Automobilius(pranesimas)) {

		MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
	}


	if (this->textBox_ValNr->Text == "")
	{
		MessageBox::Show("Nenurodytas valstybinis numeris", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
	}
	else if (_duomenys->VisiAutomobiliai()->Rasti_PagalValstybiniNumeri(this->textBox_ValNr->Text) != nullptr)
	{
		MessageBox::Show("Automobilis su tokiu valstybiniu numeriu jau egzistuoja", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
	}
	else if (this->textBox_KuroRusis->Text == "")
	{
		MessageBox::Show("Nenurodyta kuro rûðis", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
	}
	else if (_duomenys->VisiKuroTipai()->Rasti_PagalPavadinima(this->textBox_KuroRusis->Text) == nullptr)
	{
		MessageBox::Show("Nerasta kuro rûðis pagal pavadinimà", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
	}
	else {
		KuroTipas^ kuroRusis = _duomenys->VisiKuroTipai()->Rasti_PagalPavadinima(this->textBox_KuroRusis->Text);
		double normaV = 0;
		double normaZ = 0;
		double tarsosKoef = 0;
		CultureInfo^ culture = CultureInfo::CurrentCulture;
		if (!double::TryParse(this->textBox_NormaV->Text->Replace(".", culture->NumberFormat->NumberDecimalSeparator), normaV))
		{
			normaV = 0;
		}

		if (!double::TryParse(this->textBox_NormaZ->Text->Replace(".", culture->NumberFormat->NumberDecimalSeparator), normaZ))
		{
			normaZ = 0;
		}

		if (!double::TryParse(this->textBox_TarsosKoef->Text->Replace(".", culture->NumberFormat->NumberDecimalSeparator), tarsosKoef))
		{
			tarsosKoef = 0;
		}



		Automobilis^ naujasAtomobilis = this->_duomenys->VisiAutomobiliai()->Sukurti(textBox_ValNr->Text, textBox_Marke->Text,kuroRusis,normaZ,normaV,tarsosKoef);
		if (naujasAtomobilis != nullptr) {
		  	if (!this->_duomenys->Issaugok_Automobilius(pranesimas)) {
				MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
			}
			else
			{
				this->_duomenys->VisiAutomobiliai()->Valyti();
				if (!this->_duomenys->Nuskaityti_Automobilius(pranesimas)) {
					MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
				}
				Isvalom_Ivedimo_Laukus();
				this->Close();
			}
		}
		else
		{
			MessageBox::Show("Neþinoma klaida", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
	}




}

			 private: System::Void Isvalom_Ivedimo_Laukus() {
				 this->textBox_ValNr->Text = "";
				 this->textBox_Marke->Text = "";
				 this->textBox_KuroRusis->Text = "";
				 this->textBox_NormaV->Text = "";
				 this->textBox_NormaZ->Text = "";
				 this->textBox_TarsosKoef->Text = "";

			 }


};
}
