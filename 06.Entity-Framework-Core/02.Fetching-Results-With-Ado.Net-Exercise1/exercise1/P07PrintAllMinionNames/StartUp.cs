using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P07PrintAllMinionNames
{
    class StartUp
    {
        private static string connectionString = "Server=DESKTOP-B842R2J\\SQLEXPRESS01;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            connection.Open();

            using (connection)
            {
                string queryText = @"SELECT Name FROM Minions";

                SqlCommand command = new SqlCommand(queryText, connection);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    List<string> names = new List<string>();
                    int count = 0;

                    while (reader.Read())
                    {
                        names.Add(reader["Name"].ToString());
                        count++;
                    }

                    if (count % 2 == 0)
                    {
                        for (int i = 0; i < names.Count / 2; i++)
                        {
                            Console.WriteLine(names[i]);
                            Console.WriteLine(names[names.Count - 1 - i]);
                        }
                    }
                    else if (count % 2 != 0)
                    {
                        for (int i = 0; i < names.Count / 2; i++)
                        {
                            Console.WriteLine(names[i]);
                            Console.WriteLine(names[names.Count - 1 - i]);
                        }
                        Console.WriteLine(names[names.Count / 2]);
                    }

                }
            }
        }
    }
}
