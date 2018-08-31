using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ClosedXML.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Makecompany_Front
{
    public partial class frmデータ取り込み画面 : Form
    {
        public frmデータ取り込み画面()
        {
            InitializeComponent();

            this.textBox1.Text = "C:\\Users\\Minoru.M\\Desktop\\H30.予定 教室空確認 .xlsx";
            this.comboBox1.Text = "5"; 
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //var ofd = new OpenFileDialog();
            openFileDialog1.Filter = "メイクカンパニーデータファイル(csv,xlsx)|*.csv;*.xlsx";
            openFileDialog1.FileName = "data.xlsx";
            openFileDialog1.ShowDialog();

            string s = openFileDialog1.FileName;
            string s1 = openFileDialog1.SafeFileName;

            textBox1.Text = s;
        }


        /*
         * 取り込みボタン
         */
        private void button1_Click(object sender, EventArgs e)
        {
            //リストビュー初期化
            this.listView1.Clear();  

            //エクセルファイル（CSVかも）を取得
            var eFile = new System.IO.FileInfo(@textBox1.Text);
            var indata = new List<List<string>>();
            
            //エクセルファイル処理開始
            using (var book = new ExcelPackage(eFile))
            {
                //シート番号をコンボボックスから設定（数字前提）
                int sheetnum = int.Parse(this.comboBox1.Text);

                //そのブックのsheetnumシート目を読み込む
                var sheet = book.Workbook.Worksheets[sheetnum];
                

                //データ読み込み
                for (int i = 1; i <= sheet.Dimension.Rows; i++)
                {
                    var indatabyrows = new List<string>();

                    for (int j = 1; j <= sheet.Dimension.Columns; j++)
                    {
                        //読み込んで追加
                        if (sheet.Cells[i, j].Value == null)
                        {
                            indatabyrows.Add("");
                        }
                        else
                        {
                            string s = "";

                            //if (j == 3)
                            if (j == 4)
                            {
                                double dnum = 0;

                                if (double.TryParse(sheet.Cells[i, j].Value.ToString(),out dnum))
                                { 
                                    s = DateTime.FromOADate(dnum).ToString();
                                }
                                else
                                {
                                    s = sheet.Cells[i, j].Value.ToString();
                                }
                            }
                            else
                            {
                                s = sheet.Cells[i, j].Value.ToString();
                            }

                            indatabyrows.Add(s);

                            //string s = sheet.Cells[i, j].Value.ToString() ;
                            //if (sheet.Cells[i, j].Style.Numberformat != null)
                            //{ s = string.Format(sheet.Cells[i, j].Style.Numberformat.Format , s); };
                            //indatabyrows.Add(sheet.Cells[i, j].Value.ToString() + ":" + s);
                        }
                    }

                    //1行読み終わったので全体データ側に追加します
                    indata.Add(indatabyrows);
                }

                //シートの最大列を読み取りリストビューに列を追加
                for (int i = 0; i < sheet.Dimension.Columns; i++)
                {
                    listView1.Columns.Add("列" + i.ToString());
                }
            }

            int count = 0;

            foreach (var a in indata)
            {

                //リストアイテム(リストビューに追加するための前段階)
                ListViewItem itemx = new ListViewItem();
                itemx.Text = count.ToString() ;
                              foreach(var s in a)
                {
                    itemx.SubItems.Add(s);
                }

                listView1.Items.Add(itemx);
                count++;
                //lv_目視用_クラス.Items.Add(itemx);

            }

        }
    }
}
