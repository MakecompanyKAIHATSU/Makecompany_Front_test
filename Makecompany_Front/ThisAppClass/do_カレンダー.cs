using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Configuration;
using System.IO;

namespace Makecompany.Career
{

    class do_カレンダー
    {

        private class clsカレンダーview　//mはメンバーのm
        {
            public string m講師名 { get; set; } 
            public string mコース名 { get; set; } 
            public string mクラス名 { get; set; } 
            public DateTime m実施日 { get; set; } 
            public List<string> m実施校 { get; set; }
            public List<string> m内容 { get; set; }
            public List<string> mテキスト情報 { get; set; }
            public List<string> m備考 { get; set; }
        }

        //テンプレートファイル        
        string strテンプレートファイルパス ;
        string sテンプレートシート名 ;
        const string sName = "カレンダー";

        //出力フォルダ
        string str出力先フォルダパス;　

        private List<clsカレンダーview> lstカレンダーデータ;


        /*
         * コンストラクタ
         */
        //引数なしコンストラクタは作らない方向で
        public do_カレンダー(string テンプレートファイル,string 出力先フォルダパス)
        {
            strテンプレートファイルパス = テンプレートファイル;
            str出力先フォルダパス = 出力先フォルダパス;
        }
        

        public void CreateXlsx(string str講師名)
        { 
            
        }

        public void CreateXlsx()
        {
            //講師、大科目順（日程）、授業内容を取得する
            var c大科目順 = new Makecompany_Front.ThisAppClass.cls大科目順();
            var c講師 = new Makecompany_Front.ThisAppClass.cls講師();
            var c内容 = new Makecompany_Front.ThisAppClass.clsテーブル_内容();

            

        }

        private void CreateXlsxPDFCommon(List<clsカレンダーview> hカレンダーデータList)
        {

            //データ処理



            //講師名リストを作成（講師名のリストを作りたいだけなのでdicにする必要ないけど件数を保存するのに好都合なので）
            Dictionary<string, int> dic講師名 = new Dictionary<string, int>() ;
            foreach (var a in hカレンダーデータList)
            {
                if (!dic講師名.ContainsKey(a.m講師名))
                {
                    //まだ存在しないので一件目
                    dic講師名.Add(a.m講師名, 1);
                }
                else
                {
                    //存在するので２件目以降としてカウントアップ
                    dic講師名[a.m講師名]++ ;
                }
                 
            }


            //テンプレートファイルをリネームコピーして開く
            //フォーマットコピー
            foreach(var a in dic講師名)
            {
                //講師名を使用したファイルパスを作成する
                string str講師毎ファイルパス = str出力先フォルダパス + "\\" + a.Key + ".xlsx"; 
                //講師名分コピーする
                System.IO.File.Copy(strテンプレートファイルパス, str出力先フォルダパス, true);
            }
            

            //シート名変更


            //指定月カレンダー作成  
            int int年 = hカレンダーデータList[0].m実施日.Date.Year;
            int int月 = hカレンダーデータList[0].m実施日.Date.Month;

            string[] ss = Makecompany.Career._datatime._func.getCalenderData(int年, int月, 42);
            

            


            //保存


            //pdf化


            // カレントディレクトリを取得する
            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();


            //出力フォルダ
            string outDir = stCurrentDir + "\\outpath\\RDK.xlsx";



            //var outputFile = new System.IO.FileInfo(@outpath);

            /*
            using (var book = new ExcelPackage(outputFile))
            {


                //フォーマットコピー
                //System.IO.File.Copy(path, outpath, true);

                // エクセルファイルの読み込み、編集
                var sheet = book.Workbook.Worksheets["6_1"];

                ////開校日の設定

                sheet.Select();


                book.Save();;


            }

            var c = new doExcel(@outpath);
            c.View("6_1");
            */
        }
    }

}

