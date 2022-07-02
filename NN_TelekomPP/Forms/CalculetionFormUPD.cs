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
    public partial class CalculetionFormUPD : Form // расчет изменение 
    {
        string id_num;
        DataBase dataBase = new DataBase();
        public CalculetionFormUPD(string id_num, string MG1, string MG2)
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

            dataBase.openConnection();
            this.id_num = id_num;
            comboBox1.Text = MG1;
            textBox2.Text = MG2;
            dataBase.closeConnection();
        }
        
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculetionForm M = new CalculetionForm();
            M.ShowDialog();
        }

        private void Save_button_Click(object sender, EventArgs e) // сохраненрие 
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
                var addQuery = $"update Calculation set  Organizations_code= '{id_org}', MG_OSIPS = '{textBox1.Text}' , MG_m200 = '{textBox2.Text}'  where Calculation_code = '{id_num}'";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена в таблице");
                dataBase.closeConnection();
                this.Hide();
                CalculetionForm n = new CalculetionForm();
                n.ShowDialog();
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
