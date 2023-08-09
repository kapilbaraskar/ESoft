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
        MasterMethods objMaster = new MasterMethods();
        Dictionary<string, object> resObj = new Dictionary<string, object>();

        [HttpPost]
        public HttpResponseMessage GetMenuData(Req_MenuData Obj)
        {
            DataTable dt = objMaster.GetMenuData(Obj);
            if(dt != null && dt.Rows.Count > 0)
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
    }
}
