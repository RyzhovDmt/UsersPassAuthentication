namespace WindowsFormsApp1
{
    partial class EncryptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PassFrase1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Decrypt = new System.Windows.Forms.Button();
            this.Encrypt = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Open = new System.Windows.Forms.Button();
            this.PassFrase2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PassFrase1
            // 
            this.PassFrase1.Location = new System.Drawing.Point(145, 43);
            this.PassFrase1.Name = "PassFrase1";
            this.PassFrase1.PasswordChar = '*';
            this.PassFrase1.Size = new System.Drawing.Size(293, 20);
            this.PassFrase1.TabIndex = 2;
            this.PassFrase1.TextChanged += new System.EventHandler(this.PassFrase1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Парольная фраза";
            // 
            // Decrypt
            // 
            this.Decrypt.Enabled = false;
            this.Decrypt.Location = new System.Drawing.Point(24, 107);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(115, 34);
            this.Decrypt.TabIndex = 4;
            this.Decrypt.Text = "Расшифровать";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // Encrypt
            // 
            this.Encrypt.Enabled = false;
            this.Encrypt.Location = new System.Drawing.Point(23, 147);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(116, 34);
            this.Encrypt.TabIndex = 5;
            this.Encrypt.Text = "Зашифровать";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(322, 147);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 34);
            this.button4.TabIndex = 6;
            this.button4.Text = "Выход";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            this.label2.Visible = false;
            // 
            // Open
            // 
            this.Open.Enabled = false;
            this.Open.Location = new System.Drawing.Point(174, 147);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(115, 34);
            this.Open.TabIndex = 8;
            this.Open.Text = "Открыть";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // PassFrase2
            // 
            this.PassFrase2.Location = new System.Drawing.Point(145, 69);
            this.PassFrase2.Name = "PassFrase2";
            this.PassFrase2.PasswordChar = '*';
            this.PassFrase2.Size = new System.Drawing.Size(293, 20);
            this.PassFrase2.TabIndex = 9;
            // 
            // EncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 206);
            this.Controls.Add(this.PassFrase2);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PassFrase1);
            this.Name = "EncryptForm";
            this.Text = "EncryptForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EncryptForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EncryptForm_FormClosed);
            this.Load += new System.EventHandler(this.EncryptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PassFrase1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.TextBox PassFrase2;
    }
}