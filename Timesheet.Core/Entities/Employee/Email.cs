using System;

namespace Timesheet.Core
{
    public class Email
    {
        private readonly string value;

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty");
            }

            if (email.Length > 50)
            {
                throw new ArgumentException("Email cannot be longer than 50 characters");
            }

            this.value = email;
        }

        public static implicit operator string(Email email) => email.value;
        public override string ToString()
        {
            return value;
        }
    }
}