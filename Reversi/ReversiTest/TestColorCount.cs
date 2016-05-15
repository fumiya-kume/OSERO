using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReversiLib;
using static ReversiLib.Color;

namespace ReversiTest
{
    [TestClass]
    public class TestColorCount
    {
        private Reversi GetReversi() => new Reversi();

        [TestMethod]
        public void TestWhiteColor()
        {
            var Reversi = GetReversi();
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
            var Reversi = GetReversi();
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
            var Reversi = GetReversi();
            Assert.IsFalse(Reversi.IsRangeOfBoard(-1, 0));
            Assert.IsFalse(Reversi.IsRangeOfBoard(0, -1));
            Assert.IsFalse(Reversi.IsRangeOfBoard(-1, -1));

            Assert.IsFalse(Reversi.IsRangeOfBoard(8, 0));
            Assert.IsFalse(Reversi.IsRangeOfBoard(0, 8));
            Assert.IsFalse(Reversi.IsRangeOfBoard(8, 8));

            Assert.IsTrue(Reversi.IsRangeOfBoard(0, 0));
            Assert.IsTrue(Reversi.IsRangeOfBoard(7, 7));
        }

        [TestMethod]
        public void TestSetColor()
        {
            var Reversi = GetReversi();
            try
            {
                Reversi.SetColor(-1, 0, Black);

            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
            try
            {
                Reversi.SetColor(0, -1, Black);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                Reversi.SetColor(-1, -1, Black);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                Reversi.SetColor(8, 0, Black);
            }
            catch (Exception)
            {
                return;
            }

            try
            {
                Reversi.SetColor(0, 8, Black);
            }
            catch (Exception)
            {
                return;
            }

            try
            {
                Reversi.SetColor(8, 8, Black);
            }
            catch (Exception)
            {
                return;
            }

            Assert.Fail("エラーが発生しませんでした。");
        }

        [TestMethod]
        public void TestEnemyColor()
        {
            var Reversi = GetReversi();
            Assert.AreEqual(Black, Reversi.EnemyColor(White));
            Assert.AreEqual(White, Reversi.EnemyColor(Black));
            Assert.AreEqual(None, Reversi.EnemyColor(None));
        }

        [TestMethod]
        public void TestIsChangeColor()
        {
            var Reversi = GetReversi();
            Reversi.Board = new[]
             {
                new[] {None, None, None},
                new[] {White, Black, White},
                new[] {None, None, None}
            };
            Assert.IsTrue(Reversi.IsChangeColor(2, 2));

            Reversi.Board = new[]
             {
                new[] {None, None, None},
                new[] {Black, White, Black},
                new[] {None, None, None}
            };
            Assert.IsTrue(Reversi.IsChangeColor(2, 2));

            Reversi.Board = new[]
             {
                new[] {None, Black, None},
                new[] {Black, White, Black},
                new[] {None, Black, None}
            };
            Assert.IsTrue(Reversi.IsChangeColor(2, 2));

            Reversi.Board = new[]
             {
                new[] {None, Black, None},
                new[] {White, White, White},
                new[] {None, Black, None}
            };
            Assert.IsTrue(Reversi.IsChangeColor(2, 2));

            Reversi.Board = new[]
             {
                new[] {None, White, None},
                new[] {None, Black, None},
                new[] {None, White, None}
            };
            Assert.IsTrue(Reversi.IsChangeColor(2, 2));
        }

        [TestMethod]
        public void TestBoardInit()
        {
            var reversi = GetReversi();
            reversi.Init();
            CollectionAssert.AllItemsAreNotNull(reversi.Board);
            CollectionAssert.AreEqual(reversi.Board[4], new[] { None, None, None, Black, White, None, None, None });
            CollectionAssert.AreEqual(reversi.Board[5], new[] { None, None, None, White, Black, None, None, None });
        }
    }
}
