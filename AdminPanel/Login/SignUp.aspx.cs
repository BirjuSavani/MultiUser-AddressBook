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

public partial class AdminPanel_Login_SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }

    }
    #region Button : SignUp
    protected void btnSignup_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString strUsername = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strDisplayName = SqlString.Null;
        SqlString strMobileNumber = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        string strErrorMessage = "";
        #endregion Local Variable


        #region Server Side Validation
        if (txtUsernameSignup.Text == "")
            strErrorMessage += "-enter UserName <br>";

        if (txtPasswordSignup.Text == "")
            strErrorMessage += "-enter Password <br>";

        if (txtDisplayNameSignup.Text == "")
            strErrorMessage += "-enter Displayname <br>";

        if (txtMobileNumberSignup.Text == "")
            strErrorMessage += "-enter MobileNumber <br>";

        if (txtEmailSignup.Text == "")
            strErrorMessage += "-enter Email Address <br>";

        if (strErrorMessage != "")
        {
            lblMessageSignup.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information

        if (txtUsernameSignup.Text != "")
            strUsername = txtUsernameSignup.Text.ToString().Trim();

        if (txtPasswordSignup.Text != "")
            strPassword = txtPasswordSignup.Text.ToString().Trim();

        if (txtDisplayNameSignup.Text != "")
            strDisplayName = txtDisplayNameSignup.Text.ToString().Trim();

        if (txtMobileNumberSignup.Text != "")
            strMobileNumber = txtMobileNumberSignup.Text.ToString().Trim();

        if (txtEmailSignup.Text != "")
            strEmail = txtEmailSignup.Text.ToString().Trim();

        #endregion Gather Information

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);



        try
        {
            #region Set Connection String and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_Insert";
            objCmd.Parameters.AddWithValue("UserName", strUsername);
            objCmd.Parameters.AddWithValue("Password", strPassword);
            objCmd.Parameters.AddWithValue("DisplayName", strDisplayName);
            objCmd.Parameters.AddWithValue("MobileNumber", strMobileNumber);
            objCmd.Parameters.AddWithValue("Email", strEmail);
            #endregion Set Connection String and Command Object
            objCmd.ExecuteNonQuery();

            lblMessageSignup.Text = "Successfully Created Account !";

            //txtUserNameLogin.Text = txtUsernameSignup.Text;
            txtMobileNumberSignup.Text = "";
            txtUsernameSignup.Text = "";
            txtPasswordSignup.Text = "";
            txtDisplayNameSignup.Text = "";
            txtEmailSignup.Text = "";
            //txtPasswordLogin.Focus();


            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessageSignup.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
    }
    #endregion Button : SignUp

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Login/Login.aspx", true);
    }
}