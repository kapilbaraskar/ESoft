using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Esoft.HelperClass
{
    public class ContractMgmtMethods
    {
        String Qry = "";
        string DataSourceName = System.Configuration.ConfigurationManager.AppSettings["DataSourceName"].ToString();

        public DataTable GetContractMgmtData(string db, string CompId, string from_date, string to_date)
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
                    Qry = @"Select 
                            	TrId,ISNULL(CONVERT(varchar, DocDate, 106),'') as DocDate, ISNULL(BpName,'') as BpName, ISNULL(AmcTitle,'') as AmcTitle, 
                            	ISNULL(CONVERT(varchar, AmcSDate, 106),'') as AmcSDate, ISNULL(CONVERT(varchar, AmcEDate, 106),'') as AmcEDate ,ISNULL(CustRefNo,'') as CustRefNo,
                            	ISNULL(ToTQty,0)as ToTQty, ISNULL(dfTaxCode,'')as dfTaxCode, ISNULL(dfSacCode,'')As dfSacCode, ISNULL(KeyMgr,'')as KeyMgr, 
                                ISNULL(MgmFeePer,0) As MgmFeePer, AmcDsc 
                            From tAmc WITH (NOLOCK) ";
                    Qry += " Where CompId=" + CompId + " AND doctype = 'O' ";
                    if (from_date != null && from_date != "" && to_date != null && to_date != "")
                        Qry += " AND DocDate BETWEEN '"+ from_date + "' and '"+ from_date + "' ";
                    Qry += " Order By TrId DESC ";
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
                    writer.WriteLine("Method Name --> GetContractMgmtData : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                throw EX;
            }
        }
    }
}