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

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
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
        #region Set The Connetion And Command Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objConn;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "PR_Contact_SelectByUserID";
            objcmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader objSDR = objcmd.ExecuteReader();
            gvContact.DataSource = objSDR;
            gvContact.DataBind();

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        #endregion Set The Connetion And Command Object
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

    #region gvContact RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridView();
            }
        }
        #endregion Delete Record
    }

    #endregion gvContact RowCommand

    #region DeleteRecord

    private void DeleteRecord(SqlInt32 ContactID)
    {
        #region Set The Connection And Command Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        SqlInt32 IntUserID = SqlInt32.Null;
        String FilePath = "";
        #endregion Local Variable
        if (Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(Session["UserID"]);
        }
        {
            try
            {
                #region Set Connection & Command Object
                objConn.Open();

                SqlCommand ObjCmd = new SqlCommand();

                ObjCmd.Connection = objConn;
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@ContactID", ContactID);
                ObjCmd.Parameters.AddWithValue("@UserID", IntUserID);
                ObjCmd.CommandText = "PR_Contact_SelectByUserIDContactID";

                SqlDataReader objSDR = ObjCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["FilePath"].Equals(DBNull.Value))
                        {
                            FilePath = objSDR["FilePath"].ToString().Trim();
                            objSDR.Close();
                        }

                        break;
                    }
                }
                else
                {
                    lblMessage.Text = "Data Will Not Found";
                }


                FileInfo file = new FileInfo(Server.MapPath(FilePath));
                if (file.Exists)
                {

                    SqlCommand ObjCmdcc = new SqlCommand();

                    ObjCmdcc.Connection = objConn;
                    ObjCmdcc.CommandType = CommandType.StoredProcedure;
                    ObjCmd.CommandText = "PR_Contact_DeleteByUserIContactID";
                    ObjCmdcc.Parameters.AddWithValue("@ContactID", ContactID);
                    //ObjCmdcc.Parameters.AddWithValue("@UserID", IntUserID);
                    ObjCmdcc.CommandText = "PR_ContactWiseContactCategory_DeleteByPK";
                    


                    ObjCmdcc.ExecuteNonQuery();
                    ObjCmd.ExecuteNonQuery();

                    file.Delete();

                }

                objConn.Close();
                FillGridView();
                #endregion Set Connection & Command Object
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

    }

    #endregion DeleteRecord
}