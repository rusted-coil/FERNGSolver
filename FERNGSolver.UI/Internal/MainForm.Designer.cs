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
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            RngViewInitializeButton = new Button();
            RngViewPanel = new Panel();
            SearchConditionTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).BeginInit();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // SearchConditionTabControl
            // 
            SearchConditionTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            SearchConditionTabControl.Controls.Add(tabPage1);
            SearchConditionTabControl.Controls.Add(tabPage2);
            SearchConditionTabControl.Location = new Point(12, 12);
            SearchConditionTabControl.Name = "SearchConditionTabControl";
            SearchConditionTabControl.SelectedIndex = 0;
            SearchConditionTabControl.Size = new Size(654, 664);
            SearchConditionTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(646, 636);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(646, 636);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SearchButton.BackColor = Color.Yellow;
            SearchButton.Location = new Point(257, 682);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 726);
            Controls.Add(tabControl1);
            Controls.Add(SearchButton);
            Controls.Add(SearchConditionTabControl);
            Name = "MainForm";
            Text = "Form1";
            Shown += MainForm_Shown;
            SearchConditionTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl SearchConditionTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button SearchButton;
        private DataGridView SearchResultDataGridView;
        private ToolStripMenuItem OpenGenealogyRngListFormMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button RngViewInitializeButton;
        public Panel RngViewPanel;
    }
}
