using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NN_TelekomPP.Forms
{
    public partial class SubscriptionFeeUPF : Form // услуги абонентов изменить 
    {
        public int razmer = 0;
        public static string[] upd_fee = new string[1];
        string id_serv;
        DataBase dataBase = new DataBase();
        public SubscriptionFeeUPF(string id_serv, string name, string cost)
        {
            InitializeComponent();
            dataBase.openConnection();
            this.id_serv = id_serv;
            textBox1.Text = name;
            textBox2.Text = cost;
            dataBase.closeConnection();
        }
        
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            SubscriptionFee IDD = new SubscriptionFee();
            IDD.ShowDialog();
        }

        private void Save_button_Click(object sender, EventArgs e) // сохранить 
        {
            if (textBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле абонентский пакет не может быть пустым");
            if (textBox2.Text.Replace(" ", "") == "") MessageBox.Show("Поле стоимость не может быть пустым");
            else
            {
                dataBase.openConnection();
                var addQuery = $"update SubscriptionFee set Name = '{textBox1.Text}', Cost = '{textBox2.Text}' where AP_code = '{id_serv}'";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена");
                upd_fee[razmer] = textBox1.Text;
                Array.Resize(ref upd_fee, upd_fee.Length + 1);
                razmer++;
                dataBase.closeConnection();
                this.Hide();
                SubscriptionFee IF = new SubscriptionFee();
                IF.ShowDialog();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
