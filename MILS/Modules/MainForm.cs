using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MILS.Modules;

namespace MILS
{
    public partial class MainForm : Form
    {
        public int AreaID = 0;
        public int UserID = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AccordionControlElement2_Click(object sender, EventArgs e)
        {
            Modules.Area.Area s = new Modules.Area.Area();
            s.ShowDialog();
        }

        private void AccordionControlElement3_Click(object sender, EventArgs e)
        {
            Modules.Document.Document s = new Modules.Document.Document();
            s.ShowDialog();
        }

        private void AccordionControlElement4_Click(object sender, EventArgs e)
        {
            Modules.Batch.Batch s = new Modules.Batch.Batch();
            s.ShowDialog();
        }

        private void AccordionControlElement8_Click(object sender, EventArgs e)
        {
            Modules.Location.Location s = new Modules.Location.Location();
            s.ShowDialog();
        }

        private void AccordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void AccordionControlElement9_Click(object sender, EventArgs e)
        {
            Modules.Receiving.ReceivingMain s = new Modules.Receiving.ReceivingMain(this);
            s.ShowDialog();
        }

        private void AccordionControlElement11_Click(object sender, EventArgs e)
        {
            Modules.Item.Items s = new Modules.Item.Items();
            s.ShowDialog();
        }

        private void AccordionControlElement12_Click(object sender, EventArgs e)
        {
            Modules.UOM.UOM s = new Modules.UOM.UOM(this,null);
            s.Othermodule = 1;
            s.ShowDialog();
        }

        private void AccordionControlElement10_Click(object sender, EventArgs e)
        {
            Modules.Receiving.ReceivingRegister s = new Modules.Receiving.ReceivingRegister();
            s.ShowDialog();
        }
    }
}
