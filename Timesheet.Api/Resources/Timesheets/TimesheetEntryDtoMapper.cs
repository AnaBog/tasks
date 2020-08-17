using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class TimesheetEntryDtoMapper
    {
        private readonly ClientDtoMapper clientDtoMapper;
        private readonly ProjectDtoMapper projectDtoMapper;
        public TimesheetEntryDtoMapper(ClientDtoMapper clientDtoMapper, ProjectDtoMapper projectDtoMapper)
        {
            this.clientDtoMapper = clientDtoMapper;
            this.projectDtoMapper = projectDtoMapper;
        }
        public TimesheetEntryDto Map(TimesheetEntry timesheetEntry)
        {
            TimesheetEntryDto timesheetEntryDto = new TimesheetEntryDto();
            timesheetEntryDto.Id = timesheetEntry.Id.ToString();
            timesheetEntryDto.ClientId = timesheetEntry.ClientId.ToString();
            timesheetEntryDto.ProjectId = timesheetEntry.ProjectId.ToString();
            timesheetEntryDto.EntryDescription = timesheetEntry.EntryDescription;
            timesheetEntryDto.Time = timesheetEntry.Time;
            timesheetEntryDto.Overtime = timesheetEntry.Overtime;

            return timesheetEntryDto;
        }
    }
}