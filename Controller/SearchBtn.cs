using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AplikasiArsipppp
{
    
    public class SearchBtn
    {
        DataRole cda = new DataRole();
        public NpgsqlDataAdapter adapt;
        public DataTable dta;

        public void searc(string data)
        {
            cda.nyaridata(data);
            dta = new DataTable();
            adapt = cda.adapt;
            adapt.Fill(dta);

        }
       
    }
}
