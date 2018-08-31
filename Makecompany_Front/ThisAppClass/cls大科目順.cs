using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makecompany_Front.ThisAppClass
{
    struct _struct
    {
        public const string m_テーブル名 = "データ_大科目順";

        public List<string> m_フィールド名s()
        {
            var ls = new List<string>();

            ls.Add("コース番号");
            ls.Add("クラス番号");
            ls.Add("版数");
            ls.Add("順番");
            ls.Add("大科目番号");
            ls.Add("時間順");
            ls.Add("小科目番号");
            ls.Add("枝番");
            ls.Add("項目番号");
            ls.Add("実施日");
            ls.Add("教室番号");
            ls.Add("講師番号");
            ls.Add("小テスト実施日");

            return ls;
        }

        public List<string> m_WHEREフィールド名s()
        {
            var ls = new List<string>();

            ls.Add("コース番号");
            ls.Add("クラス番号");
            ls.Add("版数");
            ls.Add("順番");
            ls.Add("大科目番号");
            ls.Add("時間順");
            ls.Add("小科目番号");
            ls.Add("枝番");
            ls.Add("項目番号");

            return ls;
        }

    }


    class cls大科目順
    {
        List<Dictionary<string,object>> _data;

        public cls大科目順()
        {
            _data = new List<Dictionary<string, object>>();
        }

        public void Add(string h_コース番号
                            , string h_クラス番号
                            , string h_順番
                            , string h_版数
                            , string h_大科目番号
                            , string h_時間順
                            , string h_小科目番号
                            , string h_枝番
                            , string h_項目番号
                            , string h_実施日
                            , string h_教室番号
                            , string h_講師番号
                            , string h_小テスト実施日)
        {
            var _indata = new Dictionary<string,object>();

            _indata.Add("コース番号",h_コース番号);
            _indata.Add("クラス番号",h_クラス番号);
            _indata.Add("順番",h_順番);
            _indata.Add("版数", h_版数);
            _indata.Add("大科目番号",h_大科目番号);
            _indata.Add("時間順",h_時間順);
            _indata.Add("小科目番号",h_小科目番号);
            _indata.Add("枝番",h_枝番);
            _indata.Add("項目番号",h_項目番号);
            _indata.Add("実施日",h_実施日);
            _indata.Add("講師番号",h_講師番号);
            _indata.Add("教室番号",h_教室番号);
            _indata.Add("小テスト実施日",h_小テスト実施日);

            _data.Add(_indata);
        }

        public void m_Update()
        {

            var c = new thisCommon();

            using (var sql = c.m_接続済みSQLクラス提供())
            {
                var s = new _struct();

                sql.UPDATE(_struct.m_テーブル名, s.m_フィールド名s(), s.m_WHEREフィールド名s(), _data); 
            }
        }



        public List<Dictionary<string,object>> GetData()
        {
            var data = new List<Dictionary<string, object>>();
            return data;

        }

    }




}
