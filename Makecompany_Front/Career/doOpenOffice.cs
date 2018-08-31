using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;           

namespace Makecompany.Career
{
    class doOpenOffice
    {
        public doOpenOffice() { }


        public void FileToPDF(string inExcelFilePath, string outPDFPath)
        {
            //エクセルファイルを取得
            var eFile = new System.IO.FileInfo(inExcelFilePath);

            //エクセルファイル処理開始
            using (var book = new ExcelPackage(eFile))
            {

                //book. 
            }
        }
    }


}
