#nullable disable warnings
namespace Timelogger.Application.Dtos
{
    public class CreateProjectDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
    }
}
#nullable enable warnings