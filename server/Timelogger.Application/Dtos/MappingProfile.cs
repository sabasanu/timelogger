using AutoMapper;
using Timelogger.Domain;

namespace Timelogger.Application.Dtos
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>()
                .ForMember(p => p.CustomerName, o => o.MapFrom((pr, dto)=> pr.Customer?.Name));

            CreateMap<Customer, CustomerDto>();

            CreateMap<TimeRegistration, TimeRegistrationDto>()
                .ForMember(dto => dto.CustomerName, t => t.MapFrom(tr => tr.Project.Customer.Name))
                .ForMember(dto => dto.ProjectName, t => t.MapFrom(tr => tr.Project.Name));  
        }
    }
}
