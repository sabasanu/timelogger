using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Domain;

namespace Timelogger.Data.Configurations
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public static readonly List<Project> DummyProjects = new List<Project>()
        {
            new Project(1)
            {
                CustomerId = 1,
                Name = "Project 1",
                Deadline = new DateTime(2023, 12, 12),
                UserId = 1
            },
            new Project(2)
            {
                CustomerId = 1,
                Name = "Project 2",
                Deadline = new DateTime(2023, 12, 12),
                UserId = 1
            },
            new Project(3)
            {
                CustomerId = 2,
                Name = "Project 3",
                Deadline = new DateTime(2023, 12, 12),
                UserId = 1
            },
            new Project(4)
            {
                CustomerId = 2,
                Name = "Project 4",
                Deadline = new DateTime(2023, 12, 12),
                UserId = 1
            },
            new Project(5)
            {
                CustomerId = 3,
                Name = "Project 5",
                Deadline = new DateTime(2023, 12, 12),
                UserId = 1
            },
            new Project(6)
            {
                CustomerId = 3,
                Name = "Project 6",
                Deadline = new DateTime(2023, 12, 12),
                UserId = 1
            },
            new Project(7)
            {
                CustomerId = 4,
                Name = "Unauthorized Project",
                Deadline = new DateTime(2023, 12, 12),
                UserId = 2
            },
        };
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(p => p.Customer)
                .WithMany(c => c.Projects)
                .IsRequired();

            builder
                .Ignore(p => p.IsComplete);

            builder.HasData(DummyProjects);
        }
    }
}
