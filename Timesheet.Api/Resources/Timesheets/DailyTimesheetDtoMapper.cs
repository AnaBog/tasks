using System.Linq;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class DailyTimesheetDtoMapper
    {
        private readonly TimesheetEntryDtoMapper timesheetEntryDtoMapper;

        public DailyTimesheetDtoMapper(TimesheetEntryDtoMapper timesheetEntryDtoMapper)
        {
            this.timesheetEntryDtoMapper = timesheetEntryDtoMapper;
        }

        public DailyTimesheetDto Map(DailyTimesheet dailyTimesheet)
        {
            DailyTimesheetDto dailyTimesheetDto = new DailyTimesheetDto();
            dailyTimesheetDto.Id = dailyTimesheet.Id.ToString();
            dailyTimesheetDto.Date = dailyTimesheet.Date.ToString();
            dailyTimesheetDto.EmployeeId = dailyTimesheet.Employee.Id.ToString();
            dailyTimesheetDto.TimesheetEntries = dailyTimesheet.TimesheetEntries.Select(el => timesheetEntryDtoMapper.Map(el));
            dailyTimesheetDto.TotalHoursPerDay = dailyTimesheet.TotalHoursPerDay;
            return dailyTimesheetDto;
        }
    }
}