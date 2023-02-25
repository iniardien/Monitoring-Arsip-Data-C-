
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
    public partial class project : Form
    {

        ControlButton btn = new ControlButton();
        ContohModel mdl = new ContohModel();
        ModelProjek mpk = new ModelProjek();
        DataProject prj = new DataProject();
        DataRole dr = new DataRole();
        private DataTable dts;
        private int rowIndex = -1;
        public project(ContohModel mdr)
        {
            InitializeComponent();
            hideSubMenu();
            mdl = mdr;
        }

        private void project_Load(object sender, EventArgs e)
        {
            label2.Text = mdl.username;
            dr.idrole(label2.Text);
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
            prj.dataproject();
            dts = prj.dt;
            DataPRO.DataSource = dts;
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

        private void btnuser_Click(object sender, EventArgs e)
        {
            btn.user(mdl);
            this.Hide();
        }

        private void btnrole_Click(object sender, EventArgs e)
        {
            btn.role(mdl);
            this.Hide();
        }
        private void hideSubMenu()
        {
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            btn.showSubMenu(Submenupnl);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            btn.showSubMenu(panel3);
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

        private void button3_Click(object sender, EventArgs e)
        {
            btn.project(mdl);
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            prj.nyaridata(textBox2.Text);
            dts = prj.dt;
            DataPRO.DataSource = dts;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            insertprojek ipk = new insertprojek(DataPRO,mdl);
            ipk.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Pilih Data");
            }
            else
            {
                updateprojek upk = new updateprojek(mpk,DataPRO,mdl);
                upk.Show();
            }
        }

        private void klikk(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                mpk.id = DataPRO.Rows[e.RowIndex].Cells["id"].Value.ToString();
                mpk.nama = DataPRO.Rows[e.RowIndex].Cells["nama"].Value.ToString();
                mpk.deskripsi = DataPRO.Rows[e.RowIndex].Cells["deskripsi"].Value.ToString();
            }
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
                    prj.deleteprojek(mpk.id);
                    prj.dataproject();
                    dts = prj.dt;
                    DataPRO.DataSource = dts;
                }
            }
        }
    }
}
