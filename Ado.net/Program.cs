using Ado.net.Utils;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ado.net
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await GetAllEmployee();
            //await GetEmployeeById(2);
            //await AddEmployee("elgun Behmenli");
            //await DeleteEmployeeById(4);
            //await FilterByName("g");
        }
        public async static Task FilterByName(string search)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string command = $"SELECT * FROM Employee WHERE Fullname LIKE '%{search}%'";
                using (SqlCommand sqlcommand = new SqlCommand(command, connection))
                {
                    SqlDataReader reader = await sqlcommand.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }

            }
        }
        public async static Task DeleteEmployeeById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string queryString = $"DELETE FROM Employee  WHERE Id={id}";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    int result = await command.ExecuteNonQueryAsync();
                    if (result > 0)
                    {
                        Console.WriteLine("Emeliyyat yerine yetirildi!");
                    }
                    else
                    {
                        Console.WriteLine("Sehvlik Bash Verdi");
                    }
                }
            }
        }
        public async static Task AddEmployee(string fullname)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string queryString = $"INSERT INTO Employee VALUES('{fullname}')";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    int result = await command.ExecuteNonQueryAsync();
                    if (result > 0)
                    {
                        Console.WriteLine("Emeliyyat yerine yetirild!");
                    }
                    else
                    {
                        Console.WriteLine("Sehvlik Bash Verdi!");
                    }
                }

            }
        }
        public async static Task GetAllEmployee()
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string command = "SELECT * FROM Employee";
                using (SqlCommand sqlcommand = new SqlCommand(command, connection))
                {
                    SqlDataReader reader = await sqlcommand.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }
        public async static Task GetEmployeeById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string command = $"SELECT Fullname FROM Employee WHERE Id ={id}";
                using (SqlCommand sqlcommand = new SqlCommand(command, connection))
                {
                    SqlDataReader reader = await sqlcommand.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }
    }
}
