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
namespace MILS.Modules.Batch
{
    public partial class Batch : Form
    {
        public Batch()
        {
            InitializeComponent();
            display();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Batch Code is required.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Batch Name is required.");
            }
            else
            {
                BatchClass.SaveArea(textBox1.Text, textBox2.Text);
                textBox1.Text = "";
                textBox2.Text = "";
                display();
            }     
        }

        public void display()
        {
            dataGridView1.DataSource = BatchClass.GetBatch();
            dataGridView1.Columns[0].Visible = false;
        }



    }
}
