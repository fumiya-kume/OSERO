using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Reversi.Util;
using static Reversi.Util.Piece;

namespace Reversi.test
{
    [TestClass]
    public class BoardManagerTest
    {
        [TestMethod]
        public void 駒を取得するテスト()
        {
            var boardmanager = new BoardManager();
            try
            {
                boardmanager.GetPiece(-1, 0);
                Assert.Fail($"例外が発生しませんでした{nameof(BoardManager.GetPiece)}");
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                boardmanager.GetPiece(0, -1);
                Assert.Fail($"例外が発生しませんでした{nameof(BoardManager.GetPiece)}");
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                boardmanager.GetPiece(8, 0);
                Assert.Fail($"例外が発生しませんでした{nameof(BoardManager.GetPiece)}");
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                boardmanager.GetPiece(0, 8);
                Assert.Fail($"例外が発生しませんでした{nameof(BoardManager.GetPiece)}");
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                boardmanager.GetPiece(0, 0);
            }
            catch (Exception)
            {
                Assert.Fail();
                throw;
            }

            try
            {
                boardmanager.GetPiece(7, 7);
            }
            catch (Exception)
            {
                Assert.Fail();
                throw;
            }
        }

        [TestMethod]
        public void 駒をセットするテスト()
        {
            var boadmanager = new BoardManager();
            try
            {
                boadmanager.UpdatePiece(-1, 0, Black);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                boadmanager.UpdatePiece(0, -1, Black);
                Assert.Fail();
            }
            catch (Exception)
            {
            }

            try
            {
                boadmanager.UpdatePiece(8, 0, Black);
                Assert.Fail();
            }
            catch (Exception)
            {
            }

            try
            {
                boadmanager.UpdatePiece(0, 8, Black);
                Assert.Fail();
            }
            catch (Exception)
            {
            }

            try
            {
                boadmanager.UpdatePiece(0,0,Black);
                boadmanager.UpdatePiece(7,7,Black);

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void 敵の駒を取得するテスト()
        {
            Assert.AreEqual(BoardManager.EnemyPiece(Black),White);
            Assert.AreEqual(BoardManager.EnemyPiece(White),Black);
            Assert.AreEqual(BoardManager.EnemyPiece(None),None);
        }
    }
}
