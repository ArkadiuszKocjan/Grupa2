using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrepEngine
{
    public interface ICounter
    {
        int Count(IEnumerable<string> allDataEnumerable, string dataToFind);
    }
}
