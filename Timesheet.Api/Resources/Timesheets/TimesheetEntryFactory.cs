using System;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class TimesheetEntryFactory
    {
        public TimesheetEntry Create(TimesheetEntryDto timesheetEntryDto)
        {
            var timesheetEntryId = Guid.NewGuid();
            return new TimesheetEntry(
                timesheetEntryId,
                Guid.Parse(timesheetEntryDto.ClientId),
                Guid.Parse(timesheetEntryDto.ProjectId),
                new EntryDescription(timesheetEntryDto.EntryDescription),
                new Time(timesheetEntryDto.Time),
                new Overtime(timesheetEntryDto.Overtime)
            );
        }
    }
}
