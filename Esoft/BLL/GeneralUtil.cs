using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Esoft.BLL
{
    public class GeneralUtil
    {
        public static dynamic SetHttpResponseMessage(string data)
        {
            var resp = new HttpResponseMessage()
            {
                Content = new StringContent(data)
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return resp;
        }
        public static string DBNullValueorStringIfNotNull(string value)
        {
            string o;
            if (value == null)
            {
                o = DBNull.Value.ToString();
            }
            else
            {
                o = value;
            }
            return o;
        }
        public static string return_ajax_string(string status, string message)
        {
            return "{\"status\":\"" + status + "\",\"message\":\"" + message + "\"}";
        }
        
    }
}