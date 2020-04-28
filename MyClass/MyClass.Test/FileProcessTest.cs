﻿using System;
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
        [TestMethod]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            
            // set the good file name
            SetGoodFilename();
            // now create and add text in the file that is created
            File.AppendAllText(_GoodFileName, "This is a random text");

            //get the bool value
            fromCall = fp.FileExists(_GoodFileName);
            //delete the file
            File.Delete(_GoodFileName);
            //assert it
            Assert.IsTrue(fromCall);
            
        }


        // make a non test function to create a good file name
        // this method can all be addded in any test function
        public void SetGoodFilename()
        {
            // set the good file name
            // to do that simple check the config and get the value 
            // with the key and just replace [AppPath] with your project path
            // and test any file in this project

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
