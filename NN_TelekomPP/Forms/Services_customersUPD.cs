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
    public partial class Services_customersUPD : Form // услуги абонентов изменение 
    {
        string id_serv;
        DataBase dataBase = new DataBase();
        public Services_customersUPD(string id_num, string name1, string name2, string name3)
        {
            InitializeComponent();
            dataBase.openConnection();
            this.id_serv = id_num;
            comboBox1.Text = name1;
            comboBox2.Text = name2;
            comboBox3.Text = name3;
            
            dataBase.closeConnection();
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
            // comboBox2 - Интернет
            string searchString2 = $"Select Name From Internet";
            SqlCommand com2 = new SqlCommand(searchString2, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read2 = com2.ExecuteReader();
            while (read2.Read())
            {
                comboBox2.Items.Add(read2.GetString(0));
            }
            read2.Close();
            dataBase.closeConnection();
            // comboBox3 - Абонентская плата
            string searchString3 = $"Select Name From SubscriptionFee";
            SqlCommand com3 = new SqlCommand(searchString3, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read3 = com3.ExecuteReader();
            while (read3.Read())
            {
                comboBox3.Items.Add(read3.GetString(0));
            }
            read3.Close();
            dataBase.closeConnection();
           
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Services_customers M = new Services_customers();
            M.ShowDialog();
        }
        
        private void Save_button_Click(object sender, EventArgs e) // сохранение 
        {
            var num = $"select Organizations_code from Organizations where Name = '{comboBox1.Text}'";
            var internet = $"select Internet_code from Internet where Name = '{comboBox2.Text}'";
            var Fee = $"select AP_code from SubscriptionFee where Name = '{comboBox3.Text}'";
            
            SqlDataAdapter sda = new SqlDataAdapter(num, dataBase.GetConnection());
            SqlDataAdapter sda2 = new SqlDataAdapter(internet, dataBase.GetConnection());
            SqlDataAdapter sda3 = new SqlDataAdapter(Fee, dataBase.GetConnection());
            
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (comboBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле организация не может быть пустым");
            else if (comboBox2.Text.Replace(" ", "") == "") MessageBox.Show("Поле  интернет не может быть пустым");
            else if (comboBox3.Text.Replace(" ", "") == "") MessageBox.Show("Поле  абонентский пакет не может быть пустым");
            
            else
            {
                dataBase.openConnection();
                SqlCommand sqlCommand_org = new SqlCommand(num, dataBase.GetConnection());
                SqlCommand sqlCommand_org2 = new SqlCommand(internet, dataBase.GetConnection());
                SqlCommand sqlCommand_org3 = new SqlCommand(Fee, dataBase.GetConnection());
               
                var id_org = sqlCommand_org.ExecuteScalar().ToString();
                var inter = sqlCommand_org2.ExecuteScalar().ToString();
                var AP1 = sqlCommand_org3.ExecuteScalar().ToString();
                
                var addQuery = $"update Services_customers set Organizations_code = '{id_org}', Internet_code = '{inter}', AP_code='{AP1}'  where Services_customers_code = '{id_serv}'";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена");
                dataBase.closeConnection();
                this.Hide();
                Services_customers IF = new Services_customers();
                IF.ShowDialog();
            }
        }

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
