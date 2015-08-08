using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
public partial class AdminUSER_Module : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadUSER_ModuleData();
            RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showUSER_ModuleData();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        USER_Module uSER_Module = new USER_Module();
        //	uSER_Module.ModuleID=  int.Parse(ddlModuleID.SelectedValue);
        uSER_Module.ModuleName = txtModuleName.Text;
        uSER_Module.DefaultURL = txtDefaultURL.Text;
        uSER_Module.AddedBy = "Admin";
        uSER_Module.AddedDate = DateTime.Now;
        uSER_Module.UpdatedBy = "Admin";
        uSER_Module.UpdatedDate = DateTime.Now;
        uSER_Module.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
        int resutl = USER_ModuleManager.InsertUSER_Module(uSER_Module);
        Response.Redirect("AdminDisplayUSER_Module.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        USER_Module uSER_Module = new USER_Module();
        uSER_Module.ModuleID = int.Parse(Request.QueryString["ID"].ToString());
        uSER_Module.ModuleName = txtModuleName.Text;
        uSER_Module.DefaultURL = txtDefaultURL.Text;
        uSER_Module.AddedBy = "Admin";
        uSER_Module.AddedDate = DateTime.Now;
        uSER_Module.UpdatedBy = "Admin";
        uSER_Module.UpdatedDate = DateTime.Now;
        uSER_Module.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
        bool resutl = USER_ModuleManager.UpdateUSER_Module(uSER_Module);
        Response.Redirect("AdminDisplayUSER_Module.aspx");
    }
    private void showUSER_ModuleData()
    {
        try
        {
            USER_Module uSER_Module = new USER_Module();
            uSER_Module = USER_ModuleManager.GetUSER_ModuleByModuleID(Int32.Parse(Request.QueryString["ID"]));
            txtModuleName.Text = uSER_Module.ModuleName.ToString();
            txtDefaultURL.Text = uSER_Module.DefaultURL;
            ddlRowStatusID.SelectedValue = uSER_Module.RowStatusID.ToString();
        }
        catch (Exception ex)
        {
        }
    }

    private void RowStatusIDLoad()
    {
        try
        {
            DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
            ddlRowStatusID.DataValueField = "RowStatusID";
            ddlRowStatusID.DataTextField = "RowStatusName";
            ddlRowStatusID.DataSource = ds.Tables[0];
            ddlRowStatusID.DataBind();
            ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));

            ddlRowStatusID.SelectedValue =((int)Enums.RowStatus.Active).ToString();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

