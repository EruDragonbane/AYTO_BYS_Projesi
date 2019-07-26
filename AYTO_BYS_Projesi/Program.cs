using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
namespace AYTO_BYS_Projesi
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        public static SqlConnection dataBaseConnection = new SqlConnection("server=ERU; Initial Catalog=deneme;Integrated Security=SSPI");

        [STAThread]

        static void Main()
        {
            //Uygulamanın aktifliğini kontrol ederek ikinci bir uygulamanın açılmasını önler. //Mutex kavramı//
            bool exeIsOpenOrNot = false;
            Mutex mtx = new Mutex(true, "Program", out exeIsOpenOrNot);
            if (exeIsOpenOrNot)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GirisEkrani());
            }
            else
            {
                MessageBox.Show("Uygulama zaten çalışıyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
