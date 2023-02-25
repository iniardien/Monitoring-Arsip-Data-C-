
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
    public partial class updateuser : Form
    {
        ModelUser msr = new ModelUser();
        DataUser dus = new DataUser();
        UpdellAcc updt = new UpdellAcc();
        DataGridView dva;
        DataTable dtsa;
        ContohModel mdl;
        public updateuser(ModelUser mdr, DataGridView dv, ContohModel mdpl)
        {
            InitializeComponent();
            msr = mdr;
            dva = dv;
            mdl = mdpl;
        }

        private void updateuser_Load(object sender, EventArgs e)
        {
            dus.combobox(comboBox1);
            label8.Text = msr.id;
            textBox1.Text = msr.namauser;
            comboBox1.Text = msr.role;
            textBox2.Text = msr.username;
            textBox3.Text = msr.password;
            textBox4.Text = msr.deskripsi;
            textBox5.Text = mdl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(comboBox1.SelectedValue.ToString());
            if (textBox5.Text == "")
            {
                MessageBox.Show("Isi Diubah oleh siapa");
            }
            else
            {
                updt.updateuser(textBox1.Text, label8.Text, x, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                dus.datauser();
                dtsa = dus.dt;
                dva.DataSource = dtsa;
                this.Hide();
            }
        }
    }
}
