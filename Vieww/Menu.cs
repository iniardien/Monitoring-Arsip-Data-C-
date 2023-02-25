using Arsip;
using Npgsql;
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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace AplikasiArsipppp
{
    public partial class Menu : Form
    {
        public NpgsqlConnection conn;
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataAdapter adapt;
        public DataTable dt;
        Config cnfgs = new Config();
        ControlButton btn = new ControlButton();
        ContohModel mdl = new ContohModel();
        DataUser du = new DataUser();
        DataRole dr = new DataRole();
        DataMenu dmu = new DataMenu();
        public Menu(ContohModel mdr)
        {
            InitializeComponent();
            hideSubMenu();
            mdl = mdr;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //BuatISI UTAMA
            dmu.totalpekerjaan();
            label7.Text = dmu.totalpkj;
            dmu.statuson();
            label10.Text = dmu.onpro;
            dmu.statusf();
            label11.Text = dmu.finis;
            dmu.totaldokumen();
            label14.Text = dmu.dokumen;
            dmu.totaluser();
            label15.Text = dmu.user;
            label2.Text = mdl.username;

            //buat pembagian role
            dr.idrole(label2.Text);
            label3.Text = dr.idrolecuy;
            dr.namarole(label3.Text);
            label4.Text = dr.namarolecuy;
            if (label4.Text == "Transaksi")
            {
                Mana.Enabled = false;
                button7.Enabled = false;
            }
            else if(label4.Text == "Monitoring")
            {
                Mana.Enabled = false;
                button10.Enabled = false;
                button7.Enabled = false;
            }
            grafik();

        }

        private void grafik()
        {
            int progres = int.Parse(label10.Text);
            int finish = int.Parse(label11.Text);
            pieChart1.AnimationsSpeed = TimeSpan.FromMilliseconds(3000);
            pieChart1.Series = new ISeries[]
            {
                new PieSeries<int> {
                    Values = new int[] {finish} ,
                    Name = "Finish" ,
                    


                },
                new PieSeries<int> {
                    Values = new int[] { progres } ,
                    Name = "On Progres",
                    


                },

             };
        }
        
        private void project_Click(object sender, EventArgs e)
        {
            btn.project(mdl);
            this.Hide();
        }

        private void katpkrj_Click(object sender, EventArgs e)
        {
            btn.pekerjaan(mdl);
            this.Hide();
        }
        private void hideSubMenu()
        {
            Submenupnl.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn.menu(mdl);
            this.Hide();
        }

        private void katdok_Click(object sender, EventArgs e)
        {
            btn.dokumen(mdl);
            this.Hide();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Benarkah Anda Ingin Keluar  dari aplikasi ini ???", "Konfirmasi",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                login Vrm = new login();
                du.lojout(label2.Text);
                Vrm.Show();
                this.Hide();
            }
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
            btn.showSubMenu(panel3);
        }

        private void Mana_Click(object sender, EventArgs e)
        {
            btn.showSubMenu(panel4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btn.user(mdl);
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btn.trdokumen(mdl);
            this.Hide();
        }
    }
}
