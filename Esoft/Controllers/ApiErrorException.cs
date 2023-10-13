using Esoft.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Esoft.Controllers
{
    public class ApiErrorException : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            #region Variable Declaration     
            Log objLog = new Log();
            string user = "";
            Int32 Error_Log = 0;
            var httpRequest = HttpContext.Current.Request;
            
            String DBNAME = httpRequest.Headers.Get("DBNAME");
            
            #endregion

            const int MaxLength = 50000;
            String ReturnType = filterContext.ActionContext.ActionDescriptor.ReturnType.Name.ToString();
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            //IEnumerable<string> vals;
            //filterContext.Request.Headers.TryGetValues("user_id", out vals);
            //user = vals?.FirstOrDefault();

            var exceptionMessage = filterContext.Exception.Message;
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(exceptionMessage);
                writer.Close();
            }

            var stackTrace = filterContext.Exception.StackTrace;
            var controllerName = filterContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionContext.ActionDescriptor.ActionName;

            if (stackTrace.Length > MaxLength)
                stackTrace = stackTrace.Substring(0, MaxLength);

            if (exceptionMessage.Length > MaxLength)
                exceptionMessage = exceptionMessage.Substring(0, MaxLength);

            #region Add Data in Log Table
            String MethodType = "", Parameter_Data = "";
            var JsonData = "";
            MethodType = filterContext.Request.Method.Method.ToString();
            if (MethodType == "GET")
            {
                if (filterContext.Request.RequestUri.Query.ToString() != null && filterContext.Request.RequestUri.Query.ToString() != "")
                {
                    Parameter_Data = filterContext.Request.RequestUri.Query.ToString();
                }
            }
            else if (MethodType == "POST")
            {
                if (filterContext.Request.RequestUri.Query.ToString() != null && filterContext.Request.RequestUri.Query.ToString() != "")
                    Parameter_Data = filterContext.Request.RequestUri.Query.ToString();
                else
                {
                    Dictionary<string, object> model = filterContext.ActionContext.ActionArguments;
                    JsonData = JsonConvert.SerializeObject(model);
                    Parameter_Data = JsonData;
                }
            }
            #endregion

            //Error_Log = objLog.AddErrorLog(user, controllerName, actionName, Parameter_Data, exceptionMessage, stackTrace, DBNAME);

            filterContext.Response = objLog.ReturnHttpContext("3", ReturnType);
        }
    }
}