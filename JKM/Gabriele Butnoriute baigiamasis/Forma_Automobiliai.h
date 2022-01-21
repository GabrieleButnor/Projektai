#pragma once
#include "Forma_PridetiAutomobili.h"
#include "Forma_IstrintiAutomobili.h"
#include "Duomenys.h"


namespace Darbas {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;




	/// <summary>
	/// Summary for Forma_Automobiliai
	/// </summary>
	public ref class Forma_Automobiliai : public System::Windows::Forms::Form
	{
	public:
		Forma_Automobiliai(Duomenys^ arg_duomenys)
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

	public:






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
		~Forma_Automobiliai()
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
	private: System::Windows::Forms::Button^  button3;
	private: System::Windows::Forms::DataGridView^  dataGridView_Automobiliai;































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
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->dataGridView_Automobiliai = (gcnew System::Windows::Forms::DataGridView());
			this->Column1 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column2 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column3 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column4 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column5 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column6 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView_Automobiliai))->BeginInit();
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(529, 307);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(114, 36);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Atgal";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_Automobiliai::button1_Click);
			// 
			// button2
			// 
			this->button2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 25, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button2->Location = System::Drawing::Point(8, 298);
			this->button2->Margin = System::Windows::Forms::Padding(2);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(49, 44);
			this->button2->TabIndex = 1;
			this->button2->Text = L"+";
			this->button2->UseVisualStyleBackColor = false;
			this->button2->Click += gcnew System::EventHandler(this, &Forma_Automobiliai::button2_Click);
			// 
			// button3
			// 
			this->button3->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 25, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button3->Location = System::Drawing::Point(76, 298);
			this->button3->Margin = System::Windows::Forms::Padding(2);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(49, 44);
			this->button3->TabIndex = 2;
			this->button3->Text = L"-";
			this->button3->TextAlign = System::Drawing::ContentAlignment::TopCenter;
			this->button3->UseVisualStyleBackColor = false;
			this->button3->Click += gcnew System::EventHandler(this, &Forma_Automobiliai::button3_Click);
			// 
			// dataGridView_Automobiliai
			// 
			this->dataGridView_Automobiliai->AllowUserToAddRows = false;
			this->dataGridView_Automobiliai->AllowUserToDeleteRows = false;
			this->dataGridView_Automobiliai->AllowUserToOrderColumns = true;
			this->dataGridView_Automobiliai->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->dataGridView_Automobiliai->BackgroundColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(224)),
				static_cast<System::Int32>(static_cast<System::Byte>(224)), static_cast<System::Int32>(static_cast<System::Byte>(224)));
			this->dataGridView_Automobiliai->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->dataGridView_Automobiliai->CellBorderStyle = System::Windows::Forms::DataGridViewCellBorderStyle::Sunken;
			this->dataGridView_Automobiliai->ColumnHeadersBorderStyle = System::Windows::Forms::DataGridViewHeaderBorderStyle::Sunken;
			this->dataGridView_Automobiliai->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridView_Automobiliai->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(6) {
				this->Column1,
					this->Column2, this->Column3, this->Column4, this->Column5, this->Column6
			});
			this->dataGridView_Automobiliai->Location = System::Drawing::Point(8, 8);
			this->dataGridView_Automobiliai->Margin = System::Windows::Forms::Padding(2);
			this->dataGridView_Automobiliai->MultiSelect = false;
			this->dataGridView_Automobiliai->Name = L"dataGridView_Automobiliai";
			this->dataGridView_Automobiliai->ReadOnly = true;
			this->dataGridView_Automobiliai->RowTemplate->Height = 28;
			this->dataGridView_Automobiliai->Size = System::Drawing::Size(635, 286);
			this->dataGridView_Automobiliai->TabIndex = 3;
			// 
			// Column1
			// 
			this->Column1->DataPropertyName = L"ValNr";
			this->Column1->Frozen = true;
			this->Column1->HeaderText = L"Valstybinis numeris";
			this->Column1->Name = L"Column1";
			this->Column1->ReadOnly = true;
			// 
			// Column2
			// 
			this->Column2->DataPropertyName = L"Marke";
			this->Column2->Frozen = true;
			this->Column2->HeaderText = L"Automobilio markë";
			this->Column2->Name = L"Column2";
			this->Column2->ReadOnly = true;
			// 
			// Column3
			// 
			this->Column3->DataPropertyName = L"KuroRusiesPavad";
			this->Column3->Frozen = true;
			this->Column3->HeaderText = L"Kuro rûðis";
			this->Column3->Name = L"Column3";
			this->Column3->ReadOnly = true;
			// 
			// Column4
			// 
			this->Column4->DataPropertyName = L"Sanaudu_Norma_Vasara";
			dataGridViewCellStyle4->Format = L"N2";
			dataGridViewCellStyle4->NullValue = nullptr;
			this->Column4->DefaultCellStyle = dataGridViewCellStyle4;
			this->Column4->Frozen = true;
			this->Column4->HeaderText = L"Kuro norma vasara";
			this->Column4->Name = L"Column4";
			this->Column4->ReadOnly = true;
			// 
			// Column5
			// 
			this->Column5->DataPropertyName = L"Sanaudu_Norma_Ziema";
			dataGridViewCellStyle5->Format = L"N2";
			dataGridViewCellStyle5->NullValue = nullptr;
			this->Column5->DefaultCellStyle = dataGridViewCellStyle5;
			this->Column5->Frozen = true;
			this->Column5->HeaderText = L"Kuro norma þiema";
			this->Column5->Name = L"Column5";
			this->Column5->ReadOnly = true;
			// 
			// Column6
			// 
			this->Column6->DataPropertyName = L"Tarsos_Koeficentas";
			dataGridViewCellStyle6->Format = L"N2";
			dataGridViewCellStyle6->NullValue = nullptr;
			this->Column6->DefaultCellStyle = dataGridViewCellStyle6;
			this->Column6->Frozen = true;
			this->Column6->HeaderText = L"Tarðos koficientas";
			this->Column6->Name = L"Column6";
			this->Column6->ReadOnly = true;
			// 
			// Forma_Automobiliai
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(651, 350);
			this->Controls->Add(this->dataGridView_Automobiliai);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->button1);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_Automobiliai";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Automobiliø sàraðas";
			this->Load += gcnew System::EventHandler(this, &Forma_Automobiliai::Forma_Automobiliai_Load_1);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView_Automobiliai))->EndInit();
			this->ResumeLayout(false);

		}

	void MarshalString ( String ^ s, string& os ) 
	{  
		   using namespace Runtime::InteropServices;  
		   const char* chars =   
		  (const char*)(Marshal::StringToHGlobalAnsi(s)).ToPointer();  
		   os = chars;  
		    Marshal::FreeHGlobal(IntPtr((void*)chars));  
	 }  	


#pragma endregion
		
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->Close();
			 }


		 
private: System::Void Forma_Automobiliai_Load(System::Object^  sender, System::EventArgs^  e){
			 

		 }
private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->Hide();
			 Forma_PridetiAutomobili^ f9 = gcnew Forma_PridetiAutomobili(this->_duomenys);
			 f9-> ShowDialog();
			 delete f9;
			 this->dataGridView_Automobiliai->DataSource = nullptr;
			 this->dataGridView_Automobiliai->DataSource = this->_duomenys->VisiAutomobiliai()->Duok_Sarasa();
			 this->Show();
		 }
private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->Hide();
			 Forma_IstrintiAutomobili^ f10 = gcnew Forma_IstrintiAutomobili(this->_duomenys);
			 f10-> ShowDialog();
			 delete f10;
			 this->dataGridView_Automobiliai->DataSource = nullptr;
			 this->dataGridView_Automobiliai->DataSource = this->_duomenys->VisiAutomobiliai()->Duok_Sarasa();
			 this->Show();
		 }
	private: System::Void Forma_Automobiliai_Load_1(System::Object^  sender, System::EventArgs^  e) {
		if (this->_duomenys->VisiAutomobiliai() == nullptr || (this->_duomenys->VisiAutomobiliai() != nullptr && this->_duomenys->VisiAutomobiliai()->ElementuKiekis() == 0))
		{
			String^ pranesimas = "";
			if (!this->_duomenys->Nuskaityti_Automobilius(pranesimas))
			{
				MessageBox::Show(pranesimas, "Klaida", MessageBoxButtons::OK, MessageBoxIcon::Error);
			}
		}
		this->dataGridView_Automobiliai->DataSource = nullptr;
		this->dataGridView_Automobiliai->DataSource = this->_duomenys->VisiAutomobiliai()->Duok_Sarasa();

	}
};
}
