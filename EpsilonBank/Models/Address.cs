namespace EpsilonBank.Models
{
    public class Address
    {
        public Address(string streetLine, string city, string state, string country)
        {
            StreetLine1 = streetLine;
            City = city;
            State = state;
            Country = country;
        }
        public string StreetLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
