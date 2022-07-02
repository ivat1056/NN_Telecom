using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NN_TelekomPP.Forms
{

    public partial class Organizations : Form // организации 
    {
        string id_Organ;
        string name;
        bool save;
        DataBase dataBase = new DataBase();
        public Organizations()
        {
            InitializeComponent();
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("Name", "Название организации (абонента)");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1),RowState.ModifiedNew);
        }
        private void RefrashDataGrid(DataGridView dgw) // выбор 
        {
            dgw.Rows.Clear();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            string querryString = $"select * from Organizations";
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

        private void Organizations_Load(object sender, EventArgs e) // загрузка 
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
                id_Organ = row.Cells[0].Value.ToString();
                SqlCommand sqlCommand_country = new SqlCommand($"SELECT Organizations_code From Organizations WHERE  Organizations_code = '{id_Organ}'", dataBase.GetConnection());
                id_Organ = sqlCommand_country.ExecuteScalar().ToString();
            }
            dataBase.closeConnection();
        }

        private void UPD_button_Click(object sender, EventArgs e) // изменение 
        {
            if (id_Organ == null)
            {
                MessageBox.Show("Не выделена строчка для изменения");
            }
            else
            {
                this.Hide();
                OrganizationsUPD IU = new OrganizationsUPD(id_Organ, name);
                IU.ShowDialog();
            }
        }

        private void InternetADD_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrganizationsADD ADD = new OrganizationsADD();
            ADD.ShowDialog();
        }

        private void StrokaSearch_TextChanged(object sender, EventArgs e) // поиск 
        {
            Search(dataGridView1);
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"Select Organizations_code, Name from Organizations Where Name like '%" + StrokaSearch.Text + "%'";
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
            dataBase.openConnection();
            string admin = $"select  Organizations.Name From Services_customers  join  Organizations on Services_customers.Organizations_code=Organizations.Organizations_code WHERE Organizations.Organizations_code= '{id_Organ}'";
            string admin2 = $"  select Organizations.Name from ADD_customers join Organizations on ADD_customers.Organizations_code=Organizations.Organizations_code WHERE Organizations.Organizations_code= '{id_Organ}'";
            string admin3 = $"  select Organizations.Name  from Number join Organizations on Number.Organizations_code=Organizations.Organizations_code  WHERE Organizations.Organizations_code= '{id_Organ}'";
            SqlDataAdapter sda = new SqlDataAdapter(admin, dataBase.GetConnection());
            SqlDataAdapter sda2 = new SqlDataAdapter(admin2, dataBase.GetConnection());
            SqlDataAdapter sda3 = new SqlDataAdapter(admin2, dataBase.GetConnection());
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            DataTable dtbl2 = new DataTable();
            sda2.Fill(dtbl2);
            DataTable dtbl3 = new DataTable();
            sda3.Fill(dtbl3);


            if (((dtbl2.Rows.Count < 1) && (dtbl.Rows.Count < 1) && (dtbl3.Rows.Count < 1)))
            {
                if (id_Organ == null)
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


            
        }



        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;
            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridView1.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        new private void Update()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[2].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {

                    var deleteQuery = $"delete from Organizations where Organizations_code = {id_Organ}";
                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                    return;
                }
            }
            dataBase.closeConnection();
        }

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
