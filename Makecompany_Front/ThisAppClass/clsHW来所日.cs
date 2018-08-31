using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makecompany_Front.ThisAppClass
{
    public struct _目視用HW来所日
    {
        public const int ID = Makecompany.Career._リストビュー.subitemstartindex;    
        public const int コース番号 = 2;
        public const int クラス番号 = 3;
        public const int HW来所日 = 4;
        public const int 科目名 = 5;

    }

    class clsHW来所日
    {

        private const string m_テーブル名 = "データ_HW来所日";

        /*
         * 
         */
        public clsHW来所日()
        {

        }


        public void m_createListview(System.Windows.Forms.ListView h_List)
        {

            var c = new Makecompany.Career.doListView(h_List);
            c.m_データベースからデータを取得してlistviewにセット(m_テーブル名);
        }


        public List<Dictionary<string, object>> GetDataListDictionary()
        {
            var c = new thisCommon();

            using (var sql = c.m_接続済みSQLクラス提供())
            {
                var lst = sql.Select("SELECT * FROM " + m_テーブル名);

                return lst;
            }
        }

    }
}
