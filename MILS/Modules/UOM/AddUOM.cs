using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MILS.Class;

namespace MILS.Modules.UOM
{
    public partial class AddUOM : Form
    {
        private UOM NewUOMDisplay;

        public AddUOM(UOM uomDisplay)
        {
            NewUOMDisplay = uomDisplay;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("UoM Code is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("UoM Name is required.");
                return;
            }


            UOMClass.SaveUOM(textBox1.Text,textBox2.Text);

            MessageBox.Show("Successfully Added.");
            NewUOMDisplay.Display("");
            textBox1.Text = "";
            textBox2.Text = "";         
        }
                                                                       
        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
