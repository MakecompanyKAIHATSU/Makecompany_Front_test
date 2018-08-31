namespace Makecompany_Front
{
    partial class frmマスタ小科目
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
            this.cbxコース = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblコース = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxコース
            // 
            this.cbxコース.FormattingEnabled = true;
            this.cbxコース.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbxコース.Location = new System.Drawing.Point(74, 12);
            this.cbxコース.Name = "cbxコース";
            this.cbxコース.Size = new System.Drawing.Size(147, 21);
            this.cbxコース.TabIndex = 0;
            this.cbxコース.SelectedIndexChanged += new System.EventHandler(this.cbxコース_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "コース";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBox1.Location = new System.Drawing.Point(74, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(147, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "中科目";
            // 
            // lblコース
            // 
            this.lblコース.AutoSize = true;
            this.lblコース.Location = new System.Drawing.Point(227, 16);
            this.lblコース.Name = "lblコース";
            this.lblコース.Size = new System.Drawing.Size(34, 13);
            this.lblコース.TabIndex = 4;
            this.lblコース.Text = "コース";
            // 
            // frmマスタ小科目
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 325);
            this.Controls.Add(this.lblコース);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxコース);
            this.Name = "frmマスタ小科目";
            this.Text = "frmマスタ小科目";
            this.Load += new System.EventHandler(this.frmマスタ小科目_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxコース;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblコース;
    }
}