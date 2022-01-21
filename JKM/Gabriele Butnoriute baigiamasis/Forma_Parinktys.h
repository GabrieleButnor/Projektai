#pragma once
#include "Forma_KelioniuLentele.h"
#include "Forma_Automobiliai.h"
#include "Forma_AtrankosFiltras.h"
#include "Duomenys.h"
#include "Prisijungimas.h"
namespace Darbas {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Forma_Parinktys
	/// </summary>
	public ref class Forma_Parinktys : public System::Windows::Forms::Form
	{
	public:
		Forma_Parinktys(Prisijungimas^ arg_prisijungimas, Duomenys^ arg_duomenys)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
			this->_duomenys = arg_duomenys;
			this->_prisijungimas = arg_prisijungimas;
		}

	private: Duomenys^ _duomenys;
	private: Prisijungimas^ _prisijungimas;

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Forma_Parinktys()
		{
			if (components)
			{
				delete components;
			}
			this->_duomenys = nullptr;
			this->_prisijungimas = nullptr;
		}
	private: System::Windows::Forms::Button^  button1;
	protected: 
	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::Button^  button3;
	private: System::Windows::Forms::Button^  button4;

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
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(55, 43);
			this->button1->Margin = System::Windows::Forms::Padding(2, 2, 2, 2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(124, 51);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Kelioniø duomenys";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_Parinktys::button1_Click);
			// 
			// button2
			// 
			this->button2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button2->Location = System::Drawing::Point(55, 133);
			this->button2->Margin = System::Windows::Forms::Padding(2, 2, 2, 2);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(124, 67);
			this->button2->TabIndex = 1;
			this->button2->Text = L"Automobiliø duomenys";
			this->button2->UseVisualStyleBackColor = false;
			this->button2->Click += gcnew System::EventHandler(this, &Forma_Parinktys::button2_Click);
			// 
			// button3
			// 
			this->button3->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->button3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button3->Location = System::Drawing::Point(250, 43);
			this->button3->Margin = System::Windows::Forms::Padding(2, 2, 2, 2);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(124, 51);
			this->button3->TabIndex = 2;
			this->button3->Text = L"Ataskaitos";
			this->button3->UseVisualStyleBackColor = false;
			this->button3->Click += gcnew System::EventHandler(this, &Forma_Parinktys::button3_Click);
			// 
			// button4
			// 
			this->button4->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button4->Location = System::Drawing::Point(250, 141);
			this->button4->Margin = System::Windows::Forms::Padding(2, 2, 2, 2);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(124, 52);
			this->button4->TabIndex = 3;
			this->button4->Text = L"Atsijungti";
			this->button4->UseVisualStyleBackColor = false;
			this->button4->Click += gcnew System::EventHandler(this, &Forma_Parinktys::button4_Click);
			// 
			// Forma_Parinktys
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->AutoSize = true;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(431, 232);
			this->Controls->Add(this->button4);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Margin = System::Windows::Forms::Padding(2, 2, 2, 2);
			this->Name = L"Forma_Parinktys";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Parinktys";
			this->ResumeLayout(false);

		}
#pragma endregion
		//grizimoi registracijos langa
	private: System::Void button4_Click(System::Object^  sender, System::EventArgs^  e) {
		if (this->_prisijungimas->ArPrisijunges()) {
			this->_prisijungimas->Atsijungti();
		}
		this->Close();
	}
		 //duomenu parodymas apie keliones duomenis langas
private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->Hide();
			 Forma_KelioniuLentele^ f7 = gcnew Forma_KelioniuLentele(this->_duomenys);
			 f7-> ShowDialog();
			 delete f7;
			 this->Show();
		 }
		 //automobiliu duomenu rodumo forma
private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->Hide();
			 Forma_Automobiliai^ f8 = gcnew Forma_Automobiliai(this->_duomenys);
			 f8-> ShowDialog();
			 delete f8;
			 this->Show();
		 }
private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->Hide();
			 Forma_AtrankosFiltras^ f11 = gcnew Forma_AtrankosFiltras(this->_duomenys);
			 f11-> ShowDialog();
			 delete f11;
			 this->Show();
		 }
};
}
