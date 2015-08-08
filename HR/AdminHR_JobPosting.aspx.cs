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
 public partial class AdminHR_JobPosting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
  
		DepartmentIDLoad();
		DesignationIDLoad();
		SupervisorIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showHR_JobPostingData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	HR_JobPosting hR_JobPosting = new HR_JobPosting ();
//	hR_JobPosting.JobPostingID=  int.Parse(ddlJobPostingID.SelectedValue);
    hR_JobPosting.EmployeeID = Profile.card_id;
	hR_JobPosting.DepartmentID=  int.Parse(ddlDepartmentID.SelectedValue);
	hR_JobPosting.DesignationID=  int.Parse(ddlDesignationID.SelectedValue);
	hR_JobPosting.JoinDate=   DateTime.Parse(txtJoinDate.Text);
	hR_JobPosting.EndDate=   DateTime.Parse(txtEndDate.Text);
	hR_JobPosting.PostingStatus=  txtPostingStatus.Text;
	hR_JobPosting.JobLocation=  txtJobLocation.Text;
	hR_JobPosting.SupervisorID=  ddlSupervisorID.SelectedValue;
	hR_JobPosting.AddedBy=  Profile.card_id;
	hR_JobPosting.AddedDate=  DateTime.Now;
	hR_JobPosting.ModifiedBy=  Profile.card_id;
	hR_JobPosting.ModifiedDate=  DateTime.Now;
	int resutl =HR_JobPostingManager.InsertHR_JobPosting(hR_JobPosting);
	Response.Redirect("AdminDisplayHR_JobPosting.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_JobPosting hR_JobPosting = new HR_JobPosting ();
	hR_JobPosting.JobPostingID=  int.Parse(Request.QueryString["ID"].ToString());
    hR_JobPosting.EmployeeID = Profile.card_id;
	hR_JobPosting.DepartmentID=  int.Parse(ddlDepartmentID.SelectedValue);
	hR_JobPosting.DesignationID=  int.Parse(ddlDesignationID.SelectedValue);
	hR_JobPosting.JoinDate=   DateTime.Parse(txtJoinDate.Text);
	hR_JobPosting.EndDate=   DateTime.Parse(txtEndDate.Text);
	hR_JobPosting.PostingStatus=  txtPostingStatus.Text;
	hR_JobPosting.JobLocation=  txtJobLocation.Text;
	hR_JobPosting.SupervisorID=  ddlSupervisorID.SelectedValue;
	hR_JobPosting.AddedBy=  Profile.card_id;
	hR_JobPosting.AddedDate=  DateTime.Now;
	hR_JobPosting.ModifiedBy=  Profile.card_id;
	hR_JobPosting.ModifiedDate=  DateTime.Now;
	bool  resutl =HR_JobPostingManager.UpdateHR_JobPosting(hR_JobPosting);
	Response.Redirect("AdminDisplayHR_JobPosting.aspx");
	}
	private void showHR_JobPostingData()
	{
	 	HR_JobPosting hR_JobPosting  = new HR_JobPosting ();
	 	hR_JobPosting = HR_JobPostingManager.GetHR_JobPostingByJobPostingID(Int32.Parse(Request.QueryString["ID"]));
	 	 
	 	ddlDepartmentID.SelectedValue  =hR_JobPosting.DepartmentID.ToString();
	 	ddlDesignationID.SelectedValue  =hR_JobPosting.DesignationID.ToString();
	 	txtJoinDate.Text =hR_JobPosting.JoinDate.ToString();
	 	txtEndDate.Text =hR_JobPosting.EndDate.ToString();
	 	txtPostingStatus.Text =hR_JobPosting.PostingStatus.ToString();
	 	txtJobLocation.Text =hR_JobPosting.JobLocation.ToString();
	 	ddlSupervisorID.SelectedValue  =hR_JobPosting.SupervisorID.ToString();
	}
	
	 
	private void DepartmentIDLoad()
	{
		try {
		DataSet ds = HR_DepartmentManager.GetDropDownListAllHR_Department();
		ddlDepartmentID.DataValueField = "DepartmentID";
		ddlDepartmentID.DataTextField = "DepartmentName";
		ddlDepartmentID.DataSource = ds.Tables[0];
		ddlDepartmentID.DataBind();
		ddlDepartmentID.Items.Insert(0, new ListItem("Select Department >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void DesignationIDLoad()
	{
		try {
		DataSet ds = HR_DesignationManager.GetDropDownListAllHR_Designation();
		ddlDesignationID.DataValueField = "DesignationID";
		ddlDesignationID.DataTextField = "DesignationName";
		ddlDesignationID.DataSource = ds.Tables[0];
		ddlDesignationID.DataBind();
		ddlDesignationID.Items.Insert(0, new ListItem("Select Designation >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void SupervisorIDLoad()
	{
		try {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlSupervisorID.DataValueField = "EmployeeID";
            ddlSupervisorID.DataTextField = "EmployeeName";
		ddlSupervisorID.DataSource = ds.Tables[0];
		ddlSupervisorID.DataBind();
		ddlSupervisorID.Items.Insert(0, new ListItem("Select Supervisor >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

