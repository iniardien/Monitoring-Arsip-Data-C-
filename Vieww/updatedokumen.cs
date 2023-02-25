

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
    public partial class updatedokumen : Form
    {
        ModelDokumen mdn = new ModelDokumen();
        DataDokumen dkm = new DataDokumen();
        DataTable dtsa;
        DataGridView dva;
        ContohModel mdls;
        public updatedokumen(ModelDokumen mdl, DataGridView dv, ContohModel mdpl)
        {
            InitializeComponent();
            mdn = mdl;
            dva = dv;
            mdls = mdpl;
        }

        private void updatedokumen_Load(object sender, EventArgs e)
        {
            label2.Text = mdn.id;
            textBox3.Text = mdn.nama;
            textBox4.Text = mdn.deskripsi;
            textBox5.Text = mdls.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Isi Nama");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Isi Deskripsi");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Isi Diubah oleh");
            }
            else
            {
                dkm.updatepekerja(label2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                dkm.datadokumen();
                dtsa = dkm.dt;
                dva.DataSource = dtsa;
                this.Hide();
            }
        }
    }
}
