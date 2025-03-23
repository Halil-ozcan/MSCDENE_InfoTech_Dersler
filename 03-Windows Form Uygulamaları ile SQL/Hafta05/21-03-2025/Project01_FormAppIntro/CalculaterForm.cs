using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project01_FormAppIntro
{
    public partial class CalculaterForm : Form
    {
        public CalculaterForm()
        {
            InitializeComponent();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "+";
            double result = 0;
            result = double.Parse(txtNumber1.Text) + double.Parse(txtNumber2.Text);
            lblResult.Text = result.ToString();

        }

        private void btnDiff_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "-";
            double result = 0;
            result = double.Parse(txtNumber1.Text) - double.Parse(txtNumber2.Text);
            lblResult.Text = result.ToString();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "/";
            double result = 0;
            result = double.Parse(txtNumber1.Text) / double.Parse(txtNumber2.Text);
            lblResult.Text = result.ToString();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "x";
            double result = 0;
            result = double.Parse(txtNumber1.Text) * double.Parse(txtNumber2.Text);
            lblResult.Text = result.ToString();
        }
    }
}
