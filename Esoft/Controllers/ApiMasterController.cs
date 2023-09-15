using Esoft.BLL;
using Esoft.HelperClass;
using Esoft.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Esoft.Controllers
{
    public class ApiMasterController : ApiController
    {
        String DBNAME = "", UserCode = "", CompId = "";
        MasterMethods objMaster = new MasterMethods();
        Dictionary<string, object> resObj = new Dictionary<string, object>();

        [HttpPost]
        public HttpResponseMessage GetMenuData(Req_MenuData Obj)
        {
            IEnumerable<string> DB_NAME;
            if (Request.Headers.TryGetValues("DBNAME", out DB_NAME))
            {
                DBNAME = ((string[])DB_NAME)[0].ToString();
            }
            if (DBNAME != "")
            {
                DataTable dt = objMaster.GetMenuData(Obj, DBNAME);
                if (dt != null && dt.Rows.Count > 0)
                {
                    resObj["status"] = 1;
                    resObj["message"] = dt;
                }
                else
                {
                    resObj["status"] = 0;
                    resObj["message"] = "Data Not Found.";
                }
            }
            else
            {
                resObj["status"] = 0;
                resObj["message"] = "Database not found.";
            }
            return GeneralUtil.SetHttpResponseMessage(JsonConvert.SerializeObject(resObj));
        }

        [HttpGet]
        public HttpResponseMessage ValidateGroupCode(String GroupCode)
        {
            GroupCodeValidate obj = new GroupCodeValidate();
            DataTable dt = obj.CheckBpStatus(GroupCode);
            if (dt != null && dt.Rows.Count > 0)
            {
                resObj["status"] = 1;
                resObj["message"] = dt;
            }
            else
            {
                resObj["status"] = 0;
                resObj["message"] = "Data Not Found.";
            }
            return GeneralUtil.SetHttpResponseMessage(JsonConvert.SerializeObject(resObj));
        }

        [HttpGet]
        public HttpResponseMessage LoginByUserCodeNPwd(String musercode, String mpwd)
        {
            IEnumerable<string> DB_NAME;
            if (Request.Headers.TryGetValues("DBNAME", out DB_NAME))
            {
                DBNAME = ((string[])DB_NAME)[0].ToString();
            }
            if (DBNAME != "")
            {
                GroupCodeValidate obj = new GroupCodeValidate();
                DataTable dt = obj.LoginByUserCodeNPwd("", musercode, mpwd, "1", "", DBNAME);
                if (dt != null && dt.Rows.Count > 0)
                {
                    resObj["status"] = 1;
                    resObj["message"] = dt;
                }
                else
                {
                    resObj["status"] = 0;
                    resObj["message"] = "Wrong Credential.";
                }
            }
            else
            {
                resObj["status"] = 0;
                resObj["message"] = "Database not found.";
            }
            return GeneralUtil.SetHttpResponseMessage(JsonConvert.SerializeObject(resObj));
        }

        [HttpGet]
        public HttpResponseMessage GetDataForDashboard(String Ind, String PROJCODE)
        {
            IEnumerable<string> DB_NAME;
            if (Request.Headers.TryGetValues("DBNAME", out DB_NAME))
            {
                DBNAME = ((string[])DB_NAME)[0].ToString();
            }
            if (DBNAME != "")
            {
                Dashboard obj = new Dashboard();
                DataSet ds = obj.GetDataForDashboard(Ind, PROJCODE, DBNAME);
                if (ds != null && ds.Tables.Count > 0)
                {
                    resObj["status"] = 1;
                    resObj["message"] = ds;
                }
                else
                {
                    resObj["status"] = 0;
                    resObj["message"] = "Data not found.";
                }
            }
            else
            {
                resObj["status"] = 0;
                resObj["message"] = "Database not found.";
            }
            return GeneralUtil.SetHttpResponseMessage(JsonConvert.SerializeObject(resObj));
        }

        [HttpGet]
        public HttpResponseMessage GetDataForCityMasterTreeView()
        {
            IEnumerable<string> DB_NAME;
            if (Request.Headers.TryGetValues("DBNAME", out DB_NAME))
            {
                DBNAME = ((string[])DB_NAME)[0].ToString();
            }
            if (DBNAME != "")
            {
                CityMaster obj = new CityMaster();
                DataTable dt = obj.GetDataForCityMasterTreeView(DBNAME);
                if (dt != null && dt.Rows.Count > 0)
                {
                    resObj["status"] = 1;
                    resObj["message"] = dt;
                }
                else
                {
                    resObj["status"] = 0;
                    resObj["message"] = "Data not found.";
                }
            }
            else
            {
                resObj["status"] = 0;
                resObj["message"] = "Database not found.";
            }
            return GeneralUtil.SetHttpResponseMessage(JsonConvert.SerializeObject(resObj));
        }

        [HttpGet]
        public HttpResponseMessage GetDataForCityMasterDropDowns(String DfLocDetId)
        {
            IEnumerable<string> DB_NAME;
            if (Request.Headers.TryGetValues("DBNAME", out DB_NAME))
            {
                DBNAME = ((string[])DB_NAME)[0].ToString();
            }
            if (DBNAME != "")
            {
                CityMaster obj = new CityMaster();
                DataSet ds = obj.GetDataForCityMasterDropDowns(DfLocDetId, DBNAME);
                if (ds != null && ds.Tables.Count > 0)
                {
                    resObj["status"] = 1;
                    resObj["message"] = ds;
                }
                else
                {
                    resObj["status"] = 0;
                    resObj["message"] = "Data not found.";
                }
            }
            else
            {
                resObj["status"] = 0;
                resObj["message"] = "Database not found.";
            }
            return GeneralUtil.SetHttpResponseMessage(JsonConvert.SerializeObject(resObj));
        }

        [HttpPost]
        public HttpResponseMessage SaveCityMasterData(CityMasterData data)
        {
            string result = "";
            IEnumerable<string> DB_NAME;
            IEnumerable<string> User_Code;
            IEnumerable<string> Comp_Id;
            if (Request.Headers.TryGetValues("DBNAME", out DB_NAME))
            {
                DBNAME = ((string[])DB_NAME)[0].ToString();
            }
            if (Request.Headers.TryGetValues("UserCode", out User_Code))
            {
                UserCode = ((string[])User_Code)[0].ToString();
            }
            if (Request.Headers.TryGetValues("CompId", out Comp_Id))
            {
                CompId = ((string[])Comp_Id)[0].ToString();
            }
            if (DBNAME != "")
            {
                CityMaster obj = new CityMaster();
                DataSet ds = new DataSet();
                ds = obj.SaveCityMasterData(data, UserCode, CompId, DBNAME);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows[0]["cityid"].ToString() != "0")
                {
                    resObj["status"] = 1;
                    resObj["message"] = "data save successfully.";
                }
                else
                {
                    resObj["status"] = 0;
                    resObj["message"] = "Something went wrong.";
                }
            }
            else
            {
                resObj["status"] = 0;
                resObj["message"] = "Database not found.";
            }
            return GeneralUtil.SetHttpResponseMessage(JsonConvert.SerializeObject(resObj));
        }
    }
}
