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
 public partial class AdminQuiz_MultipleQuestion : System.Web.UI.Page
{
    //     private static List<HR_PackageRules> ListPackageRules = new List<HR_PackageRules>();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["multipleQuestions"] = null;
            Session["deletedDtlID"] = null;

            _loadCourse();
            _loadSubject(0);
            ChapterIDLoad(0,0);

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showQuiz_MultipleQuestionData();
                ddlExamID.Visible = false;
                lblExamOrSet.Visible = false;
                loadExamOrSetForthisQuestion();
            }
            else
            {
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
            }

            gvExam.Visible = !ddlExamID.Visible; 
        }
    }

    private void loadExamOrSetForthisQuestion()
    {
        gvExam.DataSource= Quiz_ExamQuestionDetailsManager.GetQuiz_ExamQuestiondetailsByQuestionID(Int32.Parse(Request.QueryString["ID"]), (int)Enums.QuestionTypes.MCQ);
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
         

    
     
	private void showQuiz_MultipleQuestionData()
	{
        try
        {
            List<Quiz_MultipleQuestionDetails> multipleQuestions = new List<Quiz_MultipleQuestionDetails>();

            Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion();
            quiz_MultipleQuestion = Quiz_MultipleQuestionManager.GetQuiz_MultipleQuestionByMultipleQustionID(Int32.Parse(Request.QueryString["ID"]));
            ddlCourseID.SelectedValue = quiz_MultipleQuestion.CourseID.ToString();
            ddlCourseID_SelectedIndexChanged(new Object(), new EventArgs());
            ddlSubjectID.SelectedValue = quiz_MultipleQuestion.SubjectID.ToString();
            ddlSubjectID_SelectedIndexChanged(new Object(), new EventArgs());
            ddlChapterID.SelectedValue = quiz_MultipleQuestion.ChapterID.ToString();
            fckDesc.Value= quiz_MultipleQuestion.MultipleQuestionName.ToString();

            DataSet ds = Quiz_MultipleQuestionDetailsManager.GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID(quiz_MultipleQuestion.MultipleQustionID);
           
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Quiz_MultipleQuestionDetails mcqDetail = new Quiz_MultipleQuestionDetails();
                mcqDetail.MultipleQuestionDetailsID = Convert.ToInt32(dr["MultipleQuestionDetailsID"].ToString());
                mcqDetail.MultipleQustionID = Convert.ToInt32(dr["MultipleQustionID"].ToString());
                mcqDetail.QuestionTitle = dr["QuestionTitle"].ToString();
                mcqDetail.IsAnswer = bool.Parse(dr["IsAnswer"].ToString());
                mcqDetail.AddedBy = dr["AddedBy"].ToString();
                mcqDetail.AddedDate = Convert.ToDateTime(dr["AddedDate"].ToString());
                mcqDetail.ModifiedBy = dr["ModifiedBy"].ToString();
                mcqDetail.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"].ToString());

                multipleQuestions.Add(mcqDetail);
            }

            Session["multipleQuestions"] = multipleQuestions;

            gvQuiz_MultipleQuestionDetails.DataSource = Session["multipleQuestions"];
            gvQuiz_MultipleQuestionDetails.DataBind();
        }
        catch (Exception ex)
        {
        }
	}
	
    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["multipleQuestions"] == null)
            {
                List<Quiz_MultipleQuestionDetails> multipleQuestions = new List<Quiz_MultipleQuestionDetails>();

                Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails = new Quiz_MultipleQuestionDetails();


                quiz_MultipleQuestionDetails.QuestionTitle = txtQuestionTitle.Text;
                quiz_MultipleQuestionDetails.IsAnswer = radIsAnswer.SelectedValue == "True" ? true : false;

                quiz_MultipleQuestionDetails.MultipleQuestionDetailsID = 0;
                multipleQuestions.Add(quiz_MultipleQuestionDetails);
                Session["multipleQuestions"] = multipleQuestions;

                txtQuestionTitle.Text = "";

                radIsAnswer.SelectedIndex = -1;

                gvQuiz_MultipleQuestionDetails.DataSource = Session["multipleQuestions"];
                gvQuiz_MultipleQuestionDetails.DataBind();

                txtQuestionTitle.Text = "";
                radIsAnswer.SelectedIndex = -1;
            }

            else
            {
                Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails = new Quiz_MultipleQuestionDetails();


                quiz_MultipleQuestionDetails.QuestionTitle = txtQuestionTitle.Text;
                quiz_MultipleQuestionDetails.IsAnswer = radIsAnswer.SelectedValue == "True" ? true : false;

                quiz_MultipleQuestionDetails.MultipleQuestionDetailsID = 0;
                ((List<Quiz_MultipleQuestionDetails>)Session["multipleQuestions"]).Add(quiz_MultipleQuestionDetails);
               
                txtQuestionTitle.Text = "";

                radIsAnswer.SelectedIndex = -1;

                gvQuiz_MultipleQuestionDetails.DataSource = Session["multipleQuestions"];
                gvQuiz_MultipleQuestionDetails.DataBind();

                txtQuestionTitle.Text = "";
                radIsAnswer.SelectedIndex = -1;
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
            List<Quiz_MultipleQuestionDetails> multipleQuestions = new List<Quiz_MultipleQuestionDetails>();
            multipleQuestions = (List<Quiz_MultipleQuestionDetails>)Session["multipleQuestions"];


            List<int> deletedDtlID = new List<int>();

            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;

            int index = Convert.ToInt32(linkButton.CommandArgument);
            HiddenField hfMCQdtlID = (HiddenField)gvQuiz_MultipleQuestionDetails.Rows[index].FindControl("hfMCQdtlID");
            int mcqDtlID = Convert.ToInt32(hfMCQdtlID.Value);
            multipleQuestions.RemoveAt(index);

            if (mcqDtlID > 0)
            {
                if (Session["deletedDtlID"] == null)
                {
                    deletedDtlID.Add(mcqDtlID);
                    Session["deletedDtlID"] = deletedDtlID;
                }
                else
                    ((List<int>)Session["deletedDtlID"]).Add(mcqDtlID);
            }
           
            Session["multipleQuestions"] = multipleQuestions;
            

            gvQuiz_MultipleQuestionDetails.DataSource = Session["multipleQuestions"];
            gvQuiz_MultipleQuestionDetails.DataBind();
        }
        catch (Exception ex)
        { }
    }
     
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            List<Quiz_MultipleQuestionDetails> multipleQuestions = new List<Quiz_MultipleQuestionDetails>();
            multipleQuestions = (List<Quiz_MultipleQuestionDetails>)Session["multipleQuestions"];

            string userID = Profile.card_id;

            Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion();
            quiz_MultipleQuestion.ComprehensionID = 0;
            quiz_MultipleQuestion.CourseID = int.Parse(ddlCourseID.SelectedValue);
            quiz_MultipleQuestion.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            quiz_MultipleQuestion.ChapterID = int.Parse(ddlChapterID.SelectedValue);
            quiz_MultipleQuestion.MultipleQuestionName = fckDesc.Value;
            quiz_MultipleQuestion.AddedBy = userID;
            quiz_MultipleQuestion.AddedDate = DateTime.Now;
            quiz_MultipleQuestion.ModifiedBy = userID;
            quiz_MultipleQuestion.ModifiedDate = DateTime.Now;
            int MultipleQustionID = Quiz_MultipleQuestionManager.InsertQuiz_MultipleQuestion(quiz_MultipleQuestion);

            if (multipleQuestions != null)
            {

                for (int i = 0; i < multipleQuestions.Count; i++)
                {
                    HR_EmployeeSalaryRules hR_EmployeeSalaryRules = new HR_EmployeeSalaryRules();

                    Label lblSerial = ((Label)gvQuiz_MultipleQuestionDetails.Rows[i].FindControl("lblSerial"));
                    TextBox txtGridQuestionTitle = ((TextBox)gvQuiz_MultipleQuestionDetails.Rows[i].FindControl("txtQuestionTitle"));
                    RadioButtonList chkAnswer = ((RadioButtonList)gvQuiz_MultipleQuestionDetails.Rows[i].FindControl("radIsAnswer"));

                    Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails = new Quiz_MultipleQuestionDetails();
                    quiz_MultipleQuestionDetails.MultipleQustionID = MultipleQustionID;
                    quiz_MultipleQuestionDetails.QuestionTitle = txtGridQuestionTitle.Text;
                    quiz_MultipleQuestionDetails.IsAnswer = chkAnswer.SelectedValue == "True" ? true : false;

                    quiz_MultipleQuestionDetails.AddedBy = userID;
                    quiz_MultipleQuestionDetails.AddedDate = DateTime.Now;
                    quiz_MultipleQuestionDetails.ModifiedBy = userID;
                    quiz_MultipleQuestionDetails.ModifiedDate = DateTime.Now;
                    int resutl = Quiz_MultipleQuestionDetailsManager.InsertQuiz_MultipleQuestionDetails(quiz_MultipleQuestionDetails);

                }
            }

            if (txtQuestionTitle.Text!="")
            {
                Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails = new Quiz_MultipleQuestionDetails();
                quiz_MultipleQuestionDetails.MultipleQustionID = MultipleQustionID;
                quiz_MultipleQuestionDetails.QuestionTitle = txtQuestionTitle.Text;
                quiz_MultipleQuestionDetails.IsAnswer = radIsAnswer.SelectedValue == "True" ? true : false;
                quiz_MultipleQuestionDetails.AddedBy = userID;
                quiz_MultipleQuestionDetails.AddedDate = DateTime.Now;
                quiz_MultipleQuestionDetails.ModifiedBy = userID;
                quiz_MultipleQuestionDetails.ModifiedDate = DateTime.Now;
                int resutl = Quiz_MultipleQuestionDetailsManager.InsertQuiz_MultipleQuestionDetails(quiz_MultipleQuestionDetails);
            }

            fckDesc.Value = string.Empty;
            txtQuestionTitle.Text = string.Empty;
            multipleQuestions.Clear();
            Session["multipleQuestions"] = null;
            gvQuiz_MultipleQuestionDetails.DataSource = multipleQuestions;
            gvQuiz_MultipleQuestionDetails.DataBind();

            if (ddlExamID.SelectedValue != "0")
            {
                Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, int.Parse(ddlExamID.SelectedValue), (int)Enums.QuestionTypes.MCQ,
                        MultipleQustionID,  Profile.card_id, DateTime.Now,  Profile.card_id, DateTime.Now);
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
            List<Quiz_MultipleQuestionDetails> multipleQuestions = new List<Quiz_MultipleQuestionDetails>();
            multipleQuestions = (List<Quiz_MultipleQuestionDetails>)Session["multipleQuestions"];

            string userID = Profile.card_id ;

            int multipleQuestionID = int.Parse(Request.QueryString["ID"].ToString());
            Quiz_MultipleQuestion quiz_MultipleQuestion = Quiz_MultipleQuestionManager.GetQuiz_MultipleQuestionByMultipleQustionID(multipleQuestionID);
            quiz_MultipleQuestion.CourseID = int.Parse(ddlCourseID.SelectedValue);
            quiz_MultipleQuestion.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            quiz_MultipleQuestion.ChapterID = int.Parse(ddlChapterID.SelectedValue);
            quiz_MultipleQuestion.MultipleQuestionName = fckDesc.Value;
            quiz_MultipleQuestion.ModifiedBy = userID;
            quiz_MultipleQuestion.ModifiedDate = DateTime.Now;
            bool result = Quiz_MultipleQuestionManager.UpdateQuiz_MultipleQuestion(quiz_MultipleQuestion);
            if (result)
            {
                #region Fill In The BlankDetails Insert/Update
                foreach (GridViewRow row in gvQuiz_MultipleQuestionDetails.Rows)
                {
                    int mcqDtlID = Convert.ToInt32(((HiddenField)row.FindControl("hfMCQdtlID")).Value);
                    Label lblSerial = ((Label)row.FindControl("lblSerial"));
                    TextBox txtGridQuestionTitle = ((TextBox)row.FindControl("txtQuestionTitle"));
                    RadioButtonList radIsAnswer = ((RadioButtonList)row.FindControl("radIsAnswer"));

                    Quiz_MultipleQuestionDetails mcqDtl = new Quiz_MultipleQuestionDetails();


                    if (mcqDtlID > 0)
                    {   
                        mcqDtl = multipleQuestions.Find(X => X.MultipleQuestionDetailsID == mcqDtlID);

                        mcqDtl.QuestionTitle = txtGridQuestionTitle.Text;
                        mcqDtl.IsAnswer = radIsAnswer.SelectedValue == "True" ? true : false;
                        mcqDtl.ModifiedBy = userID;
                        mcqDtl.ModifiedDate = DateTime.Now;
                        Quiz_MultipleQuestionDetailsManager.UpdateQuiz_MultipleQuestionDetails(mcqDtl);
                    }
                    else
                    {
                        mcqDtl.MultipleQuestionDetailsID = mcqDtlID;
                        mcqDtl.MultipleQustionID = multipleQuestionID;
                        mcqDtl.QuestionTitle = txtGridQuestionTitle.Text;
                        mcqDtl.IsAnswer = radIsAnswer.SelectedValue == "True" ? true : false;
                        mcqDtl.AddedBy = userID;
                        mcqDtl.AddedDate = DateTime.Now;
                        mcqDtl.ModifiedBy = userID;
                        mcqDtl.ModifiedDate = DateTime.Now;
                        Quiz_MultipleQuestionDetailsManager.InsertQuiz_MultipleQuestionDetails(mcqDtl);
                    }

                }

                if (txtQuestionTitle.Text != "")
                {
                    Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails = new Quiz_MultipleQuestionDetails();
                    quiz_MultipleQuestionDetails.MultipleQustionID = multipleQuestionID;
                    quiz_MultipleQuestionDetails.QuestionTitle = txtQuestionTitle.Text;
                    quiz_MultipleQuestionDetails.IsAnswer = radIsAnswer.SelectedValue == "True" ? true : false;
                    quiz_MultipleQuestionDetails.AddedBy = userID;
                    quiz_MultipleQuestionDetails.AddedDate = DateTime.Now;
                    quiz_MultipleQuestionDetails.ModifiedBy = userID;
                    quiz_MultipleQuestionDetails.ModifiedDate = DateTime.Now;
                    int resutl = Quiz_MultipleQuestionDetailsManager.InsertQuiz_MultipleQuestionDetails(quiz_MultipleQuestionDetails);
                }

                #endregion

                #region Remove Deleted Answer from DB

                List<int> deletedDtlID = new List<int>();
                if (Session["deletedDtlID"] != null)
                {
                    deletedDtlID = (List<int>)Session["deletedDtlID"];

                    foreach (int mcqDtlID in deletedDtlID)
                    {
                        Quiz_MultipleQuestionDetailsManager.DeleteQuiz_MultipleQuestionDetails(mcqDtlID);
                    }
                    
                }
                #endregion
            }

            multipleQuestions.Clear();
            Session["deletedDtlID"] = null;
            Session["multipleQuestions"] = null;

            //Response.Redirect("AdminDisplayQuiz_MultipleQuestion.aspx");
            Response.Redirect("ExamOrSetBuilder.aspx");
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvQuiz_MultipleQuestionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAnsewer = (Label)e.Row.FindControl("lblAnswer");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnsewer.Text == "True" ? "True" : "False";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Quiz_MultipleQuestionManager.DeleteQuiz_MultipleQuestion(Convert.ToInt32(Request.QueryString["ID"]));
        Response.Redirect("ExamOrSetBuilder.aspx");
    }
    protected void btnAssignQuestionToExam_Click(object sender, EventArgs e)
    {
        if (ddlExamID.SelectedValue != "0")
        {
            Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, int.Parse(ddlAllExam.SelectedValue), (int)Enums.QuestionTypes.MCQ,
                    Int32.Parse(Request.QueryString["ID"]), Profile.card_id, DateTime.Now,  Profile.card_id, DateTime.Now);
            Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
        }
    }
}

