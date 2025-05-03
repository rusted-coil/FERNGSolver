namespace FERNGSolver.FalconKnightTool.UI.Internal
{
    partial class FalconKnightToolForm
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
            AddButton = new Button();
            GridCanvas = new Path.GridCanvas();
            m_CurrentPathText = new Label();
            TotalCxStringTextBox = new TextBox();
            SearchButton = new Button();
            SearchResultDataGridView = new DataGridView();
            ResultLabel = new Label();
            label1 = new Label();
            SearchConditionTabControl = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).BeginInit();
            SearchConditionTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Location = new Point(511, 13);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(63, 28);
            AddButton.TabIndex = 0;
            AddButton.Text = "←Add";
            AddButton.UseVisualStyleBackColor = true;
            // 
            // GridCanvas
            // 
            GridCanvas.BackColor = Color.White;
            GridCanvas.GridCount = 15;
            GridCanvas.Location = new Point(591, 43);
            GridCanvas.Name = "GridCanvas";
            GridCanvas.Size = new Size(406, 406);
            GridCanvas.TabIndex = 1;
            // 
            // m_CurrentPathText
            // 
            m_CurrentPathText.AutoSize = true;
            m_CurrentPathText.Location = new Point(596, 20);
            m_CurrentPathText.Name = "m_CurrentPathText";
            m_CurrentPathText.Size = new Size(106, 15);
            m_CurrentPathText.TabIndex = 2;
            m_CurrentPathText.Text = "m_CurrentPathText";
            // 
            // TotalCxStringTextBox
            // 
            TotalCxStringTextBox.Location = new Point(61, 17);
            TotalCxStringTextBox.Name = "TotalCxStringTextBox";
            TotalCxStringTextBox.Size = new Size(418, 23);
            TotalCxStringTextBox.TabIndex = 3;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(163, 389);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(115, 33);
            SearchButton.TabIndex = 5;
            SearchButton.Text = "検索";
            SearchButton.UseVisualStyleBackColor = true;
            // 
            // SearchResultDataGridView
            // 
            SearchResultDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SearchResultDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SearchResultDataGridView.Location = new Point(12, 467);
            SearchResultDataGridView.Name = "SearchResultDataGridView";
            SearchResultDataGridView.Size = new Size(984, 202);
            SearchResultDataGridView.TabIndex = 6;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(12, 449);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(31, 15);
            ResultLabel.TabIndex = 7;
            ResultLabel.Text = "結果";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 8;
            label1.Text = "cx列：";
            // 
            // SearchConditionTabControl
            // 
            SearchConditionTabControl.Controls.Add(tabPage1);
            SearchConditionTabControl.Controls.Add(tabPage2);
            SearchConditionTabControl.Location = new Point(12, 58);
            SearchConditionTabControl.Name = "SearchConditionTabControl";
            SearchConditionTabControl.SelectedIndex = 0;
            SearchConditionTabControl.Size = new Size(467, 273);
            SearchConditionTabControl.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(459, 245);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(459, 245);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // FalconKnightToolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 681);
            Controls.Add(SearchConditionTabControl);
            Controls.Add(label1);
            Controls.Add(ResultLabel);
            Controls.Add(SearchResultDataGridView);
            Controls.Add(SearchButton);
            Controls.Add(TotalCxStringTextBox);
            Controls.Add(m_CurrentPathText);
            Controls.Add(GridCanvas);
            Controls.Add(AddButton);
            Name = "FalconKnightToolForm";
            Text = "FalconKnightTool";
            FormClosed += OnFormClosed;
            ((System.ComponentModel.ISupportInitialize)SearchResultDataGridView).EndInit();
            SearchConditionTabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddButton;
        private Path.GridCanvas GridCanvas;
        private Label m_CurrentPathText;
        private TextBox TotalCxStringTextBox;
        private Button SearchButton;
        private DataGridView SearchResultDataGridView;
        private Label ResultLabel;
        private Label label1;
        private TabControl SearchConditionTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
