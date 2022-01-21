#pragma once
#include "Forma_KelionesSanaudos.h"
#include "Duomenys.h"
namespace Darbas {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Forma_NaujaKelione
	/// </summary>
	public ref class Forma_NaujaKelione : public System::Windows::Forms::Form
	{
	public:
		Forma_NaujaKelione(Duomenys^ arg_duomenys)
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
		~Forma_NaujaKelione()
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
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::Label^  label7;
	private: System::Windows::Forms::TextBox^  textBox_Data;
	private: System::Windows::Forms::TextBox^  textBox_Miestas_Is;
	private: System::Windows::Forms::TextBox^  textBox_Salis_I;
	private: System::Windows::Forms::TextBox^  textBox_Miestas_I;
	private: System::Windows::Forms::TextBox^  textBox_Km;





	private: System::Windows::Forms::TextBox^  textBox_Salis_Is;

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
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->textBox_Data = (gcnew System::Windows::Forms::TextBox());
			this->textBox_Miestas_Is = (gcnew System::Windows::Forms::TextBox());
			this->textBox_Salis_I = (gcnew System::Windows::Forms::TextBox());
			this->textBox_Miestas_I = (gcnew System::Windows::Forms::TextBox());
			this->textBox_Km = (gcnew System::Windows::Forms::TextBox());
			this->textBox_Salis_Is = (gcnew System::Windows::Forms::TextBox());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label1->Location = System::Drawing::Point(17, 23);
			this->label1->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(200, 17);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Kelionës informacijos ávedimas";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label2->Location = System::Drawing::Point(147, 57);
			this->label2->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(42, 17);
			this->label2->TabIndex = 1;
			this->label2->Text = L"Data:";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label3->Location = System::Drawing::Point(95, 97);
			this->label3->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(97, 17);
			this->label3->TabIndex = 2;
			this->label3->Text = L"Iðvykimo ðalis:";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label4->Location = System::Drawing::Point(76, 146);
			this->label4->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(117, 17);
			this->label4->TabIndex = 3;
			this->label4->Text = L"iðvykimo miestas:";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label5->Location = System::Drawing::Point(95, 192);
			this->label5->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(96, 17);
			this->label5->TabIndex = 4;
			this->label5->Text = L"Atvykimo ðalis";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label6->Location = System::Drawing::Point(77, 235);
			this->label6->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(116, 17);
			this->label6->TabIndex = 5;
			this->label6->Text = L"Atvikimo miestas:";
			// 
			// label7
			// 
			this->label7->AutoSize = true;
			this->label7->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label7->Location = System::Drawing::Point(55, 277);
			this->label7->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(142, 17);
			this->label7->TabIndex = 6;
			this->label7->Text = L"Nuvaþiuoti kilometrai:";
			// 
			// textBox_Data
			// 
			this->textBox_Data->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->textBox_Data->Location = System::Drawing::Point(215, 45);
			this->textBox_Data->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Data->Multiline = true;
			this->textBox_Data->Name = L"textBox_Data";
			this->textBox_Data->Size = System::Drawing::Size(125, 29);
			this->textBox_Data->TabIndex = 7;
			// 
			// textBox_Miestas_Is
			// 
			this->textBox_Miestas_Is->Location = System::Drawing::Point(215, 135);
			this->textBox_Miestas_Is->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Miestas_Is->Multiline = true;
			this->textBox_Miestas_Is->Name = L"textBox_Miestas_Is";
			this->textBox_Miestas_Is->Size = System::Drawing::Size(125, 29);
			this->textBox_Miestas_Is->TabIndex = 9;
			// 
			// textBox_Salis_I
			// 
			this->textBox_Salis_I->Location = System::Drawing::Point(215, 182);
			this->textBox_Salis_I->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Salis_I->Multiline = true;
			this->textBox_Salis_I->Name = L"textBox_Salis_I";
			this->textBox_Salis_I->Size = System::Drawing::Size(125, 27);
			this->textBox_Salis_I->TabIndex = 10;
			// 
			// textBox_Miestas_I
			// 
			this->textBox_Miestas_I->Location = System::Drawing::Point(215, 226);
			this->textBox_Miestas_I->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Miestas_I->Multiline = true;
			this->textBox_Miestas_I->Name = L"textBox_Miestas_I";
			this->textBox_Miestas_I->Size = System::Drawing::Size(125, 26);
			this->textBox_Miestas_I->TabIndex = 11;
			// 
			// textBox_Km
			// 
			this->textBox_Km->Location = System::Drawing::Point(215, 266);
			this->textBox_Km->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Km->Multiline = true;
			this->textBox_Km->Name = L"textBox_Km";
			this->textBox_Km->Size = System::Drawing::Size(125, 28);
			this->textBox_Km->TabIndex = 12;
			// 
			// textBox_Salis_Is
			// 
			this->textBox_Salis_Is->Location = System::Drawing::Point(215, 90);
			this->textBox_Salis_Is->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Salis_Is->Multiline = true;
			this->textBox_Salis_Is->Name = L"textBox_Salis_Is";
			this->textBox_Salis_Is->Size = System::Drawing::Size(125, 32);
			this->textBox_Salis_Is->TabIndex = 8;
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(150, 323);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(111, 40);
			this->button1->TabIndex = 13;
			this->button1->Text = L"Iðsaugoti";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_NaujaKelione::button1_Click);
			// 
			// button2
			// 
			this->button2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button2->Location = System::Drawing::Point(350, 338);
			this->button2->Margin = System::Windows::Forms::Padding(2);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(66, 25);
			this->button2->TabIndex = 14;
			this->button2->Text = L"Atgal";
			this->button2->UseVisualStyleBackColor = false;
			this->button2->Click += gcnew System::EventHandler(this, &Forma_NaujaKelione::button2_Click);
			// 
			// Forma_NaujaKelione
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(424, 377);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->textBox_Km);
			this->Controls->Add(this->textBox_Miestas_I);
			this->Controls->Add(this->textBox_Salis_I);
			this->Controls->Add(this->textBox_Miestas_Is);
			this->Controls->Add(this->textBox_Salis_Is);
			this->Controls->Add(this->textBox_Data);
			this->Controls->Add(this->label7);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_NaujaKelione";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Lapas";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
		this->Close();
	}
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
		String^ pranesimas = "";
		if (this->_duomenys->VisosSalys() == nullptr || (this->_duomenys->VisosSalys() != nullptr && this->_duomenys->VisosSalys()->ElementuKiekis() == 0) && !this->_duomenys->Nuskaityti_Salis(pranesimas)) {

			MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}

		DateTime laikina_data;
		if (!DateTime::TryParse(this->textBox_Data->Text, laikina_data)) {
			MessageBox::Show("Neteisingai nurodyta data", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
		else if (this->textBox_Salis_Is->Text == "")
		{
			MessageBox::Show("Nenurodytas iðvykimo ðalies kodas", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
		else if (_duomenys->VisosSalys()->Rasti_PagalKoda(this->textBox_Salis_Is->Text) == nullptr)
		{
			MessageBox::Show("Nerasta iðvykimo ðalis pagal kodà", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
		else if (this->textBox_Salis_I->Text == "")
		{
			MessageBox::Show("Nenurodytas atvykimo ðalies kodas", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
		else if (_duomenys->VisosSalys()->Rasti_PagalKoda(this->textBox_Salis_I->Text) == nullptr)
		{
			MessageBox::Show("Nerasta atvykimo ðalis pagal kodà", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
		else {
			Automobilis^ automobilis = this->_duomenys->VisiAutomobiliai()->AktyvusAutomobilis();
			Salis^ salis_is = this->_duomenys->VisosSalys()->Rasti_PagalKoda(this->textBox_Salis_Is->Text);
			Salis^ salis_i = this->_duomenys->VisosSalys()->Rasti_PagalKoda(this->textBox_Salis_I->Text);

			double atstumas = 0;
			CultureInfo^ culture = CultureInfo::CurrentCulture;

			if (!double::TryParse(this->textBox_Km->Text->Replace(".", culture->NumberFormat->NumberDecimalSeparator), atstumas))
			{
				atstumas = 0;
			}

			Kelione^ naujaKelione = this->_duomenys->VisosKeliones()->Sukurti(automobilis, laikina_data, salis_is, this->textBox_Miestas_Is->Text, salis_i, this->textBox_Miestas_I->Text, atstumas, 0);
			if (naujaKelione != nullptr) {
				naujaKelione->SuskaiciuokSanaudas();
				double sanudos = naujaKelione->Kuro_Sanaudos;
				if (!this->_duomenys->Issaugok_Keliones(pranesimas)) {
					MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
				}
				else
				{
					this->_duomenys->VisosKeliones()->Valyti();
					if (!this->_duomenys->Nuskaityti_Keliones(pranesimas)) {
						MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
					}
					this->Hide();
					Forma_KelionesSanaudos^ f14 = gcnew Forma_KelionesSanaudos(sanudos);
					f14->ShowDialog();
					delete f14;
					Isvalom_Ivedimo_Laukus();
					this->Show();
				}
			}
			else
			{
				MessageBox::Show("Neþinoma klaida", "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
			}
		}


	}

			 private: System::Void Isvalom_Ivedimo_Laukus() {
				 this->textBox_Data->Text = "";
				 this->textBox_Salis_Is->Text = "";
				 this->textBox_Miestas_Is->Text = "";
				 this->textBox_Salis_I->Text = "";
				 this->textBox_Miestas_I->Text = "";
				 this->textBox_Km->Text = "";
				 
			 }



	};


}
