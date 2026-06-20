namespace LineCreator.Extensions
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel ()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
    }
}
