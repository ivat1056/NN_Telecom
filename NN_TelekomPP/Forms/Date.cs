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
    public partial class Date : Form
    {
        DataBase dataBase = new DataBase(); // вся таблица вывод 
        public Date()
        {
            InitializeComponent();
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("Name", "Название организации (абонента)");
            dataGridView1.Columns.Add("Number", "МГ1");
            dataGridView1.Columns.Add("Number", "МГ2");
            dataGridView1.Columns.Add("Number", "ДВО");
            dataGridView1.Columns.Add("Number", "Стоимость ДВО");
            dataGridView1.Columns.Add("Number", "Интернет");
            dataGridView1.Columns.Add("Number", "Стоимость интернета");
            dataGridView1.Columns.Add("Number", "Абонентский пакет");
            dataGridView1.Columns.Add("Number", "Стоимость абонентского пакета");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDouble(2), record.GetDouble(3), record.GetString(4), record.GetDouble(5), record.GetString(6), record.GetDouble(7), record.GetString(8), record.GetDouble(9), RowState.ModifiedNew);
        }
        private void RefrashDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            string querryString = $"select Calculation.Calculation_code,Organizations.Name, Calculation.MG_OSIPS, Calculation.MG_m200,  ServicesADD.Name,   ServicesADD.Cost, Internet.Name, Internet.Cost,SubscriptionFee.Name, SubscriptionFee.Cost from ADD_customers join Organizations on Organizations.Organizations_code=ADD_customers.Organizations_code   join ServicesADD on ServicesADD.ServicesADD_code=ADD_customers.ServicesADD_code  join Calculation  on Calculation.Organizations_code=Organizations.Organizations_code   join Services_customers on Services_customers.Organizations_code=Organizations.Organizations_code  join Internet on Internet.Internet_code=Services_customers.Internet_code   join SubscriptionFee on SubscriptionFee.AP_code=Services_customers.AP_code ";
            SqlCommand command = new SqlCommand(querryString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }
        private void Date_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrashDataGrid(dataGridView1);
        }

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculetionForm M = new CalculetionForm();
            M.ShowDialog();
        }
    }
}
