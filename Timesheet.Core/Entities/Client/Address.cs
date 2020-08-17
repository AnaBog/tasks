using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Timesheet.Core
{
    public class Address
    {
       private readonly string value;
       private readonly string street;
       private readonly string streetNumber;

       public Address(string address)
        {
            Regex regex = new Regex(@"(.*?)\s*(\d+(?:[/-]\d+)?)?$");
            Match result = regex.Match(address);

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException("Address cannot be empty.");
            }

            if(address.Length > 200)
            {
                throw new ArgumentException("Address cannot be longer than 200 characters.");
            }

            this.value = address;
            this.street = result.Groups[1].Value.ToString();
            this.streetNumber = result.Groups[2].Value.ToString();

            if (string.IsNullOrEmpty(streetNumber))
            {
                throw new ArgumentException("Please enter a street number.");
            }
        }

        public Address ChangeStreetNumber(string streetNumber) {
            string address = $"{this.street} {streetNumber}";
            return new Address(address);
        }

        public static implicit operator string(Address address) => address.value;
        public override string ToString()
        {
            return value;
        }
    }
}
