namespace Makecompany_Front.Usercontrol
{
    partial class MonthLabel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtYearMonth = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtYearMonth
            // 
            this.txtYearMonth.Location = new System.Drawing.Point(0, -1);
            this.txtYearMonth.Name = "txtYearMonth";
            this.txtYearMonth.Size = new System.Drawing.Size(102, 20);
            this.txtYearMonth.TabIndex = 0;
            this.txtYearMonth.Text = "平成○○年△△月";
            // 
            // MonthLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtYearMonth);
            this.Name = "MonthLabel";
            this.Size = new System.Drawing.Size(202, 19);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtYearMonth;
    }
}
