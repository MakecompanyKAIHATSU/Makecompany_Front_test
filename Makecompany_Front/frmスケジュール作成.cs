using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Makecompany.Career;
using Makecompany_Front.ThisAppClass;
using Microsoft.Win32; 

namespace Makecompany_Front
{

    public partial class frmスケジュール作成 : Form
    {

        private struct _カリキュラムリストビュー
        {
            public const int 大科目番号 = _リストビュー.subitemstartindex;
            public const int 項目名 = 2;
            public const int 実施日 = 3;

        }

        private const string outvalue = "-1";
        private List<Dictionary<string, object>> h大科目番号ごとの項目一覧 = new List<Dictionary<string, object>>();
        private string hコース番号;
        private string hクラス番号;
        private string h大科目順;



        //12月
        private const int h１２月 = 12;

        private struct _科目to講師
        {
            public const string 一限目 = "1";
            public const string 二限目 = "2";
            public const string 三限目 = "3";
            public const string 四限目 = "4";
            public const string 五限目 = "5";
            public const string 六限目 = "6";
            public const string 七限目 = "7";
        }

        /*
        * 1
        */
        public frmスケジュール作成()
        {
            InitializeComponent();

            //レジストリにODBC設定を行う
            //var d = new Makecompany.Career.doXML("");
            //d.SetRegstry();
        }


        private void frmスケジュール作成_Load(object sender, EventArgs e)
        {
            //クラス名一覧を取得しコンボボックスに表示
            pクラス番号をコンボボックスにセット();

            //大科目順リストビュー初期化
            p大科目順ListView1初期化();

            //教室情報リストボックス初期化
            p教室リストボックス設定();

            //大科目順クエリの情報をリストビューにセット
            var c = new doListView(lv_全部);
            c.m_データベースからデータを取得してlistviewにセット("Q大科目順");

            //クラス情報
            var h_リストビュー = new doListView(lv_目視用_クラス);
            h_リストビュー.m_データベースからデータを取得してlistviewにセット("データ_クラス");

            //講師情報
            var c講師 = new cls講師();
            c講師.m_createListview(lv_目視用_講師);

            //HW来所日情報
            var cHW来所日 = new Makecompany_Front.ThisAppClass.clsHW来所日();
            cHW来所日.m_createListview(lv_目視用_HW来所日);

            //キャリコン情報
            var cキャリコン = new Makecompany_Front.ThisAppClass.clsキャリコン();
            cキャリコン.m_createListview(lv_目視用_キャリコン); 

            //特殊処理
            cbxクラス番号.Text = "291225";
            cbxクラス番号.Enabled = true;

        }

        /*
         * 
         */
        private void pクラス番号をコンボボックスにセット()
        {

            string sSQL = "SELECT データ_クラス.コース番号,データ_クラス.クラス番号"
                + " FROM マスタ_コース INNER JOIN データ_クラス ON マスタ_コース.コース番号 = データ_クラス.コース番号";

            var lsコース = new List<Dictionary<string, object>>();
            lsコース = pSQLデータ取得(sSQL);

            //内容クリア
            cbxクラス番号.Items.Clear();

            //コンボボックス追加
            foreach (var data in lsコース)
            {
                cbxクラス番号.Items.Add(data["クラス番号"]);
            }

        }

        /*
         * 2
         */
        private void p大科目順ListView1初期化()
        {
            //内容クリア
            listView1.Clear();

            //デザイン再設定
            listView1.Columns.Add("大科目番号");
            listView1.Columns.Add("項目名");
            listView1.Columns.Add("実施日");
            listView1.Columns[0].Width = 50;
            listView1.Columns[1].Width = 200;
            listView1.Columns[2].Width = 200;
        }

        /*
         * 3
         */
        private void set大科目順ListView1(string ClassNo)
        {
            //引数によらず
            p大科目順ListView1初期化();

            //引数参照
            if (ClassNo == null || ClassNo == "")
            {
                //何もしない
                return;
            }
            else
            {
                //SQL文の設定
                string sSQL = "SELECT コース番号, 大科目番号, 順番, 小科目番号 ,項目番号,項目名, 実施日 FROM Q大科目順";
                sSQL = sSQL + " WHERE クラス番号 = " + @ClassNo;
                sSQL = sSQL + " ORDER BY 順番,大科目番号 ";


                //レコードの取得
                var r = new List<Dictionary<string, object>>();
                r = pSQLデータ取得(sSQL);

                //データ_大科目順に無いときは
                if (r.Count <= 0)
                {
                    //コースに設定されている大科目順そのままで
                    sSQL = "Select * From データ_クラス";
                    sSQL = sSQL + " WHERE クラス番号 = " + @ClassNo;

                    r = pSQLデータ取得(sSQL);

                    sSQL = "Select * From Q大科目";
                    sSQL = sSQL + " WHERE コース番号 = " + @r[0]["コース番号"].ToString();

                    r = pSQLデータ取得(sSQL);
                }


                //
                h大科目番号ごとの項目一覧 = r;

                //得たレコードリストを連想配列化する（[順番]でまとめるため）
                var dic = new Dictionary<string, Dictionary<string, object>>();

                //順番でまとめる
                foreach (var a in r)
                {
                    string order = a["大科目番号"].ToString();

                    if (!dic.ContainsKey(order))
                    {
                        var data = new Dictionary<string, object>();
                        data.Add("項目名", a["項目名"].ToString());
                        data.Add("実施日", a["実施日"].ToString());

                        dic.Add(order, data);
                    }
                    else
                    {
                        dic[order]["項目名"] = dic[order]["項目名"] + "," + a["項目名"].ToString();
                    }
                }


                //連想配列のキー（[順番])でソート
                var pairs = ListSort(dic);

                //リストアイテムの初期化
                var dkj = new ListViewItem();

                //リストボックス設定
                foreach (var a in pairs)
                {

                    //リストから読み込んで、１行作成し、２列め以降も追加
                    dkj = new ListViewItem(a.Key);
                    dkj.SubItems.Add(a.Value["項目名"].ToString());

                    if (a.Value["実施日"].ToString() != "")
                    {
                        dkj.SubItems.Add(string.Format(DateTime.Parse(a.Value["実施日"].ToString()).ToString("yyyy/M/d")));
                    }


                    listView1.Items.Add(dkj);
                }
            }
        }

        /*
         */
        private List<KeyValuePair<string, Dictionary<string, object>>> ListSort(Dictionary<string, Dictionary<string, object>> dic)
        {

            // Dictionaryの内容をコピーして、List<KeyValuePair<string, string>>に変換
            var pairs = new List<KeyValuePair<string, Dictionary<string, object>>>(dic);

            // List.Sortメソッドを使ってソート
            // (引数に比較方法を定義したメソッドを指定する)
            pairs.Sort(CompareKeyValuePair);

            return pairs;
        }

        /*
         */
        static int CompareKeyValuePair(KeyValuePair<string, Dictionary<string, object>> x, KeyValuePair<string, Dictionary<string, object>> y)
        {
            // Keyで比較した結果を返す
            return string.CompareOrdinal(x.Key, y.Key);  
            //return (int.Parse(x.Key) - int.Parse(y.Key));
        }


        /*
         * クラス名コンボボックスの変更時
         */
        private void cbxクラス名_SelectedIndexChanged(object sender, EventArgs e)
        {
            //クラス名が空白nullもしくは空白の場合、
            if (cbxクラス番号.Text == null || cbxクラス番号.Text == "")
            {
                //処理を抜ける
                return;
            }
            else
            {

                //もし選択されているクラス名に大科目順データがない場合、作成する。
                var doS = new Makecompany.Career.doSpecial();
                doS.m_大科目順データがないクラスの大科目をマスタからコピーする(cbxクラス番号.Text, lv_目視用_クラス);

                //クラス名テキストボックスにクラス名を表示（連想化を利用）
                txtクラス名.Text = doS.m_クラス番号からクラス名を取得(cbxクラス番号.Text, lv_目視用_クラス);
      

                //大科目リストビューに表示
                set大科目順ListView1(cbxクラス番号.Text);

                //カレンダーを作成する（カレンダーの開始月を開講日に合わせるためクラス名を渡す）
                pカレンダー設定(cbxクラス番号.Text);

                //大科目順に実施日が設定されている場合、カレンダーに大科目番号を表示する
                p大科目情報反映();

                //リストビュー専用クラスを用いてデータを保管
                var c = new doListView(lv_全部);
                c.m_データベースからデータを取得してlistviewにセット("q大科目順","WHERE クラス番号 = " + cbxクラス番号.Text);  

            }
        }


        /*
         * 
         */
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //項目が１つも選択されていない場合
            if (listView1.SelectedItems.Count == 0)
            {//処理を抜ける
                return;
            }
            else
            {

                //1番目に選択されているアイテムをitemxに格納
                var itemx = listView1.SelectedItems[0];

                //格納したリストビューの１行から一列目を取得
                lbl_Index.Text = itemx.Index.ToString();


                //科目-講師情報欄更新
                p科目to講師情報欄(this.cbxクラス番号.Text, itemx.Text);

                //教室
                p選択されている大科目番号で使用する教室を検索してリストに表示する(itemx.Text);


            }

        }


        /*
         * 
         */
        private void p教室リストボックス設定()
        {

            string sSQL = "SELECT 教室名 FROM マスタ_教室";

            var r = pSQLデータ取得(sSQL);

            this.lst教室.Items.Clear(); 

            foreach (var d in r)
            {

                this.lst教室.Items.Add(d["教室名"].ToString());
            }

            var h_リストビュー = new doListView(lv_目視用_教室);
            h_リストビュー.m_データベースからデータを取得してlistviewにセット("マスタ_教室");

        }

        /*
        * 
        */
        private void p選択されている大科目番号で使用する教室を検索してリストに表示する(string h大科目番号)
        {

            string target = "";
            ListViewItem itemx = new ListViewItem();
             

            for (int i = 0; i <= lv_全部.Items.Count-1; i++)
            {
                itemx = new ListViewItem();
                itemx = lv_全部.Items[i];


                if (itemx.SubItems[_目視用全部.大科目番号].Text == h大科目番号)
                {

                    target = itemx.SubItems[_目視用全部.教室名].Text;
                    break;
                }
            }


            for (int i = 0; i <= lst教室.Items.Count - 1; i++)
            {
                if (lst教室.Items[i].ToString() == target)
                {

                    lst教室.SelectedIndex = i;
                    break;
                }
            }

        }


        /*
         * 
         */
        private void p科目to講師情報欄(string hクラス番号, string h大科目番号)
        {
            //目視用全部からデータを取得
            var itemx = new ListViewItem();
            var h_その日の授業一覧 = new List<Makecompany_Front.Usercontrol.ItemToTeacher._h_項目情報>();
            var h_項目一覧 = new Makecompany_Front.Usercontrol.ItemToTeacher._h_項目情報();

            //講師情報欄クリア
            itemToTeacher1.Clear();
            itemToTeacher2.Clear();
            itemToTeacher3.Clear();
            itemToTeacher4.Clear();

            for (int i = 0;i<lv_全部.Items.Count;i++)
            {
                itemx = lv_全部.Items[i];

                if(itemx.SubItems[_目視用全部.クラス番号].Text == hクラス番号)
                {
                    if (itemx.SubItems[_目視用全部.大科目番号].Text == h大科目番号)
                    {
                        h_項目一覧 = new Usercontrol.ItemToTeacher._h_項目情報();  　

                        h_項目一覧.コース番号 = itemx.SubItems[_目視用全部.コース番号].Text;
                        h_項目一覧.コース名 = itemx.SubItems[_目視用全部.コース名].Text;
                        h_項目一覧.クラス番号 = itemx.SubItems[_目視用全部.クラス番号].Text;
                        h_項目一覧.大科目番号 = itemx.SubItems[_目視用全部.大科目番号].Text;
                        h_項目一覧.時間順 = itemx.SubItems[_目視用全部.時間順].Text;
                        h_項目一覧.小科目番号 = itemx.SubItems[_目視用全部.小科目番号].Text;
                        h_項目一覧.小科目名 = itemx.SubItems[_目視用全部.小科目名].Text;
                        h_項目一覧.項目番号 = itemx.SubItems[_目視用全部.項目番号].Text;
                        h_項目一覧.項目名 = itemx.SubItems[_目視用全部.項目名].Text;
                        h_項目一覧.実施日 = itemx.SubItems[_目視用全部.実施日].Text;

                        h_その日の授業一覧.Add(h_項目一覧);
                    }
                } 
            }

            foreach (var a in h_その日の授業一覧)
            {
                switch (a.時間順)
                {

                    case "1":
                        itemToTeacher1.ItemsSetting(a);
                        break; 
                    case "2":
                        itemToTeacher2.ItemsSetting(a);
                        break;
                    case "3":
                        itemToTeacher3.ItemsSetting(a);
                        break;
                    case "4":
                        itemToTeacher4.ItemsSetting(a);
                        break;
                        //case 4: break;
                }
            }
        }



        /*
         * 
         */
        private void button2_Click(object sender, EventArgs e)
        {
            set大科目順ListView1("");
        }

        /*
         * 
         */
        private void pカレンダー設定(string classNo)
        {
            //クラスデータ取得
            string sSQL = "Select * From データ_クラス";
            sSQL = sSQL + " WHERE クラス番号 = " + @classNo;
            var result = new List<Dictionary<string, object>>();
            result = pSQLデータ取得(sSQL);

            if (result.Count > 0)
            {
                //開講日取得
                DateTime d = DateTime.Parse(result[0]["開講日"].ToString());

                //開講日の当月のカレンダーを作成
                viewMonth1.setCalender(d.Year, d.Month);
                monthLabel1.setYM(d.Year, d.Month);


                //：：：以下、開講日の翌月以降の処理：：：
                int y = d.Year;
                int m = d.Month;

                for (int i = 1; i <= 3; i++)
                {
                    //月インクリメント
                    m++;

                    //月インクリメントした結果１３月になったら
                    if (m > h１２月)
                    {
                        //一年増やして１月に変える
                        y++;
                        m = 1;
                    }

                    switch (i)
                    {
                        case 1:
                            viewMonth2.setCalender(y, m);
                            monthLabel2.setYM(y, m);
                            break;
                        case 2:
                            viewMonth3.setCalender(y, m);
                            monthLabel3.setYM(y, m);
                            break;
                        case 3:
                            viewMonth4.setCalender(y, m);
                            monthLabel4.setYM(y, m);
                            break;
                    }

                }
            }
        }



        /*
         * データベースに繋いでセレクトデータ
         */
        private List<Dictionary<string, object>> pSQLデータ取得(string sSQL)
        {

            var result = new List<Dictionary<string, object>>();
            var dox = new Makecompany.Career.doXML("");
            var c = new Makecompany.Career.SqlClient.doSQL(dox.SQL_Server, dox.DB_Name, dox.UserID, dox.Password);
            result = c.Select(sSQL);

            return result;
        }

        /*
         * データベースに繋いでフィールド名取得
         */
        private List<string> pSQLフィールド名取得(string hテーブル名)
        {

            List<string> result;
            var dox = new Makecompany.Career.doXML("");
            var c = new Makecompany.Career.SqlClient.doSQL(dox.SQL_Server, dox.DB_Name, dox.UserID, dox.Password);
            result = c.getFieldName(@hテーブル名);

            return result;
        }

        /**
         * 日付欄変更プログラム
         */
        private void viewMonth1_ClickviewDayEvent(string str)
        {
            setDayInfotoviewMonth(str);
        }

        /*
        //カレンダーをクリックされたときの自作イベントです
        //strには日付が入ってきます
        */
        private void setDayInfotoviewMonth(string str)
        {
            //listboxの行番号を数値に変換したものを格納する
            int result;

            //MessageBox.Show(str);
            lbl_Date.Text = str;

            if (Check_HW(lbl_Date.Text))
            {
                MessageBox.Show("HW来所日には設定できません");  
            }
            else
            {

                if (int.TryParse(lbl_Index.Text, out result))
                {
                    //実施日反映
                    listView1.Items[result].SubItems[2].Text = str;

                    //目視用全部に実施日反映
                    var c = new doSpecial();
                    c.m_目視用Listviewにデータを連動させる_実施日(lv_全部, listView1.Items[result].Text, str);
                }

                //変更後の大科目情報の反映を行う
                p大科目情報反映();

            }
        }

        /*
         *　設定しようとした実施日がHW来所日と同じ場合、メッセージを出してキャンセルする 
         */
        private bool Check_HW(string date)
        {
            bool r = false;

            for (int i = 0; i < lv_目視用_HW来所日.Items.Count; i++)
            {
                DateTime d1 = DateTime.Parse(lv_目視用_HW来所日.Items[i].SubItems[Makecompany_Front.ThisAppClass._目視用HW来所日.HW来所日].Text);
                DateTime d2 = DateTime.Parse(date);
                
                //日付比較（等しければ0)
                if (DateTime.Compare(d1,d2) ==0)
                {
                    r = true;
                    break;
                }
            }

            return r;
        }


        /*
         * 
         */
        private void p大科目情報反映()
        {
            var dic日付ごとの大科目番号 = new Dictionary<string, string>();
            string str実施日;

            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                str実施日 = listView1.Items[i].SubItems[2].Text;

                if (str実施日 != null)
                {
                    if (!dic日付ごとの大科目番号.ContainsKey(str実施日))
                    {
                        dic日付ごとの大科目番号.Add(str実施日, listView1.Items[i].Text);
                    }
                    else
                    {
                        dic日付ごとの大科目番号[str実施日] = " 重";
                    }
                }

            }

            //HW来所日の設定
            for (int i = 0; i < lv_目視用_HW来所日.Items.Count; i++)
            {
                DateTime date = DateTime.Parse(lv_目視用_HW来所日.Items[i].SubItems[Makecompany_Front.ThisAppClass._目視用HW来所日.HW来所日].Text);  
                dic日付ごとの大科目番号.Add(date.ToShortDateString(), "HW");
            }

            //カレンダー４枚に同じデータを渡して勝手に処理してもらう。
            pカレンダー設定(cbxクラス番号.Text);

            viewMonth1.set大科目情報(dic日付ごとの大科目番号);
            viewMonth2.set大科目情報(dic日付ごとの大科目番号);
            viewMonth3.set大科目情報(dic日付ごとの大科目番号);

            viewMonth4.set大科目情報(dic日付ごとの大科目番号);
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            var dox = new Makecompany.Career.doXML("");
            var c = new Makecompany.Career.SqlClient.doSQL(dox.SQL_Server, dox.DB_Name,dox.UserID,dox.Password);


            var s = new List<string>();
            s.Add("教室番号");
            s.Add("教室名");


            var v = new List<Dictionary<string, object>>();
            var item = new Dictionary<string, object>();



            item["教室番号"] = 10;
            item["教室名"] = "教室X";

            v.Add(item);

            c.INSERT_INTO("マスタ_教室", s, v);
        }


        /*
         * 
         */
        private void lst教室_SelectedIndexChanged(object sender, EventArgs e)
        {
            //リストアイテム
            ListViewItem itemx = new ListViewItem();


            //1番目に選択されているアイテムをitemxに格納
            itemx = listView1.SelectedItems[0];


            //格納したリストビューの１行から一列目を取得
            lbl_Index.Text = itemx.Index.ToString();


            //Special処理
            var c = new doSpecial();
               
            
            //科目-講師情報欄更新
            c.m_目視用Listviewにデータを連動させる_教室(lv_全部,lv_目視用_教室 ,itemx.Text,lst教室.Text);

            //

        }


        /*
         *カレンダー２枚目クリック時
        */
        private void viewMonth2_ClickviewDayEvent(string str)
        {
            setDayInfotoviewMonth(str);
        }

        /*
         *カレンダー３枚目クリック時
        */
        private void viewMonth3_ClickviewDayEvent(string str)
        {
            setDayInfotoviewMonth(str);
        }

        /*
         *カレンダー４枚目クリック時
         */
        private void viewMonth4_ClickviewDayEvent(string str)
        {
            setDayInfotoviewMonth(str);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            var c = new ThisAppClass.cls大科目順();
            var itemx = new ListViewItem(); 

           
            for(int i = 0;i<lv_全部.Items.Count;i++)
            {
                itemx = lv_全部.Items[i];
                c.Add(itemx.SubItems[_目視用全部.コース番号].Text
                    , itemx.SubItems[_目視用全部.クラス番号].Text
                    , itemx.SubItems[_目視用全部.順番].Text
                    , "1"
                    , itemx.SubItems[_目視用全部.大科目番号].Text
                    , itemx.SubItems[_目視用全部.時間順].Text
                    , itemx.SubItems[_目視用全部.小科目番号].Text
                    , itemx.SubItems[_目視用全部.枝番].Text
                    , itemx.SubItems[_目視用全部.項目番号].Text
                    , itemx.SubItems[_目視用全部.実施日].Text
                    , itemx.SubItems[_目視用全部.教室番号].Text
                    , itemx.SubItems[_目視用全部.講師番号].Text
                    , DateTime.Today.ToString()  
                    );
            }


            c.m_Update();
            MessageBox.Show("アップデート終わり！"); 
        }


        /********************************************************************************************************
        //処理名：項目にたいして講師を割り当てる１
        //作成者：松本稔
        //作成日：H29年9月10日
        /********************************************************************************************************/
        private void itemToTeacher1_Teacher_Changed(string str)
        {

            //大科目表示リストボックスの選択されているアイテムをitemxに格納
            var itemx = listView1.SelectedItems[0];
            string str大科目番号 = itemx.Text;

            var c = new doSpecial();
            c.m_目視用Listviewにデータを連動させる_講師(lv_全部, lv_目視用_講師, str大科目番号, _科目to講師.一限目, str);
        }

        /********************************************************************************************************
        //処理名：項目にたいして講師を割り当てる２
        //作成者：松本稔
        //作成日：H29年9月10日
        /********************************************************************************************************/
        private void itemToTeacher2_Teacher_Changed(string str)
        {
            //大科目表示リストボックスの選択されているアイテムをitemxに格納
            var itemx = listView1.SelectedItems[0];


            var c = new doSpecial();
            c.m_目視用Listviewにデータを連動させる_講師(lv_全部, lv_目視用_講師, itemx.Text, _科目to講師.二限目, str);
        }

        /********************************************************************************************************
        //処理名：項目にたいして講師を割り当てる３
        //作成者：松本稔
        //作成日：H29年9月10日
        /********************************************************************************************************/
        private void itemToTeacher3_Teacher_Changed(string str)
        {
            //大科目表示リストボックスの選択されているアイテムをitemxに格納
            var itemx = listView1.SelectedItems[0];


            var c = new doSpecial();
            c.m_目視用Listviewにデータを連動させる_講師(lv_全部, lv_目視用_講師, itemx.Text, _科目to講師.三限目, str);
        }



        /********************************************************************************************************
        //処理名：労働局様式６号
        //作成者：松本稔
        //作成日：H29年9月10日
        /********************************************************************************************************/
        private void button3_Click(object sender, EventArgs e)
        {
            //労働局6号
            var d = new List<Makecompany.Career.RDK6._RowValue>();
            var a = new Makecompany.Career.RDK6._RowValue();

            for (int i = 0; i < lv_全部.Items.Count; i++)
            {
                a = new Makecompany.Career.RDK6._RowValue();

                a.CourseNo = lv_全部.Items[i].SubItems[_目視用全部.コース番号].Text;
                a.CourseName = lv_全部.Items[i].SubItems[_目視用全部.コース名].Text;

                a.ClassNo = lv_全部.Items[i].SubItems[_目視用全部.クラス番号].Text;
                a.ClassName = lv_全部.Items[i].SubItems[_目視用全部.クラス名].Text;

                a.LargeSubjectNo = lv_全部.Items[i].SubItems[_目視用全部.大科目番号].Text;
                a.LargeSubjectNoSub = lv_全部.Items[i].SubItems[_目視用全部.時間順].Text;

                a.LittleSubjectNo = lv_全部.Items[i].SubItems[_目視用全部.小科目番号].Text;
                a.LittleSubjectName = lv_全部.Items[i].SubItems[_目視用全部.小科目名].Text;

                a.Edaban = lv_全部.Items[i].SubItems[_目視用全部.枝番].Text;
                a.EdabanName = lv_全部.Items[i].SubItems[_目視用全部.枝番名].Text; //枝番名って書いてあるが小科目名だとおもうんだよなあ

                a.ItemNo = lv_全部.Items[i].SubItems[_目視用全部.項目番号].Text;
                a.ItemName = lv_全部.Items[i].SubItems[_目視用全部.項目名].Text;

                a.ExecDate = lv_全部.Items[i].SubItems[_目視用全部.実施日].Text;


                a.TeacherNo = lv_全部.Items[i].SubItems[_目視用全部.講師番号].Text;
                a.TeacherName = lv_全部.Items[i].SubItems[_目視用全部.講師名].Text;

                a.RoomNo = lv_全部.Items[i].SubItems[_目視用全部.教室番号].Text;
                a.RoomName = lv_全部.Items[i].SubItems[_目視用全部.教室名].Text;

                a.KuniTime = int.Parse(lv_全部.Items[i].SubItems[_目視用全部.国時間].Text);

                d.Add(a);
            }

            //HWデータ追加処理
            for (int i = 0; i < lv_目視用_HW来所日.Items.Count; i++)
            {
                a = new Makecompany.Career.RDK6._RowValue();

                //該当クラスのデータのみを渡すようにここで制御します（いずれデータ取得時に絞ることになってもまあいいってことで）
                if(lv_目視用_HW来所日.Items[i].SubItems[Makecompany_Front.ThisAppClass._目視用HW来所日.クラス番号].Text == this.cbxクラス番号.Text)
                { 
                    a.ExecDate = lv_目視用_HW来所日.Items[i].SubItems[Makecompany_Front.ThisAppClass._目視用HW来所日.HW来所日].Text;
                    //a.LittleSubjectName = lv_目視用_HW来所日.Items[i].SubItems[Makecompany_Front.ThisAppClass._目視用HW来所日.科目名].Text;
                    a.EdabanName = lv_目視用_HW来所日.Items[i].SubItems[Makecompany_Front.ThisAppClass._目視用HW来所日.科目名].Text;
                    d.Add(a);
                }
            }

            //キャリコンデータ追加処理
            var d2 = new List<Makecompany.Career.RDK6._キャリコンRowValue>();
            var a2 = new Makecompany.Career.RDK6._キャリコンRowValue();
            for (int i = 0; i < lv_目視用_キャリコン.Items.Count; i++)
            {
                a2 = new Makecompany.Career.RDK6._キャリコンRowValue();

                //該当クラスのデータのみを渡すようにここで制御します（いずれデータ取得時に絞ることになってもまあいいってことで）
                if (lv_目視用_キャリコン.Items[i].SubItems[Makecompany_Front.ThisAppClass._目視用キャリコン.クラス番号].Text == this.cbxクラス番号.Text)
                { 
                    a2.開始日 = lv_目視用_キャリコン.Items[i].SubItems[Makecompany_Front.ThisAppClass._目視用キャリコン.開始日].Text;
                    a2.終了日 = lv_目視用_キャリコン.Items[i].SubItems[Makecompany_Front.ThisAppClass._目視用キャリコン.終了日].Text;

                    d2.Add(a2);
                }
            }


            //出力
            var c = new Makecompany.Career.do_RDK6(d, d2);
            c.StartYMD = new DateTime(2018,3,26);
            c.View();
        }

        /********************************************************************************************************
        //処理名：労働局様式７の１、７の２出力
        //作成者：松本稔
        //作成日：H29年9月2日
        /********************************************************************************************************/
        private void button5_Click(object sender, EventArgs e)
        {
            //労働局7号1,2
            var d = new List<Makecompany_Front.ThisAppClass.RDK7._RowValue>();
            var a = new Makecompany_Front.ThisAppClass.RDK7._RowValue();

            for (int i = 0; i < lv_全部.Items.Count; i++)
            {
                a = new Makecompany_Front.ThisAppClass.RDK7._RowValue();

                a.CourseNo = lv_全部.Items[i].SubItems[_目視用全部.コース番号].Text;
                a.CourseName = lv_全部.Items[i].SubItems[_目視用全部.コース名].Text;

                a.ClassNo = lv_全部.Items[i].SubItems[_目視用全部.クラス番号].Text;
                a.ClassName = lv_全部.Items[i].SubItems[_目視用全部.クラス名].Text;

                a.LargeSubjectNo = lv_全部.Items[i].SubItems[_目視用全部.大科目番号].Text;
                a.LargeSubjectNoSub = lv_全部.Items[i].SubItems[_目視用全部.時間順].Text;

                a.LittleSubjectNo = lv_全部.Items[i].SubItems[_目視用全部.小科目番号].Text;
                a.LittleSubjectName = lv_全部.Items[i].SubItems[_目視用全部.小科目名].Text;

                a.Edaban = lv_全部.Items[i].SubItems[_目視用全部.枝番].Text;
                a.EdabanName = lv_全部.Items[i].SubItems[_目視用全部.枝番名].Text;

                a.ItemNo = lv_全部.Items[i].SubItems[_目視用全部.項目番号].Text;
                a.ItemName = lv_全部.Items[i].SubItems[_目視用全部.項目名].Text;

                a.ExecDate = lv_全部.Items[i].SubItems[_目視用全部.実施日].Text;


                a.TeacherNo = lv_全部.Items[i].SubItems[_目視用全部.講師番号].Text;
                a.TeacherName = lv_全部.Items[i].SubItems[_目視用全部.講師名].Text;

                //講師情報から生年月日を取得する
                Makecompany.Career.doSpecial doS = new doSpecial();
                a.TeacherBirthday = doS.m_講師番号から生年月日を取得(a.TeacherNo, lv_目視用_講師);

                a.KijyunDate = DateTime.Today.ToShortDateString();   

                a.RoomNo = lv_全部.Items[i].SubItems[_目視用全部.教室番号].Text;
                a.RoomName = lv_全部.Items[i].SubItems[_目視用全部.教室名].Text;

                a.KuniTime = int.Parse(lv_全部.Items[i].SubItems[_目視用全部.国時間].Text);

                d.Add(a);
            }


            //出力
            var c = new Makecompany_Front.ThisAppClass.do_RDK7(d);
            //c.StartYMD = DateTime.Today;
            c.View();
        }

        /********************************************************************************************************
        //処理名：項目にたいして講師を割り当てる３
        //作成者：松本稔
        //作成日：H29年9月15日
        /********************************************************************************************************/
        private void itemToTeacher4_Teacher_Changed(string str)
        {
            //大科目表示リストボックスの選択されているアイテムをitemxに格納
            var itemx = listView1.SelectedItems[0];


            var c = new doSpecial();
            c.m_目視用Listviewにデータを連動させる_講師(lv_全部, lv_目視用_講師, itemx.Text, _科目to講師.四限目, str);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            var c = new frmメイン画面();
            c.Show();
            


        }
    }

            
}