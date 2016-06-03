// <copyright file="ReversiTest.cs" company="Shaxware">Copyright (C)  2016 Kuxumarin</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReversiLib;

namespace ReversiLib.Tests
{
    /// <summary>This class contains parameterized unit tests for Reversi</summary>
    [TestClass]
    [PexClass(typeof(Reversi))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ReversiTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public Reversi ConstructorTest()
        {
            Reversi target = new Reversi();
            return target;
            // TODO: add assertions to method ReversiTest.ConstructorTest()
        }

        /// <summary>Test stub for CanSetStone(Int32, Int32, Color)</summary>
        [PexMethod]
        public bool CanSetStoneTest(
            [PexAssumeUnderTest]Reversi target,
            int x,
            int y,
            Color color
        )
        {
            bool result = target.CanSetStone(x, y, color);
            return result;
            // TODO: add assertions to method ReversiTest.CanSetStoneTest(Reversi, Int32, Int32, Color)
        }

        /// <summary>Test stub for GetAllBoardData()</summary>
        [PexMethod]
        public Color[][] GetAllBoardDataTest([PexAssumeUnderTest]Reversi target)
        {
            Color[][] result = target.GetAllBoardData();
            return result;
            // TODO: add assertions to method ReversiTest.GetAllBoardDataTest(Reversi)
        }

        /// <summary>Test stub for IsAlreadSetColor(Int32, Int32)</summary>
        [PexMethod]
        public bool IsAlreadSetColorTest(
            [PexAssumeUnderTest]Reversi target,
            int x,
            int y
        )
        {
            bool result = target.IsAlreadSetColor(x, y);
            return result;
            // TODO: add assertions to method ReversiTest.IsAlreadSetColorTest(Reversi, Int32, Int32)
        }

        /// <summary>Test stub for IsContinue()</summary>
        [PexMethod]
        public bool IsContinueTest([PexAssumeUnderTest]Reversi target)
        {
            bool result = target.IsContinue();
            return result;
            // TODO: add assertions to method ReversiTest.IsContinueTest(Reversi)
        }

        /// <summary>Test stub for IsSkip()</summary>
        [PexMethod]
        public bool IsSkipTest([PexAssumeUnderTest]Reversi target)
        {
            bool result = target.IsSkip();
            return result;
            // TODO: add assertions to method ReversiTest.IsSkipTest(Reversi)
        }

        /// <summary>Test stub for IsWinnerColor()</summary>
        [PexMethod]
        public Color IsWinnerColorTest([PexAssumeUnderTest]Reversi target)
        {
            Color result = target.IsWinnerColor();
            return result;
            // TODO: add assertions to method ReversiTest.IsWinnerColorTest(Reversi)
        }

        /// <summary>Test stub for SetColor(Int32, Int32, Color)</summary>
        [PexMethod]
        public void SetColorTest(
            [PexAssumeUnderTest]Reversi target,
            int x,
            int y,
            Color color
        )
        {
            target.SetColor(x, y, color);
            // TODO: add assertions to method ReversiTest.SetColorTest(Reversi, Int32, Int32, Color)
        }
    }
}
