using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClass.Test
{
    /// <summary>
    /// Summary description for AssertClassTest
    /// </summary>
    [TestClass]
    public class AssertClassTest
    {


        /// AreEqual/AreNotEqual Tests
        [TestMethod]
        [Owner("Tanvir")]

        public void AreEqualTest() {

            string str1 = "Paul";
            string str2 = "Paul";
            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Tanvir")]

        public void AreEquaCaseSensetivelTest()
        {

            string str1 = "Paul";
            string str2 = "paul";
            Assert.AreEqual(str1, str2,false);
        }

        [TestMethod]
        [Owner("Tanvir")]

        public void AreNotEqualTest()
        {

            string str1 = "Paul";
            string str2 = "john";
            Assert.AreNotEqual(str1, str2);
        }
    }
}
