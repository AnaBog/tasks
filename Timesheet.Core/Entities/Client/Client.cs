using System;

namespace Timesheet.Core
{
    public class Client
    {
        public Client(Guid id, ClientName name, Address address, City city, Country country, ZipCode zipCode)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.City = city;
            this.Country = country;
            this.ZipCode = zipCode; 
        }

        public ClientName Name { get; }
        public Guid Id { get; }
        public Address Address { get; }
        public City City { get; }
        public ZipCode ZipCode { get; }
        public Country Country { get; }

        public Client ChangeAddress(Address address) {
            return new Client(Id, Name, address, City, Country, ZipCode);
        }

        public bool IsDoo => Name.IsDoo();
    }
}
