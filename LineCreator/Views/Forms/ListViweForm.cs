using LineCreator.Models;
using System.ComponentModel;
using System.Data;

namespace LineCreator.Views.Forms
{
    public partial class ListViweForm : Form
    {
        private BindingList<LineNode> _lineBindingList = new ();
        private BindingList<PointNode> _pointBindingList = new ();

        public ListViweForm ( BindingList<PointNode> pointNodeList , BindingList<LineNode> lineNodeList )
        {
            _pointBindingList = pointNodeList;
            _lineBindingList = lineNodeList;
            InitializeComponent ();
        }

        private void ListViweForm_Load ( object sender , EventArgs e )
        {
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;

            _pointListPanel.Size = new Size ( ClientSize.Width , ClientSize.Height / 2 );
            _pointListPanel.Location = new Point ( 0 , 0 );

            _lineListPanel.Size = new Size ( ClientSize.Width , ClientSize.Height / 2 );
            _lineListPanel.Location = new Point ( 0 , _pointListPanel.Height );

            _pointDataGridView.DataSource = _pointBindingList;
            _lineDataGridView.DataSource = _lineBindingList;
        }
    }
}
