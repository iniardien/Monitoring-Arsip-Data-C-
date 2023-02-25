
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiArsipppp
{
    public class ControlButton
    {
        ContohModel mdl = new ContohModel();
        
        public void menu(ContohModel mdl)
        {
            Menu mnu = new Menu(mdl);
            mnu.Show();
        }

        public void dokumen(ContohModel mdl)
        {
            dokumen dkm = new dokumen(mdl);
            dkm.Show();
        }
        public void project(ContohModel mdl)
        {
            project prj = new project(mdl);
            prj.Show();
        }

        public void pekerjaan(ContohModel mdl)
        {
            Pekerjaan pkrj = new Pekerjaan(mdl);
            pkrj.Show();
        }

        public void user(ContohModel mdl)
        {
            User usr = new User(mdl);
            usr.Show();
        }
        public void role(ContohModel mdl)
        {
            Role rl = new Role(mdl);
            rl.Show();
        }

        public void trpekerjaan(ContohModel mdl)
        {
            transaksipekerjaan tp = new transaksipekerjaan(mdl);
            tp.Show();
        }

        public void trdokumen(ContohModel mdl)
        {
            transaksidokumen td = new transaksidokumen(mdl);
            td.Show();
        }

        public void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                //hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }

        }
        
       
       
    }
}
