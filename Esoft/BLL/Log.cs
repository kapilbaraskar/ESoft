using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Esoft.BLL
{
    public class Log
    {
        public int AddErrorLog(string userid, string controller_name, string action_name, string data, string message, string stack_trace)
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/LogFile.txt");
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            try
            {
                string ip_address = HttpContext.Current.Request.UserHostName;
                string datetime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.Connection = connection;
                    objCommand.Transaction = connection.BeginTransaction();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "AddErrorlog_sp";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@User_Id", GeneralUtil.DBNullValueorStringIfNotNull(userid));
                    objCommand.Parameters.AddWithValue("@ControllerName", GeneralUtil.DBNullValueorStringIfNotNull(controller_name));
                    objCommand.Parameters.AddWithValue("@ActionName", GeneralUtil.DBNullValueorStringIfNotNull(action_name));
                    objCommand.Parameters.AddWithValue("@Error_Data", GeneralUtil.DBNullValueorStringIfNotNull(data));
                    objCommand.Parameters.AddWithValue("@Message", GeneralUtil.DBNullValueorStringIfNotNull(message));
                    objCommand.Parameters.AddWithValue("@StackTrace", GeneralUtil.DBNullValueorStringIfNotNull(stack_trace));
                    objCommand.Parameters.AddWithValue("@Date_Time", GeneralUtil.DBNullValueorStringIfNotNull(datetime));
                    objCommand.Parameters.AddWithValue("@IP_Address", GeneralUtil.DBNullValueorStringIfNotNull(ip_address));
                    if (objCommand.ExecuteNonQuery() <= 0)
                    {
                        if (objCommand.Transaction != null) objCommand.Transaction.Rollback();
                        return 1;
                    }
                    else
                    {
                        objCommand.Transaction.Commit();
                        return 0;
                    }
                }
            }
            catch (Exception EX)
            {
                //if (objCommand.Transaction != null) objCommand.Transaction.Rollback();
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----Start Log-----");
                    writer.WriteLine("Method Name --> AddErrorLog : " + EX.Message.ToString() + Environment.NewLine + EX.StackTrace);
                    writer.WriteLine("-----Stop Log-----");
                    writer.Close();
                }
                return -1;
            }
        }
        public HttpResponseMessage ReturnHttpContext(string status, String ReturnType = "")
        {
            Dictionary<string, object> resObj = new Dictionary<string, object>();
            string result = "";
            switch (status)
            {
                case "-1":
                    result = "Session ID not Found";
                    break;
                case "0":
                    result = "Your session has expired.";
                    break;
                case "1":
                    result = "Success";
                    break;
                case "2":
                    result = "Invalid CS Id And Geo Id";
                    break;
                case "3":
                    result = "Error";
                    break;
                case "4":
                    result = "Seems that you are trying to login from multiple systems.";
                    break;
                case "5":
                    result = "Your session has expired due to inactivity.";
                    break;
                case "6":
                    result = "There is your mismatch in your credentail.";
                    break;
                case "7":
                    result = "Your session has expired.";
                    break;
                case "8":
                    result = "You have been logged out!";
                    break;
            }
            string Result = "";
            if (status == "1")
            {
                if (ReturnType == "HttpResponseMessage")
                {
                    resObj["status"] = 1;
                    resObj["message"] = result;
                }
                else
                    Result = GeneralUtil.return_ajax_string("1", result);
            }
            else if (status == "2")
            {
                if (ReturnType == "HttpResponseMessage")
                {
                    resObj["status"] = 0;
                    resObj["message"] = result;
                }
                else
                    Result = GeneralUtil.return_ajax_string("0", result);
            }
            else if (status == "3")
            {
                if (ReturnType == "HttpResponseMessage")
                {
                    resObj["status"] = 3;
                    resObj["message"] = result;
                }
                else
                    Result = GeneralUtil.return_ajax_string("3", result);
            }
            else if (status == "4")
            {
                if (ReturnType == "HttpResponseMessage")
                {
                    resObj["status"] = 4;
                    resObj["message"] = result;
                }
                else
                    Result = GeneralUtil.return_ajax_string("4", result);
            }
            else if (status == "5")
            {
                if (ReturnType == "HttpResponseMessage")
                {
                    resObj["status"] = 5;
                    resObj["message"] = result;
                }
                else
                    Result = GeneralUtil.return_ajax_string("5", result);
            }
            else if (status == "6")
            {
                if (ReturnType == "HttpResponseMessage")
                {
                    resObj["status"] = 6;
                    resObj["message"] = result;
                }
                else
                    Result = GeneralUtil.return_ajax_string("6", result);
            }
            else if (status == "7")
            {
                if (ReturnType == "HttpResponseMessage")
                {
                    resObj["status"] = 7;
                    resObj["message"] = result;
                }
                else
                    Result = GeneralUtil.return_ajax_string("7", result);
            }
            else if (status == "8")
            {
                if (ReturnType == "HttpResponseMessage")
                {
                    resObj["status"] = 8;
                    resObj["message"] = result;
                }
                else
                    Result = GeneralUtil.return_ajax_string("8", result);
            }
            else
            {
                if (ReturnType == "HttpResponseMessage")
                {
                    resObj["status"] = status;
                    resObj["message"] = result;
                }
                else
                    Result = GeneralUtil.return_ajax_string(status, result);
            }

            if (ReturnType == "HttpResponseMessage")
                return GeneralUtil.SetHttpResponseMessage(JsonConvert.SerializeObject(resObj));
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(Result)
                };
            }
        }
    }
}