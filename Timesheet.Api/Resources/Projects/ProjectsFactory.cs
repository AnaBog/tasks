using System;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class ProjectsFactory
    {
        public Project Create(ProjectDto projectDto)
        {
            var projectId = Guid.NewGuid();
            return new Project(
                projectId,
                new ProjectName(projectDto.Name),
                new Description(projectDto.Description),
                Guid.Parse(projectDto.ClientId),
                new Lead(projectDto.Lead),
                new Status(projectDto.Status)
                );
        }

        public Project Update(ProjectDto projectDto)
        {
            return new Project(
                Guid.Parse(projectDto.Id),
                new ProjectName(projectDto.Name),
                new Description(projectDto.Description),
                Guid.Parse(projectDto.ClientId),
                new Lead(projectDto.Lead),
                new Status(projectDto.Status)
                );
        }
    }
}