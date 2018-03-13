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
        internal void InsertCar(string make, string model, string colour, double price, double comm, double netvalue)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
                List<Cars> cars = new List<Cars>();

                cars.Add(new Cars { Make = make, Model = model, Colour = colour, Price = price, Comm = comm, netValue = netvalue });

                connection.Execute("dbo.Car_Insert @Make, @Model,@Colour, @Price, @Comm, @netValue", cars);
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
                    //Cars c = new Cars();
                    //c.Make = (string)reader["Make"];
                    //c.Model = (string)reader["Model"];
                    //c.Colour = (string)reader["Colour"];
                    //c.Price = (double)reader["Price"];
                    //c.Comm = (double)reader["Comm"];
                    //c.netValue = (double)reader["netValue"];
                    //car.Add(c);
                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetValue(i) + " " );
                    }
                    Console.WriteLine();


                }
                cn.Close();
            }
            //foreach (var c in car)
            //{
            //    Console.WriteLine();
            //}
        }
    }
}

