using AutoMapper;
using Timelogger.Application.Dtos;
using Timelogger.Data;

namespace Timelogger.Application.Services
{
    public class CustomersService
    {
        private readonly TimeloggerDbContext _timeloggerDbContext;
        private readonly IMapper _mapper;

        public CustomersService(TimeloggerDbContext timeloggerDbContext, IMapper mapper)
        {
            _timeloggerDbContext = timeloggerDbContext;
            _mapper = mapper;
        }

        public List<CustomerDto> GetAll()
        {
            return _timeloggerDbContext.Customers
                .Select(c => _mapper.Map<CustomerDto>(c)).ToList();
        }

    }
}
