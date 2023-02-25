using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AplikasiArsipppp
{
    public class datatrp
    {
        public NpgsqlConnection conn;
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataAdapter adapt;
        public DataTable dt;
        ContohModel mpl = new ContohModel();
        Config cnfgs = new Config();
        public void datatr()
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"SELECT tr.id_pekerjaan AS ID ,pj.project_name AS NAMAPJ, tr.nama_pekerjaan AS NAMAPK, kpr.kategori_pekerjaan_name AS KATPK, tr.deskripsi AS DESKRIPSI, tr.status AS STATUS
                        FROM tr_pekerjaan as tr 
                        INNER JOIN md_kategori_pekerjaan as kpr
                        ON kpr.id_kategori_pekerjaan = tr.id_kategori_pekerjaan
						INNER JOIN md_project as pj
						ON pj.id_project = tr.id_project
						WHERE tr.delete =0 ORDER BY id_pekerjaan ASC";
            cmd = new NpgsqlCommand(sql, conn);
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
        }

        public void nyaridatatr(string data)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                adapt = new NpgsqlDataAdapter("SELECT tr.id_pekerjaan AS ID ,pj.project_name AS NAMAPJ, tr.nama_pekerjaan AS NAMAPK, kpr.kategori_pekerjaan_name AS KATPK, tr.deskripsi AS DESKRIPSI, tr.status AS STATUS " +
                    "FROM tr_pekerjaan as tr INNER JOIN md_kategori_pekerjaan as kpr " +
                    "ON kpr.id_kategori_pekerjaan = tr.id_kategori_pekerjaan " +
                    "INNER JOIN md_project as pj " +
                    "ON pj.id_project = tr.id_project " +
                    "WHERE tr.delete = 0 AND tr.nama_pekerjaan like '" + data + "%'  ORDER BY id_pekerjaan ASC", conn);
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
        public void inserttrp(int katpek, int project, string nama, string deskripsi, string status, string dibuat)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"insert into tr_pekerjaan(id_kategori_pekerjaan,id_project,nama_pekerjaan,deskripsi,status,created_by,created_at,delete) 
                        values (@katpek,@project,@nama,@deskripsi,@status,@dibuat,current_time,0)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@katpek", katpek);
                cmd.Parameters.AddWithValue("@project", project);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@deskripsi", deskripsi);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@dibuat", dibuat);
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

        public void comboboxkat(ComboBox cmb)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"select id_kategori_pekerjaan , kategori_pekerjaan_name from md_kategori_pekerjaan WHERE delete = 0 ORDER BY id_kategori_pekerjaan ASC ";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("kategori_pekerjaan_name", typeof(string));
                dt.Load(reader);
                //createuser usr = new createuser();
                cmb.DisplayMember = "kategori_pekerjaan_name";
                cmb.ValueMember = "id_kategori_pekerjaan";
                cmb.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EROR CUY" + ex);
            }
        }
        public void comboboxprj(ComboBox cmb)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"select id_project , project_name from md_project WHERE delete = 0 ORDER BY id_project ASC ";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("project_name", typeof(string));
                dt.Load(reader);
                //createuser usr = new createuser();
                cmb.DisplayMember = "project_name";
                cmb.ValueMember = "id_project";
                cmb.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EROR CUY" + ex);
            }

        }
        public void filterdata(string data)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                adapt = new NpgsqlDataAdapter("SELECT tr.id_pekerjaan AS ID ,pj.project_name AS NAMAPJ, tr.nama_pekerjaan AS NAMAPK, kpr.kategori_pekerjaan_name AS KATPK, tr.deskripsi AS DESKRIPSI, tr.status AS STATUS " +
                    "FROM tr_pekerjaan as tr INNER JOIN md_kategori_pekerjaan as kpr " +
                    "ON kpr.id_kategori_pekerjaan = tr.id_kategori_pekerjaan " +
                    "INNER JOIN md_project as pj " +
                    "ON pj.id_project = tr.id_project " +
                    "WHERE tr.delete = 0 AND tr.status like '" + data + "%'  ORDER BY id_pekerjaan ASC", conn);
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
        public void deletedata(string id)
        {
            try
            {

                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE tr_pekerjaan
                SET delete = 1
                WHERE id_pekerjaan = @id";
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

        public void updatetr(string id, string nama, int katpek, int projek, string status, string deskripsi, string modif)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE tr_pekerjaan
                SET nama_pekerjaan = @nama, id_kategori_pekerjaan =@katpek , id_project = @projek , status = @status, deskripsi = @deskripsi, modified_by = @modif , modified_at = current_time
                WHERE id_pekerjaan = @id";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@katpek", katpek);
                cmd.Parameters.AddWithValue("@projek", projek);
                cmd.Parameters.AddWithValue("@status", status);
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
        public void BIND(string id)
        {

            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"SELECT tr.id_transaksi AS ID ,kpr.id AS IDDOC ,pj.nama_pekerjaan AS NAMAPJ, tr.document_name AS NAMADK, kpr.name AS DOK
                        FROM tr_upload_document as tr 
                        INNER JOIN public.doc as kpr
                        ON kpr.id = tr.id_dok
						INNER JOIN tr_pekerjaan as pj
						ON pj.id_pekerjaan = tr.id_pekerjaan
						WHERE tr.delete =0 AND pj.id_pekerjaan = @id ORDER BY id_transaksi ASC";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(id));
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

        }
    }
}
