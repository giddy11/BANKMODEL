using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonBank.Models
{
    public class Customer
    {
        public Customer()
        {
            Accounts = new List<Account>();
        }
        public Customer(string firstName,string lastName, float age, string emailAddress, Address houseAddress, string phoneNumber, string password) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EmailAddress = emailAddress;
            HouseAddress = houseAddress;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public float Age { get; set; }
        public string EmailAddress { get; set; }
        public Address HouseAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public List<Account> Accounts { get; set; }


    }
}
