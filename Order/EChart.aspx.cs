using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order
{
    public partial class EChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fanProp.DataSource = null;
            this.fanProp.DataBind();

            string fanid = Request.QueryString["fanid"].ToString();

            FanClass fanClass = QueryClass.Fanlist[fanid];

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("key", typeof(String)));
            table.Columns.Add(new DataColumn("value", typeof(String)));
            DataRow row = table.NewRow();

            foreach (System.Reflection.PropertyInfo p in fanClass.GetType().GetProperties())
            {
                row = table.NewRow();
                row[0] = p.Name;
                row[1] = p.GetValue(fanClass);
                table.Rows.Add(row);
            }

            fanProp.DataSource = table;
            fanProp.DataBind();

        }
    }
}