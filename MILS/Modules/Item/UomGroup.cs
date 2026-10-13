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
    public partial class UomGroup : Form
    {
        private AddItem _AddItems;

        public UomGroup(AddItem addItem)
        {
          
            InitializeComponent();
            this.KeyPreview = true;
            _AddItems = addItem;
        }


        public void display(string search)
        {
            dataGridView1.DataSource = UOMClass.GetTbl_UoMGroups();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            if (e.ColumnIndex == 0)
            {
                Modules.UOM.UOM s = new Modules.UOM.UOM(null, this);
                s.index = index;
                s.Othermodule = 3;
                s.ShowDialog();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Modules.UOM.UOM s = new Modules.UOM.UOM(null,this);
            s.Othermodule = 2;
            s.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if (button2.Text == "Add")
            {

                string ItemNo;
                string UoMCode;
                float AltQty;
                bool IsExists;

                IsExists = UoMGroupClass.CheckUom(textBox1.Text, textBox2.Text, Convert.ToSingle(textBox3.Text));

                //save header
                if (IsExists == false)
                {
                    UoMGroupClass.SaveUoM(textBox1.Text, textBox2.Text, Convert.ToSingle(textBox3.Text));
                }

                //save per row
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    ItemNo = textBox1.Text;
                    UoMCode = row.Cells[0].Value.ToString();
                    AltQty = Convert.ToSingle(row.Cells[1].Value);
                    IsExists = UoMGroupClass.CheckUom(ItemNo, UoMCode, AltQty);

                    if (IsExists == false)
                    {
                        UoMGroupClass.SaveAlterUoM(ItemNo, UoMCode, AltQty);
                    }

                }

                MessageBox.Show("Successfully added.");
            }
            else if (button2.Text == "Update")
            {
            }


        }

        private void UomGroup_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (textBox3.Text == "" || textBox3.Text == "0" || textBox3.Text == String.Empty)
            {
                MessageBox.Show("Invalid Base Quantity.");
            }
            else
            {
                _AddItems.textBox4.Text = textBox2.Text;
            }

        }

        private void DataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void UomGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void UomGroup_Validating(object sender, CancelEventArgs e)
        {
            bool IsExists;
            IsExists = UoMGroupClass.CheckUom(textBox1.Text, textBox2.Text, Convert.ToSingle(textBox3.Text));

            if (IsExists == false)
            {
                button2.Text = "Update";
            }
            else
            {
                button2.Text = "Add";
            }
        }
    }
}
