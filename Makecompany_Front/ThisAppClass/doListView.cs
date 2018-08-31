using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makecompany.Career
{
    class doListView
    {
        private const int subitemstartindex = 1;
        private ListView _lv;

        public doListView(ListView h_リストビュー)
        {

            _lv = h_リストビュー; 
        }


        public void m_データベースからデータを取得してlistviewにセット(string h_テーブル名,string h_WHERE句)
        {

            var dox = new Makecompany.Career.doXML("");
            var c = new Makecompany.Career.SqlClient.doSQL(dox.SQL_Server, dox.DB_Name, dox.UserID, dox.Password);

            List<string> h_フィールド名 = c.getFieldName(h_テーブル名);
            List<Dictionary<string, object>> r = c.Select("SELECT * FROM " + h_テーブル名 + " " + h_WHERE句);

            m_データをListviewにセット(h_テーブル名, h_フィールド名, r);

        }

        public void m_データベースからデータを取得してlistviewにセット(string h_テーブル名)
        {
            var dox = new Makecompany.Career.doXML("");
            var c = new Makecompany.Career.SqlClient.doSQL(dox.SQL_Server, dox.DB_Name, dox.UserID, dox.Password);

            List<string> h_フィールド名 = c.getFieldName(h_テーブル名);
            List<Dictionary<string, object>> r = c.Select("SELECT * FROM " + h_テーブル名);

            m_データをListviewにセット(h_テーブル名, h_フィールド名, r);    

        }


        public void m_データをListviewにセット(string sテーブル名, List<string> hフィールド名, List<Dictionary<string, object>> h_データ)
        {
            //フィールド名を目視用リストビューに設定
            _lv.Clear();
            _lv.Columns.Add("テーブル名");

            foreach (var s in hフィールド名)
            {
                _lv.Columns.Add(s);

            }

            foreach (var a in h_データ)
            {

                //リストアイテム(リストビューに追加するための前段階)
                ListViewItem itemx = new ListViewItem();
                itemx.Text = sテーブル名;

                for (int i = subitemstartindex; i < _lv.Columns.Count; i++)
                {
                    itemx.SubItems.Add(a[_lv.Columns[i].Text].ToString());
                }

                _lv.Items.Add(itemx);
            }

        }

    }
}
