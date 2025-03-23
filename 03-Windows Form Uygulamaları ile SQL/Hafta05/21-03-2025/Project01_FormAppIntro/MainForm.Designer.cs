namespace Project01_FormAppIntro
{
    partial class MainForm
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
            label1 = new Label();
            txtAdSoyad = new TextBox();
            btnKaydol = new Button();
            lblMesaj = new Label();
            btnCalculater = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 44);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "Ad Soyad:";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            txtAdSoyad.ForeColor = Color.Blue;
            txtAdSoyad.Location = new Point(40, 67);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(243, 38);
            txtAdSoyad.TabIndex = 1;
            txtAdSoyad.TextChanged += txtAdSoyad_TextChanged;
            // 
            // btnKaydol
            // 
            btnKaydol.BackColor = Color.DodgerBlue;
            btnKaydol.FlatAppearance.BorderSize = 0;
            btnKaydol.FlatStyle = FlatStyle.Flat;
            btnKaydol.ForeColor = SystemColors.ButtonHighlight;
            btnKaydol.Location = new Point(40, 123);
            btnKaydol.Name = "btnKaydol";
            btnKaydol.Size = new Size(94, 29);
            btnKaydol.TabIndex = 2;
            btnKaydol.Text = "Kaydol";
            btnKaydol.UseVisualStyleBackColor = false;
            btnKaydol.Click += btnKaydol_Click;
            // 
            // lblMesaj
            // 
            lblMesaj.AutoSize = true;
            lblMesaj.Dock = DockStyle.Bottom;
            lblMesaj.Font = new Font("Segoe UI", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 162);
            lblMesaj.ForeColor = Color.IndianRed;
            lblMesaj.Location = new Point(0, 373);
            lblMesaj.Name = "lblMesaj";
            lblMesaj.RightToLeft = RightToLeft.No;
            lblMesaj.Size = new Size(73, 31);
            lblMesaj.TabIndex = 3;
            lblMesaj.Text = "label2";
            lblMesaj.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCalculater
            // 
            btnCalculater.Location = new Point(529, 40);
            btnCalculater.Name = "btnCalculater";
            btnCalculater.Size = new Size(190, 42);
            btnCalculater.TabIndex = 4;
            btnCalculater.Text = "Hesap Makinesi";
            btnCalculater.UseVisualStyleBackColor = true;
            btnCalculater.Click += btnCalculater_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 404);
            Controls.Add(btnCalculater);
            Controls.Add(lblMesaj);
            Controls.Add(btnKaydol);
            Controls.Add(txtAdSoyad);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAdSoyad;
        private Button btnKaydol;
        private Label lblMesaj;
        private Button btnCalculater;
    }
}
