using System;
using System.Runtime.CompilerServices;

namespace Timesheet.Core
{
    public class HoursPerWeek
    {
        public readonly int value;

        public HoursPerWeek(int hoursPerWeek)
        {
            if (hoursPerWeek < 37.5)
            {
                throw new ArgumentException("Please check if you have entered all the hours correctly.");
            }

            this.value = hoursPerWeek;
        }

        public static implicit operator string(HoursPerWeek hoursPerWeek) => hoursPerWeek.value.ToString();
        public override string ToString()
        {
            return value.ToString();
        }
    }
}