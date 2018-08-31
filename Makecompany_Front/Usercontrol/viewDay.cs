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

    public partial class viewDay : UserControl
    {

        private string ymd;
        public delegate void viewDayClickHandler(string str);
        public event viewDayClickHandler ClickAllControls;

        public viewDay()
        {
            InitializeComponent();
            lblDay.Click += viewDay_Click;
            lblInfo.Click += viewDay_Click;
            this.Click += viewDay_Click;
        } 

        //public string day {set{this.lblDay.Text = value;}}
        //public string info { set { this.lblInfo.Text  = value; } }
        public void setView(string year,string month,string day,string info)
        {
            this.lblDay.Text = day ;
            this.lblInfo.Text = info;
            this.ymd = year + "/" + month + "/" + day;
        }

        public void setView(string info)
        {
            this.lblInfo.Text = info;
        }

        public string getdate()
        {
            return this.ymd;
        }

        private void viewDay_Click(object sender, EventArgs e)
        {
            if (ClickAllControls != null) { ClickAllControls(this.ymd); }
        }
    }
}
