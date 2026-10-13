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

namespace MILS.Modules.Area
{
    public partial class Area : Form
    {

        public string Category = "Internal";
        public Area()
        {
            InitializeComponent();
            GetDatagridViewDate();
        }



        private void Button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Area Code is required.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Area Name is required.");
            }
            else
            {
                AddArea(textBox1.Text, textBox2.Text, DateTime.Now, Category);
            }

        }

        public void AddArea(String AreaName, String Description, DateTime NowDate, String Category)
        {


            AreaClass.SaveArea(AreaName, Description, NowDate, Category);
            GetDatagridViewDate();

            textBox1.Text = "";
            textBox2.Text = "";


           

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Category = "Internal";
            }
            else
            {
                Category = "External";
            }
        }


        public void GetDatagridViewDate()
        {
            dataGridView1.DataSource = AreaClass.GetArea();
            dataGridView1.Columns[0].Visible = false;

        }

    }
}
