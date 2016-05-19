using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reversi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        public Reversi.Program GetProgram() => new Program();

        [TestMethod()]
        public void IsRangeOfCommandTest()
        {
            var Program = GetProgram();
            Assert.IsFalse(Program.IsRangeOfCommand(-1));
            Assert.IsTrue(Program.IsRangeOfCommand(0));
            Assert.IsTrue(Program.IsRangeOfCommand(1));
            Assert.IsTrue(Program.IsRangeOfCommand(8));
            Assert.IsFalse(Program.IsRangeOfCommand(9));
        }

        [TestMethod()]
        public void ParseXTest()
        {
            Assert.AreEqual(Program.ParseX("1"), 1);
            Assert.AreEqual(Program.ParseX("2"), 2);
            Assert.AreEqual(Program.ParseX("3"), 3);
            Assert.AreEqual(Program.ParseX("4"), 4);
            Assert.AreEqual(Program.ParseX("5"), 5);
            Assert.AreEqual(Program.ParseX("6"), 6);
            Assert.AreEqual(Program.ParseX("7"), 7);
            Assert.AreEqual(Program.ParseX("8"), 8);
            Assert.AreEqual(Program.ParseX("9"), 9);
            Assert.AreEqual(Program.ParseX("0"), 0);
        }

        [TestMethod()]
        public void ParseYTest()
        {
            Assert.AreEqual(Program.ParseY("1"), 1);
            Assert.AreEqual(Program.ParseY("2"), 2);
            Assert.AreEqual(Program.ParseY("3"), 3);
            Assert.AreEqual(Program.ParseY("4"), 4);
            Assert.AreEqual(Program.ParseY("5"), 5);
            Assert.AreEqual(Program.ParseY("6"), 6);
            Assert.AreEqual(Program.ParseY("7"), 7);
            Assert.AreEqual(Program.ParseY("8"), 8);
            Assert.AreEqual(Program.ParseY("9"), 9);
            Assert.AreEqual(Program.ParseY("0"), 0);
        }
    }
}