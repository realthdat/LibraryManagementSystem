using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace LibraryManagementSystem
{
    public static class DatabaseConnection
    {
        public static string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;

        // Phương thức để tạo một đối tượng SqlConnection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
