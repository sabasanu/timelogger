using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Timelogger.Application.Dtos;
using Timelogger.Common.Exceptions;
using Timelogger.Data;
using Timelogger.Domain;

namespace Timelogger.Application.Services
{
    public class TimeRegistrationService
    {
        private readonly TimeloggerDbContext _timeloggerDbContext;        
        private readonly IMapper _mapper;

        public TimeRegistrationService(TimeloggerDbContext timeloggerDbContext, IMapper mapper)
        {
            _timeloggerDbContext = timeloggerDbContext;
            _mapper = mapper;
        }

        public List<TimeRegistrationDto> GetTimeRegistration(int? customerId, int? projectId)
        {
            return _timeloggerDbContext.TimeRegistrations
                .Include(tr => tr.Project)
                .ThenInclude(p => p.Customer)
                .Where(tr => customerId == null || tr.Project.Customer.Id == customerId)
                .Where(tr => projectId == null || tr.ProjectId == projectId)
                .Select(tr => _mapper.Map<TimeRegistrationDto>(tr))
                .ToList();
        }

        public void RegisterTime(RegisterTimeDto dto)
        {
            var project = _timeloggerDbContext.Projects
                .Where(p => p.Id == dto.ProjectId)
                .Include(project => project.Customer)
                .Include(p => p.TimeRegistrations)
                .FirstOrThrow();

            if (project.IsComplete)
            {
                throw new ValidationException("You cannot register time for a completed project");
            }

            if(dto.Minutes < 30)
            {
                throw new ValidationException("Minimum time is 30 minutes");
            }

            int timeAlreadySpent = (int)project.TimeRegistrations.Where(tr => tr.Date == dto.Date).Sum(tr => tr.Minutes);
            if(timeAlreadySpent + dto.Minutes > 480)
            {
                throw new ValidationException("You cannot register more than 8 hours per day");
            }

            var timeRegistration = new TimeRegistration
            {
                Project = project,
                Date = dto.Date,
                Minutes = dto.Minutes,
                Description = dto.Description
            };
            project.TimeRegistrations.Add(timeRegistration);

            _timeloggerDbContext.SaveChanges();
        }
    }
}