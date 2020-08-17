using CSharpFunctionalExtensions;
using System;
using Timesheet.Core.Repositories;

namespace Timesheet.Core
{
    public class EmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Add(Employee employee)
        {
            Maybe<Employee> maybeEmployee = _employeeRepository.GetByEmail(employee.Email);

            if (maybeEmployee.HasValue)
            {
                throw new InvalidOperationException("This email is already registred, please enter another email.");
            }
            _employeeRepository.Add(employee);
        }

        public Maybe<Employee> GetById(Guid employeeId)
        {
            return _employeeRepository.GetById(employeeId);
        }

        public void Delete(Guid id)
        {
            Maybe<Employee> maybeEmployee = _employeeRepository.GetById(id);

            if (maybeEmployee.HasNoValue)
            {
                throw new InvalidOperationException("You cannot delete a non-existant employee.");
            }
            _employeeRepository.Delete(id);
        }

        //public PagedEmployees Search(EmployeeSearchParams query)
        //{
        //    return _employeeRepository.SearchEmployees(query);
        //}

        public void Update(Employee employee, Guid id)
        {
            Maybe<Employee> maybeEmployee = _employeeRepository.GetById(id);

            if (maybeEmployee.HasNoValue)
            {
                throw new InvalidOperationException("There is no employee under this name/username.");
            }

            _employeeRepository.Update(employee, id);
        }
    }
}
