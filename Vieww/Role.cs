
using Arsip;
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
    public partial class Role : Form
    {
        ControlButton btn = new ControlButton();
        DataRole dts = new DataRole();
        SearchBtn cari = new SearchBtn();
        private DataTable dtsa;
        ContohModel mdl = new ContohModel();
        UpdellAcc del = new UpdellAcc();
        private int rowIndex = -1;
        public Role(ContohModel mdr)
        {
            InitializeComponent();
            mdl = mdr;
            hideSubMenu();
        }

        private void Role_Load(object sender, EventArgs e)
        {
            dts.datarole();
            dtsa = dts.dt;
            DataRole.DataSource = dtsa;
            label3.Text = mdl.username;
            dts.idrole(label3.Text);
            label7.Text = dts.idrolecuy;
            dts.namarole(label7.Text);
            label8.Text = dts.namarolecuy;
            if (label8.Text == "Transaksi")
            {
                Mana.Enabled = false;
            }
            else if (label8.Text == "Monitoring")
            {
                Mana.Enabled = false;
                button10.Enabled = false;

            }
        }

        private void hideSubMenu()
        {
            Submenupnl.Visible = false;
            panel6.Visible = false;
        }

        private void Role_Load_1(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            cari.searc(textBox2.Text);
            dtsa = cari.dta;
            DataRole.DataSource = dtsa;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buatinsert insrt = new buatinsert(DataRole,mdl);
            insrt.Show();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Pilih Data");
            }
            else
            {
                buatupdate updt = new buatupdate(mdl,DataRole);
                updt.Show();
            }
        }

        private void klikk(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                mdl.id = DataRole.Rows[e.RowIndex].Cells["id"].Value.ToString();
                mdl.code = DataRole.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                mdl.nama = DataRole.Rows[e.RowIndex].Cells["nama"].Value.ToString();
                mdl.deskripsi = DataRole.Rows[e.RowIndex].Cells["Deskripsi"].Value.ToString();
            }
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            btn.user(mdl);
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btn.pekerjaan(mdl);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn.menu(mdl);
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

        private void btnrole_Click(object sender, EventArgs e)
        {
            btn.role(mdl);
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
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
                    del.delete(mdl.id);
                    dts.datarole();
                    dtsa = dts.dt;
                    DataRole.DataSource = dtsa;
                    
                }
            }
        }
    }
}
