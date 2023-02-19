using CST_350_Minesweeper.Models;
using System.Data.SqlClient;

namespace CST_350_Minesweeper.Services
{
    public class LoginDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CST-350-Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        User loggedInUser;

        public bool FindUserByNameAndPassword(User user)
        {
            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username and password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;

                        // retrieve the user object from the database and set the loggedInUser variable
                        while (reader.Read())
                        {
                            loggedInUser = new User()
                            {
                                FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                                LastName = reader.GetString(reader.GetOrdinal("lastname")),
                                Sex = reader.GetString(reader.GetOrdinal("sex")),
                                Age = reader.GetInt32(reader.GetOrdinal("age")),
                                Username = reader.GetString(reader.GetOrdinal("username")),
                                Password = reader.GetString(reader.GetOrdinal("password")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                State = reader.GetString(reader.GetOrdinal("state")),
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return success;
        }

        public User GetUser()
        {
            return loggedInUser;
        }
    }
}