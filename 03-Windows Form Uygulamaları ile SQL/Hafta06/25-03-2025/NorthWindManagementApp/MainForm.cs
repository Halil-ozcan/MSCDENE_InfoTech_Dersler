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

            categories.AddFirst(new Category { Id = 0, Name = "Tümü" });
            cmbFilterByCategory.DataSource = categories.ToList();
            cmbFilterByCategory.DisplayMember = "Name";
            cmbFilterByCategory.ValueMember = "Id";
        }

        private void LoadProducts(DataTable products)
        {
            dgwProducts.DataSource = products;
            dgwProducts.Columns["Id"].Width = 50;

            dgwProducts.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgwProducts.Columns["Name"].HeaderText = "Ürün";

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
            // Product Id' ye göre veri tabanýndan products tablosundan ilgili veriyi çek.
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
                MessageBox.Show("Ürün Adý Boþ Býrakýlamaz");
                return;
            }
            if (string.IsNullOrEmpty(txtProductPrice.Text.Trim()))
            {
                MessageBox.Show("Fiyat Boþ Býrakýlamaz");
            }
            decimal price;
            if (!decimal.TryParse(txtProductPrice.Text, out price))
            {
                MessageBox.Show("Lütfen Geçerli bir fiyat deðeri giriniz!");
                return;
            }
            int stock;
            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Lütfen Geçerli bir stok deðeri giriniz");
                return;
            }
            // Þimdi ProductDAL sýnýfýmýzda bir ürün güncelleme metot yazacaðýz.
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
            DataTable products = productDAL.GetAll(); // Bu iki satýr kod güncelleme yapýldýktan sonra data gridde verileri güncelleyip getirmek için yazdýk.
            LoadProducts(products);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "Yeni Ürün")
            {
                txtProductName.Clear();
                txtProductPrice.Clear();
                txtStock.Clear();
                cmbCategoryName.SelectedIndex = 0; // týklandýðýnda ilk kategoriyi seçiyor.
                txtProductName.Focus();
                btnUpdate.Enabled = false; // týklanýldðýnda bu butonlarý devre dýþý býrakýr.
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
                    MessageBox.Show("Ürün Adý Boþ Býrakýlamaz");
                    return;
                }
                if (string.IsNullOrEmpty(txtProductPrice.Text.Trim()))
                {
                    MessageBox.Show("Fiyat Boþ Býrakýlamaz");
                }
                decimal price;
                if (!decimal.TryParse(txtProductPrice.Text, out price))
                {
                    MessageBox.Show("Lütfen Geçerli bir fiyat deðeri giriniz!");
                    return;
                }
                int stock;
                if (!int.TryParse(txtStock.Text, out stock))
                {
                    MessageBox.Show("Lütfen Geçerli bir stok deðeri giriniz");
                    return;
                }
                // yeni ürün kaydetme operasyonu yapýlacak
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
                btnNew.Text = "Yeni Ürün";
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
            cmbFilterByCategory.Text = "Tümü";
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
