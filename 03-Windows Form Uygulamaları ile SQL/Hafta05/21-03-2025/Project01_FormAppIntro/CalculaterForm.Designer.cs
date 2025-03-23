namespace Project01_FormAppIntro
{
    partial class CalculaterForm
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
            txtNumber1 = new TextBox();
            txtNumber2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblOperator = new Label();
            label3 = new Label();
            lblResult = new Label();
            btnPlus = new Button();
            btnDiff = new Button();
            btnDivide = new Button();
            btnMultiply = new Button();
            SuspendLayout();
            // 
            // txtNumber1
            // 
            txtNumber1.BackColor = Color.OrangeRed;
            txtNumber1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtNumber1.ForeColor = Color.White;
            txtNumber1.Location = new Point(51, 63);
            txtNumber1.Name = "txtNumber1";
            txtNumber1.Size = new Size(94, 43);
            txtNumber1.TabIndex = 0;
            // 
            // txtNumber2
            // 
            txtNumber2.BackColor = Color.OrangeRed;
            txtNumber2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtNumber2.ForeColor = Color.White;
            txtNumber2.Location = new Point(184, 63);
            txtNumber2.Name = "txtNumber2";
            txtNumber2.Size = new Size(94, 43);
            txtNumber2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 40);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 2;
            label1.Text = "Sayı 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 40);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 3;
            label2.Text = "Sayı 2";
            // 
            // lblOperator
            // 
            lblOperator.AutoSize = true;
            lblOperator.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblOperator.Location = new Point(146, 61);
            lblOperator.Name = "lblOperator";
            lblOperator.Size = new Size(37, 38);
            lblOperator.TabIndex = 4;
            lblOperator.Text = "+";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(284, 61);
            label3.Name = "label3";
            label3.Size = new Size(37, 38);
            label3.TabIndex = 5;
            label3.Text = "=";
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.RoyalBlue;
            lblResult.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblResult.ForeColor = Color.White;
            lblResult.Location = new Point(327, 55);
            lblResult.Name = "lblResult";
            lblResult.Padding = new Padding(10);
            lblResult.Size = new Size(331, 61);
            lblResult.TabIndex = 6;
            lblResult.Text = "0";
            // 
            // btnPlus
            // 
            btnPlus.BackColor = Color.RosyBrown;
            btnPlus.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnPlus.ForeColor = Color.PaleTurquoise;
            btnPlus.Location = new Point(51, 153);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(78, 64);
            btnPlus.TabIndex = 7;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = false;
            btnPlus.Click += btnPlus_Click;
            // 
            // btnDiff
            // 
            btnDiff.BackColor = Color.Blue;
            btnDiff.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDiff.ForeColor = Color.PaleTurquoise;
            btnDiff.Location = new Point(146, 153);
            btnDiff.Name = "btnDiff";
            btnDiff.Size = new Size(78, 64);
            btnDiff.TabIndex = 8;
            btnDiff.Text = "-";
            btnDiff.UseVisualStyleBackColor = false;
            btnDiff.Click += btnDiff_Click;
            // 
            // btnDivide
            // 
            btnDivide.BackColor = Color.DarkGreen;
            btnDivide.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDivide.ForeColor = Color.PaleTurquoise;
            btnDivide.Location = new Point(243, 153);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(78, 64);
            btnDivide.TabIndex = 9;
            btnDivide.Text = "/";
            btnDivide.UseVisualStyleBackColor = false;
            btnDivide.Click += btnDivide_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.BackColor = Color.Magenta;
            btnMultiply.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnMultiply.ForeColor = Color.PaleTurquoise;
            btnMultiply.Location = new Point(337, 153);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(78, 64);
            btnMultiply.TabIndex = 10;
            btnMultiply.Text = "x";
            btnMultiply.UseVisualStyleBackColor = false;
            btnMultiply.Click += btnMultiply_Click;
            // 
            // CalculaterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMultiply);
            Controls.Add(btnDivide);
            Controls.Add(btnDiff);
            Controls.Add(btnPlus);
            Controls.Add(lblResult);
            Controls.Add(label3);
            Controls.Add(lblOperator);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNumber2);
            Controls.Add(txtNumber1);
            Name = "CalculaterForm";
            Text = "CalculaterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumber1;
        private TextBox txtNumber2;
        private Label label1;
        private Label label2;
        private Label lblOperator;
        private Label label3;
        private Label lblResult;
        private Button btnPlus;
        private Button btnDiff;
        private Button btnDivide;
        private Button btnMultiply;
    }
}