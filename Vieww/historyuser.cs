
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiArsipppp
{
    public partial class historyuser : Form
    {
        DataUser usr = new DataUser();
        private DataTable dts;
        public historyuser()
        {
            InitializeComponent();
        }

        private void historyuser_Load(object sender, EventArgs e)
        {
            usr.historyuser();
            dts = usr.dt;
            dataGridView1.DataSource = dts;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
