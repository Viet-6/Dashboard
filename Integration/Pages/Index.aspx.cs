using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Integration.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(user.Text=="admin" && pass.Text == "123456")
            {
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Response.Write("<script>alert('Đăng nhập không thành công!!')</script>");
            }
        }
    }
}