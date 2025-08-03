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
            OpenGenealogyRngListFormMenuItem = new ToolStripMenuItem();
            OpenThraciaRngListFormMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            RngViewPanel = new Panel();
            RngViewInitializeButton = new Button();
            SearchConditionTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
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
            SearchResultDataGridView.Location = new Point(6, 6);
            SearchResultDataGridView.Name = "SearchResultDataGridView";
            SearchResultDataGridView.Size = new Size(880, 697);
            SearchResultDataGridView.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ツールToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1584, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // ツールToolStripMenuItem
            // 
            ツールToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenGenealogyRngListFormMenuItem, OpenThraciaRngListFormMenuItem });
            ツールToolStripMenuItem.Name = "ツールToolStripMenuItem";
            ツールToolStripMenuItem.Size = new Size(46, 20);
            ツールToolStripMenuItem.Text = "ツール";
            // 
            // OpenGenealogyRngListFormMenuItem
            // 
            OpenGenealogyRngListFormMenuItem.Name = "OpenGenealogyRngListFormMenuItem";
            OpenGenealogyRngListFormMenuItem.Size = new Size(192, 22);
            OpenGenealogyRngListFormMenuItem.Text = "聖戦の系譜 乱数ビューア";
            OpenGenealogyRngListFormMenuItem.Click += OpenGenealogyRngListFormMenuItem_Click;
            // 
            // OpenThraciaRngListFormMenuItem
            // 
            OpenThraciaRngListFormMenuItem.Name = "OpenThraciaRngListFormMenuItem";
            OpenThraciaRngListFormMenuItem.Size = new Size(192, 22);
            OpenThraciaRngListFormMenuItem.Text = "トラキア776 乱数ビューア";
            OpenThraciaRngListFormMenuItem.Click += OpenThraciaRngListFormMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(672, 36);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(900, 737);
            tabControl1.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(SearchResultDataGridView);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(892, 709);
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
            tabPage4.Size = new Size(892, 709);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "乱数ビューア";
            tabPage4.UseVisualStyleBackColor = true;
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
            // RngViewInitializeButton
            // 
            RngViewInitializeButton.Location = new Point(6, 6);
            RngViewInitializeButton.Name = "RngViewInitializeButton";
            RngViewInitializeButton.Size = new Size(75, 24);
            RngViewInitializeButton.TabIndex = 0;
            RngViewInitializeButton.Text = "初期化";
            RngViewInitializeButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 785);
            Controls.Add(tabControl1);
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
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
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
        private ToolStripMenuItem OpenGenealogyRngListFormMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Panel RngViewPanel;
        private Button RngViewInitializeButton;
    }
}
