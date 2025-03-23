namespace Project01_FormAppIntro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

       private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Ho� Geldiniz!");
            lblMesaj.Text = string.Empty;
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            if(txtAdSoyad.Text != string.Empty)
            {
                lblMesaj.Text = $"Merhaba {txtAdSoyad.Text}, ho�geldin";
                txtAdSoyad.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("L�tfen ad soyad bilgilerini doldurun");
            }
        }

        private void txtAdSoyad_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAdSoyad.Text)) lblMesaj.Text = txtAdSoyad.Text;
           
        }

        private void btnCalculater_Click(object sender, EventArgs e)
        {
            CalculaterForm calculaterForm = new CalculaterForm();
            calculaterForm.ShowDialog();    
        }

    }
}
