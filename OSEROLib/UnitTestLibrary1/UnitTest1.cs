using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Reversi.StoneColorList;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Reversi;

namespace UnitTestLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AlwaysTrue()
        {
            Assert.AreEqual(1,1);
        }

        [TestMethod]
        public void WhiteStone()
        {
            var reversi = new Reversi.Reversi();
            Assert.IsNotNull(reversi);
            Assert.AreEqual(0,reversi.WhiteStone());

            reversi.Board.Board = new [] {
                new[] { White, None, None, None, None, None, None, None },new[] { None, None, None, None, None, None, None, None },
                new[] { None, None, None, None, None, None, None, None },new[] { None, None, None, None, None, None, None, None },
                new[] { None, None, None, None, None, None, None, None },new[] { None, None, None, None, None, None, None, None },
                new[] { None, None, None, None, None, None, None, None },new[] { None, None, None, None, None, None, None, None }
            };

            Assert.AreEqual(1,reversi.Board.Board);
        }

        [TestMethod]
        public void BlackStone()
        {
            var reversi = new Reversi.Reversi();
            Assert.AreEqual(0,reversi.BlackStone());
        }
    }
}
