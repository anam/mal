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


public partial class AdminDisplayHR_Employee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEmployeeType();
            LoadDepartment();
            DesignationIDLoad();
            HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, 1, ddlPageSize, true);
            string totalItem = gvHR_Employee.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
        }
    }

    private void LoadEmployeeType()
    {
        DataSet ds = HR_EmployerTypeManager.GetDropDownListAllHR_EmployerType();
        ddlEmployeeTypeSer.DataValueField = "EmployerType";
        ddlEmployeeTypeSer.DataTextField = "EmployerTypeName";
        ddlEmployeeTypeSer.DataSource = ds.Tables[0];
        ddlEmployeeTypeSer.DataBind();
        ddlEmployeeTypeSer.Items.Insert(0, new ListItem("All Type >>", "0"));
    }

    private void LoadDepartment()
    {
        DataSet allDepartment = HR_DepartmentManager.GetDropDownListAllHR_Department();
        ddlDepartment.DataValueField = "DepartmentID";
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataSource = allDepartment.Tables[0];
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, new ListItem("All Department >>", "0"));
    }

    private void DesignationIDLoad()
    {
        try
        {
            DataSet ds = HR_DesignationManager.GetDropDownListAllHR_Designation();
            ddlDesignationNameSer.DataValueField = "DesignationID";
            ddlDesignationNameSer.DataTextField = "DesignationName";
            ddlDesignationNameSer.DataSource = ds.Tables[0];
            ddlDesignationNameSer.DataBind();
            ddlDesignationNameSer.Items.Insert(0, new ListItem("All Designation >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void DesignationIDLoad(int departmentNo)
    {
        try
        {
            DataSet ds = HR_DesignationManager.GetHR_DesignationByDepartmentID(departmentNo);
            ddlDesignationNameSer.DataValueField = "DesignationID";
            ddlDesignationNameSer.DataTextField = "DesignationName";
            ddlDesignationNameSer.DataSource = ds.Tables[0];
            ddlDesignationNameSer.DataBind();
            ddlDesignationNameSer.Items.Insert(0, new ListItem("All Designation >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void ddlDepartment_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlDepartment.SelectedValue) > 0)
        {
            DesignationIDLoad(Convert.ToInt32(ddlDepartment.SelectedValue));
        }
        else
        {
            DesignationIDLoad();
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        // HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, 1, ddlPageSize);
        if (chkAllEmployee.Checked)
        {
            HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, 1, ddlPageSize);
            string totalItem = gvHR_Employee.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
        }
        else
        {
            HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, 1, ddlPageSize, true);
            string totalItem = gvHR_Employee.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
        }
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        if (chkAllEmployee.Checked)
        {
            HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, pageIndex, ddlPageSize);
            string totalItem = gvHR_Employee.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
        }
        else
        {
            HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, pageIndex, ddlPageSize, true);
            string totalItem = gvHR_Employee.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHR_Employee.aspx?ID=0");
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        string id;
        id = linkButton.CommandArgument;
        Response.Redirect("AdminHR_Employee.aspx?ID=" + id);
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        try
        {
            bool result = HR_EmployeeManager.DeleteHR_EmployeeChnageRowStatusID(Convert.ToString(linkButton.CommandArgument));
            //bool result = HR_EmployeeManager.DeleteHR_EmployeePermanently(Convert.ToString(linkButton.CommandArgument));
            HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, 1, ddlPageSize, true);
            string totalItem = gvHR_Employee.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvHR_Employee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblimagename = (Label)e.Row.FindControl("lblPhoto");

            Image imgphoto = (Image)e.Row.FindControl("imgPhoto");

            if (lblimagename.Text.Trim() == string.Empty)
            {
                imgphoto.ImageUrl = String.Format("~/App_Themes/CoffeyGreen/images/NoImage.jpg");
            }
            else
            {
                imgphoto.ImageUrl = "~/HR/upload/employeer/" + lblimagename.Text;
            }
            
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            if (lblStatus.Text.Trim() != string.Empty)
            {
                if (lblStatus.Text.Trim().Equals("True"))
                {
                    lblStatus.Text = "Active";
                }
                else
                {
                    lblStatus.Text = "Left";
                }
            }

            //string str = Server.MapPath(imgphoto.ImageUrl);
        }
    }

    protected void chkAllEmployee_OnCheckedChanged(object sender, EventArgs e)
    {
        if (chkAllEmployee.Checked)
        {
            HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, 1, ddlPageSize);
            string totalItem = gvHR_Employee.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
        }
        else
        {
            HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, 1, ddlPageSize, true);
            string totalItem = gvHR_Employee.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
        }
    }

    protected void btnStatistic_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlDepartment.SelectedValue) > 0)
        {
            HR_Department department = HR_DepartmentManager.GetHR_DepartmentByDepartmentID(Convert.ToInt32(ddlDepartment.SelectedValue));
            if (department != null)
            {
                lblDepartmentName.Text = "Department Name : " + department.DepartmentName;
                departmentID.Value = department.DepartmentID.ToString();
            }
        }
        else
        {
            lblDepartmentName.Text = "All Department Information";
            departmentID.Value = "0";
        }

        DataSet empStatisticDataSet = HR_EmployeeManager.GetHR_EmployeeStatisticDepartWise(Convert.ToInt32(ddlDepartment.SelectedValue));
        int totalEmp = 0;
        foreach (DataRow row in empStatisticDataSet.Tables[0].Rows)
        {
            totalEmp += Convert.ToInt32(row["TotalEmployee"]);
        }
        lblTotalDesignation.Text = "Total Designation : " + empStatisticDataSet.Tables[0].Rows.Count.ToString();
        lblTotalEmployee.Text = "Total Employee : " + totalEmp.ToString();
        gvStatisticOfEmp.DataSource = empStatisticDataSet.Tables[0];
        gvStatisticOfEmp.DataBind();

        divStatistic.Visible = true;
    }

    protected void btnHideStatistic_Click(object sender, EventArgs e)
    {
        divStatistic.Visible = false;
    }

    protected void btnEmpIDCard_Click(object sender, EventArgs e)
    {
        //
        Response.Redirect("~/idCardPage.aspx?DepartID=" + departmentID.Value);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchOption();
        ////updatePanel.Update();
    }

    private void SearchOption()
    {
        divStatistic.Visible = false;
        try
        {
            if (txtEmployeeNo.Text.Trim() != string.Empty)
            {
                string sqlSearchString = " Where HR_Employee.EmployeeNo = \'" + txtEmployeeNo.Text.Trim() + "\'";
                gvHR_Employee.DataSource = HR_EmployeeManager.GetAllHR_EmployeesBySearch(sqlSearchString);
                gvHR_Employee.DataBind();
                rptPager.DataSource = null;
                rptPager.DataBind();

                string totalItem = gvHR_Employee.Rows.Count.ToString("N");
                string[] totalItems = totalItem.Split('.');
                lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
            }
            else
            {
                string sqlSearchString = "Where HR_Employee.RowStatusID=1 ";

                if (txtEmployeeNameSer.Text.Trim() != string.Empty)
                {
                    sqlSearchString += " AND HR_Employee.EmployeeName like '%" + txtEmployeeNameSer.Text.Trim() + "%'";
                }

                if (Convert.ToInt32(ddlDesignationNameSer.SelectedValue) > 0)
                {
                    sqlSearchString += " AND HR_Employee.DesignationID = " + ddlDesignationNameSer.SelectedValue;
                }

                if (Convert.ToInt32(ddlEmployeeTypeSer.SelectedValue) > 0)
                {
                    sqlSearchString += " AND HR_Employee.EmployeeType = " + ddlEmployeeTypeSer.SelectedValue;
                }

                if (txtJoiningFromDate.Text.Trim() != string.Empty)
                {
                    sqlSearchString += " AND HR_Employee.JoiningDate >= '" + (Convert.ToDateTime(txtJoiningFromDate.Text.Trim())).ToString() + "'";
                }

                if (txtJoiningToDate.Text.Trim() != string.Empty)
                {
                    sqlSearchString += " AND HR_Employee.JoiningDate <= '" + (Convert.ToDateTime(txtJoiningToDate.Text.Trim())).ToString() + "'";
                }

                if (sqlSearchString.StartsWith("Where AND"))
                {
                    sqlSearchString = sqlSearchString.Replace("Where AND", "Where ");
                }

                if (sqlSearchString.Trim() != "Where")
                {
                    gvHR_Employee.DataSource = HR_EmployeeManager.GetAllHR_EmployeesBySearch(sqlSearchString + "order by HR_Employee.AddedDate");
                    gvHR_Employee.DataBind();
                    rptPager.DataSource = null;
                    rptPager.DataBind();

                    string totalItem = gvHR_Employee.Rows.Count.ToString("N");
                    string[] totalItems = totalItem.Split('.');
                    lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
                }
                else
                {
                    HR_EmployeeManager.LoadHR_EmployeePage(gvHR_Employee, rptPager, 1, ddlPageSize, true);
                    string totalItem = gvHR_Employee.Rows.Count.ToString("N");
                    string[] totalItems = totalItem.Split('.');
                    lblGrandTotalEmployee.Text = "Total : " + totalItems[0];
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvHR_Employee_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

