using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReversiLib;
using static ReversiLib.ColorList;
using System.Security.Policy;

namespace ReversiTest
{
    [TestClass]
    public class TestColorCount
    {
        public Reversi Reversi { get; set; } = new Reversi();

        [TestMethod]
        public void TestWhiteColor()
        {
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
            Assert.AreEqual(Black,Reversi.EnemyColor(White));
            Assert.AreEqual(White,Reversi.EnemyColor(Black));
            Assert.AreEqual(None,Reversi.EnemyColor(None));
        }
    }
}
