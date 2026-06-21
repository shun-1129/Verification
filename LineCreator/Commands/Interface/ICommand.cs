namespace LineCreator.Commands.Interface
{
    public interface ICommand
    {
        public void Execute ();

        public void Undo ();
    }
}
