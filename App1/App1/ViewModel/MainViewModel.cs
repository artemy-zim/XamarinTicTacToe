using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using App1.Model;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private Game _game;
        private ObservableCollection<CellViewModel> _cells;
        private string _currentPlayerTurnLabel;

        public MainViewModel()
        {
            _game = new Game();
            _cells = new ObservableCollection<CellViewModel>();
            CellClickCommand = new Command<string>(OnCellClick);
            _currentPlayerTurnLabel = $"Ход игрока: {_game.CurrentPlayerIndex + 1}";

            InitializeCells();
        }

        public ObservableCollection<CellViewModel> Cells
        {
            get { return _cells; }
            set { SetProperty(ref _cells, value); }
        }

        public string CurrentPlayerTurnLabel
        {
            get => _currentPlayerTurnLabel;
            set => SetProperty(ref _currentPlayerTurnLabel, value);
        }

        public ICommand CellClickCommand { get; }

        private void InitializeCells()
        {
            for (int i = 0; i < 9; i++)
            {
                _cells.Add(new CellViewModel());
            }
        }

        private async void OnCellClick(string index)
        {
            int.TryParse(index, out int position);

            if (_game.Board.IsCellOccupied(position) == false)
            {
                _game.MakeMove(position);
                UpdateCell(position);

                var result = _game.CheckGameResult();

                if (result == GameState.Win || result == GameState.Draw)
                {
                    await DisplayGameResult(result);
                    ResetGame();
                }

                UpdateCurrentPlayerTurnLabel();
            }
        }

        private void UpdateCell(int position)
        {
            var cell = _cells[position];
            cell.Marker = _game.CurrentPlayer.Marker;
            cell.Color = _game.CurrentPlayer.Color;
        }

        private void UpdateCurrentPlayerTurnLabel()
        {
            CurrentPlayerTurnLabel = $"Ход игрока: {_game.CurrentPlayerIndex + 1}";
        }

        private async Task DisplayGameResult(GameState result)
        {
            string message = result == GameState.Win
                ? $"{(_game.CurrentPlayerIndex + 1) % 2 + 1} игрок победил!"
                : "Ничья!";

            await Application.Current.MainPage.DisplayAlert("Игра окончена", message, "Ок");
        }

        private void ResetGame()
        {
            _game.Reset();
            ResetCells();

        }

        private void ResetCells()
        {
            foreach (var cell in Cells)
            {
                cell.Marker = '\0';
                cell.Color = Color.Default;
            }
        }
    }
}

