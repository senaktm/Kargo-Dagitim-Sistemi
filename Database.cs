﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace YazLab11
{
    class Database
    {
         MySqlConnection connection = new MySqlConnection("SERVER = 35.224.209.204; DATABASE=cloudDatabase;UID=root;PWD=1234");

        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

    }
}
