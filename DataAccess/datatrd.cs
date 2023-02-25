using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiArsipppp
{
    public class datatrd
    {
        public NpgsqlConnection conn;
        public string sql;
        public NpgsqlCommand cmd;
        public string iddok;
        public NpgsqlDataAdapter adapt;
        public DataTable dt;
        ContohModel mpl = new ContohModel();
        Config cnfgs = new Config();

        public void datatr()
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"SELECT tr.id_transaksi AS ID,kpr.id AS IDDOK ,pj.nama_pekerjaan AS NAMAPJ, tr.document_name AS NAMADK,pdkt.kategori_dokumen_name AS KATDOK, kpr.name AS DOK, tr.deskripsi AS DESK
                        FROM tr_upload_document as tr 
                        INNER JOIN public.doc as kpr
                        ON kpr.id = tr.id_dok
						INNER JOIN tr_pekerjaan as pj
						ON pj.id_pekerjaan = tr.id_pekerjaan
                        INNER JOIN md_kategori_dokumen as pdkt
						ON pdkt.id_kategori_dokumen = tr.id_kategori_dokumen
						WHERE tr.delete = 0 ORDER BY id_transaksi ASC";
            cmd = new NpgsqlCommand(sql, conn);
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
        }

        public void comboboxp(ComboBox cmb)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"select id_pekerjaan , nama_pekerjaan from tr_pekerjaan WHERE delete = 0 ORDER BY id_pekerjaan ASC ";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("nama_pekerjaan", typeof(string));
                dt.Load(reader);
                //createuser usr = new createuser();
                cmb.DisplayMember = "nama_pekerjaan";
                cmb.ValueMember = "id_pekerjaan";
                cmb.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EROR CUY" + ex);
            }
        }
        public void inserttrd(int pek,int katdok, int dok, string nama, string deskripsi, string dibuat)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"insert into tr_upload_document(id_pekerjaan,id_kategori_dokumen,id_dok,document_name,deskripsi,created_by,created_at,delete) 
                        values (@pekerjaan,@katdok,@dok,@nama,@deskripsi,@dibuat,current_time,0)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pekerjaan", pek);
                cmd.Parameters.AddWithValue("@dok", dok);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@deskripsi", deskripsi);
                cmd.Parameters.AddWithValue("@dibuat", dibuat);
                cmd.Parameters.AddWithValue("@katdok", katdok);

                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Data Berhasil di Input");

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Inserted Fail.Erorr : " + ex.Message);
            };
        }

        public void iddokumen(string label)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"select id from public.doc WHERE name = @name";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", label);
                iddok = (string)cmd.ExecuteScalar().ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        public void comboboxkatdok(ComboBox cmb)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"select id_kategori_dokumen , kategori_dokumen_name from md_kategori_dokumen WHERE delete = 0 ORDER BY id_kategori_dokumen ASC ";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("kategori_dokumen_name", typeof(string));
                dt.Load(reader);
                //createuser usr = new createuser();
                cmb.DisplayMember = "kategori_dokumen_name";
                cmb.ValueMember = "id_kategori_dokumen";
                cmb.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EROR CUY" + ex);
            }
        }

        public void deletedata(string id)
        {
            try
            {

                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE tr_upload_document
                SET delete = 1
                WHERE id_transaksi = @id";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Delete Success");


            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Delete Fail.Erorr : " + ex.Message);
            };
        }
        public void nyaridatatrd(string data)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"SELECT tr.id_transaksi AS ID ,kpr.id AS IDDOK,pj.nama_pekerjaan AS NAMAPJ, tr.document_name AS NAMADK,pdkt.kategori_dokumen_name AS KATDOK, kpr.name AS DOK, tr.deskripsi AS DESK
                        FROM tr_upload_document as tr 
                        INNER JOIN public.doc as kpr
                        ON kpr.id = tr.id_dok
						INNER JOIN tr_pekerjaan as pj
						ON pj.id_pekerjaan = tr.id_pekerjaan
                        INNER JOIN md_kategori_dokumen as pdkt
						ON pdkt.id_kategori_dokumen = tr.id_kategori_dokumen
						WHERE tr.delete = 0 AND tr.document_name like '" + data + "%'   ORDER BY id_transaksi ASC";
                adapt = new NpgsqlDataAdapter(sql, conn);
                dt = new DataTable();
                adapt.Fill(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error :" + ex.Message);
            }

        }
        public void updatetrd(string id, string iddok, string namadokumen, int katdok, int pekerjaan, string deskripsi, string modif)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE tr_upload_document
                SET document_name = @namadokumen,id_dok = @iddok, id_kategori_dokumen = @katdok , id_pekerjaan = @pekerjaan, deskripsi = @deskripsi, modified_by = @modif , modified_at = current_time
                WHERE id_transaksi = @id";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.Parameters.AddWithValue("@namadokumen", namadokumen);
                cmd.Parameters.AddWithValue("@katdok", katdok);
                cmd.Parameters.AddWithValue("@pekerjaan", pekerjaan);
                cmd.Parameters.AddWithValue("@iddok", int.Parse(iddok));
                cmd.Parameters.AddWithValue("@deskripsi", deskripsi);
                cmd.Parameters.AddWithValue("@modif", modif);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Update Success");
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Update Fail.Erorr : " + ex.Message);
            };
        }
    }
}
