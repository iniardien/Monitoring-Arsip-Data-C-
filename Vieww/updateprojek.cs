
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
    public partial class updateprojek : Form
    {
        ModelProjek projek;
        DataProject dkm = new DataProject();
        ContohModel mdl;
        DataGridView dva;
        DataTable dtsa;
        public updateprojek(ModelProjek mpk ,DataGridView dv,ContohModel mpr)
        {
            InitializeComponent();
            projek = mpk;
            dva = dv;
            mdl = mpr;
        }

        private void updateprojek_Load(object sender, EventArgs e)
        {
            label2.Text = projek.id;
            textBox3.Text = projek.nama;
            textBox4.Text = projek.deskripsi;
            textBox5.Text = mdl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Isi Nama Project");
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
                dkm.updateprojek(label2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                dkm.dataproject();
                dtsa = dkm.dt;
                dva.DataSource = dtsa;
                this.Hide();
            }
        }
    }
}
