using LineCreator.Commands.Interface;
using LineCreator.Models;
using System.ComponentModel;

namespace LineCreator.Commands.Impl
{
    public class AddLineCommand : ICommand
    {
        private readonly BindingList<LineNode> _lines;
        private readonly LineNode _line;

        public AddLineCommand (
            BindingList<LineNode> lines ,
            LineNode line )
        {
            _lines = lines;
            _line = line;
        }

        public void Execute ()
        {
            _lines.Add ( _line );
        }

        public void Undo ()
        {
            _lines.Remove ( _line );
        }
    }
}
