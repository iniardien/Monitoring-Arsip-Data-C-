using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiArsipppp
{
    public class Config
    {
        public string connstring = String.Format("Server={0};Port={1};" +
           "User Id={2};Password={3};Database={4}",
           "localhost", 5433, "postgres", "123456", "db_arsip");
    }
}
