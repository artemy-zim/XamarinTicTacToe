using Xamarin.Forms;

namespace App1.Model
{
    public class Player
    {
        public Player(char marker, Color color)
        {
            Marker = marker;
            Color = color;
        }

        public char Marker { get; private set; }
        public Color Color { get; private set; }
    }
}
