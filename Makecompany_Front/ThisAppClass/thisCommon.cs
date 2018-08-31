using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makecompany_Front.ThisAppClass
{
    class thisCommon
    {

        public Makecompany.Career.SqlClient.doSQL m_接続済みSQLクラス提供()
        {

            var result = new List<Dictionary<string, object>>();
            var dox = new Makecompany.Career.doXML("");
            var c = new Makecompany.Career.SqlClient.doSQL(dox.SQL_Server, dox.DB_Name, dox.UserID, dox.Password);

            return c;
        }

    }
}
