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
            CourseIDLoad();
            TeacherIDLoad();
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


    private void TeacherIDLoad()
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_EmployeeFromSubjectEmployee();
            ddlTeacher.DataValueField = "SubjectID";
            ddlTeacher.DataTextField = "EmployeeNameNoID";
            ddlTeacher.DataSource = ds.Tables[0];
            ddlTeacher.DataBind();
            ddlTeacher.Items.Insert(0, new ListItem("Select Employee >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void gvSubject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            gvSubject.Visible = true;

            HiddenField hfSubjectID = (HiddenField)e.Row.FindControl("hfSubjectID");

            DropDownList ddlTeacherID = (DropDownList)e.Row.FindControl("ddlTeacherID");

            ddlTeacherID.Items.Add(new ListItem("Select Teacher >> ", "0"));
            foreach (ListItem li in ddlTeacher.Items)
            {
                if (li.Value == hfSubjectID.Value)
                {
                    ddlTeacherID.Items.Add(new ListItem(li.Text.Split(';')[1], li.Text.Split(';')[0]));
                }
            }

            ddlTeacherID.SelectedIndex = 0;
        }
    }

    #region

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            string[] ids = txtStudentIDs.Text.Split(',');
            List<STD_Student> students = new List<STD_Student>();
            foreach (string id in ids)
            {
                STD_Student student = STD_StudentManager.GetHR_StudnetByStudentCode(id.Trim());
                if (student != null)
                    students.Add(student);
            }

            gvStudents.DataSource = students;
            gvStudents.DataBind();

            addClass.Visible = true;
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        try
        {
            //string ids = getStudentID();
            string ids = getStudentIDs(gvStudents);
            if (ids != "")
            {
                STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
                sTD_ClassStudent.ClassStudentName = "";
                sTD_ClassStudent.StudentID = ids;
                sTD_ClassStudent.ClassID = int.Parse("1");
                sTD_ClassStudent.AddedBy = Profile.card_id;
                sTD_ClassStudent.AddedDate = DateTime.Now;
                sTD_ClassStudent.UpdatedBy = Profile.card_id;
                sTD_ClassStudent.UpdateDate = DateTime.Now;
                int resutl = STD_ClassStudentManager.InsertSTD_ClassStudent_List_KeepStudentInMultipleClassActive(sTD_ClassStudent);

                string message = resutl + " New Entry Created";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + message + "');", true);

                txtStudentIDs.Text = "";
                //Response.Redirect("ClassSubjectAddStudent.aspx?ID=" + ddlClassID.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + ex.Message.ToString() + "');", true);
        }
    }

    private string getStudentIDs(GridView gv)
    {
        string ids = string.Empty;
        try
        {
            foreach (GridViewRow row in gv.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    HiddenField hfStudentID = (HiddenField)row.FindControl("hfStudentID");
                    ids += hfStudentID.Value + ", ";
                }
            }
            if (ids.Length > 0)
                ids = ids.Substring(0, ids.Length - 2);
        }
        catch (Exception ex)
        {
        }
        return ids;
    }
    #endregion
    protected void ddlCourseID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourseID.SelectedIndex != 0)
        {
            SubjectIDLoad(int.Parse(ddlCourseID.SelectedValue));
        }
    }



    private void SubjectIDLoad(int courseID)
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_SubjectEnrollment(courseID);
            ds.Tables[0].Columns.Add("IsChecked", typeof(bool));
            ds.Tables[0].Columns.Add("ExtraField1", typeof(String));
            ds.Tables[0].Columns.Add("ExtraField2", typeof(String));

            if (ds == null) return;

            if (ds.Tables[0].Rows.Count == 0)
            {
                gvSubject.Visible = false;
                return;
            }

            List<STD_ClassSubject> sTD_ClassSubject = new List<STD_ClassSubject>();

           
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                gvSubject.Visible = true;
                dr["IsChecked"] = false;
                
            }

            gvSubject.DataSource = ds.Tables[0];
            gvSubject.DataBind();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //add Subject
        STD_Class sTD_Class = new STD_Class();
        try
        {
            
            //	sTD_Class.ClassID=  int.Parse(ddlClassID.SelectedValue);
            sTD_Class.ClassName = txtClassName.Text;
            sTD_Class.CourseID = int.Parse(ddlCourseID.SelectedValue);
            sTD_Class.ClassTypeID = 2;
            sTD_Class.ClassStatusID = 1;
            sTD_Class.AddedBy = Profile.card_id;
            sTD_Class.AddedDate = DateTime.Now;
            sTD_Class.UpdatedBy = Profile.card_id;
            sTD_Class.UpdateDate = DateTime.Now;
            sTD_Class.ClassID = STD_ClassManager.InsertSTD_Class(sTD_Class);
        }
        catch (Exception ex) { }

        //Add Student
        try {
            string ids = getStudentIDs(gvStudents);
            if (ids != "")
            {
                STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
                sTD_ClassStudent.ClassStudentName = "";
                sTD_ClassStudent.StudentID = ids;
                sTD_ClassStudent.ClassID = sTD_Class.ClassID;
                sTD_ClassStudent.AddedBy = Profile.card_id;
                sTD_ClassStudent.AddedDate = DateTime.Now;
                sTD_ClassStudent.UpdatedBy = Profile.card_id;
                sTD_ClassStudent.UpdateDate = DateTime.Now;
                int resutl = STD_ClassStudentManager.InsertSTD_ClassStudent_List_KeepStudentInMultipleClassActive(sTD_ClassStudent);

                //string message = resutl + " New Entry Created";
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Message", "alert('" + message + "');", true);

            }
        }
        catch (Exception ex) { }

        //Class Subject
        try
        {
            //delete all the rows for the
            STD_ClassSubjectManager.DeleteSTD_ClassSubjectByClassID(sTD_Class.ClassID);

            foreach (GridViewRow gr in gvSubject.Rows)
            {
                CheckBox chkSelect = (CheckBox)gr.FindControl("chkSelect");

                HiddenField hfSubjectID = (HiddenField)gr.FindControl("hfSubjectID");
                DropDownList ddlTeacherID = (DropDownList)gr.FindControl("ddlTeacherID");
                TextBox txtStartDate = (TextBox)gr.FindControl("txtStartDate");
                TextBox txtEndDate = (TextBox)gr.FindControl("txtEndDate");

                if (chkSelect.Checked)
                {
                    STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject();
                    sTD_ClassSubject.ClassSubjectName = "1";
                    sTD_ClassSubject.SubjectID = int.Parse(hfSubjectID.Value);
                    sTD_ClassSubject.ClassID = sTD_Class.ClassID;
                    sTD_ClassSubject.ExtraField1 = txtStartDate.Text;
                    sTD_ClassSubject.ExtraField2 = txtEndDate.Text;
                    sTD_ClassSubject.ExtraField3 = "";
                    sTD_ClassSubject.ExtraField4 = "";
                    sTD_ClassSubject.ExtraField5 = "";
                    sTD_ClassSubject.AddedBy = Profile.card_id;
                    sTD_ClassSubject.AddedDate = DateTime.Now;
                    sTD_ClassSubject.UpdatedBy = Profile.card_id;
                    sTD_ClassSubject.UpdateDate = DateTime.Now;
                    sTD_ClassSubject.ClassSubjectID = STD_ClassSubjectManager.InsertSTD_ClassSubject(sTD_ClassSubject);

                    if (ddlTeacherID.SelectedIndex != 0)
                    {
                        STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee();
                        //	sTD_ClassSubjectEmployee.ClassSubjectEmployeeID=  int.Parse(ddlClassSubjectEmployeeID.SelectedValue);
                        sTD_ClassSubjectEmployee.ClassSubjectEmployeeName = "Need to fix later";
                        sTD_ClassSubjectEmployee.EmployeeID = ddlTeacherID.SelectedValue;
                        sTD_ClassSubjectEmployee.ClassSubjectID = sTD_ClassSubject.ClassSubjectID;
                        sTD_ClassSubjectEmployee.AddedBy = Profile.card_id;
                        sTD_ClassSubjectEmployee.AddedDate = DateTime.Now;
                        sTD_ClassSubjectEmployee.UpdatedBy = Profile.card_id;
                        sTD_ClassSubjectEmployee.UpdateDate = DateTime.Now;
                        sTD_ClassSubjectEmployee.ClassSubjectEmployeeID = STD_ClassSubjectEmployeeManager.InsertSTD_ClassSubjectEmployee(sTD_ClassSubjectEmployee);
                    }

                    //Add Student
                    try
                    {
                        string ids = getStudentIDs(gvStudents);
                        if (ids != "")
                        {
                            STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                            sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                            sTD_ClassSubjectStudent.StudentID = ids;
                            sTD_ClassSubjectStudent.ClassSubjectID = sTD_ClassSubject.ClassSubjectID;
                            sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                            sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                            sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                            sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                            int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent_List_KeepStudentInMultipleClassActive(sTD_ClassSubjectStudent);
                        }
                    }
                    catch (Exception ex) { }
                }
            }

        }
        catch (Exception ex) { }

        Response.Redirect("Enrollment.aspx?Message=Saved succfully..");
    }
}