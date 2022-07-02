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
    public partial class OrganizationsUPD : Form // организации изменить 
    {
        public int razmer = 0;
        public static string[] upd_org = new string[1];
        string id_Organ;
        DataBase dataBase = new DataBase();
        public OrganizationsUPD(string id_Organ, string name)
        {
            InitializeComponent();
            dataBase.openConnection();
            this.id_Organ = id_Organ;
            textBox1.Text = name;
            dataBase.closeConnection();
        }

        private void button_back_Click(object sender, EventArgs e) // назад 
        {
            this.Hide();
            Organizations N = new Organizations();
            N.ShowDialog();
        }

        private void Save_button_Click(object sender, EventArgs e) // сохранение 
        {
            if (textBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле организация не может быть пустым");
            else
            {
                dataBase.openConnection();
                var addQuery = $"update Organizations set Name = '{textBox1.Text}' where Organizations_code = '{id_Organ}'";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена");
                upd_org[razmer] = textBox1.Text;
                Array.Resize(ref upd_org, upd_org.Length + 1);
                razmer++;
                dataBase.closeConnection();
                this.Hide();
                Organizations IF = new Organizations();
                IF.ShowDialog();
            }
        }
        

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
