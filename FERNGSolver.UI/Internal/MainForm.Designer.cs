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
            SearchButton = new Button();
            SearchResultDataGridView = new DataGridView();
            ResultsTabControl = new TabControl();
            RngViewTabPage = new TabPage();
            RngViewInitializeButton = new Button();
            RngViewPanel = new Panel();
            SearchResultsTabPage = new TabPage();
            ToolBarMenu = new MenuStrip();
            SwitchTitleTreeMenuItem = new ToolStripMenuItem();
            SearchConditionPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).BeginInit();
            ResultsTabControl.SuspendLayout();
            RngViewTabPage.SuspendLayout();
            SearchResultsTabPage.SuspendLayout();
            ToolBarMenu.SuspendLayout();
            SuspendLayout();
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SearchButton.BackColor = Color.Yellow;
            SearchButton.Location = new Point(269, 684);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(140, 32);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "検索";
            SearchButton.UseVisualStyleBackColor = false;
            // 
            // SearchResultDataGridView
            // 
            SearchResultDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SearchResultDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SearchResultDataGridView.Location = new Point(6, 6);
            SearchResultDataGridView.Name = "SearchResultDataGridView";
            SearchResultDataGridView.Size = new Size(692, 649);
            SearchResultDataGridView.TabIndex = 1;
            // 
            // ResultsTabControl
            // 
            ResultsTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResultsTabControl.Controls.Add(RngViewTabPage);
            ResultsTabControl.Controls.Add(SearchResultsTabPage);
            ResultsTabControl.Location = new Point(672, 33);
            ResultsTabControl.Name = "ResultsTabControl";
            ResultsTabControl.SelectedIndex = 0;
            ResultsTabControl.Size = new Size(712, 689);
            ResultsTabControl.TabIndex = 3;
            // 
            // RngViewTabPage
            // 
            RngViewTabPage.Controls.Add(RngViewInitializeButton);
            RngViewTabPage.Controls.Add(RngViewPanel);
            RngViewTabPage.Location = new Point(4, 24);
            RngViewTabPage.Name = "RngViewTabPage";
            RngViewTabPage.Padding = new Padding(3);
            RngViewTabPage.Size = new Size(704, 661);
            RngViewTabPage.TabIndex = 1;
            RngViewTabPage.Text = "乱数ビューア";
            RngViewTabPage.UseVisualStyleBackColor = true;
            // 
            // RngViewInitializeButton
            // 
            RngViewInitializeButton.Location = new Point(6, 6);
            RngViewInitializeButton.Name = "RngViewInitializeButton";
            RngViewInitializeButton.Size = new Size(75, 24);
            RngViewInitializeButton.TabIndex = 0;
            RngViewInitializeButton.Text = "初期化";
            RngViewInitializeButton.UseVisualStyleBackColor = true;
            // 
            // RngViewPanel
            // 
            RngViewPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RngViewPanel.AutoScroll = true;
            RngViewPanel.BackColor = Color.DimGray;
            RngViewPanel.Location = new Point(6, 36);
            RngViewPanel.Name = "RngViewPanel";
            RngViewPanel.Size = new Size(880, 670);
            RngViewPanel.TabIndex = 2;
            // 
            // SearchResultsTabPage
            // 
            SearchResultsTabPage.Controls.Add(SearchResultDataGridView);
            SearchResultsTabPage.Location = new Point(4, 24);
            SearchResultsTabPage.Name = "SearchResultsTabPage";
            SearchResultsTabPage.Padding = new Padding(3);
            SearchResultsTabPage.Size = new Size(704, 661);
            SearchResultsTabPage.TabIndex = 0;
            SearchResultsTabPage.Text = "検索結果";
            SearchResultsTabPage.UseVisualStyleBackColor = true;
            // 
            // ToolBarMenu
            // 
            ToolBarMenu.Items.AddRange(new ToolStripItem[] { SwitchTitleTreeMenuItem });
            ToolBarMenu.Location = new Point(0, 0);
            ToolBarMenu.Name = "ToolBarMenu";
            ToolBarMenu.Size = new Size(1384, 24);
            ToolBarMenu.TabIndex = 4;
            ToolBarMenu.Text = "menuStrip1";
            // 
            // SwitchTitleTreeMenuItem
            // 
            SwitchTitleTreeMenuItem.Name = "SwitchTitleTreeMenuItem";
            SwitchTitleTreeMenuItem.Size = new Size(55, 20);
            SwitchTitleTreeMenuItem.Text = "タイトル";
            // 
            // SearchConditionPanel
            // 
            SearchConditionPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            SearchConditionPanel.AutoScroll = true;
            SearchConditionPanel.BackColor = SystemColors.Window;
            SearchConditionPanel.Location = new Point(12, 33);
            SearchConditionPanel.Name = "SearchConditionPanel";
            SearchConditionPanel.Size = new Size(654, 643);
            SearchConditionPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 726);
            Controls.Add(SearchConditionPanel);
            Controls.Add(ResultsTabControl);
            Controls.Add(SearchButton);
            Controls.Add(ToolBarMenu);
            MainMenuStrip = ToolBarMenu;
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).EndInit();
            ResultsTabControl.ResumeLayout(false);
            RngViewTabPage.ResumeLayout(false);
            SearchResultsTabPage.ResumeLayout(false);
            ToolBarMenu.ResumeLayout(false);
            ToolBarMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SearchButton;
        private DataGridView SearchResultDataGridView;
        private ToolStripMenuItem OpenGenealogyRngListFormMenuItem;
        private TabControl ResultsTabControl;
        private TabPage SearchResultsTabPage;
        private TabPage RngViewTabPage;
        private Button RngViewInitializeButton;
        public Panel RngViewPanel;
        private MenuStrip ToolBarMenu;
        private Panel SearchConditionPanel;
        private ToolStripMenuItem SwitchTitleTreeMenuItem;
    }
}
