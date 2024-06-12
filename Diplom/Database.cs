using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Diplom
{
    class db
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-HU81JFN\SQLEXPRESS;Initial Catalog=Xml programm;Integrated Security=True;Encrypt=True;TrustServerCertificate=true");

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

