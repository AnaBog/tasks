using System;

namespace Timesheet.Core
{
    public class Overtime
    {
        public readonly int value;

        public Overtime(int overtime)
        {
            if (overtime > 3)
            {
                throw new ArgumentException("You cannot enter more than three hours overtime.");
            }

            this.value = overtime;
        }

        public static implicit operator int(Overtime overtime) => overtime.value;

        public override string ToString()
        {
            return value.ToString();
        }
    }
}