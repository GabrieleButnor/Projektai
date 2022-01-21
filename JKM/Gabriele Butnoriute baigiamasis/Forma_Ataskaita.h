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
	/// Summary for Forma_Ataskaita
	/// </summary>
	public ref class Forma_Ataskaita : public System::Windows::Forms::Form
	{
	public:
		Forma_Ataskaita(Duomenys^ arg_duomenys)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
			this->_duomenys = arg_duomenys;
		}
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column1;
	public:
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column2;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column7;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column8;

	public:




	public:




	public:




	private: Duomenys^ _duomenys;

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Forma_Ataskaita()
		{
			if (components)
			{
				delete components;
			}
			this->_duomenys = nullptr;
		}
	private: System::Windows::Forms::DataGridView^  dataGridView_Ataskaita;
	protected:

	protected:








	private: System::Windows::Forms::Button^  button1;













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
			System::Windows::Forms::DataGridViewCellStyle^  dataGridViewCellStyle1 = (gcnew System::Windows::Forms::DataGridViewCellStyle());
			System::Windows::Forms::DataGridViewCellStyle^  dataGridViewCellStyle2 = (gcnew System::Windows::Forms::DataGridViewCellStyle());
			this->dataGridView_Ataskaita = (gcnew System::Windows::Forms::DataGridView());
			this->Column1 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column2 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column7 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column8 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->button1 = (gcnew System::Windows::Forms::Button());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView_Ataskaita))->BeginInit();
			this->SuspendLayout();
			// 
			// dataGridView_Ataskaita
			// 
			this->dataGridView_Ataskaita->AllowUserToAddRows = false;
			this->dataGridView_Ataskaita->AllowUserToDeleteRows = false;
			this->dataGridView_Ataskaita->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->dataGridView_Ataskaita->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridView_Ataskaita->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(4) {
				this->Column1,
					this->Column2, this->Column7, this->Column8
			});
			this->dataGridView_Ataskaita->Location = System::Drawing::Point(8, 8);
			this->dataGridView_Ataskaita->Margin = System::Windows::Forms::Padding(2);
			this->dataGridView_Ataskaita->MultiSelect = false;
			this->dataGridView_Ataskaita->Name = L"dataGridView_Ataskaita";
			this->dataGridView_Ataskaita->ReadOnly = true;
			this->dataGridView_Ataskaita->RowTemplate->Height = 28;
			this->dataGridView_Ataskaita->SelectionMode = System::Windows::Forms::DataGridViewSelectionMode::FullRowSelect;
			this->dataGridView_Ataskaita->ShowEditingIcon = false;
			this->dataGridView_Ataskaita->Size = System::Drawing::Size(571, 238);
			this->dataGridView_Ataskaita->TabIndex = 0;
			// 
			// Column1
			// 
			this->Column1->DataPropertyName = L"ValstybinisNumeris";
			this->Column1->Frozen = true;
			this->Column1->HeaderText = L"Valstybinis numeris ";
			this->Column1->Name = L"Column1";
			this->Column1->ReadOnly = true;
			// 
			// Column2
			// 
			this->Column2->DataPropertyName = L"KuroRusis";
			this->Column2->Frozen = true;
			this->Column2->HeaderText = L"Kuro rûðis";
			this->Column2->Name = L"Column2";
			this->Column2->ReadOnly = true;
			// 
			// Column7
			// 
			this->Column7->DataPropertyName = L"Visos_Kuro_Sanaudos";
			dataGridViewCellStyle1->Format = L"N2";
			dataGridViewCellStyle1->NullValue = nullptr;
			this->Column7->DefaultCellStyle = dataGridViewCellStyle1;
			this->Column7->Frozen = true;
			this->Column7->HeaderText = L"Visos kuro sànaudos";
			this->Column7->Name = L"Column7";
			this->Column7->ReadOnly = true;
			// 
			// Column8
			// 
			this->Column8->DataPropertyName = L"Tarsos_Koeficentas";
			dataGridViewCellStyle2->Format = L"N2";
			dataGridViewCellStyle2->NullValue = nullptr;
			this->Column8->DefaultCellStyle = dataGridViewCellStyle2;
			this->Column8->Frozen = true;
			this->Column8->HeaderText = L"Tarðos koficientas";
			this->Column8->Name = L"Column8";
			this->Column8->ReadOnly = true;
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(481, 250);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(98, 45);
			this->button1->TabIndex = 1;
			this->button1->Text = L"Atgal";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_Ataskaita::button1_Click);
			// 
			// Forma_Ataskaita
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(653, 311);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->dataGridView_Ataskaita);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_Ataskaita";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Ataskaita";
			this->Load += gcnew System::EventHandler(this, &Forma_Ataskaita::Forma_Ataskaita_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView_Ataskaita))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
		this->Close();
	}
	private: System::Void Forma_Ataskaita_Load(System::Object^  sender, System::EventArgs^  e) {

		if (this->_duomenys->VisaAtaskaita() == nullptr || (this->_duomenys->VisaAtaskaita() != nullptr && this->_duomenys->VisaAtaskaita()->ElementuKiekis() == 0))
		{
			String^ pranesimas = "";
			if (!this->_duomenys->Nuskaityti_Ataskaita(pranesimas))
			{
				MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
			}
		}
		this->dataGridView_Ataskaita->DataSource = nullptr;
		this->dataGridView_Ataskaita->DataSource = this->_duomenys->VisaAtaskaita()->Duok_Sarasa();

	}
	};
}
