using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MILS.Connections;
using MILS.Class;

namespace MILS.Modules.Item
{
    public partial class AddItem : Form
    {
        public bool Change = true;
        public AddItem()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bool _IsExDate = checkBox1.Checked;

            if (textBox2.Text == string.Empty || textBox2.Text == "")
            {
                MessageBox.Show("Item No. is Required.");
            }
            else if (textBox3.Text == string.Empty || textBox3.Text == "")
            {
                MessageBox.Show("Item Description is Required.");
            }
            else if (textBox4.Text == string.Empty || textBox4.Text == "")
            {
                MessageBox.Show("UoM is Required.");
            }
            else
            {
                if (button2.Text == "Update")
                {
                    ItemClass.UpdateUoM(textBox2.Text, textBox4.Text);
                }
                else
                {
                   
                    ItemClass.SaveItem(textBox2.Text, textBox3.Text, dateTimePicker1.Value, _IsExDate, true, textBox4.Text);
                    MessageBox.Show("Successfully Added.");
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    checkBox1.Checked = false;
                }
   
            }

        }


        private void DataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Input Item No.");
            }
            else if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Input Item Description.");
            }
            else
            {
                UomGroup s = new UomGroup(this);
                s.textBox1.Text = textBox2.Text;
                s.ShowDialog();
            }
        }

        private void AddItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
