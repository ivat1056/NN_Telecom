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
    public partial class Services_customers : Form // услуги абонентов 
    {
        string id_num;
        string name1;
        string name2;
        string name3;
        string name4;
        bool save;
        DataBase dataBase = new DataBase();
        public Services_customers()
        {
            InitializeComponent();
        }
        
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("Name", "Название организации (абонента)");
            dataGridView1.Columns.Add("Name", "Интернет");
            dataGridView1.Columns.Add("Name", "Абонентский пакет");
            dataGridView1.Columns.Add("Name", "Количество ДВО у абонента");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3),  record.GetInt32(4), RowState.ModifiedNew);
        }
        private void RefrashDataGrid(DataGridView dgw) // вывод данных 
        {
            dgw.Rows.Clear();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            string querryString = $"select Services_customers.Services_customers_code,  Organizations.Name, Internet.Name, SubscriptionFee.Name,COUNT(*)  from Services_customers  join  Organizations on Services_customers.Organizations_code = Organizations.Organizations_code   join Internet on Internet.Internet_code =  Services_customers.Internet_code join  ADD_customers on ADD_customers.Organizations_code=Services_customers.Organizations_code join ServicesADD on ADD_customers.ServicesADD_code=ServicesADD .ServicesADD_code join SubscriptionFee on SubscriptionFee.AP_code=Services_customers.AP_code GROUP BY Organizations.Name,SubscriptionFee.Name,Internet.Name,Services_customers.Services_customers_code   ";
            SqlCommand command = new SqlCommand(querryString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // выбор данных 
        {
            dataBase.openConnection();
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                id_num = row.Cells[0].Value.ToString();
                name1 = row.Cells[1].Value.ToString();
                name2 = row.Cells[2].Value.ToString();
                name3 = row.Cells[3].Value.ToString();
                SqlCommand sqlCommand_country = new SqlCommand($"SELECT Services_customers_code from Services_customers WHERE Services_customers_code = '{id_num}'", dataBase.GetConnection());
                id_num = sqlCommand_country.ExecuteScalar().ToString();
            }
            dataBase.closeConnection();
        }

        private void InternetADD_button_Click(object sender, EventArgs e) // добавить 
        {
            this.Hide();
            Services_customersADD IDD = new Services_customersADD();
            IDD.ShowDialog();
        }

        private void UPD_button_Click(object sender, EventArgs e)
        {
            if (id_num == null)
            {
                MessageBox.Show("Не выделена строчка для изменения");
            }
            else
            {

                this.Hide();
                Services_customersUPD employeeUpdate = new Services_customersUPD(id_num, name1, name2, name3);
                employeeUpdate.ShowDialog();
            }

        }

        private void Del_button_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            string admin = $"SELECT Organizations.Name From Calculation join Organizations on Calculation.Organizations_code=Organizations.Organizations_code  WHERE Organizations.Name = '{name1}'";
            SqlDataAdapter sda = new SqlDataAdapter(admin, dataBase.GetConnection());
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count < 1)
            {
                if (id_num == null)
                {
                    MessageBox.Show("Не выделена запись для удаления!!!");
                }
                else
                {
                    deleteRow();
                    save = true;
                }
            }
            else
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!!!");
            }
            dataBase.closeConnection();
        }
        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;
            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
            }
        new private void Update()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    
                    var deleteQuery = $"delete from Services_customers where Services_customers_code = {id_num}";
                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                    return;
                }
            }
            dataBase.closeConnection();
        }
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu M = new Menu();
            M.ShowDialog();
        }

        private void Services_customers_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrashDataGrid(dataGridView1);
        }

        private void StrokaSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }
        
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select Services_customers.Services_customers_code,  Organizations.Name, Internet.Name, SubscriptionFee.Name,COUNT(*)  from Services_customers  join  Organizations on Services_customers.Organizations_code = Organizations.Organizations_code   join Internet on Internet.Internet_code =  Services_customers.Internet_code join  ADD_customers on ADD_customers.Organizations_code=Services_customers.Organizations_code join ServicesADD on ADD_customers.ServicesADD_code=ServicesADD .ServicesADD_code join SubscriptionFee on SubscriptionFee.AP_code=Services_customers.AP_code Where Organizations.Name like '%" + StrokaSearch.Text + "%' GROUP BY Organizations.Name,SubscriptionFee.Name,Internet.Name,Services_customers.Services_customers_code  ";
            SqlCommand com = new SqlCommand(searchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (save == true)
            {
                Update();
                save = false;
            }
        }

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
