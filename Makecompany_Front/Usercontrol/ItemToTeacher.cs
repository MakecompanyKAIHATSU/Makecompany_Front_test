using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makecompany_Front.Usercontrol
{
    public partial class ItemToTeacher : UserControl
    {
        public class _h_項目情報
        {
            public string コース番号 { get; set; }
            public string コース名 { get; set; }
            public string クラス番号 { get; set; }
            public string 大科目番号 { get; set; }
            public string 時間順 { get; set; }
            public string 小科目番号 { get; set; }
            public string 小科目名 { get; set; }
            public string 項目番号 { get; set; }
            public string 項目名{ get; set; }
            public string 枝番 { get; set; }
            public string 実施日 { get; set; }
        }

        private const string invalidTeacher = "x";

        public delegate void comboselectedHandler(string str);
        public event comboselectedHandler Teacher_Changed;

        public Dictionary<string, string> Teacherdic = new Dictionary<string, string>();

        public ItemToTeacher()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            this.txtItem.Clear();
            this.comboBox1.Items.Clear();
            this.comboBox1.Text = "";
        }

        /*
         * 
         */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string result;

            if (!Teacherdic.ContainsKey(comboBox1.Text))
            {
                //コンボボックスで選ばれてないとかそういうとき
                result = invalidTeacher;
            }
            else
            {
                //連想配列から講師番号を抽出
                result = Teacherdic[comboBox1.Text].ToString();
            }

            label1.Text = result;

            if (Teacher_Changed != null) { Teacher_Changed(result); }
        }



        /*
         * 
         */
        public void ItemsSetting(_h_項目情報 h_項目情報)
        {

            //項目のセット
            string str = h_項目情報.コース名 + "-" + h_項目情報.小科目名 + "-" + h_項目情報.項目名;
            toolTip1.SetToolTip(txtItem, str);

            //テキストボックスに表示
            txtItem.Text = h_項目情報.項目名;
            
            //コンボボックスの初期設定
            //1.コース毎の授業に紐づけられた必要資格から講師のコンボボックスを作成
            Teacher_add(h_項目情報.コース番号, h_項目情報.小科目番号, h_項目情報.項目番号);

            //2.表示する初期値（既に設定されている講師があれば）
            TeacherName_set(h_項目情報.クラス番号 , h_項目情報.実施日, h_項目情報.時間順);
        }

        /*
         * 
         */
        private void Teacher_add(string hコース番号, string h小科目番号, string h項目番号)
        {

            //コンボボックスのクリア
            comboBox1.Items.Clear();

            //SQL文の設定
            string sSQL = "SELECT コース番号,コース名,小科目番号,小科目名,項目番号,項目名,講師番号,苗字";
            sSQL = sSQL + ",名前,表示用 FROM Q資格別担当可能講師";
            sSQL = sSQL + " WHERE コース番号 = '" + @hコース番号 + "'";
            sSQL = sSQL + " AND 小科目番号 = '" + @h小科目番号 + "'";
            sSQL = sSQL + " AND 項目番号 = '" + @h項目番号 + "'";


            //レコードの取得
            var r = new List<Dictionary<string, object>>();
            var dox = new Makecompany.Career.doXML("");
            var c = new Makecompany.Career.SqlClient.doSQL(dox.SQL_Server, dox.DB_Name, dox.UserID, dox.Password);
            r = c.Select(sSQL);

            //講師名を連想配列化
            var dic = new Dictionary<string, string>();
            string s;

            //tooltipIconとテキストとコンボボックス
            if (r.Count > 0)
            {

                /*
                string str = r[0]["コース名"].ToString() + "-" + r[0]["小科目名"].ToString() + "-" + r[0]["項目名"].ToString();
                toolTip1.SetToolTip(txtItem, str );

                //テキストボックスに表示
                txtItem.Text = r[0]["項目名"].ToString();
                */

                foreach (var a in r)
                {
                    s = a["苗字"].ToString() + a["名前"].ToString();

                    if (!dic.ContainsKey(s))
                    {
                        //講師名を追加
                        dic.Add(s, a["講師番号"].ToString() );
                    } 

                }

                //連想配列のコピー
                Teacherdic = dic; 

                //連想配列をコンボボックスに追加
                foreach (KeyValuePair<string, string> pair in dic)
                {
                    comboBox1.Items.Add(pair.Key);
                }
            }
        }

        private void TeacherName_set(string hクラス番号, string h実施日,string h時間順)
        {

            //SQL文の設定
            string sSQL = "SELECT 講師番号,実施日,時間順";
            sSQL = sSQL + ",苗字,名前 FROM Q担当講師";
            sSQL = sSQL + " WHERE 実施日 = '" + @h実施日 + "'";
            sSQL = sSQL + " AND 時間順 = '" + @h時間順 + "'";
            sSQL = sSQL + " AND クラス番号 = '" + @hクラス番号 + "'";


            //レコードの取得
            var r = pデータ取得(sSQL);

            if(r.Count != 0)
            {
                foreach(var a in r)
                { 
                    comboBox1.Text   = a["苗字"].ToString() + a["名前"].ToString();
                }
            } 



        }

        /*
         * データベースに繋いでセレクトデータ
         */
        private List<Dictionary<string, object>> pデータ取得(string sSQL)
        {

            var result = new List<Dictionary<string, object>>();
            var dox = new Makecompany.Career.doXML("");
            var c = new Makecompany.Career.SqlClient.doSQL(dox.SQL_Server, dox.DB_Name, dox.UserID, dox.Password);
            result = c.Select(sSQL);

            return result;
        }

        private void btn講師一覧_Click(object sender, EventArgs e)
        {
            frm講師予定 a = new frm講師予定();
            a.ShowDialog();
             
        }
    }
}
