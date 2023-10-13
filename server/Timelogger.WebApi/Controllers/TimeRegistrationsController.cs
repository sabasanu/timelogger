using Microsoft.AspNetCore.Mvc;
using Timelogger.Application.Dtos;
using Timelogger.Application.Services;
using Timelogger.Domain;

namespace Timelogger.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRegistrationsController : ControllerBase
    {
        private readonly TimeRegistrationService _timeRegistrationService;

        public TimeRegistrationsController(TimeRegistrationService timeRegistrationService)
        {
            _timeRegistrationService = timeRegistrationService;
        }

        [HttpPost]
        public void Post(RegisterTimeDto registerTimeDto)
        {
            _timeRegistrationService.RegisterTime(registerTimeDto);
        }
    }
}
