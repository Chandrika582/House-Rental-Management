using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentalManagement
{
    public abstract class User
    {
        private string UserName;
        private string Role;
        public string Name
        {
            get
            {
                return UserName;
            }
        }
        public string UserRole
        {
            get
            {
                return Role;
            }
        }
        public int Choice;
        public User(string UserName, string Role)
        {
            this.UserName = UserName;
            this.Role = Role;
            Console.WriteLine("Welcome to House Rent Management System");
        }
        public abstract void ShowMenu();
        public int GetValidInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.Trim().Equals("NULL", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Input cannot be empty or null. Please try again.");
                    continue;
                }

                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer.");
                }
            }
        }
    }
    public class Admin : User
    {
       public Admin(string UserName,string Role):base(UserName, Role)
        {
            
        }
        public override void ShowMenu()
        {
            HouseManagementService service = new HouseManagementService();
            try
            {
                do
                {
                    Console.WriteLine("Please choose one option from the below list: ");
                    Console.WriteLine("1. Add new Property");
                    Console.WriteLine("2. Modify existing Property");
                    Console.WriteLine("3. Delete existing Property");
                    Console.WriteLine("4. Display all the properties");
                    Console.WriteLine("5. Exit");
                    Choice = GetValidInt("Enter your choice: ");
                    if ((Choice > 0) && (Choice <= 5))
                    {
                        service.ExecuteChoice(Choice, UserRole);
                    }
                    else
                    {
                        Console.WriteLine("Enter valid choice");
                    }
                } while (Choice != 5);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

    }
    public class Client : User
    {
        public Client(string UserName,string Role) : base(UserName, Role)
        {

        }
        public override void ShowMenu()
        {
            HouseManagementService service = new HouseManagementService();
            try
            {
                do
                {
                    Console.WriteLine("Please choose one option from the below list: ");
                    Console.WriteLine("1. Display all the properties");
                    Console.WriteLine("2. Exit");
                    Choice = GetValidInt("Enter your choice:");
                    if (Choice == 1 || Choice == 2)
                    {
                        service.ExecuteChoice(Choice, UserRole);
                    }
                    else
                    {
                        Console.WriteLine("Enter user valid operation.");
                    }
                } while (Choice != 2);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
