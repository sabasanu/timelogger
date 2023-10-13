using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Timelogger.Application.Dtos;
using Timelogger.Common.Enums;
using Timelogger.Common.Exceptions;
using Timelogger.Data;
using Timelogger.Domain;

namespace Timelogger.Application.Services
{
    public class ProjectsService
    {
        private readonly TimeloggerDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProjectsService(TimeloggerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ProjectDto GetProject(int projectId)
        {
            var project = _dbContext.Projects.Where(p => p.Id == projectId).Include(project => project.Customer)               
                .FirstOrThrow();

            return _mapper.Map<ProjectDto>(project);
        }

        public List<ProjectDto> GetProjects(int? customerId = null, ProjectDto.OrderBy? orderBy = null, SortDirection sort = SortDirection.Ascending)
        {
            var customers = _dbContext.Customers.ToList();
            if(customerId != null && _dbContext.Customers.Find(customerId) == null)
            {
                throw new NotFoundException($"Customer with id {customerId} does not exist");
            }

            var query = _dbContext.Projects.Where(p => customerId == null || p.Customer.Id == customerId);
            if(orderBy != null)
            {
                query = GetOrderQuery(query, orderBy.Value, sort);
            }
            return query
                .Select(p => _mapper.Map<ProjectDto>(p))
                .ToList();
        }

        private IQueryable<Project> GetOrderQuery(IQueryable<Project> query, ProjectDto.OrderBy orderBy, SortDirection sort)
        {
            return sort == SortDirection.Ascending ?
                orderBy switch { ProjectDto.OrderBy.Deadline => query.OrderBy(p => p.Deadline) } :
                orderBy switch { ProjectDto.OrderBy.Deadline => query.OrderByDescending(p => p.Deadline) };
        }
    }
}
