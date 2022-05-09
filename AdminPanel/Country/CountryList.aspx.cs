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

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
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
        
        
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        
        try
        {
            //Open the connection
            #region Set Connection And Command Object
            objConn.Open();

        // Prepare the Command Object

        SqlCommand objcmd = new SqlCommand();
        objcmd.Connection = objConn;
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "[dbo].[PR_Country_SelectByUserID]";
        objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
        SqlDataReader objSDR = objcmd.ExecuteReader();
        gvCountry.DataSource = objSDR;
        gvCountry.DataBind();
        //objcmd.ExecuteNonQuery(); In Case Of Use Is Insert\Update\Delete Operation
        //objcmd.ExecuteScalar();      Only One Value Is Return In Form OF Scalar
        //objcmd.ExecuteReader(); //In Case Of Use Is Select
        #endregion Set Connection And Command Object

        objConn.Close();
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
        #endregion FillGridView

    #region gvCountry RowCommand 
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
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

    #endregion gvCountry RowCommand

    #region DeleteCountryRecord
    private void DeleteRecord(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_DeleteByUserIDCountryID";
            objCmd.Parameters.AddWithValue("CountryID", CountryID.ToString());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.ExecuteNonQuery();

            objConn.Close();

            FillGridView();
            lblMessage.Text += "Delete Record County ID = " + CountryID.ToString();

        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion DeleteCountryRecord
}
