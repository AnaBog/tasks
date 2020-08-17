using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class ProjectDtoMapper
    {
        public ProjectDto Map(Project project)
        {
            ProjectDto projectDto = new ProjectDto();
            projectDto.Id = project.Id.ToString();
            projectDto.Name = project.Name;
            projectDto.Description = project.Description;
            projectDto.Lead = project.Lead;
            projectDto.Status = project.Status;
            projectDto.ClientId = project.ClientId.ToString();
            return projectDto;
        }
    }
}