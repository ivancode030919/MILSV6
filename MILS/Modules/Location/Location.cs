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

namespace MILS.Modules.Location
{
    public partial class Location : Form
    {
        public Location()
        {
            InitializeComponent();
            GetAreaCombox();
            DisplayLocation();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int areaId = Convert.ToInt32(comboBox1.SelectedValue);

            if (textBox1.Text == "")
            {
                MessageBox.Show("Location Code is required.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Location Name is required.");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Area Code is required.");
            }
            else
            {
                LocationClass.SaveLocation(textBox1.Text, textBox2.Text, areaId);
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                DisplayLocation();
            }
          
        }

        public void GetAreaCombox()
        {
            comboBox1.DataSource = AreaClass.GetArea();
            comboBox1.DisplayMember = "AreaName";
            comboBox1.ValueMember = "AreaId";
            comboBox1.SelectedIndex = -1;
        }


        public void DisplayLocation()
        {
            dataGridView1.DataSource = LocationClass.GetLocation();
        }
    }
}
