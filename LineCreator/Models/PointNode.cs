using System.ComponentModel;

namespace LineCreator.Models
{
    public class PointNode
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged ( string name )
        {
            PropertyChanged?.Invoke ( this , new PropertyChangedEventArgs ( name ) );
        }

        private int _number;

        private PointF _position;

        public int Number
        {
            get => _number;
            set
            {
                if ( _number != value )
                {
                    _number = value;
                    OnPropertyChanged ( nameof ( Number ) );
                }
            }
        }

        public PointF Position
        {
            get => _position;
            set
            {
                if ( _position != value )
                {
                    _position = value;
                    OnPropertyChanged ( nameof ( Position ) );
                }
            }
        }

        public int PositionX
        {
            get => Convert.ToInt32 ( Position.X );
            set => Position = new PointF ( value , Position.Y );
        }

        public int PositionY
        {
            get => Convert.ToInt32 ( Position.Y );
            set => Position = new PointF ( Position.X , value );
        }
    }
}
