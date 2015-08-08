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
 

public partial class AdminDisplaySTD_ClassSubjectEmployeeStudent : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClassIDLoad();
            pnAttendantDate.Visible = false;
            //SubjectIDLoad();
            //EmployeeIDLoad();  
            txtPrintAttendenceSheet.Text = DateTime.Today.ToString("dd MMM, yyyy");
        }
    }


    private void ClassIDLoad()
    {
        try
        {
            DataSet ds = STD_ClassManager.GetDropDownListAllSTD_Class();
            ddlClassID.DataValueField = "ClassID";
            ddlClassID.DataTextField = "ClassName";
            ddlClassID.DataSource = ds.Tables[0];
            ddlClassID.DataBind();
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    protected void ddlClassID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedValue != null)
        {
            int ClassID = int.Parse(ddlClassID.SelectedValue);
            SubjectIDLoad(ClassID);

        }
    }

    private void SubjectIDLoad()
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_Subject();
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void SubjectIDLoad(int ClassID)
    {
        try
        {
            ddlSubjectID.Items.Clear();

            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_SubjectByClassID(ClassID);

            ListItem li = new ListItem("Select Subject >>", "0");
            ddlSubjectID.Items.Add(li);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["SubjectName"].ToString() + " (" + dr["NoOfStudents"].ToString() + " Students)", dr["SubjectID"].ToString());
                ddlSubjectID.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
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
            //ddlEmployeeID.Items.Insert(0, new ListItem("Mehdi Sir", "96b72550-3649-45c6-a1f5-0474a77f4fa5"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedValue != null)
        {
            int ClassID = int.Parse(ddlClassID.SelectedValue);
            int SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            EmployeeIDLoadByClassID(ClassID, SubjectID);
            ddlEmployeeID_SelectedIndexChanged(this,new EventArgs());
        }
    }

    private void EmployeeIDLoadByClassID(int ClassID, int SubjectID)
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_EmployeClassID(ClassID, SubjectID);
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            //ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
            //ddlEmployeeID.Items.Insert(0, new ListItem("Mehdi Sir", "96b72550-3649-45c6-a1f5-0474a77f4fa5"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }



    
    protected void gvSTD_ClassSubjectEmployeeStudent_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chbAttendants = (CheckBox)e.Row.FindControl("chbAttendants");

            chbAttendants.Checked = true;
        }
    }
    protected void btnShowAttendant_Click(object sender, EventArgs e)
    {
        ddlEmployeeID_SelectedIndexChanged(this, new EventArgs());
        btnOldSystemVirification_Click(this, new EventArgs());
    }

    protected void btnPrintAttendant_Click(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedIndex != 0 && ddlSubjectID.SelectedIndex != 0 && ddlEmployeeID.SelectedIndex != 0)
        {
            Response.Redirect("AttendantSheet.aspx?classID=" + ddlClassID.SelectedValue + "&subjectID=" + ddlSubjectID.SelectedValue + "&employeeID=" + ddlEmployeeID.SelectedValue);
        }
    }

    protected void btnAddAttendant_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime date = new DateTime();
            date = Convert.ToDateTime(txtAttendantDate.Text);
            string sdate = date.ToString("yyyy-MM-dd");
            date = Convert.ToDateTime(sdate + " " + ddlStartHour.SelectedValue + ":" + ddlStartMin.SelectedValue + " "+ddlStartAMPM.SelectedValue);

            //DataSet dsStudentAttendence = STD_StudentManager.GetSTD_ClassStudentsAttentdant(ddlEmployeeID.SelectedValue, date);
            DataSet dsStudentAttendence = dsStudentAttendence = STD_StudentManager.GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeIDForRepeating(
                ((Label)gvSTD_ClassSubjectEmployeeStudent.Rows[0].FindControl("lblClassSubjectEmloyeeID")).Text
                , date);
            
            if (dsStudentAttendence.Tables[0].Rows.Count == 0)
            {

                foreach (GridViewRow row in gvSTD_ClassSubjectEmployeeStudent.Rows)
                {
                    CheckBox chbAttendants = (CheckBox)row.FindControl("chbAttendants");
                    Label lblClassSubjectEmloyeeID = (Label)row.FindControl("lblClassSubjectEmloyeeID");
                    Label lblStudentID = (Label)row.FindControl("lblStudentID");

                    TextBox txtRemark = (TextBox)row.FindControl("txtRemark");
                    //if (txtRemark.Text != "")
                    //{
                    //    COMN_Remark cOMN_Remark = new COMN_Remark();
                    //    //	cOMN_Remark.RemarkID=  int.Parse(ddlRemarkID.SelectedValue);
                    //    cOMN_Remark.RemarkName = "Attendence Remark";
                    //    cOMN_Remark.Remark = txtRemark.Text;
                    //    cOMN_Remark.RemarkDate = DateTime.Parse(txtAttendantDate.Text);
                    //    cOMN_Remark.WhoReported = STD_StudentManager.GetSTD_StudentByStudentID(Profile.card_id).StudentCode;
                    //    cOMN_Remark.WhoDid = STD_StudentManager.GetSTD_StudentByStudentID(lblStudentID.Text).StudentCode;
                    //    cOMN_Remark.ExtraField1 = txtAttendantDate.Text + " (" + DateTime.Parse(txtAttendantDate.Text).ToString("ddd") + ") - " + ddlStartHour.SelectedValue + ":" + ddlStartMin.SelectedValue + " " + ddlStartAMPM.SelectedValue + " - " + ddlEndHour.SelectedValue + ":" + ddlEndMin.SelectedValue + " " + ddlEndAMPM.SelectedValue;
                    //    cOMN_Remark.ExtraField2 = "";
                    //    cOMN_Remark.ExtraField3 = "";
                    //    cOMN_Remark.ExtraField4 = "";
                    //    cOMN_Remark.ExtraField5 = "";
                    //    cOMN_Remark.AddedBy = Profile.card_id;
                    //    cOMN_Remark.AddedDate = DateTime.Now;
                    //    cOMN_Remark.UpdatedBy = Profile.card_id;
                    //    cOMN_Remark.UpdatedDate = DateTime.Now;
                    //    cOMN_Remark.RowStatusID = 1;// int.Parse(ddlRowStatusID.SelectedValue);
                    //    int resutl = COMN_RemarkManager.InsertCOMN_Remark(cOMN_Remark);
	
                    //}

                    //if (chbAttendants.Checked)
                    //{
                        STD_ClassSubjectEmployeeStudent css = new STD_ClassSubjectEmployeeStudent();

                        css.ClassSubjectEmployeeID = Convert.ToInt32(lblClassSubjectEmloyeeID.Text);
                        css.StudentID = lblStudentID.Text;
                        css.RowStatusID = 1;
                        css.AddedBy = Profile.card_id;

                        css.UpdateDate = DateTime.Now;
                        css.UpdatedBy = Profile.card_id;
                        css.AddedDate = date;

                        //if (chkManualDataEntry.Checked)
                        //{
                            css.ExtraField1 = txtAttendantDate.Text + " (" + DateTime.Parse(txtAttendantDate.Text).ToString("ddd") + ") - " + ddlStartHour.SelectedValue + ":" + ddlStartMin.SelectedValue + " " + ddlStartAMPM.SelectedValue + " - " + ddlEndHour.SelectedValue + ":" + ddlEndMin.SelectedValue + " " + ddlEndAMPM.SelectedValue;
                        //}
                        //else
                        //{
                        //    css.ExtraField1 = hfAttendenceDataTime.Value;
                        //}

                        css.ExtraField2 = ddlEmployeeID.SelectedValue;
                        css.ExtraField3 = txtCoveredSyllabus.Text; //temporary we are sending data for covered Syllabus
                        css.TodayRemark = txtRemark.Text;
                        css.IsExam = chkExamTaken.Checked;
                        css.IsAbsence = !chbAttendants.Checked;

                        int result = STD_ClassSubjectEmployeeStudentManager.InsertSTD_ClassSubjectEmployeeStudent(css);

                        if (result > 0)
                        {
                            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Add Attendants Successully.');", true);

                            //pnAttendantDate.Visible = true;

                            
                            //DataSet ca = STD_ClassSubjectEmployeeStudentManager.GetSTD_AttendantDateByEmployeeID(ddlEmployeeID.SelectedValue);
                            //lblNoAttendant.Text = ca.Tables[0].Rows.Count.ToString();
                            //gvSTD_AttendantTime.DataSource = ca;
                            //gvSTD_AttendantTime.DataBind();
                            //btnAddAttendant.Visible = false;
                        }

                    //}
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Add Attendants Successully.');", true);
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Attendants is already exist for this date time.');", true);
            }

            ddlEmployeeID_SelectedIndexChanged(this, new EventArgs());
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        Button btnAttendenceDateTime = new Button();
        btnAttendenceDateTime = (Button)sender;
        hfAttendenceDataTime.Value = btnAttendenceDateTime.Text; 
        string DateClassTimeName = btnAttendenceDateTime.Text;

        txtAttendantDate.Text = DateClassTimeName.Split('(')[0];

        string startTime = DateClassTimeName.Split('-')[1].Trim();
        string endTime = DateClassTimeName.Split('-')[2].Trim();

        ddlStartHour.SelectedValue = startTime.Split(':')[0];
        ddlStartMin.SelectedValue = startTime.Split(':')[1].Split(' ')[0];
        ddlStartAMPM.SelectedValue = startTime.Split(':')[1].Split(' ')[1];

        ddlEndHour.SelectedValue = endTime.Split(':')[0];
        ddlEndMin.SelectedValue = endTime.Split(':')[1].Split(' ')[0];
        ddlEndAMPM.SelectedValue = endTime.Split(':')[1].Split(' ')[1];

        ddlStartHour.Enabled = false;
        ddlStartMin.Enabled = false;
        ddlStartAMPM.Enabled = false;

        ddlEndHour.Enabled = false;
        ddlEndMin.Enabled = false;
        ddlEndAMPM.Enabled = false;

        //txtAttendantDate.Enabled = false;
        btnAddAttendant.Visible = true;

        lblPrint.Text = "<a class='button button-blue' target='_blank' href='AttendantSheet.aspx?Date=" + txtPrintAttendenceSheet.Text + "&StartTime=" + DateClassTimeName.Split('-')[1].Trim() + "&EndTime=" + DateClassTimeName.Split('-')[2].Trim() + "&classID=" + ddlClassID.SelectedValue + "&subjectID=" + ddlSubjectID.SelectedValue + "&employeeID=" + ddlEmployeeID.SelectedValue + "'>Print Blank Sheet</a>";
    }


    protected void btnViewAttendant_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlClassID.SelectedIndex != 0 && ddlSubjectID.SelectedIndex != 0 && ddlEmployeeID.SelectedIndex != 0 && txtAttendantDate.Text != "")
            {
                DateTime date = new DateTime();
                date = Convert.ToDateTime(txtAttendantDate.Text);
                string sdate = date.ToString().Substring(0, 9);

                Response.Redirect("ClassAttendant.aspx?classID=" + ddlClassID.SelectedValue + "&subjectID=" + ddlSubjectID.SelectedValue + "&employeeID=" + ddlEmployeeID.SelectedValue + "&Date=" + Convert.ToDateTime(sdate + " " + ddlStartHour.SelectedValue + ":" + ddlStartMin.SelectedValue + ":" + "00"));
            }
        }

        catch (Exception ex)
        {
        }

    }
    protected void ddlEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            pnAttendantDate.Visible = true;
            
            //DataSet ca = STD_ClassSubjectEmployeeStudentManager.GetSTD_AttendantDateByEmployeeID(ddlEmployeeID.SelectedValue);
            
            DataSet ds =  STD_ClassSubjectEmployeeStudentManager.GetSTD_ClassSubjectEmployeeByClassSubjectEmployeeIDDatasetDistinct(STD_ClassSubjectEmployeeManager.GetSTD_ClassSubjectByClassSubjectID(STD_ClassSubjectManager.GetSTD_SubjectBySubjectIDnClassID(int.Parse(ddlSubjectID.SelectedValue),int.Parse(ddlClassID.SelectedValue)).ClassSubjectID).ClassSubjectEmployeeID);

            lblNoAttendant.Text = ds.Tables[0].Rows.Count.ToString();

            gvSTD_AttendantTime.DataSource = ds;

            gvSTD_AttendantTime.DataBind();

            lblPrint.Text = "<a class='button button-blue' target='_blank' href='AttendantSheet.aspx?classID=" + ddlClassID.SelectedValue + "&subjectID=" + ddlSubjectID.SelectedValue + "&employeeID=" + ddlEmployeeID.SelectedValue + "'>Print Blank Sheet</a>";
            lblAttendenceReport.Text = "<a class='button button-blue' target='_blank' href='AttendantSheetAttendedReport.aspx?classID=" + ddlClassID.SelectedValue + "&subjectID=" + ddlSubjectID.SelectedValue + "&employeeID=" + ddlEmployeeID.SelectedValue + "'>Attencence Report</a>";

            loadClassFromRoutine(ds);

            DataSet dsStudentAttendence = STD_StudentManager.GetSTD_StudentsAttentdant(Convert.ToInt32(ddlClassID.SelectedValue), Convert.ToInt32(ddlSubjectID.SelectedValue), ddlEmployeeID.SelectedValue);
            hfSoftwareIds.Value = "";
            foreach (DataRow dr in dsStudentAttendence.Tables[0].Rows)
            {
                if (dr["PaymentDueAmount"].ToString() == "0.00")
                {
                    dr["ExtraField1"] = false; ;
                }
                else
                {
                    dr["ExtraField1"] = true;
                }

                dr["ExtraField2"] = !(bool)dr["ExtraField1"];

                hfSoftwareIds.Value += "-" +dr["StudentCode"].ToString() +"-";
            }

            gvSTD_ClassSubjectEmployeeStudent.DataSource = dsStudentAttendence;
            gvSTD_ClassSubjectEmployeeStudent.DataBind();


        }
        catch (Exception ex)
        {
        }
    }

    private void loadClassFromRoutine(DataSet dsAlreadyDataset)
    {
        DataSet ds= STD_RoutineTimeManager.GetAllSTD_RoutineTimesByClassSubjectTeacher(int.Parse(ddlClassID.SelectedValue),int.Parse(ddlSubjectID.SelectedValue),ddlEmployeeID.SelectedValue);
        
        STD_ClassSubject classSubject = STD_ClassSubjectManager.GetSTD_SubjectBySubjectIDnClassID(int.Parse(ddlSubjectID.SelectedValue), int.Parse(ddlClassID.SelectedValue));
                
        List<STD_Attendence> attendences = new List<STD_Attendence>();

        if (classSubject.ExtraField1 != "" && classSubject.ExtraField2 != "")
        {
            DateTime StartDate = DateTime.Parse(classSubject.ExtraField1);
            DateTime EndDate = DateTime.Parse(classSubject.ExtraField2);
            for (int i = 0; StartDate.AddDays(i) <= EndDate; i++)
            {
               foreach (DataRow dr in ds.Tables[0].Rows)
	            {
                    if (StartDate.AddDays(i).DayOfWeek.ToString().ToLower() == dr["ClassDayName"].ToString().ToLower() && StartDate.AddDays(i) >= DateTime.Today)
                    {
                        STD_Attendence attendence = new STD_Attendence();
                        attendence.ClassTimeName = dr["ClassTimeName"].ToString();
                        attendence.Date = StartDate.AddDays(i);
                        attendence.DateClassTimeName = attendence.Date.ToString("dd MMM, yyyy (ddd)")+" - " + attendence.ClassTimeName;
                        bool NeedtoAdd = true;
                        foreach (DataRow drAlreadyInAttendence in dsAlreadyDataset.Tables[0].Rows)
	                    {
                            if (attendence.DateClassTimeName.Trim() == drAlreadyInAttendence["ExtraField1"].ToString().Trim())
                            {
                                NeedtoAdd = false;
                            }
	                    }
                        
                        if(NeedtoAdd)attendences.Add(attendence);
                    }
	            }
            }

            lblNoAttendantAlready.Text = attendences.Count.ToString();

            gvClassFromRoutine.DataSource = attendences;
            gvClassFromRoutine.DataBind();
            
        }
        else
        {
            string msg = "For this class and subject the time limit has not given yet.";
        }
    }
    protected void chkManualDataEntry_CheckedChanged(object sender, EventArgs e)
    {
        if (chkManualDataEntry.Checked)
        {
            btnAddAttendant.Visible = true;
        }
        else
        {
            //btnAddAttendant.Visible = !txtAttendantDate.Enabled;
        }
    }
    protected void chkLoadFromMachine_CheckedChanged(object sender, EventArgs e)
    {
        if (chkLoadFromMachine.Checked)
        {
            //load from Machin Attendence
            //double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString())
            List<Attendence> justPresentusers = new List<Attendence>();
            if (txtAttendantDate.Text == "")
            {
                justPresentusers = AttendenceManager.GetAllAttendencesByDateJustPresent(DateTime.Today.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString())).ToString("yyyy-MM-dd"));
            }
            else
            {
                justPresentusers = AttendenceManager.GetAllAttendencesByDateJustPresent(DateTime.Parse(txtAttendantDate.Text).ToString("yyyy-MM-dd"));
            }

            foreach (GridViewRow gr in gvSTD_ClassSubjectEmployeeStudent.Rows)
            {
                Label lblStudentCode = (Label)gr.FindControl("lblStudentCode");
                CheckBox chbAttendants = (CheckBox)gr.FindControl("chbAttendants");

                chbAttendants.Checked = false;
                foreach (Attendence justPresentuser in justPresentusers)
                {
                    if (justPresentuser.UserID == lblStudentCode.Text)
                    {
                        if (justPresentuser.AttendenceID % 2 == 0)
                        {
                            chbAttendants.Checked = true;
                        }
                        break;
                    }
                }
            }
        }
        else
        {
            foreach (GridViewRow gr in gvSTD_ClassSubjectEmployeeStudent.Rows)
            {
                CheckBox chbAttendants = (CheckBox)gr.FindControl("chbAttendants");
                chbAttendants.Checked = true;
            }
        }
    }
    protected void txtPrintAttendenceSheet_TextChanged(object sender, EventArgs e)
    {
        lblPrint.Text = "<a class='button button-blue' target='_blank' href='AttendantSheet.aspx?Date=" + txtPrintAttendenceSheet.Text + "&StartTime=&EndTime=&classID=" + ddlClassID.SelectedValue + "&subjectID=" + ddlSubjectID.SelectedValue + "&employeeID=" + ddlEmployeeID.SelectedValue + "'>Print Blank Sheet</a>";
    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in gvSTD_ClassSubjectEmployeeStudent.Rows)
        {
            CheckBox chbAttendants = (CheckBox)gr.FindControl("chbAttendants");

            chbAttendants.Checked = chkSelectAll.Checked ;
        }
    }
    protected void btnOldSystemVirification_Click(object sender, EventArgs e)
    {
        if (txtIDFormPreviousAttendenceSheet.Text != "")
        {

            txtIDFormPreviousAttendenceSheet.Text = txtIDFormPreviousAttendenceSheet.Text.Replace(" ", "");
            hfSoftwareIds.Value = hfSoftwareIds.Value.Replace(" ", "");

            string idsNotinSoftware = "";
            string idsExtrainSoftware = "";

            foreach (string  id in txtIDFormPreviousAttendenceSheet.Text.Split(','))
            {
                if (id.Length>3)
                {
                   string  newid = id.Replace(" ", "");
                   newid = newid.Replace("\n", "");
                   if (!hfSoftwareIds.Value.Contains("-" + newid + "-"))
                    {
                        idsNotinSoftware += newid + ",";
                    }
                }
            }

            hfSoftwareIds.Value = hfSoftwareIds.Value.Replace("--", ",");
            hfSoftwareIds.Value = hfSoftwareIds.Value.Replace("-", ",");


            txtIDFormPreviousAttendenceSheet.Text =  txtIDFormPreviousAttendenceSheet.Text;

            foreach (string id in hfSoftwareIds.Value.Split(','))
            {
                if (id.Length > 3)
                {
                    string newid = id.Replace(" ", "");
                    newid = newid.Replace("\n", "");
                    if (!txtIDFormPreviousAttendenceSheet.Text.Contains("," + newid + ","))
                    {
                        idsExtrainSoftware += newid + ",";
                    }
                }
            }

            lblNeedOperation.Text = "<table border='1'><tr ><td style='border:2px solid Black;padding:10px;'>Need to Add</td><td style='border:2px solid Black;padding:10px;'>Need to Remove From the Class</td></tr><tr><td style='border:2px solid Black;padding:10px;'>";

            if (idsNotinSoftware != "")
            {
                int count = 1;
                foreach (string id in idsNotinSoftware.Split(','))
                {
                    
                    if (id != "")
                    {
                        lblNeedOperation.Text += "("+ (count++).ToString() + ")<a target='_blank' href='EnrollmentHistory.aspx?StudentCode="+id+"'>"+id+"</a><br/>";
                    }
                }
            }

            lblNeedOperation.Text += "</td><td style='border:2px solid Black;padding:10px;'>";

            if (idsExtrainSoftware != "")
            {
                int count = 1;
                foreach (string id in idsExtrainSoftware.Split(','))
                {
                    if (id != "")
                    {
                        lblNeedOperation.Text +="("+ (count++).ToString() + ") <a target='_blank' href='EnrollmentHistory.aspx?StudentCode=" + id + "'>" + id + "</a><br/>";
                    }
                }
            }
            lblNeedOperation.Text += "</td></tr></table>";
        }
    }
}

