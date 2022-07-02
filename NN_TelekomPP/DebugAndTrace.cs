using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NN_TelekomPP
{
    internal class DebugAndTrace
    {
        public static void testing(string[] add_org, string[] upd_org, string[] add_add, string[] upd_add, string[] add_internet, string[] upd_internet, string[] add_fee, string[] upd_fee)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("Debug.txt"));
            Debug.Indent();
            Trace.Indent();
            if (add_org[0] != null)
            {
                Debug.WriteLine("Пользователь добавил  в БД организацию:");
                for (int i = 0; i < add_org.Length - 1; i++)
                {
                    Debug.WriteLine(i + 1 + ") " + add_org[i]);
                }
            }
            if (upd_org[0] != null)
            {
                Debug.WriteLine("Пользователь  изменил  в БД организацию:");
                for (int i = 0; i < upd_org.Length - 1; i++)
                {
                    Debug.WriteLine(i + 1 + ") " + upd_org[i]);
                }
            }
            if (add_add[0] != null)
            {
                Debug.WriteLine("Пользователь  добавил в БД ДВО:");
                for (int i = 0; i < add_add.Length - 1; i++)
                {
                    Debug.WriteLine(i + 1 + ") " + add_add[i]);
                }
            }
            if (upd_add[0] != null)
            {
                Debug.WriteLine("Пользователь  изменил в БД ДВО:");
                for (int i = 0; i < upd_add.Length - 1; i++)
                {
                    Debug.WriteLine(i + 1 + ") " + upd_add[i]);
                }
            }
            if (add_internet[0] != null)
            {
                Debug.WriteLine("Пользователь  добавил в БД интернет:");
                for (int i = 0; i < add_internet.Length - 1; i++)
                {
                    Debug.WriteLine(i + 1 + ") " + add_internet[i]);
                }
            }
            if (upd_internet[0] != null)
            {
                Debug.WriteLine("Пользователь  изменил в БД интернет:");
                for (int i = 0; i < upd_internet.Length - 1; i++)
                {
                    Debug.WriteLine(i + 1 + ") " + upd_internet[i]);
                }
            }
            if (add_fee[0] != null)
            {
                Debug.WriteLine("Пользователь  добавил в БД абонентскйи пакет:");
                for (int i = 0; i < add_fee.Length - 1; i++)
                {
                    Debug.WriteLine(i + 1 + ") " + add_fee[i]);
                }
            }
            if (upd_fee[0] != null)
            {
                Debug.WriteLine("Пользователь  добавил в БД абонентскйи пакет:");
                for (int i = 0; i < upd_fee.Length - 1; i++)
                {
                    Debug.WriteLine(i + 1 + ") " + upd_fee[i]);
                }
            }
            Debug.WriteLine("");
            Trace.Flush();

        }




    }
}
