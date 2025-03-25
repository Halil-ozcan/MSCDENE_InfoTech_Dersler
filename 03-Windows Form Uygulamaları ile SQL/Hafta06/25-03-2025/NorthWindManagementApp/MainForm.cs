using System.Data;
using NorthWindManagementApp.DataAccessLayer;
using NorthWindManagementApp.Models;

namespace NorthWindManagementApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CategoryDAL categoryDAL = new CategoryDAL();
            LinkedList<Category> categories = categoryDAL.GetAll();
            LoadCategories(categories);

            ProductDAL productDAL = new ProductDAL();
            DataTable products = productDAL.GetAll();
            LoadProducts(products);

            rdbWithStart.Checked = true;
        }

        private void LoadCategories(LinkedList<Category> categories)
        {
            cmbCategoryName.DataSource = categories.ToList();
            cmbCategoryName.DisplayMember = "Name";
            cmbCategoryName.ValueMember = "Id";

            categories.AddFirst(new Category { Id = 0, Name = "T�m�" });
            cmbFilterByCategory.DataSource = categories.ToList();
            cmbFilterByCategory.DisplayMember = "Name";
            cmbFilterByCategory.ValueMember = "Id";
        }

        private void LoadProducts(DataTable products)
        {
            dgwProducts.DataSource = products;
            dgwProducts.Columns["Id"].Width = 50;

            dgwProducts.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgwProducts.Columns["Name"].HeaderText = "�r�n";

            dgwProducts.Columns["CategoryId"].Visible = false;

            dgwProducts.Columns["Price"].Width = 100;
            dgwProducts.Columns["Price"].HeaderText = "Fiyat";
            dgwProducts.Columns["Price"].DefaultCellStyle.Format = "C2";

            dgwProducts.Columns["Stock"].Width = 75;
            dgwProducts.Columns["Stock"].HeaderText = "Stok";

            dgwProducts.Columns["Category"].Width = 175;
            dgwProducts.Columns["Category"].HeaderText = "Kategori";
        }

        private void dgwProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Product Id' ye g�re veri taban�ndan products tablosundan ilgili veriyi �ek.
            //txtProductName.Text = dgwProducts.CurrentRow.Cells["Name"].Value.ToString();
            //txtProductPrice.Text = dgwProducts.CurrentRow.Cells["Price"].Value.ToString();
            //txtStock.Text = dgwProducts.CurrentRow.Cells["Stock"].Value.ToString();
            //cmbCategoryName.SelectedValue = dgwProducts.CurrentRow.Cells["CategoryId"].Value;

            ProductDAL productDAL = new ProductDAL();
            Product product = productDAL.GetById((int)dgwProducts.CurrentRow.Cells[0].Value);
            txtProductName.Text = product.Name;
            txtProductPrice.Text = product.Price.ToString();
            txtStock.Text = product.Stock.ToString();
            cmbCategoryName.SelectedValue = product.CategoryId;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                MessageBox.Show("�r�n Ad� Bo� B�rak�lamaz");
                return;
            }
            if (string.IsNullOrEmpty(txtProductPrice.Text.Trim()))
            {
                MessageBox.Show("Fiyat Bo� B�rak�lamaz");
            }
            decimal price;
            if (!decimal.TryParse(txtProductPrice.Text, out price))
            {
                MessageBox.Show("L�tfen Ge�erli bir fiyat de�eri giriniz!");
                return;
            }
            int stock;
            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("L�tfen Ge�erli bir stok de�eri giriniz");
                return;
            }
            // �imdi ProductDAL s�n�f�m�zda bir �r�n g�ncelleme metot yazaca��z.
            UpdateProductModel updateProductModel = new()
            {
                Id = (int)dgwProducts.CurrentRow.Cells["Id"].Value,
                Name = txtProductName.Text,
                Price = price,
                Stock = stock.ToString(),
                CategoryId = (int)cmbCategoryName.SelectedValue!,
            };
            ProductDAL productDAL = new ProductDAL();
            productDAL.Update(updateProductModel);
            DataTable products = productDAL.GetAll(); // Bu iki sat�r kod g�ncelleme yap�ld�ktan sonra data gridde verileri g�ncelleyip getirmek i�in yazd�k.
            LoadProducts(products);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "Yeni �r�n")
            {
                txtProductName.Clear();
                txtProductPrice.Clear();
                txtStock.Clear();
                cmbCategoryName.SelectedIndex = 0; // t�kland���nda ilk kategoriyi se�iyor.
                txtProductName.Focus();
                btnUpdate.Enabled = false; // t�klan�ld��nda bu butonlar� devre d��� b�rak�r.
                btnDelete.Enabled = false;
                grpSearch.Enabled = false;
                cmbFilterByCategory.Enabled = false;
                dgwProducts.Enabled = false;
                btnNew.Text = "Kaydet";
            }
            else
            {
                if (string.IsNullOrEmpty(txtProductName.Text.Trim()))
                {
                    MessageBox.Show("�r�n Ad� Bo� B�rak�lamaz");
                    return;
                }
                if (string.IsNullOrEmpty(txtProductPrice.Text.Trim()))
                {
                    MessageBox.Show("Fiyat Bo� B�rak�lamaz");
                }
                decimal price;
                if (!decimal.TryParse(txtProductPrice.Text, out price))
                {
                    MessageBox.Show("L�tfen Ge�erli bir fiyat de�eri giriniz!");
                    return;
                }
                int stock;
                if (!int.TryParse(txtStock.Text, out stock))
                {
                    MessageBox.Show("L�tfen Ge�erli bir stok de�eri giriniz");
                    return;
                }
                // yeni �r�n kaydetme operasyonu yap�lacak
                CreateProductModel createProductModel = new()
                {
                    Name = txtProductName.Text,
                    Price = price,
                    Stock = stock.ToString(),
                    CategoryId = (int)cmbCategoryName.SelectedValue!
                };
                ProductDAL productDAL = new ProductDAL();
                productDAL.Create(createProductModel);
                DataTable products = productDAL.GetAll();
                LoadProducts(products);

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                grpSearch.Enabled = true;
                cmbFilterByCategory.Enabled = true;
                dgwProducts.Enabled = true;
                btnNew.Text = "Yeni �r�n";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = (int)dgwProducts.CurrentRow.Cells[0].Value;
            ProductDAL productDAL = new ProductDAL();
            productDAL.Delete(id);
            DataTable products = productDAL.GetAll();
            LoadProducts(products);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterByCategory.Text = "T�m�";
            ProductDAL productDAL = new ProductDAL();
            DataTable products = productDAL.GetAll();
            LoadProducts(products);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                ProductDAL productDAL = new ProductDAL();
                DataTable searchResult = productDAL.Search(searchText, rdbWithStart.Checked);
                LoadProducts(searchResult);
            }
        }

        private void cmbFilterByCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductDAL productDAL = new ProductDAL();
            DataTable products;
            if(cmbFilterByCategory.SelectedIndex == 0)
            {
                 products = productDAL.GetAll();
            }
            else
            {
                int categoryId = (int)cmbFilterByCategory.SelectedValue!;
                 products = productDAL.GetAll(categoryId);
            }
            LoadProducts(products);
        }
    }
}
