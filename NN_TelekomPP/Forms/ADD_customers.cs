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
    public partial class ADD_customers : Form
    {
        string id_num;
        string name1;
        string name2;
        bool save;
        
        public ADD_customers()  //  ДВО абонентов
        {
            InitializeComponent();
        }
        DataBase dataBase = new DataBase();
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("Name", "Название организации (абонента)");
            dataGridView1.Columns.Add("name", "Название ДВО");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), RowState.ModifiedNew);
        }
        private void RefrashDataGrid(DataGridView dgw) // вывод таблицы 
        {
            dgw.Rows.Clear();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            string querryString = $"select ADD_customers.ADD_code, Organizations.Name, ServicesADD.Name from Organizations join ADD_customers on Organizations.Organizations_code=ADD_customers.Organizations_code join ServicesADD on ServicesADD.ServicesADD_code=ADD_customers.ServicesADD_code";
            SqlCommand command = new SqlCommand(querryString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // выбор 
        {
            dataBase.openConnection();
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                id_num = row.Cells[0].Value.ToString();
                name1 = row.Cells[1].Value.ToString();
                name2 = row.Cells[2].Value.ToString();           
                SqlCommand sqlCommand_country = new SqlCommand($"SELECT ADD_code from ADD_customers WHERE ADD_code = '{id_num}'", dataBase.GetConnection());
                id_num = sqlCommand_country.ExecuteScalar().ToString();
            }
            dataBase.closeConnection();
        }

        private void InternetADD_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADD_customersADD IDD = new ADD_customersADD();
            IDD.ShowDialog();
        }

        private void UPD_button_Click(object sender, EventArgs e) // изменение 
        {
            if (id_num == null)
            {
                MessageBox.Show("Не выделена строчка для изменения");
            }
            else
            {

                this.Hide();
                ADD_customersUPD employeeUpdate = new ADD_customersUPD(id_num, name1, name2);
                employeeUpdate.ShowDialog();
            }
        }

        private void StrokaSearch_TextChanged(object sender, EventArgs e) // поиск 
        {
            Search(dataGridView1);
        }
        
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select ADD_customers.ADD_code, Organizations.Name, ServicesADD.Name from Organizations join ADD_customers on Organizations.Organizations_code=ADD_customers.Organizations_code join ServicesADD on ServicesADD.ServicesADD_code=ADD_customers.ServicesADD_code where Organizations.Name like '%" + StrokaSearch.Text + "%'";
            SqlCommand com = new SqlCommand(searchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();
        }

        private void ADD_customers_Load(object sender, EventArgs e) // загрузка 
        {
            CreateColums();
            RefrashDataGrid(dataGridView1);
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu M = new Menu();
            M.ShowDialog();
        }




        private void Del_button_Click(object sender, EventArgs e)
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
        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;
            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridView1.Rows[index].Cells[3].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[3].Value = RowState.Deleted;

        }


        new private void Update()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[3].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {

                    var deleteQuery = $"delete from ADD_customers where ADD_code = '{id_num}'";
                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                   
                }
            }
            dataBase.closeConnection();
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
