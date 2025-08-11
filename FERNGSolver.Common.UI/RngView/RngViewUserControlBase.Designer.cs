namespace FERNGSolver.Common.UI.RngView
{
    partial class RngViewUserControlBase<TViewModel>
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // ジェネリッククラスのためデザイナーで編集することを諦め、以下の内容を手動で記述する。
        protected void InitializeComponent()
        {
            RemoveButton = new Button();
            SuspendLayout();

            // 
            // RemoveButton
            // 
            RemoveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RemoveButton.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RemoveButton.Location = new Point(372, 2);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(22, 22);
            RemoveButton.TabIndex = 2;
            RemoveButton.Text = "✕";
            RemoveButton.UseVisualStyleBackColor = true;

            // 
            // RngViewUserControlBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(RemoveButton);
            DoubleBuffered = true;
            Name = "RngViewUserControlBase";
            ResumeLayout(false);
        }

        private Button RemoveButton;
    }
}
