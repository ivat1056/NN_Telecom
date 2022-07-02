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
    public partial class InternetADD : Form // интернет добавить 
    {
        public int razmer = 0;
        public static string[] add_internet = new string[1];
        
        DataBase dataBase = new DataBase();
        public InternetADD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле интернет не может быть пустым");
            if (textBox2.Text.Replace(" ", "") == "") MessageBox.Show("Поле стоимость не может быть пустым");
            else
            {
                dataBase.openConnection();
                var internet = textBox1.Text;
                var cost = textBox2.Text;
                var addQuery = $"insert into Internet (Name, Cost) values ('{textBox1.Text}','{textBox2.Text}')";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно добавлена в таблицу");
                add_internet[razmer] = textBox1.Text;
                Array.Resize(ref add_internet, add_internet.Length + 1);
                razmer++;
                dataBase.closeConnection();
            }
        }

        private void button_back_Click(object sender, EventArgs e) // назад 
        {
            this.Hide();
            InternetForm IF = new InternetForm();
            IF.ShowDialog();
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
