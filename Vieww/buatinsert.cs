
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiArsipppp
{
    public partial class buatinsert : Form
    {
        DataRole cdas = new DataRole();
        DataGridView dva;
        DataTable dtsa;
        ContohModel mdl;
        public buatinsert(DataGridView dv, ContohModel mdr)
        {
            InitializeComponent();
            dva = dv;
            mdl = mdr;
        }

        private void buatinsert_Load(object sender, EventArgs e)
        {
            textBox3.Text = mdl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Isi Nama Role");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Isi Deskripsi");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Isi Dibuat Oleh");
            }
            else
            {
                cdas.insert(textBox1.Text, textBox2.Text, textBox3.Text);
                cdas.datarole();
                dtsa = cdas.dt;
                dva.DataSource = dtsa;
                this.Hide();
            }
        }
    }
}
