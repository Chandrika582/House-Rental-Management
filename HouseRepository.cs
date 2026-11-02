using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentalManagement
{
    public class HouseRepository
    {
        private string GetValidString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) ||
                    input.Trim().Equals("NULL", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Input cannot be empty or NULL. Please try again.");
                    continue;
                }
                return input.Trim();
            }
        }
        private int GetValidInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || input.Trim().Equals("NULL", StringComparison.OrdinalIgnoreCase) || input.Length > 10)
                {
                    throw new Exception("NULL or empty values are not allowed.");
                }
                int value;
                if (!int.TryParse(input, out value))
                {
                    throw new Exception("Please enter a valid integer.");
                }
                return value;
            }
        }
        private bool GetValidBool(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.Trim().Equals("NULL", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("NULL or empty values are not allowed.");
                }
                bool value;
                if (!bool.TryParse(input, out value))
                {
                    throw new Exception("Please enter true or false.");
                }
                return value;
            }
        }
        public string ConnectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Projects1;Integrated Security=sspi";
        //Insert Property Details
        public void InsertProperty()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("ex_procedure1", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    string title = GetValidString("Enter house title: ");
                    string address = GetValidString("Enter house address: ");
                    string city = GetValidString("Enter city: ");
                    int rent = GetValidInt("Enter monthly rent: ");
                    int deposit = GetValidInt("Enter deposit amount: ");
                    int bedrooms = GetValidInt("Enter number of bedrooms: ");
                    int bathrooms = GetValidInt("Enter number of bathrooms: ");
                    string propertyType = GetValidString("Enter property type: ");
                    bool isAvailable = GetValidBool("Is the property available? (true/false): ");
                    string owner = GetValidString("Enter owner name: ");
                    string contact = GetValidString("Enter owner contact: ");
                    SqlParameter p1 = new SqlParameter("@Action", SqlDbType.VarChar, 10);
                    p1.Value = "INSERT";
                    SqlParameter p2 = new SqlParameter("@house_title", SqlDbType.VarChar, 40);
                    p2.Value = title;
                    SqlParameter p3 = new SqlParameter("@house_address", SqlDbType.VarChar, 40);
                    p3.Value = address;
                    SqlParameter p4 = new SqlParameter("@city", SqlDbType.VarChar, 40);
                    p4.Value = city;
                    SqlParameter p5 = new SqlParameter("@monthly_rent", SqlDbType.Int);
                    p5.Value = rent;
                    SqlParameter p6 = new SqlParameter("@deposit_amount", SqlDbType.Int);
                    p6.Value = deposit;
                    SqlParameter p7 = new SqlParameter("@bedrooms", SqlDbType.Int);
                    p7.Value = bedrooms;
                    SqlParameter p8 = new SqlParameter("@bathrooms", SqlDbType.Int);
                    p8.Value = bathrooms;
                    SqlParameter p9 = new SqlParameter("@property_type", SqlDbType.VarChar, 40);
                    p9.Value = propertyType;
                    SqlParameter p10 = new SqlParameter("@is_available", SqlDbType.Bit);
                    p10.Value = isAvailable;
                    SqlParameter p11 = new SqlParameter("@property_owner", SqlDbType.VarChar, 40);
                    p11.Value = owner;
                    SqlParameter p12 = new SqlParameter("@owner_contact", SqlDbType.VarChar, 40);
                    p12.Value = contact;
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);
                    cmd.Parameters.Add(p6);
                    cmd.Parameters.Add(p7);
                    cmd.Parameters.Add(p8);
                    cmd.Parameters.Add(p9);
                    cmd.Parameters.Add(p10);
                    cmd.Parameters.Add(p11);
                    cmd.Parameters.Add(p12);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Property inserted successfully!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Insertion Exception:{e.Message}");
            }
        }
        //Update Property Details
        public void UpdateProperty()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("ex_procedure1", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    int property_id = GetValidInt("Enter property id to be updated:  ");
                    string title = GetValidString("Enter house title: ");
                    string address = GetValidString("Enter house address: ");
                    string city = GetValidString("Enter city: ");
                    int rent = GetValidInt("Enter monthly rent: ");
                    int deposit = GetValidInt("Enter deposit amount: ");
                    int bedrooms = GetValidInt("Enter number of bedrooms: ");
                    int bathrooms = GetValidInt("Enter number of bathrooms: ");
                    string propertyType = GetValidString("Enter property type: ");
                    bool isAvailable = GetValidBool("Is the property available? (true/false): ");
                    string owner = GetValidString("Enter owner name: ");
                    string contact = GetValidString("Enter owner contact: ");
                    SqlParameter p1 = new SqlParameter("@Action", SqlDbType.VarChar, 10);
                    p1.Value = "UPDATE";
                    SqlParameter p2 = new SqlParameter("@property_id", SqlDbType.Int);
                    p2.Value = property_id;
                    SqlParameter p3 = new SqlParameter("@house_title", SqlDbType.VarChar, 40);
                    p3.Value = title;
                    SqlParameter p4 = new SqlParameter("@house_address", SqlDbType.VarChar, 40);
                    p4.Value = address;
                    SqlParameter p5 = new SqlParameter("@city", SqlDbType.VarChar, 40);
                    p5.Value = city;
                    SqlParameter p6 = new SqlParameter("@monthly_rent", SqlDbType.Int);
                    p6.Value = rent;
                    SqlParameter p7 = new SqlParameter("@deposit_amount", SqlDbType.Int);
                    p7.Value = deposit;
                    SqlParameter p8 = new SqlParameter("@bedrooms", SqlDbType.Int);
                    p8.Value = bedrooms;
                    SqlParameter p9 = new SqlParameter("@bathrooms", SqlDbType.Int);
                    p9.Value = bathrooms;
                    SqlParameter p10 = new SqlParameter("@property_type", SqlDbType.VarChar, 40);
                    p10.Value = propertyType;
                    SqlParameter p11 = new SqlParameter("@is_available", SqlDbType.Bit, 40);
                    p11.Value = isAvailable;
                    SqlParameter p12 = new SqlParameter("@property_owner", SqlDbType.VarChar, 40);
                    p12.Value = owner;
                    SqlParameter p13 = new SqlParameter("@owner_contact", SqlDbType.VarChar, 40);
                    p13.Value = contact;
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);
                    cmd.Parameters.Add(p6);
                    cmd.Parameters.Add(p7);
                    cmd.Parameters.Add(p8);
                    cmd.Parameters.Add(p9);
                    cmd.Parameters.Add(p10);
                    cmd.Parameters.Add(p11);
                    cmd.Parameters.Add(p12);
                    cmd.Parameters.Add(p13);
                    cn.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result == 1)
                    {
                        Console.WriteLine("Property updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("Given property id not found.");
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Updation Exception:{e.Message}");
            }
        }
        //Delete Property Details
        public void DeleteProperty()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("ex_procedure1", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    Console.WriteLine("Enter property id to be deleted: ");
                    int property_id = Convert.ToInt32(Console.ReadLine());
                    SqlParameter p1 = new SqlParameter("@Action", SqlDbType.VarChar, 10);
                    p1.Value = "DELETE";
                    SqlParameter p2 = new SqlParameter("@property_id", SqlDbType.Int);
                    p2.Value = property_id;
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cn.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result == 1)
                    {
                        Console.WriteLine("Property details deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Given Property ID not found.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Deletion Exception: {e.Message}");
            }
        }
        //Display Property Details
        public void DisplayProperties()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand("ex_procedure1", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@Action", SqlDbType.VarChar, 10);
                    p1.Value = "DISPLAY";
                    cmd.Parameters.Add(p1);
                    cn.Open();
                    List<House> Properties = new List<House>();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int property_id = Convert.ToInt32(dr["PropertyId"]);
                            string title = dr["HouseTitle"].ToString();
                            string address = dr["HouseAddress"].ToString();
                            string city = dr["City"].ToString();
                            int rent = Convert.ToInt32(dr["MonthlyRent"]);
                            int deposit = Convert.ToInt32(dr["DepositAmount"]);
                            int bedrooms = Convert.ToInt32(dr["Bedrooms"]);
                            int bathrooms = Convert.ToInt32(dr["Bathrooms"]);
                            string propertyType = dr["PropertyType"].ToString();
                            bool isAvailable = Convert.ToBoolean(dr["IsAvailable"]);
                            DateTime createdDate = Convert.ToDateTime(dr["CreatedDate"]);
                            DateTime? updatedDate = dr["UpdatedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["UpdateDate"]);
                            string owner = dr["PropertyOwner"].ToString();
                            string contact = dr["OwnerContact"].ToString();
                            House h1 = new House(property_id, title, address, city, rent, deposit, bedrooms, bathrooms, propertyType, isAvailable, createdDate, updatedDate, owner, contact);
                            Properties.Add(h1);
                        }
                    }
                    if (Properties.Count == 0)
                    {
                        Console.WriteLine("No properties found.");
                    }
                    else
                    {
                        Console.WriteLine("Property Details: ");
                        foreach (House h in Properties)
                        {
                            Console.WriteLine($"Property ID: {h.PropertyId}");
                            Console.WriteLine($"House Title: {h.HouseTitle}");
                            Console.WriteLine($"Address: {h.Address}");
                            Console.WriteLine($"City: {h.City}");
                            Console.WriteLine($"Monthly Rent: {h.MonthlyRent}");
                            Console.WriteLine($"Deposit Amount: {h.DepositAmount}");
                            Console.WriteLine($"Bedrooms: {h.Bedrooms}");
                            Console.WriteLine($"Bathrooms: {h.Bathrooms}");
                            Console.WriteLine($"Property Type: {h.PropertyType}");
                            Console.WriteLine($"Available: {h.IsAvailable}");
                            Console.WriteLine($"Created Date: {h.CreatedDate}");
                            Console.WriteLine($"Updated Date: {h.UpdatedDate?.ToString() ?? "Not updated yet"}");
                            Console.WriteLine($"Owner: {h.PropertyOwner}");
                            Console.WriteLine($"Owner Contact: {h.OwnerContact}");
                            Console.WriteLine("-------------------------------------------------------------------------------------");

                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Diplay Exception: {e.Message}");
            }
        }
    }
}
