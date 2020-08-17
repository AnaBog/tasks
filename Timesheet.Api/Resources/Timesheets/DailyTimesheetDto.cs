using System.Collections.Generic;

namespace Timesheet.Api.Controllers
{
    public struct DailyTimesheetDto
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string EmployeeId { get; set; }
        public IEnumerable<TimesheetEntryDto> TimesheetEntries { get; set; }
        public double TotalHoursPerDay { get; set; }
    }
}