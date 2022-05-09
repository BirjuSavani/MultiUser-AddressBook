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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender,System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (Page.RouteData.Values["OperationName"] != null)
            //{
            //    lblMessage.Text += Page.RouteData.Values["OperationName"].ToString().Trim();
            //}
            //if (Page.RouteData.Values["CountryID"] != null)
            //{
            //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(Page.RouteData.Values["CountryID"].ToString().Trim());
            //    //System.Convert.ToBase64String(plainTextBytes);
            //    lblMessage.Text += Page.RouteData.Values["CountryID"].ToString().Trim() + System.Convert.ToBase64String(plainTextBytes); 
            //}
            if (Page.RouteData.Values["CountryID"] != null)
            {

                //lblMessage.Text = "Edit  Mode | CountryID = " + Request.QueryString["CountryID"].ToString();
                FillControls(Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["CountryID"].ToString().Trim())));
            }
            else
            {
                //lblMessage.Text = "Add Mode";
            }

        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        #endregion Local Variables

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());


        try
        {

            #region Server Side Validation
            string strErrorMessge = "";
            if (txtCountryName.Text.Trim() == "")
                strErrorMessge += "- Enter Country Name <br/>";

            if (txtCountryCode.Text.Trim() == "")
                strErrorMessge += "- Enter Country Code <br/>";

            if (strErrorMessge != "")
            {
                //Response.Write("<script>alert(strErrorMessge)</script>");
                lblMessage.Text = strErrorMessge;
                return;
            }
           
            #endregion Server Side Validation

            #region Gather the Information
            if (txtCountryName.Text.Trim() != "")
            {
                strCountryName = txtCountryName.Text.Trim();
            }
            if (txtCountryCode.Text.Trim() != "")
            {
                strCountryCode = txtCountryCode.Text.Trim();
            }
            #endregion Gather the Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            if (Page.RouteData.Values["CountryID"] != null)
            {
                //Edit Record
                #region Update Record
                objCmd.CommandText = "[dbo].[PR_Country_UpdateByUserIDCountryID]";
                objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["CountryID"].ToString().Trim())));
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Country/List", true);
                #endregion Update Record
            }
            else
            {
                //Add Record
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "PR_Country_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
                //Response.Redirect("~/AdminPanel/Country/CountryList.aspx", true);
                txtCountryName.Text = "";
                txtCountryCode.Text = "";
                txtCountryName.Focus();
                #endregion Insert Record
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/List", true);
    }
    #endregion Button : Cancel

    #region Fill Controls
    private void FillControls(SqlInt32 CountryID)
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_SelectByUserIDCountryID]";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryName"].Equals(DBNull.Value) != true)
                    //if(!objSDR["StateName"].Equals(DBNull.Value))      
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    txtCountryName.Focus();
                    if (objSDR["CountryCode"].Equals(DBNull.Value) != true)
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CountryID" + CountryID.ToString();
            }
            #endregion Read the Value and set the controls
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion Fill Controls

    #region Cancle Button Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/List", true);

    }

    #endregion Cancle Button Event
}