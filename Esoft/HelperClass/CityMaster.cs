using Esoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Esoft.HelperClass
{
    public class CityMaster
    {
        String Qry = "";
        string DataSourceName = System.Configuration.ConfigurationManager.AppSettings["DataSourceName"].ToString();
        public DataTable GetDataForCityMasterTreeView(string db)
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            string con_str = "Data Source=" + DataSourceName + ";Initial Catalog=" + db + ";Integrated Security=true";
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(con_str))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.Connection = con;

                    Qry = "";
                    Qry = @"Select CityId, CityName, ParentId,RouteId From
                            (Select(stateid + 21000) CityId, StateName CityName, 0 ParentId,0 RouteId, 'State' as Lvl From mState 
                            union 
                            Select (Distid + 11000) CityId, UPPER(DistName) CityName, (stateid + 21000) ParentId,0 RouteId, 'Dist' as Lvl From mdist 
                            union 
                            Select (Cityid)CityId, CityName CityName, (Distid + 11000) ParentId,RouteId, 'City' as Lvl From mCity where DistId > 0 
                            union 
                            Select CityId, CityName, ParentId,RouteId, 'SubCity' as Lvl From mCity where ParentId > 0) t0 order by cityname";
                    objCommand.CommandText = Qry;
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
                    writer.WriteLine("Method Name --> GetDataForCityMasterTreeView : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }

        public DataSet GetDataForCityMasterDropDowns(string DfLocDetId, string db)
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            MasterMethods objMaster = new MasterMethods();
            try
            {
                string con_str = "Data Source=" + DataSourceName + ";Initial Catalog=" + db + ";Integrated Security=true";
                DataTable dt = new DataTable();

                //dt = objMaster.GetDataTableBySp("", db, "spGetTableData", "@ObjId", "MLOCT2", "@LocId", DfLocDetId, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

                //if (dt != null && dt.Rows.Count > 0)
                //{
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(con_str))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.Connection = con;

                    Qry = "";
                    Qry = @"Select GlAcId,GlName from mGlActMst where (GlType='C' or GlType='R') and isLocked='False' and islocked ='False' order by GLName
                                Select CityId, CityName from mCity where islocked ='False' order by CityName
                                Select StateId,StateName from mState order by StateName
                                Select CityId, CityName from mCity where islocked ='False' order by CityName
                                Select LocId, LocName from MLoct where islocked ='False' order by LocName
                                Select DistId, DistName from mDist where islocked ='False' order by DistName";
                    objCommand.CommandText = Qry;
                    SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                    objAdapter.TableMappings.Add("Table", "mGlActMst");
                    objAdapter.TableMappings.Add("Table1", "Route");
                    objAdapter.TableMappings.Add("Table2", "mState");
                    objAdapter.TableMappings.Add("Table3", "NodeText");
                    objAdapter.TableMappings.Add("Table4", "mLoc");
                    objAdapter.TableMappings.Add("Table5", "mDist");
                    objAdapter.Fill(ds);
                    if (ds != null && ds.Tables.Count > 0)
                        return ds;
                    else
                        return null;
                }
                //}
                //else
                //return null;
            }
            catch (Exception EX)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----Start Log-----");
                    writer.WriteLine("Method Name --> GetDataForCityMasterDropDowns : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }
        public DataSet SaveCityMasterData(CityMasterData Obj, string UserCode, string CompId, string db)
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            string con_str = "Data Source=" + DataSourceName + ";Initial Catalog=" + db + ";Integrated Security=true";
            try
            {
                using (SqlConnection con = new SqlConnection(con_str))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.Connection = con;

                    #region System Generated Booking Details
                    objCommand.Parameters.Clear();
                    if (Obj.EntryMode != null && Obj.EntryMode != "")
                        objCommand.Parameters.Add("@EntryMode", SqlDbType.VarChar).Value = Obj.EntryMode;
                    else
                        objCommand.Parameters.Add("@EntryMode", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.cityid != null && Obj.cityid != "")
                        objCommand.Parameters.Add("@cityid", SqlDbType.VarChar).Value = Obj.cityid;
                    else
                        objCommand.Parameters.Add("@cityid", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.CityName != null && Obj.CityName != "")
                        objCommand.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = Obj.CityName;
                    else
                        objCommand.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (Obj.CtAlias != null && Obj.CtAlias != "")
                        objCommand.Parameters.Add("@CtAlias", SqlDbType.NVarChar).Value = Obj.CtAlias;
                    else
                        objCommand.Parameters.Add("@CtAlias", SqlDbType.NVarChar).Value = DBNull.Value;

                    if (Obj.Zip != null && Obj.Zip != "")
                        objCommand.Parameters.Add("@Zip", SqlDbType.VarChar).Value = Obj.Zip;
                    else
                        objCommand.Parameters.Add("@Zip", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.DefDocChrgs != null && Obj.DefDocChrgs != "")
                        objCommand.Parameters.Add("@DefDocChrgs", SqlDbType.VarChar).Value = Obj.DefDocChrgs;
                    else
                        objCommand.Parameters.Add("@DefDocChrgs", SqlDbType.VarChar).Value = DBNull.Value;

                    objCommand.Parameters.Add("@usercode", SqlDbType.VarChar).Value = UserCode;

                    if (Obj.DfTransport != null && Obj.DfTransport != "")
                        objCommand.Parameters.Add("@DfTransport", SqlDbType.VarChar).Value = Obj.DfTransport;
                    else
                        objCommand.Parameters.Add("@DfTransport", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.isRoute != null && Obj.isRoute != "")
                        objCommand.Parameters.Add("@isRoute", SqlDbType.VarChar).Value = Obj.isRoute;
                    else
                        objCommand.Parameters.Add("@isRoute", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.isLocked != null && Obj.isLocked != "")
                        objCommand.Parameters.Add("@isLocked", SqlDbType.VarChar).Value = Obj.isLocked;
                    else
                        objCommand.Parameters.Add("@isLocked", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.isStation != null && Obj.isStation != "")
                        objCommand.Parameters.Add("@isStation", SqlDbType.VarChar).Value = Obj.isStation;
                    else
                        objCommand.Parameters.Add("@isStation", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.GlAcId != null && Obj.GlAcId != "")
                        objCommand.Parameters.Add("@GlAcId", SqlDbType.VarChar).Value = Obj.GlAcId;
                    else
                        objCommand.Parameters.Add("@GlAcId", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.StateId != null && Obj.StateId != "")
                        objCommand.Parameters.Add("@StateId", SqlDbType.VarChar).Value = Obj.StateId;
                    else
                        objCommand.Parameters.Add("@StateId", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.RouteId != null && Obj.RouteId != "")
                        objCommand.Parameters.Add("@RouteId", SqlDbType.VarChar).Value = Obj.RouteId;
                    else
                        objCommand.Parameters.Add("@RouteId", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.DeliveryAt != null && Obj.DeliveryAt != "")
                        objCommand.Parameters.Add("@DeliveryAt", SqlDbType.VarChar).Value = Obj.DeliveryAt;
                    else
                        objCommand.Parameters.Add("@DeliveryAt", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.DeliveryAdd != null && Obj.DeliveryAdd != "")
                        objCommand.Parameters.Add("@DeliveryAdd", SqlDbType.VarChar).Value = Obj.DeliveryAdd;
                    else
                        objCommand.Parameters.Add("@DeliveryAdd", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.ContactNo != null && Obj.ContactNo != "")
                        objCommand.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = Obj.ContactNo;
                    else
                        objCommand.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.ChargesUpTo != null && Obj.ChargesUpTo != "")
                        objCommand.Parameters.Add("@ChargesUpTo", SqlDbType.VarChar).Value = Obj.ChargesUpTo;
                    else
                        objCommand.Parameters.Add("@ChargesUpTo", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.isMultiRoute != null && Obj.isMultiRoute != "")
                        objCommand.Parameters.Add("@isMultiRoute", SqlDbType.VarChar).Value = Obj.isMultiRoute;
                    else
                        objCommand.Parameters.Add("@isMultiRoute", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.OrderNo != null && Obj.OrderNo != "")
                        objCommand.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = Obj.OrderNo;
                    else
                        objCommand.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.BusChg != null && Obj.BusChg != "")
                        objCommand.Parameters.Add("@BusChg", SqlDbType.VarChar).Value = Obj.BusChg;
                    else
                        objCommand.Parameters.Add("@BusChg", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.Distance != null && Obj.Distance != "")
                        objCommand.Parameters.Add("@Distance", SqlDbType.VarChar).Value = Obj.Distance;
                    else
                        objCommand.Parameters.Add("@Distance", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.Catg != null && Obj.Catg != "")
                        objCommand.Parameters.Add("@Catg", SqlDbType.VarChar).Value = Obj.Catg;
                    else
                        objCommand.Parameters.Add("@Catg", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.ParentId != null && Obj.ParentId != "")
                        objCommand.Parameters.Add("@ParentId", SqlDbType.VarChar).Value = Obj.ParentId;
                    else
                        objCommand.Parameters.Add("@ParentId", SqlDbType.VarChar).Value = DBNull.Value;

                    objCommand.Parameters.Add("@CompId", SqlDbType.VarChar).Value = CompId;

                    if (Obj.LocId != null && Obj.LocId != "")
                        objCommand.Parameters.Add("@LocId", SqlDbType.VarChar).Value = Obj.LocId;
                    else
                        objCommand.Parameters.Add("@LocId", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.DfToLocId != null && Obj.DfToLocId != "")
                        objCommand.Parameters.Add("@DfToLocId", SqlDbType.VarChar).Value = Obj.DfToLocId;
                    else
                        objCommand.Parameters.Add("@DfToLocId", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.DefDelComPer != null && Obj.DefDelComPer != "")
                        objCommand.Parameters.Add("@DefDelComPer", SqlDbType.VarChar).Value = Obj.DefDelComPer;
                    else
                        objCommand.Parameters.Add("@DefDelComPer", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.Remark != null && Obj.Remark != "")
                        objCommand.Parameters.Add("@Remark", SqlDbType.VarChar).Value = Obj.Remark;
                    else
                        objCommand.Parameters.Add("@Remark", SqlDbType.VarChar).Value = DBNull.Value;

                    if (Obj.DistId != null && Obj.DistId != "")
                        objCommand.Parameters.Add("@DistId", SqlDbType.VarChar).Value = Obj.DistId;
                    else
                        objCommand.Parameters.Add("@DistId", SqlDbType.VarChar).Value = DBNull.Value;

                    objCommand.CommandText = "spmcity";
                    objCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                    DataSet ds = new DataSet();
                    objAdapter.Fill(ds);
                    if (ds != null && ds.Tables.Count > 0)
                        return ds;
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
                    writer.WriteLine("Method Name --> SaveCityMasterData : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }

        public DataTable GetCityMasterData(string cityid, string db)
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            MasterMethods objMaster = new MasterMethods();
            try
            {
                string con_str = "Data Source=" + DataSourceName + ";Initial Catalog=" + db + ";Integrated Security=true";
                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(con_str))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.Connection = con;

                    Qry = "";
                    Qry = "Select * from mCity ";
                    if(cityid != null && cityid != "")
                        Qry += "Where CityId = '"+ cityid + "'";
                    Qry += "order by CityName";
                    objCommand.CommandText = Qry;
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
                    writer.WriteLine("Method Name --> GetCityMasterData : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }
    }
}