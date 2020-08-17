namespace Timesheet.Core
{
    public class Lead
    {
        private readonly string value;

        public Lead(string lead)
        {
            this.value = lead;
        }

        public static implicit operator string(Lead lead) => lead.value;
        public override string ToString()
        {
            return value;
        }
    }
}