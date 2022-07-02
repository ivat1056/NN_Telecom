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
    public partial class OrganizationsADD : Form // организация добавить 
    {
        public int razmer = 0;
        public static string[] add_org = new string[1];
        DataBase dataBase = new DataBase();
        public OrganizationsADD()
        {
            InitializeComponent();
        }
        
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
           Organizations O = new Organizations();
            O.ShowDialog();
        }

        private void Save_button_Click(object sender, EventArgs e) // сохранение 
        {
            if (textBox1.Text.Replace(" ", "") == "") MessageBox.Show("Поле организация не может быть пустым");
            else
            {
                dataBase.openConnection();
                var internet = textBox1.Text;
                var addQuery = $"insert into Organizations (Name) values ('{textBox1.Text}')";
                var command = new SqlCommand(addQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно добавлена в таблицу");
                add_org[razmer] = textBox1.Text;
                Array.Resize(ref add_org, add_org.Length + 1);
                razmer++;
                dataBase.closeConnection();
            }
        }

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
