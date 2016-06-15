namespace ReversiLib
{
    public class intelligenceService
    {
        private Reversi _reversi;

        public intelligenceService(Reversi reversi)
        {
            _reversi = reversi;
        }

        public intelligenceService()
        {
        }

        private bool IsReversiDirection(int x, int y, int dx, int dy)
        {
            var nowColor = _reversi.Board.GetColor(x, y);
            var nx = x + dx;
            var ny = y + dy;
            if (_reversi.Board.GetColor(nx, ny) != ReversiLib.Util.EnemyColor(nowColor)) return false;
            while (true)
            {
                if (_reversi.Board.GetColor(nx, ny) == Color.None) return false;
                if (_reversi.Board.GetColor(nx, ny) == nowColor) break;
                nx += dx;
                ny += dy;
            }
            return true;
        }

        public bool IsReversiAllDirection(int x, int y)
        {
            if (IsReversiDirection(x, y, -1, 0)) return true; // Up
            if (IsReversiDirection(x, y, -1, 1)) return true; // Upper Right
            if (IsReversiDirection(x, y, 0, 1)) return true;  // Right
            if (IsReversiDirection(x, y, 1, 1)) return true; // Lower Right
            if (IsReversiDirection(x, y, 1, 0)) return true; // Low
            if (IsReversiDirection(x, y, 1, -1)) return true; // Lower Left
            if (IsReversiDirection(x, y, 0, -1)) return true; // Left
            if (IsReversiDirection(x, y, -1, -1)) return true; // Upper Left

            return false;
        }

        private void ReversiDirection(int x, int y, int dx, int dy, Color color)
        {
            if (!IsReversiDirection(x, y, dx, dy)) return;
            var nx = x + dx;
            var ny = y + dy;
            if (_reversi.Board.GetColor(nx, ny) != ReversiLib.Util.EnemyColor(color)) return;
            while (true)
            {
                if (_reversi.Board.GetColor(nx, ny) != ReversiLib.Util.EnemyColor(color)) break;
                _reversi.Board.Board[nx][ny] = color;
                nx += dx;
                ny += dy;
            }
        }

        private void ReversiAllDirection(int x, int y, Color color)
        {
            ReversiDirection(x, y, -1, 0, color); // Up
            ReversiDirection(x, y, -1, 1, color); // Upper Right
            ReversiDirection(x, y, 0, 1, color);   // Right
            ReversiDirection(x, y, 1, 1, color); // Lower Right
            ReversiDirection(x, y, 1, 0, color); // Low
            ReversiDirection(x, y, 1, -1, color);// Lower Left
            ReversiDirection(x, y, 0, -1, color); // Left
            ReversiDirection(x, y, -1, -1, color); // Upper Left
        }
    }
}