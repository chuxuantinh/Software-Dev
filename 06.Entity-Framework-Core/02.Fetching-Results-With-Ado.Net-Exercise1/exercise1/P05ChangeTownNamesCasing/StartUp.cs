using System;
using System.Data.SqlClient;

namespace P05ChangeTownNamesCasing
{
    class StartUp
    {
        private static string connectionString = "Server=DESKTOP-B842R2J\\SQLEXPRESS01;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"UPDATE Towns
                                        SET Name = UPPER(Name)
                                        WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                command.Parameters.AddWithValue("@countryName", countryName);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                Console.WriteLine($"{rowsAffected} town names were affected.");

                command.CommandText = @"SELECT t.Name 
                                        FROM Towns as t
                                        JOIN Countries AS c ON c.Id = t.CountryCode
                                        WHERE c.Name = @countryName";

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"[{string.Join(", ", reader["Name"])}]");
                    }
                }
            }
        }
    }
}
