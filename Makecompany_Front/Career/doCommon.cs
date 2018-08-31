using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makecompany.Career
{ 
    namespace _datatime {

        static class _func
        {

            private static readonly int FiscalYearStartingMonth = 4;


            //https://dobon.net/vb/dotnet/system/getage.html
            /// <summary>
            /// 生年月日から年齢を計算する
            /// </summary>
            /// <param name="birthDate">生年月日</param>
            /// <param name="targetDate">現在の日付</param>
            /// <returns>年齢</returns>
            public static int GetAge(DateTime birthDate, DateTime targetDate)
            {
                int age = targetDate.Year - birthDate.Year;
                //現在の日付から年齢を引いた日付が誕生日より前ならば、1引く
                if (targetDate.AddYears(-age) < birthDate)
                {
                    age--;
                }

                return age;
            }

            /// <summary>
            /// 該当年月の日数を返す
            /// </summary>
            /// <param name="dt">DateTime</param>
            /// <returns>DateTime</returns>
            public static int DaysInMonth(this DateTime dt)
            {
                return DateTime.DaysInMonth(dt.Year, dt.Month);
            }

            /// <summary>
            /// 月初日を返す
            /// </summary>
            /// <param name="dt">DateTime</param>
            /// <returns>Datetime</returns>
            public static DateTime BeginOfMonth(this DateTime dt)
            {
                return dt.AddDays((dt.Day - 1) * -1);
            }

            /// <summary>
            /// 月末日を返す
            /// </summary>
            /// <param name="dt">DateTime</param>
            /// <returns>DateTime</returns>
            public static DateTime EndOfMonth(this DateTime dt)
            {
                return new DateTime(dt.Year, dt.Month, DaysInMonth(dt));
            }

            /// <summary>
            /// 時刻を落として日付のみにする
            /// </summary>
            /// <param name="dt">DateTime</param>
            /// <returns>DateTime</returns>
            public static DateTime StripTime(this DateTime dt)
            {
                return new DateTime(dt.Year, dt.Month, dt.Day);
            }

            /// <summary>
            /// 日付を落として時刻のみにする
            /// </summary>
            /// <param name="dt">DateTime</param>
            /// <param name="base_date">DateTime* : 基準日</param>
            /// <returns>DateTime</returns>
            public static DateTime StripDate(this DateTime dt, DateTime? base_date = null)
            {
                base_date = base_date ?? DateTime.MinValue;
                return new DateTime(base_date.Value.Year, base_date.Value.Month, base_date.Value.Day, dt.Hour, dt.Minute, dt.Second);
            }

            /// <summary>
            /// 該当日付の年度を返す
            /// </summary>
            /// <param name="dt">DateTime</param>
            /// <param name="startingMonth">int? : 年度の開始月</param>
            /// <returns>int</returns>
            public static int FiscalYear(this DateTime dt, int? startingMonth = null)
            {
                return (dt.Month >= (startingMonth ?? FiscalYearStartingMonth)) ? dt.Year : dt.Year - 1;
            }

            public static string[] getCalenderData(int yy, int mm, int needCount)
            {

                int n;
                List<string> Ls = new List<string>();


                //その月の1日の曜日番号(0～6)-1
                DateTime dt = new DateTime(yy, mm, 1);
                n = (int)dt.DayOfWeek - 1;

                //Listに予め空白を設定(日曜=0-1なら空白なし)
                for (int i = 0; i <= n; i++)
                { Ls.Add(""); }

                //月末日の算出
                if (mm != 12)
                {
                    //翌月頭
                    dt = new DateTime(yy, mm + 1, 1);
                }
                else
                {
                    //翌年１月頭
                    dt = new DateTime(yy + 1, 1, 1);

                }

                //一日ずらして当月末日を算出
                dt = dt.AddDays(-1);


                //日を入れる
                for (int i = 1; i <= dt.Day; i++)
                {
                    Ls.Add(i.ToString());
                }

                for (int i = Ls.Count; i <= needCount; i++)
                {
                    Ls.Add("");
                }

                //配列化して返す
                return Ls.ToArray<string>();

                //Me(lblname & i + n).Caption = i
                //If CDate(yy & "/" & mm & "/" & i) = the_date Then
                //    Me("Label" & i + n).BackColor = RGB(255, 255, 0) 'TextBoxの日と同じなら色をつける
                //End If
                //Next i

            }


        }

        namespace _File
        {
            class _func
            {
                public void copy(string inPath,string outPath)
                {
                    System.IO.File.Copy(inPath, outPath);  

                }

                public void copy(string inPath, string outPath, bool overwrite)
                {
                    System.IO.File.Copy(inPath, outPath, overwrite);

                }

            }



        }
         


    }

}
