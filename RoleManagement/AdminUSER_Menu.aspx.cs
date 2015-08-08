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
public partial class AdminUSER_Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadModules();
            PageIDLoad();
            RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showUSER_MenuData();
            }
            else
                ddlParentMenu.Items.Insert(0, new ListItem("Select Menu>>", "0"));
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        USER_Menu uSER_Menu = new USER_Menu();
        uSER_Menu.PageID = int.Parse(ddlPageID.SelectedValue);
        uSER_Menu.ModuleID = Convert.ToInt32(ddlModules.SelectedValue);
        uSER_Menu.MenuTitle = txtMenuTitle.Text;
        uSER_Menu.ParentMenuID = Convert.ToInt32(ddlParentMenu.SelectedValue);
        uSER_Menu.AddedBy = "Admin";
        uSER_Menu.AddedDate = DateTime.Now;
        uSER_Menu.UpdatedBy = "Admin";
        uSER_Menu.UpdatedDate = DateTime.Now;
        uSER_Menu.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
        int resutl = USER_MenuManager.InsertUSER_Menu(uSER_Menu);
        Response.Redirect("AdminDisplayUSER_Menu.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            USER_Menu uSER_Menu = new USER_Menu();
            uSER_Menu.MenuID = int.Parse(Request.QueryString["ID"].ToString());
            uSER_Menu.PageID = int.Parse(ddlPageID.SelectedValue);
            uSER_Menu.ModuleID = Convert.ToInt32(ddlModules.SelectedValue);
            uSER_Menu.MenuTitle = txtMenuTitle.Text;
            uSER_Menu.ParentMenuID = Convert.ToInt32(ddlParentMenu.SelectedValue);
            uSER_Menu.AddedBy = "Admin";
            uSER_Menu.AddedDate = DateTime.Now;
            uSER_Menu.UpdatedBy = "Admin";
            uSER_Menu.UpdatedDate = DateTime.Now;
            uSER_Menu.RowStatusID = int.Parse(ddlRowStatusID.SelectedValue);
            bool resutl = USER_MenuManager.UpdateUSER_Menu(uSER_Menu);
            Response.Redirect("AdminDisplayUSER_Menu.aspx");
        }
        catch (Exception ex)
        {
        }
    }

    private void showUSER_MenuData()
    {
        try
        {
            USER_Menu uSER_Menu = new USER_Menu();

            uSER_Menu = USER_MenuManager.GetUSER_MenuByMenuID(Int32.Parse(Request.QueryString["ID"]));
            ddlModules.SelectedValue = uSER_Menu.ModuleID.ToString();
            ddlModules_SelectedIndexChanged(new object(), new EventArgs());
            ddlPageID.SelectedValue = uSER_Menu.PageID.ToString();
            txtMenuTitle.Text = uSER_Menu.MenuTitle.ToString();
            ddlParentMenu.SelectedValue = uSER_Menu.ParentMenuID.ToString();
            ddlRowStatusID.SelectedValue = uSER_Menu.RowStatusID.ToString();
        }
        catch (Exception ex)
        {
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
            ex.Message.ToString();
        }
    }

    protected void ddlModules_SelectedIndexChanged(object sender, EventArgs e)
    {
        int moduleID=0;
        try
        {
             moduleID= Convert.ToInt32(ddlModules.SelectedValue);
            List<USER_Page> pages = USER_PageManager.GetUSER_PagesByModuleID(moduleID);

            ddlPageID.DataValueField = "PageID";
            ddlPageID.DataTextField = "PageTitle";

            ddlPageID.DataSource = pages;
            ddlPageID.DataBind();
            ddlPageID.Items.Insert(0, new ListItem("Select Page >>", "0"));
        }
        catch (Exception ex)
        {
        }

        try
        {
            List<USER_Menu> parentMenus = USER_MenuManager.GetUSER_Menu_ByModuleID(moduleID);
            parentMenus = parentMenus.FindAll(X => X.ParentMenuID ==0);
            ddlParentMenu.DataValueField = "MenuID";
            ddlParentMenu.DataTextField = "MenuTitle";
            ddlParentMenu.DataSource = parentMenus;
            ddlParentMenu.DataBind();

            ddlParentMenu.Items.Insert(0, new ListItem("Select Menu>>", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void PageIDLoad()
    {
        try
        {
            DataSet ds = USER_PageManager.GetDropDownListAllUSER_Page();
            ddlPageID.DataValueField = "PageID";
            ddlPageID.DataTextField = "PageTitle";
            ddlPageID.DataSource = ds.Tables[0];
            ddlPageID.DataBind();
            ddlPageID.Items.Insert(0, new ListItem("Select Page >>", "0"));

            ddlRowStatusID.SelectedValue = ((int)Enums.RowStatus.Active).ToString();
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
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

