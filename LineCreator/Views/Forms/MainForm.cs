using LineCreator.Models;

namespace LineCreator.Views.Forms
{
    public partial class MainForm : Form
    {
        private const int PointRadius = 12;

        private readonly List<PointNode> _points = new();
        private readonly List<Line> _lines = new();
        private PointNode? _currentPoint;
        private Point _mousePosition;

        public MainForm ()
        {
            InitializeComponent ();

            KeyPreview = true;

            panel1.MouseClick += Panel1_MouseClick;
            panel1.Paint += Panel1_Paint;
            panel1.MouseMove += Panel1_MouseMove;
            KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown ( object? sender , KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Escape )
            {
                _currentPoint = null;
                panel1.Invalidate ();
            }
        }

        private void Panel1_MouseClick ( object? sender , MouseEventArgs e )
        {
            if ( e.Button != MouseButtons.Left )
                return;

            // ★① 既存点をクリックしたか判定
            var hitPoint = FindPoint(e.Location);

            PointNode? point = null;

            if ( hitPoint != null )
            {
                var result = MessageBox.Show(
            "この点と接続しますか？",
            "確認",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

                if ( result == DialogResult.Yes )
                {
                    point = hitPoint;
                }
            }

            // ★② 「いいえ」または既存点ではなかった場合
            if ( point == null )
            {
                Point pos = e.Location;

                if ( _currentPoint != null )
                {
                    pos = GetSnapPoint ( _currentPoint.Position , pos );
                }

                point = new PointNode
                {
                    Position = pos ,
                    Number = _points.Count + 1
                };

                _points.Add ( point );
            }

            // ★③ 線を引く処理
            if ( _currentPoint != null )
            {
                _lines.Add ( new Line
                {
                    Start = _currentPoint ,
                    End = point
                } );
            }

            _currentPoint = point;

            panel1.Invalidate ();
        }

        private void Panel1_Paint ( object? sender , PaintEventArgs e )
        {
            Graphics g = e.Graphics;

            g.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using Pen pen = new(Color.Blue, 2);

            // 線
            foreach ( var line in _lines )
            {
                g.DrawLine (
                    pen ,
                    line.Start.Position ,
                    line.End.Position );
            }

            // 仮線
            if ( _currentPoint != null )
            {
                Point end = GetSnapPoint(_currentPoint.Position, _mousePosition);

                using Pen tempPen = new(Color.Gray, 1)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };

                g.DrawLine ( tempPen , _currentPoint.Position , end );
            }

            // 頂点
            foreach ( var p in _points )
            {
                DrawPoint ( g , p );
            }
        }

        private void Panel1_MouseMove ( object? sender , MouseEventArgs e )
        {
            _mousePosition = e.Location;
            panel1.Invalidate ();
        }

        private void DrawPoint ( Graphics g , PointNode point )
        {
            const int radius = 12;

            Rectangle rect = new Rectangle (
                point.Position.X - radius ,
                point.Position.Y - radius ,
                radius * 2 ,
                radius * 2 );

            Brush fill = Brushes.Red;
            using Pen border = new Pen ( Color.Black , 2);

            g.FillEllipse ( fill , rect );
            g.DrawEllipse ( border , rect );

            string text = point.Number.ToString ();

            SizeF size = g.MeasureString( text , Font );

            g.DrawString (
                text ,
                Font ,
                Brushes.White ,
                point.Position.X - size.Width / 2 ,
                point.Position.Y - size.Height / 2 );
        }

        private Point GetSnapPoint ( Point start , Point current )
        {
            if ( ( ModifierKeys & Keys.Shift ) == 0 )
                return current;

            int dx = current.X - start.X;
            int dy = current.Y - start.Y;

            if ( Math.Abs ( dx ) >= Math.Abs ( dy ) )
            {
                // 水平
                return new Point ( current.X , start.Y );
            }
            else
            {
                // 垂直
                return new Point ( start.X , current.Y );
            }
        }
        private PointNode? FindPoint ( Point mouse )
        {
            return _points.FirstOrDefault ( p =>
            {
                int dx = p.Position.X - mouse.X;
                int dy = p.Position.Y - mouse.Y;

                return dx * dx + dy * dy <= PointRadius * PointRadius;
            } );
        }
    }
}
