using CSharpFunctionalExtensions;
using System;

namespace Timesheet.Core.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Delete(Guid Id);
        Employee Update(Employee employee, Guid id);

        //PagedEmployees SearchEmployees(EmployeeSearchParams query);
        Maybe<Employee> GetById(Guid id);
        Maybe<Employee> GetByEmail(Email email);
    }
}
