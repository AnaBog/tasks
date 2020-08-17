using CSharpFunctionalExtensions;
using System;
using Timesheet.Core.Repositories;

namespace Timesheet.Core
{
    public class ProjectService
    {
        private IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void Add(Project project)
        {
            Maybe<Project> maybeProject = _projectRepository.GetByName(project.Name);

            if (maybeProject.HasValue)
            {
                throw new InvalidOperationException("You cannot add the existing name of the project");
            }
            _projectRepository.Add(project);
        }

        public void Delete(Guid id)
        {
            Maybe<Project> maybeProject = _projectRepository.GetById(id);

            if (maybeProject.HasNoValue)
            {
                throw new InvalidOperationException("You cannot delete a non-existant object");
            }
            _projectRepository.Delete(id);
        }

        public PagedProjects Search(ProjectSearchParams query)
        {
            return _projectRepository.SearchProjects(query);
        }

        public void Update(Project project, Guid id)
        {
            Maybe<Project> maybeProject = _projectRepository.GetById(id);

            if (maybeProject.HasNoValue)
            {
                throw new InvalidOperationException("You cannot update a non-existing project.");
            }

            _projectRepository.Update(project, id);
        }
    }
}
