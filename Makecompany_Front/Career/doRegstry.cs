using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
  
namespace Makecompany.Career
{
    class doRegstry:IDisposable 
    {
        #region 宣言部
        public enum TopPath
        {
            CurrentUser = 1,etc = 2
        }

        private RegistryKey key;
        #endregion

        /*
         * キー登録処理。複数同時処理はやめて単一の処理にしておきます
         */
        public void CreateValue(TopPath toppath,string path,string name,string value)
        {

            switch (toppath)
            {
                case TopPath.CurrentUser:
                    key = Registry.CurrentUser;
                    break;

                case TopPath.etc:
                    throw new Exception("この選択肢は未実装です 2017/3");
                    break;
            }

            key = key.CreateSubKey(@path);
            key.SetValue(name, value);   
        } 



        //デストラクタ
        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージ状態を破棄します (マネージ オブジェクト)。
                }

                // TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // TODO: 大きなフィールドを null に設定します。

                //閉じる処理
                key.Close();

                disposedValue = true;
            }
        }

        // TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        // ~doRegstry() {
        //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
        //   Dispose(false);
        // }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            // GC.SuppressFinalize(this);
        }
        #endregion






    }
}
