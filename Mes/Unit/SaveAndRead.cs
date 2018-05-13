﻿
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mes.Unit
{
    [TestClass]
    public class SaveAndRead
    {
        [TestMethod]
        public void TestReadAndWriteInFile()
        {
            string[] Text = new string[2]{"TestX","TestY"};
            string path = "UnitTest.Save";
            string[] Result = new string[2];

            Mes.Classes.FileSystem.Save.SaveInfo(Text,path);
            Result = Mes.Classes.FileSystem.Start.Load(path);

            Assert.AreEqual(Convert.ToString(Text),Convert.ToString(Result));
        }



    }
}
