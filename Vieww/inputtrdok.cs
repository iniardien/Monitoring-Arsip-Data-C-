using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AplikasiArsipppp
{
    public partial class inputtrdok : Form
    {
        DataTable dt;
        int seqCode = -1;
        Config cnf = new Config();
        datatrd tr = new datatrd();
        ContohModel mpl = new ContohModel();
        DataGridView dv;
        public inputtrdok(ContohModel mdll,DataGridView dva)
        {
            InitializeComponent();
            mpl = mdll;
            dv = dva;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All File (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName;
                    byte[] bytes = File.ReadAllBytes(fileName);
                    string contentType = "";
                    //Set the contenttype based on File Extension

                    switch (Path.GetExtension(fileName))
                    {
                        case ".jpg":
                            contentType = "image/jpeg";
                            break;
                        case ".png":
                            contentType = "image/png";
                            break;
                        case ".gif":
                            contentType = "image/gif";
                            break;
                        case ".bmp":
                            contentType = "image/bmp";
                            break;
                    }
                    try
                    {
                        string connstring = cnf.connstring;
                        using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
                        {

                            string sql = "INSERT INTO doc(Name,ContentType,Data) VALUES(@Name, @ContentType, @Data)";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@Name", Path.GetFileName(fileName));
                                cmd.Parameters.AddWithValue("@ContentType", contentType);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                textBox1.Text = Path.GetFileName(openFileDialog1.FileName);
                                tr.iddokumen(textBox1.Text);
                                label5.Text = tr.iddok;
                                
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Gagal, Silahkan Ganti File/Nama File" );
                    }
                    
                    //this.BIND();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            SaveFileDialog sfd = new SaveFileDialog(); 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string strFileToSave = sfd.FileName;
                FileStream objFileStream = new FileStream(strFileToSave, FileMode.Create, FileAccess.Write);
                
                //File.WriteAllBytes(sfd.FileName, );
                objFileStream.Close();


            }
        }

        private void inputtrdok_Load(object sender, EventArgs e)
        {
            
            tr.comboboxp(comboBox1);
            tr.comboboxkatdok(comboBox2);
            textBox3.Text = mpl.username;
            
        }

        

        private void y(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            int x = int.Parse(comboBox1.SelectedValue.ToString());
            int y = int.Parse(label5.Text.ToString());
            int z = int.Parse(comboBox2.SelectedValue.ToString());
            if (textBox2.Text == "")
            {
                MessageBox.Show("Isi Nama Dokumen ");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Isi Deskripsi");

            }
            else if (richTextBox1.Text == "")
            {
                MessageBox.Show("Upload Dokumen ");

            }
            else
            {
                tr.inserttrd(x, z, y, textBox2.Text, richTextBox1.Text, textBox3.Text);
                tr.datatr();
                dt = tr.dt;
                dv.DataSource = dt;
                this.Hide();
            }
            
        }
    }
}
