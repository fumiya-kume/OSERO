using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReversiLib;
using static ReversiLib.Color;

namespace ReversiTest
{
    [TestClass]
    public class TestColorCount
    {
        private ReversiLib.Reversi reversi => new ReversiLib.Reversi();

        [TestMethod]
        public void TestWhiteColor()
        {
            var Reversi = reversi;
            Reversi.Board = new[]
            {
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None}
            };

            Assert.AreEqual(0, Reversi.CountWhiteColor());

            Reversi.Board = new[]
            {
                new[] {White, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None}
            };

            Assert.AreEqual(1, Reversi.CountWhiteColor());

            Reversi.Board = new[]
            {
                new[] {White, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, White}
            };

            Assert.AreEqual(2, Reversi.CountWhiteColor());
        }

        [TestMethod]
        public void TestBlackColor()
        {
            var Reversi = reversi;
            Reversi.Board = new[]
            {
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None}
            };


            Reversi.Board = new[]
            {
                new[] {Black, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None}
            };

            Assert.AreEqual(1, Reversi.CountBlackColor());

            Reversi.Board = new[]
            {
                new[] {Black, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, Black}
            };

            Assert.AreEqual(2, Reversi.CountBlackColor());
        }

        [TestMethod]
        public void TestIsRangeOfBoard()
        {
            var Reversi = reversi;
            Assert.IsFalse(Reversi.IsRange(-1, 0));
            Assert.IsFalse(Reversi.IsRange(0, -1));
            Assert.IsFalse(Reversi.IsRange(-1, -1));

            Assert.IsFalse(Reversi.IsRange(8, 0));
            Assert.IsFalse(Reversi.IsRange(0, 8));
            Assert.IsFalse(Reversi.IsRange(8, 8));

            Assert.IsTrue(Reversi.IsRange(0, 0));
            Assert.IsTrue(Reversi.IsRange(7, 7));
        }

        

        [TestMethod]
        public void TestEnemyColor()
        {
            var Reversi = reversi;
            Assert.AreEqual(Black, ReversiLib.Reversi.EnemyColor(White));
            Assert.AreEqual(White, ReversiLib.Reversi.EnemyColor(Black));
            Assert.AreEqual(None, ReversiLib.Reversi.EnemyColor(None));
        }



        //[TestMethod]
        //public void TestBoardInit()
        //{
        //    var reversi = this.reversi;
        //    reversi.Init();
        //    CollectionAssert.AllItemsAreNotNull(reversi.Board);
        //    CollectionAssert.AreEqual(reversi.Board[4], new[] { None, None, None, Black, White, None, None, None });
        //    CollectionAssert.AreEqual(reversi.Board[5], new[] { None, None, None, White, Black, None, None, None });
        //}

    }
}
