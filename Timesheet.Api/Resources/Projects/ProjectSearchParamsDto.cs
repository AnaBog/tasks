﻿namespace Timesheet.Api.Controllers
{
    public class ProjectSearchParamsDto
    {
        public string SearchText { get; set; }
        public string FirstLetter { get; set; }
        public int PageNumber { get; set; }
    }
}