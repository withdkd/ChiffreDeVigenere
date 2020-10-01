using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChiffreDeVigenere;

namespace Test.ChiffreDeVigenere
{
    [TestClass]
    public class TestVigenere
    {
        [TestMethod]
        public void TestEncrypt()
        {
            IEnumerable<string> source = Program.Preprocess("ALPHA");
            string key = "OMEGA";
            string expected = "OXTNA";
            string actual = Vigenere.Encrypt(source, key).FirstOrDefault();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDecrypt()
        {
            IEnumerable<string> encrypt = Program.Preprocess("ALPHA");
            string key = "NU";
            string expected = "OXTCO";
            string actual = Vigenere.Decrypt(encrypt, key).FirstOrDefault();
            Assert.AreNotEqual(expected, actual);
        }
    }
}
