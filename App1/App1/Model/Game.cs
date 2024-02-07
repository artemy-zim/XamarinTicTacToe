using Xamarin.Forms;

namespace App1.Model
{
    public class Game
    {
        private Player[] _players;
        private Board _board;
        private WinningCondition _winningCondition;

        private int _currentPlayerIndex;

        public Game()
        {
            _players = new Player[2];
            _players[0] = new Player('X', Color.Green);
            _players[1] = new Player('O', Color.Red);
            _board = new Board();
            _winningCondition = new WinningCondition(_board);
        }

        public Player CurrentPlayer => _players[_currentPlayerIndex];
        public Board Board => _board;
        public int CurrentPlayerIndex => _currentPlayerIndex;

        public void MakeMove(int position)
        {
            _board.Mark(position, CurrentPlayer.Marker);
            _currentPlayerIndex = (_currentPlayerIndex + 1) % 2;
        }

        public GameState CheckGameResult()
        {
            int checkResult = _winningCondition.Check();

            if (checkResult == 1)
            {
                return GameState.Win;
            }
            else if (checkResult == -1)
            {
                return GameState.Draw;
            }
            else
            {
                return GameState.InProgress;
            }
        }

        public void Reset()
        {
            _board.Reset();
            _currentPlayerIndex = 0;
        }
    }
}
