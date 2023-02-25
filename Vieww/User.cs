
using Arsip;
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
    public partial class User : Form
    {
        ControlButton btn = new ControlButton();
        DataUser usr = new DataUser();
        DataRole dr = new DataRole();
        ContohModel mdl = new ContohModel();
        ModelUser mpl = new ModelUser();
        UpdellAcc del = new UpdellAcc();
        private int rowIndex = -1;
        private DataTable dtsa;
        public User(ContohModel mdr)
        {
            InitializeComponent();
            hideSubMenu();
            mdl = mdr;
        }

        private void hideSubMenu()
        {
            Submenupnl.Visible = false;
            panel6.Visible = false;

        }

        private void User_Load(object sender, EventArgs e)
        {
            usr.datauser();
            dtsa = usr.dt;
            DataUser.DataSource = dtsa;
            label3.Text = mdl.username;
            dr.idrole(label3.Text);
            label4.Text = dr.idrolecuy;
            dr.namarole(label4.Text);
            label5.Text = dr.namarolecuy;
            if (label5.Text == "Transaksi")
            {
                Mana.Enabled = false;
            }
            else if (label5.Text == "Monitoring")
            {
                Mana.Enabled = false;
                button10.Enabled = false;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            usr.nyaridata(textBox2.Text);
            dtsa = usr.dt;
            DataUser.DataSource = dtsa;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            historyuser vrm = new historyuser();
            vrm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            createuser crtus = new createuser(DataUser,mdl);
            crtus.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Pilih Data");
            }
            else
            {
                updateuser updtusr = new updateuser(mpl,DataUser,mdl);
                updtusr.Show();
            }

        }

        private void button10_Click(object sender, EventArgs e)
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
                    del.deleteuser(mpl.id);
                    usr.datauser();
                    dtsa = usr.dt;
                    DataUser.DataSource = dtsa;
                }
            };
        }

        private void klikk(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                mpl.id = DataUser.Rows[e.RowIndex].Cells["id"].Value.ToString();
                mpl.namauser = DataUser.Rows[e.RowIndex].Cells["nama_user"].Value.ToString();
                mpl.role = DataUser.Rows[e.RowIndex].Cells["nama_role"].Value.ToString();
                mpl.username = DataUser.Rows[e.RowIndex].Cells["username"].Value.ToString();
                mpl.password = DataUser.Rows[e.RowIndex].Cells["password"].Value.ToString();
                mpl.deskripsi = DataUser.Rows[e.RowIndex].Cells["deskripsi"].Value.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
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

        private void btnrole_Click(object sender, EventArgs e)
        {
            btn.role(mdl);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void btnuser_Click(object sender, EventArgs e)
        {

            btn.user(mdl);
            this.Hide();
        }
    }
}
