using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownCountry();
            FillDropDownState();
            FillDropDownCity();
            //FillDropDownContactCategory();
            FillCBLContactCategoryID();


            if (Page.RouteData.Values["ContactID"] != null)
            {
                //lblMeassage.Text = "Edit Mode | ContactID = " + Request.QueryString["ContactID"].ToString();
                FillControls(Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["ContactID"].ToString().Trim())));

            }
            else
            {
                //lblMeassage.Text = "Add Mode";
            }


        }

    }
    #endregion Load Event

    #region Contact Save Event
    protected void btnContactCategorySave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlInt64 strCountryID = SqlInt64.Null;
        SqlInt64 strStateID = SqlInt64.Null;
        SqlInt64 strCityID = SqlInt64.Null;
        //SqlInt64 strContactCategoryID = SqlInt64.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNumber = SqlString.Null;
        SqlString strWhatsappNumber = SqlString.Null;
        SqlString strBirthDate = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlInt64 strAge = SqlInt64.Null;
        SqlString strAddress = SqlString.Null;
        string FilePath = "";
        SqlInt32 IntUserID = SqlInt32.Null;
        int Count = 0;
        if (Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(Session["UserID"]);
        }
        #endregion Local Variable

        // Server Side Validation
        #region Server Side Validation
        string strErrorMessage = "";
        if (ddlCountry.SelectedIndex == 0)
            strErrorMessage += "- Select The Country <br />";
        if (ddlState.SelectedIndex == 0)
            strErrorMessage += "- Select The State <br/>";
        if (ddlCity.SelectedIndex == 0)
            strErrorMessage += "- Select The City <br />";
        //if (ddlContactCategory.SelectedIndex == 0)
        //    strErrorMessage += "- Select The Contact Category <br />";
        foreach (ListItem ContactCategorylist in cblContactCategory.Items)
        {
            if (ContactCategorylist.Selected)
            {
                Count++;

            }
        }
        if (txtContactName.Text.Trim() == "")
            strErrorMessage += "- Enter The ContactName <br/>";
        if (txtContactNumber.Text.Trim() == "")
            strErrorMessage += "- Enter The ContactNumber <br/>";
        if (txtWhatsappNumber.Text.Trim() == "")
            strErrorMessage += "- Enter The WhatsappNumber <br />";
        if (txtEmail.Text.Trim() == "")
            strErrorMessage += "- Enter The Email Address <br/>";
        if (txtBloodGroup.Text.Trim() == "") ;
        strBloodGroup += "- Enter The Blood Group <br>";
        if (txtAge.Text.Trim() == "")
            strErrorMessage += "- Enter The Age <br/>";
        if (txtAddress.Text.Trim() == "")
            strErrorMessage += "- Enter The Address <br/>";
        if (!fuFile.HasFile)
        {
            strErrorMessage += "- Select File <br>";
        }
        if (strErrorMessage != "")
        {
            lblMeassage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        // Gather The Information 
        #region Gather The Information
        if (ddlCountry.SelectedIndex > 0)
            strCountryID = Convert.ToInt64(ddlCountry.SelectedValue);
        if (ddlState.SelectedIndex > 0)
            strStateID = Convert.ToInt64(ddlState.SelectedValue);
        if (ddlCity.SelectedIndex > 0)
            strCityID = Convert.ToInt64(ddlCity.SelectedValue);
        //if (ddlContactCategory.SelectedIndex > 0)
        //    strContactCategoryID = Convert.ToInt32(ddlContactCategory.SelectedValue);
        if (txtContactName.Text.Trim() != "")
            strContactName = txtContactName.Text.Trim();
        if (txtContactNumber.Text.Trim() != "")
            strContactNumber = txtContactNumber.Text.Trim();
        if (txtWhatsappNumber.Text.Trim() != "")
            strWhatsappNumber = txtWhatsappNumber.Text.Trim();
        if (txtBirthDate.Text.Trim() != "")
            strBirthDate = txtBirthDate.Text.Trim();
        if (txtEmail.Text.Trim() != "")
            strEmail = txtEmail.Text.Trim();
        if (txtBloodGroup.Text.Trim() != "")
            strBloodGroup = txtBloodGroup.Text.Trim();
        if (txtAge.Text.Trim() != "")
            strAge = Convert.ToInt64(txtAge.Text.Trim());
        if (txtAddress.Text.Trim() != "")
            strAddress = txtAddress.Text.Trim();
        if (fuFile.PostedFile.ContentType == "image/jpeg" || fuFile.PostedFile.ContentType == "image/png")
        {
            if (Convert.ToDouble(fuFile.PostedFile.ContentLength) / 3024 < 3000)
            {
                FilePath = "../UserContent/" + fuFile.FileName.ToString().Trim();
                fuFile.SaveAs(Server.MapPath(FilePath));
            }
            else
            {
                lblMeassage.Text += "File Size exceeds 200 KB - Please Uplaod File Size Maximum 50 KB";
                return;
            }
        }
        else
        {
            lblMeassage.Text += "Only jpeg/png Image File Acceptable - Upload Image File Again";
            return;
        }
        //if (fuFile.HasFile)
        //{
        //    string fPath = "../UserContent/";
        //    string Path = Server.MapPath(fPath);
        //    FilePath = fPath + fuFile.FileName.ToString().Trim();

        //    if (!Directory.Exists(Path))
        //    {
        //        Directory.CreateDirectory(Path);
        //    }

        //    fuFile.SaveAs(Server.MapPath(FilePath));
        //}
        #endregion Gather The Information

        #region Set The Connection And Command Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            //objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@ContactNumber", strContactNumber);
            objCmd.Parameters.AddWithValue("@WhatsappNumber", strWhatsappNumber);
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@FilePath", FilePath);
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            if (Page.RouteData.Values["ContactID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@ContactID", Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["ContactID"].ToString().Trim())));
                //FilePath = this.fuFile.FileName.ToString().Trim();
                objCmd.CommandText = "PR_Contact_UpdateByUserIDContactID";
                objCmd.ExecuteNonQuery();

                //Delete ContactWiseContactCategory Records
                SqlCommand objCmdContactCategory = objConn.CreateCommand();
                objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_DeleteByContactID";
                objCmdContactCategory.Parameters.AddWithValue("@ContactID", Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["ContactID"].ToString().Trim())));
                objCmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"]);
                objCmdContactCategory.ExecuteNonQuery();

                foreach (ListItem liContactCategory in cblContactCategory.Items)
                {
                    if (liContactCategory.Selected)
                    {
                        SqlCommand objCmdContactCategoryInsert = objConn.CreateCommand();
                        objCmdContactCategoryInsert.CommandType = CommandType.StoredProcedure;
                        objCmdContactCategoryInsert.CommandText = "PR_ContactWiseContactCategory_Insert";
                        objCmdContactCategoryInsert.Parameters.AddWithValue("@ContactID", Convert.ToInt32(CommonDropDownFillMethods.Base64decode(Page.RouteData.Values["ContactID"].ToString().Trim())));
                        objCmdContactCategoryInsert.Parameters.AddWithValue("@ContactCategoryID", liContactCategory.Value.ToString());
                        objCmdContactCategoryInsert.Parameters.AddWithValue("@UserID", Session["UserID"]);
                        objCmdContactCategoryInsert.ExecuteNonQuery();
                    }
                }

                Response.Redirect("~/AdminPanel/Contact/List", true);

                #endregion Update Record
            }
            else
            {

                #region Insert Record
                //Add Mode
                objCmd.CommandText = "PR_Contact_Insert";
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;


                objCmd.ExecuteNonQuery();

                SqlInt32 ContactID = 0;
                ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                foreach (ListItem liContactCategory in cblContactCategory.Items)
                {
                    if (liContactCategory.Selected)
                    {
                        SqlCommand objCmdContactCategory = objConn.CreateCommand();
                        objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                        objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_Insert";
                        objCmdContactCategory.Parameters.AddWithValue("@ContactID", ContactID.ToString());
                        objCmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"]);
                        objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategory.Value.ToString());
                        objCmdContactCategory.ExecuteNonQuery();
                    }
                }

                ddlCountry.ClearSelection();
                ddlState.Items.Clear();
                ddlCity.Items.Clear();
                txtContactName.Text = "";
                txtContactNumber.Text = "";
                txtWhatsappNumber.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtBloodGroup.Text = "";
                txtBirthDate.Text = "";
                txtEmail.Text = "";
                cblContactCategory.Items.Clear();



                lblMeassage.ForeColor = System.Drawing.Color.Green;
                lblMeassage.Text = "Data Inserted Successfully";
                //Response.Redirect("~/AdminPanel/Contact/List", true);
            }

            #endregion Insert Record

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        #endregion Set The Connection And Command Object
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

    #endregion Contact Save Event

    #region FillDropDownCountry
    private void FillDropDownCountry()
    {
        CommonDropDownFillMethods.FillDropDownListCounrty(ddlCountry, Convert.ToInt32(Session["UserID"]));

        //#region Set The Connection And Command Object
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        //try
        //{
        //    objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "PR_Country_SelectForDropDownListByUserID";
        //    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    #region Read The Data
        //    if (objSDR.HasRows == true)
        //    {
        //        ddlCountryList.DataSource = objSDR;
        //        ddlCountryList.DataValueField = "CountryID";
        //        ddlCountryList.DataTextField = "CountryName";
        //        ddlCountryList.DataBind();
        //    }
        //    #endregion Read The Data
        //    ddlCountryList.Items.Insert(0, new ListItem("Select Country", "-1"));

        //    objConn.Close();
        //}
        //#endregion Set The Connection And Command Object
        //catch (Exception ex)
        //{
        //    lblMeassage.Text = ex.Message;
        //}
        //finally
        //{
        //    objConn.Close();
        //}
    }

    #endregion FillDropDownCountry

    #region FillDropDownState
    private void FillDropDownState()
    {
        CommonDropDownFillMethods.FillDropDownListState(ddlState, Convert.ToInt32(Session["UserID"]));

        //#region Set The Connection And Command Object
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        //try
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
        //        ddlStateList.DataSource = objSDR;
        //        ddlStateList.DataValueField = "StateID";
        //        ddlStateList.DataTextField = "StateName";
        //        ddlStateList.DataBind();
        //    }
        //    #endregion Read The Data

        //    ddlStateList.Items.Insert(0, new ListItem("Select State", "-1"));

        //    objConn.Close();
        //}
        //#endregion Set The Connection And Command Object
        //catch (Exception ex)
        //{
        //    lblMeassage.Text = ex.Message;
        //}
        //finally
        //{
        //    objConn.Close();
        //}
    }

    #endregion FillDropDownState

    #region FillDropDownCity
    private void FillDropDownCity()
    {
        CommonDropDownFillMethods.FillDropDownListCity(ddlCity, Convert.ToInt32(Session["UserID"]));

        //#region Set The Connection And Command Object
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        //try
        //{
        //    objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "PR_City_SelectForDropDownListByUserID";
        //    objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
        //    SqlDataReader objSDR = objCmd.ExecuteReader();
        //    #region Read The Data
        //    if (objSDR.HasRows == true)
        //    {
        //        ddlCityList.DataSource = objSDR;
        //        ddlCityList.DataValueField = "CityID";
        //        ddlCityList.DataTextField = "CityName";
        //        ddlCityList.DataBind();
        //    }
        //    #endregion Read The Data
        //    ddlCityList.Items.Insert(0, new ListItem("Select City", "-1"));

        //    objConn.Close();
        //}
        //#endregion Set The Connection And Command Object
        //catch (Exception ex)
        //{
        //    lblMeassage.Text = ex.Message;
        //}
        //finally
        //{
        //    objConn.Close();
        //}
    }

    #endregion FillDropDownCity

    /* #region FillDropDownContactCategory
     private void FillDropDownContactCategory()
     {
         //    #region Set The Connection And Command Object
         //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
         //    try
         //    {
         //        objConn.Open();

         //        SqlCommand objCmd = objConn.CreateCommand();
         //        objCmd.CommandType = CommandType.StoredProcedure;
         //        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownListByUserID";
         //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
         //        SqlDataReader objSDR = objCmd.ExecuteReader();

         //        #region Read The Data
         //        if (objSDR.HasRows == true)
         //        {
         //            ddlContactCategory.DataSource = objSDR;
         //            ddlContactCategory.DataValueField = "ContactCategoryID";
         //            ddlContactCategory.DataTextField = "ContactCategoryName";
         //            ddlContactCategory.DataBind();
         //        }
         //        #endregion Read The Data
         //        ddlContactCategory.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));

         //        objConn.Close();
         //    }
         //    #endregion Set The Connection And Command Object
         //    catch (Exception ex)
         //    {
         //        lblMeassage.Text = ex.Message;
         //    }
         //    finally
         //    {
         //        objConn.Close();
         //    }

     }

     #endregion FillDropDownContactCategory*/

    #region FillControls
    private void FillControls(SqlInt32 ContactID)
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByUserIDContactID";

            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            #region Read the Value and set the controls

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["CountryID"].Equals(DBNull.Value) != true)
                    {
                        ddlCountry.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (objSDR["StateID"].Equals(DBNull.Value) != true)
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (objSDR["CityID"].Equals(DBNull.Value) != true)
                    {
                        ddlCity.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    //if (objSDR["ContactCategoryID"].Equals(DBNull.Value) != true)
                    //{
                    //    ddlContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    //}
                    if (objSDR["ContactCategoryNames"].Equals(DBNull.Value) != true)
                    {
                        Int32 c = 0;
                        String category = objSDR["ContactCategoryNames"].ToString();
                        //lblMassge.Text = category.ToString().Trim();
                        String[] Saprator = { ", " };
                        foreach (ListItem ContactCategorylist in cblContactCategory.Items)
                        {
                            c++;
                        }
                        Int32 list = c;
                        String[] LiCategory = category.Split(Saprator, list, StringSplitOptions.RemoveEmptyEntries);

                        foreach (String s in LiCategory)
                        {

                            foreach (ListItem ContactCategorylist in cblContactCategory.Items)
                            {
                                if (s.ToString().Trim() == ContactCategorylist.ToString().Trim())
                                {
                                    ContactCategorylist.Selected = true;

                                }
                            }
                        }
                    }
                    if (objSDR["ContactName"].Equals(DBNull.Value) != true)
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (objSDR["ContactNumber"].Equals(DBNull.Value) != true)
                    {
                        txtContactNumber.Text = objSDR["ContactNumber"].ToString().Trim();
                    }
                    if (objSDR["WhatsappNumber"].Equals(DBNull.Value) != true)
                    {
                        txtWhatsappNumber.Text = objSDR["WhatsappNumber"].ToString().Trim();
                    }
                    if (objSDR["BirthDate"].Equals(DBNull.Value) != true)
                    {
                        txtBirthDate.Text = objSDR["BirthDate"].ToString().Trim();
                    }
                    if (objSDR["Email"].Equals(DBNull.Value) != true)
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (objSDR["BloodGroup"].Equals(DBNull.Value) != true)
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                    }
                    if (objSDR["Age"].Equals(DBNull.Value) != true)
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (objSDR["Address"].Equals(DBNull.Value) != true)
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMeassage.Text = "No Data available for the ContactID" + ContactID.ToString();
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

    #endregion FillControls

    #region Cancle Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/List", true);
    }

    #endregion Cancle Event

    #region Fill Check Box List ContactcategoryID
    private void FillCBLContactCategoryID()
    {
        SqlInt32 strCountryID = SqlInt32.Null;


        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            #endregion Set Connection & Command Object

            #region Gather & Fill Information
            //objCmd.CommandText = "PR_ContactCategory_Select";
            objCmd.CommandText = "PR_ContactCategory_SelectForCheckBoxList";
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                cblContactCategory.DataTextField = "ContactCategoryName";
                cblContactCategory.DataValueField = "ContactCategoryID";
                cblContactCategory.DataSource = objSDR;


                cblContactCategory.DataBind();
            }

            #endregion Gather & Fill Information


            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception Ex)
        {
            lblMeassage.Text = Ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Fill Check Box List ContactcategoryID

}