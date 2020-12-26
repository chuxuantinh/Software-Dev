using System;
using System.Data.SqlClient;
using System.Linq;

namespace P04AddMinion
{
    class StartUp
    {
        private static string connectionString = "Server=DESKTOP-B842R2J\\SQLEXPRESS01;" +
            "Database=MinionsDB;" +
            "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        private static SqlTransaction transaction;

        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()
                .Split(": ")
                .ToArray();

            string[] infoFromInput1 = input1[1]
                .Split()
                .ToArray();

            string minionName = infoFromInput1[0];
            int minionAge = int.Parse(infoFromInput1[1]);
            string minionTown = infoFromInput1[2];

            string[] input2 = Console.ReadLine()
                .Split(": ")
                .ToArray();

            string[] infoFromInput2 = input2[1]
                .Split()
                .ToArray();

            string villainName = infoFromInput2[0];

            connection.Open();

            using (connection)
            {
                transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = @"SELECT Id FROM Towns WHERE Name = @townName";
                    command.Parameters.AddWithValue("@townName", minionTown);

                    object value = command.ExecuteScalar();

                    if (value == null)
                    {
                        command.CommandText = @"INSERT INTO Towns (Name) VALUES (@townName)";
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Town {minionTown} was added to the database.");

                        command.CommandText = @"SELECT Id FROM Towns WHERE Name = @townName";
                        
                        value = command.ExecuteScalar();
                    }

                    int townId = (int)value;

                    command.CommandText = @"SELECT Id FROM Villains WHERE Name = @villainName";
                    command.Parameters.AddWithValue("@villainName", villainName);

                    value = command.ExecuteScalar();

                    if (value == null)
                    {
                        command.CommandText = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                        
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Villain {villainName} was added to the database.");

                        command.CommandText = @"SELECT Id FROM Villains WHERE Name = @villainName";
                        
                        value = command.ExecuteScalar();
                    }

                    int villainId = (int)value;

                    command.CommandText = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
                    command.Parameters.AddWithValue("@name", minionName);
                    command.Parameters.AddWithValue("@age", minionAge);
                    command.Parameters.AddWithValue("@townId", townId);
                    command.ExecuteNonQuery();

                    command.CommandText = @"SELECT Id FROM Minions WHERE Name = @name";
                    
                    value = command.ExecuteScalar();

                    int minionId = (int)value;

                    command.CommandText = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
                    command.Parameters.AddWithValue("@villainId", villainId);
                    command.Parameters.AddWithValue("@minionId", minionId);
                    command.ExecuteNonQuery();

                    transaction.Commit();

                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

                }
                catch (Exception e)
                {
                    try
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                    catch (Exception re)
                    {
                        Console.WriteLine(re.Message);
                    }
                }
            }
        }
    }
}
