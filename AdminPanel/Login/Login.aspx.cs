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

public partial class AdminPanel_Login_Login : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    #endregion Page Load Event

    #region Button : Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlInt32 strUserID = SqlInt32.Null;
        SqlString strUsername = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        string strErrorMessage = "";
        #endregion Local Variable

        #region Server Side Validation

        if (txtUserNameLogin.Text == "")
            strErrorMessage += "-enter UserName <br>";

        if (txtPasswordLogin.Text == "")
            strErrorMessage += "-enter Password <br>";

        if (strErrorMessage != "")
        {
            lblMessageLogin.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information

        if (txtUserNameLogin.Text != "")
            strUsername = txtUserNameLogin.Text.ToString().Trim();

        if (txtPasswordLogin.Text != "")
            strPassword = txtPasswordLogin.Text.ToString().Trim();

        #endregion Gather Information

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set ConnectionString and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByUserIDPassword";
            //objCmd.Parameters.AddWithValue("UserID", strUserID);
            objCmd.Parameters.AddWithValue("UserName", strUsername);
            objCmd.Parameters.AddWithValue("Password", strPassword);

            #endregion Set ConnectionString and Command Object

            #region Read the Value And Set to the Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                lblMessageLogin.Text = "valid user";
                while (objSDR.Read())
                {
                    if (objSDR["UserID"].Equals(DBNull.Value) != true)
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }

                    if (objSDR["DisplayName"].Equals(DBNull.Value) != true)
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }
                Response.Redirect("~/AdminPanel/Default.aspx");
            }
            else
            {
                lblMessageLogin.Text = "Invalid UserName Or Password";
            }
            #endregion Read the Value And Set to the Controls

            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessageLogin.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }

    }
    #endregion Button : Login

    
}