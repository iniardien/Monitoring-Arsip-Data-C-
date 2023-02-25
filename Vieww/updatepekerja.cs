
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
    public partial class updatepekerja : Form
    {
        DataPekerja dtp = new DataPekerja();
        ModelPekerjaan mdl = new ModelPekerjaan();
        DataTable dtsa;
        DataGridView dva;
        ContohModel mdpl;
        public updatepekerja(ModelPekerjaan mdr, DataGridView dv,ContohModel mdpls)
        {
            InitializeComponent();
            mdl = mdr;
            dva = dv;
            mdpl = mdpls;
        }

        private void updatepekerja_Load(object sender, EventArgs e)
        {
            label5.Text = mdl.id;
            textBox1.Text = mdl.nama;
            textBox2.Text = mdl.deskripsi;
            textBox3.Text = mdpl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtp.updatepekerja(label5.Text, textBox1.Text, textBox2.Text, textBox3.Text);
            dtp.datapekerjaan();
            dtsa = dtp.dt;
            dva.DataSource = dtsa;
            this.Hide();
        }
    }
}
