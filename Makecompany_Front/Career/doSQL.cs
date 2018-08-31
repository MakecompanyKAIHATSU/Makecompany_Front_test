using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
 

namespace Makecompany.Career
{
    namespace SqlClient
    {

    
        class doSQL:IDisposable 
        {
            SqlConnection conn = new SqlConnection() ;
            SqlCommand comm = new SqlCommand() ;

            public doSQL(string SQL_Server, string DB_Name, string UserID , string Password)
            {

                conn.ConnectionString = "Data Source = " + SQL_Server 
                    + ";Initial Catalog = " + DB_Name 
                    + ";User ID = " + UserID 
                    + ";Password = " + Password; 
             
            }

            public void test()
            {
                try
                {
                    conn.Open();
                }
                catch(Exception ex) { throw ex; }
                finally { connclose(); }
            }

            public void exec(string strSQL)
            {
                conn.Open();
                var trans = conn.BeginTransaction();

                try
                {
                    comm = new SqlCommand(strSQL, conn, trans);
                     
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }

                trans.Commit();
            }

            public void INSERT_INTO(string h_テーブル名,List<string> h_フィールド名s, List<Dictionary<string,object>> VALUEs)
            {

                データcheck(h_フィールド名s, VALUEs);

                conn.Open();
                //トランザクションの開始
                var trans = conn.BeginTransaction();

                try
                {
                    foreach (var v in VALUEs)
                    {
                        StringBuilder sb = new StringBuilder();
                        const string h_INSERT句 = "INSERT INTO ";

                        sb.Append(h_INSERT句);
                        sb.Append(h_テーブル名);
                        sb.Append("(");

                        //INSERT句テーブル側の作成
                        foreach (var s in h_フィールド名s)
                        {
                            sb.Append(s);
                            sb.Append(",");
                        }

                        //最後の","が邪魔
                        sb.Remove(sb.Length - 1, 1);

                        //INSERT句VALUES側の作成
                        sb.Append(") VALUES(");

                        foreach (var s in h_フィールド名s)
                        {
                            sb.Append("@" + s);
                            sb.Append(",");
                        }

                        //最後の","が邪魔
                        sb.Remove(sb.Length-1, 1);

                        sb.Append(")");

                        comm = new SqlCommand(sb.ToString() , conn, trans);

                        foreach (var s in h_フィールド名s)
                        {
                            var param = new SqlParameter("@" + s, v[s]);
                            comm.Parameters.Add(param);
                        }

                        comm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { trans.Rollback(); connclose(); throw ex; }

                trans.Commit();
                connclose(); ;

                //command.CommandText = @"INSERT INTO T_USER (ID, PASSWORD) VALUES (@ID, @PASSWORD)";
                //StringBuilder d 

            }

            private void データcheck(List<string> h_フィールド名s, List<Dictionary<string,object>> VALUEs)
            { 
                InvalidOperationException ex = new InvalidOperationException();

                //値の組み合わせが、１件でもおかしければエラーで処理をやめる
                foreach (var v in VALUEs)
                {
                    if (v.Count != h_フィールド名s.Count) { throw (ex); }
                }

            
            }

            public void UPDATE(string h_テーブル名, List<string> h_フィールド名s, List<string> h_WHEREフィールド名s, List<Dictionary<string, object>> VALUEs)
            {

                データcheck(h_フィールド名s, VALUEs);

                conn.Open();
                //トランザクションの開始
                var trans = conn.BeginTransaction();

                try
                {
                    foreach (var v in VALUEs)
                    {
                        StringBuilder sb = new StringBuilder();
                        const string h_UPDATE句 = "UPDATE ";

                        sb.Append(h_UPDATE句);
                        sb.Append(h_テーブル名);
                        sb.Append(" SET ");

                        //INSERT句テーブル側の作成
                        foreach (var s in h_フィールド名s)
                        {
                            sb.Append(s);
                            sb.Append("=");
                            sb.Append("@" + s);
                            sb.Append(",");
                        }

                        //最後の","が邪魔
                        sb.Remove(sb.Length - 1, 1);

                        //WHERE側の作成
                        sb.Append(" WHERE ");
                        string _and = " AND ";

                        foreach (var s in h_WHEREフィールド名s)
                        {
                            sb.Append(s);
                            sb.Append("=");
                            sb.Append("@" + s);
                            sb.Append(_and);
                        }

                        //最後の" AND "が邪魔
                        sb.Remove(sb.Length - _and.Length, _and.Length);

                        //sb.Append(")");

                        comm = new SqlCommand(sb.ToString(), conn, trans);

                        foreach (var s in h_フィールド名s)
                        {
                            var param = new SqlParameter("@" + s, v[s]);
                            comm.Parameters.Add(param);
                        }

                        comm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { trans.Rollback(); connclose(); throw ex; }

                trans.Commit();
                connclose(); ;

                //command.CommandText = @"INSERT INTO T_USER (ID, PASSWORD) VALUES (@ID, @PASSWORD)";
                //StringBuilder d 

            }

            private void INSERTString(SqlCommand comm , string h_テーブル名, List<string> h_フィールド名s, Dictionary<string,object> v)
            {
                const string h_INSERT句 = "INSERT INTO ";

                comm.CommandText = h_INSERT句 + h_テーブル名 + "(" ;

                //INSERT句テーブル側の作成
                foreach(var s in h_フィールド名s)
                {
                    comm.CommandText = comm.CommandText + s + ",";
                }

                //最後の","が邪魔
                comm.CommandText = comm.CommandText.Substring(0,comm.CommandText.Length - 1);

                //INSERT句VALUES側の作成
                comm.CommandText = comm.CommandText + ") VALUES(";
                foreach (var s in h_フィールド名s)
                {
                    comm.CommandText = comm.CommandText + "@" + s + ",";
                }

                //最後の","が邪魔
                comm.CommandText = comm.CommandText.Substring(0, comm.CommandText.Length - 1);

                comm.CommandText = comm.CommandText + ")";

                comm.CommandText = @comm.CommandText;

                foreach (var s in h_フィールド名s)
                {
                    comm.Parameters.Add(new SqlParameter("@" + s, v[s]));
                }

                comm.ExecuteNonQuery(); 
            }


            public List<string> getFieldName(string sTableName)
            {


                try{

                    string SQLstring ;

                    SQLstring = "Select Top 1 * From " + sTableName;

                    conn.Open();
                    comm = new SqlCommand(SQLstring, conn);
                    SqlDataReader b = comm.ExecuteReader();
                    List<string> c = new List<string>();

                    for (int i = 0; i < b.FieldCount; i++)
                    {
                        c.Add(b.GetName(i));
                    }

                    return c;

                }
                catch { return null; }
                finally { connclose(); }


            }


            /*
             * 現在接続しているデータベースのテーブル一覧を取得する
             */
            public List<string> getTableNameList()
            {
                try
                {
                    conn.Open();

                    var ls = new List<string>();
                    System.Data.DataTable d = conn.GetSchema("Tables");

                    for (int i = 0; i <= d.Rows.Count - 1; i++)
                    {

                        ls.Add(d.Rows[i]["TABLE_NAME"].ToString());

                    }

                    return ls;
                }
                catch { return null; }
                finally { connclose(); }
            }



            public List<Dictionary<string, object>> Select(string SQLstring)
            {

                try
                {

                    conn.Open();
                    comm = new SqlCommand(SQLstring, conn);
                    SqlDataReader b = comm.ExecuteReader();
                    List<Dictionary<string, object>> c = new List<Dictionary<string, object>>();
                    Dictionary<string, object> d = new Dictionary<string, object>();

                    while (b.Read())
                    {
                        d = new Dictionary<string, object>();

                        for (int i = 0; i < b.FieldCount; i++)
                        {
                            d.Add(b.GetName(i), b.GetValue(i));
                        }

                        c.Add(d);
                    }

                    return c;
                }
                catch(Exception ex) { throw ex; }
                finally
                {
                    connclose();
                }  

            }

            private void connclose()
            {
                if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            }

            public void Dispose()
            {

                conn.Dispose();


                //throw new NotImplementedException();
            }
        }
    }
}
