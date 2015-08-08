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
public partial class AdminUSER_RoleWiseMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadModules(string.Empty);

            RoleIDLoad();
        }
    }
    
    private void RoleIDLoad()
    {
        try
        {
            string[] roles = Roles.GetAllRoles();
            ddlRoleID.DataSource = roles;
            ddlRoleID.DataBind();
            ddlRoleID.Items.Insert(0, new ListItem("Select Role >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void ddlRoleID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRoleID.SelectedIndex > 0)
        {
            try
            {
                _loadModules(ddlRoleID.SelectedValue);
                _loadMenus();
            }
            catch (Exception ex)
            {
            }
        }
    }

    private void _loadModules(string roleID)
    {
        try
        {
            List<RoleWiseModule> roleWiseModules = RoleWiseModuleManager.GETRoleWiseModulesByRoleID(roleID);
            
            lbxModules.DataValueField = "ModuleID";
            lbxModules.DataTextField = "ModuleName";

            lbxModules.DataSource = roleWiseModules.FindAll(X => X.RowStatusID == (int)Enums.RowStatus.Active);
            lbxModules.DataBind();

            if (lbxModules.Items.Count > 0)
            {
                _sortList(lbxModules);
                lbxModules.Visible = true;
            }
            else
                lbxModules.Visible = false;
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void _loadMenus()
    {
        try
        {
            List<USER_Menu> menus = new List<USER_Menu>();
            if (lbxModules.SelectedIndex != -1)
            {
                int moduleID = Convert.ToInt32(lbxModules.SelectedValue);
                menus = USER_MenuManager.GetUSER_Menu_ByModuleID(moduleID);
            }

            //ViewState["menus"] = menus;
            gvMenuAccess.DataSource = menus;
            gvMenuAccess.DataBind();

            if (gvMenuAccess.Rows.Count > 0)
                btnSubmit.Visible = true;
            else
                btnSubmit.Visible = false;
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvMenuAccess_DataBound(object sender, EventArgs e)
    {
        try
        {
            List<USER_RoleWiseMenu> r_menus = USER_RoleWiseMenuManager.GetUSER_RoleWiseMenuByRoleID(ddlRoleID.SelectedValue);
            foreach (GridViewRow row in gvMenuAccess.Rows)
            {
                int menuID = Convert.ToInt32(((HiddenField)row.FindControl("hfMenuID")).Value);
                CheckBox cbIsAssigned = (CheckBox)row.FindControl("cbIsAssigned");
                cbIsAssigned.Checked = r_menus.Exists(X => (X.MenuID == menuID && X.RowStatusID==(int)Enums.RowStatus.Active));
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbxModules_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            _loadMenus();
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {   
            if (ddlRoleID.SelectedIndex > 0 && lbxModules.SelectedIndex != -1)
            {
                string roleID = ddlRoleID.SelectedValue;
                bool isUpdated = false;
                foreach (GridViewRow row in gvMenuAccess.Rows)
                {
                    CheckBox cbIsAssigned = (CheckBox)row.FindControl("cbIsAssigned");
                    int menuID = Convert.ToInt32(((HiddenField)row.FindControl("hfMenuID")).Value);

                    USER_RoleWiseMenu uSER_RoleWiseMenu = new USER_RoleWiseMenu();
                    uSER_RoleWiseMenu.ID = 0;
                    uSER_RoleWiseMenu.MenuID = menuID;
                    uSER_RoleWiseMenu.RoleID = roleID;
                    uSER_RoleWiseMenu.AddedBy = "Admin";
                    uSER_RoleWiseMenu.AddedDate = DateTime.Now;
                    uSER_RoleWiseMenu.UpdatedBy = "Admin";
                    uSER_RoleWiseMenu.UpdatedDate = DateTime.Now;

                    if (cbIsAssigned.Checked)
                    {
                        uSER_RoleWiseMenu.RowStatusID = (int)Enums.RowStatus.Active;
                    }
                    else
                    {
                        uSER_RoleWiseMenu.RowStatusID = (int)Enums.RowStatus.Deleted;
                    }

                    int result = USER_RoleWiseMenuManager.InsertUSER_RoleWiseMenu(uSER_RoleWiseMenu);
                    if (result > 0)
                        isUpdated = true;
                }

                if (isUpdated)
                {
                    _loadMenus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('Updated Successfully!!');", true);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    #region Sorting
    private void _sortList(ListBox lbList)
    {
        try
        {
            List<ListItem> t = new List<ListItem>();
            Comparison<ListItem> compare = new Comparison<ListItem>(CompareListItems);
            foreach (ListItem lbItem in lbList.Items)
                t.Add(lbItem);
            t.Sort(compare);
            lbList.Items.Clear();
            lbList.Items.AddRange(t.ToArray());
        }
        catch (Exception ex)
        {
        }
    }
    int CompareListItems(ListItem li1, ListItem li2)
    {
        return String.Compare(li1.Text, li2.Text);
    }
    #endregion
    
}

