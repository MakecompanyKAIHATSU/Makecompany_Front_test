using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Makecompany_Front
{
    public partial class frmカレンダー作成 : Form
    {

        const string cstrカレンダーテンプレート = "CalenderTemplateFile";


        public frmカレンダー作成()
        {
            InitializeComponent();
        }


        /*
         *  出力
         */
        private void button2_Click(object sender, EventArgs e)
        {

            //Dictionary<object, string> objエラーチェック対象 = new Dictionary<object, string>();
            string str出力先フォルダ = this.txt出力先フォルダ.Text;


            //テンプレートファイルを読み込むため、パスを作成します
            string strテンプレートファイルパス = Application.StartupPath.ToString() 
                                 + "\\" + System.Configuration.ConfigurationManager.AppSettings[cstrカレンダーテンプレート];


            //対象年月を抽出し、処理対象範囲を確認します
            DateTime dt対象年月 = DateTime.Parse(this.cbo年.Text + "/" + this.cbo月.Text);
            MessageBox.Show(dt対象年月.ToShortDateString());  

            //テンプレートファイルとスケジュールデータをもとに、講師毎のカレンダーファイル.xlsxを作成します
            Makecompany.Career.do_カレンダー doc = new Makecompany.Career.do_カレンダー(strテンプレートファイルパス
                                                                                        , str出力先フォルダ) ;
            //ファイル出力
            doc.CreateXlsx(); 


            //出力したフォルダのxlsxファイルをpdfに変換
            Makecompany.Career.doExcel doe = new Makecompany.Career.doExcel();
            doe.PDF出力(str出力先フォルダ, str出力先フォルダ); //暫定処理として、直下にそのまま出力します

            //作成したxlsxファイルをPDFに変換
            //var files = Directory.GetFiles(str出力先フォルダパス, "*.xlsx", SearchOption.AllDirectories);

           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmカレンダー作成_Load(object sender, EventArgs e)
        { 

            //年コンボボックス
            for (int i = -1; i <= 1; i++)
            {
                this.cbo年.Items.Add((DateTime.Now.Year + i).ToString());
            }

            //月コンボボックス
            for (int i = 1; i <= 12; i++)
            {
                this.cbo月.Items.Add(i.ToString());
            }

            //現在の年月を対象とする（一か月後のほうがいいっすかねえ。。。）
            this.cbo年.Text = DateTime.Now.Year.ToString();
            this.cbo月.Text = DateTime.Now.Month.ToString();

        }
    }
}
