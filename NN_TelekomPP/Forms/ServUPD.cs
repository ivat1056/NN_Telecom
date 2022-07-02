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
    public partial class ServUPD : Form // дво изменение 
    {
        public int razmer = 0;
        public static string[] upd_add = new string[1];
        string id_serv;
        DataBase dataBase = new DataBase();
        public ServUPD(string id_serv, string name, string cost)
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
            SADD IDD = new SADD();
            IDD.ShowDialog();
        }

        private void Save_button_Click(object sender, EventArgs e) // сохранение 
        {
            if (textBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле дополнительная услуга не может быть пустым");
            if (textBox2.Text.Replace(" ", "") == "") MessageBox.Show("Поле стоимость не может быть пустым");
            else
            {
                dataBase.openConnection();
                var addQuery = $"update ServicesADD set Name = '{textBox1.Text}', Cost = '{textBox2.Text}' where ServicesADD_code = '{id_serv}'";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена");
                upd_add[razmer] = textBox1.Text;
                Array.Resize(ref upd_add, upd_add.Length + 1);
                razmer++;
                dataBase.closeConnection();
                this.Hide();
                SADD IF = new SADD();
                IF.ShowDialog();
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
