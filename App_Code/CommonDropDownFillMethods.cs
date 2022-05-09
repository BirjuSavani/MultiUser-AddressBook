using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethods
/// </summary>
public static class CommonDropDownFillMethods
{
    #region FillDropDownListCountry
    public static void FillDropDownListCounrty(DropDownList ddlCountry, SqlInt32 UserID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_SelectForDropDownListByUserID]";
            objCmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlCountry.DataSource = objSDR;
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataBind();
            }

            ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            //lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillDropDownListCountry

    #region FillDropDownListState
    public static void FillDropDownListState(DropDownList ddlState, SqlInt32 UserID)
    {
        #region Set The Connection And Command Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownListByUserID]";
            objCmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region Read The Data
            if (objSDR.HasRows == true)
            {
                ddlState.DataSource = objSDR;
                ddlState.DataValueField = "StateID";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
            }
            #endregion Read The Data

            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));

            objConn.Close();
        }
        #endregion Set The Connection And Command Object
        catch (Exception ex)
        {
            //lblMeassage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    #endregion FillDropDownListCountry

    #region FillDropDownListCity
    public static void FillDropDownListCity(DropDownList ddlCity, SqlInt32 UserID)
    {
        #region Set The Connection And Command Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectForDropDownListByUserID";
            objCmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #region Read The Data
            if (objSDR.HasRows == true)
            {
                ddlCity.DataSource = objSDR;
                ddlCity.DataValueField = "CityID";
                ddlCity.DataTextField = "CityName";
                ddlCity.DataBind();
            }
            #endregion Read The Data
            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));

            objConn.Close();
        }
        #endregion Set The Connection And Command Object
        catch (Exception ex)
        {
            //lblMeassage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }

    #endregion FillDropDownListCity

    #region EnCodeData
    public static string Base64encode(string plaintext)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    #endregion EnCodeData

    #region DecodeData
    public static string Base64decode(string Base64EncodedData)
    {
        var Base64DataBytes = System.Convert.FromBase64String(Base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(Base64DataBytes);
    }
    #endregion DecodeData

}

