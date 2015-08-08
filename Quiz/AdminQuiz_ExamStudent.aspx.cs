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
 public partial class AdminQuiz_ExamStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadQuiz_ExamStudentData();
         		StudentIDLoad();
		ClassSubjectIDLoad();
		STDExamDetailsIDLoad();
		QuizExamIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showQuiz_ExamStudentData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent ();
//	quiz_ExamStudent.ExamStudentID=  int.Parse(ddlExamStudentID.SelectedValue);
	quiz_ExamStudent.ExamStudentName=  txtExamStudentName.Text;
	quiz_ExamStudent.StudentID=  ddlStudentID.SelectedValue;
	quiz_ExamStudent.ClassSubjectID=  int.Parse(ddlClassSubjectID.SelectedValue);
	quiz_ExamStudent.STDExamDetailsID=  int.Parse(ddlSTDExamDetailsID.SelectedValue);
	quiz_ExamStudent.QuizExamID=  int.Parse(ddlQuizExamID.SelectedValue);
	quiz_ExamStudent.ExtraField1=  txtExtraField1.Text;
	quiz_ExamStudent.ExtraField2=  txtExtraField2.Text;
	quiz_ExamStudent.ExtraField3=  txtExtraField3.Text;
	quiz_ExamStudent.ExtraField4=  txtExtraField4.Text;
	quiz_ExamStudent.ExtraField5=  txtExtraField5.Text;
	quiz_ExamStudent.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	quiz_ExamStudent.AddedDate=  DateTime.Now;
	quiz_ExamStudent.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	quiz_ExamStudent.UpdateDate=  DateTime.Now;
	quiz_ExamStudent.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =Quiz_ExamStudentManager.InsertQuiz_ExamStudent(quiz_ExamStudent);
	Response.Redirect("AdminDisplayQuiz_ExamStudent.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent ();
	quiz_ExamStudent.ExamStudentID=  int.Parse(Request.QueryString["ID"].ToString());
	quiz_ExamStudent.ExamStudentName=  txtExamStudentName.Text;
	quiz_ExamStudent.StudentID=  ddlStudentID.SelectedValue;
	quiz_ExamStudent.ClassSubjectID=  int.Parse(ddlClassSubjectID.SelectedValue);
	quiz_ExamStudent.STDExamDetailsID=  int.Parse(ddlSTDExamDetailsID.SelectedValue);
	quiz_ExamStudent.QuizExamID=  int.Parse(ddlQuizExamID.SelectedValue);
	quiz_ExamStudent.ExtraField1=  txtExtraField1.Text;
	quiz_ExamStudent.ExtraField2=  txtExtraField2.Text;
	quiz_ExamStudent.ExtraField3=  txtExtraField3.Text;
	quiz_ExamStudent.ExtraField4=  txtExtraField4.Text;
	quiz_ExamStudent.ExtraField5=  txtExtraField5.Text;
	quiz_ExamStudent.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	quiz_ExamStudent.AddedDate=  DateTime.Now;
	quiz_ExamStudent.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	quiz_ExamStudent.UpdateDate=  DateTime.Now;
	quiz_ExamStudent.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =Quiz_ExamStudentManager.UpdateQuiz_ExamStudent(quiz_ExamStudent);
	Response.Redirect("AdminDisplayQuiz_ExamStudent.aspx");
	}
	private void showQuiz_ExamStudentData()
	{
	 	Quiz_ExamStudent quiz_ExamStudent  = new Quiz_ExamStudent ();
	 	quiz_ExamStudent = Quiz_ExamStudentManager.GetQuiz_ExamStudentByExamStudentID(Int32.Parse(Request.QueryString["ID"]));
	 	txtExamStudentName.Text =quiz_ExamStudent.ExamStudentName.ToString();
	 	ddlStudentID.SelectedValue  =quiz_ExamStudent.StudentID.ToString();
	 	ddlClassSubjectID.SelectedValue  =quiz_ExamStudent.ClassSubjectID.ToString();
	 	ddlSTDExamDetailsID.SelectedValue  =quiz_ExamStudent.STDExamDetailsID.ToString();
	 	ddlQuizExamID.SelectedValue  =quiz_ExamStudent.QuizExamID.ToString();
	 	txtExtraField1.Text =quiz_ExamStudent.ExtraField1.ToString();
	 	txtExtraField2.Text =quiz_ExamStudent.ExtraField2.ToString();
	 	txtExtraField3.Text =quiz_ExamStudent.ExtraField3.ToString();
	 	txtExtraField4.Text =quiz_ExamStudent.ExtraField4.ToString();
	 	txtExtraField5.Text =quiz_ExamStudent.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =quiz_ExamStudent.RowStatusID.ToString();
	}
	
	private void StudentIDLoad()
	{
		try {
		DataSet ds = Quiz_StudentManager.GetDropDownListAllQuiz_Student();
		ddlStudentID.DataValueField = "StudentID";
		ddlStudentID.DataTextField = "StudentName";
		ddlStudentID.DataSource = ds.Tables[0];
		ddlStudentID.DataBind();
		ddlStudentID.Items.Insert(0, new ListItem("Select Student >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void ClassSubjectIDLoad()
	{
		try {
		DataSet ds = Quiz_ClassSubjectManager.GetDropDownListAllQuiz_ClassSubject();
		ddlClassSubjectID.DataValueField = "ClassSubjectID";
		ddlClassSubjectID.DataTextField = "ClassSubjectName";
		ddlClassSubjectID.DataSource = ds.Tables[0];
		ddlClassSubjectID.DataBind();
		ddlClassSubjectID.Items.Insert(0, new ListItem("Select ClassSubject >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void STDExamDetailsIDLoad()
	{
		try {
		DataSet ds = Quiz_STDExamDetailsManager.GetDropDownListAllQuiz_STDExamDetails();
		ddlSTDExamDetailsID.DataValueField = "STDExamDetailsID";
		ddlSTDExamDetailsID.DataTextField = "STDExamDetailsName";
		ddlSTDExamDetailsID.DataSource = ds.Tables[0];
		ddlSTDExamDetailsID.DataBind();
		ddlSTDExamDetailsID.Items.Insert(0, new ListItem("Select STDExamDetails >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void QuizExamIDLoad()
	{
		try {
		DataSet ds = Quiz_QuizExamManager.GetDropDownListAllQuiz_QuizExam();
		ddlQuizExamID.DataValueField = "QuizExamID";
		ddlQuizExamID.DataTextField = "QuizExamName";
		ddlQuizExamID.DataSource = ds.Tables[0];
		ddlQuizExamID.DataBind();
		ddlQuizExamID.Items.Insert(0, new ListItem("Select QuizExam >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = Quiz_RowStatusManager.GetDropDownListAllQuiz_RowStatus();
		ddlRowStatusID.DataValueField = "RowStatusID";
		ddlRowStatusID.DataTextField = "RowStatusName";
		ddlRowStatusID.DataSource = ds.Tables[0];
		ddlRowStatusID.DataBind();
		ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

