using System;

namespace Timesheet.Core
{
    public class EntryDescription
    {
        private readonly string value;

        public EntryDescription(string entryDescription)
        {
            if (string.IsNullOrEmpty(entryDescription))
            {
                throw new ArgumentException("Description name cannot be empty");
            }

            if (entryDescription.Length > 400)
            {
                throw new ArgumentException("Description cannot be longer than 200 characters");
            }

            this.value = entryDescription;
        }

        public static implicit operator string(EntryDescription entryDescription) => entryDescription.value;
        public override string ToString()
        {
            return value;
        }
    }
}