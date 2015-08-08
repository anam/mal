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
 public partial class AdminSTD_ClassTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassTimeData();
         		ClassTimeGroupIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassTimeData();
                }
        }
    }

    protected void btnAddWithNewTimeGroup_Click(object sender, EventArgs e)
    {
        //if (txtNewTimeGroupName.Text != "")
        //{

            STD_ClassTimeGroup sTD_ClassTimeGroup = new STD_ClassTimeGroup();
            //	sTD_ClassTimeGroup.ClassTimeGroupID=  int.Parse(ddlClassTimeGroupID.SelectedValue);
            sTD_ClassTimeGroup.ClassTimeGroupName ="Set-"+ (int.Parse(ddlClassTimeGroupID.Items[ddlClassTimeGroupID.Items.Count-1].Text.Split('-')[1])+1).ToString();
            sTD_ClassTimeGroup.StartTime = txtStartTime.Text;
            sTD_ClassTimeGroup.EndTime = txtEndTime.Text;
            sTD_ClassTimeGroup.ExtraField1 = txtExtraField1.Text;
            sTD_ClassTimeGroup.ExtraField2 = txtExtraField2.Text;
            sTD_ClassTimeGroup.ExtraField3 = (int.Parse(ddlClassTimeGroupID.Items[ddlClassTimeGroupID.Items.Count - 1].Text.Split('-')[1]) + 1).ToString();
            sTD_ClassTimeGroup.ExtraField4 = txtExtraField4.Text;
            sTD_ClassTimeGroup.ExtraField5 = txtExtraField5.Text;
            sTD_ClassTimeGroup.AddedBy = Profile.card_id;
            sTD_ClassTimeGroup.AddedDate = DateTime.Now;
            sTD_ClassTimeGroup.UpdatedBy = Profile.card_id;
            sTD_ClassTimeGroup.UpdateDate = DateTime.Now;
            sTD_ClassTimeGroup.RowStatusID = 1;
            sTD_ClassTimeGroup.ClassTimeGroupID = STD_ClassTimeGroupManager.InsertSTD_ClassTimeGroup(sTD_ClassTimeGroup);
            ClassTimeGroupIDLoad();
            ddlClassTimeGroupID.SelectedValue = sTD_ClassTimeGroup.ClassTimeGroupID.ToString();

            btnAdd_Click(this, new EventArgs());
        //}
        //else
        //{
        //    lblMessage.Text = "Enter the Set Number";
        //}
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
        STD_ClassTime sTD_ClassTime = new STD_ClassTime ();

        bool is12PMIssueEnd = false;
        if (ddlEndHour.SelectedValue == "12" && ddlEndAMPM.SelectedValue == "PM")
        {
            is12PMIssueEnd = true;
            txtEndTime.Text = "0:" + ddlEndMin.SelectedValue + " " + ddlEndAMPM.SelectedValue;
        }
        else
        {
            txtEndTime.Text = ddlEndHour.SelectedValue + ":" + ddlEndMin.SelectedValue + " " + ddlEndAMPM.SelectedValue;
        }

        bool is12PMIssueStart = false;
        if (ddlStartHour.SelectedValue == "12" && ddlStartAMPM.SelectedValue == "PM")
        {
            is12PMIssueStart = true;
            txtStartTime.Text = "0:" + ddlStartMin.SelectedValue + " " + ddlStartAMPM.SelectedValue;
        }
        else
        {
            txtStartTime.Text = ddlStartHour.SelectedValue + ":" + ddlStartMin.SelectedValue + " " + ddlStartAMPM.SelectedValue;
        }
            //txtEndTime.Text = ddlEndHour.SelectedValue + ":" + ddlEndMin.SelectedValue + " " + ddlEndAMPM.SelectedValue;
        txtClassTimeName.Text = (is12PMIssueStart ? "12:" + txtStartTime.Text.ToString().Split(':')[1] : txtStartTime.Text.ToString()) + " - " + (is12PMIssueEnd ? "12:" + txtEndTime.Text.ToString().Split(':')[1] : txtEndTime.Text.ToString());
            

            TimeList timeList = new TimeList();
            List<Time> times = new List<Time>();
            times = timeList.getTimeList();
            foreach (Time t in times)
            {
                if (txtStartTime.Text == t.TimeName) txtExtraField1.Text = t.TimeID.ToString();
                if (txtEndTime.Text == t.TimeName) txtExtraField2.Text = t.TimeID.ToString();
            }
            txtDuration.Text = ((int.Parse(txtExtraField2.Text) - int.Parse(txtExtraField1.Text)) * 5).ToString();
	
        //Check in the group
            //DataSet classTimesAll = STD_ClassTimeManager.GetSTD_ClassTimeByClassTimeGroupID();
            DataSet classTimes = STD_ClassTimeManager.GetSTD_ClassTimeByClassTimeGroupID(int.Parse(ddlClassTimeGroupID.SelectedValue));
            bool isConfict = false;

            foreach (DataRow dr in classTimes.Tables[0].Rows)
            {
                if ((int.Parse(dr["ExtraField1"].ToString()) <= int.Parse(txtExtraField1.Text) && int.Parse(dr["ExtraField2"].ToString()) >= int.Parse(txtExtraField1.Text))
                    || (int.Parse(dr["ExtraField1"].ToString()) <= int.Parse(txtExtraField2.Text) && int.Parse(dr["ExtraField2"].ToString()) >= int.Parse(txtExtraField2.Text)))
                {
                    isConfict = true;
                    divNewRoutineTimeGourp.Visible = true;
                    lblMessage.Text = "</br>There is a conflict with the Class Time Group-<span style='color:red;'>" + ddlClassTimeGroupID.SelectedItem.Text + "</span>. Please change it<br/>OR<br/>Click on the following button to set # System Generated";
                    try
                    {
                        if (ddlClassTimeGroupID.SelectedValue != ddlClassTimeGroupID.Items[ddlClassTimeGroupID.Items.Count - 1].Value)
                        {
                            ddlClassTimeGroupID.SelectedValue = (int.Parse(ddlClassTimeGroupID.SelectedValue) + 1).ToString();
                            btnAdd_Click(this, new EventArgs());
                        }
                        else
                        {
                            btnAddWithNewTimeGroup_Click(this, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    {
                        btnAddWithNewTimeGroup_Click(this, new EventArgs());
                    }
                    return;
                }
            }

            foreach (DataRow dr in classTimes.Tables[1].Rows)
            {
                if ((int.Parse(dr["ExtraField1"].ToString()) <= int.Parse(txtExtraField1.Text) && int.Parse(dr["ExtraField2"].ToString()) >= int.Parse(txtExtraField1.Text))
                    || (int.Parse(dr["ExtraField1"].ToString()) <= int.Parse(txtExtraField2.Text) && int.Parse(dr["ExtraField2"].ToString()) >= int.Parse(txtExtraField2.Text)))
                {
                    txtExtraField3.Text += dr["ClassTimeID"].ToString() + ";";
                }
            }

            divNewRoutineTimeGourp.Visible = false;
            lblMessage.Text = "";

//	sTD_ClassTime.ClassTimeID=  int.Parse(ddlClassTimeID.SelectedValue);
	sTD_ClassTime.ClassTimeName=  txtClassTimeName.Text;
	sTD_ClassTime.Duration=  decimal.Parse(txtDuration.Text);
	sTD_ClassTime.AddedBy=  Profile.card_id;
	sTD_ClassTime.AddedDate=  DateTime.Now;
	sTD_ClassTime.UpdatedBy=  Profile.card_id;
	sTD_ClassTime.UpdateDate=  DateTime.Now;
	sTD_ClassTime.Order=  int.Parse(txtOrder.Text);
	sTD_ClassTime.ClassTimeGroupID=  int.Parse(ddlClassTimeGroupID.SelectedValue);
    sTD_ClassTime.StartTime = (is12PMIssueStart ? "12:" + txtStartTime.Text.ToString().Split(':')[1] : txtStartTime.Text.ToString());
    sTD_ClassTime.EndTime = (is12PMIssueEnd ? "12:" + txtEndTime.Text.ToString().Split(':')[1] : txtEndTime.Text.ToString());
	sTD_ClassTime.ExtraField1=  txtExtraField1.Text;
	sTD_ClassTime.ExtraField2=  txtExtraField2.Text;
	sTD_ClassTime.ExtraField3=  txtExtraField3.Text;
	sTD_ClassTime.ExtraField4=  txtExtraField4.Text;
	sTD_ClassTime.ExtraField5=  txtExtraField5.Text;
	sTD_ClassTime.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =STD_ClassTimeManager.InsertSTD_ClassTime(sTD_ClassTime);
	Response.Redirect("AdminDisplaySTD_ClassTime.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_ClassTime sTD_ClassTime = new STD_ClassTime ();
    bool is12PMIssueEnd = false;
    if (ddlEndHour.SelectedValue == "12" && ddlEndAMPM.SelectedValue == "PM")
    {
        is12PMIssueEnd = true;
        txtEndTime.Text = "0:" + ddlEndMin.SelectedValue + " " + ddlEndAMPM.SelectedValue;
    }
    else
    {
        txtEndTime.Text = ddlEndHour.SelectedValue + ":" + ddlEndMin.SelectedValue + " " + ddlEndAMPM.SelectedValue;
    }

    bool is12PMIssueStart = false;
    if (ddlStartHour.SelectedValue == "12" && ddlStartAMPM.SelectedValue == "PM")
    {
        is12PMIssueStart = true;
        txtStartTime.Text = "0:" + ddlStartMin.SelectedValue + " " + ddlStartAMPM.SelectedValue;
    }
    else
    {
        txtStartTime.Text = ddlStartHour.SelectedValue + ":" + ddlStartMin.SelectedValue + " " + ddlStartAMPM.SelectedValue;
    }
    //txtEndTime.Text = ddlEndHour.SelectedValue + ":" + ddlEndMin.SelectedValue + " " + ddlEndAMPM.SelectedValue;
    txtClassTimeName.Text = (is12PMIssueStart ? "12:" + txtStartTime.Text.ToString().Split(':')[1] : txtStartTime.Text.ToString()) + " - " + (is12PMIssueEnd ? "12:" + txtEndTime.Text.ToString().Split(':')[1] : txtEndTime.Text.ToString());


    TimeList timeList = new TimeList();
    List<Time> times = new List<Time>();
    times = timeList.getTimeList();
    foreach (Time t in times)
    {
        if (txtStartTime.Text == t.TimeName) txtExtraField1.Text = t.TimeID.ToString();
        if (txtEndTime.Text == t.TimeName) txtExtraField2.Text = t.TimeID.ToString();
    }
    txtDuration.Text = ((int.Parse(txtExtraField2.Text) - int.Parse(txtExtraField1.Text)) * 5).ToString();
	

        //Check in the group
    DataSet classTimes = STD_ClassTimeManager.GetSTD_ClassTimeByClassTimeGroupID(int.Parse(ddlClassTimeGroupID.SelectedValue));
    bool isConfict = false;

    //foreach (DataRow dr in classTimes.Tables[0].Rows)
    //{
    //    if (dr["ClassTimeID"].ToString() != Request.QueryString["ID"])
    //    {
    //        if ((int.Parse(dr["ExtraField1"].ToString()) <= int.Parse(txtExtraField1.Text) && int.Parse(dr["ExtraField2"].ToString()) >= int.Parse(txtExtraField1.Text))
    //            || (int.Parse(dr["ExtraField1"].ToString()) <= int.Parse(txtExtraField2.Text) && int.Parse(dr["ExtraField2"].ToString()) >= int.Parse(txtExtraField2.Text)))
    //        {
    //            isConfict = true;

    //            lblMessage.Text = "</br>There is a conflict with the ClassTimeGroup-<span style='color:red;'>" + ddlClassTimeGroupID.SelectedItem.Text + "</span>. Please change it";
    //            try
    //            {
    //                if (ddlClassTimeGroupID.SelectedValue != ddlClassTimeGroupID.Items[ddlClassTimeGroupID.Items.Count - 1].Value)
    //                {
    //                    ddlClassTimeGroupID.SelectedValue = (int.Parse(ddlClassTimeGroupID.SelectedValue) + 1).ToString();
    //                    btnAdd_Click(this, new EventArgs());
    //                }
    //                else
    //                {
    //                    btnAddWithNewTimeGroup_Click(this, new EventArgs());
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                btnAddWithNewTimeGroup_Click(this, new EventArgs());
    //            }
    //            return;
    //        }
    //    }
    //}


    foreach (DataRow dr in classTimes.Tables[1].Rows)
    {
        if (dr["ClassTimeID"].ToString() != Request.QueryString["ID"])
        {
            if ((int.Parse(dr["ExtraField1"].ToString()) <= int.Parse(txtExtraField1.Text) && int.Parse(dr["ExtraField2"].ToString()) >= int.Parse(txtExtraField1.Text))
                || (int.Parse(dr["ExtraField1"].ToString()) <= int.Parse(txtExtraField2.Text) && int.Parse(dr["ExtraField2"].ToString()) >= int.Parse(txtExtraField2.Text)))
            {
                txtExtraField3.Text += dr["ClassTimeID"].ToString() + ";";
            }
        }
    }


    lblMessage.Text = "";
	sTD_ClassTime.ClassTimeID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ClassTime.ClassTimeName=  txtClassTimeName.Text;
	sTD_ClassTime.Duration=  decimal.Parse(txtDuration.Text);
	sTD_ClassTime.AddedBy=  Profile.card_id;
	sTD_ClassTime.AddedDate=  DateTime.Now;
	sTD_ClassTime.UpdatedBy=  Profile.card_id;
	sTD_ClassTime.UpdateDate=  DateTime.Now;
	sTD_ClassTime.Order=  int.Parse(txtOrder.Text);
	sTD_ClassTime.ClassTimeGroupID=  int.Parse(ddlClassTimeGroupID.SelectedValue);
	sTD_ClassTime.StartTime=  txtStartTime.Text;
    
    sTD_ClassTime.EndTime = txtEndTime.Text;
	
	sTD_ClassTime.ExtraField1=  txtExtraField1.Text;
	sTD_ClassTime.ExtraField2=  txtExtraField2.Text;
	sTD_ClassTime.ExtraField3=  txtExtraField3.Text;
	sTD_ClassTime.ExtraField4=  txtExtraField4.Text;
	sTD_ClassTime.ExtraField5=  txtExtraField5.Text;
	sTD_ClassTime.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =STD_ClassTimeManager.UpdateSTD_ClassTime(sTD_ClassTime);
	Response.Redirect("AdminDisplaySTD_ClassTime.aspx");
	}
	private void showSTD_ClassTimeData()
	{
	 	STD_ClassTime sTD_ClassTime  = new STD_ClassTime ();
	 	sTD_ClassTime = STD_ClassTimeManager.GetSTD_ClassTimeByClassTimeID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassTimeName.Text =sTD_ClassTime.ClassTimeName.ToString();
	 	txtDuration.Text =sTD_ClassTime.Duration.ToString();
	 	txtOrder.Text =sTD_ClassTime.Order.ToString();
	 	ddlClassTimeGroupID.SelectedValue  =sTD_ClassTime.ClassTimeGroupID.ToString();
	 	txtStartTime.Text =sTD_ClassTime.StartTime.ToString();
        ddlStartHour.SelectedValue = txtStartTime.Text.Split(':')[0];
        ddlStartMin.SelectedValue = txtStartTime.Text.Split(':')[1].Split(' ')[0];
        ddlStartAMPM.SelectedValue = txtStartTime.Text.Split(':')[1].Split(' ')[1];

        txtEndTime.Text = sTD_ClassTime.EndTime.ToString();
        ddlEndHour.SelectedValue = txtEndTime.Text.Split(':')[0];
        ddlEndMin.SelectedValue = txtEndTime.Text.Split(':')[1].Split(' ')[0];
        ddlEndAMPM.SelectedValue = txtEndTime.Text.Split(':')[1].Split(' ')[1];

	 	txtExtraField1.Text =sTD_ClassTime.ExtraField1.ToString();
	 	txtExtraField2.Text =sTD_ClassTime.ExtraField2.ToString();
	 	txtExtraField3.Text =sTD_ClassTime.ExtraField3.ToString();
	 	txtExtraField4.Text =sTD_ClassTime.ExtraField4.ToString();
	 	txtExtraField5.Text =sTD_ClassTime.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =sTD_ClassTime.RowStatusID.ToString();
	}
	
	private void ClassTimeGroupIDLoad()
	{
		try {
		DataSet ds = STD_ClassTimeGroupManager.GetDropDownListAllSTD_ClassTimeGroup();
		ddlClassTimeGroupID.DataValueField = "ClassTimeGroupID";
		ddlClassTimeGroupID.DataTextField = "ClassTimeGroupName";
		ddlClassTimeGroupID.DataSource = ds.Tables[0];
		ddlClassTimeGroupID.DataBind();
		ddlClassTimeGroupID.Items.Insert(0, new ListItem("Select ClassTimeGroup >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
		ddlRowStatusID.DataValueField = "RowStatusID";
		ddlRowStatusID.DataTextField = "RowStatusName";
		ddlRowStatusID.DataSource = ds.Tables[0];
		ddlRowStatusID.DataBind();
		ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
        ddlRowStatusID.SelectedValue = "1";
	 }
}

