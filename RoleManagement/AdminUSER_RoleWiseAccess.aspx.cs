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
public partial class AdminUSER_RoleWiseAccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadModules();
            
            RoleIDLoad();
            _loadPages();
            RowStatusIDLoad();
        }

        //if (lbxModules.SelectedIndex >= 0 && ddlRoleID.SelectedIndex > 0)
        //    btnSubmit.Visible = true;
        //else
        //    btnSubmit.Visible = false;

       
    }

    private void _loadModules()
    {
        try
        {
            DataSet ds = USER_ModuleManager.GetDropDownListAllUSER_Module();
            lbxModules.DataValueField = "ModuleID";
            lbxModules.DataTextField = "ModuleName";
            lbxModules.DataSource = ds.Tables[0];
            lbxModules.DataBind();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void lbxModules_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            _loadPages();
        }
        catch(Exception ex)
        {
        }
    }

    protected void ddlRoleID_SelectedIndexChanged(object sender, EventArgs e)
    {
        _refreshPageAccess();
    }

    private void _loadPages()
    {
        try
        {
            List<USER_Page> pages=new List<USER_Page>();
            if(lbxModules.SelectedIndex!=-1)
            {
                int moduleID=Convert.ToInt32(lbxModules.SelectedValue);
                pages=USER_PageManager.GetUSER_PagesByModuleID(moduleID);
            }

            gvPagesAndAccess.DataSource = pages;
            gvPagesAndAccess.DataBind();

            if (gvPagesAndAccess.Rows.Count > 0)
                btnSubmit.Visible = true;
            else
                btnSubmit.Visible = false;
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvPagesAndAccess_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    CheckBoxList cblOperations = (CheckBoxList)e.Row.FindControl("cblOperations");
        //    CheckBox cbAssigned = (CheckBox)e.Row.FindControl("cbAssigned");
        //    HiddenField hfPageID = (HiddenField)e.Row.FindControl("hfPageID");
        //    try
        //    {
        //        cblOperations.DataValueField = "OperationID";
        //        cblOperations.DataTextField = "OperationName";

        //        DataSet ds = USER_OperationManager.GetDropDownListAllUSER_Operation();
        //        cblOperations.DataSource = ds;
        //        cblOperations.DataBind();

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
    }

    protected void gvPagesAndAccess_DataBound(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;
        string roleID = ddlRoleID.SelectedValue;
        List<USER_RoleWiseAccess> accesses = new List<USER_RoleWiseAccess>();
        accesses = USER_RoleWiseAccessManager.GetUSER_RoleWiseAccessesByRoleID(roleID);

        foreach (GridViewRow row in gv.Rows)
        {
            CheckBoxList cblOperations = (CheckBoxList)row.FindControl("cblOperations");
            
            try
            {
                cblOperations.DataValueField = "OperationID";
                cblOperations.DataTextField = "OperationName";

                DataSet ds = USER_OperationManager.GetDropDownListAllUSER_Operation();
                cblOperations.DataSource = ds;
                cblOperations.DataBind();

            }
            catch (Exception ex)
            {
            }
        }
        _refreshPageAccess();
    }

    private void _refreshPageAccess()
    {
        if (ddlRoleID.SelectedIndex > 0)
        {
            string roleID = ddlRoleID.SelectedValue;
            List<USER_RoleWiseAccess> accesses = new List<USER_RoleWiseAccess>();
            accesses = USER_RoleWiseAccessManager.GetUSER_RoleWiseAccessesByRoleID(roleID);

            foreach (GridViewRow row in gvPagesAndAccess.Rows)
            {
                CheckBoxList cblOperations = (CheckBoxList)row.FindControl("cblOperations");
                CheckBox cbAssigned = (CheckBox)row.FindControl("cbAssigned");
                HiddenField hfPageID = (HiddenField)row.FindControl("hfPageID");
                List<USER_RoleWiseAccess> pageWiseAccesses = new List<USER_RoleWiseAccess>();

                int pageID = Convert.ToInt32(hfPageID.Value);

                try
                {
                    pageWiseAccesses = accesses.FindAll(X => X.PageID == pageID);
                    if (pageWiseAccesses.Count > 0 && pageWiseAccesses.FindAll(X => X.RowStatusID == 1).Count>0)
                    {
                        cbAssigned.Checked = true;
                        for (int i = 0; i < cblOperations.Items.Count; i++)
                        {
                            cblOperations.Items[i].Selected = pageWiseAccesses.Find(X => X.OperationID == Convert.ToInt32(cblOperations.Items[i].Value)).Access;
                        }
                    }
                    else
                    {
                        cbAssigned.Checked = false;
                        for (int i = 0; i < cblOperations.Items.Count; i++)
                        {
                            cblOperations.Items[i].Selected = false;
                        }
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRoleID.SelectedIndex > 0)
            {
                foreach (GridViewRow row in gvPagesAndAccess.Rows)
                {
                    string roleName = ddlRoleID.SelectedValue;
                    HiddenField hfPageID = (HiddenField)row.FindControl("hfPageID");
                    int pageID = Convert.ToInt32(hfPageID.Value);
                    USER_RoleWiseAccess uSER_RoleWiseAccess = new USER_RoleWiseAccess();
                    uSER_RoleWiseAccess.PageID = pageID;
                    uSER_RoleWiseAccess.RoleID = roleName;

                    uSER_RoleWiseAccess.AddedBy = "Admin";
                    uSER_RoleWiseAccess.AddedDate = DateTime.Now;
                    uSER_RoleWiseAccess.UpdatedBy = "Admin";
                    uSER_RoleWiseAccess.UpdatedDate = DateTime.Now;

                    CheckBox cbAssigned = (CheckBox)row.FindControl("cbAssigned");
                    if (cbAssigned.Checked)
                        uSER_RoleWiseAccess.RowStatusID = (int)Enums.RowStatus.Active;//Here is something to do later.
                    else
                        uSER_RoleWiseAccess.RowStatusID = (int)Enums.RowStatus.Deleted;

                    CheckBoxList cblOperations = (CheckBoxList)row.FindControl("cblOperations");
                    foreach (ListItem li in cblOperations.Items)
                    {
                        uSER_RoleWiseAccess.OperationID = int.Parse(li.Value);
                        uSER_RoleWiseAccess.Access = li.Selected;

                        int resutl = USER_RoleWiseAccessManager.InsertUSER_RoleWiseAccess(uSER_RoleWiseAccess);
                    }
                }
                _loadPages();
            }
        }
        catch (Exception ex)
        {
        }
    }
    
    private void RoleIDLoad()
    {
        try
        {
            //DataSet ds = UserRoleManager.GetDropDownListAllUserRole();
            //ddlRoleID.DataValueField = "RoleID";
            //ddlRoleID.DataTextField = "RoleName";

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

    private void RowStatusIDLoad()
    {
        try
        {
            //DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
            //ddlRowStatusID.DataValueField = "RowStatusID";
            //ddlRowStatusID.DataTextField = "RowStatusName";
            //ddlRowStatusID.DataSource = ds.Tables[0];
            //ddlRowStatusID.DataBind();
            //ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

