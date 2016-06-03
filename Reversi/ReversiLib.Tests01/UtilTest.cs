// <copyright file="UtilTest.cs" company="Shaxware">Copyright (C)  2016 Kuxumarin</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReversiLib;

namespace ReversiLib.Tests
{
    /// <summary>This class contains parameterized unit tests for Util</summary>
    [TestClass]
    [PexClass(typeof(Util))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class UtilTest
    {

        /// <summary>Test stub for EnemyColor(Color)</summary>
        [PexMethod]
        public Color EnemyColorTest(Color color)
        {
            Color result = Util.EnemyColor(color);
            return result;
            // TODO: add assertions to method UtilTest.EnemyColorTest(Color)
        }
    }
}
