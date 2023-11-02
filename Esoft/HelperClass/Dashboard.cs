using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Esoft.HelperClass
{
    public class Dashboard
    {
        string DataSourceName = System.Configuration.ConfigurationManager.AppSettings["DataSourceName"].ToString();
        public DataSet GetDataForDashboard(string Ind, string PROJCODE, string db)
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            string con_str = "Data Source=" + DataSourceName + ";Initial Catalog=" + db + ";Integrated Security=true";
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(con_str))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.Connection = con;

                    objCommand.Parameters.Clear();
                    if (Ind != null && Ind != "")
                        objCommand.Parameters.Add("@Ind", SqlDbType.VarChar).Value = Ind;
                    else
                        objCommand.Parameters.Add("@Ind", SqlDbType.VarChar).Value = "";

                    if (PROJCODE != null && PROJCODE != "")
                        objCommand.Parameters.Add("@PROJCODE", SqlDbType.VarChar).Value = PROJCODE;
                    else
                        objCommand.Parameters.Add("@PROJCODE", SqlDbType.VarChar).Value = "";

                    objCommand.CommandText = "WSP_Dashboard";
                    objCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                    objAdapter.Fill(ds);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        return ds;
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----Start Log-----");
                    writer.WriteLine("Method Name --> GetDataForDashboard : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }
    }
}