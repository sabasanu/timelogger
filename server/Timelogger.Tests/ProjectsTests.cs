using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Timelogger.Application.Dtos;
using Timelogger.Application.Services;
using Timelogger.Common.Enums;
using Timelogger.Common.Exceptions;
using Timelogger.Data;
using Timelogger.Tests.Mocks;

namespace Timelogger.Tests
{
    [TestFixture]
    public class ProjectsTests : TestsBase
    {
        ProjectsService _projectsService;

        [SetUp]
        public void Setup()
        {
            _identityProvider.UserId = 1;
            InitDbContext();
            _projectsService = new ProjectsService(_dbContext, _mapper);
        }

        [Test]
        public void Projects_are_sorted_descending()
        {
            var projects = _projectsService.GetProjects(null, ProjectDto.OrderBy.Deadline, SortDirection.Descending);
            for (int i = 0; i < projects.Count - 1; i++)
            {
                Assert.That(projects[i].Deadline, Is.GreaterThanOrEqualTo(projects[i + 1].Deadline));
            }
        }

        [Test]
        public void Projects_are_sorted_ascending()
        {
            var projects = _projectsService.GetProjects(null, ProjectDto.OrderBy.Deadline, SortDirection.Ascending);
            for (int i = 0; i < projects.Count - 1; i++)
            {
                Assert.That(projects[i].Deadline, Is.LessThanOrEqualTo(projects[i + 1].Deadline));
            }
        }

        [Test]
        public void Projects_are_filtered_by_customer()
        {
            var projects = _projectsService.GetProjects(1);
            Assert.True(projects.All(p => p.CustomerId == 1));  
        }

        [Test]
        public void Projects_are_filtered_by_current_user()
        {
            _identityProvider.UserId = 2;
            var projects = _projectsService.GetProjects();
            Assert.True(projects.All(p => p.UserId == 2));
        }
    }
}
