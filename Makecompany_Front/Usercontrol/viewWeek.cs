using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makecompany
{
    public partial class viewWeek : UserControl
    {

        private string h年;
        private string h月;

        public const int startvalue = 1;
        public const int weekdays = 7;

        private const string viewDayname = "viewDay";

        private Dictionary<string, viewDay> dic曜日 = new Dictionary<string, viewDay>();

        public delegate void viewDayClickofWeekHandler(string str);
        public event viewDayClickofWeekHandler ClickviewDayEvent;


        public viewWeek()
        {
            InitializeComponent();

            viewDay1.BackColor = Color.Plum; 
            viewDay2.BackColor = Color.White;
            viewDay3.BackColor = Color.White;
            viewDay4.BackColor = Color.White;
            viewDay5.BackColor = Color.White;
            viewDay6.BackColor = Color.White;
            viewDay7.BackColor = Color.PowderBlue;

            
            foreach(Control c in this.Controls)
            {
                if (c is viewDay)
                {

                    viewDay v = (viewDay)(c);
                    v.ClickAllControls += viewDayClick; 
                }

            }
        }


        public bool setDay(int weekday,string Year, string Month, string day, string info)
        {
            if(weekday > weekdays)
            {
                return false;
            }
            else
            { 
                viewDay vD = (viewDay)this.Controls[viewDayname + weekday.ToString()];
                setday(vD, Year, Month, day, info);
                return true;
            }
        }



        private void setday(viewDay v,string y,string M,string d,string Info)
        {
            v.setView(y, M, d, Info);

            string ymd = y + "/" + M + "/" +d;

            //if (!dic曜日.ContainsKey(ymd)) { dic曜日.Add(ymd, v); }  

        }

        public string getdate(int weekday)
        {
            viewDay vD = (viewDay)this.Controls[viewDayname + weekday.ToString()];
            return vD.getdate();
             
        }

        public void setInfo(int weekday,string str大科目番号)
        {

            viewDay vD = (viewDay)this.Controls[viewDayname + weekday.ToString()];
            vD.setView(str大科目番号); 

        }


        private void viewDayClick(string str)
        {
            if (ClickviewDayEvent != null) { ClickviewDayEvent(str); }
        }

    }
}
