using Xamarin.Forms;

namespace App1.ViewModel
{
    public class CellViewModel : BaseViewModel
    {
        private char _marker;
        private Color _color;

        public char Marker
        {
            get { return _marker; }
            set { SetProperty(ref _marker, value); }
        }

        public Color Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }
    }
}
