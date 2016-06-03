// <copyright file="BoardTest.cs" company="Shaxware">Copyright (C)  2016 Kuxumarin</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReversiLib;

namespace ReversiLib.Tests
{
    /// <summary>This class contains parameterized unit tests for Board</summary>
    [PexClass(typeof(Board))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class BoardTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public Board ConstructorTest()
        {
            Board target = new Board();
            return target;
            // TODO: add assertions to method BoardTest.ConstructorTest()
        }

        /// <summary>Test stub for CountBlackColor()</summary>
        [PexMethod]
        public int CountBlackColorTest([PexAssumeUnderTest]Board target)
        {
            int result = target.CountBlackColor();
            return result;
            // TODO: add assertions to method BoardTest.CountBlackColorTest(Board)
        }

        /// <summary>Test stub for CountNoneColor()</summary>
        [PexMethod]
        public int CountNoneColorTest([PexAssumeUnderTest]Board target)
        {
            int result = target.CountNoneColor();
            return result;
            // TODO: add assertions to method BoardTest.CountNoneColorTest(Board)
        }

        /// <summary>Test stub for CountWhiteColor()</summary>
        [PexMethod]
        public int CountWhiteColorTest([PexAssumeUnderTest]Board target)
        {
            int result = target.CountWhiteColor();
            return result;
            // TODO: add assertions to method BoardTest.CountWhiteColorTest(Board)
        }

        /// <summary>Test stub for GetColor(Int32, Int32)</summary>
        [PexMethod]
        public Color GetColorTest(
            [PexAssumeUnderTest]Board target,
            int x,
            int y
        )
        {
            Color result = target.GetColor(x, y);
            return result;
            // TODO: add assertions to method BoardTest.GetColorTest(Board, Int32, Int32)
        }

        /// <summary>Test stub for Init()</summary>
        [PexMethod]
        public void InitTest([PexAssumeUnderTest]Board target)
        {
            target.Init();
            // TODO: add assertions to method BoardTest.InitTest(Board)
        }

        /// <summary>Test stub for IsNone(Int32, Int32)</summary>
        [PexMethod]
        public bool IsNoneTest(
            [PexAssumeUnderTest]Board target,
            int x,
            int y
        )
        {
            bool result = target.IsNone(x, y);
            return result;
            // TODO: add assertions to method BoardTest.IsNoneTest(Board, Int32, Int32)
        }

        /// <summary>Test stub for IsRange(Int32, Int32)</summary>
        [PexMethod]
        public bool IsRangeTest(
            [PexAssumeUnderTest]Board target,
            int x,
            int y
        )
        {
            bool result = target.IsRange(x, y);
            return result;
            // TODO: add assertions to method BoardTest.IsRangeTest(Board, Int32, Int32)
        }

        /// <summary>Test stub for get_Length()</summary>
        [PexMethod]
        public int LengthGetTest([PexAssumeUnderTest]Board target)
        {
            int result = target.Length;
            return result;
            // TODO: add assertions to method BoardTest.LengthGetTest(Board)
        }

        /// <summary>Test stub for SetColor(Int32, Int32, Color)</summary>
        [PexMethod]
        public void SetColorTest(
            [PexAssumeUnderTest]Board target,
            int x,
            int y,
            Color color
        )
        {
            target.SetColor(x, y, color);
            // TODO: add assertions to method BoardTest.SetColorTest(Board, Int32, Int32, Color)
        }
    }
}
