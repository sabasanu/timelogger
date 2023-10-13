using CSharpFunctionalExtensions;

namespace Timelogger.Domain
{
    public class Project : Entity<int>
    {
        private Customer? _customer;

        public Project(int id): base(id)
        {
            
        }

        public int UserId { get; set; }

        public required string Name { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsComplete => Deadline.Date < DateTime.Now.Date;

        public int CustomerId { get; set; }

        public Customer Customer { get => _customer ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Customer)); set => _customer = value; }

        public ICollection<TimeRegistration> TimeRegistrations { get; set; } = new List<TimeRegistration>();
    }
}
