using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Csharp_Login_And_Register
{
    class DB
    {
       private MySqlConnection connection = new MySqlConnection("server=localhost;port=5050;username=root;password=;database=logowanie");
        public void openConn()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConn()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConn()
        {
            return connection;
        }
    }
}
