using System.Data;
using System.Data.SqlClient;

namespace DistributionManager.Connection
{
    class Connector
    {
        const string CONNECTION_STRING = @"Data Source=DESKTOP-NN2AVJ6\SQLEXPRESS;Initial Catalog=Distribution_Managemaent;Integrated Security=True";
        static SqlConnection SQL_CONNECTION = new SqlConnection(CONNECTION_STRING);

        public static SqlConnection Sql_Connection { get { return SQL_CONNECTION; } }

        public static void CheckForConnection()
        {
            if (Sql_Connection != null && Sql_Connection.State != ConnectionState.Closed)
                Sql_Connection.Close();
            Sql_Connection.Open();
        }
    }

}
