using System;
using System.Data.SqlClient;
using CST_350_Minesweeper.Models;

namespace CST_350_Minesweeper.Services
{
    public class RegisterDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CST-350-Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool RegisterUserAccount(User user)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(
                    "SELECT COUNT(*) FROM [users] WHERE Email = @Email",
                    connection);

                command.Parameters.AddWithValue("@Email", user.Email);

                try
                {
                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // User already exists
                        success = false;
                    }
                    else
                    {
                        // User does not exist, insert new row
                        command.CommandText = "INSERT INTO [users] (FirstName, LastName, Sex, Age, State, Email, Username, Password) VALUES (@FirstName, @LastName, @Sex, @Age, @State, @Email, @Username, @Password)";

                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                        command.Parameters.AddWithValue("@Sex", user.Sex);
                        command.Parameters.AddWithValue("@Age", user.Age);
                        command.Parameters.AddWithValue("@State", user.State);
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // User inserted successfully
                            success = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }

    }
}
