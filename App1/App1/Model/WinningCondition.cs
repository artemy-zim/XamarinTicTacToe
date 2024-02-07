namespace App1.Model
{
    public class WinningCondition
    {
        private Board _board;

        public WinningCondition(Board board)
        {
            _board = board;
        }

        public int Check()
        {
            if (IsHorizontalWin() || IsVerticalWin() || IsDiagonalWin())
            {
                return 1;
            }
            else if (IsDraw())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private bool IsHorizontalWin()
        {
            return IsLineWin(0, 1, 2) || IsLineWin(3, 4, 5) || IsLineWin(6, 7, 8);
        }

        private bool IsVerticalWin()
        {
            return IsLineWin(0, 3, 6) || IsLineWin(1, 4, 7) || IsLineWin(2, 5, 8);
        }

        private bool IsDiagonalWin()
        {
            return IsLineWin(0, 4, 8) || IsLineWin(2, 4, 6);
        }

        private bool IsDraw()
        {
            for (int i = 0; i < _board.GetBoardLength(); i++)
            {
                if (_board.GetCell(i) == i.ToString()[0])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsLineWin(int i, int j, int k)
        {
            return _board.GetCell(i) == _board.GetCell(j) &&
                   _board.GetCell(j) == _board.GetCell(k);
        }
    }
}
