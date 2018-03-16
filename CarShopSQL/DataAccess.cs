using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace CarShopSQL
{
    class DataAccess
    {
        public List<Cars> GetCars()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                var output = connection.Query<Cars>("dbo.findAllInfo").ToList();
                return output;
            }
        }
        internal void InsertCar(Cars car)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                connection.Execute("dbo.Car_Insert @Make, @Model,@Colour, @Price, @Comm, @netValue", car);
            }
        }

        internal void GetCarInv()
        {
            Console.Clear();
            List<Cars> car = new List<Cars>();
            using (SqlConnection cn = new SqlConnection(Helper.CnnVal("SampleDB")))
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.findAllInfo", cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetValue(i) + " " );
                    }
                    Console.WriteLine();
                }
                cn.Close();
            }
        }
    }
}

