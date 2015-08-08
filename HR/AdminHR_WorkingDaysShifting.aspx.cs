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
public partial class AdminHR_WorkingDaysShifting : System.Web.UI.Page
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
                showHR_WorkingDaysShiftingData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string txtStartHour = this.ddltime_hoursStart.SelectedValue.ToString();
        string txtStartMin = this.ddltime_minstart.SelectedValue.ToString();
        string txtStartTime = DateTime.Now.ToShortDateString() + " " + txtStartHour + " : " + txtStartMin + ": 00";
        DateTime dtStartTime = Convert.ToDateTime(txtStartTime);
        string txtEndHour = this.ddltime_hoursEnd.SelectedValue.ToString();
        string txtEndMin = this.ddltime_minEnd.SelectedValue.ToString();
        string txtEndTime = DateTime.Now.ToShortDateString() + " " + txtEndHour + " : " + txtEndMin + ": 00";
        DateTime dtEndTime = Convert.ToDateTime(txtEndTime);
        HR_WorkingDaysShifting hR_WorkingDaysShifting = new HR_WorkingDaysShifting();
        //	hR_WorkingDaysShifting.WorkingDaysID=  int.Parse(ddlWorkingDaysID.SelectedValue);
        hR_WorkingDaysShifting.EmployeeID = Profile.card_id;
        hR_WorkingDaysShifting.Saturday = chkSaturday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Sunday = chkSunday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Monday = chkMonday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Tuesday = chkTuesday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Wednesday = chkWednesday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Thrusday = chkThrusday.Checked == true ? true : false;
        //hR_WorkingDaysShifting.ShiftStartTime=   DateTime.Parse(txtShiftStartTime.Text);
        //hR_WorkingDaysShifting.ShiftEndTime=   DateTime.Parse(txtShiftEndTime.Text);
        hR_WorkingDaysShifting.ShiftStartTime = dtStartTime;
        hR_WorkingDaysShifting.ShiftEndTime = dtEndTime;
        hR_WorkingDaysShifting.Description = txtDescription.Text;
        hR_WorkingDaysShifting.AddedBy = Profile.card_id;
        hR_WorkingDaysShifting.AddedDate = DateTime.Now;
        hR_WorkingDaysShifting.ModifiedBy = Profile.card_id;
        hR_WorkingDaysShifting.ModifiedDate = DateTime.Now;
        int resutl = HR_WorkingDaysShiftingManager.InsertHR_WorkingDaysShifting(hR_WorkingDaysShifting);
        Response.Redirect("AdminDisplayHR_WorkingDaysShifting.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string txtStartHour = this.ddltime_hoursStart.SelectedValue.ToString();
        string txtStartMin = this.ddltime_minstart.SelectedValue.ToString();
        string txtStartTime = DateTime.Now.ToShortDateString() + " " + txtStartHour + " : " + txtStartMin + ": 00";
        DateTime dtStartTime = Convert.ToDateTime(txtStartTime);
        string txtEndHour = this.ddltime_hoursEnd.SelectedValue.ToString();
        string txtEndMin = this.ddltime_minEnd.SelectedValue.ToString();
        string txtEndTime = DateTime.Now.ToShortDateString() + " " + txtEndHour + " : " + txtEndMin + ": 00";
        DateTime dtEndTime = Convert.ToDateTime(txtEndTime);
        HR_WorkingDaysShifting hR_WorkingDaysShifting = new HR_WorkingDaysShifting();
        hR_WorkingDaysShifting.WorkingDaysID = int.Parse(Request.QueryString["ID"].ToString());
        hR_WorkingDaysShifting.EmployeeID = Profile.card_id;
        hR_WorkingDaysShifting.Saturday = chkSaturday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Sunday = chkSunday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Monday = chkMonday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Tuesday = chkTuesday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Wednesday = chkWednesday.Checked == true ? true : false;
        hR_WorkingDaysShifting.Thrusday = chkThrusday.Checked == true ? true : false;
        //hR_WorkingDaysShifting.ShiftStartTime=   DateTime.Parse(txtShiftStartTime.Text);
        //hR_WorkingDaysShifting.ShiftEndTime=   DateTime.Parse(txtShiftEndTime.Text);
        hR_WorkingDaysShifting.ShiftStartTime = dtStartTime;
        hR_WorkingDaysShifting.ShiftEndTime = dtEndTime;
        hR_WorkingDaysShifting.Description = txtDescription.Text;
        hR_WorkingDaysShifting.AddedBy = Profile.card_id;
        hR_WorkingDaysShifting.AddedDate = DateTime.Now;
        hR_WorkingDaysShifting.ModifiedBy = Profile.card_id;
        hR_WorkingDaysShifting.ModifiedDate = DateTime.Now;
        bool resutl = HR_WorkingDaysShiftingManager.UpdateHR_WorkingDaysShifting(hR_WorkingDaysShifting);
        Response.Redirect("AdminDisplayHR_WorkingDaysShifting.aspx");
    }

    private void showHR_WorkingDaysShiftingData()
    {
        string txtStartHour = this.ddltime_hoursStart.SelectedValue.ToString();
        string txtStartMin = this.ddltime_minstart.SelectedValue.ToString();
        string txtStartTime = DateTime.Now.ToShortDateString() + " " + txtStartHour + " : " + txtStartMin + ": 00";
        DateTime dtStartTime = Convert.ToDateTime(txtStartTime);
        string txtEndHour = this.ddltime_hoursEnd.SelectedValue.ToString();
        string txtEndMin = this.ddltime_minEnd.SelectedValue.ToString();
        string txtEndTime = DateTime.Now.ToShortDateString() + " " + txtEndHour + " : " + txtEndMin + ": 00";
        DateTime dtEndTime = Convert.ToDateTime(txtEndTime);
        HR_WorkingDaysShifting hR_WorkingDaysShifting = new HR_WorkingDaysShifting();
        hR_WorkingDaysShifting = HR_WorkingDaysShiftingManager.GetHR_WorkingDaysShiftingByWorkingDaysID(Int32.Parse(Request.QueryString["ID"]));

        chkSaturday.Checked = hR_WorkingDaysShifting.Saturday;
        chkSunday.Checked = hR_WorkingDaysShifting.Sunday;
        chkMonday.Checked = hR_WorkingDaysShifting.Monday;
        chkTuesday.Checked = hR_WorkingDaysShifting.Tuesday;
        chkWednesday.Checked = hR_WorkingDaysShifting.Wednesday;
        chkThrusday.Checked = hR_WorkingDaysShifting.Thrusday;
        //txtShiftStartTime.Text =hR_WorkingDaysShifting.ShiftStartTime.ToString();
        //txtShiftEndTime.Text =hR_WorkingDaysShifting.ShiftEndTime.ToString();
        hR_WorkingDaysShifting.ShiftStartTime = dtStartTime;
        hR_WorkingDaysShifting.ShiftEndTime = dtEndTime;
        txtDescription.Text = hR_WorkingDaysShifting.Description.ToString();
    }
}

