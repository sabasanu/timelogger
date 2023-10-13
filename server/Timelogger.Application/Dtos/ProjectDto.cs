#nullable disable warnings
namespace Timelogger.Application.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  int UserId { get; set; }

        public int CustomerId { get; set; }

        public DateOnly Deadline { get; set; }

        public enum OrderBy
        {
            Deadline
        }
    }
}
#nullable enable warnings
