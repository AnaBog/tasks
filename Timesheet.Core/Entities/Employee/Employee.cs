using System;

namespace Timesheet.Core
{
    public class Employee
    {
        private readonly Guid id;
        private readonly EmployeeName name;
        private readonly Username username;
        private readonly HoursPerWeek hoursPerWeek;
        private readonly Email email;
        private readonly EmployeeStatus employeeStatus;
        private readonly Role role;

        public Employee(Guid id, EmployeeName name, Username username, HoursPerWeek hoursPerWeek, Email email, EmployeeStatus status, Role role)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.hoursPerWeek = hoursPerWeek;
            this.email = email;
            this.employeeStatus = status;
            this.role = role;
        }
        public Guid Id => id;
        public EmployeeName Name => name;
        public Username Username => username;
        public HoursPerWeek HoursPerWeek => hoursPerWeek;
        public Email Email => email;
        public EmployeeStatus EmployeeStatus => employeeStatus;
        public Role Role => role;

    }
}
