using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Timelogger.Domain;

namespace Timelogger.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public static readonly List<Customer> DummyCustomers = new List<Customer>()
        {
            new Customer(1)
            {
                Name = "Big Customer",
                UserId = 1
            },
            new Customer(2)
            {
                Name = "Small Customer",
                UserId = 1
            },
            new Customer(3)
            {
                Name = "Medium Customer",
                UserId = 1
            },
            new Customer(4)
            {
                Name = "Unauthorized Customer",
                UserId = 2
            }

        };

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(c => c.Projects)
                .WithOne(p => p.Customer)
                .IsRequired();

            builder.HasData(DummyCustomers);
        }
    }
}
