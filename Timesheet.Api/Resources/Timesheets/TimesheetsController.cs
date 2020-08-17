using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    [ApiController]
    [Route("api/timesheets")]
    public class TimesheetsController : ControllerBase
    {
        private readonly TimesheetService timesheetService;
        private readonly DailyTimesheetFactory dailyTimesheetFactory;
        private readonly DailyTimesheetDtoMapper dailyTimesheetDtoMapper;

        public TimesheetsController(TimesheetService timesheetService,
                                    DailyTimesheetFactory dailyTimesheetFactory,
                                    DailyTimesheetDtoMapper dailyTimesheetDtoMapper)
        {
            this.timesheetService = timesheetService;
            this.dailyTimesheetFactory = dailyTimesheetFactory;
            this.dailyTimesheetDtoMapper = dailyTimesheetDtoMapper;
        }

        [HttpPost]
        public IActionResult CreateOrUpdate([FromBody] DailyTimesheetDto dailytimesheetDto)
        {
            DailyTimesheet createdDailyTimesheet = dailyTimesheetFactory.Create(dailytimesheetDto);
            Guid dailyTimesheetId = timesheetService.CreateOrUpdate(createdDailyTimesheet, createdDailyTimesheet.Id);
            return Created($"/api/timesheets/{dailyTimesheetId}", dailyTimesheetId);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string date)
        {
            DailyTimesheet dailyTimesheet = timesheetService.GetByDate(DateTime.Parse(date));
            DailyTimesheetDto mappedTimesheet = dailyTimesheetDtoMapper.Map(dailyTimesheet);
            return Ok(mappedTimesheet);
        }
        //[Route("range")]
        //[HttpGet]
        //public IActionResult GetRange([FromQuery] string from, [FromQuery] string to)
        //{
        //    IEnumerable<DailyTimesheet> dailyTimesheets = timesheetService.GetByDateRange(DateTime.Parse(from), DateTime.Parse(to));
        //    IEnumerable<DailyTimesheetDto> mappedTimesheets = dailyTimesheets.Select(dt => dailyTimesheetDtoMapper.Map(dt));
        //    return Ok(mappedTimesheets);
        //}
    }
}