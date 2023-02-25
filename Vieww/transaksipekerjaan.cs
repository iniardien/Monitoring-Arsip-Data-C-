
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
    public partial class transaksipekerjaan : Form
    {
        ContohModel mdl = new ContohModel();
        ControlButton btn = new ControlButton();
        DataRole dr = new DataRole();
        datatrp tr = new datatrp();
        Modeltr mtr = new Modeltr();
        private int rowIndex = -1;
        private DataTable dts;
        public transaksipekerjaan(ContohModel mdr)
        {
            InitializeComponent();
            hideSubMenu();
            mdl = mdr;
        }

        private void transaksipekerjaan_Load(object sender, EventArgs e)
        {
            tr.datatr();
            dts = tr.dt;
            dataGridView1.DataSource = dts;
            label2.Text = mdl.username;
            dr.idrole(label2.Text);
            label3.Text = dr.idrolecuy;
            dr.namarole(label3.Text);
            label4.Text = dr.namarolecuy;
            if (label4.Text == "Transaksi")
            {
                Mana.Enabled = false;
            }
            else if (label4.Text == "Monitoring")
            {
                Mana.Enabled = false;
                button10.Enabled = false;

            }
            
        }
        private void hideSubMenu()
        {
            Submenupnl.Visible = false;
            panel4.Visible = false;
        }

        private void transaksipekerjaan_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn.menu(mdl);
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btn.pekerjaan(mdl);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btn.dokumen(mdl);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btn.project(mdl);
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            btn.trpekerjaan(mdl);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn.trdokumen(mdl);
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            btn.showSubMenu(Submenupnl);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            btn.showSubMenu(panel6);
        }

        private void Mana_Click(object sender, EventArgs e)
        {
            btn.showSubMenu(panel4);
        }

        private void btnrole_Click(object sender, EventArgs e)
        {
            btn.role(mdl);
            this.Hide();
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            btn.user(mdl);
            this.Hide();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tr.nyaridatatr(textBox2.Text);
            dts = tr.dt;
            dataGridView1.DataSource = dts;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            inserttrp trp = new inserttrp(mdl,dataGridView1);
            trp.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "All")
            {
                tr.datatr();
                dts = tr.dt;
                dataGridView1.DataSource = dts;
            }
            else
            {
                tr.filterdata(comboBox1.Text);
                dts = tr.dt;
                dataGridView1.DataSource = dts;
            }
           
        }

        private void klikk(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                mtr.id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                mtr.name = dataGridView1.Rows[e.RowIndex].Cells["nama"].Value.ToString();
                mtr.katpek = dataGridView1.Rows[e.RowIndex].Cells["katpek"].Value.ToString();
                mtr.projeck = dataGridView1.Rows[e.RowIndex].Cells["projek"].Value.ToString();
                mtr.status = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();
                mtr.deskripsi = dataGridView1.Rows[e.RowIndex].Cells["deskripsi"].Value.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Pilih Data");
            }
            else
            {
                if (MessageBox.Show("Benarkah Anda Ingin Menghapus data ini ???", "Konfirmasi",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tr.deletedata(mtr.id);
                    tr.datatr();
                    dts = tr.dt;
                    dataGridView1.DataSource = dts;
                    
                }
            };
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Pilih Data");
            }
            else
            {
                updatetrpcs upt = new updatetrpcs(mdl,dataGridView1,mtr);
                upt.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(rowIndex < 0)
            {
                MessageBox.Show("Pilih Data");
            }
            else
            {
                Detailpekerjaan dpk = new Detailpekerjaan(mtr);
                dpk.Show();
            }
            
        }
    }
}
