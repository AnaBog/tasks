using Microsoft.AspNetCore.Mvc;
using System;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    [ApiController]
    [Route("api/projects")]

    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService projectService;
        private readonly ProjectsSearchFactory projectsSearchFactory;
        private readonly ProjectsFactory projectsFactory;
        private readonly ProjectDtoMapper projectDtoMapper;
        private readonly PagedProjectsDtoMapper pagedProjectsDtoMapper;
        private readonly ClientDtoMapper clientDtoMapper;

        public ProjectsController(ProjectService projectService, 
                                  ProjectsSearchFactory projectsSearchFactory, 
                                  ProjectsFactory projectsFactory, 
                                  ProjectDtoMapper projectDtoMapper, 
                                  PagedProjectsDtoMapper pagedProjectsDtoMapper, 
                                  ClientDtoMapper clientDtoMapper)
        {
            this.projectService = projectService;
            this.projectsSearchFactory = projectsSearchFactory;
            this.projectsFactory = projectsFactory;
            this.projectDtoMapper = projectDtoMapper;
            this.pagedProjectsDtoMapper = pagedProjectsDtoMapper;
            this.clientDtoMapper = clientDtoMapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProjectDto projectDto)
        {
            Project createdProject = projectsFactory.Create(projectDto);
            projectService.Add(createdProject);
            return Created($"/api/projects/{createdProject.Id}", createdProject.Id);
        }

        [HttpGet]
        public IActionResult Search([FromQuery] ProjectSearchParamsDto query)
        {
            var projectSearchParams = projectsSearchFactory.Create(query);
            PagedProjects pagedProjects = projectService.Search(projectSearchParams);
            return Ok(pagedProjectsDtoMapper.Map(pagedProjects));
        }

        [HttpDelete("{Id}")]
        public void Delete(Guid Id)
        {
            projectService.Delete(Id);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(Guid Id, [FromBody] ProjectDto projectDto)
        {
            Project updatedProject = projectsFactory.Update(projectDto);
            projectService.Update(updatedProject, Id);
            return Created($"/api/projects/{updatedProject.Id}", projectDtoMapper.Map(updatedProject));
        }
    }
}
