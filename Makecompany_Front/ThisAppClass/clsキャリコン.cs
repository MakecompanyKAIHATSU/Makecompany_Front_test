using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makecompany_Front.ThisAppClass
{
    public struct _目視用キャリコン
    {
        public const int ID = Makecompany.Career._リストビュー.subitemstartindex;
        public const int クラス番号 = 2;
        public const int コース番号 = 3;
        public const int 番号 = 4;
        public const int 開始日 = 5;
        public const int 終了日 = 6;
    }


    class clsキャリコン
    {
        private const string m_テーブル名 = "データ_キャリコン";


        public List<Dictionary<string, object>> GetDataListDictionary()
        {
            var c = new thisCommon();

            using (var sql = c.m_接続済みSQLクラス提供())
            {
                var lst = sql.Select("SELECT * FROM " + m_テーブル名);

                return lst;
            }
        }

        public void m_createListview(System.Windows.Forms.ListView h_List)
        {

            var c = new Makecompany.Career.doListView(h_List);
            c.m_データベースからデータを取得してlistviewにセット(m_テーブル名);
        }

    }

}
