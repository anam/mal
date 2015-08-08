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
 public partial class AdminQuiz_TrueFalse : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
     {
         if (!IsPostBack)
         {
             
             //lblUserID.Text = u.ProviderUserKey.ToString();
             
             _loadCourse();
             _loadSubject(0);
             ChapterIDLoad(0, 0);

             if (Request.QueryString["ID"] != null)
             {
                 int ID = Int32.Parse(Request.QueryString["ID"]);
                 btnAdd.Visible = false;
                 btnUpdate.Visible = true;
                 showQuiz_TrueFalseData();
                 btnUpdate.Visible = true;
                 loadExamOrSetForthisQuestion();
             }
             if (Request.QueryString["TypeID"] != null)
             {
                 int TypeID = Int32.Parse(Request.QueryString["TypeID"]);
                 if (TypeID == 1)
                 {
                     radIsDrCr.SelectedIndex = 0;

                 }
                 else
                 {
                     radIsDrCr.SelectedIndex = 1;
                 }
             }

             gvExam.Visible = !ddlExamID.Visible; 
         }
     }


     private void loadExamOrSetForthisQuestion()
     {
         gvExam.DataSource = Quiz_ExamQuestionDetailsManager.GetQuiz_ExamQuestiondetailsByQuestionID(Int32.Parse(Request.QueryString["ID"]), Int32.Parse(Request.QueryString["TypeID"]));
         gvExam.DataBind();
     }

    private void _loadCourse()
    {
        try
        {
            DataSet ds = STD_CourseManager.GetDropDownListAllSTD_Course();
            ddlCourseID.DataValueField = "CourseID";
            ddlCourseID.DataTextField = "CourseName";
            ddlCourseID.DataSource = ds;
            ddlCourseID.DataBind();
            ddlCourseID.Items.Insert(0, new ListItem("...Select Course...", "0"));
        }
        catch (Exception ex)
        {
        }
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

    protected void ddlCourseID_SelectedIndexChanged(object sender, EventArgs e)
    {
        _loadSubject(Convert.ToInt32(ddlCourseID.SelectedValue));
    }

    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        ChapterIDLoad(courseID, subjectID);
        LoadExamSet(subjectID);
    }

    private void LoadExamSet(int subjectID)
    {
        try
        {
            DataSet ds = Quiz_ExamManager.GetHR_SubjectBySubjectID(subjectID);
            ddlExamID.DataValueField = "ExamID";
            ddlExamID.DataTextField = "ExamName";
            ddlExamID.DataSource = ds;
            ddlExamID.DataBind();
            ddlExamID.Items.Insert(0, new ListItem("...Select Exam/Set...", "0"));
        }
        catch (Exception ex)
        {
        }
    }

	protected void btnAdd_Click(object sender, EventArgs e)
		{
            try
            {
                string userID = Profile.card_id ;
                Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse();

                quiz_TrueFalse.ComprehensionID = 0;
                quiz_TrueFalse.CourseID = int.Parse(ddlCourseID.SelectedValue);
                quiz_TrueFalse.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                quiz_TrueFalse.ChapterID = int.Parse(ddlChapterID.SelectedValue);
                quiz_TrueFalse.QuestionTitle = fckDesc.Value;
                quiz_TrueFalse.IsDrCr = bool.Parse(radIsDrCr.SelectedValue);
                quiz_TrueFalse.IsTrue = bool.Parse(radIsTrue.SelectedValue);
                quiz_TrueFalse.AddedBy = userID;
                quiz_TrueFalse.AddedDate = DateTime.Now;
                quiz_TrueFalse.ModifiedBy = userID;
                quiz_TrueFalse.ModifiedDate = DateTime.Now;
                int trueFalseID = Quiz_TrueFalseManager.InsertQuiz_TrueFalse(quiz_TrueFalse);

                if (trueFalseID > 0)
                {
                    fckDesc.Value = "";
                    radIsTrue.SelectedIndex = -1;
                }

                if (ddlExamID.SelectedValue != "0")
                {
                    Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, int.Parse( ddlExamID.SelectedValue),(quiz_TrueFalse.IsDrCr? (int)Enums.QuestionTypes.DrCr:(int)Enums.QuestionTypes.TrueFalse),
                            trueFalseID,  Profile.card_id, DateTime.Now,  Profile.card_id, DateTime.Now);
                    Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
                }

            }
            catch (Exception ex)
            {
            }
	}

	protected void btnUpdate_Click(object sender, EventArgs e)
		{
            try
            {
                string userID = Profile.card_id;

                Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse();
                quiz_TrueFalse.TrueFalseID = int.Parse(Request.QueryString["ID"].ToString());
                quiz_TrueFalse.ComprehensionID = 0;
                quiz_TrueFalse.CourseID = int.Parse(ddlCourseID.SelectedValue);
                quiz_TrueFalse.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                quiz_TrueFalse.ChapterID = int.Parse(ddlChapterID.SelectedValue);
                quiz_TrueFalse.QuestionTitle = fckDesc.Value;
                quiz_TrueFalse.IsDrCr = bool.Parse(radIsDrCr.SelectedValue);
                quiz_TrueFalse.IsTrue = bool.Parse(radIsTrue.SelectedValue);
                quiz_TrueFalse.AddedBy = userID;
                quiz_TrueFalse.AddedDate = DateTime.Now;
                quiz_TrueFalse.ModifiedBy = userID;
                quiz_TrueFalse.ModifiedDate = DateTime.Now;
                bool resutl = Quiz_TrueFalseManager.UpdateQuiz_TrueFalse(quiz_TrueFalse);

                //if (quiz_TrueFalse.IsDrCr)
                //    Response.Redirect("AdminDisplayQuiz_DrCr.aspx");
                //else
                //    Response.Redirect("AdminDisplayQuiz_TrueFalse.aspx");
                Response.Redirect("ExamOrSetBuilder.aspx");
            }
            catch (Exception ex)
            {
            }
	}

	private void showQuiz_TrueFalseData()
	{
        try
        {
            Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse();
            quiz_TrueFalse = Quiz_TrueFalseManager.GetQuiz_TrueFalseByTrueFalseID(Int32.Parse(Request.QueryString["ID"]));
            ddlCourseID.SelectedValue = quiz_TrueFalse.CourseID.ToString();
            _loadSubject(quiz_TrueFalse.CourseID);
            ddlSubjectID.SelectedValue = quiz_TrueFalse.SubjectID.ToString();
            ChapterIDLoad(quiz_TrueFalse.CourseID, quiz_TrueFalse.SubjectID);
            ddlChapterID.SelectedValue = quiz_TrueFalse.ChapterID.ToString();
            fckDesc.Value = quiz_TrueFalse.QuestionTitle.ToString();
            radIsDrCr.SelectedValue = quiz_TrueFalse.IsDrCr.ToString();
            radIsTrue.SelectedValue = quiz_TrueFalse.IsTrue.ToString();

            ddlExamID.Enabled = false;
        }
        catch (Exception ex)
        {
        }
	}
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Quiz_TrueFalseManager.DeleteQuiz_TrueFalse(Convert.ToInt32(Request.QueryString["ID"]));
        Response.Redirect("ExamOrSetBuilder.aspx");
    
    }

    protected void btnAssignQuestionToExam_Click(object sender, EventArgs e)
    {
        if (ddlAllExam.SelectedValue != "0")
        {
            Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, int.Parse(ddlAllExam.SelectedValue), Int32.Parse(Request.QueryString["TypeID"]),
                    int.Parse(Request.QueryString["ID"].ToString()), Profile.card_id, DateTime.Now, Profile.card_id, DateTime.Now);
            Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
        }
    }
}

