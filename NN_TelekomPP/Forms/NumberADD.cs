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
    public partial class NumberADD : Form // телефон добавить 
    {
        DataBase dataBase = new DataBase();
        public NumberADD()
        {
            InitializeComponent();
        }
       
        private void NumberADD_Load(object sender, EventArgs e)
        {
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
        
        private void Save_button_Click(object sender, EventArgs e) // сохранение 
        {
            var num = $"select Organizations_code from Organizations where Name = '{comboBox1.Text}'";
            SqlDataAdapter sda = new SqlDataAdapter(num, dataBase.GetConnection());
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 0) MessageBox.Show("Поле организация должно быть выбрано из списка");
            else if (textBox2.Text.Replace(" ", "") == "") MessageBox.Show("Поле номер не может быть пустым");
            else
            {
               
                dataBase.openConnection();
                SqlCommand sqlCommand_org = new SqlCommand(num, dataBase.GetConnection());
                var id_org = sqlCommand_org.ExecuteScalar().ToString();
                var addQuery = $"insert into Number (Organizations_code, Number) values ('{id_org}','{textBox2.Text}')";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно добавлена в таблицу");
                dataBase.closeConnection();
            }
        }

        private void button_back_Click(object sender, EventArgs e) // назад 
        {
            this.Hide();
            Number M = new Number();
            M.ShowDialog();
        }

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
