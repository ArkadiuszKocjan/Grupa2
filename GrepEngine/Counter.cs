using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrepEngine
{
    public class Counter : ICounter
    {
        public int Count(IEnumerable<string> allDataEnumerable, string dataToFind)
        {
            var method =
                allDataEnumerable.Count(x => x.Contains(dataToFind));

            return method;
        }
    }
}
