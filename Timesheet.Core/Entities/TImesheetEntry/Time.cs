using System;

namespace Timesheet.Core
{
    public class Time
    {
        public readonly double value;

        public Time(double time)
        {
            if (time <= 0)
            {
                throw new ArgumentException("Minimum number of hours per entry must be greater than zero.");
            }

            if (time > 7.5)
            {
                throw new ArgumentException("Maximum number of hours per entry is 7.5.");
            }

            this.value = time;
        }

        public static implicit operator double(Time time) => time.value;

        public override string ToString()
        {
            return value.ToString();
        }
    }
}