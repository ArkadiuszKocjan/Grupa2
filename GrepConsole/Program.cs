using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrepEngine;
using DataProvider;
using Logger;
using System.Windows.Forms;
using GrepUI;

namespace GrepConsole
{

    class ConsoleArguments
    {
        public ConsoleArguments(string url, string word, bool ifgui, bool valid)
        {
            URL = url;
            keyWord = word;
            isValid = valid;
            ifGUI = ifgui;
        }
        public ConsoleArguments(): this("", "", true, false)
        {}
        public string URL {  get; private set; }
        public string keyWord { get; private set; }
        public bool isValid { get; private set; }
        public bool ifGUI { get; private set; }
    }

    class ArgsParser
    {
        private string[] argsTab;
        public ArgsParser(string[] args)
        {
            argsTab = args;
        }

        public ConsoleArguments parseArguments()
        {
            if (argsTab.Length == 0)
                return new ConsoleArguments();
            else if (argsTab.Length == 2)
            {
                Uri url;
                bool result = Uri.TryCreate(argsTab[0], UriKind.Absolute, out url) && url.Scheme == Uri.UriSchemeHttp;
                return new ConsoleArguments(argsTab[0], argsTab[1], false, result);

            }
            else
            {
                return new ConsoleArguments(argsTab[0], argsTab[1], false, false);
            }

        }
    }
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RunnerFactory runner = new RunnerFactory(args);
            runner.SelectEnv().Run();
            
        }
    }
}
