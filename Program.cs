using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_app3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static string ConvertDate(string date, bool time = false)
        {
            if (time)
            {
                string[] date_list = date.Split('-');
                string hours_minutes = date_list[2].Split(' ')[1];
                string year = date_list[2].Split(' ')[0];
                return year + "-" + date_list[1] + "-" + date_list[0] + " " + hours_minutes;
            }

            else
            {
                string[] date_list = date.Split('-');
                return date_list[2] + "-" + date_list[1] + "-" + date_list[0];
            }
        }

    }
}
