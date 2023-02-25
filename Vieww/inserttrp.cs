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
    public partial class inserttrp : Form
    {
        datatrp trp = new datatrp();
        ContohModel mpl = new ContohModel();
        DataGridView dv;
        private DataTable dtsa;
        public inserttrp(ContohModel mdl,DataGridView dva)
        {
            InitializeComponent();
            mpl = mdl;
            dv = dva;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inserttrp_Load(object sender, EventArgs e)
        {
            trp.comboboxprj(comboBox1);
            trp.comboboxkat(comboBox2);
            textBox5.Text = mpl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(comboBox1.SelectedValue.ToString());
                int y = int.Parse(comboBox2.SelectedValue.ToString());
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Isi Nama Pekerjaan ");
                }
                else if (richTextBox1.Text == "")
                {
                    MessageBox.Show("Isi Deskripsi");

                }
                else if (comboBox3.Text == "")
                {
                    MessageBox.Show("Isi Status ");

                }
                else
                {
                    trp.inserttrp(y, x, textBox1.Text, richTextBox1.Text, comboBox3.Text, textBox5.Text);
                    trp.datatr();
                    dtsa = trp.dt;
                    dv.DataSource = dtsa;
                    this.Hide();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("ERORR SU" + ex);
            }
        }
    }
}
