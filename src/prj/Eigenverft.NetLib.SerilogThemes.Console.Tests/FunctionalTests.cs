using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Eigenverft.NetLib.SerilogThemes.Console.Tests
{
    [TestClass]
    public class FunctionalTests
    {

        [TestInitialize()]
        public void Startup()
        {

        }

        [TestMethod]
        public void TestMainMethod()
        {
            var result = Eigenverft.NetLib.SerilogThemes.Console.Program.Main(System.Array.Empty<string>());

            Assert.AreEqual(0, result);
        }
    }
}
