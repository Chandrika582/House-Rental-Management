using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentalManagement
{
    public class HouseManagementUI
    {
        public string GetPassword(string message)
        {
            Console.Write(message);
            string password = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

            return password;
        }
        public void RegisterClient()
        {
            AuthenticationRepository repository = new AuthenticationRepository();

            Console.WriteLine("CLIENT REGISTRATION");

            string username = GetValidString("Enter username: ");

            string password;

            while (true)
            {
                password = GetPassword("Enter password: ");

                if (IsValidPassword(password))
                {
                    break;
                }

                Console.WriteLine("Password must contain:");
                Console.WriteLine("- Minimum 8 characters");
                Console.WriteLine("- One uppercase letter");
                Console.WriteLine("- One lowercase letter");
                Console.WriteLine("- One digit");
                Console.WriteLine("- One special character");
            }
            string confirmPassword;
            while (true)
            {
                confirmPassword = GetPassword("Confirm password: ");
                if (password == confirmPassword)
                {
                    Console.WriteLine("Password confirmed successfully!");
                    break;
                }
                else
                {
                    Console.WriteLine("Passwords do not match! Please try again.");
                }
            }
            try
            {
                repository.RegisterClient(username, password);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Registration failed: {e.Message}");
            }
        }
        public void Start()
        {
            AuthenticationRepository repository = new AuthenticationRepository();

            while (true)
            { 
                Console.WriteLine("HOUSE RENT MANAGEMENT SYSTEM");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register as Client");
                Console.WriteLine("3. Exit");
                Console.Write("Please enter your choice: ");

                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid choice.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        LoginUser();
                        return;

                    case 2:
                        RegisterClient();
                        break;

                    case 3:
                        Console.WriteLine("Thank you for using House Rent Management!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
        public string GetValidString(string message)
        {
            string input;
            while (true)
            {
                Console.Write(message);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || input.Trim().Equals("null", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Input cannot be empty or null. Please try again.");
                }
                else
                {
                    return input.Trim();
                }
            }
        }
        public bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
        public void LoginUser()
        {
            AuthenticationRepository repository = new AuthenticationRepository();

            while (true)
            {
                Console.WriteLine("HOUSE RENT MANAGEMENT LOGIN ");

                string username = GetValidString("Enter username:");

                string password = GetPassword("Enter password: ");

                string role = repository.Login(username, password);

                if (role == null)
                {
                    Console.WriteLine("Invalid username or password. Try again.");
                    continue;
                }
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine($"Welcome, {username}!");
                Console.WriteLine($"Role: {role}");

                User user;

                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    user = new Admin(username, role);
                }
                else if (role.Equals("Client", StringComparison.OrdinalIgnoreCase))
                {
                    user = new Client(username, role);
                }
                else
                {
                    Console.WriteLine("Invalid account role.");
                    return;
                }

                user.ShowMenu();
                return;
            }
        }
    }
}
