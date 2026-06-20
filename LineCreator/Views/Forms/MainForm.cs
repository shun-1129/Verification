using LineCreator.Models;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using static LineCreator.Constants.Constants;

namespace LineCreator.Views.Forms
{
    public partial class MainForm : Form
    {
        private readonly Pen _linePen = new ( Color.Blue , 2 );
        private readonly Pen _tempPen = new ( Color.Gray , 1 ) { DashStyle = DashStyle.Dash };
        private readonly BindingList<PointNode> _points = new();
        private readonly List<LineNode> _lines = new();
        private PointNode? _currentPoint;
        private Point _mousePosition;
        private ToolMode _toolMode = ToolMode.None;
        private PointF _viewOffset = new(0, 0);
        private bool _isPanning;
        private Point _panStartMouse;
        private PointF _panStartOffset;
        private float _scale = 4.0f;

        public MainForm ()
        {
            InitializeComponent ();
            SetupEventHandlers ();
        }

        private void MainForm_Load ( object? sender , EventArgs e )
        {
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;

            int clientWidth = ClientSize.Width;
            int clientHeight = ClientSize.Height;
            _menuPanel.Size = new Size ( clientWidth , 100 );
            _viewPanel.Size = new Size ( clientWidth , clientHeight - _menuPanel.Height );
        }

        private void SetupEventHandlers ()
        {
            KeyPreview = true;

            _pointLinePanel.Paint += PointLinePanel_Paint;
            _pointLinePanel.MouseClick += PointLinePanel_MouseClick;
            _pointLinePanel.MouseMove += PointLinePanel_MouseMove;
            _pointLinePanel.MouseDown += PointLinePanel_MouseDown;
            _pointLinePanel.MouseUp += PointLinePanel_MouseUp;
            KeyDown += MainForm_KeyDown;
            _lineSegmentBtn.Click += LineSegmentBtn_Click;
            _listDispBtn.Click += ListDispBtn_Click;
        }

        private void MainForm_KeyDown ( object? sender , KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Escape )
            {
                _currentPoint = null;
                _toolMode = ToolMode.None;

                _pointLinePanel.Invalidate ();
            }
        }

        private void PointLinePanel_MouseClick ( object? sender , MouseEventArgs e )
        {
            if ( _toolMode != ToolMode.LineSegment )
                return;

            if ( e.Button != MouseButtons.Left )
                return;

            // ★① 既存点をクリックしたか判定

            PointNode? point = null;

            if ( _currentPoint != null )
            {
                PointF worldMouse = ScreenToWorld(e.Location);
                PointNode? hitPoint = FindPoint(worldMouse);
                if ( hitPoint != null )
                {
                    var result = MessageBox.Show (
                        "この点と接続しますか？" ,
                        "確認" ,
                        MessageBoxButtons.YesNo ,
                        MessageBoxIcon.Question );

                    if ( result == DialogResult.Yes )
                    {
                        point = hitPoint;
                    }
                }
            }

            // ★② 「いいえ」または既存点ではなかった場合
            if ( point == null )
            {
                PointF worldPos = ScreenToWorld(e.Location);

                if ( _currentPoint != null )
                {
                    worldPos = GetSnapPoint ( _currentPoint.Position , worldPos );
                }

                point = CreatePoint ( worldPos );
            }

            // ★③ 線を引く処理
            if ( _currentPoint != null )
            {
                _lines.Add ( new LineNode
                {
                    Start = _currentPoint ,
                    End = point
                } );
            }

            _currentPoint = point;

            _pointLinePanel.Invalidate ();
        }

        private void PointLinePanel_Paint ( object? sender , PaintEventArgs e )
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 線
            foreach ( var line in _lines )
            {
                PointF start = WorldToScreen(line.Start.Position);
                PointF end = WorldToScreen(line.End.Position);

                g.DrawLine (
                    _linePen ,
                    start ,
                    end );
            }

            // 仮線
            if ( _toolMode == ToolMode.LineSegment && _currentPoint != null )
            {
                // 図面座標
                PointF worldEnd = GetSnapPoint(
                    _currentPoint.Position,
                    ScreenToWorld ( _mousePosition ) );

                // 画面座標へ変換
                PointF screenStart = WorldToScreen ( _currentPoint.Position );
                PointF screenEnd = WorldToScreen ( worldEnd );

                // 描画
                g.DrawLine (
                    _tempPen ,
                    screenStart ,
                    screenEnd );
            }

            // 頂点
            foreach ( var p in _points )
            {
                DrawPoint ( g , p );
            }
        }

        private void Point_PropertyChanged ( object? sender , PropertyChangedEventArgs e )
        {
            _pointLinePanel.Invalidate ();
        }

        private void PointLinePanel_MouseMove ( object? sender , MouseEventArgs e )
        {
            _mousePosition = e.Location;

            if ( _isPanning )
            {
                _viewOffset = new PointF (
                    _panStartOffset.X - ( e.X - _panStartMouse.X ) / _scale ,
                    _panStartOffset.Y - ( e.Y - _panStartMouse.Y ) / _scale );

                _pointLinePanel.Invalidate ();
                return;
            }

            if ( _toolMode == ToolMode.LineSegment && _currentPoint != null )
            {
                _pointLinePanel.Invalidate ();
            }
        }

        private void PointLinePanel_MouseDown ( object? sender , MouseEventArgs e )
        {
            if ( _toolMode != ToolMode.None )
                return;

            if ( e.Button != MouseButtons.Left )
                return;

            _isPanning = true;
            _panStartMouse = e.Location;
            _panStartOffset = _viewOffset;
        }

        private void PointLinePanel_MouseUp ( object? sender , MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Left )
            {
                _isPanning = false;
            }
        }

        private void DrawPoint ( Graphics g , PointNode point )
        {
            PointF screen = WorldToScreen(point.Position);

            RectangleF rect = new RectangleF (
                screen.X - POINT_RADIUS ,
                screen.Y - POINT_RADIUS ,
                POINT_RADIUS * 2 ,
                POINT_RADIUS * 2 );

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
                screen.X - size.Width / 2 ,
                screen.Y - size.Height / 2 );
        }

        private void LineSegmentBtn_Click ( object? sender , EventArgs e )
        {
            _toolMode = ToolMode.LineSegment;
            _currentPoint = null;
        }

        private void ListDispBtn_Click ( object? sender , EventArgs e )
        {
            using var listForm = new ListViweForm ( _points );
            listForm.ShowDialog ();
        }

        private PointF GetSnapPoint ( PointF start , PointF current )
        {
            if ( ( ModifierKeys & Keys.Shift ) == 0 )
                return current;

            float dx = current.X - start.X;
            float dy = current.Y - start.Y;

            if ( Math.Abs ( dx ) >= Math.Abs ( dy ) )
                return new PointF ( current.X , start.Y );

            return new PointF ( start.X , current.Y );
        }

        private PointNode? FindPoint ( PointF mouse )
        {
            return _points.FirstOrDefault ( p =>
            {
                float dx = p.Position.X - mouse.X;
                float dy = p.Position.Y - mouse.Y;

                return dx * dx + dy * dy <= POINT_RADIUS * POINT_RADIUS;
            } );
        }

        private PointNode CreatePoint ( PointF position )
        {
            var point = new PointNode
            {
                Position = position,
                Number = _points.Count + 1
            };

            point.PropertyChanged += Point_PropertyChanged;
            _points.Add ( point );

            return point;
        }

        private PointF WorldToScreen ( PointF world )
        {
            return new PointF (
                ( world.X - _viewOffset.X ) * _scale ,
                ( world.Y - _viewOffset.Y ) * _scale );
        }

        private PointF ScreenToWorld ( Point screen )
        {
            return new PointF (
                screen.X / _scale + _viewOffset.X ,
                screen.Y / _scale + _viewOffset.Y );
        }
    }
}
