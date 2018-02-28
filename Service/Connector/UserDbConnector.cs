using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Service.Connector
{
    public class UserDbConnector
    {
        private SqlConnection connection;

        /*
        @dev in the constructor we are connecting to our sql-database on azure. there
        we are trying to open a connection
        */ 
        public UserDbConnector()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "userstorage.database.windows.net";
            builder.UserID = "hung";
            builder.Password = "******";
            builder.InitialCatalog = "usersdb";

            try
            {
                connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        //@dev add a user into the sql-database by appending a UserData into corresponding column.
        public void add(UserInfo data)
        {
            try
            {
                String sql = "INSERT INTO dbo.users VALUES ('" + data.userName + "', '" + data.firstName + "', '" + data.lastName + "');";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        //@dev search the sql database for userName.
        public UserInfo getUser(string userName)
        {
            String sql = "SELECT * FROM dbo.users WHERE USERNAME='"+userName+"'";


            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            UserInfo user = new UserInfo(reader.GetString(1), reader.GetString(2), reader.GetString(3));

            return user;
        }
    }
}