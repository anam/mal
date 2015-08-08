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
 public partial class AdminQuiz_Exam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadQuiz_ExamData();
         		CourseIDLoad();
        //SubjectIDLoad();
        //ChapterIDLoad();

                _loadExamDuration();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showQuiz_ExamData();
                }
        }
    }
    private void _loadExamDuration()
    {
        try
        {
            for (int i = 0; i < 4; i++)
            {
                ddlExamHour.Items.Add(new ListItem(i.ToString("00"), i.ToString()));
            }

            for (int i = 0; i < 60; i += 5)
            {
                ddlExamMin.Items.Add(new ListItem(i.ToString("00"), i.ToString()));
            }
        }
        catch (Exception ex)
        {
        }
    }

	protected void btnAdd_Click(object sender, EventArgs e)
		{

           int examDuration = Convert.ToInt32(ddlExamHour.SelectedValue) * 60 + Convert.ToInt32(ddlExamMin.SelectedValue);
            if (examDuration == 0)
                examDuration = 120;
            DateTime examStartTime = DateTime.Now;
            bool isRetake = false;// cbIsRetake.Checked;
            int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
            int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
            int chapterID = 0;      // Convert.ToInt32(ddlChapterID.SelectedValue);

            Quiz_Exam qe = new Quiz_Exam(0, ddlCourseID.SelectedItem.Text + " - " + ddlSubjectID.SelectedItem.Text + " - " + txtExamName.Text, courseID, subjectID, chapterID, examDuration, examStartTime,
                        isRetake, true, Profile.card_id.ToString(), DateTime.Now, Profile.card_id, DateTime.Now);
            int examID = Quiz_ExamManager.InsertQuiz_Exam(qe);

//    Quiz_Exam quiz_Exam = new Quiz_Exam ();
////	quiz_Exam.ExamID=  int.Parse(ddlExamID.SelectedValue);
//    quiz_Exam.ExamName=  txtExamName.Text;
//    quiz_Exam.CourseID=  int.Parse(ddlCourseID.SelectedValue);
//    quiz_Exam.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
//    quiz_Exam.ChapterID=  int.Parse(ddlChapterID.SelectedValue);
//    quiz_Exam.ExamTimeDuration=  int.Parse(txtExamTimeDuration.Text);
//    quiz_Exam.ExamStartTime=   DateTime.Parse(txtExamStartTime.Text);
//    quiz_Exam.IsRetake=  bool.Parse( radIsRetake.SelectedValue);
//    quiz_Exam.IsActive=  bool.Parse( radIsActive.SelectedValue);
//    quiz_Exam.AddedBy=  txtAddedBy.Text;
//    quiz_Exam.AddedDate=  DateTime.Now;
//    quiz_Exam.ModifiedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
//    quiz_Exam.ModifiedDate=  DateTime.Now;
//    int resutl =Quiz_ExamManager.InsertQuiz_Exam(quiz_Exam);
	Response.Redirect("AdminDisplayQuiz_Exam.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	Quiz_Exam quiz_Exam = new Quiz_Exam ();
    quiz_Exam = Quiz_ExamManager.GetQuiz_ExamByExamID(Int32.Parse(Request.QueryString["ID"]));
	quiz_Exam.ExamName=  txtExamName.Text;
	quiz_Exam.CourseID=  int.Parse(ddlCourseID.SelectedValue);
	quiz_Exam.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	quiz_Exam.ChapterID=  int.Parse(ddlChapterID.SelectedValue);
	quiz_Exam.ModifiedBy= Profile.card_id;
	quiz_Exam.ModifiedDate=  DateTime.Now;
    int examDuration = Convert.ToInt32(ddlExamHour.SelectedValue) * 60 + Convert.ToInt32(ddlExamMin.SelectedValue);
    if (examDuration == 0)
        examDuration = 120;

    quiz_Exam.ExamTimeDuration = examDuration;

	bool  resutl =Quiz_ExamManager.UpdateQuiz_Exam(quiz_Exam);
	Response.Redirect("AdminDisplayQuiz_Exam.aspx");
	}
	private void showQuiz_ExamData()
	{
	 	Quiz_Exam quiz_Exam  = new Quiz_Exam ();
	 	quiz_Exam = Quiz_ExamManager.GetQuiz_ExamByExamID(Int32.Parse(Request.QueryString["ID"]));
	 	txtExamName.Text =quiz_Exam.ExamName.ToString();
	 	ddlCourseID.SelectedValue  =quiz_Exam.CourseID.ToString();
        ddlCourseID_SelectedIndexChanged(this, new EventArgs());
        ddlSubjectID.SelectedValue = quiz_Exam.SubjectID.ToString();
        ddlSubjectID_SelectedIndexChanged(this, new EventArgs());
	 	ddlChapterID.SelectedValue  =quiz_Exam.ChapterID.ToString();


        ddlExamHour.SelectedValue = (quiz_Exam.ExamTimeDuration / 60).ToString();
        ddlExamMin.SelectedValue = (quiz_Exam.ExamTimeDuration % 60).ToString();
	}

    protected void ddlCourseID_SelectedIndexChanged(object sender, EventArgs e)
    {
        _loadSubject(Convert.ToInt32(ddlCourseID.SelectedValue));
    }

    private void _loadSubject(int courseID)
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_SubjectGeneral(courseID);
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds;
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("...Select Subject...", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void ChapterIDLoad(int courseID, int subjectID)
    {
        try
        {
            if (courseID > 0 && subjectID > 0)
            {
                DataSet ds = Quiz_ChapterManager.GetDropDownListAllQuiz_Chapter(courseID, subjectID);
                ddlChapterID.DataValueField = "ChapterID";
                ddlChapterID.DataTextField = "ChapterName";
                ddlChapterID.DataSource = ds.Tables[0];
                ddlChapterID.DataBind();
            }
            ddlChapterID.Items.Insert(0, new ListItem("...Select Chapter...", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        ChapterIDLoad(courseID, subjectID);
    }

	private void CourseIDLoad()
	{
		try {
            DataSet ds = STD_CourseManager.GetDropDownListAllSTD_Course();
            ddlCourseID.DataValueField = "CourseID";
		ddlCourseID.DataTextField = "CourseName";
		ddlCourseID.DataSource = ds.Tables[0];
		ddlCourseID.DataBind();
		ddlCourseID.Items.Insert(0, new ListItem("Select Course >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
    //private void SubjectIDLoad()
    //{
    //    try {
    //    DataSet ds = Quiz_SubjectManager.GetDropDownListAllQuiz_Subject();
    //    ddlSubjectID.DataValueField = "SubjectID";
    //    ddlSubjectID.DataTextField = "SubjectName";
    //    ddlSubjectID.DataSource = ds.Tables[0];
    //    ddlSubjectID.DataBind();
    //    ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
    //    }
    //    catch (Exception ex) {
    //    ex.Message.ToString();
    //    }
    // }
    //private void ChapterIDLoad()
    //{
    //    try {
    //    DataSet ds = Quiz_ChapterManager.GetDropDownListAllQuiz_Chapter();
    //    ddlChapterID.DataValueField = "ChapterID";
    //    ddlChapterID.DataTextField = "ChapterName";
    //    ddlChapterID.DataSource = ds.Tables[0];
    //    ddlChapterID.DataBind();
    //    ddlChapterID.Items.Insert(0, new ListItem("Select Chapter >>", "0"));
    //    }
    //    catch (Exception ex) {
    //    ex.Message.ToString();
    //    }
    // }
}

