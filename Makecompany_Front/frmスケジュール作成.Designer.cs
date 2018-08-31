namespace Makecompany_Front
{
    partial class frmスケジュール作成
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.cbxクラス番号 = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.itemToTeacher4 = new Makecompany_Front.Usercontrol.ItemToTeacher();
            this.lst教室 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.itemToTeacher3 = new Makecompany_Front.Usercontrol.ItemToTeacher();
            this.itemToTeacher2 = new Makecompany_Front.Usercontrol.ItemToTeacher();
            this.itemToTeacher1 = new Makecompany_Front.Usercontrol.ItemToTeacher();
            this.lbl_Index = new System.Windows.Forms.Label();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.txtクラス名 = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.monthLabel3 = new Makecompany_Front.Usercontrol.MonthLabel();
            this.monthLabel4 = new Makecompany_Front.Usercontrol.MonthLabel();
            this.viewMonth3 = new Makecompany.viewMonth();
            this.viewMonth4 = new Makecompany.viewMonth();
            this.monthLabel1 = new Makecompany_Front.Usercontrol.MonthLabel();
            this.monthLabel2 = new Makecompany_Front.Usercontrol.MonthLabel();
            this.viewMonth2 = new Makecompany.viewMonth();
            this.viewMonth1 = new Makecompany.viewMonth();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.lv_目視用_キャリコン = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.lv_目視用_HW来所日 = new System.Windows.Forms.ListView();
            this.lv_目視用_講師 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lv_目視用_クラス = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_目視用_教室 = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.lv_全部 = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(6, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(481, 250);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // cbxクラス番号
            // 
            this.cbxクラス番号.FormattingEnabled = true;
            this.cbxクラス番号.Location = new System.Drawing.Point(7, 6);
            this.cbxクラス番号.Name = "cbxクラス番号";
            this.cbxクラス番号.Size = new System.Drawing.Size(155, 20);
            this.cbxクラス番号.TabIndex = 6;
            this.cbxクラス番号.SelectedIndexChanged += new System.EventHandler(this.cbxクラス名_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.itemToTeacher4);
            this.tabPage1.Controls.Add(this.lst教室);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.itemToTeacher3);
            this.tabPage1.Controls.Add(this.itemToTeacher2);
            this.tabPage1.Controls.Add(this.itemToTeacher1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(473, 172);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "授業一覧";
            // 
            // itemToTeacher4
            // 
            this.itemToTeacher4.Location = new System.Drawing.Point(6, 113);
            this.itemToTeacher4.Name = "itemToTeacher4";
            this.itemToTeacher4.Size = new System.Drawing.Size(363, 40);
            this.itemToTeacher4.TabIndex = 17;
            this.itemToTeacher4.Teacher_Changed += new Makecompany_Front.Usercontrol.ItemToTeacher.comboselectedHandler(this.itemToTeacher4_Teacher_Changed);
            // 
            // lst教室
            // 
            this.lst教室.FormattingEnabled = true;
            this.lst教室.ItemHeight = 12;
            this.lst教室.Location = new System.Drawing.Point(374, 34);
            this.lst教室.Name = "lst教室";
            this.lst教室.Size = new System.Drawing.Size(63, 76);
            this.lst教室.TabIndex = 16;
            this.lst教室.SelectedIndexChanged += new System.EventHandler(this.lst教室_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.button1.Location = new System.Drawing.Point(373, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 22);
            this.button1.TabIndex = 15;
            this.button1.Text = "教室";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // itemToTeacher3
            // 
            this.itemToTeacher3.Location = new System.Drawing.Point(6, 77);
            this.itemToTeacher3.Name = "itemToTeacher3";
            this.itemToTeacher3.Size = new System.Drawing.Size(363, 40);
            this.itemToTeacher3.TabIndex = 14;
            this.itemToTeacher3.Teacher_Changed += new Makecompany_Front.Usercontrol.ItemToTeacher.comboselectedHandler(this.itemToTeacher3_Teacher_Changed);
            // 
            // itemToTeacher2
            // 
            this.itemToTeacher2.Location = new System.Drawing.Point(6, 41);
            this.itemToTeacher2.Name = "itemToTeacher2";
            this.itemToTeacher2.Size = new System.Drawing.Size(363, 40);
            this.itemToTeacher2.TabIndex = 13;
            this.itemToTeacher2.Teacher_Changed += new Makecompany_Front.Usercontrol.ItemToTeacher.comboselectedHandler(this.itemToTeacher2_Teacher_Changed);
            // 
            // itemToTeacher1
            // 
            this.itemToTeacher1.Location = new System.Drawing.Point(6, 6);
            this.itemToTeacher1.Name = "itemToTeacher1";
            this.itemToTeacher1.Size = new System.Drawing.Size(363, 40);
            this.itemToTeacher1.TabIndex = 12;
            this.itemToTeacher1.Teacher_Changed += new Makecompany_Front.Usercontrol.ItemToTeacher.comboselectedHandler(this.itemToTeacher1_Teacher_Changed);
            // 
            // lbl_Index
            // 
            this.lbl_Index.AutoSize = true;
            this.lbl_Index.Location = new System.Drawing.Point(455, 12);
            this.lbl_Index.Name = "lbl_Index";
            this.lbl_Index.Size = new System.Drawing.Size(48, 12);
            this.lbl_Index.TabIndex = 13;
            this.lbl_Index.Text = "lbl_Index";
            // 
            // lbl_Date
            // 
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Location = new System.Drawing.Point(413, 12);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(45, 12);
            this.lbl_Date.TabIndex = 14;
            this.lbl_Date.Text = "lbl_Date";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1140, 526);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.txtクラス名);
            this.tabPage8.Controls.Add(this.tabControl2);
            this.tabPage8.Controls.Add(this.monthLabel3);
            this.tabPage8.Controls.Add(this.monthLabel4);
            this.tabPage8.Controls.Add(this.cbxクラス番号);
            this.tabPage8.Controls.Add(this.lbl_Index);
            this.tabPage8.Controls.Add(this.viewMonth3);
            this.tabPage8.Controls.Add(this.viewMonth4);
            this.tabPage8.Controls.Add(this.lbl_Date);
            this.tabPage8.Controls.Add(this.monthLabel1);
            this.tabPage8.Controls.Add(this.monthLabel2);
            this.tabPage8.Controls.Add(this.listView1);
            this.tabPage8.Controls.Add(this.viewMonth2);
            this.tabPage8.Controls.Add(this.viewMonth1);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1132, 500);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // txtクラス名
            // 
            this.txtクラス名.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtクラス名.Location = new System.Drawing.Point(167, 3);
            this.txtクラス名.Name = "txtクラス名";
            this.txtクラス名.Size = new System.Drawing.Size(240, 25);
            this.txtクラス名.TabIndex = 16;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Location = new System.Drawing.Point(7, 296);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(481, 198);
            this.tabControl2.TabIndex = 15;
            // 
            // monthLabel3
            // 
            this.monthLabel3.Location = new System.Drawing.Point(520, 251);
            this.monthLabel3.Name = "monthLabel3";
            this.monthLabel3.Size = new System.Drawing.Size(202, 18);
            this.monthLabel3.TabIndex = 9;
            // 
            // monthLabel4
            // 
            this.monthLabel4.Location = new System.Drawing.Point(824, 251);
            this.monthLabel4.Name = "monthLabel4";
            this.monthLabel4.Size = new System.Drawing.Size(202, 18);
            this.monthLabel4.TabIndex = 10;
            // 
            // viewMonth3
            // 
            this.viewMonth3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewMonth3.Location = new System.Drawing.Point(520, 271);
            this.viewMonth3.Name = "viewMonth3";
            this.viewMonth3.Size = new System.Drawing.Size(269, 212);
            this.viewMonth3.TabIndex = 4;
            this.viewMonth3.ClickviewDayEvent += new Makecompany.viewMonth.viewDayClickofMonthHandler(this.viewMonth3_ClickviewDayEvent);
            // 
            // viewMonth4
            // 
            this.viewMonth4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewMonth4.Location = new System.Drawing.Point(824, 271);
            this.viewMonth4.Name = "viewMonth4";
            this.viewMonth4.Size = new System.Drawing.Size(269, 212);
            this.viewMonth4.TabIndex = 5;
            this.viewMonth4.ClickviewDayEvent += new Makecompany.viewMonth.viewDayClickofMonthHandler(this.viewMonth4_ClickviewDayEvent);
            // 
            // monthLabel1
            // 
            this.monthLabel1.Location = new System.Drawing.Point(520, 6);
            this.monthLabel1.Name = "monthLabel1";
            this.monthLabel1.Size = new System.Drawing.Size(202, 18);
            this.monthLabel1.TabIndex = 7;
            // 
            // monthLabel2
            // 
            this.monthLabel2.Location = new System.Drawing.Point(824, 6);
            this.monthLabel2.Name = "monthLabel2";
            this.monthLabel2.Size = new System.Drawing.Size(202, 18);
            this.monthLabel2.TabIndex = 8;
            // 
            // viewMonth2
            // 
            this.viewMonth2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewMonth2.Location = new System.Drawing.Point(824, 26);
            this.viewMonth2.Name = "viewMonth2";
            this.viewMonth2.Size = new System.Drawing.Size(269, 219);
            this.viewMonth2.TabIndex = 3;
            this.viewMonth2.ClickviewDayEvent += new Makecompany.viewMonth.viewDayClickofMonthHandler(this.viewMonth2_ClickviewDayEvent);
            // 
            // viewMonth1
            // 
            this.viewMonth1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewMonth1.Location = new System.Drawing.Point(520, 26);
            this.viewMonth1.Name = "viewMonth1";
            this.viewMonth1.Size = new System.Drawing.Size(269, 219);
            this.viewMonth1.TabIndex = 2;
            this.viewMonth1.ClickviewDayEvent += new Makecompany.viewMonth.viewDayClickofMonthHandler(this.viewMonth1_ClickviewDayEvent);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.label5);
            this.tabPage9.Controls.Add(this.lv_目視用_キャリコン);
            this.tabPage9.Controls.Add(this.label4);
            this.tabPage9.Controls.Add(this.lv_目視用_HW来所日);
            this.tabPage9.Controls.Add(this.lv_目視用_講師);
            this.tabPage9.Controls.Add(this.label3);
            this.tabPage9.Controls.Add(this.label2);
            this.tabPage9.Controls.Add(this.lv_目視用_クラス);
            this.tabPage9.Controls.Add(this.label1);
            this.tabPage9.Controls.Add(this.lv_目視用_教室);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1132, 500);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "連想化";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(560, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "キャリコン";
            // 
            // lv_目視用_キャリコン
            // 
            this.lv_目視用_キャリコン.Location = new System.Drawing.Point(562, 175);
            this.lv_目視用_キャリコン.Name = "lv_目視用_キャリコン";
            this.lv_目視用_キャリコン.Size = new System.Drawing.Size(253, 111);
            this.lv_目視用_キャリコン.TabIndex = 10;
            this.lv_目視用_キャリコン.UseCompatibleStateImageBehavior = false;
            this.lv_目視用_キャリコン.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "HW来所日";
            // 
            // lv_目視用_HW来所日
            // 
            this.lv_目視用_HW来所日.Location = new System.Drawing.Point(274, 175);
            this.lv_目視用_HW来所日.Name = "lv_目視用_HW来所日";
            this.lv_目視用_HW来所日.Size = new System.Drawing.Size(253, 111);
            this.lv_目視用_HW来所日.TabIndex = 8;
            this.lv_目視用_HW来所日.UseCompatibleStateImageBehavior = false;
            this.lv_目視用_HW来所日.View = System.Windows.Forms.View.Details;
            // 
            // lv_目視用_講師
            // 
            this.lv_目視用_講師.Location = new System.Drawing.Point(6, 175);
            this.lv_目視用_講師.Name = "lv_目視用_講師";
            this.lv_目視用_講師.Size = new System.Drawing.Size(253, 111);
            this.lv_目視用_講師.TabIndex = 7;
            this.lv_目視用_講師.UseCompatibleStateImageBehavior = false;
            this.lv_目視用_講師.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "講師";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "クラス情報";
            // 
            // lv_目視用_クラス
            // 
            this.lv_目視用_クラス.Location = new System.Drawing.Point(6, 28);
            this.lv_目視用_クラス.Name = "lv_目視用_クラス";
            this.lv_目視用_クラス.Size = new System.Drawing.Size(560, 111);
            this.lv_目視用_クラス.TabIndex = 4;
            this.lv_目視用_クラス.UseCompatibleStateImageBehavior = false;
            this.lv_目視用_クラス.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "教室";
            // 
            // lv_目視用_教室
            // 
            this.lv_目視用_教室.FullRowSelect = true;
            this.lv_目視用_教室.Location = new System.Drawing.Point(580, 28);
            this.lv_目視用_教室.Name = "lv_目視用_教室";
            this.lv_目視用_教室.Size = new System.Drawing.Size(296, 111);
            this.lv_目視用_教室.TabIndex = 2;
            this.lv_目視用_教室.UseCompatibleStateImageBehavior = false;
            this.lv_目視用_教室.View = System.Windows.Forms.View.Details;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.lv_全部);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1132, 500);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(707, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // lv_全部
            // 
            this.lv_全部.Location = new System.Drawing.Point(32, 20);
            this.lv_全部.Name = "lv_全部";
            this.lv_全部.Size = new System.Drawing.Size(667, 169);
            this.lv_全部.TabIndex = 0;
            this.lv_全部.UseCompatibleStateImageBehavior = false;
            this.lv_全部.View = System.Windows.Forms.View.Details;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(583, 535);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 48);
            this.button3.TabIndex = 2;
            this.button3.Text = "6号出力";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1020, 535);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 45);
            this.button4.TabIndex = 16;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(689, 534);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 48);
            this.button5.TabIndex = 17;
            this.button5.Text = "7号出力";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1201, 285);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 45);
            this.button6.TabIndex = 18;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // frmスケジュール作成
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 592);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmスケジュール作成";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmスケジュール作成_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private Makecompany.viewMonth viewMonth1;
        private Makecompany.viewMonth viewMonth2;
        private Makecompany.viewMonth viewMonth3;
        private Makecompany.viewMonth viewMonth4;
        private System.Windows.Forms.ComboBox cbxクラス番号;
        private Usercontrol.MonthLabel monthLabel1;
        private Usercontrol.MonthLabel monthLabel2;
        private Usercontrol.MonthLabel monthLabel3;
        private Usercontrol.MonthLabel monthLabel4;
        private System.Windows.Forms.TabPage tabPage1;
        private Usercontrol.ItemToTeacher itemToTeacher1;
        private Usercontrol.ItemToTeacher itemToTeacher3;
        private Usercontrol.ItemToTeacher itemToTeacher2;
        private System.Windows.Forms.Label lbl_Index;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lst教室;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.ListView lv_目視用_教室;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lv_目視用_クラス;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lv_全部;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lv_目視用_講師;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lv_目視用_HW来所日;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lv_目視用_キャリコン;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtクラス名;
        private Usercontrol.ItemToTeacher itemToTeacher4;
        private System.Windows.Forms.Button button6;
    }
}

