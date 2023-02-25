using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



//Buat Fungsi LOGIN
namespace AplikasiArsipppp
{
   
    public class Login
    {
        
        DataRole cdas = new DataRole();
        Utility cnt = new Utility();

        public string lojin(string username,string password)
        {

            try
            {
                cdas.accessloj(username, password);
                int hasil = cdas.res;
                if ( hasil == 1)
                {
                    return Utility.SUCCESS;
                }
                else
                {                  
                    return Utility.FAIL;
                }                  
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erorr Login" + ex.Message);
            }
            
            return Utility.FAIL_CONNECTION;


        }

    }
}
