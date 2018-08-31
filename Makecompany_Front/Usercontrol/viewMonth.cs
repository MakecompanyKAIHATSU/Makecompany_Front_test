using System.Windows.Forms;
using System; 
using Makecompany;
using System.Collections.Generic;


namespace Makecompany
{
    public partial class viewMonth : UserControl
    {
        const int viewWeekStart = 1;
        const int viewWeekCount = 6;
        const string viewWeekname = "viewWeek";

        private string h年;
        private string h月;

        public delegate void viewDayClickofMonthHandler(string str);
        public event viewDayClickofMonthHandler ClickviewDayEvent;

        public viewMonth()
        {
            InitializeComponent();

            foreach (Control c in this.Controls)
            {
                if (c is viewWeek)
                {

                    viewWeek v = (viewWeek)(c);
                    v.ClickviewDayEvent += viewDay_Click;
                }

            }
        }

        private void viewDay_Click(string str)
        {
            if (ClickviewDayEvent != null) { ClickviewDayEvent(str); }
        }

        //カレンダーに月を渡してカレンダーを作成する
        public bool setCalender(int year,int month)
        {

            h年 = year.ToString();
            h月 = month.ToString();

            int count = 0;


            string[] ss = Makecompany.Career._datatime._func.getCalenderData(year, month, 42); 
            

            for(int i = viewWeekStart; i <= viewWeekCount; i++)
            {
                viewWeek vW = (viewWeek)this.Controls[viewWeekname + i.ToString()];
               
                for (int j = viewWeek.startvalue ; j<= viewWeek.weekdays ; j++)
                {

                    vW.setDay(j, h年, h月, ss[count], "");
                    count++;
                }

            }


            return true;

        }

        //日付に大科目情報を設定する
        public void set大科目情報(Dictionary<string,string> dic日付ごとの大科目)
        {
            foreach(KeyValuePair<string, string> pair in dic日付ごとの大科目)
            {
                for (int i = viewWeekStart; i <= viewWeekCount; i++)
                {
                    viewWeek vW = (viewWeek)this.Controls[viewWeekname + i.ToString()];

                    for (int j = viewWeek.startvalue; j <= viewWeek.weekdays; j++)
                    {
                        //日付型の比較は慎重を要するので
                        DateTime d1, d2;
                        bool b1, b2;

                        //日付に変換を試みる
                        b1 = DateTime.TryParse(pair.Key, out d1);
                        b2 = DateTime.TryParse(vW.getdate(j), out d2);

                        //空白の場合等、できないものはスキップする）
                        if (!b1 || !b2)
                        {
                            //なにもしない
                        }
                        else if(DateTime.Compare(d1,d2) ==0)
                        {
                            vW.setInfo(j, pair.Value);
                        }
                        else
                        { 
                            //なにもしない
                        }
                    }

                }


            }

        }

        //一日分を設定
        //public bool UpdateInfobyOneDay(dayInfo di)
        //{


        //    return true;
        //}
    }
}
