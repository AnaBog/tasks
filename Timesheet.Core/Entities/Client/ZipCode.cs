using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheet.Core
{
    public class ZipCode
    {
        private readonly int value;

        public ZipCode(string zipCodeText)
        {
            int zipCode;
            if (!int.TryParse(zipCodeText, out zipCode))
            {
                throw new ArgumentException("ZipCode cannot be a number.");
            }

            this.value = zipCode;
        }

        public static implicit operator int(ZipCode zipCode) => zipCode.value;

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
