using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Makecompany.Career
{
    class doExcel
    {

        string str対象excelファイル名_フルパス;

        //引数なしコンストラクタ
        public doExcel() { }

        //コンストラクタ
        public doExcel(string 対象excelファイル名_フルパス)
        {
            str対象excelファイル名_フルパス = 対象excelファイル名_フルパス;
        }


        public void PDF出力forフォルダ(string h入力フォルダパス, string h出力フォルダパス)
        {

        }

        public void PDF出力(string h入力ファイルパス,string h出力フォルダパス)
        {

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlBook = null;  

            try
            {
                xlBook = xlApp.Workbooks.Open(h入力ファイルパス);

                //--- ファイル名の拡張子を置換して、出力ファイルパスを作成
                string pdfファイル名_フルパス = h出力フォルダパス + "\\" + xlBook.Name.Replace("xlsx", "pdf");

                //--- PDFとして保存
                xlBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF
                                    , pdfファイル名_フルパス
                                    , Excel.XlFixedFormatQuality.xlQualityStandard
                                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラー : {ex.Message}");
            }
            finally
            {
                if (xlBook != null)
                {
                    Marshal.ReleaseComObject(xlBook);
                    xlBook = null;
                }

                //--- Excelを終了
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                xlApp = null;
            }

        }


        public void View(string _inSheetname)
        {
            Excel.Application excel;
            Excel.Workbook oWBook;
            excel = new Excel.Application();

            oWBook = (Excel.Workbook)(excel.Workbooks.Open(str対象excelファイル名_フルパス));
            var OSheet = (Excel.Worksheet)oWBook.Worksheets[_inSheetname];
            OSheet.Select(); 
            OSheet.Calculate();
           

            excel.WindowState = Excel.XlWindowState.xlMaximized;
            excel.Visible = true; //確認のためエクセルのウィンドウを表示する

        } 

    }
}
