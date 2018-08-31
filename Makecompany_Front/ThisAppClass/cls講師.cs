using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Makecompany_Front.ThisAppClass
{
    class cls講師
    {
        public struct _目視用講師
        {
            public const int 講師番号 = 1;
            public const int 苗字 = 2;
            public const int 名前 = 3;
            public const int 空白 = 4;
            public const int みょうじ = 5;
            public const int なまえ = 6;
            public const int 生年月日 = 7;
            public const int 日 = 8;
            public const int 月 = 9;
            public const int 火 = 10;
            public const int 水 = 11;
            public const int 木 = 12;
            public const int 金 = 13;
            public const int 土 = 14;
            public const int 表示用 = 15;
            public const int 講師名 = 16;
        }

        //メンバー一覧
        public string 講師番号 { get; set; }
        public string 苗字 { get; set; }
        public string 名前 { get; set; }
        public string 空白 { get; set; }
        public string みょうじ { get; set; }
        public string なまえ { get; set; }
        public DateTime 生年月日 { get; set; }
        public bool 日  { get; set; }
        public bool 月 { get; set; }
        public bool 火 { get; set; }
        public bool 水 { get; set; }
        public bool 木 { get; set; }
        public bool 金 { get; set; }
        public bool 土 { get; set; }
        public bool 表示用 { get; set; }
        public bool 講師名 { get; set; }

        public string m_テーブル名 = "マスタ_講師";

        public cls講師() { }

        public void m_createListview(ListView h_講師)
        {

            var c = new Makecompany.Career.doListView(h_講師);
            c.m_データベースからデータを取得してlistviewにセット(m_テーブル名); 
        }





    }
}
