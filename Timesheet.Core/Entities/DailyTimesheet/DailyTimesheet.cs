using System;
using System.Collections.Generic;
using System.Linq;

namespace Timesheet.Core
{
    public class DailyTimesheet
    {
        private readonly Guid id;
        private readonly DateTime date;
        private readonly Employee employee;
        private readonly IEnumerable<TimesheetEntry> timesheetEntries;

        public DailyTimesheet(Guid id, DateTime date, Employee employee, IEnumerable<TimesheetEntry> timesheetEntries)
        {
            this.id = id;
            this.date = date;
            this.employee = employee;
            this.timesheetEntries = timesheetEntries;
        }

        public Guid Id => id;
        public DateTime Date => date;
        public Employee Employee => employee;
        public IEnumerable<TimesheetEntry> TimesheetEntries => timesheetEntries;
        public double TotalHoursPerDay => this.timesheetEntries.Sum(te => te.Time);
    }
}
