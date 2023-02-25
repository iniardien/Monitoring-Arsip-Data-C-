using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AplikasiArsipppp
{
    public partial class updatetrdok : Form
    {
        ContohModel mdl = new ContohModel();
        DataGridView dv;
        modeltrdok mtd = new modeltrdok();
        datatrd tr = new datatrd();
        DataTable dts;
        public updatetrdok(ContohModel mdpl,DataGridView dva,modeltrdok mttd)
        {
            InitializeComponent();
            mdl = mdpl;
            dv = dva;
            mtd = mttd;
        }

        private void updatetrdok_Load(object sender, EventArgs e)
        {
            tr.comboboxp(comboBox1);
            tr.comboboxkatdok(comboBox2);
            label7.Text = mtd.id;
            label5.Text = mtd.iddok;
            textBox2.Text = mtd.namadokumen;
            comboBox1.Text = mtd.namapekerjaan;
            comboBox2.Text = mtd.katdok;
            textBox1.Text = mtd.dokumen;
            richTextBox1.Text = mtd.deskripsi;
            textBox3.Text = mdl.username;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(comboBox1.SelectedValue.ToString());
            int y = int.Parse(comboBox2.SelectedValue.ToString());
            if (textBox3.Text == "")
            {
                MessageBox.Show("Isi Diubah oleh siapa");
            }
            else
            {
                tr.updatetrd(label7.Text,label5.Text,textBox2.Text,y,x,richTextBox1.Text,textBox3.Text);
                tr.datatr();
                dts = tr.dt;
                dv.DataSource = dts;
                this.Hide();
            }
        }
    }
}
