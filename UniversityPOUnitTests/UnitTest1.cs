using UniversityPO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UniversityPO.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDateTimeTest()
        {
            var res = Helpers.GetDateTime(null);
        }
    }
}

namespace UniversityPOUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
