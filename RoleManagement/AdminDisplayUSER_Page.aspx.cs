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


public partial class AdminDisplayUSER_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadModules();
            USER_PageManager.LoadUSER_PagePage(gvUSER_Page, rptPager, 1, ddlPageSize);
        }
    }

    protected void gvUSER_Page_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                Label lblRowStatusID = (Label)e.Row.FindControl("lblRowStatusID");
                Label lblModuleID = (Label)e.Row.FindControl("lblModuleID");

                if (Convert.ToInt32(lblRowStatusID.Text) == 1)
                    lblRowStatusID.Text = "Active";
                else
                    lblRowStatusID.Text = "Deleted";

                int moduleID = Convert.ToInt32(lblModuleID.Text);
                if (moduleID > 0)
                    lblModuleID.Text = USER_ModuleManager.GetUSER_ModuleByModuleID(moduleID).ModuleName;
            }
            catch (Exception ex)
            {
            }
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        USER_PageManager.LoadUSER_PagePage(gvUSER_Page, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        USER_PageManager.LoadUSER_PagePage(gvUSER_Page, rptPager, pageIndex, ddlPageSize);
    }

    private void _loadModules()
    {
        try
        {
            DataSet ds = USER_ModuleManager.GetDropDownListAllUSER_Module();
            ddlModules.DataValueField = "ModuleID";
            ddlModules.DataTextField = "ModuleName";
            ddlModules.DataSource = ds.Tables[0];
            ddlModules.DataBind();
            ddlModules.Items.Insert(0, new ListItem("Select Module >>", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    protected void ddlModules_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int moduleID = Convert.ToInt32(ddlModules.SelectedValue);
            if (moduleID > 0)
            {
                List<USER_Page> pages = new List<USER_Page>();
                pages = USER_PageManager.GetUSER_PagesByModuleID(moduleID);

                gvUSER_Page.DataSource = pages;
                gvUSER_Page.DataBind();

                phPaging.Visible = false;
            }
            else
            {
                USER_PageManager.LoadUSER_PagePage(gvUSER_Page, rptPager, 1, ddlPageSize);
                phPaging.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminUSER_Page.aspx?ID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminUSER_Page.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = USER_PageManager.DeleteUSER_Page(Convert.ToInt32(linkButton.CommandArgument));
        USER_PageManager.LoadUSER_PagePage(gvUSER_Page, rptPager, 1, ddlPageSize);
    }


}

