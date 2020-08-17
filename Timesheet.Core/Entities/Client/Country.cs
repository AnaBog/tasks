using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheet.Core
{
    public class Country
    {
        private static readonly IEnumerable<string> countries = new List<string>
        {
            "Serbia", "US"
        };

        private readonly string value;

        public Country(string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                throw new ArgumentException("Country cannot be empty");
            }

            if (country.Length > 100)
            {
                throw new ArgumentException("Country cannot be longer than 100 characters");
            }

            this.value = country;
        }

        public static implicit operator string(Country country) => country.value;

        public override string ToString()
        {
            return value;
        }
    }
}
