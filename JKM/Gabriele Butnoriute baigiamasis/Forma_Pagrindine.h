#pragma once
#include <string>
#include "Forma_Apie.h"
#include "Forma_Registracija.h"
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
	/// Summary for Forma_Pagrindine
	/// </summary>
	public ref class Forma_Pagrindine : public System::Windows::Forms::Form
	{
	public:
		Forma_Pagrindine(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
			_duomenys = gcnew Duomenys();
			_prisijungimas = gcnew Prisijungimas();
			_prisijungimas->Sukurk_Vartotojus();
			this->registracijos_forma = nullptr;
	        this->ArKlaustiUzdarant = true;
			
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Forma_Pagrindine()
		{
			if (components)
			{
				delete components;
			}
		}
	private: Duomenys^ _duomenys;
	private: Prisijungimas^ _prisijungimas;
	private: Forma_Registracija^ registracijos_forma;
	private: bool ArKlaustiUzdarant;



	private: System::Windows::Forms::Button^  button1;
	protected: 
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::PictureBox^  pictureBox1;

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
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Forma_Pagrindine::typeid));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(205, 158);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(174, 76);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Pradëti darbà";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_Pagrindine::button1_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 25, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)),
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(186)));
			this->label1->Location = System::Drawing::Point(81, 39);
			this->label1->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(470, 78);
			this->label1->TabIndex = 1;
			this->label1->Text = L"Kuro apskaita ir metinës \r\ntarðos duomenø paruoðimas";
			this->label1->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// button2
			// 
			this->button2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button2->ForeColor = System::Drawing::SystemColors::ControlText;
			this->button2->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"button2.Image")));
			this->button2->ImageAlign = System::Drawing::ContentAlignment::MiddleLeft;
			this->button2->Location = System::Drawing::Point(29, 270);
			this->button2->Margin = System::Windows::Forms::Padding(2);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(99, 34);
			this->button2->TabIndex = 2;
			this->button2->Text = L"     Informacija";
			this->button2->UseVisualStyleBackColor = false;
			this->button2->Click += gcnew System::EventHandler(this, &Forma_Pagrindine::button2_Click);
			// 
			// pictureBox1
			// 
			this->pictureBox1->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox1.Image")));
			this->pictureBox1->Location = System::Drawing::Point(429, 158);
			this->pictureBox1->Margin = System::Windows::Forms::Padding(2);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(213, 162);
			this->pictureBox1->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->pictureBox1->TabIndex = 3;
			this->pictureBox1->TabStop = false;
			// 
			// Forma_Pagrindine
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->AutoValidate = System::Windows::Forms::AutoValidate::EnablePreventFocusChange;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(651, 328);
			this->Controls->Add(this->pictureBox1);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->button1);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_Pagrindine";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Kuro apskaita";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &Forma_Pagrindine::Forma_Pagrindine_FormClosing);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
		//naujos formos atidarymas
		private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->Hide();
			 if (!this->_prisijungimas->ArPrisijunges()) {

				 if (this->registracijos_forma == nullptr) {
					 this->registracijos_forma = gcnew Forma_Registracija(_prisijungimas);
					 this->registracijos_forma->Closed += gcnew System::EventHandler(this, &Forma_Pagrindine::registracijos_pabaiga);
				 }
				 this->registracijos_forma->ShowDialog();
			 }
			 else
			 {
				 Rodyk_LangaPagal_Vartotoja();
			 }
		 }

	     private: System::Void registracijos_pabaiga(System::Object^  sender, System::EventArgs^  e) {
			 if (this->registracijos_forma->DialogResult == System::Windows::Forms::DialogResult::OK && this->_prisijungimas->ArPrisijunges()) {

				 Rodyk_LangaPagal_Vartotoja();

			 }
			 else
			 {
				 this->Show();
			 }
	     }

	private: System::Void Rodyk_LangaPagal_Vartotoja() {
		if (this->_prisijungimas->PrisijungesKaip()->ArAdministratorius())
		{
			Forma_Parinktys^ f4 = gcnew Forma_Parinktys(this->_prisijungimas, this->_duomenys);
			f4->ShowDialog();
			delete f4;
			this->Show();
		}
		else
		{
			Forma_AutomobilisKelionei^ f5 = gcnew Forma_AutomobilisKelionei(_duomenys);
			f5->ShowDialog();
			delete f5;
			this->_prisijungimas->Atsijungti();
			this->Show();
		}

	}


		//informacijos lango atidarymas
	private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->Hide();
				 Forma_Apie^ forma_apie = gcnew Forma_Apie();
				 forma_apie->ShowDialog();
				 delete forma_apie;
				 this->Show();
			 }

	private: System::Void Forma_Pagrindine_FormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e) {
		if (ArKlaustiUzdarant && MessageBox::Show("Ar tikrai norite iðeiti?", "Iðeiti", MessageBoxButtons::YesNo, MessageBoxIcon::Question) == System::Windows::Forms::DialogResult::Yes)
		{
			this->ArKlaustiUzdarant = false;
			Application::Exit();
		}
		else {
			this->ArKlaustiUzdarant = true;
			e->Cancel = true;
		}
	}

};



}
