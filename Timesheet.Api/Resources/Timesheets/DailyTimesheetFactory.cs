using CSharpFunctionalExtensions;
using System;
using System.Linq;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class DailyTimesheetFactory
    {
        private readonly TimesheetEntryFactory timesheetEntryFactory;
        private readonly EmployeeService employeeService;

        public DailyTimesheetFactory(TimesheetEntryFactory timesheetEntryFactory, EmployeeService employeeService)
        {
            this.timesheetEntryFactory = timesheetEntryFactory;
            this.employeeService = employeeService;
        }

        public DailyTimesheet Create(DailyTimesheetDto dailyTimesheetDto)
        {
            var dailyTimesheetId = Guid.NewGuid();
            
            Maybe<Employee> employee = this.employeeService.GetById(Guid.Parse(dailyTimesheetDto.EmployeeId));

            if (employee.HasNoValue) 
            {
                throw new ArgumentException("You cannot create a Daily Timesheet for a non-existing employee.");
            }

            return new DailyTimesheet(
                dailyTimesheetId,
                DateTime.Parse(dailyTimesheetDto.Date),
                employee.Value,
                dailyTimesheetDto.TimesheetEntries.Select(el => this.timesheetEntryFactory.Create(el))
            );
        }
    }
}