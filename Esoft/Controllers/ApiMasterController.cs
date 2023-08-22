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
        String DBNAME = "";
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
            if(DBNAME != "")
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
    }
}
