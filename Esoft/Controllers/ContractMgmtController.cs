using Esoft.BLL;
using Esoft.HelperClass;
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
    public class ContractMgmtController : ApiController
    {
        String DBNAME = "", UserCode = "", CompId = "";
        Dictionary<string, object> resObj = new Dictionary<string, object>();

        [HttpGet]
        public HttpResponseMessage GetDataForCityMasterTreeView(string from_date = "", string to_date = "")
        {
            IEnumerable<string> DB_NAME;
            IEnumerable<string> Comp_Id;
            if (Request.Headers.TryGetValues("DBNAME", out DB_NAME))
            {
                DBNAME = ((string[])DB_NAME)[0].ToString();
            }
            if (Request.Headers.TryGetValues("CompId", out Comp_Id))
            {
                CompId = ((string[])Comp_Id)[0].ToString();
            }
            if (DBNAME != "")
            {
                ContractMgmtMethods obj = new ContractMgmtMethods();
                DataTable dt = obj.GetContractMgmtData(DBNAME, CompId, from_date, to_date);
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
                resObj["message"] = "Database Not Found.";
            }
            return GeneralUtil.SetHttpResponseMessage(JsonConvert.SerializeObject(resObj));
        }
    }
}
