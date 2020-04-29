using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass;
namespace MyClass.Test
{
    /// <summary>
    /// Summary description for ObjectTypeTest
    /// </summary>
    [TestClass]
    public class ObjectTypeTest
    {
        [TestMethod]
        [Owner("tanvir")]
        public void IsinstanceOfTypeTest()
        {
            // we will find if it is the instance of a same class

            PersonManager mgr = new PersonManager();
            Person per;  // create a person type so we can assign a person object there

            per = mgr.CreatePerson("tanvir", "Rahman", true);
            // so we create a super type person


            Assert.IsInstanceOfType(per, typeof(Supervisor));

            
        }

        [TestMethod]
        [Owner("tanvir")]
        public void IsNotinstanceOfTypeTest()
        {
            // we will find if it is the instance of a same class

            PersonManager mgr = new PersonManager();
            Person per;  // create a person type so we can assign a person object there

            per = mgr.CreatePerson("tanvir", "Rahman", false);
            // so we create a super type person


            Assert.IsNotInstanceOfType(per, typeof(Supervisor));


        }


        [TestMethod]
        [Owner("tanvir")]
        public void IsNullTest()
        {
            // we will find if it is the instance of a same class

            PersonManager mgr = new PersonManager();
            Person per;  // create a person type so we can assign a person object there

            per = mgr.CreatePerson("", "Rahman", true);
            // so we create a super type person


            Assert.IsNull(per);


        }










    }
}
