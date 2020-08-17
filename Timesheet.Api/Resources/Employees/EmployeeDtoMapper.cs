using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class EmployeeDtoMapper
    {
        public EmployeeDto Map(Employee employee)
        {
            EmployeeDto employeeDto = new EmployeeDto();
            employeeDto.Id = employee.Id.ToString();
            employeeDto.Name = employee.Name;
            employeeDto.Username = employee.Username;
            employeeDto.HoursPerWeek = employee.HoursPerWeek;
            employeeDto.Email = employee.Email;
            employeeDto.EmployeeStatus = employee.EmployeeStatus;
            employeeDto.Role = employee.Role;
            return employeeDto;
        }
    }
}
