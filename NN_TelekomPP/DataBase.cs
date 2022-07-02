using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NN_TelekomPP
{
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=ngknn.ru;Initial Catalog=MatveevPP;Persist Security Info=True;User ID=31П;Password=12357");
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

    }
}
