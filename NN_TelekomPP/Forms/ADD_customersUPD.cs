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
    public partial class ADD_customersUPD : Form // изменение ДВО для абонентов 
    {
        public int razmer = 0;
        public static string[] upd_addcus = new string[1];
        string id_serv;
        DataBase dataBase = new DataBase();
        public ADD_customersUPD(string id_num, string name1, string name2)
        {
            InitializeComponent();
            dataBase.openConnection(); // для изменения 
            this.id_serv = id_num;
            comboBox1.Text = name1;
            comboBox2.Text = name2;
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
        
        private void Save_button_Click(object sender, EventArgs e) // сохранение 
        {
            var num = $"select Organizations_code from Organizations where Name = '{comboBox1.Text}'";
            var internet = $"select ServicesADD_code from ServicesADD where Name = '{comboBox2.Text}'";
            SqlDataAdapter sda = new SqlDataAdapter(num, dataBase.GetConnection());
            SqlDataAdapter sda2 = new SqlDataAdapter(internet, dataBase.GetConnection());
            DataTable dtbl = new DataTable();
            DataTable dtbl2 = new DataTable();
            sda.Fill(dtbl);
            sda2.Fill(dtbl2);
            if (comboBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле название организациb не может быть пустым");
            else if (comboBox2.Text.Replace(" ", "") == "") MessageBox.Show("Поле дополнительная услуга не может быть пустым");
            else
            {
                dataBase.openConnection();
                SqlCommand sqlCommand_org = new SqlCommand(num, dataBase.GetConnection());
                SqlCommand sqlCommand_org2 = new SqlCommand(internet, dataBase.GetConnection());
                var id_org = sqlCommand_org.ExecuteScalar().ToString();
                var inter = sqlCommand_org2.ExecuteScalar().ToString();
                var addQuery = $"update ADD_customers set Organizations_code = '{id_org}', ServicesADD_code = '{inter}' where ADD_customers.ADD_code = '{id_serv}'";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена");
                upd_addcus[razmer] = comboBox2.Text;
                Array.Resize(ref upd_addcus, upd_addcus.Length + 1);
                razmer++;
                dataBase.closeConnection();
                this.Hide();
                ADD_customers IF = new ADD_customers();
                IF.ShowDialog();
            }
        }

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
