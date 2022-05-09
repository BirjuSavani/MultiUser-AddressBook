using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Event

    #region FillGridView
    private void FillGridView()
    {
        #region Set The Connection And Command Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objConn;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "PR_ContactCategory_SelectByUserID";
            objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objcmd.ExecuteReader();
            gvContactCategory.DataSource = objSDR;
            gvContactCategory.DataBind();
            objConn.Close();
        }
        #endregion Set The Connection And Command Object
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    #endregion FillGridView

    #region gvContactCategory RowCommand

    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record
    }
    #endregion gvContactCategory RowCommand

    #region DeleteRecord
    private void DeleteRecord(SqlInt32 ContactCategoryID)
    {
        #region Set The Connection And Command Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_DeleteByUserIDContactCategoryID";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("ContactCategoryID", ContactCategoryID.ToString());
            objCmd.ExecuteNonQuery();

            objConn.Close();

            FillGridView();
            lblMessage.Text += "Delete Record ContactCategoryID = " + ContactCategoryID.ToString();
        }
        #endregion Set The Connection And Command Object
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion DeleteRecord
}