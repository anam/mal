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
 

public partial class AdminDisplaySTD_ClassStudent : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CourseIDLoad();
            Session["ClassSubjectStudents"] = null;
            Session["id"] = null;
            Session["eID"] = null;

            if (Request.QueryString["StudentCode"]!= null)
            {
                txtStudentCode.Text = Request.QueryString["StudentCode"];
                btnVarify_OnClick(this, new EventArgs());
            }

            if (Request.QueryString["ProcessEnrollment"] != null)
            {
                txtStudentCode.Text = Request.QueryString["StudentCode"];
                btnVarify_OnClick(this, new EventArgs());

                ddlCourseID.SelectedValue = Request.QueryString["CourseID"];
                ddlCourseID_OnSelectedIndexChanged(this, new EventArgs());

                bool isFound=false;
                for (int i = 1; i < ddlSubjectID.Items.Count;i++ )
                {
                    if (ddlSubjectID.Items[i].Value == Request.QueryString["SubjectID"])
                    {
                        ddlSubjectID.SelectedValue = Request.QueryString["SubjectID"];
                        ddlSubjectID_OnSelectedIndexChanged(this, new EventArgs());
                        isFound = true;
                        break;
                    }
                }

                if (!isFound) { lblConfilictMessage.Text = "This subject is not applicable for this student"; }
                else
                {
                    isFound = false;

                    if (Request.QueryString["ClassID"] != "0")
                    {
                        for (int i = 1; i < ddlSubjectID.Items.Count; i++)
                        {
                            if (ddlSubjectID.Items[i].Value == Request.QueryString["SubjectID"])
                            {
                                ddlClassID.SelectedValue = Request.QueryString["SubjectID"];
                                btnVarifyRoutine_Click(this, new EventArgs());
                                isFound = true;
                                break;
                            }
                        }

                        if (!isFound) { lblConfilictMessage.Text = "This subject and Class is not applicable for this student"; }
                    }
                }
            }
            
        }
    }
    private void CourseIDLoad()
    {
        try
        {
            DataSet ds = STD_CourseManager.GetDropDownListAllSTD_Course();
            ddlCourseID.DataValueField = "CourseID";
            ddlCourseID.DataTextField = "CourseName";
            ddlCourseID.DataSource = ds.Tables[0];
            ddlCourseID.DataBind();
            ddlCourseID.Items.Insert(0, new ListItem("Select Course >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void loadClassSubjectStudentDataBase()
    {

        List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
       
        DataSet ds = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByStudentID(hfStudentID.Value);
        
      
        foreach (DataRow dr in ds.Tables[0].Rows)
        {


            STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
            sTD_ClassSubjectStudent.ClassSubjectStudentID = int.Parse(dr["ClassSubjectStudentID"].ToString());
            sTD_ClassSubjectStudent.ClassSubjectStudentName = dr["ClassSubjectStudentName"].ToString();
            sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
            sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(dr["ClassSubjectID"].ToString());
            sTD_ClassSubjectStudent.SubjectID = int.Parse(dr["SubjectID"].ToString());
            sTD_ClassSubjectStudent.ClassID = int.Parse(dr["ClassID"].ToString());
            sTD_ClassSubjectStudent.SubjectName = dr["SubjectName"].ToString();
            sTD_ClassSubjectStudent.ClassName = dr["ClassName"].ToString();
            sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
            sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
            sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
            sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;

            sTD_ClassSubjectStudent.ClassSubjectStudentID = ClassSubjectStudents.Count;

            sTD_ClassSubjectStudent.ID = int.Parse(dr["ClassSubjectStudentID"].ToString());

            //Session["eID"] =Session["eID"]+ dr["ClassSubjectStudentID"].ToString() +",";
            //int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);

            ClassSubjectStudents.Add(sTD_ClassSubjectStudent);
        
        }

        Session["ClassSubjectStudents"] = ClassSubjectStudents;

        gvSTD_ClassSubjectStudent.DataSource = ClassSubjectStudents;
        gvSTD_ClassSubjectStudent.DataBind();

    }

    protected void btnVarify_OnClick(object sender, EventArgs e)
    {
        

        STD_Student student = new STD_Student();
        student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text);

        if (student == null)
        {
            lblMessage.Text = "<br/>There is no Student with this student Id";
            return;
        }
        else
        {
            lblMessage.Text = "!!! Valid ID  !!!";
            hfStudentID.Value = student.StudentID;
        }

        //Session["ClassSubjectStudents"] = student;
        CourseIDLoad();
        loadClassSubjectStudentDataBase();
        loadRoutine();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["id"] != null)
            {
                string[] id = Session["id"].ToString().Split(',');

                for (int i = 0; i < id.Length-1; i++)
                {
                    STD_ClassSubjectStudent sTD_ClassSubjectStudent = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByClassSubjectStudentID(Convert.ToInt32(id[i]));
                    sTD_ClassSubjectStudent.RowStatusID = 3;
                    STD_ClassSubjectStudentManager.UpdateSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
                }

            }
            //insert the classes which are not assigned for that student
            string classIDsNeedtoAddinDataBase = "";

            hfclassIDs.Value = "";
            DataSet ds = STD_ClassStudentManager.GetSTD_ClassStudentByStudentID(hfStudentID.Value, true);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                hfclassIDs.Value += dr["ClassID"].ToString() + "-";
            }

            if (Session["ClassSubjectStudents"] != null)
            {
                List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
                ClassSubjectStudents = (List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"];


                foreach (STD_ClassSubjectStudent classSubjectStudent in ClassSubjectStudents)
                {
                    if (!hfclassIDs.Value.Contains(classSubjectStudent.ClassID.ToString()))
                    {
                        classIDsNeedtoAddinDataBase += classSubjectStudent.ClassID.ToString() + "-";
                    }
                }

                if (classIDsNeedtoAddinDataBase != "")
                {
                    string[] ids = classIDsNeedtoAddinDataBase.Split('-');
                    foreach (string id in ids)
                    {
                        if (id != "" && id != "-")
                        {
                            STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
                            //	sTD_ClassStudent.ClassStudentID=  int.Parse(ddlClassStudentID.SelectedValue);
                            sTD_ClassStudent.ClassStudentName = "";
                            sTD_ClassStudent.StudentID = hfStudentID.Value;
                            sTD_ClassStudent.ClassID = int.Parse(id);
                            sTD_ClassStudent.AddedBy = Profile.card_id;
                            sTD_ClassStudent.AddedDate = DateTime.Now;
                            sTD_ClassStudent.UpdatedBy = Profile.card_id;
                            sTD_ClassStudent.UpdateDate = DateTime.Now;
                            sTD_ClassStudent.RowStatusID = 1;
                            int resutl = STD_ClassStudentManager.InsertSTD_ClassStudent(sTD_ClassStudent);
                        }
                    }
                }

                //Need to add the ClassSubject Student

                //insert the classes which are not assigned for that student
                string classSubjectIDsNeedtoAddinDataBase = "";

                hfclassIDs.Value = "";
                DataSet dsclassSubject = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByStudentID(hfStudentID.Value);
                foreach (DataRow dr in dsclassSubject.Tables[0].Rows)
                {
                    hfclassSubjectIDs.Value += dr["ClassSubjectID"].ToString() + "-";
                }


                foreach (STD_ClassSubjectStudent classSubjectStudent in ClassSubjectStudents)
                {
                    if (!hfclassSubjectIDs.Value.Contains(classSubjectStudent.ClassSubjectID.ToString()))
                    {
                        classSubjectIDsNeedtoAddinDataBase += classSubjectStudent.ClassSubjectID.ToString() + "-";
                    }
                }

                if (classSubjectIDsNeedtoAddinDataBase != "")
                {
                    string[] ids = classSubjectIDsNeedtoAddinDataBase.Split('-');
                    foreach (string id in ids)
                    {
                        if (id != "" && id != "-")
                        {
                            STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                            //	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
                            sTD_ClassSubjectStudent.ClassSubjectStudentName = "";
                            sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
                            sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(id);
                            sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                            sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                            sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                            sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                            sTD_ClassSubjectStudent.RowStatusID = 1;
                            int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);


                        }
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Save successfully.')", true);
                }
                else
                {
                    foreach (STD_ClassSubjectStudent classSubjectStudent in ClassSubjectStudents)
                    {
                        classSubjectStudent.RowStatusID = 1;
                        STD_ClassSubjectStudentManager.UpdateSTD_ClassSubjectStudent(classSubjectStudent);
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Save successfully.')", true);
                }
            }

        }
        catch (Exception ex)
        {
        }
    
    }

    protected void btnLoadSubjecct_Click(object sender, EventArgs e)
    {
        loadSubjet();
    }

    private void loadSubjet()
    {
        try
        {
            ddlSubjectID.Items.Clear();
            ddlClassID.Items.Clear();

            DataSet ds = STD_SubjectManager.GetSTD_SubjectByCourseIDByStudentIDWhoHasnotTakenTheClass(int.Parse(ddlCourseID.SelectedValue),hfStudentID.Value);
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select subject >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    
    }
    protected void btnLoadClass_Click(object sender, EventArgs e)
    {
        loadClass();
    }

    private void loadClass()
    {
        try
        {

            ddlClassID.Items.Clear();
            DataSet ds = STD_ClassSubjectManager.GetSTD_ClassSubjectBySubjectID(int.Parse(ddlSubjectID.SelectedValue));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["ClassName"].ToString(), dr["ClassSubjectID"].ToString() + "-" + dr["ClassID"].ToString());
                ddlClassID.Items.Add(item);

            }            
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0-0"));


        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }
    protected void btnAddClass_Click(object sender, EventArgs e)
    {
        btnVarifyRoutine_Click(this, new EventArgs());
        if (btnAddClass.Visible)
        {
            int i = 0;

            if (Session["ClassSubjectStudents"] != null)
            {

                List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
                ClassSubjectStudents = (List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"];

                foreach (STD_ClassSubjectStudent subject in ClassSubjectStudents)
                {
                    if (ddlSubjectID.SelectedItem.Text == subject.SubjectName)
                    {
                        i = 1;
                        break;
                    }
                }
            }
            //btnVarify_OnClick(this, new EventArgs());

            if (i == 0)
            {
                if (Session["ClassSubjectStudents"] == null)
                {

                    List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();

                    string[] words = ddlClassID.SelectedValue.Split('-');


                    STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                    sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                    sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
                    sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(ddlClassID.SelectedValue.Split('-')[0]);
                    sTD_ClassSubjectStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                    sTD_ClassSubjectStudent.ClassID = int.Parse(ddlClassID.SelectedValue.Split('-')[1]);
                    sTD_ClassSubjectStudent.SubjectName = ddlSubjectID.SelectedItem.Text;
                    sTD_ClassSubjectStudent.ClassName = ddlClassID.SelectedItem.Text;
                    sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                    sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                    sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                    sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                    sTD_ClassSubjectStudent.RowStatusID = 1;
                    sTD_ClassSubjectStudent.ClassSubjectStudentID = ClassSubjectStudents.Count;

                    //int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);

                    ClassSubjectStudents.Add(sTD_ClassSubjectStudent);
                    Session["ClassSubjectStudents"] = ClassSubjectStudents;
                    loadClassSubjectStudent();
                }

                else
                {
                    string[] words = ddlClassID.SelectedValue.Split('-');


                    STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                    sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                    sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
                    sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(ddlClassID.SelectedValue.Split('-')[0]);
                    sTD_ClassSubjectStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                    sTD_ClassSubjectStudent.ClassID = int.Parse(ddlClassID.SelectedValue.Split('-')[1]);
                    sTD_ClassSubjectStudent.SubjectName = ddlSubjectID.SelectedItem.Text;
                    sTD_ClassSubjectStudent.ClassName = ddlClassID.SelectedItem.Text;
                    sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                    sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                    sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                    sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                    sTD_ClassSubjectStudent.RowStatusID = 1;

                    sTD_ClassSubjectStudent.ClassSubjectStudentID = ((List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"]).Count;
                    //int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);

                    ((List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"]).Add(sTD_ClassSubjectStudent);
                    Session["ClassSubjectStudents"] = Session["ClassSubjectStudents"];
                    loadClassSubjectStudent();
                }
            }
        }
    }

  
    private void showUpdateInfoData(int studentID)
    {
        try
        {
            if (Session["ClassSubjectStudents"] != null)
            {
                List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
                ClassSubjectStudents = (List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"];

                STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();

                sTD_ClassSubjectStudent = ClassSubjectStudents[studentID];

                hfStudentID.Value= sTD_ClassSubjectStudent.StudentID;
                ddlClassID.SelectedValue = sTD_ClassSubjectStudent.ClassSubjectID.ToString()+"-"+sTD_ClassSubjectStudent.ClassID.ToString();                
                ddlSubjectID.SelectedValue= sTD_ClassSubjectStudent.SubjectID.ToString();
                hfClassStudentSubjectID.Value = sTD_ClassSubjectStudent.ClassSubjectStudentID.ToString();
                //ddlClassID.SelectedValue= sTD_ClassSubjectStudent.ClassID.ToString();
                //ddlSubjectID.SelectedItem.Text=sTD_ClassSubjectStudent.SubjectName;
                //ddlClassID.SelectedItem.Text= sTD_ClassSubjectStudent.ClassName; 
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void loadClassSubjectStudent()
    {
        if (Session["ClassSubjectStudents"] != null)
        {
            gvSTD_ClassSubjectStudent.DataSource = Session["ClassSubjectStudents"];
            gvSTD_ClassSubjectStudent.DataBind();

            btnUpdateClass.Visible = false;
            btnAddClass.Visible = true;

            gvSTD_ClassSubjectStudent.Visible = true;
            btnSave.Visible = true;
        }
        else
        {
            gvSTD_ClassSubjectStudent.Visible = false;
            btnSave.Visible = false;
        }
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        showUpdateInfoData(id);

        btnAddClass.Visible = false;
        btnUpdateClass.Visible = true;
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        try
        {
            List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
            ClassSubjectStudents = (List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"];

           
            ImageButton imgButton = new ImageButton();
            imgButton = (ImageButton)sender;

            ClassSubjectStudents.RemoveAt(Convert.ToInt32(imgButton.CommandArgument));

            if (imgButton.ToolTip != "0")
            {
                Session["id"] = Session["id"] + imgButton.ToolTip + ",";
            }

           
            for (int i = 0; i < ClassSubjectStudents.Count; i++)
            {
                ClassSubjectStudents[i].ClassSubjectStudentID = i;
            }
            Session["ClassSubjectStudents"] = ClassSubjectStudents;
            loadClassSubjectStudent();
        }
        catch (Exception ex)
        { }
    }
    protected void btnUpdateClass_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ClassSubjectStudents"] != null)
            {
                List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
                ClassSubjectStudents = (List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"];

                STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
                sTD_ClassSubjectStudent.ClassSubjectStudentID = int.Parse(hfClassStudentSubjectID.Value);
                sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(ddlClassID.SelectedValue.Split('-')[0]);
                sTD_ClassSubjectStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                sTD_ClassSubjectStudent.ClassID = int.Parse(ddlClassID.SelectedValue.Split('-')[1]);
                sTD_ClassSubjectStudent.SubjectName = ddlSubjectID.SelectedItem.Text;
                sTD_ClassSubjectStudent.ClassName = ddlClassID.SelectedItem.Text;
                sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;



                ClassSubjectStudents[int.Parse(hfClassStudentSubjectID.Value)] = sTD_ClassSubjectStudent;
                Session["ClassSubjectStudents"] = ClassSubjectStudents;
                loadClassSubjectStudent();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlCourseID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        loadSubjet();
    }
    protected void ddlSubjectID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        loadClass();
    }

    protected void ddlClassID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //loadClass();
        try
        {          
            STD_RoutineTime routineTime = new STD_RoutineTime();
            routineTime.RoomID = 0;
            routineTime.ClassID = int.Parse(ddlClassID.SelectedValue.Split('-')[1]);
            routineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            routineTime.EmployeeID = "";
            string StudentID = "";
            lblRoutineDisplayForSelectedClassNSubject.Text = STD_RoutineTimeManager.getRoutineTextDayTop(routineTime, StudentID);
        }
        catch (Exception ex)
        { }
    }

    public  String getRoutineText()
    {
        try
        {

            STD_RoutineTime routineTime = new STD_RoutineTime();
            routineTime.RoomID = 0;
            routineTime.ClassID = int.Parse(ddlClassID.SelectedValue.Split('-')[1]);
            routineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            routineTime.EmployeeID = "";
            string StudentID = "";
            DataSet dsRoutineTimeByClassnSubject = STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);

            routineTime = new STD_RoutineTime();
            routineTime.RoomID = 0;
            routineTime.ClassID = 0;
            routineTime.SubjectID = 0;
            routineTime.EmployeeID = "";
            StudentID = hfStudentID.Value == "0" ? "" : hfStudentID.Value;
            DataSet dsRoutineTimeByStudent= STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);


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

    //public String getRoutineText()
    //{
    //    try
    //    {

    //        STD_RoutineTime routineTime = new STD_RoutineTime();
    //        routineTime.RoomID = 0;
    //        routineTime.ClassID = int.Parse(ddlClassID.SelectedValue.Split('-')[1]);
    //        routineTime.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
    //        routineTime.EmployeeID = "";
    //        string StudentID = "";
    //        DataSet dsRoutineTimeByClassnSubject = STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);

    //        routineTime = new STD_RoutineTime();
    //        routineTime.RoomID = 0;
    //        routineTime.ClassID = 0;
    //        routineTime.SubjectID = 0;
    //        routineTime.EmployeeID = "";
    //        StudentID = hfStudentID.Value == "0" ? "" : hfStudentID.Value;
    //        DataSet dsRoutineTimeByStudent = STD_RoutineTimeManager.STD_SearchRoutineTime(routineTime, StudentID);


    //        DataSet dsClassTime = STD_ClassTimeManager.GetAllSTD_ClassTimes();
    //        DataSet dsClassDay = STD_ClassDayManager.GetAllSTD_ClassDaies();
    //        int width = 450;
    //        int widthDay = 100;
    //        string routine = "<table border='1' style='width:" + ((dsClassTime.Tables[0].Rows.Count * width) + widthDay).ToString() + "px'>";

    //        for (int row = 0; row < dsClassDay.Tables[0].Rows.Count; row++)
    //        {
    //            if (row == 0)
    //            {
    //                routine += "<tr><td></td>";
    //                for (int col = 0; col < dsClassTime.Tables[0].Rows.Count; col++)
    //                {
    //                    routine += "<td>";
    //                    routine += dsClassTime.Tables[0].Rows[col]["ClassTimeName"].ToString();
    //                    routine += "</td>";

    //                }
    //                routine += "</tr>";
    //            }

    //            routine += "<tr>";
    //            for (int col = 0; col < dsClassTime.Tables[0].Rows.Count; col++)
    //            {
    //                if (col == 0)
    //                {
    //                    routine += "<td style='min-width:" + widthDay + "px'>";
    //                    routine += dsClassDay.Tables[0].Rows[row]["ClassDayName"].ToString();
    //                    routine += "</td>";
    //                }

    //                routine += "<td style='min-width:" + width + "px;'>";
    //                routine += GetClassName(dsRoutineTimeByClassnSubject, dsRoutineTimeByStudent, dsClassTime.Tables[0].Rows[col]["ClassTimeID"].ToString(), dsClassDay.Tables[0].Rows[row]["ClassDayID"].ToString());
    //                routine += "</td>";
    //            }
    //            routine += "</tr>";
    //        }
    //        routine += "</table>";


    //        return routine;

    //    }
    //    catch (Exception ex)
    //    {
    //        return "";
    //    }
    //}
    public string GetClassName(DataSet dsRoutineTimeByClassnSubject, DataSet dsRoutineTimeByStudent, string ClassTimeID, string ClassDayID)
    {
        btnAddClass.Visible = true;
        lblConfilictMessage.Text = "";
        string className = "";
        string byStudentRoutineIDs = "";
        foreach (DataRow drByStudent in dsRoutineTimeByStudent.Tables[0].Rows)
        {
            if (drByStudent["ClassTimeID"].ToString() == ClassTimeID && drByStudent["ClassDayID"].ToString() == ClassDayID)
            {
                if (className != "") className += "</br>";
                byStudentRoutineIDs += " "+drByStudent["RoutineTimeID"].ToString()+" ";
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
                    
                    btnAddClass.Visible = false;
                    lblConfilictMessage.Text = "Routine Conflict";
                }
                else
                {
                    className += "<span style='color:Green;'>(" + drByClassnSubject["ClassName"].ToString() + ") (" + drByClassnSubject["SubjectName"].ToString() + ") (" + drByClassnSubject["EmployeeSortName"].ToString() + ")  (" + drByClassnSubject["RoomName"].ToString() + ")</span>";
                }
            }
        }

        

        return className;
    }


    private void loadRoutine()
    {
        try
        {
            STD_RoutineTime routineTime = new STD_RoutineTime();
            routineTime.RoomID = 0;
            routineTime.ClassID = 0;
            routineTime.SubjectID = 0;
            routineTime.EmployeeID = "";
            string StudentID = hfStudentID.Value == "0" ? "" : hfStudentID.Value;
            lblRoutineDisplayForStudent.Text = STD_RoutineTimeManager.getRoutineTextDayTop(routineTime, StudentID);            
        }
        catch (Exception ex)
        { }
    }
    protected void btnVarifyRoutine_Click(object sender, EventArgs e)
    {
        lblVerifyRoutine.Text = getRoutineText();
    }
    protected void OnTextChanged_txtStudentCode(object sender, EventArgs e)
    {
        btnVarify_OnClick(new Object(), new EventArgs());
    }
}

