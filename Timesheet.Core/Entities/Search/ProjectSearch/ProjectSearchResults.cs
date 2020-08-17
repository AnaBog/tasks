using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheet.Core
{
    class ProjectSearchResults
    {
        private readonly List<Project> projects;
        private readonly int totalNumberOfProjects;
        private readonly int pageLimit;

        public ProjectSearchResults(List<Project> projects, int totalNumberOfProjects, int pageLimit)
        {
            this.projects = projects;
            this.totalNumberOfProjects = totalNumberOfProjects;
            this.pageLimit = pageLimit;
        }

        public List<Project> Projects => projects;
        public int TotalNumberOfProjects => totalNumberOfProjects;
        public int PageLimit => pageLimit;
    }
}
