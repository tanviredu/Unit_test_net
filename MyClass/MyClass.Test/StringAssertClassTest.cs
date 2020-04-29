using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass;

namespace MyClass.Test
{   
    
    [TestClass]
    public class StringAssertClassTest
    {

        [TestMethod]
        [Owner("Tanvir Rahman")]

        public void ContainsTest()
        {
            string str1 = "Tanvir rahman";
            string sub_str2 = "Tanvir";

            StringAssert.Contains(str1, sub_str2);
        }


        [TestMethod]
        [Owner("Tanvir Rahman")]

        public void StartsWithTest()
        {
            string str1 = "Tanvir rahman";
            string sub_str2 = "Tanvir";

            StringAssert.StartsWith(str1, sub_str2);
        }
    }
}
