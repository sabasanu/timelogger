#nullable disable warnings
namespace Timelogger.Application.Dtos
{
    public class TimeRegistrationDto
    {
        public DateOnly Date { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }
    }
}
#nullable enable warnings