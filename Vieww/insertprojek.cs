
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
    public partial class insertprojek : Form
    {
        DataProject dp = new DataProject();
        DataTable dtsa;
        DataGridView dva;
        ContohModel mdl;
        public insertprojek(DataGridView dv,ContohModel mdll)
        {
            InitializeComponent();
            dva = dv;
            mdl = mdll;
        }

        private void insertprojek_Load(object sender, EventArgs e)
        {
            textBox3.Text = mdl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Isi Nama Project");
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
                dp.insertprojek(textBox1.Text, textBox2.Text, textBox3.Text);
                dp.dataproject();
                dtsa = dp.dt;
                dva.DataSource = dtsa;
                this.Hide();
            }
        }
    }
}
