using Esoft.BLL;
using Esoft.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Esoft.HelperClass
{
    public class MasterMethods
    {
        string DataSourceName = System.Configuration.ConfigurationManager.AppSettings["DataSourceName"].ToString();
        public DataTable GetMenuData(Req_MenuData Obj, string db)
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

                    #region System Generated Booking Details
                    objCommand.Parameters.Clear();
                    if (Obj.ObjId != null && Obj.ObjId != "")
                        objCommand.Parameters.Add("@ObjId", SqlDbType.VarChar).Value = Obj.ObjId;
                    else
                        objCommand.Parameters.Add("@ObjId", SqlDbType.VarChar).Value = "";

                    if (Obj.TableId != null && Obj.TableId != "")
                        objCommand.Parameters.Add("@TableId", SqlDbType.VarChar).Value = Obj.TableId;
                    else
                        objCommand.Parameters.Add("@TableId", SqlDbType.VarChar).Value = "";

                    if (Obj.DateFrom != null && Obj.DateFrom != "")
                        objCommand.Parameters.Add("@DateFrom", SqlDbType.VarChar).Value = Obj.DateFrom;
                    else
                        objCommand.Parameters.Add("@DateFrom", SqlDbType.VarChar).Value = "";

                    if (Obj.DateTo != null && Obj.DateTo != "")
                        objCommand.Parameters.Add("@DateTo", SqlDbType.VarChar).Value = Obj.DateTo;
                    else
                        objCommand.Parameters.Add("@DateTo", SqlDbType.VarChar).Value = "";

                    if (Obj.KeyVal != null && Obj.KeyVal != "")
                        objCommand.Parameters.Add("@KeyVal", SqlDbType.VarChar).Value = Obj.KeyVal;
                    else
                        objCommand.Parameters.Add("@KeyVal", SqlDbType.VarChar).Value = "";

                    if (Obj.LocId != null && Obj.LocId != "")
                        objCommand.Parameters.Add("@LocId", SqlDbType.VarChar).Value = Obj.LocId;
                    else
                        objCommand.Parameters.Add("@LocId", SqlDbType.VarChar).Value = "";

                    if (Obj.ParentLocId != null && Obj.ParentLocId != "")
                        objCommand.Parameters.Add("@ParentLocId", SqlDbType.VarChar).Value = Obj.ParentLocId;
                    else
                        objCommand.Parameters.Add("@ParentLocId", SqlDbType.VarChar).Value = "";

                    if (Obj.ClusterId != null && Obj.ClusterId != "")
                        objCommand.Parameters.Add("@ClusterId", SqlDbType.VarChar).Value = Obj.ClusterId;
                    else
                        objCommand.Parameters.Add("@ClusterId", SqlDbType.VarChar).Value = "";

                    if (Obj.CityId != null && Obj.CityId != "")
                        objCommand.Parameters.Add("@CityId", SqlDbType.VarChar).Value = Obj.CityId;
                    else
                        objCommand.Parameters.Add("@CityId", SqlDbType.VarChar).Value = "";

                    if (Obj.BpId != null && Obj.BpId != "")
                        objCommand.Parameters.Add("@BpId", SqlDbType.VarChar).Value = Obj.BpId;
                    else
                        objCommand.Parameters.Add("@BpId", SqlDbType.VarChar).Value = "";

                    if (Obj.SBpId != null && Obj.SBpId != "")
                        objCommand.Parameters.Add("@SBpId", SqlDbType.VarChar).Value = Obj.SBpId;
                    else
                        objCommand.Parameters.Add("@SBpId", SqlDbType.VarChar).Value = "";

                    if (Obj.Others != null && Obj.Others != "")
                        objCommand.Parameters.Add("@Others", SqlDbType.VarChar).Value = Obj.Others;
                    else
                        objCommand.Parameters.Add("@Others", SqlDbType.VarChar).Value = "";

                    if (Obj.CompId != null && Obj.CompId != "")
                        objCommand.Parameters.Add("@CompId", SqlDbType.VarChar).Value = Obj.CompId;
                    else
                        objCommand.Parameters.Add("@CompId", SqlDbType.VarChar).Value = "";

                    if (Obj.DivId != null && Obj.DivId != "")
                        objCommand.Parameters.Add("@DivId", SqlDbType.VarChar).Value = Obj.DivId;
                    else
                        objCommand.Parameters.Add("@DivId", SqlDbType.VarChar).Value = "";

                    if (Obj.UserCode != null && Obj.UserCode != "")
                        objCommand.Parameters.Add("@UserCode", SqlDbType.VarChar).Value = Obj.UserCode;
                    else
                        objCommand.Parameters.Add("@UserCode", SqlDbType.VarChar).Value = "";

                    if (Obj.finyrid != null && Obj.finyrid != "")
                        objCommand.Parameters.Add("@finyrid", SqlDbType.VarChar).Value = Obj.finyrid;
                    else
                        objCommand.Parameters.Add("@finyrid", SqlDbType.VarChar).Value = "";

                    if (Obj.isLocalUser != null && Obj.isLocalUser != "")
                        objCommand.Parameters.Add("@isLocalUser", SqlDbType.VarChar).Value = Obj.isLocalUser;
                    else
                        objCommand.Parameters.Add("@isLocalUser", SqlDbType.VarChar).Value = "";

                    if (Obj.isLocalCity != null && Obj.isLocalCity != "")
                        objCommand.Parameters.Add("@isLocalCity", SqlDbType.VarChar).Value = Obj.isLocalCity;
                    else
                        objCommand.Parameters.Add("@isLocalCity", SqlDbType.VarChar).Value = "";

                    if (Obj.myMacId != null && Obj.myMacId != "")
                        objCommand.Parameters.Add("@myMacId", SqlDbType.VarChar).Value = Obj.myMacId;
                    else
                        objCommand.Parameters.Add("@myMacId", SqlDbType.VarChar).Value = "";

                    objCommand.CommandText = "spGetTableData";
                    objCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                    objAdapter.Fill(ds);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                    else
                        return null;
                    #endregion
                }
            }
            catch (Exception EX)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----Start Log-----");
                    writer.WriteLine("Method Name --> GetMenuData : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }

        public DataTable GetDataTableBySp(string misRemotServ, string db, string spName, string para1, string value1, string para2, string value2,
            string para3, string value3, string para4, string dtpvalue4, string para5,
            string dtpvalue5, string para6, string value6, string para7, string value7,
            string para8, string value8, string para9, string value9,
            string para10, string value10, string para11, string value11,
            string para12, string value12, string para13, string value13,
            string para14, string value14, string para15, string value15,
            string para16, string value16, string para17, string value17, string para18, string value18,
            string para19, string value19, string para20, string value20, string para21, string value21,
            string para22, string value22, string para23, string value23, string para24, string value24,
            string para25, string value25, string para26, string value26)
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            string con_str = "";
            if (misRemotServ == "")
            { 
                con_str = "Data Source="+ DataSourceName + ";Initial Catalog="+db+";Integrated Security=true";
            }
            else
            {
                con_str = System.Configuration.ConfigurationManager.ConnectionStrings["ESoft"].ToString();
            }
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(con_str))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.Connection = con;

                    if (para1 != "") { objCommand.Parameters.AddWithValue(para1, value1); }
                    if (para2 != "") { objCommand.Parameters.AddWithValue(para2, value2); }
                    if (para3 != "") { objCommand.Parameters.AddWithValue(para3, value3); }
                    if (para4 != "") { objCommand.Parameters.AddWithValue(para4, dtpvalue4); }
                    if (para5 != "") { objCommand.Parameters.AddWithValue(para5, dtpvalue5); }
                    if (para6 != "") { objCommand.Parameters.AddWithValue(para6, value6); }
                    if (para7 != "") { objCommand.Parameters.AddWithValue(para7, value7); }
                    if (para8 != "") { objCommand.Parameters.AddWithValue(para8, value8); }
                    if (para9 != "") { objCommand.Parameters.AddWithValue(para9, value9); }
                    if (para10 != "") { objCommand.Parameters.AddWithValue(para10, value10); }
                    if (para11 != "") { objCommand.Parameters.AddWithValue(para11, value11); }
                    if (para12 != "") { objCommand.Parameters.AddWithValue(para12, value12); }
                    if (para13 != "") { objCommand.Parameters.AddWithValue(para13, value13); }
                    if (para14 != "") { objCommand.Parameters.AddWithValue(para14, value14); }
                    if (para15 != "") { objCommand.Parameters.AddWithValue(para15, value15); }
                    if (para16 != "") { objCommand.Parameters.AddWithValue(para16, value16); }
                    if (para17 != "") { objCommand.Parameters.AddWithValue(para17, value17); }
                    if (para18 != "") { objCommand.Parameters.AddWithValue(para18, value18); }
                    if (para19 != "") { objCommand.Parameters.AddWithValue(para19, value19); }
                    if (para20 != "") { objCommand.Parameters.AddWithValue(para20, value20); }
                    if (para21 != "") { objCommand.Parameters.AddWithValue(para21, value21); }
                    if (para22 != "") { objCommand.Parameters.AddWithValue(para22, value22); }
                    if (para23 != "") { objCommand.Parameters.AddWithValue(para23, value23); }
                    if (para24 != "") { objCommand.Parameters.AddWithValue(para24, value24); }
                    if (para25 != "") { objCommand.Parameters.AddWithValue(para25, value25); }

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = spName;
                    SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                    objAdapter.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                        return dt;
                    else
                        return null;
                }
            }
            catch (Exception EX)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----Start Log-----");
                    writer.WriteLine("Method Name --> GetDataTableBySp : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }
    }
}