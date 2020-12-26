using System;
using System.Data.SqlClient;

namespace P03MinionNames
{
    class StartUp
    {
        private static string connectionString = "Server=DESKTOP-B842R2J\\SQLEXPRESS01;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"SELECT Name FROM Villains WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", villainId);

                object value = command.ExecuteScalar();

                if (value == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                string villainName = (string)value;

                command.CommandText = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Villain: {villainName}");

                if (reader == null)
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                        }
                    }
                }
            }
        }
    }
}
