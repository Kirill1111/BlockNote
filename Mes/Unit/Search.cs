
using System;
using System.Security.AccessControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mes.Unit
{
    [TestClass]
    public class Search
    {
        [TestMethod]
        public void SearchInFileName()
        {
            string[] FileName = new string[3]{"TestR","TestX","TextY"};
            string Search = "TestR";
            bool Result;

            Mes.Classes.Instruments.Save.FileNameAll = FileName;
            Result = Mes.Classes.Instruments.Save.Search(Search);
            
            Assert.AreEqual(Result,true);
        }

        [TestMethod]
        public void SearchInOutput()
        {
            string[] Output = new string[3]{"TestX","TestY","TestR"};
            string Search = "TestR";
            string[] Result;

            Classes.FileSystem.Instruments.Output = Output;
            Result = Classes.FileSystem.SearchString.Search(Search);

            Assert.AreEqual(Result[0],Search);
        }


    }
}
