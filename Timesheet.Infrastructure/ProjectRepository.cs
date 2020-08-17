using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Timesheet.Core;
using Timesheet.Core.Repositories;

namespace Timesheet.Infrastructure
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> projects;

        public ProjectRepository()
        {
            this.projects = new List<Project>();
            this.projects.Add(new Project(Guid.Parse("00000000-0000-0000-0000-000000000001"), new ProjectName("SpaceTravel"), new Description("From Jupiter to Neptune"), Guid.Parse("00000000-b37e-4079-87bd-5207fd386cf5"), new Lead("Ja"), new Status("Active")));
        }

        public void Add(Project project)
        {
            projects.Add(project);
        }

        public void Delete(Guid id)
        {
            projects.RemoveAll(pr => pr.Id == id);
        }

        public Maybe<Project> GetById(Guid id)
        {
            return projects.Find(project => project.Id == id);
        }

        public Maybe<Project> GetByName(ProjectName name)
        {
            return projects.Find(project => project.Name == name);
        }

        public PagedProjects SearchProjects(ProjectSearchParams query)
        {
            var searchQuery = projects
                .Where(project => project.Name.Contains(query.SearchText))
                .Where(project => project.Name.StartsWith(query.FirstLetter));

            int foundProjects = searchQuery.Count();

            IEnumerable<Project> filteredProjects = searchQuery
                .Skip(Constants.PageSize * (query.PageNumber - 1))
                .Take(Constants.PageSize)
                .ToList();

            PagedProjects pagedProjects = new PagedProjects(filteredProjects, foundProjects, query.PageNumber, Constants.PageSize);
            return pagedProjects;
        }

        public Project Update(Project project, Guid id)
        {
            Project oldProject = projects.Find(project => project.Id == id);
            projects.Remove(oldProject);
            projects.Add(project);
            return project;
        }
    }
}