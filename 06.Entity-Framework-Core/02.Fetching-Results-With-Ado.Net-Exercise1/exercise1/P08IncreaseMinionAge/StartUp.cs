using System;
using System.Data.SqlClient;
using System.Linq;

namespace P08IncreaseMinionAge
{
    class StartUp
    {
        private static string connectionString = "Server=DESKTOP-B842R2J\\SQLEXPRESS01;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            int[] ids = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"UPDATE Minions
                                        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                        WHERE Id = @Id";

                for (int i = 0; i < ids.Length; i++)
                {
                    command.Parameters.AddWithValue("@Id", ids[i]);
                    command.ExecuteNonQuery();
                }

                command.CommandText = @"SELECT Name, Age FROM Minions";

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}
