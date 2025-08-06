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
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            RngViewInitializeButton = new Button();
            RngViewPanel = new Panel();
            ToolBarMenu = new MenuStrip();
            SwitchTitleTreeMenuItem = new ToolStripMenuItem();
            SearchConditionPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).BeginInit();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
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
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(672, 33);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(712, 689);
            tabControl1.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(SearchResultDataGridView);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(704, 661);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "検索結果";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(RngViewInitializeButton);
            tabPage4.Controls.Add(RngViewPanel);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(704, 661);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "乱数ビューア";
            tabPage4.UseVisualStyleBackColor = true;
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
            Controls.Add(tabControl1);
            Controls.Add(SearchButton);
            Controls.Add(ToolBarMenu);
            MainMenuStrip = ToolBarMenu;
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ToolBarMenu.ResumeLayout(false);
            ToolBarMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SearchButton;
        private DataGridView SearchResultDataGridView;
        private ToolStripMenuItem OpenGenealogyRngListFormMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button RngViewInitializeButton;
        public Panel RngViewPanel;
        private MenuStrip ToolBarMenu;
        private Panel SearchConditionPanel;
        private ToolStripMenuItem SwitchTitleTreeMenuItem;
    }
}
