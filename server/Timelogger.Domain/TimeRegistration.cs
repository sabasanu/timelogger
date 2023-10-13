using CSharpFunctionalExtensions;

namespace Timelogger.Domain
{
    public class TimeRegistration : Entity<int>
    {
        private Project? _project;

        public int ProjectId { get; set; }

        public Project Project { get => _project ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Project)); set => _project = value; }

        public required string Description { get; set; }

        public DateOnly Date { get; set; }

        public int Minutes { get; set; }
    }
}
