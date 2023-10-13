using System.Runtime.Serialization;

namespace Timelogger.Common.Exceptions
{
    [Serializable]
    public class ValidationException : ApiException
    {

        public ValidationException(string message) : base(message, System.Net.HttpStatusCode.BadRequest)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}