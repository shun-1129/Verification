namespace LineCreator.Constants
{
    public class Constants
    {
        public enum ToolMode
        {
            None = 0 ,
            LineSegment = 1,
        }

        public const int POINT_RADIUS = 12;
        private const int DrawingWidthMm = 10000;
        private const int DrawingHeightMm = 10000;
        private const float PixelsPerMm = 4.0f;
    }
}
