namespace FERNGSolver.UI.Internal
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SearchConditionTabControl = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            SearchButton = new Button();
            SearchResultDataGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            ツールToolStripMenuItem = new ToolStripMenuItem();
            OpenThraciaRngListFormMenuItem = new ToolStripMenuItem();
            SearchConditionTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // SearchConditionTabControl
            // 
            SearchConditionTabControl.Controls.Add(tabPage1);
            SearchConditionTabControl.Controls.Add(tabPage2);
            SearchConditionTabControl.Location = new Point(12, 36);
            SearchConditionTabControl.Name = "SearchConditionTabControl";
            SearchConditionTabControl.SelectedIndex = 0;
            SearchConditionTabControl.Size = new Size(654, 699);
            SearchConditionTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(646, 671);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(646, 671);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.Yellow;
            SearchButton.Location = new Point(257, 741);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(143, 32);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "検索";
            SearchButton.UseVisualStyleBackColor = false;
            // 
            // SearchResultDataGridView
            // 
            SearchResultDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SearchResultDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SearchResultDataGridView.Location = new Point(672, 36);
            SearchResultDataGridView.Name = "SearchResultDataGridView";
            SearchResultDataGridView.Size = new Size(500, 713);
            SearchResultDataGridView.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ツールToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1184, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // ツールToolStripMenuItem
            // 
            ツールToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenThraciaRngListFormMenuItem });
            ツールToolStripMenuItem.Name = "ツールToolStripMenuItem";
            ツールToolStripMenuItem.Size = new Size(46, 20);
            ツールToolStripMenuItem.Text = "ツール";
            // 
            // OpenThraciaRngListFormMenuItem
            // 
            OpenThraciaRngListFormMenuItem.Name = "OpenThraciaRngListFormMenuItem";
            OpenThraciaRngListFormMenuItem.Size = new Size(186, 22);
            OpenThraciaRngListFormMenuItem.Text = "トラキア776 乱数ビューア";
            OpenThraciaRngListFormMenuItem.Click += OpenThraciaRngListFormMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 785);
            Controls.Add(SearchResultDataGridView);
            Controls.Add(SearchButton);
            Controls.Add(SearchConditionTabControl);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            SearchConditionTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl SearchConditionTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button SearchButton;
        private DataGridView SearchResultDataGridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ツールToolStripMenuItem;
        private ToolStripMenuItem OpenThraciaRngListFormMenuItem;
    }
}
