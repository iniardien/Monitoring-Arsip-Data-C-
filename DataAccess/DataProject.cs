
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
    public class DataProject
    {
        public NpgsqlConnection conn;
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataAdapter adapt;
        public DataTable dt;
        Config cnfgs = new Config();


        public void dataproject()
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"select id_project AS ID ,project_code AS CODEPROJECT, project_name AS NAMAPROJECT, deskripsi AS DESKRIPSI from md_project WHERE delete = 0 order by id_project ASC";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        public void nyaridata(string data)
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            adapt = new NpgsqlDataAdapter("select id_project AS ID ,project_code AS CODEPROJECT, project_name AS NAMAPROJECT, deskripsi AS DESKRIPSI from md_project WHERE delete = 0" +
                " AND project_name like '" + data + "%' ORDER BY id_project ASC", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            conn.Close();
        }

        public void insertprojek(string nama, string deskripsi, string dibuat)
        {

            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"insert into md_project(project_name,deskripsi,created_at,created_by,delete) values (@nama,@deskripsi,current_time ,@dibuat,0)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@deskripsi", deskripsi);
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

        public void updateprojek(string id, string nama, string deskripsi, string modif)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE md_project
                SET project_name = @nama, deskripsi = @deskripsi, modified_by = @modif , modified_at = current_time
                WHERE id_project = @id";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.Parameters.AddWithValue("@nama", nama);
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

        public void deleteprojek(string id)
        {
            try
            {

                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE md_project
                SET delete = 1
                WHERE id_project = @id";
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

    }
}
