using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makecompany_Front
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmデータ取り込み画面());
            Application.Run(new frmスケジュール作成());
            //Application.Run(new frmカレンダー作成());

            // 2018/8/31 GitHubにてソースコードの管理開始
        }
    }
}
