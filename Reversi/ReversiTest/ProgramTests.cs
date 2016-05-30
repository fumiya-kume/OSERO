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
            Assert.AreEqual(expected: Program.ParseY("0"), actual: 0);
        }

        
        [TestMethod()]
        public void ParseXTest1()
        {
            Assert.AreEqual(1, Program.ParseX('A'));
            Assert.AreEqual(2, Program.ParseX('B'));
            Assert.AreEqual(3, Program.ParseX('C'));
            Assert.AreEqual(4, Program.ParseX('D'));
            Assert.AreEqual(5, Program.ParseX('E'));
            Assert.AreEqual(6, Program.ParseX('F'));
            Assert.AreEqual(7, Program.ParseX('G'));
        }
    }
}