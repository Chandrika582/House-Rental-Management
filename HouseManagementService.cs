using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentalManagement
{
    public class HouseManagementService
    {
        public void ExecuteChoice(int Choice, string Role)
        {
            HouseRepository repository = new HouseRepository();

            if (string.IsNullOrWhiteSpace(Role))
            {
                Console.WriteLine("Access denied. Invalid user role.");
                return;
            }

            if (Role.Equals("ADMIN", StringComparison.OrdinalIgnoreCase))
            {
                switch (Choice)
                {
                    case 1:
                        repository.InsertProperty();
                        break;

                    case 2:
                        repository.UpdateProperty();
                        break;

                    case 3:
                        repository.DeleteProperty();
                        break;

                    case 4:
                        repository.DisplayProperties();
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using House Rental Management.");
                        break;

                    default:
                        Console.WriteLine("Invalid Admin operation.");
                        break;
                }
            }
            else if (Role.Equals("CLIENT", StringComparison.OrdinalIgnoreCase))
            {
                switch (Choice)
                {
                    case 1:
                        repository.DisplayProperties();
                        break;

                    case 2:
                        Console.WriteLine("Thank you for using House Rental Management.");
                        break;

                    default:
                        Console.WriteLine("Access denied! You don't have permission for this operation.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Access denied. Invalid role.");
            }
        }
    }
}
