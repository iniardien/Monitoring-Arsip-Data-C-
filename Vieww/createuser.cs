
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class createuser : Form
    {
        DataUser dus = new DataUser();
        DataGridView dva;
        DataTable dtsa;
        ContohModel mdl;
        public createuser(DataGridView dv,ContohModel mdr)
        {
            InitializeComponent();
            dva = dv;
            mdl = mdr;
        }

        private void createuser_Load(object sender, EventArgs e)
        {
            dus.combobox(comboBox1);
            textBox5.Text = mdl.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(comboBox1.SelectedValue.ToString());
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Isi Nama Anda ");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Isi username ");

                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Isi Password ");

                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Isi Deskripsi ");

                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Isi Dibuat Oleh ");
                }
                else
                {
                    dus.insertuser(textBox1.Text, x, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                    dus.datauser();
                    dtsa = dus.dt;
                    dva.DataSource = dtsa;
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERORR SU" + ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

