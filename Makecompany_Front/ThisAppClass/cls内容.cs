using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makecompany_Front.ThisAppClass
{

    public enum enum内容
    {
        コース番号 = 1,
        大科目番号 = 2,
        時間順 = 3,
        小科目番号 = 4,
        枝番 = 5,
        区分 = 6,
        表示順 = 7,
        内容 = 8
    }

    class cls内容
    {    
        public string m_コース番号 { get; set; }
        public string m_大科目番号 { get; set; }
        public string m_時間順 { get; set; }
        public string m_小科目番号 { get; set; }
        public string m_枝番 { get; set; }
        public string m_項目番号 { get; set; }
        public string m_区分 { get; set; }
        public string m_表示順 { get; set; }
        public string m_内容 { get; set; }
    }

    class clsテーブル_内容
    {

        private const string m_テーブル名 = "データ_内容";

        /*
         * 
         */
        public clsテーブル_内容()
        {

        }


        public List<cls内容> GetData()
        {
            var c = new thisCommon();
            var r = new List<cls内容>();

            using (var sql = c.m_接続済みSQLクラス提供())
            {
                var lst = sql.Select("SELECT * FROM " + m_テーブル名);

                foreach (var dic in lst)
                {
                    var a = new cls内容();

                    a.m_コース番号 = dic["コース番号"].ToString();

                    a.m_大科目番号 = dic["大科目番号"].ToString();
                    a.m_時間順 = dic["時間順"].ToString();

                    a.m_小科目番号 = dic["小科目番号"].ToString();

                    a.m_枝番 = dic["枝番"].ToString();
                    a.m_項目番号 = dic["項目番号"].ToString();

                    a.m_区分 = dic["区分"].ToString();
                    a.m_表示順 = dic["表示順"].ToString();

                    a.m_内容 = dic["内容"].ToString();

                    r.Add(a);
                }

                return r;
            }
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
