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

namespace MILS.Modules.Receiving
{
    public partial class ReceiveDetailData : Form
    {
        public int ChooseDetail;
        public int ReceiveRowIndex;
        private ReceivingMain _receiving;

        public ReceiveDetailData(ReceivingMain receiving)
        {
            InitializeComponent();
            _receiving = receiving;
        }

        private void ReceiveDetailData_Load(object sender, EventArgs e)
        {
            DisplayData(textBox1.Text);
        }

        public void DisplayData(string search)
        {
            if (ChooseDetail == 1)
            {
                this.Text = "Items";
                dataGridView1.DataSource = ItemClass.GetItemsSearch(search);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
            else if (ChooseDetail == 3)
            {
                this.Text = "Batch";
                dataGridView1.DataSource = BatchClass.GetBatchesSearch(search);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;

            }
            else if (ChooseDetail == 4)
            {
                this.Text = "Location";
                dataGridView1.DataSource = LocationClass.GetlocationSearch(search);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[0].Visible = false;

                dataGridView1.Columns[5].DisplayIndex = 0;
                dataGridView1.Columns[1].DisplayIndex = 1;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DisplayData(textBox1.Text);
        }

        public void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex >= 0)
            {
                int row = e.RowIndex;

                if (ChooseDetail == 1)
                {
                    _receiving.ReceiveDG.Rows[ReceiveRowIndex].Cells[0].Value = dataGridView1.Rows[row].Cells[1].Value?.ToString();
                    _receiving.ReceiveDG.Rows[ReceiveRowIndex].Cells[1].Value = dataGridView1.Rows[row].Cells[2].Value?.ToString();
                    _receiving.ReceiveDG.Rows[ReceiveRowIndex].Cells[2].Value = dataGridView1.Rows[row].Cells[6].Value?.ToString();
                }
                else if (ChooseDetail == 3)
                {
                    _receiving.ReceiveDG.Rows[ReceiveRowIndex].Cells[3].Value = dataGridView1.Rows[row].Cells[2].Value?.ToString();
                    _receiving.ReceiveDG.Rows[ReceiveRowIndex].Cells[6].Value = dataGridView1.Rows[row].Cells[0].Value?.ToString();
                }
                else if (ChooseDetail == 4)
                {
                    _receiving.ReceiveDG.Rows[ReceiveRowIndex].Cells[4].Value = dataGridView1.Rows[row].Cells[1].Value?.ToString();
                    _receiving.ReceiveDG.Rows[ReceiveRowIndex].Cells[7].Value = dataGridView1.Rows[row].Cells[0].Value?.ToString();
                }
                this.Close();
            }
        }

        private void ReceiveDetailData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
