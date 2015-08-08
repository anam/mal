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
 public partial class AdminQuiz_FillInTheBlanks : System.Web.UI.Page
 {
     //private static List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();
     //private static List<int> deletedDtlID = new List<int>();
     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadCourse();
                _loadSubject(0);
                ChapterIDLoad(0, 0);
                if (Request.QueryString["ID"] != null)
                {
                    int ID = Int32.Parse(Request.QueryString["ID"]);
                    showQuiz_FillInTheBlanksData();
                    ddlExamID.Visible = false;
                    lblExamOrSet.Visible = false;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    loadExamOrSetForthisQuestion();
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }

                gvExam.Visible = !ddlExamID.Visible; 
            }
        }
     private void loadExamOrSetForthisQuestion()
     {
         gvExam.DataSource = Quiz_ExamQuestionDetailsManager.GetQuiz_ExamQuestiondetailsByQuestionID(Int32.Parse(Request.QueryString["ID"]), (int)Enums.QuestionTypes.FillInTheBlanks);
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


            ddlAllExam.DataValueField = "ExamID";
            ddlAllExam.DataTextField = "ExamName";
            ddlAllExam.DataSource = ds;
            ddlAllExam.DataBind();
            ddlAllExam.Items.Insert(0, new ListItem("...Select Exam/Set...", "0"));
        }
        catch (Exception ex)
        {
        }
    }
         
	private void showQuiz_FillInTheBlanksData()
	{
        try
        {
            List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();

            Quiz_FillInTheBlanks quiz_FillInTheBlanks = new Quiz_FillInTheBlanks();
            quiz_FillInTheBlanks = Quiz_FillInTheBlanksManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(Int32.Parse(Request.QueryString["ID"]));

            _loadSubject(quiz_FillInTheBlanks.CourseID);

            ChapterIDLoad(quiz_FillInTheBlanks.CourseID, quiz_FillInTheBlanks.SubjectID);
            

            fckDesc.Value= quiz_FillInTheBlanks.Question.ToString();
            ddlCourseID.SelectedValue = quiz_FillInTheBlanks.CourseID.ToString();
            ddlSubjectID.SelectedValue = quiz_FillInTheBlanks.SubjectID.ToString();
            ddlSubjectID_SelectedIndexChanged(this, new EventArgs());
            ddlChapterID.SelectedValue = quiz_FillInTheBlanks.ChapterID.ToString();

            DataSet ds = Quiz_FillInTheBlanksDetailsManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(quiz_FillInTheBlanks.FillInTheBlanksID);
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Quiz_FillInTheBlanksDetails fitbDetails = new Quiz_FillInTheBlanksDetails();
                fitbDetails.FillInTheBlanksDetailsID = Convert.ToInt32(dr["FillInTheBlanksDetailsID"].ToString());
                fitbDetails.FillInTheBlanksID = Convert.ToInt32(dr["FillInTheBlanksID"].ToString());
                fitbDetails.QuestionSl = Convert.ToInt32(dr["QuestionSl"].ToString());
                fitbDetails.Answer = dr["Answer"].ToString();
                fitbDetails.AddedBy = dr["AddedBy"].ToString();
                fitbDetails.AddedDate =Convert.ToDateTime(dr["AddedDate"].ToString());
                fitbDetails.ModifiedBy = dr["ModifiedBy"].ToString();
                fitbDetails.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"].ToString());

                fillInTheBlanksDetails.Add(fitbDetails);
            }

            Session["fillInTheBlanksDetails"] = fillInTheBlanksDetails;

            gvQuiz_FillInTheBlanksQuestionDetails.DataSource = Session["fillInTheBlanksDetails"];
            gvQuiz_FillInTheBlanksQuestionDetails.DataBind();
        }
        catch (Exception ex)
        {
        }
	}
	
    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["fillInTheBlanksDetails"] == null)
            {
                List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();

                Quiz_FillInTheBlanksDetails fillInTheBlanksDetail = new Quiz_FillInTheBlanksDetails();

                fillInTheBlanksDetail.FillInTheBlanksDetailsID = 0;
                fillInTheBlanksDetail.Answer = txtAnswer.Text;

                fillInTheBlanksDetails.Add(fillInTheBlanksDetail);

                Session["fillInTheBlanksDetails"] = fillInTheBlanksDetails;

                gvQuiz_FillInTheBlanksQuestionDetails.DataSource = Session["fillInTheBlanksDetails"];
                gvQuiz_FillInTheBlanksQuestionDetails.DataBind();

                txtAnswer.Text = "";
            }
            else
            {
               

                Quiz_FillInTheBlanksDetails fillInTheBlanksDetail = new Quiz_FillInTheBlanksDetails();

                fillInTheBlanksDetail.FillInTheBlanksDetailsID = 0;
                fillInTheBlanksDetail.Answer = txtAnswer.Text;

                
                ((List<Quiz_FillInTheBlanksDetails>)Session["fillInTheBlanksDetails"]).Add(fillInTheBlanksDetail);
                

                gvQuiz_FillInTheBlanksQuestionDetails.DataSource = Session["fillInTheBlanksDetails"];
                gvQuiz_FillInTheBlanksQuestionDetails.DataBind();

                txtAnswer.Text ="";
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        try
        {
            List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();
            fillInTheBlanksDetails = (List<Quiz_FillInTheBlanksDetails>)Session["fillInTheBlanksDetails"];


            List<int> deletedDtlID = new List<int>();

            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;


            int index = Convert.ToInt32(linkButton.CommandArgument);
            int fitbDtlID = Convert.ToInt32(((HiddenField)gvQuiz_FillInTheBlanksQuestionDetails.Rows[index].FindControl("hfFitbDtlID")).Value);

            fillInTheBlanksDetails.RemoveAt(index);
            if (fitbDtlID > 0)
            {
                if (Session["deletedDtlID"] == null)
                {
                    deletedDtlID.Add(fitbDtlID);
                    Session["deletedDtlID"] = deletedDtlID;
                }
                else
                    ((List<int>)Session["deletedDtlID"]).Add(fitbDtlID);
            }

            Session["fillInTheBlanksDetails"] = fillInTheBlanksDetails;

            gvQuiz_FillInTheBlanksQuestionDetails.DataSource = Session["fillInTheBlanksDetails"];
            gvQuiz_FillInTheBlanksQuestionDetails.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
     
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();
            fillInTheBlanksDetails = (List<Quiz_FillInTheBlanksDetails>)Session["fillInTheBlanksDetails"];

            string userID = Profile.card_id;
            Quiz_FillInTheBlanks fillInTheBlanks = new Quiz_FillInTheBlanks();
            fillInTheBlanks.Question = fckDesc.Value;
            fillInTheBlanks.ChapterID = int.Parse(ddlChapterID.SelectedValue);
            fillInTheBlanks.CourseID = int.Parse(ddlCourseID.SelectedValue);
            fillInTheBlanks.ComprehensionID = 0;
            fillInTheBlanks.SubjectID = int.Parse(ddlSubjectID.SelectedValue);

            fillInTheBlanks.AddedBy = userID;
            fillInTheBlanks.AddedDate = DateTime.Now;
            fillInTheBlanks.ModifiedBy = userID;
            fillInTheBlanks.ModifiedDate = DateTime.Now;
            int FillInTheBlanksID = Quiz_FillInTheBlanksManager.InsertQuiz_FillInTheBlanks(fillInTheBlanks);

            if (fillInTheBlanksDetails != null)
            {
                for (int i = 0; i < fillInTheBlanksDetails.Count; i++)
                {


                    Label lblSerial = ((Label)gvQuiz_FillInTheBlanksQuestionDetails.Rows[i].FindControl("lblSerial"));
                    TextBox txtanswer = ((TextBox)gvQuiz_FillInTheBlanksQuestionDetails.Rows[i].FindControl("txtAnswer"));

                    Quiz_FillInTheBlanksDetails fillInTheBlanksDtl = new Quiz_FillInTheBlanksDetails();
                    //	quiz_MultipleQuestionDetails.MultipleQuestionDetailsID=  int.Parse(ddlMultipleQuestionDetailsID.SelectedValue);
                    fillInTheBlanksDtl.FillInTheBlanksID = FillInTheBlanksID;
                    fillInTheBlanksDtl.QuestionSl = int.Parse(lblSerial.Text);
                    fillInTheBlanksDtl.Answer = txtanswer.Text;


                    fillInTheBlanksDtl.AddedBy = userID;
                    fillInTheBlanksDtl.AddedDate = DateTime.Now;
                    fillInTheBlanksDtl.ModifiedBy = userID;
                    fillInTheBlanksDtl.ModifiedDate = DateTime.Now;
                    int resutl = Quiz_FillInTheBlanksDetailsManager.InsertQuiz_FillInTheBlanksDetails(fillInTheBlanksDtl);
                }
            }

            if (txtAnswer.Text != "")
            {
                Quiz_FillInTheBlanksDetails fillInTheBlanksDtl = new Quiz_FillInTheBlanksDetails();
                //	quiz_MultipleQuestionDetails.MultipleQuestionDetailsID=  int.Parse(ddlMultipleQuestionDetailsID.SelectedValue);
                fillInTheBlanksDtl.FillInTheBlanksID = FillInTheBlanksID;
                fillInTheBlanksDtl.QuestionSl = 1;
                fillInTheBlanksDtl.Answer = txtAnswer.Text;


                fillInTheBlanksDtl.AddedBy = userID;
                fillInTheBlanksDtl.AddedDate = DateTime.Now;
                fillInTheBlanksDtl.ModifiedBy = userID;
                fillInTheBlanksDtl.ModifiedDate = DateTime.Now;
                int resutl = Quiz_FillInTheBlanksDetailsManager.InsertQuiz_FillInTheBlanksDetails(fillInTheBlanksDtl);
            }

            fckDesc.Value = string.Empty;
            txtAnswer.Text = string.Empty;

            fillInTheBlanksDetails.Clear();
            Session["fillInTheBlanksDetails"] = null;

            gvQuiz_FillInTheBlanksQuestionDetails.DataSource = fillInTheBlanksDetails;
            gvQuiz_FillInTheBlanksQuestionDetails.DataBind();


            if (ddlExamID.SelectedValue != "0")
            {
                Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, int.Parse(ddlExamID.SelectedValue), (int)Enums.QuestionTypes.FillInTheBlanks,
                        FillInTheBlanksID,  Profile.card_id, DateTime.Now,  Profile.card_id, DateTime.Now);
                Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
            }
        }
        catch (Exception ex)
        {
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();
        fillInTheBlanksDetails = (List<Quiz_FillInTheBlanksDetails>)Session["fillInTheBlanksDetails"];

        string userID = Profile.card_id;

        int fillInTheBlankID = int.Parse(Request.QueryString["ID"].ToString());
        Quiz_FillInTheBlanks quiz_FillInTheBlanks = Quiz_FillInTheBlanksManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(fillInTheBlankID);

        quiz_FillInTheBlanks.Question = fckDesc.Value;
        quiz_FillInTheBlanks.CourseID = int.Parse(ddlCourseID.SelectedValue);
        quiz_FillInTheBlanks.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
        quiz_FillInTheBlanks.ChapterID = int.Parse(ddlChapterID.SelectedValue);

        quiz_FillInTheBlanks.ModifiedBy = userID;
        quiz_FillInTheBlanks.ModifiedDate = DateTime.Now;
        bool resutl = Quiz_FillInTheBlanksManager.UpdateQuiz_FillInTheBlanks(quiz_FillInTheBlanks);
        if (resutl)
        {
            #region Fill In The BlankDetails Insert/Update
            foreach (GridViewRow row in gvQuiz_FillInTheBlanksQuestionDetails.Rows)
            {
                int fitbDtlID = Convert.ToInt32(((HiddenField)row.FindControl("hfFitbDtlID")).Value);
                Label lblSerial = ((Label)row.FindControl("lblSerial"));
                TextBox txtanswer = ((TextBox)row.FindControl("txtAnswer"));
                
                Quiz_FillInTheBlanksDetails fillInTheBlanksDtl = new Quiz_FillInTheBlanksDetails();


                if (fitbDtlID > 0)
                {
                    //quiz_MultipleQuestionDetails.MultipleQuestionDetailsID=  int.Parse(ddlMultipleQuestionDetailsID.SelectedValue);
                    //fillInTheBlanksDtl.FillInTheBlanksID = FillInTheBlanksID;
                    fillInTheBlanksDtl = fillInTheBlanksDetails.Find(X => X.FillInTheBlanksDetailsID == fitbDtlID);

                    fillInTheBlanksDtl.QuestionSl = int.Parse(lblSerial.Text);
                    fillInTheBlanksDtl.Answer = txtanswer.Text;
                    fillInTheBlanksDtl.ModifiedBy = userID;
                    fillInTheBlanksDtl.ModifiedDate = DateTime.Now;
                    Quiz_FillInTheBlanksDetailsManager.UpdateQuiz_FillInTheBlanksDetails(fillInTheBlanksDtl);
                }
                else
                {
                    fillInTheBlanksDtl.FillInTheBlanksDetailsID = 0;
                    fillInTheBlanksDtl.FillInTheBlanksID = fillInTheBlankID;
                    fillInTheBlanksDtl.QuestionSl = int.Parse(lblSerial.Text);
                    fillInTheBlanksDtl.Answer = txtanswer.Text;
                    fillInTheBlanksDtl.AddedBy = userID;
                    fillInTheBlanksDtl.AddedDate = DateTime.Now;
                    fillInTheBlanksDtl.ModifiedBy = userID;
                    fillInTheBlanksDtl.ModifiedDate = DateTime.Now;
                    Quiz_FillInTheBlanksDetailsManager.InsertQuiz_FillInTheBlanksDetails(fillInTheBlanksDtl);
                }

            }

            if (txtAnswer.Text != "")
            {
                Quiz_FillInTheBlanksDetails fillInTheBlanksDtl = new Quiz_FillInTheBlanksDetails();
                fillInTheBlanksDtl.FillInTheBlanksDetailsID = 0;
                fillInTheBlanksDtl.FillInTheBlanksID = fillInTheBlankID;
                fillInTheBlanksDtl.QuestionSl = 1;
                fillInTheBlanksDtl.Answer = txtAnswer.Text;
                fillInTheBlanksDtl.AddedBy = userID;
                fillInTheBlanksDtl.AddedDate = DateTime.Now;
                fillInTheBlanksDtl.ModifiedBy = userID;
                fillInTheBlanksDtl.ModifiedDate = DateTime.Now;
                Quiz_FillInTheBlanksDetailsManager.InsertQuiz_FillInTheBlanksDetails(fillInTheBlanksDtl);
            }
            #endregion

            #region Remove Deleted Answer from DB
            List<int> deletedDtlID = new List<int>();
            if (Session["deletedDtlID"] != null)
            {
                deletedDtlID = (List<int>)Session["deletedDtlID"];

                foreach (int fitbDtlID in deletedDtlID)
                {
                    Quiz_FillInTheBlanksDetailsManager.DeleteQuiz_FillInTheBlanksDetails(fitbDtlID);
                }
               
            }
            #endregion
        }

        fillInTheBlanksDetails.Clear();
        Session["deletedDtlID"] = null;
        Session["fillInTheBlanksDetails"] = null;

        //Response.Redirect("AdminDisplayQuiz_FillInTheBlanks.aspx");
        Response.Redirect("ExamOrSetBuilder.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Quiz_FillInTheBlanksManager.DeleteQuiz_FillInTheBlanks(Convert.ToInt32(Request.QueryString["ID"]));
        Response.Redirect("ExamOrSetBuilder.aspx");
    }

    protected void btnAssignQuestionToExam_Click(object sender, EventArgs e)
    {
        if (ddlAllExam.SelectedValue != "0")
        {
            Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, int.Parse(ddlAllExam.SelectedValue), (int)Enums.QuestionTypes.FillInTheBlanks,
                    int.Parse(Request.QueryString["ID"].ToString()), Profile.card_id, DateTime.Now, Profile.card_id, DateTime.Now);
            Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
        }
    }
}

