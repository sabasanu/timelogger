using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Timelogger.Application.Services;
using Timelogger.Common.Exceptions;
using Timelogger.Data;
using Timelogger.Tests.Mocks;

namespace Timelogger.Tests
{
    [TestFixture]
    public class TimeRegistrationTests : TestsBase
    {
        TimeRegistrationService _timeRegistrationService;

        [SetUp]
        public void Setup()
        {
            InitDbContext();
            _timeRegistrationService = new TimeRegistrationService(_dbContext, _mapper);
        }

        [Test]
        public void TimeRegistration_is_created_correctly ()
        {
            RegisterTimeDto dto = new RegisterTimeDto()
            {
                Date = new DateOnly(2021, 1, 1),
                ProjectId = 1,
                Minutes = 60,
                Description = "Test registration"
            };

            _timeRegistrationService.RegisterTime(dto);

            var insertedTr = _dbContext.TimeRegistrations.First(t => t.ProjectId == 1 && t.Description == "Test registration");

            Assert.That(insertedTr.Date, Is.EqualTo(new DateOnly(2021, 1, 1)));
            Assert.That(insertedTr.Minutes, Is.EqualTo(60));
        }

        [Test]
        public void Cannot_register_less_than_30_minutes()
        {
            RegisterTimeDto dto = new RegisterTimeDto()
            {
                Date = new DateOnly(2021, 1, 1),
                ProjectId = 2,
                Minutes = 20,
                Description = "Test registration"
            };

            Assert.Throws<ValidationException>(() => _timeRegistrationService.RegisterTime(dto));
        }

        [Test]
        public void Cannot_register_more_than_8_hours()
        {
            RegisterTimeDto dto = new RegisterTimeDto()
            {
                Date = new DateOnly(2021, 1, 1),
                ProjectId = 3,
                Minutes = 480,
                Description = "Test registration"
            };
            _timeRegistrationService.RegisterTime(dto);

            dto.Minutes = 1;
            Assert.Throws<ValidationException>(() => _timeRegistrationService.RegisterTime(dto));
        }
    }
}
