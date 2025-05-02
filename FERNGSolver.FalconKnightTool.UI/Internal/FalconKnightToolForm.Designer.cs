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
            m_TestGroupBox = new GroupBox();
            m_TestPanel = new Panel();
            SearchButton = new Button();
            m_TestGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Location = new Point(12, 326);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(63, 28);
            AddButton.TabIndex = 0;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            // 
            // GridCanvas
            // 
            GridCanvas.BackColor = Color.White;
            GridCanvas.GridCount = 5;
            GridCanvas.Location = new Point(12, 12);
            GridCanvas.Name = "GridCanvas";
            GridCanvas.Size = new Size(267, 273);
            GridCanvas.TabIndex = 1;
            // 
            // m_CurrentPathText
            // 
            m_CurrentPathText.AutoSize = true;
            m_CurrentPathText.Location = new Point(12, 298);
            m_CurrentPathText.Name = "m_CurrentPathText";
            m_CurrentPathText.Size = new Size(106, 15);
            m_CurrentPathText.TabIndex = 2;
            m_CurrentPathText.Text = "m_CurrentPathText";
            // 
            // TotalCxStringTextBox
            // 
            TotalCxStringTextBox.Location = new Point(327, 12);
            TotalCxStringTextBox.Multiline = true;
            TotalCxStringTextBox.Name = "TotalCxStringTextBox";
            TotalCxStringTextBox.Size = new Size(418, 34);
            TotalCxStringTextBox.TabIndex = 3;
            // 
            // m_TestGroupBox
            // 
            m_TestGroupBox.Controls.Add(m_TestPanel);
            m_TestGroupBox.Location = new Point(321, 73);
            m_TestGroupBox.Name = "m_TestGroupBox";
            m_TestGroupBox.Size = new Size(403, 233);
            m_TestGroupBox.TabIndex = 4;
            m_TestGroupBox.TabStop = false;
            m_TestGroupBox.Text = "groupBox1";
            // 
            // m_TestPanel
            // 
            m_TestPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            m_TestPanel.Location = new Point(20, 22);
            m_TestPanel.Name = "m_TestPanel";
            m_TestPanel.Size = new Size(355, 180);
            m_TestPanel.TabIndex = 0;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(380, 326);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(63, 28);
            SearchButton.TabIndex = 5;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            // 
            // FalconKnightToolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SearchButton);
            Controls.Add(m_TestGroupBox);
            Controls.Add(TotalCxStringTextBox);
            Controls.Add(m_CurrentPathText);
            Controls.Add(GridCanvas);
            Controls.Add(AddButton);
            Name = "FalconKnightToolForm";
            Text = "FalconKnightTool";
            FormClosed += OnFormClosed;
            m_TestGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddButton;
        private Path.GridCanvas GridCanvas;
        private Label m_CurrentPathText;
        private TextBox TotalCxStringTextBox;
        private GroupBox m_TestGroupBox;
        private Panel m_TestPanel;
        private Button SearchButton;
    }
}
