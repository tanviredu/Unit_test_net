using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass;
using System.IO;

namespace MyClass.Test
{
    /// <summary>
    /// you need to add the system.data to the reference 
    /// and you need to actvate the connection using the vs
    /// tools->connect to Database
    /// </summary>
    // 

    

    [TestClass]
    public class FileProcessTestDataDriven
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        [DataSource("System.Data.SqlClient","Server=Localhost;Database=MyClassTests;Integrated Security=Yes","tests.FileProcessTest",DataAccessMethod.Sequential)]
        [Owner("Tanvir Rahman")]

         public void FileExistsTestFromDB()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool expectedValue;
            bool causesException;
            bool fromCall;


            // it will loop throgh all the value and test pass for each individual row
            // you will get access this data with TestContext
            fileName = TestContext.DataRow["FileName"].ToString();
            expectedValue = Convert.ToBoolean(TestContext.DataRow["ExpectedValue"]);
            causesException = Convert.ToBoolean(TestContext.DataRow["CausesException"]);


            try
            {
                // get  the file name from database
                fromCall = fp.FileExists(fileName);
                // from call should have  a boolean value
                // check with the result 
                Assert.AreEqual(expectedValue, fromCall);

            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(causesException);
            }

        }   
     
    }
}
