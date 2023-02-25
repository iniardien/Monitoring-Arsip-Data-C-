
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
    public partial class insertpekerja : Form
    {
        DataPekerja dtp = new DataPekerja();
        DataGridView dva;
        DataTable dtsa;
        ContohModel mdl;

        public insertpekerja(DataGridView dv,ContohModel mdpl)
        {
            InitializeComponent();
            dva = dv;
            mdl = mdpl;
        }

        private void insertpekerja_Load(object sender, EventArgs e)
        {
            textBox3.Text = mdl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("ISI NAMA");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("ISI Deskripsi");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("ISI Dibuat Oleh");
            }
            else
            {
                dtp.insertpekerja(textBox1.Text, textBox2.Text, textBox3.Text);
                dtp.datapekerjaan();
                dtsa = dtp.dt;
                dva.DataSource = dtsa;
                this.Hide();
            }
        }
    }
}
