using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentalManagement
{
    public class House
    {
        public int PropertyId;
        public string HouseTitle;
        public string Address;
        public string City;
        public int MonthlyRent;
        public int DepositAmount;
        public int Bedrooms;
        public int Bathrooms;
        public string PropertyType;
        public bool IsAvailable;
        public DateTime CreatedDate;
        public DateTime? UpdatedDate;
        public string PropertyOwner;
        public string OwnerContact;
        public House(int PropertyId, string HouseTitle,string Address,string City,int MonthlyRent,int DepositAmount,int Bedrooms,int Bathrooms,string PropertyType,bool IsAvailable,DateTime CreatedDate, DateTime? UpdatedDate, string PropertyOwner,string OwnerContact)
        {
            try
            {
                this.PropertyId = PropertyId;
                this.HouseTitle = HouseTitle;
                this.Address = Address;
                this.City = City;
                this.MonthlyRent = MonthlyRent;
                this.DepositAmount = DepositAmount;
                this.Bedrooms = Bedrooms;
                this.Bathrooms = Bathrooms;
                this.PropertyType = PropertyType;
                this.IsAvailable = IsAvailable;
                this.CreatedDate = CreatedDate;
                this.UpdatedDate = UpdatedDate;
                this.PropertyOwner = PropertyOwner;
                this.OwnerContact = OwnerContact;
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
                Console.WriteLine("Null values can not be inserted.");
            }
           
        }
    }
}
