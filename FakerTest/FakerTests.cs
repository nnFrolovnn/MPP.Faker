using System;
using InterfacesLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakerTest
{
    [TestClass]
    public class FakerTests
    {
        private TestTop testclass;

        [TestInitialize]
        public void TestInit()
        {
            IPlugin plugin = new Plugin.Plugin();
            Faker.Faker faker = new Faker.Faker(plugin.GetGenerators(), 2);

            testclass = faker.Create<TestTop>();
        }

        [TestMethod]
        public void TestResultIsNotNull()
        {
            Assert.IsNotNull(testclass);
        }

        [TestMethod]
        public void TestPrivateSetFooIsNull()
        {
            Assert.IsNull(testclass.privatesetfoo);
        }

        [TestMethod]
        public void TestBoolFieldIsSet()
        {
            Assert.AreNotEqual(false, testclass.boolean);
        }

        [TestMethod]
        public void TestDoubleIsSet()
        {
            bool value = testclass.doub == 456.2;
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void TestRecursion2()
        {
            bool rec1 = testclass.testTop != null;
            if (rec1)
            {
                bool rec2 = testclass.testTop.testTop != null;
                Assert.AreEqual(true, rec2);
            }
            else
            {
                Assert.Fail("recursion level is 1");
            }
        }

        [TestMethod]
        public void TestDateTime()
        {
            DateTime dateTime = new DateTime(1, 1, 1, 1, 1, 1);

            Assert.AreEqual(dateTime, testclass.testBar.testFoo.datetime);
        }
    }
}
