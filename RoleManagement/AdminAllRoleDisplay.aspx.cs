using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

public partial class RoleManagement_AdminAllRoleDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RefreshAllRolesListBox();
            _loadUsers();
            RefreshCurrentRolesListBox();

            //_assignRoleToStudent();
        }
    }

    private void _loadUsers()
    {
        try
        {
            //ddlUsername.DataSource = Membership.GetAllUsers();

            //DataSet dsStudent = STD_StudentManager.GetAllSTD_Students();
            //ddlUsername.DataValueField = "StudentCode";
            //ddlUsername.DataTextField = "StudentName";
            //ddlUsername.DataSource = dsStudent;
            DataSet dsEmployee = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlUsername.DataValueField = "EmployeeNo";
            ddlUsername.DataTextField = "EmployeeNameNo";
            ddlUsername.DataSource = dsEmployee;

            ddlUsername.DataBind();
            ddlUsername.Items.Insert(0, new ListItem("...Select User...", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnDeleteRole_Click(object sender, EventArgs e)
    {
        if (lbxAvailableRoles.SelectedIndex != -1)
        {
            string selectedRole = lbxAvailableRoles.SelectedValue;

            try
            {
                Roles.DeleteRole(selectedRole);
                RefreshAllRolesListBox();
            }
            catch (Exception ex)
            {

            }
        }

    }
    protected void btnInsertRole_Click(object sender, EventArgs e)
    {
        if (!Roles.RoleExists(txtRoleName.Text))
        {
            Roles.CreateRole(txtRoleName.Text);
            RefreshAllRolesListBox();
            txtRoleName.Text = "";
            lblRoleInfoText.Text = "Insert Successfully";
        }
        else
        {
            lblRoleInfoText.Text = "Already Exists";
        }
    }

    protected void RefreshAllRolesListBox()
    {
        try
        {
            string[] roles = Roles.GetAllRoles();
            lbxAvailableRoles.DataSource = roles;
            lbxAvailableRoles.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    #region User In Role

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        lblResults.Text = "";
        lblUserRoleInfoText.Text = "";
        if (lbxAvailableRoles.SelectedIndex != -1 && ddlUsername.SelectedIndex>0)
        {
            string selectedRole = lbxAvailableRoles.SelectedValue;
            string userName=ddlUsername.SelectedItem.Text;
            //MembershipUser user = Membership.GetUser(ddlUsername.SelectedItem.Text);
            
            if (!Roles.IsUserInRole(userName, selectedRole))
            {
                try
                {
                    Roles.AddUserToRole(ddlUsername.SelectedItem.Value.ToString(), selectedRole);
                    RefreshCurrentRolesListBox();
                    //lblResults.Text = "Add Successfully";

                }
                catch (Exception ex)
                {
                    //lblResults.Text = "Could not add the user to the role: " + Server.HtmlEncode(ex.Message);
                    //lblResults.Visible = true;
                }
            }
            else
            {
                lbxAvailableRoles.SelectedIndex = -1;
                //lblResults.Text = "Already Exists";
            }
        }

    }

    private void RefreshCurrentRolesListBox()
    {
        lblResults.Text = "";
        lblUserRoleInfoText.Text = "";

        lbxUserRoles.SelectedIndex = -1;
        lbxUserRoles.DataSource = Roles.GetRolesForUser(ddlUsername.SelectedItem.Value.ToString());
        lbxUserRoles.DataBind();
        if (lbxUserRoles.Items.Count == 0)
        {
            //lblUserRoleInfoText.Text = "The user currently does not belong to any roles.";
            lbxUserRoles.Visible = true;
            btnDeleteUserFromRole.Visible = false;
            //Label1.Visible = false;

        }
        else
        {
            //lblUserRoleInfoText.Text = "Removed Successfully";
            lbxUserRoles.Visible = true;
            btnDeleteUserFromRole.Visible = true;
        }

    }

    protected void btnDeleteUserFromRole_Click(object sender, EventArgs e)
    {
        lblResults.Text = "";
        lblUserRoleInfoText.Text = "";

        if (lbxUserRoles.SelectedIndex != -1)
        {
            string selectedRole = lbxUserRoles.SelectedValue;

            try
            {
                Roles.RemoveUserFromRole(ddlUsername.SelectedItem.Value.ToString(), selectedRole);
                RefreshCurrentRolesListBox();
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void ddlUsername_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshCurrentRolesListBox();
    }
    #endregion

    #region Assign Role to Student
    private void _assignRoleToStudent()
    {
        try
        {
            DataSet dsStudent = STD_StudentManager.GetAllSTD_Students();
            ddlUsername.DataValueField = "StudentCode";
            ddlUsername.DataTextField = "StudentName";

            string selectedRole = "Student";

            foreach (DataRow dr in dsStudent.Tables[0].Rows)
            {
                string userName = dr["StudentCode"].ToString();

                if (!Roles.IsUserInRole(userName, selectedRole))
                {
                    Roles.AddUserToRole(userName, selectedRole);
                }
                else
                {
                    lbxAvailableRoles.SelectedIndex = -1;
                    //lblResults.Text = "Already Exists";
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    #endregion
}