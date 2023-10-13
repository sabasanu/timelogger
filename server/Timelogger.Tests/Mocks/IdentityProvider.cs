using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Data;

namespace Timelogger.Tests.Mocks
{
    public class IdentityProvider : IIdentityProvider
    {
        public IdentityProvider(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; set; }
    }
}
