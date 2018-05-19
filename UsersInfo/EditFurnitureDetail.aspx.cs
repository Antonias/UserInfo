using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsersInfo
{
    public partial class EditFurnitureDetail : System.Web.UI.Page
    {
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);    //クエリ文字列を参照 
                SqlDataSource1.ConnectionString = main.GetConnectionString();
                SqlDataSource1.SelectParameters["id"].DefaultValue = id.ToString();
            }
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }
    }
}