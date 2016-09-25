using System;
using System.Linq;
using Prism.Mvvm;

namespace Reversi.Util
{
    public class BoardManager : BindableBase
    {
        private Piece[][] _gameBoard;

        public Piece[][] GameBoard
        {
            get { return _gameBoard; }
            set { SetProperty(ref _gameBoard, value); }
        }

        public BoardManager()
        {
            InitGameBoard();
        }

        public void InitGameBoard()
        {
            GameBoard = new[]
            {
               new[] { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
               new[] { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
               new[] { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
               new[] { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
               new[] { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
               new[] { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
               new[] { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None },
               new[] { Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None, Piece.None }
        };
        }

        public Piece GetPiece(int x, int y)
        {
            if (x < 0 || 7 < x) throw new IndexOutOfRangeException("Out of " + nameof(x));
            if (y < 0 || 7 < y) throw new IndexOutOfRangeException("Out of " + nameof(y));

            return GameBoard[x][y];
        }

        public void UpdatePiece(int x, int y, Piece piece)
        {
            if (x < 0 || 7 < x) throw new IndexOutOfRangeException("Out of " + nameof(x));
            if (y < 0 || 7 < y) throw new IndexOutOfRangeException("Out of " + nameof(y));

            GameBoard[x][y] = piece;
        }

        public static Piece EnemyPiece(Piece Piece)
        {
            switch (Piece)
            {
                case Piece.Black:
                    return Piece.White;
                case Piece.White:
                    return Piece.Black;
                case Piece.None:
                    return Piece.None;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Piece), Piece, null);
            }
        }

    }
}
