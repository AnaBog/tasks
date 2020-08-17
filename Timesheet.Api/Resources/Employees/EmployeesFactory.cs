using System;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class EmployeesFactory
    {
        public Employee Create(EmployeeDto employeeDto)
        {
            var employeeId = Guid.NewGuid();
            return new Employee(
                employeeId,
                new EmployeeName(employeeDto.Name),
                new Username(employeeDto.Username),
                new HoursPerWeek(Int32.Parse(employeeDto.HoursPerWeek)),
                new Email(employeeDto.Email),
                new EmployeeStatus(employeeDto.EmployeeStatus),
                new Role(employeeDto.Role)
            );
        }

        public Employee Update(EmployeeDto employeeDto)
        {
            return new Employee(
                Guid.Parse(employeeDto.Id),
                new EmployeeName(employeeDto.Name),
                new Username(employeeDto.Username),
                new HoursPerWeek(Int32.Parse(employeeDto.HoursPerWeek)),
                new Email(employeeDto.Email),
                new EmployeeStatus(employeeDto.EmployeeStatus),
                new Role(employeeDto.Role)
            );
        }
    }
}
