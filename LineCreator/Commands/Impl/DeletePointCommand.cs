using LineCreator.Commands.Interface;
using LineCreator.Models;
using System.ComponentModel;

namespace LineCreator.Commands.Impl
{
    public class DeletePointCommand : ICommand
    {
        private readonly BindingList<PointNode> _points;
        private readonly BindingList<LineNode> _lines;

        private readonly PointNode _point;

        private readonly List<LineNode> _removedLines = new();

        private int _pointIndex;

        public DeletePointCommand (
            BindingList<PointNode> points ,
            BindingList<LineNode> lines ,
            PointNode point )
        {
            _points = points;
            _lines = lines;
            _point = point;
        }

        public void Execute ()
        {
            _pointIndex = _points.IndexOf ( _point );

            _removedLines.Clear ();

            foreach ( LineNode line in _lines.ToList () )
            {
                if ( line.Start == _point ||
                    line.End == _point )
                {
                    _removedLines.Add ( line );
                    _lines.Remove ( line );
                }
            }

            _points.Remove ( _point );
        }

        public void Undo ()
        {
            _points.Insert ( _pointIndex , _point );

            foreach ( LineNode line in _removedLines )
            {
                _lines.Add ( line );
            }
        }
    }
}
