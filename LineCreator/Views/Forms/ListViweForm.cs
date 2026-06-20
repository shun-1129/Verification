using LineCreator.Models;
using System.ComponentModel;

namespace LineCreator.Views.Forms
{
    public partial class ListViweForm : Form
    {
        private BindingList<PointNode> _bindingList = new ();

        public ListViweForm ( BindingList<PointNode> pointNodeList )
        {
            _bindingList = pointNodeList;
            InitializeComponent ();
        }

        private void ListViweForm_Load ( object sender , EventArgs e )
        {
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;

            _dataGridView.DataSource = _bindingList;
        }
    }
}
