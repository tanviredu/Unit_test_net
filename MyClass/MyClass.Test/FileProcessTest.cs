using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass;
using System.Configuration;
namespace MyClass.Test
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.exe";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        /// <summary>
        ///  there are three initializer
        ///  project initializer that start when the project executed
        ///  then
        ///  class initializer that start when the class executed
        ///  then
        ///  test initializer that start when the test method executed
        /// </summary>

        /// <summary>
        ///  there are three cleanup
        ///  project cleanup that start when the project finished (then third)
        ///  class cleanup that start when the class finished (then second)
        ///  test cleanup that start when the test method finished (first)
        /// </summary>

        /// <summary>
        /// the TestContext object is passed as a parameter to Assembly(project) initializer and class initializer
        /// </summary>


        /// class initializer is writen in side the class with method
        /// and a testContext is passwd
        [ClassInitialize]
        public static void ClassInitializer(TestContext tc) {
            tc.WriteLine("this class is initialized");
        }

        [ClassCleanup]

        public static void ClassCleanup()
        {
            //TODO
        }



        /// <summary>
        /// test initializer is not static because 
        /// it needs to run before and after each test
        /// and we dont need to pass any TestContext
        /// because we have direct access
        /// tou can access method name and see what method is executed
        /// </summary>
        
        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("Currently Running Test " + TestContext.TestName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Console.WriteLine("finished test "+TestContext.TestName);
        }



        [TestMethod]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            SetGoodFilename();
            TestContext.WriteLine("Creating the file " +_GoodFileName);
            File.AppendAllText(_GoodFileName, "This is a random text");
            TestContext.WriteLine("Testing the file " + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);
            TestContext.WriteLine("Deleting the file " + _GoodFileName);
            File.Delete(_GoodFileName);
            Assert.IsTrue(fromCall);
            
        }


        
        public void SetGoodFilename()
        {
        
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]")) {
                // replace the path with your path
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }


        [TestMethod]
        public void FileNameDoesNotExists()
        {
            //Assert.Inconclusive();
            //arrange
            FileProcess fp = new FileProcess();
            //act
            bool fromCall;
            fromCall = fp.FileExists(@"C:\BadFileName.exe");
            //Assert.IsTrue(fromCall);
            Assert.IsFalse(fromCall);

        }

        [TestMethod]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            //Assert.Inconclusive();
            // test the exception 
            FileProcess fp = new FileProcess();

            try {
                fp.FileExists("");
            }
            catch (ArgumentNullException) {
                // if the catch exception works
                // then the assert is success
                return;
            
            }//if the file exists then this test fail
            Assert.Fail("It did not throw an argument");
        }
    }
}
