using System;

namespace Timesheet.Core
{
    public class EmployeeStatus
    {
        private readonly bool value;

        public EmployeeStatus(bool employeeStatus)
        {
            this.value = employeeStatus;
        }

        public static implicit operator bool(EmployeeStatus employeeStatus) => employeeStatus.value;
        public override string ToString()
        {
            return value.ToString();
        }
    }
}