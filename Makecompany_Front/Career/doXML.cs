using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq; 

namespace Makecompany.Career
{
    class doXML
    {
        public string DSN="";
        public string Driver = "";
        public string SQL_Server = "";
        public string DB_Name = "";
        public string UserID = "";
        public string Password = "";


        public doXML(string filename)
        {
            //XElement xe = XElement.Load("Class\\Makecompany\\Makecompany.xml");
            XElement xe = XElement.Load("Career\\Makecompany.xml");


            var q = from p in xe.Descendants("ODBC") select p;

            foreach (XElement n in q)
            {
                //複数記載がある場合は上書きします
                DSN = n.Element("DSN").Value;
                Driver = n.Element("Driver").Value;
                SQL_Server = n.Element("SQL_Server").Value;
                DB_Name = n.Element("DB_Name").Value;
                UserID = n.Element("UserID").Value;
                Password = n.Element("Password").Value;

            }
        }

        public void SetRegstry()
        {
            XElement xe = XElement.Load("Career\\Makecompany.xml");

            //レジストリ
            var c = new doRegstry();

            var q = from p in xe.Descendants("Regstry") select p; 

            foreach(XElement n in q)
            {
                c.CreateValue(doRegstry.TopPath.CurrentUser,n.Element("path").Value , n.Element("name").Value, n.Element("value").Value); 
            }
        }

    }
}
