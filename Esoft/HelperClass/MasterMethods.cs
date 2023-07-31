using Esoft.BLL;
using Esoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace Esoft.HelperClass
{
    public class MasterMethods : ServerBase
    {
        public DataTable GetMenuData(Req_MenuData Obj)
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            try
            {
                if (objConnection.State != ConnectionState.Open)
                    objConnection.Open();
                objCommand.Connection = objConnection;
                DataSet ds = new DataSet();

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
                objAdapter.SelectCommand = objCommand;
                objAdapter.Fill(ds);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                    return null;
                #endregion
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
            finally
            {
                if (objConnection.State == ConnectionState.Open)
                    objConnection.Close();
            }
        }
    }
}