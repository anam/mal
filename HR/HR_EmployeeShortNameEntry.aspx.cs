using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HR_HR_EmployeeShortNameEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvHR_Employee.DataSource = HR_EmployeeManager.GetAllHR_Employees();
            gvHR_Employee.DataBind();
        }
    }
    protected void btnUpdate_OnClick(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvHR_Employee.Rows)
        {
            Label lblEmployeeID = (Label)row.FindControl("lblEmployeeID");
            TextBox txtShortName = (TextBox)row.FindControl("txtShortName");
            TextBox txtNickName = (TextBox)row.FindControl("txtNickName");

            HR_Employee employee = HR_EmployeeManager.GetHR_EmployeeByEmployeeID(lblEmployeeID.Text);

            if (txtShortName.Text != "")

                employee.ExtraField1 = txtShortName.Text;
            else
                employee.ExtraField1 = "N/A";
                

            if (txtNickName.Text != "")
                employee.ExtraField2 = txtNickName.Text;
            else
                employee.ExtraField2 = "N/A";

            bool result = HR_EmployeeManager.UpdateHR_EmployeeName(employee);
        }

        gvHR_Employee.DataSource = HR_EmployeeManager.GetAllHR_Employees();
        gvHR_Employee.DataBind();
    }
}