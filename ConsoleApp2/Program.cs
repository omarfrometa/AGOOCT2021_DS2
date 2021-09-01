using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDate = DateTime.Now;
            var finishDate = DateTime.Now;
            Console.WriteLine($"INICIO: {startDate.ToString("F")}");

            string connStr = ConfigurationManager.ConnectionStrings["DS2Conn"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connStr);

            SqlCommand sqlCommand = new SqlCommand 
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM Student",
                Connection = sqlConnection
            };

            try
            {
                sqlConnection.Open();

                SqlDataReader dr = sqlCommand.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine($"Matricula: {dr["Enrollment"]} | Nombre: {dr["FirstName"]} {dr["LastName"]}");
                }

            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw;
            }

            sqlConnection.Close();
            finishDate = DateTime.Now;

            Console.WriteLine($"FINAL: {finishDate.ToString("F")}");
            Console.WriteLine($"DIFERENCIA: {(finishDate - startDate).Milliseconds}");
            Console.ReadLine();

        }
    }
}
