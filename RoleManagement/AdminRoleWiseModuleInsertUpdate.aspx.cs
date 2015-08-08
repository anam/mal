using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class RoleManagement_AdminRoleWiseModuleInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadModules();
            loadRole();
        }
    }

    private void _loadModules()
    {
        try
        {
            List<ListItem> modules = new List<ListItem>();
            lbxModules.Items.Clear();

            if (Session["modules"] != null)
               modules = (List<ListItem>)Session["modules"];
            else
            {
                DataSet ds = USER_ModuleManager.GetDropDownListAllUSER_Module();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ListItem li = new ListItem();
                    li.Value = dr["ModuleID"].ToString();
                    li.Text = dr["ModuleName"].ToString();

                    modules.Add(li);
                }

                Session["modules"] = modules;
            }
            
            lbxModules.Items.AddRange(modules.ToArray());

            _sortList(lbxModules);
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnAddModule_Click(object sender, EventArgs e)
    {
        if (ddlRole.SelectedIndex > 0)
        {
            try
            {
                int _selectedIndex = lbxModules.SelectedIndex;
                while (lbxModules.SelectedIndex >= 0)
                {
                    RoleWiseModule roleWiseModule = new RoleWiseModule();

                    roleWiseModule.ModuleID = Int32.Parse(lbxModules.SelectedValue);
                    roleWiseModule.RoleID = ddlRole.SelectedValue;
                    roleWiseModule.AddedBy = "Admin";
                    roleWiseModule.AddedDate = DateTime.Now;
                    roleWiseModule.UpdatedBy = "Admin";
                    roleWiseModule.UpdatedDate = DateTime.Now;
                    roleWiseModule.RowStatusID = (int)Enums.RowStatus.Active;
                    int resutl = RoleWiseModuleManager.InsertRoleWiseModule(roleWiseModule);
                    if (resutl > 0)
                    {
                        lbxRoleWiseModules.Items.Add(lbxModules.SelectedItem);
                        lbxModules.Items.RemoveAt(_selectedIndex);
                    }
                    else
                        continue;
                }

                _sortList(lbxModules);
                _sortList(lbxRoleWiseModules);
                if (lbxModules.Items.Count == _selectedIndex)
                    lbxModules.SelectedIndex = _selectedIndex - 1;
                else
                    lbxModules.SelectedIndex = _selectedIndex;
                lbxRoleWiseModules.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
        }
    }

    protected void btnRemoveModule_Click(object sender, EventArgs e)
    {
        int _selectedIndex = lbxRoleWiseModules.SelectedIndex;
        while (lbxRoleWiseModules.SelectedIndex >= 0)
        {
            RoleWiseModule roleWiseModule = new RoleWiseModule();
            //roleWiseModule = RoleWiseModuleManager.GetRoleWiseModuleByID(Int32.Parse(lbxRoleWiseModules.SelectedValue));
            roleWiseModule.RoleID = ddlRole.SelectedValue;
            roleWiseModule.ModuleID = Convert.ToInt32(lbxRoleWiseModules.SelectedValue);
            roleWiseModule.AddedBy = "";
            roleWiseModule.AddedDate = DateTime.Now;
            roleWiseModule.UpdatedBy = "Admin";
            roleWiseModule.UpdatedDate = DateTime.Now;
            roleWiseModule.RowStatusID = (int)Enums.RowStatus.Deleted;
            bool result = RoleWiseModuleManager.UpdateRoleWiseModule(roleWiseModule);
            if (result)
            {
                lbxModules.Items.Add(lbxRoleWiseModules.SelectedItem);
                lbxRoleWiseModules.Items.RemoveAt(_selectedIndex);                
            }
            else
                continue;
        }

        _sortList(lbxModules);
    }
    
    private void loadRole()
    {
        try
        {
            string[] roles = Roles.GetAllRoles();
            ddlRole.DataSource = roles;
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, new ListItem("Select Role >>", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedIndex > 0)
        {
            try
            {
                _loadModules();
                lbxRoleWiseModules.Items.Clear();
                List<ListItem> modules = (List<ListItem>)Session["modules"];
                List<ListItem> assignedModules = new List<ListItem>();
                List<RoleWiseModule> roleWiseModules = RoleWiseModuleManager.GETRoleWiseModulesByRoleID(ddlRole.SelectedValue);
                foreach (RoleWiseModule rm in roleWiseModules)
                {   
                    ListItem li = modules.Find(X => (X.Value == rm.ModuleID.ToString() && rm.RowStatusID==(int)Enums.RowStatus.Active));
                    if (li != null)
                    {
                        assignedModules.Add(li);
                        lbxModules.Items.Remove(li);
                    }
                }

                lbxRoleWiseModules.Items.AddRange(assignedModules.ToArray());
                _sortList(lbxRoleWiseModules);

            }
            catch (Exception ex)
            {
            }
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