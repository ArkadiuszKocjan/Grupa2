using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrepEngine
{
    public class ProffessionalLogger : Ilogger
    {
        public void Log(string methodName)
        {
            Logger.Logger.Log(methodName+" executed");
        }
    }
}
