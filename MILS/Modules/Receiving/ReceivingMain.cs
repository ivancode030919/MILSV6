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
    public partial class ReceivingMain : Form
    {
        int DGIndex;
        private MainForm _MainForm;


        public ReceivingMain(MainForm Recv)
        {
            InitializeComponent();
            _MainForm = Recv;
            DisplayCombox();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if (button2.Text == "ADD")
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Receive from is required.");
                }
                else if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Document Type is required.");
                }
                else if (comboBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("Reference Document Type is required.");
                }
                else
                {
                    SaveEntry();
                    MessageBox.Show("Data Recorded.");
                    button2.Text = "NEW ENTRY";
                    ReceiveDG.Enabled = false;
                    ReceiveDG.AllowUserToAddRows = false;
                    textBox3.Text = ReceivingClass.EntryNumber.ToString();
                }

            }
            else if (button2.Text == "NEW ENTRY")
            {
                ClearHeaderDetail();
                button2.Text = "ADD";
                ReceiveDG.Enabled = true;
                ReceiveDG.AllowUserToAddRows = true;
            }
        }
        
        public void DisplayCombox()
        {
            comboBox1.DataSource = AreaClass.GetArea();
            comboBox1.DisplayMember = "Description";
            comboBox1.ValueMember = "AreaId";
            comboBox1.SelectedIndex = -1;

            comboBox2.DataSource = DocumentClass.GetRecvPrimaryDoc();
            comboBox2.DisplayMember = "DocumentName";
            comboBox2.ValueMember = "Docid";
            comboBox2.SelectedIndex = -1;


            comboBox4.DataSource = DocumentClass.GetV_ReceivingDocsRefs();
            comboBox4.DisplayMember = "DocumentName";
            comboBox4.ValueMember = "Docid";
            comboBox4.SelectedIndex = -1;

            comboBox5.Items.AddRange(new String[]
               {
                    "Owned","Consigned"
               });

            comboBox5.SelectedIndex = -1;
        }

        public void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Received.");
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Document Type.");
            }
            else if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please Input Document No.");
            }
            else
            {
                int row = e.RowIndex;

                if (e.RowIndex < 0 || e.ColumnIndex == 5)
                    return;

                ReceiveDetailData s = new ReceiveDetailData(this);

                DGIndex = row;
                s.ReceiveRowIndex = row;

                if (e.ColumnIndex == 0)
                    s.ChooseDetail = 1;
                else if (e.ColumnIndex == 3)
                    s.ChooseDetail = 3;
                else if (e.ColumnIndex == 4)
                    s.ChooseDetail = 4;
                else
                    return;

                s.ShowDialog();
            }         
        }
               
        public void SaveEntry()
        {          
            int areaId = Convert.ToInt32(comboBox1.SelectedValue);
            int DocId = Convert.ToInt32(comboBox2.SelectedValue);
            int RefDocId = Convert.ToInt32(comboBox4.SelectedValue);
            int UserAreaID = _MainForm.UserID;
            int AreaID = _MainForm.AreaID;

            ReceivingClass.SaveHeader(areaId, DocId, textBox1.Text, 1, RefDocId, textBox2.Text, comboBox5.Text, dateTimePicker1.Value, UserAreaID, AreaID);

            string ItemNo;
            string UOM;
            int BatchID;
            int LocID;
            double Qty;

            foreach (DataGridViewRow row in ReceiveDG.Rows)
            {
                if (row.IsNewRow)
                continue;

                ItemNo = row.Cells[0].Value.ToString();
                UOM = row.Cells[2].Value.ToString();
                BatchID = Convert.ToInt32(row.Cells[6].Value);
                LocID = Convert.ToInt32(row.Cells[7].Value);
                Qty = Convert.ToDouble(row.Cells[5].Value);

                ReceivingClass.SaveDetail(ItemNo, BatchID, LocID, Qty, UOM);
                ReceivingClass.AddToInventory(ItemNo, BatchID, LocID, Qty);
            }

        }

        public void ClearHeaderDetail()
        {
            ReceiveDG.Rows.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
        
    }
}
