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
 public partial class AdminSTD_Exam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_ExamData();
           
            ClassIDLoad();
            //SubjectIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showSTD_ExamData();
            }
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

            DataSet ds = STD_SubjectManager.GetSTD_ClassSubjectsByClassID(ClassID);

            ListItem li = new ListItem("Select Subject >>", "0");
            ddlSubjectID.Items.Add(li);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["SubjectName"].ToString(), dr["ClassSubjectID"].ToString());
                ddlSubjectID.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            
            //add Std_ExamDetails
            STD_ExamDetails sTD_ExamDetails = new STD_ExamDetails();
            sTD_ExamDetails.ExamID = int.Parse(ddlSTDExamID.SelectedValue);
            sTD_ExamDetails.ExamTypeID = 0;
            sTD_ExamDetails.ExamDetailsName = "Online Quiz "+ ddlClassID.SelectedItem.Text +" for "+ddlSubjectID.SelectedItem.Text;
            sTD_ExamDetails.ExtraField1 = "";
            sTD_ExamDetails.ExtraField2 = "";
            sTD_ExamDetails.ExtraField3 = "";
            sTD_ExamDetails.ExtraField4 = "";
            sTD_ExamDetails.ExtraField5 = "";
            sTD_ExamDetails.AddedBy = Profile.card_id;
            sTD_ExamDetails.AddedDate = DateTime.Now;
            sTD_ExamDetails.UpdatedBy = Profile.card_id;
            sTD_ExamDetails.UpdatedDate = DateTime.Now;
            sTD_ExamDetails.RowStatusID = 1;
            sTD_ExamDetails.TotalMarks = decimal.Parse(ddlQuizExamID.SelectedItem.Text.Split('(')[1].Split('=')[1].Split(' ')[0]);//CAT - MA 2 - Set-1 (Marks=4 )
            sTD_ExamDetails.ExamDetailsID = STD_ExamDetailsManager.InsertSTD_ExamDetails(sTD_ExamDetails);

            foreach (GridViewRow gvr in gvStudents.Rows)
            {
                HiddenField hfStudentID = (HiddenField)gvr.FindControl("hfStudentID");
                
                int QuizExamID = int.Parse(ddlQuizExamID.SelectedValue);
                string ExamStudentName = ddlQuizExamID.SelectedItem.Text;
                
                if (!chkAllStudentSameExam.Checked)
                {
                    DropDownList ddlStudentQuizExamID = (DropDownList)gvr.FindControl("ddlStudentQuizExamID");

                    if (ddlStudentQuizExamID.SelectedIndex == 0)//jodi ddl selected na theke then o e student er nam e exam hobe na
                    {
                        continue;
                    }

                    QuizExamID = int.Parse(ddlStudentQuizExamID.SelectedValue);
                    ExamStudentName = ddlStudentQuizExamID.SelectedItem.Text;
                }

                Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent();
                //	quiz_ExamStudent.ExamStudentID=  int.Parse(ddlExamStudentID.SelectedValue);
                quiz_ExamStudent.ExamStudentName = ExamStudentName;
                quiz_ExamStudent.StudentID = hfStudentID.Value;
                quiz_ExamStudent.ClassSubjectID = int.Parse(ddlSubjectID.SelectedValue);
                quiz_ExamStudent.STDExamDetailsID = sTD_ExamDetails.ExamDetailsID;
                quiz_ExamStudent.QuizExamID = QuizExamID;
                quiz_ExamStudent.ExtraField1 = "";
                quiz_ExamStudent.ExtraField2 = "";
                quiz_ExamStudent.ExtraField3 = "";
                quiz_ExamStudent.ExtraField4 = "";
                quiz_ExamStudent.ExtraField5 = "";
                quiz_ExamStudent.AddedBy = Profile.card_id;
                quiz_ExamStudent.AddedDate = DateTime.Now;
                quiz_ExamStudent.UpdatedBy = Profile.card_id;
                quiz_ExamStudent.UpdateDate = DateTime.Now;
                quiz_ExamStudent.RowStatusID = 1;
                quiz_ExamStudent.ExamStudentID = Quiz_ExamStudentManager.InsertQuiz_ExamStudent(quiz_ExamStudent);
            }
        }

        catch(Exception ex)
        {
        }
    }

    

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //STD_Exam sTD_Exam = STD_ExamManager.GetSTD_ExamByExamID(int.Parse(Request.QueryString["ID"].ToString()));
            //sTD_Exam.ExamName = "Exam Of" + " " + ddlSubjectID.SelectedItem.Text + " " + "for" + " " + ddlClassID.SelectedItem.Text;
            //sTD_Exam.Description = txtDescription.Text;
            //sTD_Exam.ClassSubjectID = int.Parse(ddlSubjectID.SelectedValue);
            //sTD_Exam.ExamTypeID = int.Parse(ddlExamTypeID.SelectedValue);          
            //sTD_Exam.ExtraField1 = "";
            //sTD_Exam.ExtraField2 = "";
            //sTD_Exam.ExtraField3 = "";
            //sTD_Exam.ExtraField4 = "";
            //sTD_Exam.ExtraField5 = "";
            //sTD_Exam.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            //sTD_Exam.AddedDate = DateTime.Now;
            //sTD_Exam.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            //sTD_Exam.UpdatedDate = DateTime.Now;
            //sTD_Exam.RowStatusID = 1;
            //bool resutl = STD_ExamManager.UpdateSTD_Exam(sTD_Exam);
            //Response.Redirect("AdminDisplaySTD_Exam.aspx");
        }

        catch (Exception ex)
        {
        }
    }
	private void showSTD_ExamData()
	{
        try
        {
            //STD_Exam sTD_Exam = new STD_Exam();
            //sTD_Exam = STD_ExamManager.GetSTD_ExamByExamID(Int32.Parse(Request.QueryString["ID"]));

            //STD_ClassSubject classSubject = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassSubjectID(sTD_Exam.ClassSubjectID);

            //txtDescription.Text = sTD_Exam.Description.ToString();

            //ddlExamTypeID.SelectedValue = sTD_Exam.ExamTypeID.ToString();
           
            //ddlClassID.SelectedValue = classSubject.ClassID.ToString();
            //ddlSubjectID.SelectedValue = classSubject.ClassSubjectID.ToString();
            //ddlSubjectID.SelectedItem.Text = classSubject.SubjectName;
        }
        catch (Exception ex)
        {
        }
	}
	

    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadQuizExams();
        loadExams();
        
    }

    private void loadExams()
    {
        try
        {
            DataSet ds = STD_ExamManager.GetSTD_ClassSubjectByClassSubjectID(int.Parse(ddlSubjectID.SelectedValue), true);
            ddlSTDExamID.DataValueField = "ExamID";
            ddlSTDExamID.DataTextField = "ExamName";
            ddlSTDExamID.DataSource = ds.Tables[0];
            ddlSTDExamID.DataBind();
            ddlSTDExamID.Items.Insert(0, new ListItem("Select Exam >>", "0"));

            if (ds.Tables[0].Rows.Count > 0 && ddlQuizExamID.Items.Count >0)
            {
                btnAdd.Visible = true;
                chkAllStudentSameExam.Visible = true;
                lblQuizExam.Visible = true;
                    ddlQuizExamID.Visible = true;
                    gvStudents.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
                chkAllStudentSameExam.Visible = false;
                lblQuizExam.Visible = false;
                ddlQuizExamID.Visible = false;
                gvStudents.Visible = false;
            }
            chkAllStudentSameExam_CheckedChanged(this, new EventArgs());

            gvStudents.DataSource = ds.Tables[1];
            gvStudents.DataBind();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void loadQuizExams()
    {
        try
        {
            DataSet ds = STD_ExamManager.GetQuiz_ClassSubjectByClassSubjectID(int.Parse(ddlSubjectID.SelectedValue), true);
            
            ddlQuizExamID.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlQuizExamID.Items.Add(new ListItem(dr["ExamName"].ToString() + " (Marks=" + dr["NoOfQuestions"].ToString() + " )", dr["ExamID"].ToString()));
            }
            ddlQuizExamID.DataBind();


            if (ds.Tables[0].Rows.Count > 0)
            {
                btnAdd.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void chkAllStudentSameExam_CheckedChanged(object sender, EventArgs e)
    {
        gvStudents.Visible = !chkAllStudentSameExam.Checked;
        ddlQuizExamID.Visible = chkAllStudentSameExam.Checked;
        lblQuizExam.Visible = true;
    }
    protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlStudentQuizExamID = (DropDownList)e.Row.FindControl("ddlStudentQuizExamID");

            ddlStudentQuizExamID.Items.Clear();
            foreach (ListItem li in ddlQuizExamID.Items)
            {
                ddlStudentQuizExamID.Items.Add(li);
            }
            ddlStudentQuizExamID.DataBind();
        }
    }
}

