using System.Net;
using System.Runtime.Serialization;

namespace Timelogger.Common.Exceptions
{
    [Serializable]
    public abstract class ApiException : Exception
    {
        public ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ApiException(string message, HttpStatusCode? httpStatusCode = null, Exception? innerException = null)
            : base(message, innerException)
        {
            StatusCode = httpStatusCode;
        }

        public HttpStatusCode? StatusCode { get; }
    }
}