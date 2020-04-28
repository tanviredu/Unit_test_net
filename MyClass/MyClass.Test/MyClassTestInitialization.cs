using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClass.Test
{
    /// <summary>
    /// Summary description for MyClassTestInitialization
    /// </summary>
    [TestClass]
    public class MyClassTestInitialization
    {
        // why static ? because it will run only once 
        // no matter how nuch test method in there
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc) {

            tc.WriteLine("In the Project initialzer"); 
        }

        [AssemblyCleanup]

        public static void AssemblyCleaner()
        {
            // this method will xecute at last
        }

       
    }
}
