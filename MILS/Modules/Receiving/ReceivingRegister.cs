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

namespace MILS.Modules.Receiving
{
    public partial class ReceivingRegister : Form
    {
        public ReceivingRegister()
        {
            InitializeComponent();
        }

        private void ReceivingResterDetails_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ReceiveRegisterDG.DataSource = ReceivingClass.RegisterDEtails(null);
        }
    }
}
