using LineCreator.Extensions;

namespace LineCreator.Views.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing )
            {
                _linePen.Dispose ();
                _tempPen.Dispose ();
            }

            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            _pointLinePanel = new DoubleBufferedPanel ();
            _menuPanel = new Panel ();
            _lineSegmentBtn = new Button ();
            _viewPanel = new Panel ();
            _listDispBtn = new Button ();
            _menuPanel.SuspendLayout ();
            _viewPanel.SuspendLayout ();
            SuspendLayout ();
            // 
            // _pointLinePanel
            // 
            _pointLinePanel.BackColor = Color.White;
            _pointLinePanel.Dock = DockStyle.Fill;
            _pointLinePanel.Location = new Point ( 10 , 10 );
            _pointLinePanel.Name = "_pointLinePanel";
            _pointLinePanel.Size = new Size ( 1780 , 780 );
            _pointLinePanel.TabIndex = 0;
            // 
            // _menuPanel
            // 
            _menuPanel.BackColor = Color.FromArgb ( 255 , 0 , 0 );
            _menuPanel.Controls.Add ( _listDispBtn );
            _menuPanel.Controls.Add ( _lineSegmentBtn );
            _menuPanel.Location = new Point ( 0 , 0 );
            _menuPanel.Name = "_menuPanel";
            _menuPanel.Size = new Size ( 1800 , 100 );
            _menuPanel.TabIndex = 1;
            // 
            // _lineSegmentBtn
            // 
            _lineSegmentBtn.Location = new Point ( 12 , 12 );
            _lineSegmentBtn.Name = "_lineSegmentBtn";
            _lineSegmentBtn.Size = new Size ( 85 , 72 );
            _lineSegmentBtn.TabIndex = 0;
            _lineSegmentBtn.Text = "線分";
            _lineSegmentBtn.UseVisualStyleBackColor = true;
            // 
            // _viewPanel
            // 
            _viewPanel.BackColor = Color.FromArgb ( 0 , 255 , 0 );
            _viewPanel.Controls.Add ( _pointLinePanel );
            _viewPanel.Location = new Point ( 0 , 100 );
            _viewPanel.Name = "_viewPanel";
            _viewPanel.Padding = new Padding ( 10 );
            _viewPanel.Size = new Size ( 1800 , 800 );
            _viewPanel.TabIndex = 2;
            // 
            // _listDispBtn
            // 
            _listDispBtn.Location = new Point ( 138 , 12 );
            _listDispBtn.Name = "_listDispBtn";
            _listDispBtn.Size = new Size ( 85 , 72 );
            _listDispBtn.TabIndex = 1;
            _listDispBtn.Text = "リスト表示";
            _listDispBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF ( 7F , 15F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size ( 1800 , 900 );
            Controls.Add ( _viewPanel );
            Controls.Add ( _menuPanel );
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            _menuPanel.ResumeLayout ( false );
            _viewPanel.ResumeLayout ( false );
            ResumeLayout ( false );
        }

        #endregion

        private DoubleBufferedPanel _pointLinePanel;
        private Panel _menuPanel;
        private Panel _viewPanel;
        private Button _lineSegmentBtn;
        private Button _listDispBtn;
    }
}
