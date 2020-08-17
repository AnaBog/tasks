namespace Timesheet.Core
{
    public class Status
    {
        private readonly string value;
        public Status(string status)
        {
            this.value = status;
        }

        public static implicit operator string(Status status) => status.value;
        public override string ToString()
        {
            return value;
        }
    }
}