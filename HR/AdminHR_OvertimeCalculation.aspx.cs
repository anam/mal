using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_AdminHR_OvertimeCalculation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            EmployeeIDLoad();
    }

    private void EmployeeIDLoad()
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        txtTotalOvertime.Text = string.Empty;
        txtTKHour.Text = string.Empty;
        txtTotalTaka.Text = string.Empty;

        
        HR_EmployeeOverTimePackage employeeOverTimePackage = HR_EmployeeOverTimePackageManager.GetHR_EmployeeOverTimePackageByEmployeeID(ddlEmployeeID.SelectedValue.ToString());
        if (employeeOverTimePackage != null)
        {
            
            if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty )
            {
                double overTimeHours = HR_OvertimeManager.GetHR_OvertimeByEmployeeIDAndDateInterval(ddlEmployeeID.SelectedValue.ToString(), Convert.ToDateTime(txtFromDate.Text.Trim()), Convert.ToDateTime(txtToDate.Text.Trim()));
                txtTotalOvertime.Text = overTimeHours.ToString();
                txtTKHour.Text = employeeOverTimePackage.OverTimeTakaPerHour.ToString("N2");
                txtTotalTaka.Text = (Convert.ToDecimal(overTimeHours) * employeeOverTimePackage.OverTimeTakaPerHour).ToString();
            }
        }
    }
}