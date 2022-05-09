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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Page.RouteData.Values["CityID"] != null)
            {
                //lblMessage.Text = "Edit Mode | CityID =" + Request.QueryString["CityID"].ToString();
                FillControls(Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["CityID"].ToString().Trim())));
            }
            else
            {
                //lblMessage.Text = "Add Mode";
            }


        }
    }

    #endregion Load Event

    #region State Save Event
    protected void btnStateSave_Click(object sender, EventArgs e)
    {
        #region Loacal Variable
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlInt32 strCityCode = SqlInt32.Null;
        SqlInt32 strCityPinCode = SqlInt32.Null;
        #endregion Loacal Variable



        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {

            // Server Side Validation
            #region Server Side Validation
            String strErrorMessage = "";

            if (ddlState.SelectedIndex == 0)
                strErrorMessage += "- Select The State <br/>";

            if (txtCityName.Text.Trim() == "")
                strErrorMessage += "- Enter The City Name <br />";

            if (txtCityCode.Text.Trim() == "")
                strErrorMessage += "- Enter The City Code <br/>";

            if (txtCityPinCode.Text.Trim() == "")
                strErrorMessage += "- Enter The City Pin Code <br/>";

            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            //Gather The Information
            #region Gather The Information
            if (ddlState.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlState.SelectedValue);

            if (txtCityName.Text.Trim() != "")
                strCityName = txtCityName.Text.Trim();

            if (txtCityCode.Text.Trim() != "")
                strCityCode = Convert.ToInt32(txtCityCode.Text.Trim());

            if (txtCityPinCode.Text.Trim() != "")
                strCityPinCode = Convert.ToInt32(txtCityPinCode.Text.Trim());

            #endregion Gather The Information

            #region Set Connection & Command Object
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strCityCode);
            objCmd.Parameters.AddWithValue("@PinCode", strCityPinCode);
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            if (Page.RouteData.Values["CityID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@CityID", Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["CityID"].ToString().Trim())));
                objCmd.CommandText = "PR_City_UpdateByUserIDCityID";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "PR_City_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
                //Response.Redirect("~/AdminPanel/City/List", true);
                txtCityName.Text = "";
                txtCityCode.Text = "";
                ddlState.SelectedIndex = 0;
                ddlState.Focus();
                #endregion Insert Record
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();


            objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }

    #endregion State Save Event

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropDownListState(ddlState, Convert.ToInt32(Session["UserID"]));

        //#region Set The Connection And Command Object
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString); try
        //{
        //    objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownListByUserID]";
        //    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    #region Read The Data
        //    if (objSDR.HasRows == true)
        //    {
        //        ddlState.DataSource = objSDR;
        //        ddlState.DataValueField = "StateID";
        //        ddlState.DataTextField = "StateName";
        //        ddlState.DataBind();
        //    }
        //    #endregion Read The Data
        //    ddlState.Items.Insert(0, new ListItem("Select State", "-1"));

        //    objConn.Close();
        //}
        //#endregion Set The Connection And Command Object
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message;
        //}
        //finally
        //{
        //    objConn.Close();
        //}
    }

    #endregion FillDropDownList

    #region FillControls
    private void FillControls(SqlInt32 CityID)
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectByUserIDCityID";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CityName"].Equals(DBNull.Value) != true)
                    //if(!objSDR["StateName"].Equals(DBNull.Value))      
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (objSDR["STDCode"].Equals(DBNull.Value) != true)
                    {
                        txtCityCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (objSDR["PinCode"].Equals(DBNull.Value) != true)
                    {
                        txtCityPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CityID" + CityID.ToString();
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

    #endregion FillControls

    #region Cancle Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/List", true);
    }
    #endregion Cancle Event
}