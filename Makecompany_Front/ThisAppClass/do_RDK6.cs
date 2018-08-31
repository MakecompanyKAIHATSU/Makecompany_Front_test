using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Text.RegularExpressions;




namespace Makecompany.Career
{

    namespace RDK6
    {
        struct _format
        {
            public string ExecDate { get; set; }
            public string EdabanName { get; set; }
            public string TeacherName { get; set; }
            public string LargeSubjectNo { get; set; }
            public string SeisekiKousaTou { get; set; }
            public string LiTestLiItemNo { get; set; }
            public string KuniTime { get; set; }
        }

        struct _行数
        {
            //RDK_6の様式に合わせて各行数を設定すること
            public const int LittleSubjectString = 0;
            public const int LargeSubjectNo = LittleSubjectString + 11;
            public const int SeisekiKousaTou = LargeSubjectNo + 1;
            public const int LiTestLiItemNo = SeisekiKousaTou + 1;
            public const int TeacherName = LiTestLiItemNo + 1;
            public const int Bikou = TeacherName + 3;

        }


        class _キャリコンRowValue
        {
            public string 開始日 { get; set; }
            public string 終了日 { get; set; }
        }


        class _RowValue
        {
            public string ClassNo { get; set; }
            public string ClassName { get; set; }
            public string CourseNo { get; set; }
            public string CourseName { get; set; }
            public string LargeSubjectNo { get; set; }
            public string LargeSubjectNoSub { get; set; }
            public string LittleSubjectNo { get; set; }
            public string LittleSubjectName { get; set; }
            public string Edaban { get; set; }
            public string EdabanName { get; set; }
            public string ItemNo { get; set; }
            public string ItemName { get; set; }
            public string TeacherNo { get; set; }
            public string TeacherName { get; set; }
            public string ExecDate { get; set; }
            public string RoomNo { get; set; }
            public string RoomName { get; set; }
            public string LittleTestDate { get; set; }
            public int KuniTime { get; set; }

        }
    }

    class do_RDK6
    {

        const string sSeisekikousaMark = "○";
        const string sSyuryouHyoukaMark = "◎";


        const string sFormatSheetName = "【様式】国6の1";
        const string sName = "6-1";

        const string StartYearCell = "D1";
        const string StartMonthCell = "G1";
        const string StartdayCell = "I1";

        const string KikanAStartCell = "D10";
        const string KikanBStartCell = "D33";
        const string KikanCStartCell = "D56";
        const string KikanDStartCell = "D79";


        const string _キャリコン開始cell = "L102";
        const string _キャリコン終了cell = "T102";

        const string _HW来所日開始cell = "L106";


        //開校日
        public DateTime  StartYMD;


        List<RDK6._RowValue> _rowvalues;
        List<RDK6._キャリコンRowValue> _キャリコンrowvalues;



        //コンストラクタ
        public do_RDK6(List<RDK6._RowValue> _in,List<RDK6._キャリコンRowValue> _in2)
        {
            _rowvalues = _in;
            _キャリコンrowvalues = _in2;
        }

        
        /*--------------------------------------------------------------------------------------------------------
        'View
        '作成者:松本稔
        '作成日:2017/7/25
        '動作説明:
        '結果:
        '補足:
        --------------------------------------------------------------------------------------------------------*/
        public void  View()
        {

            int num =0;

            
            // カレントディレクトリを取得する
            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
            string path = stCurrentDir + "\\Format\\RDK.xlsx";
            string outpath = stCurrentDir + "\\outpath\\RDK.xlsx";

            //フォーマットコピー
            System.IO.File.Copy(path, outpath,true);

            var outputFile = new System.IO.FileInfo(@outpath);
            //var book = new ExcelPackage(outputFile);
            //book.Save();

            using (var book = new ExcelPackage(outputFile))
            {
                // エクセルファイルの読み込み、編集
                var sheet = book.Workbook.Worksheets["6_1"];

                ////開校日の設定
                sheet.Cells[StartYearCell].Value = new DateTime(StartYMD.Year,StartYMD.Month , StartYMD.Day);


                //期間A
                num = SetOneMonthInfo(sheet, KikanAStartCell, 0);
                //期間B
                num = SetOneMonthInfo(sheet, KikanBStartCell, num);
                //期間C
                num = SetOneMonthInfo(sheet, KikanCStartCell, num);
                //期間D
                num = SetOneMonthInfo(sheet, KikanDStartCell, num);

                //キャリコンデータ処理
                pキャリコンデータ処理(sheet);

                sheet.Select();


                book.Save(); 
                //System.IO.File.Open(outputFile, System.IO.FileMode.Open);


            }

            var c = new doExcel(@outpath);
            c.View("6_1"); 
            
        }


        private int SetOneMonthInfo(ExcelWorksheet h_シート, string h_Range名, int num)
        {
            var h_スタートcell = h_シート.Cells[h_Range名];
            int h_スタートrow = GetRowIndex(h_Range名);
            int h_スタートcolumn = GetColumnIndex(h_Range名);


            DateTime dt = new DateTime(StartYMD.Year , StartYMD.Month , StartYMD.Day);
            dt = dt.AddMonths(num);


            //データ集約
            var fds = CreateDataForFormat();


            //データクリア(h_スタートcolumnの場所=1日なので、+31の後に-1しています）
            for (int i = h_スタートcolumn; i <= h_スタートcolumn + 31 - 1; i++)
            {
                h_シート.Cells[h_スタートrow - 2, i].Value = ""; //年月日
                h_シート.Cells[h_スタートrow - 1, i].Value = ""; //曜日

                h_シート.Cells[h_スタートrow + RDK6._行数.LittleSubjectString, i].Value = ""; //大科目（内容）
                h_シート.Cells[h_スタートrow + RDK6._行数.LargeSubjectNo, i].Value = "";  //大科目（番号）
                h_シート.Cells[h_スタートrow + RDK6._行数.SeisekiKousaTou, i].Value = "";  //成績考査等
                h_シート.Cells[h_スタートrow + RDK6._行数.LiTestLiItemNo, i].Value = "";  //成績考査(実施科目）
                h_シート.Cells[h_スタートrow + RDK6._行数.TeacherName, i].Value = ""; //講師
                h_シート.Cells[h_スタートrow + RDK6._行数.Bikou, i].Value = "";   //備考
            }



            //先に日付をセット--------------------------------
            int h_day = 1;
            int h_endday = Makecompany.Career._datatime._func.DaysInMonth(dt);

            //(h_スタートcolumnの場所 = 1日なので、+enddayの後に - 1しています）
            for (int i = h_スタートcolumn; i <= h_スタートcolumn + h_endday - 1; i++)
            {
                h_シート.Cells[h_スタートrow - 2, i].Value = new DateTime(dt.Year, dt.Month, h_day);
                h_シート.Cells[h_スタートrow - 1, i].Value = new DateTime(dt.Year, dt.Month, h_day);
                h_day++;
            }
            //----------------------------------------------------


            //    '作っておいた様式用データを使って
            foreach (var fd in fds)
            {
                //セルを1日～31日ぶん(0～30になるように）
                for (int j = 0; j < 31; j++)
                {
                    //シートにあらかじめセットした日付を日付型変数に格納（日付突合せのため形式統一）
                    DateTime シート側日付;
                    if (!DateTime.TryParse(h_シート.Cells[h_スタートrow, h_スタートcolumn].Offset(-2, j).Text,out シート側日付))
                    { シート側日付 = new DateTime(9999,1,1);}

                    //データがわの日付を日付型変数に格納
                    var データ側日付 = DateTime.Parse(fd.ExecDate);

                    //等しい場合=0（真偽ではないので注意）
                    if (DateTime.Compare(シート側日付, データ側日付) == 0)  
                    {
                        //大科目（内容）
                        h_シート.Cells[h_スタートrow + RDK6._行数.LittleSubjectString, h_スタートcolumn + j].Value = fd.EdabanName;

                        //大科目（番号）→大科目（内容）の次
                        h_シート.Cells[h_スタートrow + RDK6._行数.LargeSubjectNo , h_スタートcolumn + j].Value = fd.LargeSubjectNo;

                        //成績考査等→大科目（番号）の次
                        h_シート.Cells[h_スタートrow + RDK6._行数.SeisekiKousaTou , h_スタートcolumn + j].Value = "○";// fd.SeisekiKousaTou;

                        //成績考査(実施科目）→成績考査等の次
                        h_シート.Cells[h_スタートrow + RDK6._行数.LiTestLiItemNo , h_スタートcolumn + j].Value = fd.LiTestLiItemNo;

                        //講師名→成績考査実施科目の次
                        h_シート.Cells[h_スタートrow + RDK6._行数.TeacherName , h_スタートcolumn + j].Value = fd.TeacherName;

                        //備考→講師名の次
                        h_シート.Cells[h_スタートrow + RDK6._行数.Bikou, h_スタートcolumn + j].Value = fd.KuniTime ;

                    }

                }
            }

            return num + 1;

        }

        private List<RDK6._format> CreateDataForFormat()
        {

            List<string> uDate = new List<string>();
            List<RDK6._format> fds = new List<RDK6._format>();
            RDK6._format fd;
            bool b最初;
            int int時間 = 0;


            //まずは実施日の集約
            foreach(var r in _rowvalues)
            {
                if(!uDate.Contains(r.ExecDate))
                {
                    uDate.Add(r.ExecDate);
                }
            }

            //次に実施日で名寄せ
            for(int i = 0;i < uDate.Count;i++ )
            {

                //ある実施日Aの処理を開始する
                b最初 = true;
                var h_ひとつまえのrow = new RDK6._RowValue();

                //その実施日のデータを格納するクラス_formatの初期化と実施日の設定
                fd = new RDK6._format();
                fd.ExecDate = uDate[i];


                //以下、_rowvalues中の一行一行をサーチし、実施日Aのものをfdにまとめていく
                foreach (var row in _rowvalues)
                { 
                    //実施日Aかどうか
                    if(uDate[i] == row.ExecDate)
                    {
                        //実施日Aについての最初のデータか
                        if (b最初)
                        {
                            //その実施日中最初のデータであればそのまま
                            //枝番名？→縦書きなのに注意
                            fd.EdabanName = row.EdabanName + System.Environment.NewLine + fd.EdabanName;
                            //講師名
                            fd.TeacherName = fd.TeacherName + System.Environment.NewLine + row.TeacherName;

                            //大科目番号
                            fd.LargeSubjectNo = row.LargeSubjectNo;

                            //時間を覚える
                            int時間 = row.KuniTime;

                            //最初の処理を終了したのでfalseにする
                            b最初 = false;
  
                        }
                        else
                        {
                            //同実施日であれば大科目は必ず同じはずなので、あとは枝番名の比較
                            //違えば追記
                            //枝番名が違うか
                            if (row.EdabanName != h_ひとつまえのrow.EdabanName)
                            {
                                //枝番名（小科目名のひとつ下の名前）→縦書きなのに注意
                                fd.EdabanName = row.EdabanName + System.Environment.NewLine + fd.EdabanName;
                                fd.TeacherName = fd.TeacherName + System.Environment.NewLine + row.TeacherName;

                                //覚えていた時間を出力
                                if (int時間 != 0)
                                { fd.KuniTime += int時間.ToString() + "H" + System.Environment.NewLine ; }

                                //今の時間を覚えなおす
                                int時間 = row.KuniTime; 
                            }
                            else
                            {
                                //同一実施日でかつ同一枝番名の場合、枝番名は追加しないけど・・・
                                //時間を合算
                                int時間 += row.KuniTime;  


                                //講師名が違う場合（つまり同一科目なのに講師が途中で交代する場合）
                                if (row.TeacherName != h_ひとつまえのrow.TeacherName)
                                {
                                    //枝番名（小科目名のひとつ下の名前）→縦書きなのに注意
                                    fd.TeacherName = fd.TeacherName + System.Environment.NewLine + row.TeacherName;
                                }


                                //修了評価試験は介護の理解(2)の一部なので、その実施日に◎をつけます
                                //                                if(row.LittleSubjectNo == RDK6.SyuryouHyoukaLiNo && row.ItemNo == SyuryouHyoukaItemNo)
                                //                    fd(i).SeisekiKousaTou = sSyuryouHyoukaMark
                                //                End If
                            }

                            //介護の理解（２）の場合→修了試験◎の表示が優先なので、◎でない場合のみ、小テストがあるか判断します
                            if (fd.SeisekiKousaTou != sSyuryouHyoukaMark)
                            {
                                //成績考査があれば○
                                if (uDate[i] == row.LittleTestDate)
                                {
                                    //上書き
                                    fd.SeisekiKousaTou = sSeisekikousaMark;
                                    //くっつける
                                    fd.LiTestLiItemNo = fd.LiTestLiItemNo + System.Environment.NewLine + row.LittleSubjectNo + "(" + row.ItemNo + ")";
                                }
                            }

                        }
                    }

                    h_ひとつまえのrow = row;
                }

                //一日分のデータ作成が終わったので、締め処理

                //覚えていた時間を出力
                if (int時間 != 0)
                { fd.KuniTime += int時間.ToString() + "H"; }

                //↓続いて邪魔な改行の処理を

                //枝番名（Remove ○文字目から△文字削除　※開始は0文字目）
                fd.EdabanName = fd.EdabanName.Remove(fd.EdabanName.Length - System.Environment.NewLine.Length, System.Environment.NewLine.Length);
                
                //講師名は最初の改行が邪魔
                fd.TeacherName = fd.TeacherName.Remove(0, System.Environment.NewLine.Length);

                //出力データに追加する
                fds.Add(fd);
            }

            //        '大科目番号は上書きしているので大丈夫
            //        '成績考査も上書きしているので大丈夫
            //        '小テスト科目項目番号は確認用なので特に弄らない

            return fds;

        }


        private void pキャリコンデータ処理(ExcelWorksheet h_シート)
        {

            int キャリコン開始cellrow = GetRowIndex(_キャリコン開始cell);
            int キャリコン開始cellcol = GetColumnIndex(_キャリコン開始cell);

            int キャリコン終了cellrow = GetRowIndex(_キャリコン終了cell);
            int キャリコン終了cellcol = GetColumnIndex(_キャリコン終了cell);

            int i=0;

            foreach (var a in _キャリコンrowvalues)
            {
                h_シート.Cells[キャリコン開始cellrow + i, キャリコン開始cellcol].Value  = a.開始日;
                h_シート.Cells[キャリコン終了cellrow + i, キャリコン終了cellcol].Value = a.終了日;
                i++;
            }
        }


        // https://www.p-space.jp/index.php/development/open-xml-sdk/81-openxmlsdk5

        public static int GetColumnIndex(string cellName)
        {
            string column_name = GetColumnName(cellName).ToUpper();
            const string colChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int column_index = 0;
            for (int i = column_name.Length; i > 0; i--)
            {
                column_index += (int)((colChars.IndexOf(column_name.Substring(column_name.Length - i, 1)) + 1) * Math.Pow(26, i - 1));
            }
            return column_index;
        }

        //https://msdn.microsoft.com/ja-jp/library/office/Cc822064.aspx
        // Given a cell name, parses the specified cell to get the row index.
        public static int GetRowIndex(string cellName)
        {
            // Create a regular expression to match the row index portion the cell name.
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(cellName);
            return int.Parse(match.Value);
        }

        //https://msdn.microsoft.com/ja-jp/library/office/Cc822064.aspx
        public static string GetColumnName(string cellName)
        {
            Match match = Regex.Match(cellName, "[A-Za-z]+");
            return match.Value;
        }

    }
}
