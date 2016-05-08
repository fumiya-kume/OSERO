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
        public void TestWhiteColorZero()
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

            Assert.AreEqual(0,Reversi.CountWhiteColor());
        }

        [TestMethod]
        public void TestWhiteColorOne()
        {
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
        }

        [TestMethod]
        public void TestWhiteColorTwo()
        {
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
        public void TestBlackColorZero()
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

            Assert.AreEqual(0, Reversi.CountBlackColor());
        }

        [TestMethod]
        public void TestBlackColorOne()
        {
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
        }

        [TestMethod]
        public void TestBlackColorTwo()
        {
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
    }
}
