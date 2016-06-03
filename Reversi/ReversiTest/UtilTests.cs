using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Reversi.Color;
using static Reversi.Util;

namespace Reversi.Tests
{
    [TestClass()]
    public class UtilTests
    {
        [TestMethod()]
        public void EnemyColorTest()
        {
            Assert.AreEqual(EnemyColor(Black), White);
            Assert.AreEqual(EnemyColor(White), Black);
            Assert.AreEqual(EnemyColor(None), None);
        }
    }
}