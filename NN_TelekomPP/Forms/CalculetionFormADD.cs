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

    public partial class CalculetionFormADD : Form
    {
        DataBase dataBase = new DataBase();
        public CalculetionFormADD()
        {
            InitializeComponent();
            // comboBox1 - организации
            string searchString = $"Select Name From Organizations";
            SqlCommand com = new SqlCommand(searchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read.GetString(0));
            }
            read.Close();
            dataBase.closeConnection();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculetionForm M = new CalculetionForm();
            M.ShowDialog();
        }

        private void Save_button_Click(object sender, EventArgs e) // сохранение 
        {
            var num = $"select Organizations_code from Organizations where Name = '{comboBox1.Text}'";
            SqlDataAdapter sda = new SqlDataAdapter(num, dataBase.GetConnection());
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 0) MessageBox.Show("Поле организация должно быть выбрано из списка");
            else if (textBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле МГ1 не может быть пустым");
            else if (textBox2.Text.Replace(" ", "") == "") MessageBox.Show("Поле МГ2 не может быть пустым");
            else
            {

                dataBase.openConnection();
                SqlCommand sqlCommand_org = new SqlCommand(num, dataBase.GetConnection());
                var id_org = sqlCommand_org.ExecuteScalar().ToString();
                // Проверка есть ли у данной организации уже интернет 
                string a = $"select count(*)  from Calculation  join  Organizations on Calculation.Organizations_code = Organizations.Organizations_code   where Organizations.Organizations_code='{id_org}' ";
                SqlCommand command1 = new SqlCommand(a, dataBase.GetConnection());
                if (command1.ExecuteScalar().ToString().Equals("1"))
                {
                    MessageBox.Show("Данная организация уже есть в таблице");
                    return;
                }
                
                var addQuery = $"insert into Calculation (Organizations_code, MG_OSIPS,MG_m200) values ('{id_org}','{textBox1.Text}','{textBox2.Text}')";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно добавлена в таблицу");
                dataBase.closeConnection();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
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
