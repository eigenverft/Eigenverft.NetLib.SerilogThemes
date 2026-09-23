using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Eigenverft.NetLib.SerilogThemes.Tests
{
    [TestClass]
    public class FunctionalTests
    {

        [TestInitialize()]
        public void Startup()
        {

        }

        [TestMethod]
        public void TestFooMethod()
        {
            var result = Eigenverft.NetLib.SerilogThemes.Class1.Foo();

            Assert.IsNotNull(result);
            Assert.AreEqual("123", result);
        }
    }
}