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
    public partial class SubscriptionFee : Form // абонентские пакеты 
    {
        string id_serv;
        string name;
        string cost;
        bool save;
        DataBase dataBase = new DataBase();
        public SubscriptionFee()
        {
            InitializeComponent();
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("Name", "Название абонентского пакета");
            dataGridView1.Columns.Add("Cost", "Стоимость");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDouble(2), RowState.ModifiedNew);
        }
        private void RefrashDataGrid(DataGridView dgw) // вывод 
        {
            dgw.Rows.Clear();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            string querryString = $"select * from SubscriptionFee";
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
       
        private void InternetADD_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            SubscriptionFeeADD IDD = new SubscriptionFeeADD();
            IDD.ShowDialog();
            
        }

        private void UPD_button_Click(object sender, EventArgs e) // изменение 
        {
            if (id_serv == null)
            {
                MessageBox.Show("Не выделена строчка для изменения");
            }
            else
            {
                this.Hide();
                SubscriptionFeeUPF IU = new SubscriptionFeeUPF(id_serv, name, cost);
                IU.ShowDialog();
            }
        }

        private void StrokaSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void SubscriptionFee_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrashDataGrid(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataBase.openConnection();
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                id_serv = row.Cells[0].Value.ToString();
                SqlCommand sqlCommand_country = new SqlCommand($"SELECT AP_code From SubscriptionFee WHERE  AP_code = '{id_serv}'", dataBase.GetConnection());
                id_serv = sqlCommand_country.ExecuteScalar().ToString();
            }
            dataBase.closeConnection();
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"Select AP_code, Name, Cost from SubscriptionFee Where Name like '%" + StrokaSearch.Text + "%'";
            SqlCommand com = new SqlCommand(searchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();
        }


        private void deleteRow() // удаление 
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

                    var deleteQuery = $"delete from SubscriptionFee where AP_code = {id_serv}";
                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                    return;
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

        private void Del_button_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            string admin = $"select Organizations.Name From SubscriptionFee  inner join Services_customers ON SubscriptionFee.AP_code = Services_customers.AP_code join Organizations on Organizations.Organizations_code = Services_customers.Organizations_code WHERE SubscriptionFee.AP_code = '{id_serv}'";
            SqlDataAdapter sda = new SqlDataAdapter(admin, dataBase.GetConnection());
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count < 1)
            {
                if (id_serv == null)
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

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
