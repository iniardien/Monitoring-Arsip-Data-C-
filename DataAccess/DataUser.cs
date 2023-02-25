

using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ComboBox = System.Windows.Forms.ComboBox;

namespace AplikasiArsipppp
{
    internal class DataUser
    {
        public NpgsqlConnection conn;
        public string sql;
        public NpgsqlCommand cmd;
        public NpgsqlDataAdapter adapt;
        public DataTable dt;
        ContohModel mpl = new ContohModel();
        Config cnfgs = new Config();
            

        public void datauser()
        {

            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"SELECT u.id_user AS ID , u.nama AS NAMA, r.role_name AS NAMAROLE, u.username AS USERNAME, u.password AS PASSWORD, u.deskripsi AS DESKRIPSI
                        FROM public.user as u 
                        INNER JOIN tbl_role as r
                        ON r.id_role = u.id_role where u.delete = 0 ORDER BY id_user ASC";
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
            adapt = new NpgsqlDataAdapter("SELECT  u.id_user as ID ,u.nama AS NAMA," +
                " r.role_name AS NAMAROLE, u.username AS USERNAME, u.password AS PASSWORD," +
                " u.deskripsi AS DESKRIPSI FROM"+
                " public.user as u INNER JOIN tbl_role as r   " +
                " ON r.id_role = u.id_role  where u.delete = 0 AND nama like '" + data + "%' ORDER BY id_user ASC", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            conn.Close();
        }

        public void lojinn(string username)
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"update public.user SET last_login = current_time , tanggal = current_date where username = @username";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.ExecuteScalar();
            conn.Close();
        }
        public void lojout(string username)
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"update public.user SET last_logout = current_time , tanggalkeluar = current_date where username = @username";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.ExecuteScalar();
            conn.Close();
        }

        public void combobox(ComboBox cmb)
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"select id_role , role_name from tbl_role WHERE delete = 0 ORDER BY id_role ASC ";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("role_name",typeof(string));
                dt.Load(reader);
                //createuser usr = new createuser();
                cmb.DisplayMember = "role_name";
                cmb.ValueMember = "id_role";
                cmb.DataSource = dt;
                
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("EROR CUY"+ex);
            }
        }

        public void historyuser()
        {
            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"SELECT u.nama AS NAMA, r.role_name AS NAMAROLE, u.username AS USERNAME , u.tanggal AS LASTLOJIN , u.last_login AS JAM , u.tanggalkeluar AS LASTLOJOUT , u.last_logout AS JAM2
                        FROM public.user as u
                        INNER JOIN tbl_role as r
                        ON r.id_role = u.id_role where u.delete = 0 ORDER BY id_user ASC";
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
        public void insertuser(string nama,int role, string username, string password , string deskripsi ,string dibuat)
        {

            try
            {
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"insert into public.user(nama,id_role,username,password,deskripsi,created_by,created_at,delete) 
                        values (@nama,@role,@username,@password,@deskripsi,@dibuat,current_time,0)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@role",role);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
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
    }
}
