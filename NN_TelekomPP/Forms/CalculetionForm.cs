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
    
    public partial class CalculetionForm : Form // расчет 
    {
        string id_num;
        string MG1;
        string MG2;
        
        bool save;
        DataBase dataBase = new DataBase();
        public CalculetionForm()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu M = new Menu();
            M.ShowDialog();
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("Name", "Название организации (абонента)");
            dataGridView1.Columns.Add("Number", "МГ1");
            dataGridView1.Columns.Add("Number", "МГ2");
            dataGridView1.Columns.Add("Number", "Итого");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDouble(2), record.GetDouble(3), record.GetDouble(4), RowState.ModifiedNew);
        }
        private void RefrashDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            string querryString = $"select Calculation.Calculation_code,Organizations.Name, Calculation.MG_OSIPS, Calculation.MG_m200, sum(ServicesADD.Cost)+ Internet.Cost+SubscriptionFee.Cost+Calculation.MG_OSIPS+ Calculation.MG_m200 from ADD_customers join Organizations on Organizations.Organizations_code=ADD_customers.Organizations_code  join ServicesADD on ServicesADD.ServicesADD_code=ADD_customers.ServicesADD_code join Calculation  on Calculation.Organizations_code=Organizations.Organizations_code  join Services_customers on Services_customers.Organizations_code=Organizations.Organizations_code join Internet on Internet.Internet_code=Services_customers.Internet_code  join SubscriptionFee on SubscriptionFee.AP_code=Services_customers.AP_code GROUP BY Organizations.Name, Calculation.MG_OSIPS, Calculation.MG_m200,Internet.Cost,SubscriptionFee.Cost, Calculation.Calculation_code";
            SqlCommand command = new SqlCommand(querryString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // для выбора  
        {
            var selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                id_num = row.Cells[0].Value.ToString();
                
                MG1 = row.Cells[1].Value.ToString();
                MG2 = row.Cells[2].Value.ToString();
                
                

                SqlCommand sqlCommand_country = new SqlCommand($"SELECT Calculation_code from Calculation WHERE Calculation_code = '{id_num}'", dataBase.GetConnection());
                id_num = sqlCommand_country.ExecuteScalar().ToString();
            }
        }

        private void CalculetionForm_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrashDataGrid(dataGridView1);
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
                CalculetionFormUPD employeeUpdate = new CalculetionFormUPD(id_num, MG1, MG2);
                employeeUpdate.ShowDialog();
            }
        }

        private void InternetADD_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculetionFormADD IDD = new CalculetionFormADD();
            IDD.ShowDialog();
        }

        private void StrokaSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }
        private void Search(DataGridView dgw)  // поиск 
        {
            dgw.Rows.Clear();
            string searchString = $"select Calculation.Calculation_code,Organizations.Name, Calculation.MG_OSIPS, Calculation.MG_m200, sum(ServicesADD.Cost)+ Internet.Cost+SubscriptionFee.Cost+Calculation.MG_OSIPS+ Calculation.MG_m200 from ADD_customers join Organizations on Organizations.Organizations_code=ADD_customers.Organizations_code  join ServicesADD on ServicesADD.ServicesADD_code=ADD_customers.ServicesADD_code join Calculation  on Calculation.Organizations_code=Organizations.Organizations_code  join Services_customers on Services_customers.Organizations_code=Organizations.Organizations_code join Internet on Internet.Internet_code=Services_customers.Internet_code  join SubscriptionFee on SubscriptionFee.AP_code=Services_customers.AP_code Where Organizations.Name like '%" + StrokaSearch.Text + "%' GROUP BY Organizations.Name, Calculation.MG_OSIPS, Calculation.MG_m200,Internet.Cost,SubscriptionFee.Cost, Calculation.Calculation_code ";
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
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
            

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
                    
                    var deleteQuery = $"delete from Calculation where Calculation_code = '{id_num}'";
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

       

        private void global_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            summ();
        }
        public void summ() // для подсчета итоговой суммы 
        {
            string querryString = $"select Calculation.Calculation_code,Organizations.Name, Calculation.MG_OSIPS, Calculation.MG_m200, sum(ServicesADD.Cost)+ Internet.Cost+SubscriptionFee.Cost+Calculation.MG_OSIPS+ Calculation.MG_m200 from ADD_customers join Organizations on Organizations.Organizations_code=ADD_customers.Organizations_code  join ServicesADD on ServicesADD.ServicesADD_code=ADD_customers.ServicesADD_code join Calculation  on Calculation.Organizations_code=Organizations.Organizations_code  join Services_customers on Services_customers.Organizations_code=Organizations.Organizations_code join Internet on Internet.Internet_code=Services_customers.Internet_code  join SubscriptionFee on SubscriptionFee.AP_code=Services_customers.AP_code GROUP BY Organizations.Name, Calculation.MG_OSIPS, Calculation.MG_m200,Internet.Cost,SubscriptionFee.Cost, Calculation.Calculation_code";
            SqlCommand command = new SqlCommand(querryString, dataBase.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            double a= 0;
            while (reader.Read())
            {
                 a=summ2(a, reader.GetDouble(4));
                //a += reader.GetDouble(4);
            }
            MessageBox.Show($"Итоговая сумма {a}");
            reader.Close();
            
        }
        
        public double summ2(double a ,  double b) // для суммы двух строк 
        {
           
            return a + b;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Date M = new Date();
            M.ShowDialog();
        }
    }
}
