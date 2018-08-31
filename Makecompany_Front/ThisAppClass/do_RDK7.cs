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
using Makecompany.Career;


namespace Makecompany_Front.ThisAppClass
{
    namespace RDK7
    {
        struct format_
        {
            public string TeacherName { get; set; }
            public string TeacherAge { get; set; }
            public string EdaName { get; set; }
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
            public string TeacherBirthday { get; set; }
            public string KijyunDate { get; set; }
        }

    }


    class do_RDK7
    {

        const int NextRow = 10;

        const string StarNoCell = "A8";
        const string StarTeacherNameCell = "B8";
        const string StartEdabanStringCell = "E8";

        const string Start7_2TeacherNameCell = "G8";
        const string Start7_2TeacherAGECell = "O8";
        const string Start7_2EdaNameCell = "B12";

        public string ClassName_;
        public string CourseName_;
        private List<RDK7._RowValue> _rowvalues;



        //--------------------------------------------------------------------------------------------------------
        //コンストラクタ
        //作成者:松本稔
        //作成日:2017/9/2
        //動作説明:
        //結果:
        //補足:
        //--------------------------------------------------------------------------------------------------------
        public do_RDK7(List<RDK7._RowValue> _in)
        { 
                _rowvalues = _in;
        }

        //--------------------------------------------------------------------------------------------------------
        //View
        //作成者:松本稔
        //作成日:2015/12/19
        //動作説明:
        //結果:
        //補足:
        //--------------------------------------------------------------------------------------------------------
        public void View()
        {
            //データをフォーマットに整頓
            List<RDK7.format_> fds = CreateDataForFormat();

            //フォーマットをもとに出力
            Create_RDK_7(fds);
        }



        private void Create_RDK_7(List<RDK7.format_> _infds)
        {
            int count = 0;

            // カレントディレクトリを取得する
            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
            string path = stCurrentDir + "\\Format\\RDK7.xlsx";
            string outpath = stCurrentDir + "\\outpath\\RDK7.xlsx";


            //フォーマットコピー
            System.IO.File.Copy(path, outpath, true);

            //ファイルがっちり
            var outputFile = new System.IO.FileInfo(@outpath);

            //
            using (var book = new ExcelPackage(outputFile))
            {

                //7_1作成処理
                var sheet = book.Workbook.Worksheets["7_1"];

                //
                foreach (var fd in _infds)
                {
                    if (fd.EdaName != "")
                    {
                        count = count + 1;
                        
                        //
                        sheet.Cells[GetRowIndex(StarNoCell) + NextRow * (count - 1), GetColumnIndex(StarNoCell)].Value = count;

                        sheet.Cells[GetRowIndex(StarTeacherNameCell) + NextRow * (count - 1), GetColumnIndex(StarTeacherNameCell)].Value = fd.TeacherName;
                        sheet.Cells[GetRowIndex(StartEdabanStringCell) + NextRow * (count - 1), GetColumnIndex(StartEdabanStringCell)].Value = fd.EdaName;
                    }
                }


                //7_2作成処理
                foreach(var fd in _infds)
                {
                    //リネームコピーメソッドが普通に用意されている嬉しみ
                    string newsheetname = "7_2" + fd.TeacherName;
                    book.Workbook.Worksheets.Copy("7_2", newsheetname);

                    sheet = book.Workbook.Worksheets[newsheetname];

                    //Start7_2TeacherNameCell Start7_2TeacherAGECell Start7_2EdaNameCell
                    sheet.Cells[Start7_2TeacherNameCell].Value = fd.TeacherName ;
                    sheet.Cells[Start7_2TeacherAGECell].Value = fd.TeacherAge ;
                    sheet.Cells[Start7_2EdaNameCell].Value = fd.EdaName;
                }



                sheet.Select();
                book.Save();
            }

            var c = new doExcel(@outpath);
            c.View("7_1");

        }


        private List<RDK7.format_> CreateDataForFormat()
        {
            //初期宣言
            List<RDK7.format_> fds = new List<RDK7.format_>();
            RDK7.format_ fd;
            string str = "";


            //講師ループ用
            List<string> list = new List<string>();


            //講師名をまとめる
            foreach (var row in _rowvalues)
            {
                str = row.TeacherName;

                if (!list.Contains(str))
                {
                    list.Add(str);
                }
            }


            //次に講師ごとのデータ作成
            foreach (var tname in list)
            {
                fd = new RDK7.format_();
                List<string> Edanames = new List<string>();
                string s = "";

                //講師名設定
                fd.TeacherName = tname;

                //再度講師名でループをして、該当する講師名の枝番名をまとめる
                foreach (var row in _rowvalues)
                {
                    //該当講師の場合で、
                    if (row.TeacherName == fd.TeacherName)
                    {
                        //まだ未追加の枝番名の場合、
                        if (!Edanames.Contains(row.EdabanName))
                        { 
                            //追加
                            Edanames.Add(row.EdabanName);
                        }
                    }
                }

                //枝番を改行付き文字列にする
                foreach (var edaname in Edanames)
                {
                    s = s + edaname + Environment.NewLine;
                }

                //枝番文字列を設定
                fd.EdaName = s;


                ////再度講師名でループをして、基準日と誕生日から講師年齢を計算する
                foreach (var row in _rowvalues)
                {
                    //該当講師の場合
                    if (row.TeacherName == fd.TeacherName)
                    {
                        //誕生日
                        DateTime 誕生日;
                        DateTime 基準日;
                        int 年齢 = 0;

                        //変換かけてみて、変換出来たら計算（例えば未設定の場合誕生日なんてありませんから計算不能となります）
                        if(DateTime.TryParse(row.TeacherBirthday ,out 誕生日) && DateTime.TryParse(row.KijyunDate, out 基準日))
                        {
                            //年齢計算
                            年齢 = Makecompany.Career._datatime._func.GetAge(誕生日, 基準日);   
                            
                        }

                        //年齢は一回計算すればいいのでループを抜ける
                        fd.TeacherAge = 年齢.ToString();
                        break;
                    }
                }


                //データ追加
                fds.Add(fd); 

            }

            //作ったフォーマットを返す
            return fds;
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
