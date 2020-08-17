using System.Collections.Generic;
using System.Linq;
using Timesheet.Core;

namespace Timesheet.Api.Controllers
{
    public class PagedProjectsDtoMapper
    {
        private readonly ProjectDtoMapper _projectDtoMapper;

        public PagedProjectsDtoMapper(ProjectDtoMapper projectDtoMapper)
        {
            _projectDtoMapper = projectDtoMapper;
        }
        public PagedProjectsDto Map(PagedProjects pagedProjects)
        {
            PagedProjectsDto pagedProjectsDto = new PagedProjectsDto();
            pagedProjectsDto.PageNumber = pagedProjects.PageNumber;
            pagedProjectsDto.PageSize = pagedProjects.PageSize;
            pagedProjectsDto.TotalItems = pagedProjects.TotalItems;
            pagedProjectsDto.Projects = pagedProjects.Projects.Select(pagedPoject => _projectDtoMapper.Map(pagedPoject));
            return pagedProjectsDto;
        }
    }
}