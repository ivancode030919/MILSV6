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

namespace MILS.Modules.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if (LoginClass.LoginUser(textBox1.Text, textBox2.Text) == true)
            {
                int p = LoginClass.GetUserID(textBox1.Text, textBox2.Text);
                int l = LoginClass.GetAreaID(p);

                MainForm s = new MainForm();
                this.Hide();
                s.UserID = p;
                s.AreaID = l;
                s.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid User.");
            }

     

        }
    }
}
