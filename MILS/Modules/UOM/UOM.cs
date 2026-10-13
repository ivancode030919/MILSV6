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
using MILS.Modules;

namespace MILS.Modules.UOM
{
    public partial class UOM : Form
    {
        public int Othermodule = 0;
        public int index;
        private MainForm _mainForm;
        private Modules.Item.UomGroup _UomGroup;

        public UOM(MainForm Mod = null, Modules.Item.UomGroup UoMgroup = null)
        {
            InitializeComponent();
            _mainForm = Mod;
            _UomGroup = UoMgroup;
            Display("");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddUOM s = new AddUOM(this);
            s.Text = "New Unit of Measure";
            s.ShowDialog();
        }


        public void Display(string search)
        {
            dataGridView1.DataSource = UOMClass.GetUOMsSearch(search);
            dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[3].Visible = false;
            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[5].Visible = false;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Display(textBox1.Text);
           
        }

        private void UOM_Load(object sender, EventArgs e)
        {
            if (Othermodule == 1)
            {
                button1.Visible = true;
            }
            else if (Othermodule ==2)
            {
                button1.Visible = false;
            }
            else if (Othermodule == 3)
            {
                button1.Visible = false;
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (Othermodule == 2)
            {
                _UomGroup.textBox2.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            }
            else if (Othermodule == 3)
            {
                _UomGroup.dataGridView1.Rows[index].Cells[0].Value = dataGridView1.Rows[row].Cells[1].Value?.ToString();
            }

            this.Close();
        }
    }
}
