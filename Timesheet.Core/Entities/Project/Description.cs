using System;

namespace Timesheet.Core
{
    public class Description
    {
        private readonly string value;

        public Description(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description name cannot be empty");
            }

            if (description.Length > 400)
            {
                throw new ArgumentException("Description cannot be longer than 400 characters");
            }

            this.value = description;
        }

        public static implicit operator string(Description description) => description.value;
        public override string ToString()
        {
            return value;
        }
    }
}