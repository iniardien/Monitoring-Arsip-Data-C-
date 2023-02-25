
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AplikasiArsipppp
{


    public partial class login : Form
    {
        Login loj = new Login();
        DataUser dus = new DataUser();
        ContohModel mdl = new ContohModel();
        public string user;
        DataRole dacs = new DataRole();
        
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string srlt = loj.lojin(textbox1.Text, textbox2.Text);
            if (srlt.Equals(Utility.SUCCESS))
            {

                dus.lojinn(textbox1.Text);
                Menu mnu = new Menu(mdl);
                mdl.username = textbox1.Text;
                mnu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Gagal username atau password salah");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
