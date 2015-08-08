using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Quiz_AdminDisplayQuiz_QuizBuilder : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadExamDuration();
            _loadCourse();
            _loadSubject(0);
        }
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
        
    private void _loadExamDuration()
    {
        try
        {
            for (int i = 0; i < 4; i++)
            {
                ddlExamHour.Items.Add(new ListItem(i.ToString("00"), i.ToString()));
            }

            for(int i=0;i<60;i+=5)
            {
                ddlExamMin.Items.Add(new ListItem(i.ToString("00"), i.ToString()));
            }
        }
        catch (Exception ex)
        {
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

        foreach (GridViewRow row in gvQuestionDistribution.Rows)
        {
            DropDownList ddlChapters = (DropDownList)row.FindControl("ddlChapters");
            try
            {
                if (courseID > 0 && subjectID > 0)
                {
                    DataSet ds = Quiz_ChapterManager.GetDropDownListAllQuiz_Chapter(courseID, subjectID);
                    ddlChapters.DataValueField = "ChapterID";
                    ddlChapters.DataTextField = "ChapterName";
                    ddlChapters.DataSource = ds.Tables[0];
                    ddlChapters.DataBind();
                }
                ddlChapters.Items.Insert(0, new ListItem("...All Chapter...", "0"));

                HiddenField hfChapterID = (HiddenField)row.FindControl("hfChapterID");
                ddlChapters.SelectedValue = hfChapterID.Value;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }

    #region Question Distribution

    protected void gvQuestionDistribution_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                dt.Columns.Add(new DataColumn("Chapter", typeof(string)));
                dt.Columns.Add(new DataColumn("TrueFalse", typeof(string)));
                dt.Columns.Add(new DataColumn("DrCr", typeof(string)));
                dt.Columns.Add(new DataColumn("FillInTheBlank", typeof(string)));
                dt.Columns.Add(new DataColumn("MCQ", typeof(string)));
                dt.Columns.Add(new DataColumn("Comprehension", typeof(string)));

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                gvQuestionDistribution.DataSource = dt;
                gvQuestionDistribution.DataBind();
            }
            catch (Exception ex)
            { }
        }
    }

    protected void gvQuestionDistribution_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlChapters = (DropDownList)e.Row.FindControl("ddlChapters");
            try
            {
                if (courseID > 0 && subjectID > 0)
                {
                    DataSet ds = Quiz_ChapterManager.GetDropDownListAllQuiz_Chapter(courseID, subjectID);
                    ddlChapters.DataValueField = "ChapterID";
                    ddlChapters.DataTextField = "ChapterName";
                    ddlChapters.DataSource = ds.Tables[0];
                    ddlChapters.DataBind();
                }
                ddlChapters.Items.Insert(0, new ListItem("...All Chapter...", "0"));

                HiddenField hfChapterID = (HiddenField)e.Row.FindControl("hfChapterID");
                ddlChapters.SelectedValue = hfChapterID.Value;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }

    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        try
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Chapter", typeof(string)));
            dt.Columns.Add(new DataColumn("TrueFalse", typeof(string)));
            dt.Columns.Add(new DataColumn("DrCr", typeof(string)));
            dt.Columns.Add(new DataColumn("FillInTheBlank", typeof(string)));
            dt.Columns.Add(new DataColumn("MCQ", typeof(string)));
            //dt.Columns.Add(new DataColumn("Comprehension", typeof(string)));
            int rowCount = gvQuestionDistribution.Rows.Count;
            DataRow dr = dt.NewRow();
            for (int i = 0; i < rowCount; i++)
            {
                DropDownList ddlChapters = (DropDownList)gvQuestionDistribution.Rows[i].FindControl("ddlChapters");
                HiddenField hfChapterID = (HiddenField)gvQuestionDistribution.Rows[i].FindControl("hfChapterID");
                TextBox txtTrueFalse = (TextBox)gvQuestionDistribution.Rows[i].FindControl("txtTrueFalse");
                TextBox txtDrCr = (TextBox)gvQuestionDistribution.Rows[i].FindControl("txtDrCr");
                TextBox txtFillInTheBlank = (TextBox)gvQuestionDistribution.Rows[i].FindControl("txtFillInTheBlank");
                TextBox txtMCQ = (TextBox)gvQuestionDistribution.Rows[i].FindControl("txtMCQ");
                //TextBox txtComprehension = (TextBox)gvQuestionDistribution.Rows[i].FindControl("txtComprehension");

                dr[0] = ddlChapters.SelectedValue;
                hfChapterID.Value = dr[0].ToString();
                dr[1] = txtTrueFalse.Text;
                dr[2] = txtDrCr.Text;
                dr[3] = txtFillInTheBlank.Text;
                dr[4] = txtMCQ.Text;
                //dr[5] = txtComprehension.Text;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }

            dt.Rows.Add(dr);

            gvQuestionDistribution.DataSource = dt;
            gvQuestionDistribution.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    #endregion

    #region Comprehension Question

    protected void gvQuiz_Comprehension_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            GridView gvQuiz_MultipleQuestion = (GridView)e.Row.FindControl("gvQuiz_MultipleQuestion");

            Label lblComprehensionID = (Label)e.Row.FindControl("lblComprehensionID");

            DataSet dsMultipleQuestion = Quiz_MultipleQuestionManager.GetQuiz_MultipleQuestionByComprehensionID(int.Parse(lblComprehensionID.Text));

            gvQuiz_MultipleQuestion.DataSource = dsMultipleQuestion;

            gvQuiz_MultipleQuestion.DataBind();

            //gvQuiz_MultipleQuestion

            //now for true false
            GridView gvQuiz_TrueFalse = (GridView)e.Row.FindControl("gvQuiz_TrueFalse");


            DataSet dsTrueFalse = Quiz_TrueFalseManager.GetQuiz_TrueFalseByComprehensionID(int.Parse(lblComprehensionID.Text));
            gvQuiz_TrueFalse.DataSource = dsTrueFalse;
            gvQuiz_TrueFalse.DataBind();


            //now for dr cr gvQuiz_gvDrCr_RowDataBound
            GridView gvQuiz_gvDrCr = (GridView)e.Row.FindControl("gvQuiz_gvDrCr");

            DataSet dsDrCr = Quiz_TrueFalseManager.GetQuiz_DrCrByComprehensionID(int.Parse(lblComprehensionID.Text));
            gvQuiz_gvDrCr.DataSource = dsDrCr;
            gvQuiz_gvDrCr.DataBind();


            //now fill in the blanks

            GridView gvQuiz_FillInTheBlanks = (GridView)e.Row.FindControl("gvQuiz_FillInTheBlanks");

            DataSet dsFillInTheBlanks = Quiz_FillInTheBlanksManager.GetQuiz_FillInTheBlanksByComprehensionID(int.Parse(lblComprehensionID.Text));
            gvQuiz_FillInTheBlanks.DataSource = dsFillInTheBlanks;
            gvQuiz_FillInTheBlanks.DataBind();
        }
    }

    protected void gvMultipleQUestionsAnswer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //gvMultipleQUestionsAnswer
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblAnswerValue = (Label)e.Row.FindControl("lblAnswerValue");

            //RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            //chkAnswer.SelectedValue = lblAnswerValue.Text == "True" ? "True" : "False";
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = FormatNumberToWord(lblSerial.Text);
        }
    }

    public static string FormatNumberToWord(string number)
    {
        string value = string.Empty;
        switch (number)
        {
            case "1":
                value = "a";
                break;

            case "2":
                value = "b";

                break;
            case "3":
                value = "c";
                break;
            case "4":
                value = "d";
                break;
            case "5":
                value = "e";
                break;

            case "6":
                value = "f";
                break;
            case "7":
                value = "g";
                break;
            case "8":
                value = "h";
                break;
            case "9":
                value = "i";
                break;

        }
        return value;
    }

    protected void gvQuiz_MultipleQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //gvMultipleQUestionsAnswer

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblMultipleQustionID = (Label)e.Row.FindControl("lblMultipleQustionID");
            Label lblCourseID = (Label)e.Row.FindControl("lblCourseID");
            Label lblSubjectID = (Label)e.Row.FindControl("lblSubjectID");
            Label lblChapterID = (Label)e.Row.FindControl("lblChapterID");

            GridView gvAnswer = (GridView)e.Row.FindControl("gvMultipleQUestionsAnswer");

            DataSet dsAnswer = Quiz_MultipleQuestionDetailsManager.GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID(int.Parse(lblMultipleQustionID.Text));

            gvAnswer.DataSource = dsAnswer;
            gvAnswer.DataBind();

            //  gvAnswer.DataSource = 

            //Label lblAnsewer = (Label)e.Row.FindControl("lblAnswer");

            // RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            // chkAnswer.SelectedValue = lblAnsewer.Text == "True" ? "True" : "False";


            //  BulletedList bl =             (BulletedList)e.Row.FindControl("bltTerritories");
        }
    }
    
    protected void gvQuiz_TrueFalse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //gvMultipleQUestionsAnswer

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAnsewer = (Label)e.Row.FindControl("lblAnswer");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnsewer.Text == "True" ? "True" : "False";
        }
    }

    protected void gvQuiz_gvDrCr_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAnsewer = (Label)e.Row.FindControl("lblAnswer");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnsewer.Text == "True" ? "True" : "False";
        }
    }

    protected void gvQuiz_FillInTheBlanks_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvFillIntheBlanksDetails = (GridView)e.Row.FindControl("gvFillIntheBlanksDetails");
            Label lblFillInTheBlanksID = (Label)e.Row.FindControl("lblFillInTheBlanksID");
            DataSet dsFillInTheBlanksDetails = Quiz_FillInTheBlanksDetailsManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(int.Parse(lblFillInTheBlanksID.Text));

            gvFillIntheBlanksDetails.DataSource = dsFillInTheBlanksDetails;
            gvFillIntheBlanksDetails.DataBind();
        }
    }

    #endregion

    #region Begin Non Comprehension

    protected void btnGenerateQuiz_Click(object sender, EventArgs e)
    {
        try
        {
            int courseID=Convert.ToInt32(ddlCourseID.SelectedValue);
            int subjectID=Convert.ToInt32(ddlSubjectID.SelectedValue);

            List<Quiz_TrueFalse> trueFalseQuestions = new List<Quiz_TrueFalse>();
            List<Quiz_TrueFalse> drCrQuestions = new List<Quiz_TrueFalse>();
            List<Quiz_FillInTheBlanks> fillInTheBlanks = new List<Quiz_FillInTheBlanks>();
            List<Quiz_MultipleQuestion> multipleQuestion = new List<Quiz_MultipleQuestion>();
            //List<Quiz_Comprehension> comprehensions = new List<Quiz_Comprehension>();

            foreach (GridViewRow row in gvQuestionDistribution.Rows)
            {
                DropDownList ddlChapters = (DropDownList)row.FindControl("ddlChapters");
                TextBox txtTrueFalse = (TextBox)row.FindControl("txtTrueFalse");
                TextBox txtDrCr = (TextBox)row.FindControl("txtDrCr");
                TextBox txtFillInTheBlank = (TextBox)row.FindControl("txtFillInTheBlank");
                TextBox txtMCQ = (TextBox)row.FindControl("txtMCQ");
                //TextBox txtComprehension = (TextBox)row.FindControl("txtComprehension");
                int chapterID = Convert.ToInt32(ddlChapters.SelectedValue);

                if (txtTrueFalse.Text.Length > 0)
                {
                    trueFalseQuestions.AddRange(Quiz_TrueFalseManager.GetQuiz_TrueFalsesRandomly(courseID, subjectID, chapterID, false, Convert.ToInt32(txtTrueFalse.Text)));
                }

                if (txtDrCr.Text.Length > 0)
                {
                    drCrQuestions.AddRange( Quiz_TrueFalseManager.GetQuiz_TrueFalsesRandomly(courseID, subjectID, chapterID, true, Convert.ToInt32(txtDrCr.Text)));
                    
                }

                if (txtFillInTheBlank.Text.Length > 0)
                {
                    fillInTheBlanks.AddRange( Quiz_FillInTheBlanksManager.GetQuiz_FillInTheBlanksRandomly(courseID, subjectID, chapterID, Convert.ToInt32(txtFillInTheBlank.Text)));
                }

                if (txtMCQ.Text.Length > 0)
                {
                    multipleQuestion.AddRange( Quiz_MultipleQuestionManager.GetQuiz_MultipleQuestionsRandomly(courseID, subjectID, chapterID, Convert.ToInt32(txtMCQ.Text)));
                }

                //if (txtComprehension.Text.Length > 0)
                //{
                //    comprehensions.AddRange(Quiz_ComprehensionManager.GetQuiz_ComprehensionsRandomly(courseID, subjectID, chapterID, Convert.ToInt32(txtComprehension.Text)));
                    
                //}

                gvQuiz_nc_TrueFalse.DataSource = trueFalseQuestions;
                gvQuiz_nc_TrueFalse.DataBind();
                if (trueFalseQuestions.Count > 0)
                    phTrueFalse.Visible = true;
                else
                    phTrueFalse.Visible = false;

                gvQuiz_nc_gvDrCr.DataSource = drCrQuestions;
                gvQuiz_nc_gvDrCr.DataBind();
                if (drCrQuestions.Count > 0)
                    phDrCr.Visible = true;
                else
                    phDrCr.Visible = false;

                gvQuiz_nc_FillInTheBlanks.DataSource = fillInTheBlanks;
                gvQuiz_nc_FillInTheBlanks.DataBind();
                if (fillInTheBlanks.Count > 0)
                    phFillInTheBlanks.Visible = true;
                else
                    phFillInTheBlanks.Visible = false;

                gvQuiz_nc_MultipleQuestion.DataSource = multipleQuestion;
                gvQuiz_nc_MultipleQuestion.DataBind();
                if (multipleQuestion.Count > 0)
                    phMCQ.Visible = true;
                else
                    phMCQ.Visible = false;

                //gvQuiz_Comprehension.DataSource = comprehensions;
                //gvQuiz_Comprehension.DataBind();
                //if (comprehensions.Count > 0)
                //    phComprehension.Visible = true;
                //else
                //    phComprehension.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvQuiz_nc_MultipleQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblMultipleQustionID = (Label)e.Row.FindControl("lblMultipleQustionID");
                Label lblCourseID = (Label)e.Row.FindControl("lblCourseID");
                Label lblSubjectID = (Label)e.Row.FindControl("lblSubjectID");
                Label lblChapterID = (Label)e.Row.FindControl("lblChapterID");

                GridView gvAnswer = (GridView)e.Row.FindControl("gvMultipleQUestionsAnswer");

                DataSet dsAnswer = Quiz_MultipleQuestionDetailsManager.GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID(int.Parse(lblMultipleQustionID.Text));

                gvAnswer.DataSource = dsAnswer;
                gvAnswer.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvQuiz_nc_TrueFalse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //gvMultipleQUestionsAnswer

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAnsewer = (Label)e.Row.FindControl("lblAnswer");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnsewer.Text == "True" ? "True" : "False";
        }
    }

    protected void gvQuiz_nc_gvDrCr_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAnsewer = (Label)e.Row.FindControl("lblAnswer");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnsewer.Text == "True" ? "True" : "False";
        }
    }

    protected void gvQuiz_nc_FillInTheBlanks_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvFillIntheBlanksDetails = (GridView)e.Row.FindControl("gvFillIntheBlanksDetails");
            Label lblFillInTheBlanksID = (Label)e.Row.FindControl("lblFillInTheBlanksID");
            DataSet dsFillInTheBlanksDetails = Quiz_FillInTheBlanksDetailsManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(int.Parse(lblFillInTheBlanksID.Text));

            gvFillIntheBlanksDetails.DataSource = dsFillInTheBlanksDetails;
            gvFillIntheBlanksDetails.DataBind();
        }
    }

    #endregion
    
    #region Save Quiz Question
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Begin Insert Exam
            int examDuration = Convert.ToInt32(ddlExamHour.SelectedValue) * 60 + Convert.ToInt32(ddlExamMin.SelectedValue);
            if (examDuration == 0)
                examDuration = 120;
            DateTime examStartTime = DateTime.Now;
            bool isRetake = false;// cbIsRetake.Checked;
            int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
            int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
            int chapterID = 0;      // Convert.ToInt32(ddlChapterID.SelectedValue);

            Quiz_Exam qe = new Quiz_Exam(0, txtExamName.Text, courseID, subjectID, chapterID, examDuration, examStartTime,
                        isRetake, true, "User", DateTime.Now,  Profile.card_id, DateTime.Now);
            int examID = Quiz_ExamManager.InsertQuiz_Exam(qe);
            
            #endregion End Insert Exam


            #region Begin Exam Details
            if (examID > 0)
            {
                foreach (GridViewRow row in gvQuiz_nc_TrueFalse.Rows)
                {
                    int trueFalseID = Convert.ToInt32(((HiddenField)row.FindControl("hfTrueFalseID")).Value);
                    Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, examID, (int)Enums.QuestionTypes.TrueFalse,
                            trueFalseID, "User", DateTime.Now,  Profile.card_id, DateTime.Now);
                    Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
                }

                foreach (GridViewRow row in gvQuiz_nc_gvDrCr.Rows)
                {
                    int drCrID = Convert.ToInt32(((HiddenField)row.FindControl("hfDrCrID")).Value);
                    Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, examID, (int)Enums.QuestionTypes.DrCr,
                            drCrID, "User", DateTime.Now,  Profile.card_id, DateTime.Now);
                    Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
                }

                foreach (GridViewRow row in gvQuiz_nc_FillInTheBlanks.Rows)
                {
                    int fillInTheBlanksID = Convert.ToInt32(((Label)row.FindControl("lblFillInTheBlanksID")).Text);
                    Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, examID, (int)Enums.QuestionTypes.FillInTheBlanks,
                            fillInTheBlanksID, "User", DateTime.Now,  Profile.card_id, DateTime.Now);
                    Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
                }

                foreach (GridViewRow row in gvQuiz_nc_MultipleQuestion.Rows)
                {
                    Label lblMcqID = (Label)row.FindControl("lblMultipleQustionID");
                    int mcqID = Convert.ToInt32(lblMcqID.Text);
                    Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, examID, (int)Enums.QuestionTypes.MCQ,
                            mcqID, "User", DateTime.Now,  Profile.card_id, DateTime.Now);
                    Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
                }

                foreach (GridViewRow row in gvQuiz_Comprehension.Rows)
                {
                    int comprehensionID = Convert.ToInt32(((Label)row.FindControl("lblComprehensionID")).Text);
                    Quiz_ExamQuestionDetails qe_Details = new Quiz_ExamQuestionDetails(0, examID, (int)Enums.QuestionTypes.Comprehension,
                                comprehensionID, "User", DateTime.Now,  Profile.card_id, DateTime.Now);
                    Quiz_ExamQuestionDetailsManager.InsertQuiz_ExamQuestionDetails(qe_Details);
                }
            }
            #endregion End Exam Details
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

}