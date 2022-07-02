using NN_TelekomPP.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN_TelekomPP
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Forms.Menu());
                DebugAndTrace.testing(OrganizationsADD.add_org, OrganizationsUPD.upd_org, ServADD.add_add, ServUPD.upd_add,InternetADD.add_internet, InernetUPD.upd_internet, SubscriptionFeeADD.add_fee, SubscriptionFeeUPF.upd_fee);
            }
            catch
            {
                MessageBox.Show("В программе возникла ошибка, из-за чего она будет завершина");
            }
        }
    }
}
