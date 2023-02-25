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
    public partial class Detailpekerjaan : Form
    {
        Modeltr mtt;
        Config cnf = new Config();
        datatrp tr = new datatrp();
        DataTable dts;
        public Detailpekerjaan(Modeltr mpr)
        {
            InitializeComponent();
            mtt = mpr;
        }

        private void Detailpekerjaan_Load(object sender, EventArgs e)
        {
            label9.Text = mtt.id;
            label15.Text = mtt.name;
            label16.Text = mtt.projeck;
            label17.Text = mtt.katpek;
            label18.Text = mtt.status;
            richTextBox1.Text = mtt.deskripsi;
            tr.BIND(mtt.id);
            dts = tr.dt;
            dataGridView1.DataSource = dts;
            DATADOWN();
        }

        public void DATADOWN()
        {
            DataGridViewLinkColumn lnkDownload = new DataGridViewLinkColumn();
            lnkDownload.UseColumnTextForLinkValue = true;
            lnkDownload.LinkBehavior = LinkBehavior.SystemDefault;
            lnkDownload.Name = "lnkDownload";
            lnkDownload.HeaderText = "DOWNLOAD";
            lnkDownload.Text = "Download";
            dataGridView1.Columns.Insert(5, lnkDownload);
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(y);
        }

        private void y(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt16((row.Cells[1].Value));
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
    }
}
