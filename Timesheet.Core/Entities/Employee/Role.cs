namespace Timesheet.Core
{
    public class Role
    {
        private readonly string value;

        public Role(string role)
        {
            this.value = role;
        }

        public static implicit operator string(Role role) => role.value;
        public override string ToString()
        {
            return value;
        }
    }
}