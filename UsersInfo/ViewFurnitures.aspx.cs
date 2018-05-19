using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace UsersInfo
{
    public partial class ViewFurnitures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddItemToProductSortDLL();
                SqlDataSource1.ConnectionString = main.GetConnectionString();
                SqlDataSource1.SelectParameters["product_id"].DefaultValue = 1.ToString();
            }
        }

        protected void AddItemToProductSortDLL()
        {
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            string sql = "select product_ja, product_id from [kaigoryoku].[dbo].[TM_ProductName]";
            SqlDataReader reader = clsdb.GetReader(sql);
            while (reader.Read())
            {
                ListItem li = new ListItem(reader.GetValue(0).ToString(), reader.GetValue(1).ToString());
                DDL_ProductSort.Items.Add(li);
            }

            clsdb.closedb();


        }

        protected void DDL_ProductSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem list = (ListItem)DDL_ProductSort.SelectedItem;
            int id = int.Parse(list.Value.ToString());
            SqlDataSource1.ConnectionString = main.GetConnectionString();
            SqlDataSource1.SelectParameters["product_id"].DefaultValue = id.ToString();

        }

        protected void GV_FurnitureList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvr = GV_FurnitureList.Rows[index];

            int id = int.Parse( gvr.Cells[0].Text);

            string url = string.Format("EditFurnitureDetail.aspx?id={0:s}", id.ToString());
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenNewWindow", "window.open('" + url + "', null);", true);

        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}