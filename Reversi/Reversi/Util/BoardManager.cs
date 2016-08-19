using System;
using System.Linq;
using Prism.Mvvm;

namespace Reversi.Util
{
    public class BoardManager : BindableBase
    {
        public GameBoard GameBoard { get; set; } = new GameBoard();

        public BoardManager()
        {
            InitGameBoard();
            //GameBoard.Pieces.Select(lists => lists.Count(list => list == Piece.Black)).Aggregate((i, i1) => i + i1);
            //GameBoard.Pieces.Select(lists => lists.Count(list => list == Piece.Black)).Aggregate((i, i1) => i + i1);
            //GameBoard.Pieces.Select(lists => lists.Count(list => list == Piece.None)).Aggregate((i, i1) => i + i1);
        }

        public void InitGameBoard()
        {
            GameBoard.Pieces = new[]
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

            return GameBoard.Pieces[x][y];
        }

        public void UpdatePiece(int x, int y, Piece piece)
        {
            if (x < 0 || 7 < x) throw new IndexOutOfRangeException("Out of " + nameof(x));
            if (y < 0 || 7 < y) throw new IndexOutOfRangeException("Out of " + nameof(y));

            GameBoard.Pieces[x][y] = piece;
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
