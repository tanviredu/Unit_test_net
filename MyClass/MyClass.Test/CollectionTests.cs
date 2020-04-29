using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass;
namespace MyClass.Test
{
    /// <summary>
    /// Summary description for CollectionTests
    /// </summary>
    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        public void AreEqualTest()
        {
            PersonManager mgr = new PersonManager();
            // we make two list
            List<Person> PeopleExpected = new List<Person>();
            List<Person> Peopleactual = new List<Person>();

            PeopleExpected.Add(new Person() { FirstName = "tanvir", LastName = "Rahman" });
            PeopleExpected.Add(new Person() { FirstName = "Zakaria", LastName = "bijoy" });
            PeopleExpected.Add(new Person() { FirstName = "mridul", LastName = "hossen" });

            Peopleactual = mgr.GetPeople();

            // now check 
            // object are not equal because every object is unique
            // no matter attribute is same or not

            CollectionAssert.AreNotEqual(Peopleactual, PeopleExpected);

            // if the order is different it may also show fail
            // to check this you have to make AreEquivalent()
            // method



        }

    }
}
