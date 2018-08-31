using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makecompany_Front.ThisAppClass
{
    public enum enumクラス
    {
        クラス番号 =1,
        クラス名 = 2,
        コース番号 =3,
        開校日 =4,
        終了の日 =5,
        選考試験日 =6,
        選考結果通知日 =7,
        労働局募集開始日 =8,
        労働局募集終了日 =9,
        延長募集終了日 =10,

        労働局通知日 =11,
        労働局番号 =12,

        県通知日 =13,
        県番号 =14
    }

    class clsクラス 
    {
        public string m_クラス番号 { get; set; }
        public string m_クラス名 { get; set; }
        public string m_コース番号 { get; set; }
        public string m_開校日 { get; set; }
        public string m_終了の日 { get; set; }
        public string m_選考試験日 { get; set; }
        public string m_選考結果通知日 { get; set; }
        public string m_労働局募集開始日 { get; set; }
        public string m_労働局募集終了日 { get; set; }
        public string m_延長募集終了日 { get; set; }

        public string m_労働局通知日 { get; set; }
        public string m_労働局番号 { get; set; }

        public string m_県通知日 { get; set; }
        public string m_県番号 { get; set; }
    }

    class clsテーブル_クラス
    {

        private const string m_テーブル名 = "データ_クラス";

        /*
         * 
         */
        public clsテーブル_クラス()
        {

        }


        public List<clsクラス> GetData()
        {
            var c = new thisCommon();
            var r = new List<clsクラス>();

            using (var sql = c.m_接続済みSQLクラス提供())
            {
                var lst = sql.Select("SELECT * FROM " + m_テーブル名);

                foreach (var dic in lst)
                {
                    var a = new clsクラス();


                    a.m_クラス番号 = dic["クラス番号"].ToString();
                    a.m_クラス名 = dic["クラス名"].ToString();

                    a.m_コース番号 = dic["コース番号"].ToString();

                    a.m_開校日 = dic["開校日"].ToString();
                    a.m_終了の日 = dic["終了の日"].ToString();

                    a.m_労働局募集終了日 = dic["労働局募集終了日"].ToString();
                    a.m_労働局募集開始日 = dic["労働局募集開始日"].ToString();

                    a.m_労働局番号 = dic["労働局番号"].ToString();
                    a.m_労働局通知日 = dic["労働局通知日"].ToString();

                    a.m_延長募集終了日 = dic["延長募集終了日"].ToString();

                    a.m_県番号 = dic["県番号"].ToString();
                    a.m_県通知日 = dic["県通知日"].ToString();

                    a.m_選考結果通知日 = dic["選考結果通知日"].ToString();
                    a.m_選考試験日 = dic["選考試験日"].ToString();

                    r.Add(a);
                }

                return r;
            }
        }


        public List<Dictionary<string,object>> GetDataListDictionary()
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
