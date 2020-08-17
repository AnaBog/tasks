using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheet.Core
{
    public class City
    {
        private readonly string value;

        public City(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentException("City cannot be empty");
            }

            if (city.Length > 80)
            {
                throw new ArgumentException("City cannot be longer than 80 characters");
            }

            this.value = city;
        }

        public static implicit operator string(City city) => city.value;

        public override string ToString()
        {
            return value;
        }
    }
}
