namespace FERNGSolver.Genealogy.UI.RngList.Internal
{
    partial class RngListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RngViewPanel = new Panel();
            SuspendLayout();
            // 
            // RngViewPanel
            // 
            RngViewPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RngViewPanel.AutoScroll = true;
            RngViewPanel.BackColor = Color.DimGray;
            RngViewPanel.Location = new Point(496, 29);
            RngViewPanel.Name = "RngViewPanel";
            RngViewPanel.Size = new Size(475, 737);
            RngViewPanel.TabIndex = 1;
            // 
            // RngListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 795);
            Controls.Add(RngViewPanel);
            Name = "RngListForm";
            Text = "聖戦の系譜 乱数ビューア";
            ResumeLayout(false);
        }

        #endregion

        private Panel RngViewPanel;
    }
}
