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


public partial class AdminDisplayUSER_Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadModules();
            USER_MenuManager.LoadUSER_MenuPage(gvUSER_Menu, rptPager, 1, ddlPageSize);
        }
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
                List<USER_Menu> menus = new List<USER_Menu>();
                menus = USER_MenuManager.GetUSER_Menu_ByModuleID(moduleID);

                gvUSER_Menu.DataSource = menus;
                gvUSER_Menu.DataBind();

                phPaging.Visible = false;
            }
            else
            {
                USER_MenuManager.LoadUSER_MenuPage(gvUSER_Menu, rptPager, 1, ddlPageSize);
                phPaging.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvUSER_Menu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                Label lblRowStatusID = (Label)e.Row.FindControl("lblRowStatusID");
                //Label lblPageID = (Label)e.Row.FindControl("lblPageID");
                Label lblParentMenuTitle = (Label)e.Row.FindControl("lblParentMenuTitle");
                int parentMenuID = Convert.ToInt32(lblParentMenuTitle.Text);

                lblParentMenuTitle.Text = parentMenuID == 0 ? "<span style=\"color:red\">NA</span>" :USER_MenuManager.GetUSER_MenuByMenuID(parentMenuID).MenuTitle;
                if (Convert.ToInt32(lblRowStatusID.Text) == 1)
                    lblRowStatusID.Text = "Active";
                else
                    lblRowStatusID.Text = "Deleted";
            }
            catch (Exception ex)
            {
            }
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        USER_MenuManager.LoadUSER_MenuPage(gvUSER_Menu, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        USER_MenuManager.LoadUSER_MenuPage(gvUSER_Menu, rptPager, pageIndex, ddlPageSize);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminUSER_Menu.aspx?ID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminUSER_Menu.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = USER_MenuManager.DeleteUSER_Menu(Convert.ToInt32(linkButton.CommandArgument));
        USER_MenuManager.LoadUSER_MenuPage(gvUSER_Menu, rptPager, 1, ddlPageSize);
    }
}

