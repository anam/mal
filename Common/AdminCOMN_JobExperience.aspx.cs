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
 public partial class AdminCOMN_JobExperience : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_JobExperienceData();
         		UserIDLoad();
		DesignationIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_JobExperienceData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience ();
//	cOMN_JobExperience.JobExperienceID=  int.Parse(ddlJobExperienceID.SelectedValue);
	cOMN_JobExperience.UserID=  ddlUserID.SelectedValue;
	cOMN_JobExperience.OrganizationName=  txtOrganizationName.Text;
	cOMN_JobExperience.Designation= ddlDesignationID.SelectedItem.Text;
	cOMN_JobExperience.NatureofWork=  txtNatureofWork.Text;
	cOMN_JobExperience.DateStart=   DateTime.Parse(txtDateStart.Text);
	cOMN_JobExperience.DateEnds=   DateTime.Parse(txtDateEnds.Text);
	cOMN_JobExperience.Duration=  decimal.Parse(txtDuration.Text);
	cOMN_JobExperience.ReasionForLeaving=  txtReasionForLeaving.Text;
	cOMN_JobExperience.Contact=  txtContact.Text;
	cOMN_JobExperience.AddedBy=  Profile.card_id;
	cOMN_JobExperience.AddedDate=  DateTime.Now;
	cOMN_JobExperience.UpdatedBy=  Profile.card_id;
	cOMN_JobExperience.UpdatedDate=   DateTime.Parse(txtUpdatedDate.Text);
	int resutl =COMN_JobExperienceManager.InsertCOMN_JobExperience(cOMN_JobExperience);
	Response.Redirect("AdminCOMN_JobExperienceDisplay.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience ();
	cOMN_JobExperience.JobExperienceID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_JobExperience.UserID=  ddlUserID.SelectedValue;
	cOMN_JobExperience.OrganizationName=  txtOrganizationName.Text;
	cOMN_JobExperience.Designation=  ddlDesignationID.SelectedItem.Text;
	cOMN_JobExperience.NatureofWork=  txtNatureofWork.Text;
	cOMN_JobExperience.DateStart=   DateTime.Parse(txtDateStart.Text);
	cOMN_JobExperience.DateEnds=   DateTime.Parse(txtDateEnds.Text);
	cOMN_JobExperience.Duration=  decimal.Parse(txtDuration.Text);
	cOMN_JobExperience.ReasionForLeaving=  txtReasionForLeaving.Text;
	cOMN_JobExperience.Contact=  txtContact.Text;
	cOMN_JobExperience.AddedBy=  Profile.card_id;
	cOMN_JobExperience.AddedDate=  DateTime.Now;
	cOMN_JobExperience.UpdatedBy=  Profile.card_id;
	cOMN_JobExperience.UpdatedDate=   DateTime.Parse(txtUpdatedDate.Text);
	bool  resutl =COMN_JobExperienceManager.UpdateCOMN_JobExperience(cOMN_JobExperience);
	Response.Redirect("AdminDisplayCOMN_JobExperience.aspx");
	}
	private void showCOMN_JobExperienceData()
	{
	 	COMN_JobExperience cOMN_JobExperience  = new COMN_JobExperience ();
	 	cOMN_JobExperience = COMN_JobExperienceManager.GetCOMN_JobExperienceByJobExperienceID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlUserID.SelectedValue  =cOMN_JobExperience.UserID.ToString();
	 	txtOrganizationName.Text =cOMN_JobExperience.OrganizationName.ToString();
	 	ddlDesignationID.SelectedValue  =cOMN_JobExperience.Designation;
	 	txtNatureofWork.Text =cOMN_JobExperience.NatureofWork.ToString();
	 	txtDateStart.Text =cOMN_JobExperience.DateStart.ToString();
	 	txtDateEnds.Text =cOMN_JobExperience.DateEnds.ToString();
	 	txtDuration.Text =cOMN_JobExperience.Duration.ToString();
	 	txtReasionForLeaving.Text =cOMN_JobExperience.ReasionForLeaving.ToString();
	 	txtContact.Text =cOMN_JobExperience.Contact.ToString();
	 	txtUpdatedBy.Text =cOMN_JobExperience.UpdatedBy.ToString();
	 	txtUpdatedDate.Text =cOMN_JobExperience.UpdatedDate.ToString();
	}
	
	private void UserIDLoad()
	{
		try {
        //DataSet ds = COMN_UserManager.GetDropDownListAllCOMN_User();
        //ddlUserID.DataValueField = "UserID";
        //ddlUserID.DataTextField = "UserName";
        //ddlUserID.DataSource = ds.Tables[0];
        //ddlUserID.DataBind();
        //ddlUserID.Items.Insert(0, new ListItem("Select User >>", "0"));
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
}

