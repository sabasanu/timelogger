using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timelogger.Application.Dtos;
using Timelogger.Application.Services;

namespace Timelogger.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private CustomersService _customerService;
        private TimeRegistrationService _timeRegistrationService;

        public CustomersController(CustomersService customerService, TimeRegistrationService timeRegistrationService)
        {
            _customerService = customerService;
            _timeRegistrationService = timeRegistrationService;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            return _customerService.GetAll();
        }

        [HttpGet("{customerId}/timeRegistrations")]
        public IEnumerable<TimeRegistrationDto> GetTimeRegistrations(int customerId)
        {
            return _timeRegistrationService.GetTimeRegistration(customerId, null);
        }
    }
}
