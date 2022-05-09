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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
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
            objcmd.CommandText = "PR_State_SelectByUserID";
            objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objcmd.ExecuteReader();
            gvState.DataSource = objSDR;
            gvState.DataBind();


            objConn.Close();
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

    #endregion FillGridView

    #region gvState RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Which Command button Is Clicked | e.CommandName
        // Which Row Is Clicked | Get The ID OF That Row | e.CommandArgument
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion Delete Record
    }

    #endregion gvState RowCommand

    #region DeleteState Event
    private void DeleteState(SqlInt32 StateID)
    {
        #region Set The Connection And Command Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_DeleteByUserIDStateID";
            objCmd.Parameters.AddWithValue("StateID", StateID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.ExecuteNonQuery();

            objConn.Close();

            FillGridView();
            lblMessage.Text += "Delete Record StateID = " + StateID.ToString();
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

    #endregion DeleteState Event
}