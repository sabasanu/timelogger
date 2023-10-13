#nullable disable warnings
namespace Timelogger.Application.Services
{
    public class RegisterTimeDto
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public int Minutes { get; set; }
    }
}
#nullable enable warnings