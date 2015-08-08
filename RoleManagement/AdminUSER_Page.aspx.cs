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
public partial class AdminUSER_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadUSER_PageData();
            ModuleIDLoad();
            RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showUSER_PageData();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        USER_Page uSER_Page = new USER_Page();
        //	uSER_Page.PageID=  int.Parse(ddlPageID.SelectedValue);
        uSER_Page.PageTitle = txtPageTitle.Text;
        uSER_Page.PageURL = txtPageURL.Text;
        uSER_Page.ModuleID = int.Parse(ddlModuleID.SelectedValue);
        uSER_Page.AddedBy = "Admin";
        uSER_Page.AddedDate = DateTime.Now;
        uSER_Page.UpdatedBy = "Admin";
        uSER_Page.UpdatedDate = DateTime.Now;
        uSER_Page.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
        int resutl = USER_PageManager.InsertUSER_Page(uSER_Page);
        Response.Redirect("AdminDisplayUSER_Page.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        USER_Page uSER_Page = new USER_Page();
        uSER_Page.PageID = int.Parse(Request.QueryString["ID"].ToString());
        uSER_Page.PageTitle = txtPageTitle.Text;
        uSER_Page.PageURL = txtPageURL.Text;
        uSER_Page.ModuleID = int.Parse(ddlModuleID.SelectedValue);
        uSER_Page.AddedBy = "Admin";
        uSER_Page.AddedDate = DateTime.Now;
        uSER_Page.UpdatedBy = "Admin";
        uSER_Page.UpdatedDate = DateTime.Now;
        uSER_Page.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
        bool resutl = USER_PageManager.UpdateUSER_Page(uSER_Page);
        Response.Redirect("AdminDisplayUSER_Page.aspx");
    }
    private void showUSER_PageData()
    {
        USER_Page uSER_Page = new USER_Page();
        uSER_Page = USER_PageManager.GetUSER_PageByPageID(Int32.Parse(Request.QueryString["ID"]));
        txtPageTitle.Text = uSER_Page.PageTitle.ToString();
        txtPageURL.Text = uSER_Page.PageURL.ToString();
        ddlModuleID.SelectedValue = uSER_Page.ModuleID.ToString();
        ddlRowStatusID.SelectedValue = uSER_Page.RowStatusID.ToString();
    }

    private void ModuleIDLoad()
    {
        try
        {
            DataSet ds = USER_ModuleManager.GetDropDownListAllUSER_Module();
            ddlModuleID.DataValueField = "ModuleID";
            ddlModuleID.DataTextField = "ModuleName";
            ddlModuleID.DataSource = ds.Tables[0];
            ddlModuleID.DataBind();
            ddlModuleID.Items.Insert(0, new ListItem("Select Module >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
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

            ddlRowStatusID.SelectedValue = ((int)Enums.RowStatus.Active).ToString();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

