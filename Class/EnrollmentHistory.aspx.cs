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
 public partial class AdminSTD_Class : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClassIDLoad();
            if (Request.QueryString["StudentCode"] != null)
            {
                txtStudentCode.Text = Request.QueryString["StudentCode"];
                btnVarify_OnClick(this, new EventArgs());
            }
		}
	}


    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = STD_ClassSubjectStudentManager.DeleteSTD_ClassSubjectStudentByClassSubjectIDnStudentID(Convert.ToInt32(linkButton.CommandArgument),hfStudentID.Value);
        btnVarify_OnClick(this, new EventArgs());
    }

    protected void lbPassed_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = STD_ClassSubjectStudentManager.HistorySTD_ClassSubjectStudentByClassSubjectIDnStudentID(Convert.ToInt32(linkButton.CommandArgument), hfStudentID.Value);
       btnVarify_OnClick(this, new EventArgs());
    }

    public String getRoutineText(int classID,int SubjectID)
    {
        try
        {

            STD_RoutineTime routineTime = new STD_RoutineTime();
            routineTime.RoomID = 0;
            routineTime.ClassID = classID;
            routineTime.SubjectID = SubjectID;
            routineTime.EmployeeID = "";
            string StudentID = "";
            DataSet dsRoutineTimeByClassnSubject = STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);

            routineTime = new STD_RoutineTime();
            routineTime.RoomID = 0;
            routineTime.ClassID = 0;
            routineTime.SubjectID = 0;
            routineTime.EmployeeID = "";
            StudentID = hfStudentID.Value == "0" ? "" : hfStudentID.Value;
            DataSet dsRoutineTimeByStudent = STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);


            DataSet dsClassTime = STD_ClassTimeManager.GetAllSTD_ClassTimes();
            DataSet dsClassDay = STD_ClassDayManager.GetAllSTD_ClassDaies();
            int width = 120;
            int widthDay = 70;
            string routine = "<table id='tblRoutineDisplay'  style='font-size:10px;width:" + ((dsClassTime.Tables[0].Rows.Count * width) + widthDay).ToString() + "px'>";
            string classTimeGroupID = dsClassTime.Tables[0].Rows[0]["ClassTimeGroupID"].ToString();
            for (int row = 0; row < dsClassTime.Tables[0].Rows.Count; row++)
            {
                if (classTimeGroupID != dsClassTime.Tables[0].Rows[row]["ClassTimeGroupID"].ToString())
                {
                    routine += "<tr><td colspan='" + (dsClassDay.Tables[0].Rows.Count + 1) + "'>&nbsp;</br></br></br></td></tr>";
                    //routine += "<tr><td colspan='" + (dsClassDay.Tables[0].Rows.Count + 1) + "'>&nbsp;</td></tr>";
                    classTimeGroupID = dsClassTime.Tables[0].Rows[row]["ClassTimeGroupID"].ToString();
                }

                if (row == 0)
                {
                    routine += "<tr style='border-top:1px solid Black;'><td></td>";

                    for (int col = 0; col < dsClassDay.Tables[0].Rows.Count; col++)
                    {
                        routine += "<td>";
                        routine += dsClassDay.Tables[0].Rows[col]["ClassDayName"].ToString();
                        routine += "</td>";
                    }

                    routine += "</tr>";
                }

                routine += "<tr>";
                for (int col = 0; col < dsClassDay.Tables[0].Rows.Count; col++)
                {
                    if (col == 0)
                    {
                        routine += "<td style='min-width:" + widthDay + "px'>";
                        routine += dsClassTime.Tables[0].Rows[row]["ClassTimeName"].ToString();
                        routine += "</td>";
                    }

                    routine += "<td style='min-width:" + width + "px;'>";
                    routine += GetClassName(dsRoutineTimeByClassnSubject, dsRoutineTimeByStudent, dsClassTime.Tables[0].Rows[row]["ClassTimeID"].ToString(), dsClassDay.Tables[0].Rows[col]["ClassDayID"].ToString());
                    routine += "</td>";
                }
                routine += "</tr>";
            }
            routine += "</table>";

            routine += STD_RoutineTimeManager.GetTeacherName(dsRoutineTimeByClassnSubject);

            return routine;

        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public string GetClassName(DataSet dsRoutineTimeByClassnSubject, DataSet dsRoutineTimeByStudent, string ClassTimeID, string ClassDayID)
    {
        //btnEnrollment.Visible = true;
        //lblConfilictMessage.Text = "";
        string className = "";
        string byStudentRoutineIDs = "";
        foreach (DataRow drByStudent in dsRoutineTimeByStudent.Tables[0].Rows)
        {
            if (drByStudent["ClassTimeID"].ToString() == ClassTimeID && drByStudent["ClassDayID"].ToString() == ClassDayID)
            {
                if (className != "") className += "</br>";
                byStudentRoutineIDs += " " + drByStudent["RoutineTimeID"].ToString() + " ";
                //className += "(" + drByStudent["SubjectName"].ToString() + ") (" + drByStudent["ClassName"].ToString() + ") (" + drByStudent["EmployeeName"].ToString() + ")  (" + drByStudent["RoomName"].ToString() + ")";
                className += "(" + drByStudent["ClassName"].ToString() + ") (" + drByStudent["SubjectName"].ToString() + ") (" + drByStudent["EmployeeSortName"].ToString() + ")  (" + drByStudent["RoomName"].ToString() + ")";
            }
        }

        foreach (DataRow drByClassnSubject in dsRoutineTimeByClassnSubject.Tables[0].Rows)
        {
            if (drByClassnSubject["ClassTimeID"].ToString() == ClassTimeID && drByClassnSubject["ClassDayID"].ToString() == ClassDayID)
            {
                //if (className != "") className += "</br>";
                //if (byStudentRoutineIDs.Contains(" " + drByClassnSubject["RoutineTimeID"].ToString() + " "))
                if (className != "")
                {
                    className += "</br>";
                    className += "<span style='color:Red;'>(" + drByClassnSubject["ClassName"].ToString() + ") (" + drByClassnSubject["SubjectName"].ToString() + ") (" + drByClassnSubject["EmployeeSortName"].ToString() + ")  (" + drByClassnSubject["RoomName"].ToString() + ")</span>";

                    //btnEnrollment.Visible = false;
                    if (lblConfilictMessage.Text == "")
                    {
                        lblConfilictMessage.Text = "Routine Conflict";
                    }
                    uncheckTheSubject(hfsubjectID.Value);
                    
                }
                else
                {
                    className += "<span style='color:Green;'>(" + drByClassnSubject["ClassName"].ToString() + ") (" + drByClassnSubject["SubjectName"].ToString() + ") (" + drByClassnSubject["EmployeeSortName"].ToString() + ")  (" + drByClassnSubject["RoomName"].ToString() + ")</span>";
                }
            }
        }



        return className;
    }

    private void uncheckTheSubject(string SubjectID)
    {
        foreach (GridViewRow gr in gvSubjects.Rows)
        {
            CheckBox chkSubject = (CheckBox)gr.FindControl("chkSubject");
            if (chkSubject.ToolTip == SubjectID)
            {
                chkSubject.Checked = false;
            }
        }
    }


    private int SubjectIDLoad()
    {
        try
        {
            int rowcount = 0;
            DataSet ds = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassID(int.Parse(ddlClassID.SelectedValue), true);
            rowcount= ds.Tables[0].Rows.Count;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (hfSubjects.Value.Contains("-" + dr["SubjectID"].ToString() + "-"))
                {
                    dr.Delete();
                    rowcount--;
                }
            }

            gvSubjects.DataSource = ds.Tables[0];
            gvSubjects.DataBind();

            return rowcount;
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
            return 0;
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

    protected void btnVarify_OnClick(object sender, EventArgs e)
    {
        hfSubjects.Value = "-";
        txtStudentCode.Text = txtStudentCode.Text.Trim();
        ddlClassID.SelectedIndex = 0;
        ddlClassID_SelectedIndexChanged(this, new EventArgs());
        STD_Student student = new STD_Student();
        student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text);
        txtAccARegistrationNo.Text = student.RegistrationNo;
        
        if (student.RegistrationNo != "")
        {
            txtAccARegistrationNo.Enabled = false;
            btnSaveRegistrationNo.Visible = false;
        }

        if (student == null)
        {
            lblMessage.Text = "<br/>There is no Student with this student Id";
            return;
        }
        else
        {
            lblMessage.Text = "!!! Valid ID  !!!";
            hfStudentID.Value = student.StudentID;
            StudentCodeVarification(student);

            //load routine for that student;
            STD_RoutineTime routineTime = new STD_RoutineTime();
            routineTime.RoomID = Request.QueryString["RoomID"] == null ? 0 : int.Parse(Request.QueryString["RoomID"]);
            routineTime.RoutineID = Request.QueryString["RoutineID"] == null ? 0 : int.Parse(Request.QueryString["RoutineID"]);
            routineTime.ClassID = Request.QueryString["ClassID"] == null ? 0 : int.Parse(Request.QueryString["ClassID"]);
            routineTime.SubjectID = Request.QueryString["SubjectID"] == null ? 0 : int.Parse(Request.QueryString["SubjectID"]);
            routineTime.EmployeeID = Request.QueryString["EmployeeID"] == null ? "" : Request.QueryString["EmployeeID"];
            string StudentID = hfStudentID.Value;
            lblVerifyRoutine.Text = STD_RoutineTimeManager.getRoutineTextDayTop(routineTime, StudentID);
            lblVerifyRoutine.Text = lblVerifyRoutine.Text.Replace("id='tblRoutineDisplay'", "border='1'");
            lblVerifyRoutine.Text = lblVerifyRoutine.Text.Replace("id='tblRoutineDisplayTeacher'", "border='1'");
            //lblVerifyRoutine.Text = //getRoutineText(0,0);
        }

        loadHistory(student);

        
    }

    private void loadHistory(STD_Student student)
    {
        DataSet ds=STD_ClassManager.GetSTD_ClassByStudentID(student.StudentID);


        gvSTD_Class.DataSource = ds.Tables[0];
        gvSTD_Class.DataBind();

        if (ds.Tables[1].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[1];
            lblDeletedHistory.Text = "<b style='font-size:15px'>Transfered Classes[Black= Active Classes; Green= Passed in those Classes; Red= Deleted from those classes]</b><table border='1' cellpadding='2' cellspacing='2'>";
            string doneSubjectID = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (!doneSubjectID.Contains("-" + dr["SubjectID"].ToString() + "-"))
                { 
                    lblDeletedHistory.Text+="<tr><td>"+dr["SubjectName"].ToString()+"</td><td>";
                    doneSubjectID+=";-" + dr["SubjectID"].ToString() + "-";

                    string doneClassID = "";

                    foreach (DataRow drClass in dt.Rows)
                    {
                        if (!doneClassID.Contains("-" + drClass["ClassID"].ToString() + "-"))
                        {
                            if (drClass["RowStatusID"].ToString() == "1" && dr["SubjectID"].ToString() == drClass["SubjectID"].ToString())
                            {
                                lblDeletedHistory.Text += " --> " + drClass["ClassName"].ToString();
                                doneClassID += ";-" + drClass["ClassID"].ToString() + "-";
                            }
                        }
                    }                    
                        foreach (DataRow drClass in dt.Rows)
                        {
                            if (!doneClassID.Contains("-" + drClass["ClassID"].ToString() + "-"))
                            {
                                if (drClass["RowStatusID"].ToString() == "14" && dr["SubjectID"].ToString() == drClass["SubjectID"].ToString())
                                {
                                    lblDeletedHistory.Text += "<span style='color:Green;'> --> " + drClass["ClassName"].ToString() + "</span>";
                                    doneClassID += ";-" + drClass["ClassID"].ToString() + "-";
                                }
                            }
                        }
                        foreach (DataRow drClass in dt.Rows)
                        {
                            if (!doneClassID.Contains("-" + drClass["ClassID"].ToString() + "-"))
                            {
                                if (drClass["RowStatusID"].ToString() == "3" && dr["SubjectID"].ToString() == drClass["SubjectID"].ToString())
                                {
                                    lblDeletedHistory.Text += "<span style='color:red;'> --> " + drClass["ClassName"].ToString() + "</span>";
                                    doneClassID += ";-" + drClass["ClassID"].ToString() + "-";
                                }
                            }
                        }

                     
                       
                    }
                    lblDeletedHistory.Text += "</td></tr>";
                }
        
            lblDeletedHistory.Text += "</table>";
        }
        else
        {
            lblDeletedHistory.Text = "";
        }
    }

    private bool StudentCodeVarification(STD_Student students)
    {
        // = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text.Trim());
        if (students != null)
        {
            pnStudentDetails.Visible = true;
            lblName.Text = students.StudentName;
            lblContact.Text = students.Mobile;
            imgStudent.ImageUrl = students.PPSizePhoto;

            hfStudentID.Value = students.StudentID;
            lblMessage.Text = "<br/>Student Code is Exist. <a target='_blank' style='color:blue;' href='../Student/AdminDetailsSTD_Student.aspx?ID=" + students.StudentID + "'>Click here for Details</a>";
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is Exist')", true);
            return true;
        }
        else
        {
            lblMessage.Text = "S<br/>tudent Code is not Exist";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is not Exist')", true);
        }
        return false;
    }

    protected void gvSTD_Class_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfClassID = (HiddenField)e.Row.FindControl("hfClassID");
            HiddenField hfIsHistory = (HiddenField)e.Row.FindControl("hfIsHistory");

            GridView gvSubject = (GridView)e.Row.FindControl("gvSubject");

            DataSet ds = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassIDnStudentID(int.Parse(hfClassID.Value), hfStudentID.Value, true);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (bool.Parse(hfIsHistory.Value))
                {
                    dr["IsActive"] = false;
                    dr["IsHistory"] = true;
                }
                

                if (bool.Parse(dr["IsActive"].ToString())) //&& !bool.Parse(dr["IsHistory"].ToString()))
                {
                    hfSubjects.Value += dr["SubjectID"].ToString()+"-";
                }
            }

            gvSubject.DataSource = ds.Tables[0];
            gvSubject.DataBind();
        }
    }
    
    protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnEnrollment.Visible = false;
        if (ddlClassID.SelectedIndex != 0)
        {
            gvSubjects.Visible = true;
            if (SubjectIDLoad() != 0)
            {
                btnEnrollment.Visible = true;
            }
        }
        else
        {
            gvSubjects.Visible = false;
        }

        lblNoSubject.Visible = !btnEnrollment.Visible;
    }

    protected void btnEnrollment_Click(object sender, EventArgs e)
    {
        bool isAlreadyAdded= false;
        int classSubjectID = 0;
        foreach (GridViewRow gvr in gvSTD_Class.Rows)
        {
            HiddenField hfClassID = (HiddenField)gvr.FindControl("hfClassID");
            HiddenField hfIsHistory = (HiddenField)gvr.FindControl("hfIsHistory");

            if (!bool.Parse(hfIsHistory.Value) && ddlClassID.SelectedValue == hfClassID.Value)
            {
                isAlreadyAdded = true;
                break;
            }
        }

        if (!isAlreadyAdded)
        {
            STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
            sTD_ClassStudent.ClassStudentName = "";
            sTD_ClassStudent.StudentID = hfStudentID.Value;
            sTD_ClassStudent.ClassID = int.Parse(ddlClassID.SelectedValue);
            sTD_ClassStudent.AddedBy = Profile.card_id;
            sTD_ClassStudent.AddedDate = DateTime.Now;
            sTD_ClassStudent.UpdatedBy = Profile.card_id;
            sTD_ClassStudent.UpdateDate = DateTime.Now;
            sTD_ClassStudent.RowStatusID = 1;
            classSubjectID = STD_ClassStudentManager.InsertSTD_ClassStudent(sTD_ClassStudent);            
        }

        foreach (GridViewRow item in gvSubjects.Rows)
        {
            CheckBox chkSubject = (CheckBox)item.FindControl("chkSubject");
            //HiddenField hfClassSubjectID = (HiddenField)item.FindControl("hfClassSubjectID");

            if (chkSubject.Checked)
            {
                STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                //	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
                sTD_ClassSubjectStudent.ClassSubjectStudentName = "";
                sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
                sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(((HiddenField)item.FindControl("hfClassSubjectID")).Value);
                sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                sTD_ClassSubjectStudent.RowStatusID = 1;
                int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
            }
        }

        btnVarify_OnClick(this, new EventArgs());
        ddlClassID.SelectedIndex=0;
        ddlClassID_SelectedIndexChanged(this,new EventArgs());
    }
    protected void chkSubject_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSubject = new CheckBox();
        chkSubject = (CheckBox)sender;
        if (chkSubject.Checked)
        {
            hfsubjectID.Value = chkSubject.ToolTip;
            lblConfilictMessage.Text = "";
            lblVerifyRoutine.Text = getRoutineText(int.Parse(ddlClassID.SelectedValue), int.Parse(chkSubject.ToolTip));
            if (lblConfilictMessage.Text != "")
            {
                lblConfilictMessage.Text += " for [" + chkSubject.Text + "] in ["+ddlClassID.SelectedItem.Text+"]";
            }
        }
    }
    protected void btnSaveRegistrationNo_Click(object sender, EventArgs e)
    {
        STD_Student student = new STD_Student();
        student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text);
        student.RegistrationNo = txtAccARegistrationNo.Text;
        btnSaveRegistrationNo.Visible = false;
        txtAccARegistrationNo.Enabled = false;

        STD_StudentManager.UpdateSTD_Student(student);
    }
}

