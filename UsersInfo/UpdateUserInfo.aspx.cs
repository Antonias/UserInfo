using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsersInfo
{
    public partial class UpdateUserInfo : System.Web.UI.Page
    {
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];    //クエリ文字列を参照 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string path = main.PhotoSavePath();
            string fileName = id + ".jpg";
            string filePath = System.IO.Path.Combine(path, fileName);

            Ful_UserFace.SaveAs(filePath);
            

        }
    }
}