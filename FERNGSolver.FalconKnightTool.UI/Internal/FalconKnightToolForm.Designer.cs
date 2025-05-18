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
            GridCanvas = new FERNGSolver.FalconKnightTool.UI.Path.GridCanvas();
            m_CurrentPathText = new Label();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Location = new Point(154, 466);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(63, 28);
            AddButton.TabIndex = 0;
            AddButton.Text = "追加";
            AddButton.UseVisualStyleBackColor = true;
            // 
            // GridCanvas
            // 
            GridCanvas.BackColor = Color.White;
            GridCanvas.GridCount = 15;
            GridCanvas.Location = new Point(12, 12);
            GridCanvas.Name = "GridCanvas";
            GridCanvas.Size = new Size(406, 406);
            GridCanvas.TabIndex = 1;
            // 
            // m_CurrentPathText
            // 
            m_CurrentPathText.AutoSize = true;
            m_CurrentPathText.Location = new Point(136, 436);
            m_CurrentPathText.Name = "m_CurrentPathText";
            m_CurrentPathText.Size = new Size(106, 15);
            m_CurrentPathText.TabIndex = 2;
            m_CurrentPathText.Text = "m_CurrentPathText";
            // 
            // FalconKnightToolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 681);
            Controls.Add(m_CurrentPathText);
            Controls.Add(GridCanvas);
            Controls.Add(AddButton);
            Name = "FalconKnightToolForm";
            Text = "FalconKnightTool";
            FormClosed += OnFormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddButton;
        private Path.GridCanvas GridCanvas;
        private Label m_CurrentPathText;
    }
}
