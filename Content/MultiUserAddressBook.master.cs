using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_MultiUserAddressBook : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Login/List", true);
        }

        if(!Page.IsPostBack)
        {
            if(Session["DisplayName"]!= null)
            {
                lblmessage.Text = "Hi " + Session["DisplayName"] + "!";
            }
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/AdminPanel/Login/List", true);
    }
    
}
