#pragma once
#include "Forma_NaujaKelione.h"
#include "Duomenys.h"
namespace Darbas {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Forma_AutomobilisKelionei
	/// </summary>
	public ref class Forma_AutomobilisKelionei : public System::Windows::Forms::Form
	{
	public:
		Forma_AutomobilisKelionei(Duomenys^ arg_duomenys)
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
		~Forma_AutomobilisKelionei()
		{
			if (components)
			{
				delete components;
			}
			this->_duomenys = nullptr;
		}
	private: System::Windows::Forms::ComboBox^  comboBox_Automobiliai;
	protected:

	protected:
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::Button^  button2;


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
			this->comboBox_Automobiliai = (gcnew System::Windows::Forms::ComboBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// comboBox_Automobiliai
			// 
			this->comboBox_Automobiliai->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->comboBox_Automobiliai->FormattingEnabled = true;
			this->comboBox_Automobiliai->Location = System::Drawing::Point(249, 51);
			this->comboBox_Automobiliai->Margin = System::Windows::Forms::Padding(2);
			this->comboBox_Automobiliai->Name = L"comboBox_Automobiliai";
			this->comboBox_Automobiliai->Size = System::Drawing::Size(192, 21);
			this->comboBox_Automobiliai->TabIndex = 0;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label1->Location = System::Drawing::Point(44, 36);
			this->label1->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(201, 34);
			this->label1->TabIndex = 1;
			this->label1->Text = L"Pasirinkite reikiamos tansporto\r\npriemonës numerius:";
			this->label1->TextAlign = System::Drawing::ContentAlignment::TopRight;
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(184, 106);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(106, 46);
			this->button1->TabIndex = 2;
			this->button1->Text = L"Pasirinkti";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_AutomobilisKelionei::button1_Click);
			// 
			// button2
			// 
			this->button2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button2->Location = System::Drawing::Point(423, 118);
			this->button2->Margin = System::Windows::Forms::Padding(2);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(66, 34);
			this->button2->TabIndex = 3;
			this->button2->Text = L"Atgal";
			this->button2->UseVisualStyleBackColor = false;
			this->button2->Click += gcnew System::EventHandler(this, &Forma_AutomobilisKelionei::button2_Click);
			// 
			// Forma_AutomobilisKelionei
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(497, 160);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->comboBox_Automobiliai);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_AutomobilisKelionei";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Automobilio pasirinkimas";
			this->Load += gcnew System::EventHandler(this, &Forma_AutomobilisKelionei::Forma_AutomobilisKelionei_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
		this->Close();
	}
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

		if (this->comboBox_Automobiliai->SelectedIndex != -1) {

			String^ aktyvus_ValNr = comboBox_Automobiliai->SelectedValue->ToString();
			this->Hide();
			this->_duomenys->VisiAutomobiliai()->Nurodyti_AktyvuAutomobiliPagalValNr(aktyvus_ValNr);
  		    Forma_NaujaKelione^ forma_nauja_kelione = gcnew Forma_NaujaKelione(this->_duomenys);
			forma_nauja_kelione->ShowDialog();
			forma_nauja_kelione->Hide();
			this->_duomenys->VisiAutomobiliai()->Isvalyti_AktyvuAutomobili();
			delete forma_nauja_kelione;
			this->Show();
		}
		else
		{
			MessageBox::Show("Nepasirinktas automobilis", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}


	}

			 


	private: System::Void Forma_AutomobilisKelionei_Load(System::Object^  sender, System::EventArgs^  e) {
		if (this->_duomenys->VisiAutomobiliai() == nullptr || (this->_duomenys->VisiAutomobiliai() != nullptr && this->_duomenys->VisiAutomobiliai()->ElementuKiekis() == 0))
		{
			String^ pranesimas = "";
			if (!this->_duomenys->Nuskaityti_Automobilius(pranesimas))
			{
				MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
			}
		}

		this->comboBox_Automobiliai->DataSource = this->_duomenys->VisiAutomobiliai()->Duok_Sarasa();
		this->comboBox_Automobiliai->ValueMember = "ValNr";
		this->comboBox_Automobiliai->DisplayMember = "ValNr";

	}


	};
}
