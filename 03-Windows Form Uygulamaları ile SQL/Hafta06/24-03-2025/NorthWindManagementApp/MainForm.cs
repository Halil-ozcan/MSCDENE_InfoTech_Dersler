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
            Product product = productDAL.GetById((int)dgwProducts.CurrentRow.Cells["Id"].Value);
            txtProductName.Text = product.Name;
            txtProductPrice.Text = product.Price.ToString();
            txtStock.Text = product.Stock.ToString();
            cmbCategoryName.SelectedValue = product.CategoryId;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                MessageBox.Show("Ürün Adý Boþ Býrakýlamaz");
                return;
            }
            if(string.IsNullOrEmpty(txtProductPrice.Text.Trim()))
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
            if(!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Lütfen Geçerli bir stok deðeri giriniz");
                return;
            }
            // Þimdi ProductDAL sýnýfýmýzda bir ürün güncelleme metot yazacaðýz.

        }
    }
}
