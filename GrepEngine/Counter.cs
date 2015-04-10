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
                allDataEnumerable.Sum(line => CountOcc(line, dataToFind));

            return method;
        }

        private int CountOcc(string line, string dataToFind)
        {
            if (String.IsNullOrEmpty(line))
            {
                return 0;
            }
            int index = -1;
            int count = -1;
            do
            {
                index = line.IndexOf(dataToFind);
                count ++;
                if (index > -1)
                {
                    line = line.Substring(index + dataToFind.Length);
                }
            } while (index >= 0);
            return count;

        }
    }
}
