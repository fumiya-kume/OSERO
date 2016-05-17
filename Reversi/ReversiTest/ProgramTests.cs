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
    }
}