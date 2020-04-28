using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass;
namespace MyClass.Test
{
    /// <summary>
    /// Summary description for ObjectTests
    /// </summary>
    [TestClass]
    public class ObjectTests
    {
       [TestMethod]
       [Owner("Tanvir")]
       public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y); // this will pass the test


        }


        [TestMethod]
        [Owner("Tanvir")]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y); // this will pass the test too cause they are not same


        }




    }
}
