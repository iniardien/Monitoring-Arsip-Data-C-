
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiArsipppp
{
    public partial class insertdokumen : Form
    {
        DataDokumen dkm = new DataDokumen();
        DataGridView dva;
        DataTable dtsa;
        ContohModel mdl;
        public insertdokumen(DataGridView dv,ContohModel mdpl)
        {
            InitializeComponent();
            dva = dv;
            mdl = mdpl;
        }

        private void insertdokumen_Load(object sender, EventArgs e)
        {
            textBox5.Text = mdl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Isi Nama Dokumen");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Isi Deskripsi");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Isi Dibuat Oleh");
            }
            else
            {
                dkm.insertdokumen(textBox3.Text, textBox4.Text, textBox5.Text);
                dkm.datadokumen();
                dtsa = dkm.dt;
                dva.DataSource = dtsa;
                this.Hide();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
