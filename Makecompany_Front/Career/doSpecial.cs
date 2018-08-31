using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makecompany.Career;
using System.Windows.Forms;

namespace Makecompany.Career
{


    struct _リストビュー
    { public const int subitemstartindex = 1;}

    //subitemのindexは1からスタート
    struct _目視用教室
    {
        public const int 教室番号 = 2;
        public const int 教室名 = 3;
    }

    //ListView目視用全部の
    struct _目視用全部
    {
        public const int 大科目番号 = _リストビュー.subitemstartindex;
        public const int 順番 = 2;
        public const int 時間順 = 3;
        public const int クラス番号 = 4;
        public const int クラス名 = 5;
        public const int コース番号 = 6;
        public const int コース名 = 7;
        public const int 小科目番号 = 8;
        public const int 小科目名 = 9;
        public const int 枝番 = 10;
        public const int 枝番名 = 11;
        public const int 項目番号 = 12;
        public const int 項目名 = 13;
        public const int 実施日 = 14;
        public const int 教室番号 = 15;
        public const int 教室名 = 16;
        public const int 講師番号 = 17;
        public const int 講師名 = 18;
        public const int 国時間 = 19;
        public const int 県時間 = 20;
        public const int 小テスト実施日 = 21;

    }

    struct _目視用クラス
    {
        public const int クラス番号 = 2;
        public const int クラス名 = 3;
        public const int コース番号 = 4;
    }

    struct _目視用講師
    {
        public const int ID = _リストビュー.subitemstartindex;
        public const int 講師番号 = 2;
        public const int 苗字 = 3;
        public const int 名前 = 4;
        public const int 空白 = 5;
        public const int みょうじ = 6;
        public const int なまえ = 7;
        public const int 生年月日 = 8;
        public const int 日 = 9;
        public const int 月 = 10;
        public const int 火 = 11;
        public const int 水 = 12;
        public const int 木 = 13;
        public const int 金 = 14;
        public const int 土 = 15;
        public const int 表示用 = 16;
        public const int 講師名 = 17;
    }

    struct _テーブル名
    {
        public const string 順 = "データ_大科目順";
        public const string 大科目 = "データ_大科目";

    }

    struct _既定値
    {
        public const int 未定 = 0;
    }


    class doSpecial
    {
        //


        public doSpecial()
        {

        }

        public string m_講師番号から生年月日を取得(string h_講師番号, ListView h_講師)
        {
            string str生年月日 = "";
            var itemx = new ListViewItem();

            for (int i = 0; i < h_講師.Items.Count; i++)
            {
                itemx = new ListViewItem();
                itemx = h_講師.Items[i];

                if (itemx.SubItems[_目視用講師.講師番号].Text == h_講師番号)
                {
                    str生年月日 = itemx.SubItems[_目視用講師.生年月日].Text;

                }
            }

            return str生年月日;

        }

        public string m_クラス番号からクラス名を取得(string h_クラス番号, ListView h_クラス)
        {
            string strクラス名 = "";
            var itemx = new ListViewItem();

            for (int i = 0; i < h_クラス.Items.Count; i++)
            {
                itemx = new ListViewItem();
                itemx = h_クラス.Items[i];

                if (itemx.SubItems[_目視用クラス.クラス番号].Text == h_クラス番号)
                {
                     strクラス名 = itemx.SubItems[_目視用クラス.クラス名].Text;

                }
            }

            return strクラス名;

        }

        public void m_大科目順データがないクラスの大科目をマスタからコピーする(string h_クラス番号,ListView h_クラス)
        {
            var d = new doXML("");
            var c = new Makecompany.Career.SqlClient.doSQL(d.SQL_Server, d.DB_Name, d.UserID, d.Password);
            var sb = new StringBuilder();
            string s_コース番号 = ""; 

            //まずデータを検索
            var 大科目順件数 = c.Select("SELECT * FROM " + _テーブル名.順 + " WHERE クラス番号 = '" + h_クラス番号 + "'");

            //件数が0件の場合、データ_大科目から必要データを取得してデータセット
            if (大科目順件数.Count != 0)
            {
                return;
            }
            else
            {
                //クラス情報からコース番号逆引き
                var itemx = new ListViewItem();

                for(int i = 0; i <= h_クラス.Items.Count - 1; i++)
                {
                    itemx = h_クラス.Items[i];

                    if (itemx.SubItems[_目視用クラス.クラス番号].Text == h_クラス番号)
                    {
                        s_コース番号 = itemx.SubItems[_目視用クラス.コース番号].Text;
                        break;
                    }
                }

                //データ_大科目からもととなるデータを取得
                var 大科目データ = c.Select("SELECT * FROM " + _テーブル名.大科目 + " WHERE コース番号 = '" + s_コース番号 + "'");
                
                //INSERT先はデータ_大科目順
                var 大科目順テーブル列 = new List<string>(); 


                var VALUEs = new List<Dictionary<string, object>>();
                var VALUE = new Dictionary<string, object>();


                //列作成
                大科目順テーブル列.Add("クラス番号");
                大科目順テーブル列.Add("コース番号");
                大科目順テーブル列.Add("版数");
                大科目順テーブル列.Add("順番");
                大科目順テーブル列.Add("大科目番号");
                大科目順テーブル列.Add("時間順");
                大科目順テーブル列.Add("小科目番号");
                大科目順テーブル列.Add("枝番");
                大科目順テーブル列.Add("項目番号");
                大科目順テーブル列.Add("実施日");
                大科目順テーブル列.Add("担当講師No");
                大科目順テーブル列.Add("教室No");


                foreach (var data in 大科目データ)
                {

                    VALUE = new Dictionary<string, object>();

                    
                    VALUE.Add("クラス番号", h_クラス番号);
                    VALUE.Add("コース番号",s_コース番号);

                    //版数の初期値は1とします
                    VALUE.Add("版数",1);
                    //順番の初期値は大科目番号とします
                    VALUE.Add("順番", data["大科目番号"]);
                    VALUE.Add("大科目番号", data["大科目番号"]);
                    VALUE.Add("時間順", data["時間順"]);
                    VALUE.Add("小科目番号", data["小科目番号"]);
                    VALUE.Add("枝番", data["枝番"]);
                    VALUE.Add("項目番号", data["項目番号"]);
                    VALUE.Add("実施日","");
                    VALUE.Add("担当講師No", _既定値.未定 );
                    VALUE.Add("教室No", _既定値.未定);

                    VALUEs.Add(VALUE); 
                }


                //データ追加実行
                c.INSERT_INTO(_テーブル名.順, 大科目順テーブル列, VALUEs);   

            }
        }


        public void m_目視用Listviewにデータを連動させる_実施日(ListView h_全部, string h_大科目番号, string h_実施日)
        {

            var itemx = new ListViewItem();

            for (int i = 0; i < h_全部.Items.Count; i++)
            {
                itemx = new ListViewItem();
                itemx = h_全部.Items[i];

                if (itemx.SubItems[_目視用全部.大科目番号].Text == h_大科目番号)
                {
                    itemx.SubItems[_目視用全部.実施日].Text = h_実施日;
                    
                }
            }


        }

        public void m_目視用Listviewにデータを連動させる_教室(ListView h_全部, ListView h_教室, string h_大科目番号,string h_教室名)
        {

            var itemx = new ListViewItem();
            string h_教室番号 = "x";

            for(int i = 0; i <= h_教室.Items.Count-1; i++)
            {
                itemx = new ListViewItem();
                itemx = h_教室.Items[i];

                if (itemx.SubItems[_目視用教室.教室名].Text == h_教室名)
                {
                    h_教室番号 = itemx.SubItems[_目視用教室.教室番号].Text;
                    break;
                }
            }

            for (int i = 0; i < h_全部.Items.Count - 1; i++)
            {
                itemx = new ListViewItem();
                itemx = h_全部.Items[i];

                if (itemx.SubItems[_目視用全部.大科目番号].Text == h_大科目番号)
                {
                    itemx.SubItems[_目視用全部.教室番号].Text = h_教室番号  ;
                    itemx.SubItems[_目視用全部.教室名].Text = h_教室名;
                    
                }
            }


        }


        public void m_目視用Listviewにデータを連動させる_講師(ListView h_全部, ListView h_講師 
                                                            , string h_大科目番号, string h_時間順,string h_講師番号)
        {

            var itemx = new ListViewItem();
            string s_講師名 = "";

            //講師番号から講師名を取得（データ更新上は不要な処理だが目視用に使うものとする）
            for (int i = 0; i <= h_講師.Items.Count - 1; i++)
            {
                itemx = new ListViewItem();
                itemx = h_講師.Items[i];

                if (itemx.SubItems[_目視用講師.講師番号].Text == h_講師番号)
                {
                    s_講師名 = itemx.SubItems[_目視用講師.講師名].Text;
                    break;
                }
            }

            //講師番号、講師名を反映
            for (int i = 0; i < h_全部.Items.Count - 1; i++)
            {
                itemx = new ListViewItem();
                itemx = h_全部.Items[i];

                if (itemx.SubItems[_目視用全部.大科目番号].Text == h_大科目番号 
                    && itemx.SubItems[_目視用全部.時間順].Text == h_時間順)
                {
                    itemx.SubItems[_目視用全部.講師番号].Text = h_講師番号;
                    itemx.SubItems[_目視用全部.講師名].Text = s_講師名;

                }
            }


        }
    }
}
