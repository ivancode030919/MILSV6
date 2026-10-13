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

namespace MILS.Modules.Item
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            this.KeyPreview = true;
            Display("");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
       
        }


        public void Display(string search)
        {
            dataGridView1.DataSource = ItemClass.GetItemsSearch(search);
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[3].Visible = false;
            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Columns[6].Visible = false;

            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 1000;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Display(textBox1.Text);
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            AddItem s = new AddItem();
            s.textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            s.textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            s.textBox4.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
            s.checkBox1.Checked = (bool)dataGridView1.Rows[index].Cells[4].Value;

            s.textBox2.Enabled = false;
            s.Text = "Update Item";
            s.button2.Text = "Update";
            
   
            s.ShowDialog();
        }

        private void Items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItem s = new AddItem();
            s.ShowDialog();
        }
    }
}
