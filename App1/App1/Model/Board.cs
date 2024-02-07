namespace App1.Model
{
    public class Board
    {
        private char[] _cells;

        public Board()
        {
            _cells = new char[9];
            Reset();
        }

        public void Mark(int position, char marker)
        {
            _cells[position] = marker;
        }

        public bool IsCellOccupied(int position)
        {
            return _cells[position] == 'X' ||
                   _cells[position] == 'O';
        }

        public char GetCell(int cellNumber)
        {
            return _cells[cellNumber];
        }

        public int GetBoardLength()
        {
            return _cells.Length;
        }

        public void Reset()
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i] = (char)('0' + i);
            }
        }
    }
}
