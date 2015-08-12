using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaMI.Web.Services
{
    /// <summary>
    /// Summary description for Profile
    /// </summary>
    public class Profile :JsonRequestHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            string permanentVDC = "TEST";

            //return as JSON result
            Dictionary<string, string> response = new Dictionary<string, string>();
            response.Add("code", "1");
            response.Add("status", "200");
            response.Add("data", permanentVDC);
            SetResponse(context, response);
            /*
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");*/
        }
    }
}