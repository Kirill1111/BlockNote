using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Classes
{
    class Options
    {
        private static bool grammarChecker = false;

        public static bool GrammarChecker {
            get => grammarChecker;
            set => grammarChecker = value;
        }


    }
}
