
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mes.Unit
{
    [TestClass]
    public class Scrypt
    {
        [TestMethod]
        public void TestMethod1()
        {
            string result;

            Mes.Classes.Crypto.Write.WriteText("Test", "Test.SAVE", "Key1Key1Key1Key1Key1Key1Key1Key1", "Key1Key1Key1Key1");
            result = Mes.Classes.Crypto.Read.ReadText("Test.SAVE", "Key1Key1Key1Key1Key1Key1Key1Key1", "Key1Key1Key1Key1");
            File.Delete("Test.SAVE");

            Assert.AreEqual(result,"Test");
        }
    }
}
