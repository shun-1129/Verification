using LineCreator.Models;
using LineCreator.Commands.Interface;
using System.ComponentModel;

namespace LineCreator.Commands.Impl
{
    public class AddPointCommand : ICommand
    {
        private readonly BindingList<PointNode> _points;
        private readonly PointNode _point;

        public AddPointCommand (
            BindingList<PointNode> points ,
            PointNode point )
        {
            _points = points;
            _point = point;
        }

        public void Execute ()
        {
            _points.Add ( _point );
        }

        public void Undo ()
        {
            _points.Remove ( _point );
        }
    }
}
