using System.Net;
using System.Runtime.Serialization;

namespace Timelogger.Common.Exceptions
{
    [Serializable]
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {

        }

        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
