using System.Collections.Generic;

namespace Timesheet.Core
{
    public class PagedProjects
    {
        public IEnumerable<Project> Projects { get; set; }
        public int TotalItems { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        public PagedProjects(IEnumerable<Project> Projects, int TotalItems, int PageNumber, int PageSize)
        {
            this.Projects = Projects;
            this.TotalItems = TotalItems;
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;
        }
    }
}
