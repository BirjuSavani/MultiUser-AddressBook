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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Page.RouteData.Values["ContactCategoryID"] != null)
            {
                //lblMeassage.Text = "Edit Mode | ContactCategoryID= " + Request.QueryString["ContactCategoryID"].ToString();
                FillControls(Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim())));

            }
            else
            {
                //lblMeassage.Text = "Add Mode";
            }
        }
    }

    #endregion Load Event

    #region ContactCategorySave Event
    protected void btnContactCategorySave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString strContactCategoryName = SqlString.Null;
        #endregion Local Variable

        #region Server Side Validation
        String strErrorMessage = "";

        if (txtContactCategoryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter ContactCategoryName";
        }
        if(strErrorMessage != "")
        {
            lblMeassage.Text = strErrorMessage;
            return;
        }
        if (txtContactCategoryName.Text.Trim() != "")
            strContactCategoryName = txtContactCategoryName.Text.Trim();
        #endregion Server Side Validation

        #region Set The Connection And Command Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variables
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            //objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());
            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            //SqlDataReader objSDR = objCmd.ExecuteReader();

            if (Page.RouteData.Values["ContactCategoryID"] != null)
            {
                // Edit mode
                #region Update Record
                objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["ContactCategoryID"].ToString().Trim())));
                objCmd.CommandText = "PR_ContactCategory_UpdateByUserIDContactCategoryID";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/ContactCategory/List", true);
                #endregion Update Record
            }
            else
            {
                // Add mode
                #region Insert Record
                objCmd.CommandText = "[dbo].[PR_ContactCategory_InsertByUserID]";
                objCmd.ExecuteNonQuery();
                objConn.Close();
                lblMeassage.ForeColor = System.Drawing.Color.Green;
                lblMeassage.Text = "Data Inserted Successfully";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
                #endregion Insert Record
            }
           
            #endregion Read the Value and set the controls
        }
        catch (Exception ex)
        {
            lblMeassage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }


    #endregion ContactCategorySave Event

    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Local Variables
        try
        {

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectByUserIDContactCategoryID]";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region Read the value and set the contros
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }

                    break;
                }
            }
            else
            {
                lblMeassage.Text = "No Data avaliable for the ContactCategoryID = " + ContactCategoryID.ToString();
            }
            #endregion Read the value and set the contros
        }
        catch (Exception ex)
        {
            lblMeassage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }

    }

        #endregion FillControls

    #region Cancle Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/List", true);
    }
    #endregion Cancle Event
}
    