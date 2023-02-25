
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
    public class UpdellAcc
    {
        public NpgsqlConnection conn;
        public string sql;
        public NpgsqlCommand cmd;
        Config cnfgs = new Config();
        DataRole dts = new DataRole();
        public DataTable dtsc;
        
        
        public void update(string id ,string code,string nama ,string deskripsi ,string modif)
        {

            try
            {

                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE tbl_role
                SET role_name = @nama, deskripsi = @deskripsi, modified_by = @modif , modified_at = current_time
                WHERE id_role = @id";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.Parameters.AddWithValue("@code",code);
                cmd.Parameters.AddWithValue("@nama",nama);
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
        public void delete(string id)
        {
            try
            {

                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE tbl_role
                SET delete = 1
                WHERE id_role = @id";
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
        public void deleteuser(string id)
        {
            try
            {

                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE public.user
                SET delete = 1
                WHERE id_user = @id";
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
        public void updateuser(string namauser,string id, int namarole, string username,string password, string deskripsi, string modif)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"UPDATE public.user
                SET nama = @namauser, username =@username , password = @password , id_role = @nama, deskripsi = @deskripsi, modified_by = @modif , modified_at = current_time
                WHERE id_user = @id";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@namauser", namauser);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@nama", namarole);
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
