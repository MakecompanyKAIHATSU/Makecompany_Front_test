using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makecompany_Front
{
    public partial class frmマスタ小科目 : Form
    {
        private Dictionary<string, string> hコース = new Dictionary<string, string>();



        public frmマスタ小科目()
        {
            InitializeComponent();
        }

        private void frmマスタ小科目_Load(object sender, EventArgs e)
        {
            pコースコンボボックス作成();
        }

        private void pコースコンボボックス作成()
        {

            string sSQL = "SELECT * FROM マスタ_コース";

            var lsコース = new List<Dictionary<string, object>>();
            lsコース = pデータ取得(sSQL);

            //内容クリア
            cbxコース.Items.Clear();

            //コンボボックス追加
            foreach (Dictionary<string, object> so in lsコース)
            {
                cbxコース.Items.Add(so["コース名"].ToString());
                hコース.Add(so["コース名"].ToString() , so["コース番号"].ToString());
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

        private void cbxコース_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hコース.ContainsKey(cbxコース.Text)) { lblコース.Text = hコース[cbxコース.Text]; }
        }
    }
}
