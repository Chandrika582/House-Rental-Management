using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentalManagement
{
    public class AuthenticationRepository
    {
        private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Projects1;Integrated Security=True";

        public void CreateInitialAdmin()
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Role = @Role";
                using (SqlCommand Cmd = new SqlCommand(checkQuery, cn))
                {
                    Cmd.Parameters.Add("@Role", SqlDbType.VarChar, 20).Value = "Admin";
                    int count = Convert.ToInt32(Cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        Console.WriteLine("Admin account already exists.");
                        return;
                    }
                }
                Console.Write("Enter Admin username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Admin password: ");
                string password = Console.ReadLine();
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

                string insertQuery ="INSERT INTO Users (UserName, PasswordHash, Role) VALUES (@UserName, @PasswordHash, @Role)";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, cn))
                    {
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = username;
                        cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 255).Value = passwordHash;
                        cmd.Parameters.Add("@Role", SqlDbType.VarChar, 20).Value = "Admin";
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Admin account created successfully!");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public string Login(string username, string password)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    cn.Open();
                    string query = "SELECT PasswordHash, Role FROM Users WHERE UserName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = username;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string storedHash = dr["PasswordHash"].ToString();
                                string role = dr["Role"].ToString();
                                if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                                {
                                    return role;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Login Exception: {e.Message}");
                return null;
            }
            return null;
        }
        public void RegisterClient(string username, string password)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                string query = @"INSERT INTO Users(UserName, PasswordHash, Role)VALUES (@UserName, @PasswordHash, @Role)";
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = username;
                    cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 255).Value = passwordHash;
                    cmd.Parameters.Add("@Role", SqlDbType.VarChar, 20).Value = "Client";
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Client registration successful!");
            }
        }
    }
}
