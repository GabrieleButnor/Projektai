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
	/// Summary for Forma_KelioniuLentele
	/// </summary>
	public ref class Forma_KelioniuLentele : public System::Windows::Forms::Form
	{
	public:
		Forma_KelioniuLentele(Duomenys^ arg_duomenys)
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
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column3;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column4;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column5;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column6;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column7;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^  Column8;

	public:








	public:








	public:








	public:







	public:







	public:







	public:






	private: Duomenys^ _duomenys;

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Forma_KelioniuLentele()
		{
			if (components)
			{
				delete components;
			}
			this->_duomenys = nullptr;
		}
	private: System::Windows::Forms::DataGridView^  dataGridView_Keliones;
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
			System::Windows::Forms::DataGridViewCellStyle^  dataGridViewCellStyle4 = (gcnew System::Windows::Forms::DataGridViewCellStyle());
			System::Windows::Forms::DataGridViewCellStyle^  dataGridViewCellStyle5 = (gcnew System::Windows::Forms::DataGridViewCellStyle());
			System::Windows::Forms::DataGridViewCellStyle^  dataGridViewCellStyle6 = (gcnew System::Windows::Forms::DataGridViewCellStyle());
			this->dataGridView_Keliones = (gcnew System::Windows::Forms::DataGridView());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->Column1 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column2 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column3 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column4 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column5 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column6 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column7 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column8 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView_Keliones))->BeginInit();
			this->SuspendLayout();
			// 
			// dataGridView_Keliones
			// 
			this->dataGridView_Keliones->AllowUserToAddRows = false;
			this->dataGridView_Keliones->AllowUserToDeleteRows = false;
			this->dataGridView_Keliones->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->dataGridView_Keliones->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridView_Keliones->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(8) {
				this->Column1,
					this->Column2, this->Column3, this->Column4, this->Column5, this->Column6, this->Column7, this->Column8
			});
			this->dataGridView_Keliones->EditMode = System::Windows::Forms::DataGridViewEditMode::EditProgrammatically;
			this->dataGridView_Keliones->Location = System::Drawing::Point(8, 8);
			this->dataGridView_Keliones->Margin = System::Windows::Forms::Padding(2);
			this->dataGridView_Keliones->MultiSelect = false;
			this->dataGridView_Keliones->Name = L"dataGridView_Keliones";
			this->dataGridView_Keliones->ReadOnly = true;
			this->dataGridView_Keliones->RowTemplate->Height = 28;
			this->dataGridView_Keliones->SelectionMode = System::Windows::Forms::DataGridViewSelectionMode::FullRowSelect;
			this->dataGridView_Keliones->Size = System::Drawing::Size(758, 194);
			this->dataGridView_Keliones->TabIndex = 0;
			// 
			// button1
			// 
			this->button1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(678, 226);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(88, 36);
			this->button1->TabIndex = 1;
			this->button1->Text = L"Atgal";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_KelioniuLentele::button1_Click);
			// 
			// Column1
			// 
			this->Column1->DataPropertyName = L"ValNr";
			this->Column1->HeaderText = L"Valstybinis numeris";
			this->Column1->Name = L"Column1";
			this->Column1->ReadOnly = true;
			// 
			// Column2
			// 
			this->Column2->DataPropertyName = L"Data";
			dataGridViewCellStyle4->Format = L"g";
			dataGridViewCellStyle4->NullValue = nullptr;
			this->Column2->DefaultCellStyle = dataGridViewCellStyle4;
			this->Column2->HeaderText = L"Data";
			this->Column2->Name = L"Column2";
			this->Column2->ReadOnly = true;
			// 
			// Column3
			// 
			this->Column3->DataPropertyName = L"Is_Salies_Kodas";
			this->Column3->HeaderText = L"Iðvykimo ðalis";
			this->Column3->Name = L"Column3";
			this->Column3->ReadOnly = true;
			// 
			// Column4
			// 
			this->Column4->DataPropertyName = L"Is_Miesto";
			this->Column4->HeaderText = L"Iðvykimo miestas";
			this->Column4->Name = L"Column4";
			this->Column4->ReadOnly = true;
			// 
			// Column5
			// 
			this->Column5->DataPropertyName = L"I_Salies_Kodas";
			this->Column5->HeaderText = L"Atvykimo ðalis";
			this->Column5->Name = L"Column5";
			this->Column5->ReadOnly = true;
			// 
			// Column6
			// 
			this->Column6->DataPropertyName = L"I_Miesta";
			this->Column6->HeaderText = L"Atvykimo miestas";
			this->Column6->Name = L"Column6";
			this->Column6->ReadOnly = true;
			// 
			// Column7
			// 
			this->Column7->DataPropertyName = L"Atstumas";
			dataGridViewCellStyle5->Format = L"N2";
			dataGridViewCellStyle5->NullValue = nullptr;
			this->Column7->DefaultCellStyle = dataGridViewCellStyle5;
			this->Column7->HeaderText = L"Nuvaþiuotas kilometraþas";
			this->Column7->Name = L"Column7";
			this->Column7->ReadOnly = true;
			// 
			// Column8
			// 
			this->Column8->DataPropertyName = L"Kuro_Sanaudos";
			dataGridViewCellStyle6->Format = L"N2";
			dataGridViewCellStyle6->NullValue = nullptr;
			this->Column8->DefaultCellStyle = dataGridViewCellStyle6;
			this->Column8->HeaderText = L"Kuro sanaudos";
			this->Column8->Name = L"Column8";
			this->Column8->ReadOnly = true;
			// 
			// Forma_KelioniuLentele
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(803, 270);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->dataGridView_Keliones);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_KelioniuLentele";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Duomenu lentelë";
			this->Load += gcnew System::EventHandler(this, &Forma_KelioniuLentele::Forma_KelioniuLentele_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView_Keliones))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->Close();
			 }
private: System::Void Forma_KelioniuLentele_Load(System::Object^  sender, System::EventArgs^  e) {
	if (this->_duomenys->VisosKeliones() == nullptr || (this->_duomenys->VisosKeliones() != nullptr && this->_duomenys->VisosKeliones()->ElementuKiekis() == 0))
	{
		String^ pranesimas = "";
		if (!this->_duomenys->Nuskaityti_Keliones(pranesimas))
		{
			MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
	}
	this->dataGridView_Keliones->DataSource = nullptr;
	this->dataGridView_Keliones->DataSource = this->_duomenys->VisosKeliones()->Duok_Sarasa();

}
};
}
