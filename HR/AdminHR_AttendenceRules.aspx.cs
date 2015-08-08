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
public partial class AdminHR_AttendenceRules : System.Web.UI.Page
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
                showHR_AttendenceRulesData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_AttendenceRules hR_AttendenceRules = new HR_AttendenceRules();
        //	hR_AttendenceRules.AttendenceRulesID=  int.Parse(ddlAttendenceRulesID.SelectedValue);
        hR_AttendenceRules.EmployeeID = Profile.card_id;
        hR_AttendenceRules.Rules = txtRules.Text;
        hR_AttendenceRules.Time = int.Parse(ddlTime.SelectedValue);
        hR_AttendenceRules.Unit = "Min";
        hR_AttendenceRules.AddedBy = Profile.card_id;
        hR_AttendenceRules.AddedDate = DateTime.Now;
        hR_AttendenceRules.ModifiedBy = Profile.card_id;
        hR_AttendenceRules.ModifiedDate = DateTime.Now;
        int resutl = HR_AttendenceRulesManager.InsertHR_AttendenceRules(hR_AttendenceRules);
        Response.Redirect("AdminDisplayHR_AttendenceRules.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_AttendenceRules hR_AttendenceRules = new HR_AttendenceRules();
        hR_AttendenceRules.AttendenceRulesID = int.Parse(Request.QueryString["ID"].ToString());
        hR_AttendenceRules.EmployeeID = Profile.card_id;
        hR_AttendenceRules.Rules = txtRules.Text;
        hR_AttendenceRules.Time = int.Parse(ddlTime.SelectedValue);
        hR_AttendenceRules.Unit = "Min";
        hR_AttendenceRules.AddedBy = Profile.card_id;
        hR_AttendenceRules.AddedDate = DateTime.Now;
        hR_AttendenceRules.ModifiedBy = Profile.card_id;
        hR_AttendenceRules.ModifiedDate = DateTime.Now;
        bool resutl = HR_AttendenceRulesManager.UpdateHR_AttendenceRules(hR_AttendenceRules);
        Response.Redirect("AdminDisplayHR_AttendenceRules.aspx");
    }

    private void showHR_AttendenceRulesData()
    {
        HR_AttendenceRules hR_AttendenceRules = new HR_AttendenceRules();
        hR_AttendenceRules = HR_AttendenceRulesManager.GetHR_AttendenceRulesByAttendenceRulesID(Int32.Parse(Request.QueryString["ID"]));

        txtRules.Text = hR_AttendenceRules.Rules.ToString();
        ddlTime.SelectedValue = hR_AttendenceRules.Time.ToString();

    }
}

