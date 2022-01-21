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
	/// Summary for Forma_IstrintiAutomobili
	/// </summary>
	public ref class Forma_IstrintiAutomobili : public System::Windows::Forms::Form
	{
	public:
		Forma_IstrintiAutomobili(Duomenys^ arg_duomenys)
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
		~Forma_IstrintiAutomobili()
		{
			if (components)
			{
				delete components;
			}
			this->_duomenys = nullptr;
		}
	private: System::Windows::Forms::Button^  button1;
	protected:
	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::TextBox^  textBox_ValNr;


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
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->textBox_ValNr = (gcnew System::Windows::Forms::TextBox());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(99, 154);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(115, 49);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Trinti";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_IstrintiAutomobili::button1_Click);
			// 
			// button2
			// 
			this->button2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button2->Location = System::Drawing::Point(263, 194);
			this->button2->Margin = System::Windows::Forms::Padding(2);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(57, 42);
			this->button2->TabIndex = 1;
			this->button2->Text = L"Atgal";
			this->button2->UseVisualStyleBackColor = false;
			this->button2->Click += gcnew System::EventHandler(this, &Forma_IstrintiAutomobili::button2_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label1->Location = System::Drawing::Point(57, 36);
			this->label1->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(223, 34);
			this->label1->TabIndex = 2;
			this->label1->Text = L"Iveskite norimos iðtrinti transporto \r\npriemones valtybiná numerá:";
			this->label1->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// textBox_ValNr
			// 
			this->textBox_ValNr->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->textBox_ValNr->Location = System::Drawing::Point(99, 93);
			this->textBox_ValNr->Margin = System::Windows::Forms::Padding(2);
			this->textBox_ValNr->Multiline = true;
			this->textBox_ValNr->Name = L"textBox_ValNr";
			this->textBox_ValNr->Size = System::Drawing::Size(116, 37);
			this->textBox_ValNr->TabIndex = 3;
			// 
			// Forma_IstrintiAutomobili
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(328, 244);
			this->Controls->Add(this->textBox_ValNr);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_IstrintiAutomobili";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Iðtrinti automobili";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
		this->Close();
	}
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

		if (this->_duomenys->VisiAutomobiliai() == nullptr || (this->_duomenys->VisiAutomobiliai() != nullptr && this->_duomenys->VisiAutomobiliai()->ElementuKiekis() == 0))
		{
			String^ pranesimas = "";
			if (!this->_duomenys->Nuskaityti_Automobilius(pranesimas))
			{
				MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
			}
		}

		if (this->textBox_ValNr->Text == "") {
			MessageBox::Show("Nenurodytas automobilio numeris", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
		else {

			Automobilis^ automobilis = this->_duomenys->VisiAutomobiliai()->Rasti_PagalValstybiniNumeri(this->textBox_ValNr->Text);
			if (automobilis == nullptr) {
				MessageBox::Show("Automobilis nerastas pagal nurodyta numerá", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);

			}
			else
			{
				this->_duomenys->VisiAutomobiliai()->Pasalinti(automobilis);
				String^ pranesimas = "";
				if (!this->_duomenys->Issaugok_Automobilius(pranesimas))
				{
					MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
				}
				this->_duomenys->VisiAutomobiliai()->Valyti();
				if (!this->_duomenys->Nuskaityti_Automobilius(pranesimas))
				{
					MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
				}
				this->Close();
			}
		}
	}
	};
}
