using Helper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Order
{
    /// <summary>
    /// GetValue 的摘要说明
    /// </summary>
    public class GetValue : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string id = context.Request["id"].ToString();
            //string id = context.Request["id"].ToString();
            FanClass fanClass = QueryClass.Fanlist[id];

            JArray jArray = new JArray();

            string sql = string.Format(" select * FROM fanDataPoint where 风机型号 = '{0}'", id) ;
            string sql1 = string.Format(" select max(风量),max(静压),max(全压),min(风量),min(静压),min(全压),min(功率),max(功率) FROM fanDataPoint where 风机型号 = '{0}'", id) ;

            //DataTable dt = db.GetDataTable(sql);
            DataTable dt = SQLHelper.Query(sql).Tables[0];
            DataTable dt1 = SQLHelper.Query(sql1).Tables[0];
            var lists = new List<object>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JObject jObject = new JObject();
                jObject.Add("Q", dt.Rows[i]["风量"].ToString());
                jObject.Add("S", dt.Rows[i]["静压"].ToString());
                jObject.Add("P", dt.Rows[i]["全压"].ToString());
                jObject.Add("W", dt.Rows[i]["功率"].ToString());
                jArray.Add(jObject);
                //var obj1 = new { Q = dt.Rows[i]["风量"], S = dt.Rows[i]["静压"] };
                //lists.Add(obj1);
            }

            JObject jObject1 = new JObject();
            jObject1.Add("minQ", fanClass.MinFlow);
            jObject1.Add("maxQ", fanClass.MaxFlow);

            jObject1.Add("minP", dt1.Rows[0][5].ToString());
            jObject1.Add("maxP", dt1.Rows[0][2].ToString());

            jObject1.Add("minS", dt1.Rows[0][4].ToString());
            jObject1.Add("maxS", dt1.Rows[0][1].ToString());

            jObject1.Add("minW", dt1.Rows[0][6].ToString());
            jObject1.Add("maxW", dt1.Rows[0][7].ToString());
            jArray.Add(jObject1);


            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    var obj2 = new { Q = dt.Rows[i]["风量"], P = dt.Rows[i]["全压"] };
            //    lists.Add(obj2);
            //}


            //var obj3 = new { min = fanClass.MinFlow, max = fanClass.MaxFlow };
            //lists.Add(obj3);

            //var jsS = new JavaScriptSerializer();
            //var result = jsS.Serialize(lists);
            //context.Response.Write(result);

            context.Response.Write(jArray.ToString(Newtonsoft.Json.Formatting.None));
        }

         
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}