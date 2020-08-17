namespace Timesheet.Core
{
    public class TotalHoursPerDay
    {
        private readonly double value;

        public TotalHoursPerDay(double totalHoursPerDay)
        {
            this.value = totalHoursPerDay;
        }

        public static implicit operator double(TotalHoursPerDay totalHoursPerDay) => totalHoursPerDay.value;

        public override string ToString()
        {
            return value.ToString();
        }
    }
}