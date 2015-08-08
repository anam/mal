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
 public partial class AdminHR_JobExperience : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showHR_JobExperienceData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	HR_JobExperience hR_JobExperience = new HR_JobExperience ();
//	hR_JobExperience.JobExperienceID=  int.Parse(ddlJobExperienceID.SelectedValue);
    hR_JobExperience.EmployeeID = Profile.card_id;
	hR_JobExperience.Organization=  txtOrganization.Text;
	hR_JobExperience.Position=  txtPosition.Text;
	hR_JobExperience.YearStart=   DateTime.Parse(txtYearStart.Text);
	hR_JobExperience.YearEnd=   DateTime.Parse(txtYearEnd.Text);
	hR_JobExperience.ReasonForLeaving=  txtReasonForLeaving.Text;
	hR_JobExperience.ContactPerson=  txtContactPerson.Text;
	hR_JobExperience.AddedBy=  Profile.card_id;
	hR_JobExperience.AddedDate=  DateTime.Now;
	hR_JobExperience.ModifiedBy=  Profile.card_id;
	hR_JobExperience.ModifiedDate=  DateTime.Now;
	int resutl =HR_JobExperienceManager.InsertHR_JobExperience(hR_JobExperience);
	Response.Redirect("AdminDisplayHR_JobExperience.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_JobExperience hR_JobExperience = new HR_JobExperience ();
	hR_JobExperience.JobExperienceID=  int.Parse(Request.QueryString["ID"].ToString());
    hR_JobExperience.EmployeeID = Profile.card_id;
	hR_JobExperience.Organization=  txtOrganization.Text;
	hR_JobExperience.Position=  txtPosition.Text;
	hR_JobExperience.YearStart=   DateTime.Parse(txtYearStart.Text);
	hR_JobExperience.YearEnd=   DateTime.Parse(txtYearEnd.Text);
	hR_JobExperience.ReasonForLeaving=  txtReasonForLeaving.Text;
	hR_JobExperience.ContactPerson=  txtContactPerson.Text;
	hR_JobExperience.AddedBy=  Profile.card_id;
	hR_JobExperience.AddedDate=  DateTime.Now;
	hR_JobExperience.ModifiedBy=  Profile.card_id;
	hR_JobExperience.ModifiedDate=  DateTime.Now;
	bool  resutl =HR_JobExperienceManager.UpdateHR_JobExperience(hR_JobExperience);
	Response.Redirect("AdminDisplayHR_JobExperience.aspx");
	}
	private void showHR_JobExperienceData()
	{
	 	HR_JobExperience hR_JobExperience  = new HR_JobExperience ();
	 	hR_JobExperience = HR_JobExperienceManager.GetHR_JobExperienceByJobExperienceID(Int32.Parse(Request.QueryString["ID"]));
	 	 
	 	txtOrganization.Text =hR_JobExperience.Organization.ToString();
	 	txtPosition.Text =hR_JobExperience.Position.ToString();
	 	txtYearStart.Text =hR_JobExperience.YearStart.ToString();
	 	txtYearEnd.Text =hR_JobExperience.YearEnd.ToString();
	 	txtReasonForLeaving.Text =hR_JobExperience.ReasonForLeaving.ToString();
	 	txtContactPerson.Text =hR_JobExperience.ContactPerson.ToString();
	}
	
	 
}

