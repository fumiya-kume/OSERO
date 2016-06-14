using ReversiLib;

namespace ReversiLib
{


    public class Reversi
    {
        private readonly ReversiBoard _reversiBoard;
        private readonly intelligenceService _intelligenceService;

        public Reversi()
        {
            _reversiBoard = new ReversiBoard(this);
            _intelligenceService = new intelligenceService(this);
        }


        public ReversiBoard ReversiBoard
        {
            get { return _reversiBoard; }
        }

        public intelligenceService IntelligenceService
        {
            get { return _intelligenceService; }
        }

        //一方向にひっくり返せる石があるか確認

        // Can Reversi Color on vicinty

        public bool SetColor(int x, int y, Color color)
        {
            if (Util.IsRange(x, y)) return false;
            if (Board[x][y] != Color.None)
            {
                throw new OverlapStone();
            }
            if (!_reversi.IsReversiAllDirection(x, y))
            {
                throw new NotEnableSetStone();
            }
            Board[x][y] = color;
            _reversi.ReversiAllDirection(x, y, color);
            return true;
        }

        public bool IsAlreadSetColor(int x, int y)
        {
            if (ReversiBoard.GetColor(x, y) == None) return false;

            return true;
        }

        public bool CanSetStone(int x, int y, Color color)
        {
            if (!Util.IsRange(x, y)) return false;
            if (ReversiBoard.Board[x][y] != None) return false;
            if (!IntelligenceService.IsReversiAllDirection(x, y)) return false;
            return true;
        }

        public bool IsSkip()
        {
            for (int i = 0; i < ReversiBoard.Board.Length; i++)
            {
                for (int j = 0; j < ReversiBoard.Board[0].Length; j++)
                {
                    if (IntelligenceService.IsReversiAllDirection(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Set Color on Board

        public bool IsContinue()
        {
            if (ReversiBoard.CountBlackColor() == 0) return false;
            if (ReversiBoard.CountWhiteColor() == 0) return false;
            if (ReversiBoard.CountNoneColor() == 0) return false;
            return true;
        }
    }
}
