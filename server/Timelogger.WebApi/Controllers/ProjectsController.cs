using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Timelogger.Application.Dtos;
using Timelogger.Application.Services;
using Timelogger.Common.Enums;

namespace Timelogger.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsService _projectsService;
        private readonly TimeRegistrationService _timeRegistrationService;

        public ProjectsController(ProjectsService projectsService, TimeRegistrationService timeRegistrationService)
        {
            _projectsService = projectsService;
            _timeRegistrationService = timeRegistrationService;
        }

        [HttpGet]
        public IEnumerable<ProjectDto> Get(int? customerId, ProjectDto.OrderBy? orderBy, SortDirection dir = SortDirection.Ascending)
        {
            return _projectsService.GetProjects(customerId, orderBy, dir);
        }

        [HttpGet("{id}")]
        public ProjectDto Get(int id)
        {
            return _projectsService.GetProject(id);
        }

        [HttpGet("{projectId}/timeRegistrations")]
        public IEnumerable<TimeRegistrationDto> GetTimeRegistrations(int projectId)
        {
            return _timeRegistrationService.GetTimeRegistrations(null, projectId);
        }

    }
}
