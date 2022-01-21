#pragma once
#include "Forma_Ataskaita.h"
#include "Duomenys.h"
namespace Darbas {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Forma_AtrankosFiltras
	/// </summary>
	public ref class Forma_AtrankosFiltras : public System::Windows::Forms::Form
	{
	public:
		Forma_AtrankosFiltras(Duomenys^ arg_duomenys)
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
		~Forma_AtrankosFiltras()
		{
			if (components)
			{
				delete components;
			}
			this->_duomenys = nullptr;
		}
	private: System::Windows::Forms::Label^  label1;
	protected: 
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::TextBox^  textBox_DataNuo;
	private: System::Windows::Forms::TextBox^  textBox_DataIki;


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
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->textBox_DataNuo = (gcnew System::Windows::Forms::TextBox());
			this->textBox_DataIki = (gcnew System::Windows::Forms::TextBox());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label1->Location = System::Drawing::Point(19, 16);
			this->label1->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(124, 17);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Áveskite laikotarpá :";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label2->Location = System::Drawing::Point(89, 49);
			this->label2->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(42, 17);
			this->label2->TabIndex = 1;
			this->label2->Text = L"Nuo:";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label3->Location = System::Drawing::Point(102, 86);
			this->label3->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(29, 17);
			this->label3->TabIndex = 2;
			this->label3->Text = L"Iki:";
			// 
			// textBox_DataNuo
			// 
			this->textBox_DataNuo->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->textBox_DataNuo->Location = System::Drawing::Point(132, 49);
			this->textBox_DataNuo->Margin = System::Windows::Forms::Padding(2);
			this->textBox_DataNuo->Multiline = true;
			this->textBox_DataNuo->Name = L"textBox_DataNuo";
			this->textBox_DataNuo->Size = System::Drawing::Size(111, 25);
			this->textBox_DataNuo->TabIndex = 3;
			// 
			// textBox_DataIki
			// 
			this->textBox_DataIki->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->textBox_DataIki->Location = System::Drawing::Point(132, 86);
			this->textBox_DataIki->Margin = System::Windows::Forms::Padding(2);
			this->textBox_DataIki->Multiline = true;
			this->textBox_DataIki->Name = L"textBox_DataIki";
			this->textBox_DataIki->Size = System::Drawing::Size(111, 25);
			this->textBox_DataIki->TabIndex = 4;
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(141, 145);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(73, 39);
			this->button1->TabIndex = 5;
			this->button1->Text = L"Rodyti";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_AtrankosFiltras::button1_Click);
			// 
			// button2
			// 
			this->button2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button2->Location = System::Drawing::Point(275, 200);
			this->button2->Margin = System::Windows::Forms::Padding(2);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(62, 39);
			this->button2->TabIndex = 6;
			this->button2->Text = L"Atgal";
			this->button2->UseVisualStyleBackColor = false;
			this->button2->Click += gcnew System::EventHandler(this, &Forma_AtrankosFiltras::button2_Click);
			// 
			// Forma_AtrankosFiltras
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(345, 247);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->textBox_DataIki);
			this->Controls->Add(this->textBox_DataNuo);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_AtrankosFiltras";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Ataskaitos atranka";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->Close();
			 }
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

		DateTime laikina_data_nuo;
		DateTime laikina_data_iki;
		if (!DateTime::TryParse(this->textBox_DataNuo->Text, laikina_data_nuo)) {
			MessageBox::Show("Neteisingai nurodyta data nuo", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
		else if (!DateTime::TryParse(this->textBox_DataIki->Text, laikina_data_iki)) {
			MessageBox::Show("Neteisingai nurodyta data iki", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
		else {

			if (this->_duomenys->VisaAtaskaita()->Atrinkti(laikina_data_nuo, laikina_data_iki)) {
				String^ pranesimas = "";
				if (!this->_duomenys->Issaugok_Ataskaita(pranesimas))
				{
					MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
                }

				this->Hide();
				Forma_Ataskaita^ f12 = gcnew Forma_Ataskaita(this->_duomenys);
				f12->ShowDialog();
				delete f12;
				this->Show();
			}
			else MessageBox::Show("Pagal pasirinktas datas duomenø nëra", "Informacija", MessageBoxButtons::OK, MessageBoxIcon::Information);

		}
	}
};
}
