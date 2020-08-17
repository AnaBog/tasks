using System;

namespace Timesheet.Core
{
    public class Username
    {
        private readonly string value;

        public Username(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty");
            }

            if (username.Length > 200)
            {
                throw new ArgumentException("Username cannot be greater than 200 characters");
            }

            this.value = username;
        }

        public static implicit operator string(Username username) => username.value;
        public override string ToString()
        {
            return value;
        }
    }
}