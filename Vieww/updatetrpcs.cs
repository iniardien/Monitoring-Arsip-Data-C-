using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AplikasiArsipppp
{
    public partial class updatetrpcs : Form
    {
        ContohModel mpl;
        DataGridView dva;
        Modeltr mtt;
        datatrp trp = new datatrp();
        public DataTable dts;
        public updatetrpcs(ContohModel mdd,DataGridView dv ,Modeltr mtrr)
        {
            InitializeComponent();
            mpl = mdd;
            dva = dv;
            mtt = mtrr;
        }

        private void updatetrpcs_Load(object sender, EventArgs e)
        {
            trp.comboboxkat(comboBox1);
            trp.comboboxprj(comboBox2);
            label8.Text = mtt.id;
            textBox1.Text = mtt.name;
            comboBox1.Text = mtt.katpek;
            comboBox2.Text = mtt.projeck;
            comboBox3.Text = mtt.status;
            richTextBox1.Text = mtt.deskripsi;
            textBox5.Text = mpl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(comboBox1.SelectedValue.ToString());
            int y = int.Parse(comboBox2.SelectedValue.ToString());
            if (textBox5.Text == "")
            {
                MessageBox.Show("Isi Diubah oleh siapa");
            }
            else
            {
                trp.updatetr(label8.Text,textBox1.Text,x,y,comboBox3.Text,richTextBox1.Text,textBox5.Text);
                trp.datatr();
                dts = trp.dt;
                dva.DataSource = dts;
                this.Hide();
            }
        }
    }
}
