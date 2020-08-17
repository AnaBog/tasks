using System.Collections.Generic;

namespace Timesheet.Api.Controllers
{
    public class PagedProjectsDto
    {
        public IEnumerable<ProjectDto> Projects { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}