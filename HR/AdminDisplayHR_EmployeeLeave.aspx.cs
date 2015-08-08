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


public partial class AdminDisplayHR_EmployerType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnLeave.Visible = true;
            btnUpdate.Visible = !btnLeave.Visible;
            loadEmployee();
            loadLeaveType();            
        }
    }

    private void loadLeaveType()
    {
        List<LeaveType> allLeaves= LeaveTypeManager.GetAllLeaveTypes(); ;

        ListItem li = new ListItem("Select Type...", "0");
        ddlLeaveType.Items.Add(li);
        
        foreach (LeaveType dr in allLeaves)
        {
            ListItem item = new ListItem(dr.LeaveName, dr.LeaveTypeID.ToString());
            ddlLeaveType.Items.Add(item);
         
        }
    }
    private void loadEmployee()
    {
        DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();

        ListItem li = new ListItem("Select Employee...", "0");
        ddlAccountingUser.Items.Add(li);
        ddlEmployee.Items.Add(li);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (bool.Parse(dr["Flag"].ToString()) == true)
            {
                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeID"].ToString());
                ddlAccountingUser.Items.Add(item);
            }
        }

        ddlAccountingUser.SelectedValue = Profile.card_id;


        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (bool.Parse(dr["Flag"].ToString()) == true)
            {
                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeID"].ToString());
                ddlEmployee.Items.Add(item);
            }
        }

        //ddlAccountingUser.SelectedValue = Profile.card_id;
        //ddlEmployee.SelectedValue = Profile.card_id;

        gvEmpoyeeList.DataSource = ds.Tables[0];
        gvEmpoyeeList.DataBind();

    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        EmployeeLeave employeeLeave = new EmployeeLeave();
        employeeLeave = EmployeeLeaveManager.GetEmployeeLeaveByID(id);
        hfEmployeeLeaveID.Value = employeeLeave.EmployeeLeaveID.ToString();
        ddlAccountingUser.SelectedValue = employeeLeave.EmployeeID.ToString();
        txtDate.Text = employeeLeave.LeaveDate.ToString("dd MMM yyyy");
        ddlLeaveType.SelectedValue = employeeLeave.LeaveTypeID.ToString();

        btnLeave.Visible = false;
        btnUpdate.Visible = !btnLeave.Visible;
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = LeaveTypeManager.DeleteLeaveType(Convert.ToInt32(linkButton.CommandArgument));
        showEmployeeLeaveGrid();
    }

    private void showEmployeeLeaveGrid()
    {
        gvEmployeeLeave.DataSource = EmployeeLeaveManager.GetAllEmployeeLeaves();
        gvEmployeeLeave.DataBind();
    }
    protected void btnLeave_Click(object sender, EventArgs e)
    {
        //Single Employee
        int resutl=0;

        foreach (GridViewRow gr in gvEmpoyeeList.Rows)
        {
            HiddenField hfEmployeeID = (HiddenField)gr.FindControl("hfEmployeeID");
            CheckBox chkEmpployee = (CheckBox)gr.FindControl("chkEmpployee");
            if (chkEmpployee.Checked)
            {
                resutl += addLeave(hfEmployeeID.Value);
                chkEmpployee.Checked = false;
            }
        }

        if (txtEmployeeIDs.Text == "" && resutl ==0)
        {
            resutl = addLeave(ddlAccountingUser.SelectedValue);
        }
        else
            if (txtEmployeeIDs.Text != "") //multiple employeeID
            {

                string[] ids = txtEmployeeIDs.Text.Split(',');
                foreach (string id in ids)
                {
                    HR_Employee employee = HR_EmployeeManager.GetHR_EmployeeByEmployeeNo(id.Trim());
                    resutl += addLeave(employee.EmployeeID);
                }
            }
            

        lblMessage.Text = "<br/>" + resutl.ToString() + " entry added..";
        showEmployeeLeaveGrid();
    }

    private int addLeave(string employeeID)
    {
        int resutl = 0;

        if (txtDate.Text != "")//signle Date
        {
            EmployeeLeave employeeLeave = new EmployeeLeave();

            employeeLeave.EmployeeID = employeeID;
            employeeLeave.LeaveDate = DateTime.Parse(txtDate.Text);
            employeeLeave.LeaveTypeID = Int32.Parse(ddlLeaveType.SelectedValue);
            employeeLeave.AddedBy = Profile.card_id;
            employeeLeave.AddedDate = DateTime.Now;
            employeeLeave.UpdatedBy = Profile.card_id;
            employeeLeave.UpdateDate = DateTime.Now;
            employeeLeave.RowStatusID = 1;
            EmployeeLeaveManager.InsertEmployeeLeave(employeeLeave);
            resutl = 1;
        }
        else
            if (txtFromDateLeave.Text != "")//Date From And to
            {
                EmployeeLeave employeeLeave = new EmployeeLeave();

                employeeLeave.EmployeeID = employeeID;
                employeeLeave.LeaveTypeID = Int32.Parse(ddlLeaveType.SelectedValue);
                employeeLeave.AddedBy = Profile.card_id;
                employeeLeave.AddedDate = DateTime.Now;
                employeeLeave.UpdatedBy = Profile.card_id;
                employeeLeave.UpdateDate = DateTime.Now;
                employeeLeave.RowStatusID = 1;

                for (int i = 0; DateTime.Parse(txtFromDateLeave.Text).AddDays(i) <= DateTime.Parse(txtToDateLeave.Text); i++)
                {
                    employeeLeave.LeaveDate = DateTime.Parse(txtFromDateLeave.Text).AddDays(i);
                     EmployeeLeaveManager.InsertEmployeeLeave(employeeLeave);
                     resutl += 1;
                }
            }
            else
                if (txtMultipleDate.Text != "")//Date Multiple 
                {
                    EmployeeLeave employeeLeave = new EmployeeLeave();

                    employeeLeave.EmployeeID = employeeID;
                    employeeLeave.LeaveTypeID = Int32.Parse(ddlLeaveType.SelectedValue);
                    employeeLeave.AddedBy = Profile.card_id;
                    employeeLeave.AddedDate = DateTime.Now;
                    employeeLeave.UpdatedBy = Profile.card_id;
                    employeeLeave.UpdateDate = DateTime.Now;
                    employeeLeave.RowStatusID = 1;

                    foreach (String item in txtMultipleDate.Text.Split(','))
                    {
                        try
                        {
                            employeeLeave.LeaveDate = DateTime.Parse(item);
                            EmployeeLeaveManager.InsertEmployeeLeave(employeeLeave);
                            resutl += 1;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

        return resutl;
    }
    
    protected void btnShow_Click(object sender, EventArgs e)
    {


        gvEmployeeLeave.DataSource = EmployeeLeaveManager.GetAllEmployeeLeavesByEmployeeID(ddlEmployee.SelectedValue,txtDateFrom.Text,txtDateTo.Text);
        gvEmployeeLeave.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        EmployeeLeave employeeLeave = new EmployeeLeave();
        employeeLeave = EmployeeLeaveManager.GetEmployeeLeaveByID(Int32.Parse( hfEmployeeLeaveID.Value));
        EmployeeLeave tempEmployeeLeave = new EmployeeLeave();
        tempEmployeeLeave.EmployeeLeaveID = employeeLeave.EmployeeLeaveID;

        tempEmployeeLeave.EmployeeID = ddlAccountingUser.SelectedValue;
        tempEmployeeLeave.LeaveDate = DateTime.Parse(txtDate.Text);
        tempEmployeeLeave.LeaveTypeID = Int32.Parse(ddlLeaveType.SelectedValue);
        tempEmployeeLeave.AddedBy = employeeLeave.AddedBy;
        tempEmployeeLeave.AddedDate = employeeLeave.AddedDate;
        tempEmployeeLeave.UpdatedBy = Profile.card_id;
        tempEmployeeLeave.UpdateDate = DateTime.Now;
        tempEmployeeLeave.RowStatusID = 1;
        bool result = EmployeeLeaveManager.UpdateEmployeeLeave(tempEmployeeLeave);
        showEmployeeLeaveGrid();
        btnLeave.Visible = true;
        btnUpdate.Visible = !btnLeave.Visible;

        ddlAccountingUser.SelectedIndex = 0;
        txtDate.Text = "";
        ddlLeaveType.SelectedIndex = 0;

    }
}

