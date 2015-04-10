using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrepEngine
{
    public class Searcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="searchedString"></param>
        /// <returns></returns>
        public IEnumerable<string> FindLineWithString(IEnumerable<string> inputText,string searchedString)
        {
            if (inputText == null || searchedString == null)
            {
                return new List<string>();
                
            }
            IEnumerable<string> results = inputText.Where(s => s.Contains(searchedString));
            Logger.Logger.Log("FindLineWithString executed");
            return results;
            
        }
    }
}
