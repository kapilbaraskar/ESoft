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
        public DataTable GetDataForCityMasterTreeView(string db)
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            string con_str = System.Configuration.ConfigurationManager.ConnectionStrings[db].ToString();
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
                string con_str = System.Configuration.ConfigurationManager.ConnectionStrings[db].ToString();
                DataTable dt = new DataTable();

                dt = objMaster.GetDataTableBySp("", db, "spGetTableData", "@ObjId", "MLOCT2", "@LocId", "1", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

                if (dt != null && dt.Rows.Count > 0)
                {
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
                }
                else
                    return null;
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
    }
}