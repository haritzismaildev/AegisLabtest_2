using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using SourceTest2.DataAccess;
using SourceTest2.Models;
using DataModel = SourceTest2.Models.DataModel;

namespace SourceTest2.Repositories
{
    public class DataRepository
    {
        public List<DataModel> GetAllData() 
        {
            List<DataModel> dataList = new List<DataModel>();
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataList.Add(new DataModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nama = reader["Nama"].ToString(),
                        Tanggal = Convert.ToDateTime(reader["Tanggal"])
                    });
                }

                conn.Close();
            }
            return dataList;
        }
    }
}
