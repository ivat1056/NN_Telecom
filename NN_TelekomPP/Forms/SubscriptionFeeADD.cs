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
    public partial class SubscriptionFeeADD : Form // услуги абонентов добавить 
    {
        public int razmer = 0;
        public static string[] add_fee = new string[1];
        DataBase dataBase = new DataBase();
        public SubscriptionFeeADD()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            SubscriptionFee IDD = new SubscriptionFee();
            IDD.ShowDialog();
        }
        
        private void Save_button_Click(object sender, EventArgs e) // сохранение 
        {
            if (textBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле абонентский пакет не может быть пустым");
            if (textBox2.Text.Replace(" ", "") == "") MessageBox.Show("Поле стоимость не может быть пустым");
            else
            {
                dataBase.openConnection();
                var ss = textBox1.Text;
                var cost = textBox2.Text;
                var addQuery = $"insert into SubscriptionFee(Name, Cost) values ('{textBox1.Text}','{textBox2.Text}')";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно добавлена в таблицу");
                add_fee[razmer] = textBox1.Text;
                Array.Resize(ref add_fee, add_fee.Length + 1);
                razmer++;
                dataBase.closeConnection();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
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
