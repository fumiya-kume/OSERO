using System;
using System.Linq;
using Prism.Mvvm;

namespace Reversi.Util
{
    public class BoardManager : BindableBase
    {
        public GameBoard GameBoard { get; set; } = new GameBoard();
        private int _whitePiece = 0;
        private int _blackPiece;
        private int _nonePiece;

        public int WhitePiece
        {
            get { return _whitePiece; }
            set { SetProperty(ref _whitePiece, value); }
        }

        public int BlackPiece
        {
            get { return _blackPiece; }
            set { SetProperty(ref _blackPiece, value); }
        }

        public int NonePiece
        {
            get { return _nonePiece; }
            set { SetProperty(ref _nonePiece, value); }
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
            WhitePiece = GameBoard.Pieces.Select(lists => lists.Count(list => list == Piece.Black)).Aggregate((i, i1) => i + i1);
            BlackPiece = GameBoard.Pieces.Select(lists => lists.Count(list => list == Piece.Black)).Aggregate((i, i1) => i + i1);
            NonePiece = GameBoard.Pieces.Select(lists => lists.Count(list => list == Piece.None)).Aggregate((i, i1) => i + i1);
        }

        private static Piece EnemyPiece(Piece Piece)
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
