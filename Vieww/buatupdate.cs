

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiArsipppp
{
    public partial class buatupdate : Form
    {
        ContohModel mdl = new ContohModel();
        UpdellAcc apdet = new UpdellAcc();
        DataGridView dva;
        DataRole cdas = new DataRole();
        DataTable dtsa;
        public buatupdate(ContohModel mdr,DataGridView dv)
        {
            InitializeComponent();
            mdl = mdr;
            dva = dv;
        }

        private void buatupdate_Load(object sender, EventArgs e)
        {
            label2.Text = mdl.id;
            label5.Text = mdl.code;
            textBox3.Text = mdl.nama;
            textBox4.Text = mdl.deskripsi;
            textBox5.Text = mdl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Isi Diubah oleh");
            }
            else
            {
                apdet.update(label2.Text, label5.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                cdas.datarole();
                dtsa = cdas.dt;
                dva.DataSource = dtsa;
                this.Hide();
            }
        }
    }
}
