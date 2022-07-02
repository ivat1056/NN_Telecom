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
    public partial class Number : Form // телефоны 
    {
        string id_num;
        string number;
        string name;
        string id_Org;
        bool save;
        public Number()
        {
            InitializeComponent();
        }
        DataBase dataBase = new DataBase();
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("Name", "Название организации (абонента)");
            dataGridView1.Columns.Add("Number", "Номер");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), RowState.ModifiedNew);
        }
        private void RefrashDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            string querryString = $"select Number_code, Organizations.Name,Number.Number from Organizations inner join Number on Organizations.Organizations_code = Number.Organizations_code";
            SqlCommand command = new SqlCommand(querryString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }
        
        private void button_back_Click(object sender, EventArgs e) // назад 
        {
            this.Hide();
            Menu M = new Menu();
            M.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)// выбор 
        {
            dataBase.openConnection();
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                id_num = row.Cells[0].Value.ToString();
                id_Org = row.Cells[1].Value.ToString();
                number = row.Cells[2].Value.ToString();
                SqlCommand sqlCommand_country = new SqlCommand($"SELECT Number_code from Number WHERE Number_code = '{id_num}'", dataBase.GetConnection());
                id_num = sqlCommand_country.ExecuteScalar().ToString();
            }
            dataBase.closeConnection();
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
                NumberUPD employeeUpdate = new NumberUPD(id_num, name, number);
                employeeUpdate.ShowDialog();
            }
        }

        private void InternetADD_button_Click(object sender, EventArgs e) // добавление 
        {
            this.Hide();
            NumberADD IDD = new NumberADD();
            IDD.ShowDialog();
        }

        private void Number_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrashDataGrid(dataGridView1);
        }

        private void StrokaSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }
       
        private void Search(DataGridView dgw) // поиск 
        {
            dgw.Rows.Clear();
            string searchString = $"Select Organizations.Organizations_code, Organizations.Name,Number.Number from Organizations inner join Number on Organizations.Organizations_code = Number.Organizations_code Where Name like '%" + StrokaSearch.Text + "%'";
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

                    var deleteQuery = $"delete from Number where Number_code = '{id_num}'";
                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                    return;

                }
            }
            dataBase.closeConnection();
        }

        private void global_FormClosed(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
