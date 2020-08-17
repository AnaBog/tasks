using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using Timesheet.Core;
using Timesheet.Core.Repositories;

namespace Timesheet.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees;

        public EmployeeRepository()
        {
            this.employees = new List<Employee>();
            this.employees.Add(new Employee(Guid.Parse("00000000-0000-0000-0000-00000000000e"), new EmployeeName("Io"), new Username("Bloodseeker"), new HoursPerWeek(40), new Email("grass@gmail.com"), new EmployeeStatus(true), new Role("Worker")));
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public void Delete(Guid id)
        {
            employees.RemoveAll(em => em.Id == id);
        }

        public Maybe<Employee> GetById(Guid id)
        {
            return employees.Find(employee => employee.Id == id);
        }

        public Maybe<Employee> GetByEmail(Email email)
        {
            return employees.Find(employee => employee.Email == email);
        }

        //public PagedEmployees SearchEmployees(EmployeeSearchParams query)
        //{
        //    var searchQuery = employees
        //        .Where(employee => employee.Name.Contains(query.SearchText))
        //        .Where(employee => employee.Name.StartsWith(query.FirstLetter));
        //
        //    int foundEmployees = searchQuery.Count();
        //
        //    IEnumerable<Employee> filteredEmployees = searchQuery
        //        .Skip(Constants.PageSize * (query.PageNumber - 1))
        //        .Take(Constants.PageSize)
        //        .ToList();
        //
        //    PagedEmployees pagedEmployees = new PagedEmployees(filteredEmployees, foundEmployees, query.PageNumber, Constants.PageSize);
        //    return pagedEmployees;
        //}

        public Employee Update(Employee employee, Guid id)
        {
            Employee oldEmployee = employees.Find(employee => employee.Id == id);
            employees.Remove(oldEmployee);
            employees.Add(employee);
            return employee;
        }
    }
}