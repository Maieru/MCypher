﻿namespace MCypherWinForms
{
    partial class frMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			txtPlainText = new TextBox();
			txtKey = new TextBox();
			cbEncryptionType = new ComboBox();
			btnEncrypt = new Button();
			txtResult = new TextBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			errorProvider = new ErrorProvider(components);
			((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
			SuspendLayout();
			// 
			// txtPlainText
			// 
			txtPlainText.Location = new Point(8, 29);
			txtPlainText.Margin = new Padding(3, 2, 3, 2);
			txtPlainText.Name = "txtPlainText";
			txtPlainText.Size = new Size(271, 23);
			txtPlainText.TabIndex = 0;
			txtPlainText.Tag = "PlainText";
			// 
			// txtKey
			// 
			txtKey.Location = new Point(9, 72);
			txtKey.Margin = new Padding(3, 2, 3, 2);
			txtKey.Name = "txtKey";
			txtKey.Size = new Size(271, 23);
			txtKey.TabIndex = 1;
			txtKey.Tag = "Key";
			// 
			// cbEncryptionType
			// 
			cbEncryptionType.DropDownStyle = ComboBoxStyle.DropDownList;
			cbEncryptionType.FormattingEnabled = true;
			cbEncryptionType.Location = new Point(9, 115);
			cbEncryptionType.Margin = new Padding(3, 2, 3, 2);
			cbEncryptionType.Name = "cbEncryptionType";
			cbEncryptionType.Size = new Size(271, 23);
			cbEncryptionType.TabIndex = 2;
			cbEncryptionType.Tag = "EncryptionType";
			// 
			// btnEncrypt
			// 
			btnEncrypt.Location = new Point(8, 152);
			btnEncrypt.Margin = new Padding(3, 2, 3, 2);
			btnEncrypt.Name = "btnEncrypt";
			btnEncrypt.Size = new Size(270, 22);
			btnEncrypt.TabIndex = 3;
			btnEncrypt.Text = "Encriptar";
			btnEncrypt.UseVisualStyleBackColor = true;
			btnEncrypt.Click += BtnEncrypt_Click;
			// 
			// txtResult
			// 
			txtResult.Location = new Point(8, 203);
			txtResult.Margin = new Padding(3, 2, 3, 2);
			txtResult.Multiline = true;
			txtResult.Name = "txtResult";
			txtResult.ReadOnly = true;
			txtResult.Size = new Size(271, 90);
			txtResult.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(8, 185);
			label1.Name = "label1";
			label1.Size = new Size(62, 15);
			label1.TabIndex = 5;
			label1.Text = "Resultado:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(6, 12);
			label2.Name = "label2";
			label2.Size = new Size(38, 15);
			label2.TabIndex = 6;
			label2.Text = "Texto:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(9, 54);
			label3.Name = "label3";
			label3.Size = new Size(43, 15);
			label3.TabIndex = 7;
			label3.Text = "Chave:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(9, 97);
			label4.Name = "label4";
			label4.Size = new Size(112, 15);
			label4.TabIndex = 8;
			label4.Text = "Tipo de Criptografia";
			// 
			// errorProvider
			// 
			errorProvider.ContainerControl = this;
			// 
			// frMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(306, 311);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(txtResult);
			Controls.Add(btnEncrypt);
			Controls.Add(cbEncryptionType);
			Controls.Add(txtKey);
			Controls.Add(txtPlainText);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Margin = new Padding(3, 2, 3, 2);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frMain";
			SizeGripStyle = SizeGripStyle.Hide;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MCypher";
			((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtPlainText;
        private TextBox txtKey;
        private ComboBox cbEncryptionType;
        private Button btnEncrypt;
        private TextBox txtResult;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ErrorProvider errorProvider;
    }
}
