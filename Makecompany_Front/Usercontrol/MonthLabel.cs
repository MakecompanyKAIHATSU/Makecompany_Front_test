using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Makecompany_Front.Usercontrol
{
    public partial class MonthLabel : UserControl
    {
        private int startdate = 1;

        public MonthLabel()
        {
            InitializeComponent();
        }

        public void setYM(int y,int m)
        {
            CultureInfo culture = new CultureInfo("ja-JP", true);
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            DateTime target = new DateTime(y, m, startdate);
            string result = target.ToString("ggyy年M月", culture);
            txtYearMonth.Text = result;

        }
    }
}
