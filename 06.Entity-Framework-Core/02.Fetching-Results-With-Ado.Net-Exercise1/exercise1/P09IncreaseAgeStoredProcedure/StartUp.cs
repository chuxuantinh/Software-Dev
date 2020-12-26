using System;
using System.Data.SqlClient;

namespace P09IncreaseAgeStoredProcedure
{
    class StartUp
    {
        private static string connectionString = "Server=DESKTOP-B842R2J\\SQLEXPRESS01;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            while (true)
            {
                int minionId = int.Parse(Console.ReadLine());

                connection.Open();

                using (connection)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = @"EXEC usp_GetOlder @id";
                    command.Parameters.AddWithValue("@id", minionId);
                    command.ExecuteNonQuery();

                    command.CommandText = @"SELECT Name, Age FROM Minions WHERE Id = @MinionId";
                    command.Parameters.AddWithValue("@MinionId", minionId);

                    SqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");
                        }
                    }
                }
            }
        }
    }
}
