namespace NorthWindManagementApp
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtProductName = new TextBox();
            txtStock = new TextBox();
            txtProductPrice = new TextBox();
            cmbCategoryName = new ComboBox();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            btnClear = new Button();
            txtSearch = new TextBox();
            rdbContains = new RadioButton();
            rdbWithStart = new RadioButton();
            btnUpdate = new Button();
            btnNew = new Button();
            btnDelete = new Button();
            label5 = new Label();
            cmbFilterByCategory = new ComboBox();
            dgwProducts = new DataGridView();
            label6 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(22, 14);
            label1.Name = "label1";
            label1.Size = new Size(117, 31);
            label1.TabIndex = 0;
            label1.Text = "Ürün Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(22, 68);
            label2.Name = "label2";
            label2.Size = new Size(112, 31);
            label2.TabIndex = 1;
            label2.Text = "Kategori:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.RoyalBlue;
            label3.Location = new Point(535, 65);
            label3.Name = "label3";
            label3.Size = new Size(69, 31);
            label3.TabIndex = 2;
            label3.Text = "Stok:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = Color.RoyalBlue;
            label4.Location = new Point(535, 9);
            label4.Name = "label4";
            label4.Size = new Size(72, 31);
            label4.TabIndex = 3;
            label4.Text = "Fiyat:";
            // 
            // txtProductName
            // 
            txtProductName.BorderStyle = BorderStyle.FixedSingle;
            txtProductName.Font = new Font("Segoe UI", 13.8F);
            txtProductName.ForeColor = Color.SteelBlue;
            txtProductName.Location = new Point(136, 12);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(358, 38);
            txtProductName.TabIndex = 4;
            // 
            // txtStock
            // 
            txtStock.BorderStyle = BorderStyle.FixedSingle;
            txtStock.Font = new Font("Segoe UI", 13.8F);
            txtStock.ForeColor = Color.SteelBlue;
            txtStock.Location = new Point(613, 65);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(138, 38);
            txtStock.TabIndex = 5;
            // 
            // txtProductPrice
            // 
            txtProductPrice.BorderStyle = BorderStyle.FixedSingle;
            txtProductPrice.Font = new Font("Segoe UI", 13.8F);
            txtProductPrice.ForeColor = Color.SteelBlue;
            txtProductPrice.Location = new Point(613, 9);
            txtProductPrice.Name = "txtProductPrice";
            txtProductPrice.Size = new Size(138, 38);
            txtProductPrice.TabIndex = 6;
            // 
            // cmbCategoryName
            // 
            cmbCategoryName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryName.Font = new Font("Segoe UI", 13.8F);
            cmbCategoryName.ForeColor = Color.Teal;
            cmbCategoryName.FormattingEnabled = true;
            cmbCategoryName.Location = new Point(136, 68);
            cmbCategoryName.Name = "cmbCategoryName";
            cmbCategoryName.Size = new Size(358, 39);
            cmbCategoryName.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(rdbContains);
            groupBox1.Controls.Add(rdbWithStart);
            groupBox1.Font = new Font("Segoe UI", 14.2F, FontStyle.Bold);
            groupBox1.ForeColor = Color.RoyalBlue;
            groupBox1.Location = new Point(22, 124);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(716, 146);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gelişmiş Arama";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.RoyalBlue;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(540, 78);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(170, 55);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.NavajoWhite;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.Location = new Point(540, 22);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(170, 57);
            btnClear.TabIndex = 5;
            btnClear.Text = "Temizle";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(6, 85);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(528, 39);
            txtSearch.TabIndex = 4;
            // 
            // rdbContains
            // 
            rdbContains.AutoSize = true;
            rdbContains.Font = new Font("Segoe UI", 12.8F);
            rdbContains.ForeColor = Color.Gray;
            rdbContains.Location = new Point(388, 36);
            rdbContains.Name = "rdbContains";
            rdbContains.Size = new Size(124, 34);
            rdbContains.TabIndex = 3;
            rdbContains.TabStop = true;
            rdbContains.Text = "... içerir ...";
            rdbContains.UseVisualStyleBackColor = true;
            // 
            // rdbWithStart
            // 
            rdbWithStart.AutoSize = true;
            rdbWithStart.Font = new Font("Segoe UI", 12.8F);
            rdbWithStart.ForeColor = Color.Gray;
            rdbWithStart.Location = new Point(230, 36);
            rdbWithStart.Name = "rdbWithStart";
            rdbWithStart.Size = new Size(140, 34);
            rdbWithStart.TabIndex = 2;
            rdbWithStart.TabStop = true;
            rdbWithStart.Text = "... ile başlar";
            rdbWithStart.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Blue;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(22, 276);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(153, 82);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.Green;
            btnNew.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(196, 276);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(153, 82);
            btnNew.TabIndex = 10;
            btnNew.Text = "Yeni Ürün";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(371, 276);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(153, 82);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.ForeColor = Color.RoyalBlue;
            label5.Location = new Point(533, 279);
            label5.Name = "label5";
            label5.Size = new Size(238, 28);
            label5.TabIndex = 12;
            label5.Text = "Kategoriye Göre Filtrele";
            // 
            // cmbFilterByCategory
            // 
            cmbFilterByCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterByCategory.Font = new Font("Segoe UI", 13.8F);
            cmbFilterByCategory.ForeColor = Color.Teal;
            cmbFilterByCategory.FormattingEnabled = true;
            cmbFilterByCategory.Location = new Point(535, 315);
            cmbFilterByCategory.Name = "cmbFilterByCategory";
            cmbFilterByCategory.Size = new Size(235, 39);
            cmbFilterByCategory.TabIndex = 13;
            // 
            // dgwProducts
            // 
            dgwProducts.AllowUserToAddRows = false;
            dgwProducts.AllowUserToDeleteRows = false;
            dgwProducts.AllowUserToResizeColumns = false;
            dgwProducts.AllowUserToResizeRows = false;
            dgwProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwProducts.Dock = DockStyle.Bottom;
            dgwProducts.Location = new Point(0, 411);
            dgwProducts.Name = "dgwProducts";
            dgwProducts.RowHeadersWidth = 51;
            dgwProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwProducts.Size = new Size(782, 305);
            dgwProducts.TabIndex = 14;
            dgwProducts.CellEnter += dgwProducts_CellEnter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.ForeColor = Color.RoyalBlue;
            label6.Location = new Point(22, 363);
            label6.Name = "label6";
            label6.Size = new Size(147, 31);
            label6.TabIndex = 15;
            label6.Text = "Ürün Listesi:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 716);
            Controls.Add(label6);
            Controls.Add(dgwProducts);
            Controls.Add(cmbFilterByCategory);
            Controls.Add(label5);
            Controls.Add(btnDelete);
            Controls.Add(btnNew);
            Controls.Add(btnUpdate);
            Controls.Add(groupBox1);
            Controls.Add(cmbCategoryName);
            Controls.Add(txtProductPrice);
            Controls.Add(txtStock);
            Controls.Add(txtProductName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Northwind Management App";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtProductName;
        private TextBox txtStock;
        private TextBox txtProductPrice;
        private ComboBox cmbCategoryName;
        private GroupBox groupBox1;
        private RadioButton rdbWithStart;
        private RadioButton rdbContains;
        private Button btnSearch;
        private Button btnClear;
        private TextBox txtSearch;
        private Button btnUpdate;
        private Button btnNew;
        private Button btnDelete;
        private Label label5;
        private ComboBox cmbFilterByCategory;
        private DataGridView dgwProducts;
        private Label label6;
    }
}
