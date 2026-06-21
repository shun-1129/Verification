namespace LineCreator.Views.Forms
{
    partial class ListViweForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            _pointListPanel = new Panel ();
            _pointDataGridView = new DataGridView ();
            _lineListPanel = new Panel ();
            _lineDataGridView = new DataGridView ();
            _pointListPanel.SuspendLayout ();
            ( ( System.ComponentModel.ISupportInitialize ) _pointDataGridView ).BeginInit ();
            _lineListPanel.SuspendLayout ();
            ( ( System.ComponentModel.ISupportInitialize ) _lineDataGridView ).BeginInit ();
            SuspendLayout ();
            // 
            // _pointListPanel
            // 
            _pointListPanel.BackColor = SystemColors.ActiveCaption;
            _pointListPanel.Controls.Add ( _pointDataGridView );
            _pointListPanel.Location = new Point ( 0 , 0 );
            _pointListPanel.Name = "_pointListPanel";
            _pointListPanel.Padding = new Padding ( 10 );
            _pointListPanel.Size = new Size ( 1800 , 400 );
            _pointListPanel.TabIndex = 1;
            // 
            // _pointDataGridView
            // 
            _pointDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _pointDataGridView.Dock = DockStyle.Fill;
            _pointDataGridView.Location = new Point ( 10 , 10 );
            _pointDataGridView.Name = "_pointDataGridView";
            _pointDataGridView.Size = new Size ( 1780 , 380 );
            _pointDataGridView.TabIndex = 1;
            // 
            // _lineListPanel
            // 
            _lineListPanel.BackColor = Color.FromArgb ( 255 , 192 , 255 );
            _lineListPanel.Controls.Add ( _lineDataGridView );
            _lineListPanel.Location = new Point ( 0 , 400 );
            _lineListPanel.Name = "_lineListPanel";
            _lineListPanel.Padding = new Padding ( 10 );
            _lineListPanel.Size = new Size ( 1800 , 400 );
            _lineListPanel.TabIndex = 2;
            // 
            // _lineDataGridView
            // 
            _lineDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _lineDataGridView.Dock = DockStyle.Fill;
            _lineDataGridView.Location = new Point ( 10 , 10 );
            _lineDataGridView.Name = "_lineDataGridView";
            _lineDataGridView.Size = new Size ( 1780 , 380 );
            _lineDataGridView.TabIndex = 0;
            // 
            // ListViweForm
            // 
            AutoScaleDimensions = new SizeF ( 7F , 15F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size ( 1800 , 800 );
            Controls.Add ( _lineListPanel );
            Controls.Add ( _pointListPanel );
            Name = "ListViweForm";
            Text = "ListViweForm";
            Load += ListViweForm_Load;
            _pointListPanel.ResumeLayout ( false );
            ( ( System.ComponentModel.ISupportInitialize ) _pointDataGridView ).EndInit ();
            _lineListPanel.ResumeLayout ( false );
            ( ( System.ComponentModel.ISupportInitialize ) _lineDataGridView ).EndInit ();
            ResumeLayout ( false );
        }

        #endregion
        private Panel _pointListPanel;
        private DataGridView _pointDataGridView;
        private Panel _lineListPanel;
        private DataGridView _lineDataGridView;
    }
}