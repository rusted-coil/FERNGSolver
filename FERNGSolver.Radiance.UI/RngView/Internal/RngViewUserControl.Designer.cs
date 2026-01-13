using FERNGSolver.Radiance.Domain.Combat;

namespace FERNGSolver.Radiance.UI.RngView.Internal
{
    partial class RngViewUserControl
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
        private new void InitializeComponent()
        {
            TableIndexLabel = new Label();
            TableIndexNumericUpDown = new FERNGSolver.Common.UI.Controls.NumericUpDownEx();
            PositionLabel = new Label();
            PositionNumericUpDown = new FERNGSolver.Common.UI.Controls.NumericUpDownEx();
            ((System.ComponentModel.ISupportInitialize)TableIndexNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PositionNumericUpDown).BeginInit();
            SuspendLayout();

            const int topControlY = 5;
            const int tableIndexLocationX = 3;
            const int tableIndexLabelWidth = 55;
            const int positionLocationX = 110;
            const int positionLabelWidth = 46;

            int controlCount = 0;

            // テーブル番号
            {
                TableIndexLabel.AutoSize = true;
                TableIndexLabel.Name = "TableIndexLabel";
                TableIndexLabel.TabIndex = controlCount;

                TableIndexLabel.Text = "テーブル: #";
                TableIndexLabel.Location = new Point(tableIndexLocationX, topControlY + 2);
                TableIndexLabel.Size = new Size(tableIndexLabelWidth, 15);

                Controls.Add(TableIndexLabel);
                Controls.SetChildIndex(TableIndexLabel, controlCount);
                controlCount++;

                TableIndexNumericUpDown.Name = "TableIndexNumericUpDown";
                TableIndexNumericUpDown.TabIndex = controlCount;
                TableIndexNumericUpDown.TextAlign = HorizontalAlignment.Right;

                TableIndexNumericUpDown.Maximum = new decimal(new int[] { Radiance.Domain.RNG.Const.TableCount - 1, 0, 0, 0 });
                TableIndexNumericUpDown.ValueChanged += TableIndexNumericUpDown_ValueChanged;
                TableIndexNumericUpDown.Location = new Point(tableIndexLocationX + tableIndexLabelWidth, topControlY);
                TableIndexNumericUpDown.Size = new Size(40, 23);

                Controls.Add(TableIndexNumericUpDown);
                Controls.SetChildIndex(TableIndexNumericUpDown, controlCount);
                controlCount++;
            }

            // 消費数
            {
                PositionLabel.AutoSize = true;
                PositionLabel.Name = "PositionLabel";
                PositionLabel.TabIndex = controlCount;

                PositionLabel.Text = "消費数:";
                PositionLabel.Location = new Point(positionLocationX, topControlY + 2);
                PositionLabel.Size = new Size(positionLabelWidth, 15);

                Controls.Add(PositionLabel);
                Controls.SetChildIndex(PositionLabel, controlCount);
                controlCount++;

                PositionNumericUpDown.Name = "PositionNumericUpDown";
                PositionNumericUpDown.TabIndex = controlCount;
                PositionNumericUpDown.TextAlign = HorizontalAlignment.Right;

                PositionNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
                PositionNumericUpDown.ValueChanged += PositionNumericUpDown_ValueChanged;
                PositionNumericUpDown.Location = new Point(positionLocationX + positionLabelWidth, topControlY);
                PositionNumericUpDown.Size = new Size(70, 23);

                Controls.Add(PositionNumericUpDown);
                Controls.SetChildIndex(PositionNumericUpDown, controlCount);
                controlCount++;
            }

            // 全体の設定
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Name = "RngViewUserControl";

            ((System.ComponentModel.ISupportInitialize)PositionNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)TableIndexNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label TableIndexLabel;
        private Common.UI.Controls.NumericUpDownEx TableIndexNumericUpDown;
        private Label PositionLabel;
        private Common.UI.Controls.NumericUpDownEx PositionNumericUpDown;
    }
}
