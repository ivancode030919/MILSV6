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

namespace MILS.Modules.Document
{
    public partial class Document : Form
    {
        public Document()
        {
           
            InitializeComponent();
            GetComboboxData1();
            GetComboboxData2();
            Display();
        }

        private void Document_Load(object sender, EventArgs e)
        {

        }
        
        public void GetComboboxData1()
        {
            comboBox2.Items.AddRange(new String[]
                {
                    "Primary","Reference"
                });

            comboBox2.SelectedIndex = -1;
        }

        public void GetComboboxData2()
        {
            comboBox1.Items.AddRange(new String[]
                {
                    "Receiving","Releasing"
                });

            comboBox1.SelectedIndex = -1;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Document Code is required.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Document Name is required.");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Module is required.");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Category is required.");
            }
            else
            {
                AddDoc(textBox1.Text, textBox2.Text, comboBox1.Text, comboBox2.Text);
                Display();

                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
                       
        }
               
        public void AddDoc(String DocCode, String DocName, String Cat, String mod)
        {
            DocumentClass.SaveDocument(DocCode,DocName,Cat, mod);
        }


        public void Display()
        {
            var documents = DocumentClass.GetDocuments();

            if (documents == null)
            {
                MessageBox.Show("No Data Available.");
                return;
            }

            dataGridView1.DataSource = documents;
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
