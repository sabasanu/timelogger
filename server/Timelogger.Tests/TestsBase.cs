using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Timelogger.Application.Services;
using Timelogger.Data;
using Timelogger.Tests.Mocks;

namespace Timelogger.Tests
{
    [TestFixture]
    public class TestsBase
    {
        protected IdentityProvider _identityProvider;
        protected TimeloggerDbContext _dbContext;
        protected IMapper _mapper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _identityProvider = new IdentityProvider(1);
            var cfg = new MapperConfiguration(exp =>
            {
                exp.AddMaps(typeof(TimeRegistrationService));
            });
            _mapper = cfg.CreateMapper();
            InitDbContext();
            _dbContext.Database.EnsureCreated();
        }

        protected void InitDbContext()
        {
            _dbContext = new TimeloggerDbContext(new DbContextOptionsBuilder<TimeloggerDbContext>().UseInMemoryDatabase("db").Options, _identityProvider);
        }
    }
}