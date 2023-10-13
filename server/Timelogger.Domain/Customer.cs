using CSharpFunctionalExtensions;

namespace Timelogger.Domain
{
    public class Customer : Entity<int>
    {
        public Customer(int id) : base(id)
        {

        }

        public required int UserId { get; set; }

        public required string Name { get; set; }

        public ICollection<Project>? Projects { get; set; }
    }
}
