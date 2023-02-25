using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiArsipppp
{
    public class DataMenu
    {
        public NpgsqlConnection conn;
        public string sql;
        public string totalpkj;
        public string onpro;
        public string finis;
        public string user;

        public string dokumen;


        public NpgsqlCommand cmd;
        public int res;
        public DataTable dt;
        public NpgsqlDataAdapter adapt;
        Config cnfgs = new Config();
        public void totalpekerjaan()
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"SELECT COUNT(id_pekerjaan)
                    FROM tr_pekerjaan
                    WHERE delete = 0;";
            cmd = new NpgsqlCommand(sql, conn);
            totalpkj = (string)cmd.ExecuteScalar().ToString();
            conn.Close();
        }

        public void statuson()
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"SELECT COUNT(id_pekerjaan)
                    FROM tr_pekerjaan
                    WHERE delete = 0 AND status ='On Progres';";
            cmd = new NpgsqlCommand(sql, conn);
            onpro = (string)cmd.ExecuteScalar().ToString();
            conn.Close();
        }
        public void statusf()
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"SELECT COUNT(id_pekerjaan)
                    FROM tr_pekerjaan
                    WHERE delete = 0 AND status ='Finish';";
            cmd = new NpgsqlCommand(sql, conn);
            finis = (string)cmd.ExecuteScalar().ToString();
            conn.Close();
        }

        public void totaldokumen()
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"SELECT COUNT(id_transaksi)
                    FROM tr_upload_document
                    WHERE delete = 0;";
            cmd = new NpgsqlCommand(sql, conn);
            dokumen = (string)cmd.ExecuteScalar().ToString();
            conn.Close();
        }

        public void totaluser()
        {
            string connstring = cnfgs.connstring;
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = @"SELECT COUNT(id_user)
                    FROM public.user
                    WHERE delete = 0;";
            cmd = new NpgsqlCommand(sql, conn);
            user = (string)cmd.ExecuteScalar().ToString();
            conn.Close();
        }
    }
}
