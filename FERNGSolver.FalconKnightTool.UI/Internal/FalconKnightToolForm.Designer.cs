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
            m_AddButton = new Button();
            m_GridCanvas = new Path.GridCanvas();
            m_CurrentPathText = new Label();
            m_TotalCxStringTextBox = new TextBox();
            SuspendLayout();
            // 
            // m_AddButton
            // 
            m_AddButton.Location = new Point(403, 104);
            m_AddButton.Name = "m_AddButton";
            m_AddButton.Size = new Size(81, 41);
            m_AddButton.TabIndex = 0;
            m_AddButton.Text = "Add";
            m_AddButton.UseVisualStyleBackColor = true;
            // 
            // m_GridCanvas
            // 
            m_GridCanvas.BackColor = Color.White;
            m_GridCanvas.GridCount = 5;
            m_GridCanvas.Location = new Point(12, 12);
            m_GridCanvas.Name = "m_GridCanvas";
            m_GridCanvas.Size = new Size(267, 273);
            m_GridCanvas.TabIndex = 1;
            // 
            // m_CurrentPathText
            // 
            m_CurrentPathText.AutoSize = true;
            m_CurrentPathText.Location = new Point(326, 38);
            m_CurrentPathText.Name = "m_CurrentPathText";
            m_CurrentPathText.Size = new Size(106, 15);
            m_CurrentPathText.TabIndex = 2;
            m_CurrentPathText.Text = "m_CurrentPathText";
            // 
            // m_TotalCxStringTextBox
            // 
            m_TotalCxStringTextBox.Location = new Point(335, 208);
            m_TotalCxStringTextBox.Multiline = true;
            m_TotalCxStringTextBox.Name = "m_TotalCxStringTextBox";
            m_TotalCxStringTextBox.Size = new Size(299, 118);
            m_TotalCxStringTextBox.TabIndex = 3;
            // 
            // FalconKnightToolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(m_TotalCxStringTextBox);
            Controls.Add(m_CurrentPathText);
            Controls.Add(m_GridCanvas);
            Controls.Add(m_AddButton);
            Name = "FalconKnightToolForm";
            Text = "FalconKnightTool";
            FormClosed += OnFormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button m_AddButton;
        private Path.GridCanvas m_GridCanvas;
        private Label m_CurrentPathText;
        private TextBox m_TotalCxStringTextBox;
    }
}
