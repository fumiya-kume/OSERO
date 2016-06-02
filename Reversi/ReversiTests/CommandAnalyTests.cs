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
    public class CommandAnalyTests
    {
        [TestMethod]
        public void CommandAnalyTest()
        {
            var commands = new string[]
            {
                "a1","a2","a3","a4","a5","a6","a7","a8","a9",
                "b1","b2","b3","b4","b5","b6","b7","b8","b9",
                "c1","c2","c3","c4","c5","c6","c7","c8","c9",
                "d1","d2","d3","d4","d5","d6","d7","d8","d9",
                "e1","e2","e3","e4","e5","e6","e7","e8","e9",
                "f1","f2","f3","f4","f5","f6","f7","f8","f9",
                "g1","g2","g3","g4","g5","g6","g7","g8","g9"
            };

            var result = new string[]
            {
                "11","12","13","14","15","16","17","18","19",
                "21","22","23","24","25","26","27","28","29",
                "31","32","33","34","35","36","37","38","39",
                "41","42","43","44","45","46","47","48","49",
                "51","52","53","54","55","56","57","58","59",
                "61","62","63","64","65","66","67","68","69",
                "71","72","73","74","75","76","77","78","79",
                "81","82","83","84","85","86","87","88","89",
                "91","92","93","94","95","96","97","98","99"
            };

            var Xs = commands.Select(c => new CommandAnaly(c).ParseX()).ToList();
            var Ys = commands.Select(c => new CommandAnaly(c).ParseY()).ToList();
            result.Select((s, i) =>
            {
                Assert.AreEqual(s.First(), Xs[i]);
                Assert.AreEqual(s.Last(), Ys[i]);
                return 0;
            });
        }
        
    }
}