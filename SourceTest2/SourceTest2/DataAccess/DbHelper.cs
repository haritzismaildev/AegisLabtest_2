using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SourceTest2.DataAccess
{
    public static class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Server=MSIS_DEV\\MSSQLSVR2019LCL;Database=AegisLabsDB;User Id=sa;Password=123456;Encrypt=True;TrustServerCertificate=True;";
            return new SqlConnection(connectionString);
        }
    }
}