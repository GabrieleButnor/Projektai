#pragma once
#include <string> 
#include "Forma_Parinktys.h"
#include "Forma_AutomobilisKelionei.h"

#include "Prisijungimas.h"


namespace Darbas {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Forma_Registracija
	/// </summary>
	public ref class Forma_Registracija : public System::Windows::Forms::Form
	{
	public:
		Forma_Registracija(Prisijungimas^ arg_prisijungimas)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
			this->DialogResult = System::Windows::Forms::DialogResult::None;

			_prisijungimas = arg_prisijungimas;
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Forma_Registracija()
		{
			if (components)
			{
				delete components;
			}
		}

	private: Prisijungimas^ _prisijungimas;

	private: System::Windows::Forms::Label^  label1;
	protected:
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::TextBox^  textBox_Vardas;
	protected: System::Windows::Forms::TextBox^  textBox_Slaptas;
	private: System::Windows::Forms::Button^  button_Prisijungti;
	protected:
	private:


	private:


	private: System::Windows::Forms::GroupBox^  groupBox1;

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
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->textBox_Vardas = (gcnew System::Windows::Forms::TextBox());
			this->textBox_Slaptas = (gcnew System::Windows::Forms::TextBox());
			this->button_Prisijungti = (gcnew System::Windows::Forms::Button());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->groupBox1->SuspendLayout();
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label1->Location = System::Drawing::Point(30, 36);
			this->label1->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(57, 17);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Vardas:";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label2->Location = System::Drawing::Point(4, 77);
			this->label2->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(85, 17);
			this->label2->TabIndex = 1;
			this->label2->Text = L"Slaptaþodis:";
			// 
			// textBox_Vardas
			// 
			this->textBox_Vardas->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->textBox_Vardas->Location = System::Drawing::Point(101, 34);
			this->textBox_Vardas->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Vardas->Multiline = true;
			this->textBox_Vardas->Name = L"textBox_Vardas";
			this->textBox_Vardas->Size = System::Drawing::Size(167, 27);
			this->textBox_Vardas->TabIndex = 2;
			this->textBox_Vardas->Text = L"Gabriele";
			// 
			// textBox_Slaptas
			// 
			this->textBox_Slaptas->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->textBox_Slaptas->Location = System::Drawing::Point(101, 73);
			this->textBox_Slaptas->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Slaptas->Multiline = true;
			this->textBox_Slaptas->Name = L"textBox_Slaptas";
			this->textBox_Slaptas->PasswordChar = '*';
			this->textBox_Slaptas->Size = System::Drawing::Size(167, 26);
			this->textBox_Slaptas->TabIndex = 3;
			// 
			// button_Prisijungti
			// 
			this->button_Prisijungti->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button_Prisijungti->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button_Prisijungti->Location = System::Drawing::Point(123, 167);
			this->button_Prisijungti->Margin = System::Windows::Forms::Padding(2);
			this->button_Prisijungti->Name = L"button_Prisijungti";
			this->button_Prisijungti->Size = System::Drawing::Size(101, 35);
			this->button_Prisijungti->TabIndex = 4;
			this->button_Prisijungti->Text = L"Prisijungti";
			this->button_Prisijungti->UseVisualStyleBackColor = false;
			this->button_Prisijungti->Click += gcnew System::EventHandler(this, &Forma_Registracija::button_Prisijungti_Click);
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->label1);
			this->groupBox1->Controls->Add(this->textBox_Vardas);
			this->groupBox1->Controls->Add(this->textBox_Slaptas);
			this->groupBox1->Controls->Add(this->label2);
			this->groupBox1->Location = System::Drawing::Point(17, 25);
			this->groupBox1->Margin = System::Windows::Forms::Padding(2);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Padding = System::Windows::Forms::Padding(2);
			this->groupBox1->Size = System::Drawing::Size(311, 129);
			this->groupBox1->TabIndex = 5;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Prisijungimas";
			// 
			// Forma_Registracija
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(348, 234);
			this->Controls->Add(this->groupBox1);
			this->Controls->Add(this->button_Prisijungti);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_Registracija";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Registracija";
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->ResumeLayout(false);

		}
#pragma endregion
	
	


	//prisijungimo duomenys
	private: System::Void button_Prisijungti_Click(System::Object^  sender, System::EventArgs^  e) {
		String^ pranesimas = "";
		if (!this->_prisijungimas->Prisijungti(textBox_Vardas->Text, textBox_Slaptas->Text, pranesimas))
		{
			MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
		else
		{
			textBox_Slaptas->Text = "";
			this->DialogResult = System::Windows::Forms::DialogResult::OK;
			this->Hide();
			this->Close();

		}

	}

	};
}
