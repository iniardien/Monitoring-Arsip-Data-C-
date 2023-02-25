using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using System.Drawing;
using NpgsqlTypes;
using System.Reflection.Emit;



namespace AplikasiArsipppp
{
    internal class DataRole
    {
        public NpgsqlConnection conn;
        public string sql;
        public string idrolecuy;
        public string namarolecuy;
        public NpgsqlCommand cmd;
        public int res;
        public DataTable dt;
        public NpgsqlDataAdapter adapt;
        Config cnfgs = new Config();
        


        public void accessloj(string username, string password)
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"select * from st_login(:_username ,:_password) ";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("_username", username);
            cmd.Parameters.AddWithValue("_password", password);
            res = (int)cmd.ExecuteScalar();
            conn.Close();

        }

        public int getResult()
        { 
            return res; 
        }

        

        public void datarole()
        {
            try
            {
               
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"select id_role as ID ,
                code_role as CODEROLE ,role_name as NAMAROLE,deskripsi as DESKRIPSI from tbl_role where delete = 0 ORDER BY id_role ASC";
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
            adapt = new NpgsqlDataAdapter("select id_role as ID , code_role as CODEROLE ,role_name as NAMAROLE,deskripsi as DESKRIPSI from tbl_role where delete = 0 AND role_name like '" + data + "%'ORDER BY id_role ASC ", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            conn.Close();
        }

        public void insert(string nama, string deskripsi, string dibuat)
        {
            
            try
            {
     
                string connstring = cnfgs.connstring;
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = @"insert into tbl_role(role_name,deskripsi,created_at,created_by,delete) values (@role_name,@deskripsi,current_time,@created_by,0)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@role_name", nama);
                cmd.Parameters.AddWithValue("@deskripsi", deskripsi);
                cmd.Parameters.AddWithValue("@created_by", dibuat);
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

        public void idrole(string label2)
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"select id_role from public.user WHERE username = @username";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", label2);
            idrolecuy = (string)cmd.ExecuteScalar().ToString();
            conn.Close();
        }

        public void namarole(string label3)
        {
            conn.Open();
            sql = @"select role_name from tbl_role WHERE id_role = @id";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", int.Parse(label3));
            namarolecuy = (string)cmd.ExecuteScalar().ToString();
            conn.Close();
        }



    }
}
