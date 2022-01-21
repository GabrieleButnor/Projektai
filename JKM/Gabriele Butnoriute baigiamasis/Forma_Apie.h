#pragma once

namespace Darbas {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Forma_Apie
	/// </summary>
	public ref class Forma_Apie : public System::Windows::Forms::Form
	{
	public:
		Forma_Apie(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Forma_Apie()
		{
			if (components)
			{
				delete components;
			}
		}

	private: System::Windows::Forms::Button^  button1;
	protected: 

	protected: 

	protected: 

	protected: 


	protected: 

	protected: 

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
			System::Windows::Forms::TextBox^  textBox1;
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Forma_Apie::typeid));
			this->button1 = (gcnew System::Windows::Forms::Button());
			textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->SuspendLayout();
			// 
			// textBox1
			// 
			textBox1->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			textBox1->BorderStyle = System::Windows::Forms::BorderStyle::None;
			textBox1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			textBox1->Location = System::Drawing::Point(8, 8);
			textBox1->Margin = System::Windows::Forms::Padding(2);
			textBox1->Multiline = true;
			textBox1->Name = L"textBox1";
			textBox1->ReadOnly = true;
			textBox1->Size = System::Drawing::Size(488, 180);
			textBox1->TabIndex = 0;
			textBox1->TabStop = false;
			textBox1->Text = resources->GetString(L"textBox1.Text");
			textBox1->WordWrap = false;
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->button1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(186)));
			this->button1->Location = System::Drawing::Point(198, 198);
			this->button1->Margin = System::Windows::Forms::Padding(2);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(106, 51);
			this->button1->TabIndex = 1;
			this->button1->Text = L"Atgal";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Forma_Apie::button1_Click);
			// 
			// Forma_Apie
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->ClientSize = System::Drawing::Size(509, 257);
			this->Controls->Add(this->button1);
			this->Controls->Add(textBox1);
			this->Margin = System::Windows::Forms::Padding(2);
			this->Name = L"Forma_Apie";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Apie";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

		private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->Close();
			 }




};
}
