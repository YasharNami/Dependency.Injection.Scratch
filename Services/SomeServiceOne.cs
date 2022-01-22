using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Injection.Scratch.Services
{
    public class SomeServiceOne : ISomeService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;
        public SomeServiceOne(IRandomGuidProvider randomGuidProvider) => _randomGuidProvider = randomGuidProvider;

        public void PrintSomthing() => Console.WriteLine(_randomGuidProvider.RandomGuid);

    }
}
