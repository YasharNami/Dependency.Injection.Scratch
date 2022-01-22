using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Injection.Scratch.Services
{
    public interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }
}
