using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Esoft.HelperClass
{
    public class GroupCodeValidate
    {
        public DataTable CheckBpStatus(string mGroupCode, string db = "")
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            string con_str = System.Configuration.ConfigurationManager.ConnectionStrings["ESoft"].ToString();
            MasterMethods objMaster = new MasterMethods();
            try
            {
                DataTable dt = new DataTable();

                if (mGroupCode == "0" || mGroupCode == "00" || mGroupCode == "000" || mGroupCode == "X")
                {
                    dt = objMaster.GetDataTableBySp("1", db, "spGetBPCode", "@GROUPCODE", mGroupCode, "@ObjId", "OFFLINEBP", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                }
                else if (mGroupCode == "1" || mGroupCode == "11")
                {
                    dt = objMaster.GetDataTableBySp("1", db, "spGetBPCode", "@GROUPCODE", mGroupCode, "@ObjId", "OFFLINEBP", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                }
                else if (mGroupCode == "2")
                {
                    dt = objMaster.GetDataTableBySp("1", db, "spGetBPCode", "@GROUPCODE", mGroupCode, "@ObjId", "OFFLINEBP", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                }
                else if (mGroupCode != "")
                {
                    dt = objMaster.GetDataTableBySp("1", db, "spGetBPCode", "@GROUPCODE", mGroupCode, "@ObjId", "ONLINEBP", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                }
                else
                {
                    return null;
                }
                if (dt != null && dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch (Exception EX)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----Start Log-----");
                    writer.WriteLine("Method Name --> CheckBpStatus : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }

        public DataTable LoginByUserCodeNPwd(string misRemotServ, string musercode, string mpwd, string mcompid, string mmyMacAdd, string db = "")
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            MasterMethods objMaster = new MasterMethods();
            try
            {
                int b = 0;
                int a = 9 / b;
                DataTable dt = new DataTable();
                dt = objMaster.GetDataTableBySp(misRemotServ, db, "spGetuserwsCmpDiv", "@Objtyp", "LOGINBYCODEPWD", "@compid", mcompid, "@DivId", "", "", "", "", "", "@usercode", musercode, "@pwd", mpwd, "@myMacAdd", mmyMacAdd, "@Empid", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                if (dt != null && dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch (Exception EX)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----Start Log-----");
                    writer.WriteLine("Method Name --> LoginByUserCodeNPwd : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }
    }
}