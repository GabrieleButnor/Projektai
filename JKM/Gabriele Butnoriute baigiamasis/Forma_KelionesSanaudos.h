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
	/// Summary for Forma_KelionesSanaudos
	/// </summary>
	public ref class Forma_KelionesSanaudos : public System::Windows::Forms::Form
	{
	public:
		Forma_KelionesSanaudos(double arg_sanaudos)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//

			this->textBox_Sanaudos->Text = arg_sanaudos.ToString("#,###0.00");
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Forma_KelionesSanaudos()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  button1;
	protected:
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::TextBox^  textBox_Sanaudos;


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
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->textBox_Sanaudos = (gcnew System::Windows::Forms::TextBox());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(229, 181);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(89, 43);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Gerai";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_KelionesSanaudos::button1_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label1->Location = System::Drawing::Point(87, 44);
			this->label1->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(158, 17);
			this->label1->TabIndex = 1;
			this->label1->Text = L"Duomenys i�saugoti ";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->label2->Location = System::Drawing::Point(35, 101);
			this->label2->Margin = System::Windows::Forms::Padding(2, 0, 2, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(164, 17);
			this->label2->TabIndex = 2;
			this->label2->Text = L"Kelion�s kuro s�naudos:";
			// 
			// textBox_Sanaudos
			// 
			this->textBox_Sanaudos->Location = System::Drawing::Point(207, 92);
			this->textBox_Sanaudos->Margin = System::Windows::Forms::Padding(2);
			this->textBox_Sanaudos->Multiline = true;
			this->textBox_Sanaudos->Name = L"textBox_Sanaudos";
			this->textBox_Sanaudos->ReadOnly = true;
			this->textBox_Sanaudos->Size = System::Drawing::Size(90, 38);
			this->textBox_Sanaudos->TabIndex = 3;
			// 
			// Forma_KelionesSanaudos
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(327, 231);
			this->Controls->Add(this->textBox_Sanaudos);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->button1);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_KelionesSanaudos";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Sanaudos";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
		this->Close();
	}
	};
}
