using System;
using System.Data.SqlClient;

namespace AdoNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var town = new Town
            //{
            //    Name = "Sofia"
            //};

            //db.SaveChanges();

            //var towns = db.
            //    Towns.
            //    Where(t => t.Name == "Sofia").
            //    ToList();

            //var connection = new SqlConnection(@"Server=DESKTOP-B842R2J\SQLEXPRESS01;Database=SoftUni;Integrated Security=True");
            //var command = new SqlCommand("SELECT * ...", connection);

            //var result = command.ExecuteReader();

            var connection = new SqlConnection(@"Server=DESKTOP-B842R2J\SQLEXPRESS01;Database=SoftUni;Integrated Security=True");

            connection.Open();

            var firstName = "Kevin";

            var firstName = "' OR 1=1 --";

            using (connection)
            {
                var command = new SqlCommand(
                    $"SELECT COUNT(*) FROM Employees WHERE FirstName = '{firstName}'",
                    connection);

                var command = new SqlCommand(
                   $"SELECT COUNT(*) FROM Employees WHERE FirstName = @name AND Age = @age",
                   connection);

                command.Parameters.AddWithValue("@name", firstName);
                command.Parameters.AddWithValue("@age", 5);

                var result = (int)command.ExecuteScalar();

                Console.WriteLine(result);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[1] + " " + reader[2]);
                    }
                }

                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var firstName = reader["Firstname"];
                        var lastName = reader["LastName"];
                        var title = reader["JobTitle"];

                        var result = firstName + " " + lastName + " " + title;

                        Console.WriteLine(result);
                    }
                }

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var firstName = reader[1];
                        var lastName = reader[2];
                        var title = reader[4];

                        var result = firstName + " " + lastName + " " + title;

                        Console.WriteLine(result);
                    }
                }

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + " ");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
