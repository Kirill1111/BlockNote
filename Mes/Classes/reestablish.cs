using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Classes
{
    class reestablish
    {
        public reestablish()
        {
            if (!Directory.Exists("SaveInfo"))
                Directory.CreateDirectory("SaveInfo");
            if(!Directory.Exists("SaveInfo/SaveText"))
                Directory.CreateDirectory("SaveInfo/SaveText");

            Test("SaveInfo/Work.SAVE","");
            Test("SaveInfo/Logs.SAVE", "");
            Test("SaveInfo/Save.SAVE", "");
            Test("SaveInfo/SaveD.SAVE", "0");
        }

        private void Test(string path,string write)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path,write);
            }
        }
    }
}
