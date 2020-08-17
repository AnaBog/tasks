using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Timesheet.Core;
using Timesheet.Core.Repositories;

namespace Timesheet.Infrastructure
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly List<DailyTimesheet> dailyTimesheets;
        // Timesheet (id, dailyTimesheetId, date, clientId, projectId, employeeId, desc, time, ot)
                     //(1, 1, 17-07-2020, 1, 1, 1, '', 4.5, 0)
                     //(2, 1, 17-07-2020, 1, 2, 1, '', 2.5, 0)
        public TimesheetRepository()
        {
            var timesheetEntries2 = new List<TimesheetEntry>
            {
                new TimesheetEntry(
                    Guid.NewGuid(),
                    Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                    Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    new EntryDescription("This is the description of one entry."),
                    new Time(5),
                    new Overtime(0)
                )
            };

            var timesheetEntries = new List<TimesheetEntry>
            {
                new TimesheetEntry(
                    Guid.NewGuid(),
                    Guid.Parse("00000000-0000-0000-0000-00000000000c"),
                    Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    new EntryDescription("This is the description of one entry."),
                    new Time(7.5),
                    new Overtime(2)
                )
            };

            this.dailyTimesheets = new List<DailyTimesheet>
            {
                 new DailyTimesheet(
                    Guid.NewGuid(),
                    new DateTime(2020, 7, 17),
                    new Employee(Guid.NewGuid(), new EmployeeName("Ana Bogdanovic"), new Username("Chasa"), new HoursPerWeek(50), new Email("anaa@gmail.com"), new EmployeeStatus(true), new Role("admin") ),
                    timesheetEntries
                ),

                 new DailyTimesheet(
                    Guid.NewGuid(),
                    new DateTime(2020, 7, 18),
                    new Employee(Guid.NewGuid(), new EmployeeName("Ana Bogdanovic"), new Username("Chasa"), new HoursPerWeek(50), new Email("anaa@gmail.com"), new EmployeeStatus(true), new Role("admin") ),
                    timesheetEntries2
                ),

                 new DailyTimesheet(
                    Guid.NewGuid(),
                    new DateTime(2020, 7, 19),
                    new Employee(Guid.NewGuid(), new EmployeeName("Ana Bogdanovic"), new Username("Chasa"), new HoursPerWeek(50), new Email("anaa@gmail.com"), new EmployeeStatus(true), new Role("admin") ),
                    timesheetEntries2
                )
            };
        }

        public void Add(DailyTimesheet dailyTimesheet)
        {
            dailyTimesheets.Add(dailyTimesheet);
        }

        public void Delete(Guid id)
        {
            dailyTimesheets.RemoveAll(dt => dt.Id == id);
        }

        public DailyTimesheet GetByDate(DateTime date)
        {
            return dailyTimesheets.Find(dt => dt.Date.ToString() == date.ToString());
        }

        public IEnumerable<DailyTimesheet> GetByDateRange(DateTime from, DateTime to)
        {
            return dailyTimesheets.Where(dt => dt.Date >= from && dt.Date <= to);
        }

        public Maybe<DailyTimesheet> GetById(Guid id)
        {
            return dailyTimesheets.Find(dt => dt.Id == id);
        }

        public DailyTimesheet Update(DailyTimesheet dailyTimesheet, Guid id)
        {
            DailyTimesheet oldDailyTimesheet = dailyTimesheets.Find(dt => dt.Id == id);
            dailyTimesheets.Remove(oldDailyTimesheet);
            dailyTimesheets.Add(dailyTimesheet);
            return dailyTimesheet;
        }
    }
}
