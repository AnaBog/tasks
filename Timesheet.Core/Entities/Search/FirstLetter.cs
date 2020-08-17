using System;

namespace Timesheet.Core
{
    public class FirstLetter
    {
        private readonly string value;

        public FirstLetter(string firstLetter)
        {
            if (string.IsNullOrEmpty(firstLetter))
                throw new ArgumentException("Letter cannot be empty.");

            if (firstLetter.Length != 1)
                throw new ArgumentException("Letter contains only one character.");

            var lowerFirstLetter = firstLetter.ToLower()[0];
            
            if (lowerFirstLetter < 'a' || lowerFirstLetter > 'z')
                throw new ArgumentException("Only letters are allowed.");

            this.value = firstLetter;
        }

        public static implicit operator string(FirstLetter letter) => letter.value;

        public override string ToString()
        {
            return value;
        }
    }
}