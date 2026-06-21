namespace LineCreator.Models
{
    public class LineNode
    {
        public PointNode Start { get; set; }

        public PointNode End { get; set; }

        public int FromNumber => Start.Number;
        public int ToNumber => End.Number;

        public LineNode ()
        {
            Start = new PointNode ();
            End = new PointNode ();
        }
    }
}
