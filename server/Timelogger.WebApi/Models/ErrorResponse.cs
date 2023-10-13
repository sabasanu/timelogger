namespace Timelogger.WebApi.Models
{
    public class ErrorResponse
    {
        public ErrorResponse(string exception, string errorMessage)
        {
            Exception = exception;
            ErrorMessage = errorMessage;
        }

        public string Exception { get; set; }
        public string ErrorMessage { get; set; }
    }
}
