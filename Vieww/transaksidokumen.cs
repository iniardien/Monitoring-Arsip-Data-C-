
using Npgsql;
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
    public partial class transaksidokumen : Form
    {
        ContohModel mdl = new ContohModel();
        ControlButton btn = new ControlButton();
        datatrd tr = new datatrd();
        DataRole dr = new DataRole();
        DataTable dts;
        private int rowIndex = -1;
        modeltrdok mtd = new modeltrdok();
        Config cnf = new Config();
        public transaksidokumen(ContohModel mdr)
        {
            InitializeComponent();
            mdl = mdr;
            hideSubMenu();
        }
        private void hideSubMenu()
        {
            Submenupnl.Visible = false;
            panel4.Visible = false;
        }

        public void DATADOWN()
        {
            DataGridViewLinkColumn lnkDownload = new DataGridViewLinkColumn();
            lnkDownload.UseColumnTextForLinkValue = true;
            lnkDownload.LinkBehavior = LinkBehavior.SystemDefault;
            lnkDownload.Name = "lnkDownload";
            lnkDownload.HeaderText = "DOWNLOAD";
            lnkDownload.Text = "Download";
            dataGridView1.Columns.Insert(7, lnkDownload);
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(y);
        }


        private void transaksidokumen_Load(object sender, EventArgs e)
        {
            DATADOWN();
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

        private void button8_Click(object sender, EventArgs e)
        {
            inputtrdok tr = new inputtrdok(mdl,dataGridView1);
            tr.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void klik(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                mtd.id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                mtd.namapekerjaan = dataGridView1.Rows[e.RowIndex].Cells["nama"].Value.ToString();
                mtd.namadokumen = dataGridView1.Rows[e.RowIndex].Cells["namadok"].Value.ToString();
                mtd.katdok = dataGridView1.Rows[e.RowIndex].Cells["katdok"].Value.ToString();
                mtd.dokumen = dataGridView1.Rows[e.RowIndex].Cells["dokumen"].Value.ToString();
                mtd.deskripsi = dataGridView1.Rows[e.RowIndex].Cells["deskripsi"].Value.ToString();
                mtd.iddok = dataGridView1.Rows[e.RowIndex].Cells["iddok"].Value.ToString();

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
                    tr.deletedata(mtd.id);
                    tr.datatr();
                    dts = tr.dt;
                    dataGridView1.DataSource = dts;

                }
            };
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tr.nyaridatatrd(textBox2.Text);
            dts = tr.dt;
            dataGridView1.DataSource = dts;
        }

        private void y(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt16((row.Cells["iddok"].Value));
                byte[] bytes;
                string fileName, contentType;
                string connstring = cnf.connstring;
                using (NpgsqlConnection con = new NpgsqlConnection(connstring))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.CommandText = "select Name, Data, ContentType from doc where Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Connection = con;
                        con.Open();
                        using (NpgsqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["Name"].ToString();

                            Stream stream;
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "All files (*.*)|*.*";
                            saveFileDialog.FilterIndex = 1;
                            saveFileDialog.RestoreDirectory = true;
                            saveFileDialog.FileName = fileName;
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                stream = saveFileDialog.OpenFile();
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Close();
                                MessageBox.Show("Download Sukses");

                            }
                        }
                    }
                    con.Close();
                }
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
                updatetrdok utd = new updatetrdok(mdl,dataGridView1,mtd);
                utd.Show();
                
            }
        }
    }
}
