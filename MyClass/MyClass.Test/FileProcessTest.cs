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

        [ClassInitialize]
        public static void ClassInitializer(TestContext tc) {
            tc.WriteLine("this class is initialized");
        }

        [ClassCleanup]

        public static void ClassCleanup()
        {
            //TODO
        }



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



        /// <summary>
        /// there is also a [Ignore()] for ignoring any test
        /// </summary>



        [TestMethod]
        [Timeout(3000)] // this method check if it finished working under 3 second 
        public void SimulateTimeout() {
            System.Threading.Thread.Sleep(2000);
            // this will not show error
        }

        [TestMethod]

        [Description("check if the dile does exists")]
        [Owner("Tanvir Rahman")]
        [Priority(1)]  //this number does not mean anything just arr a metadata so you can filter
        [TestCategory("primary team")]
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


        [Description("setting the name")]
        [Owner("Tanvir Rahman")]
        [TestCategory("secondary team")]
        public void SetGoodFilename()
        {
        
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]")) {
                // replace the path with your path
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }


        [TestMethod]
        [Description("check if the file does note exists")]
        [Owner("Tanvir Rahman")]

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
        [Description("check if it throws an exception")]
        [Owner("Tanvir Rahman ornob")]

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
