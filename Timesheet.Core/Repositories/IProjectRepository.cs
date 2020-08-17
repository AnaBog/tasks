using CSharpFunctionalExtensions;
using System;

namespace Timesheet.Core.Repositories
{
    public interface IProjectRepository
    {
        void Add(Project project);
        void Delete(Guid Id);
        Project Update(Project project, Guid id);
        PagedProjects SearchProjects(ProjectSearchParams query);
        Maybe<Project> GetByName(ProjectName name);
        Maybe<Project> GetById(Guid id);
    }
}
