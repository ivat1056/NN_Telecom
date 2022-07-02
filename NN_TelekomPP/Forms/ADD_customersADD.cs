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
    public partial class ADD_customersADD : Form // дво добавить для абонента 
    {
       
        DataBase dataBase = new DataBase();
        public ADD_customersADD()
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
            // comboBox4 - дополнительные услуги
            string searchString4 = $"Select Name From ServicesADD";
            SqlCommand com4 = new SqlCommand(searchString4, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read4 = com4.ExecuteReader();
            while (read4.Read())
            {
                comboBox2.Items.Add(read4.GetString(0));
            }
            read4.Close();
            dataBase.closeConnection();
        }
        
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADD_customers M = new ADD_customers();
            M.ShowDialog();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            var num = $"select Organizations_code from Organizations where Name = '{comboBox1.Text}'"; // сохранения 
            var num2 = $"select ServicesADD_code from ServicesADD where Name = '{comboBox2.Text}'";
            SqlDataAdapter sda = new SqlDataAdapter(num, dataBase.GetConnection());
            SqlDataAdapter sda2 = new SqlDataAdapter(num2, dataBase.GetConnection());
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (comboBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле название организации не может быть пустым");
            else if(comboBox2.Text.Replace(" ", "") == "") MessageBox.Show("Поле дополнительная услуга не может быть пустым");
            else
            {

                dataBase.openConnection();
                SqlCommand sqlCommand_org = new SqlCommand(num, dataBase.GetConnection());
                SqlCommand sqlCommand_org2 = new SqlCommand(num2, dataBase.GetConnection());
                var id_org = sqlCommand_org.ExecuteScalar().ToString();
                var id_org2 = sqlCommand_org2.ExecuteScalar().ToString();

                // Проверка есть ли у данной организации уже данная дополнительная услуга
                string b = $"select  Organizations.Name  from Services_customers  join  Organizations on Services_customers.Organizations_code = Organizations.Organizations_code   join Internet on Internet.Internet_code =  Services_customers.Internet_code join  ADD_customers on ADD_customers.Organizations_code=Services_customers.Organizations_code join ServicesADD on ADD_customers.ServicesADD_code=ServicesADD .ServicesADD_code join SubscriptionFee on SubscriptionFee.AP_code=Services_customers.AP_code  where ServicesADD.Name='{comboBox2.Text}' GROUP BY Organizations.Name,SubscriptionFee.Name,Internet.Name,Services_customers.Services_customers_code  ";
                SqlCommand com1 = new SqlCommand(b, dataBase.GetConnection());
                dataBase.openConnection();
                SqlDataReader read = com1.ExecuteReader();
                while (read.Read())
                {
                    if (comboBox1.Text == read.GetString(0))
                    {
                        MessageBox.Show("Данная организация уже есть в таблице");
                        return;
                    }
                }
                read.Close();


                var addQuery = $"insert into ADD_customers (Organizations_code, ServicesADD_code) values ('{id_org}','{id_org2}')";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно добавлена в таблицу");
                
                dataBase.closeConnection();
            }
        }

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
