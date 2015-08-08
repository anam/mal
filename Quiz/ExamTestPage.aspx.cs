using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Quiz_ExamTestPage : System.Web.UI.Page
{
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
                DataSet ds = Quiz_ChapterManager.GetDropDownListAllQuiz_Chapter(courseID, subjectID);
                ddlChapters.DataValueField = "ChapterID";
                ddlChapters.DataTextField = "ChapterName";
                ddlChapters.DataSource = ds.Tables[0];
                ddlChapters.DataBind();
                ddlChapters.Items.Insert(0, new ListItem("...All Chapter...", "0"));

                HiddenField hfChapterID = (HiddenField)row.FindControl("hfChapterID");
                ddlChapters.SelectedValue = hfChapterID.Value;
                ddlChapters_SelectedIndexChanged((object)ddlChapters, new EventArgs());
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
                //dt.Columns.Add(new DataColumn("Comprehension", typeof(string)));

                DataRow dr = dt.NewRow();
                dr[0] = "0";
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
        string studentID = Profile.card_id;

        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlChapters = (DropDownList)e.Row.FindControl("ddlChapters");
            HiddenField hfChapterID = (HiddenField)e.Row.FindControl("hfChapterID");
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
                ddlChapters.SelectedValue = hfChapterID.Value;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            int chapterID=Convert.ToInt32(hfChapterID.Value);
            Label lblAvailTrueFalse = (Label)e.Row.FindControl("lblAvailTrueFalse");
            Label lblAvailDrCr = (Label)e.Row.FindControl("lblAvailDrCr");
            Label lblAvailFillBlanks = (Label)e.Row.FindControl("lblAvailFillBlanks");
            Label lblAvailMCQ = (Label)e.Row.FindControl("lblAvailMCQ");
            //Label lblAvailComprehension = (Label)e.Row.FindControl("lblAvailComprehension");
            try
            {
                lblAvailTrueFalse.Text = STD_MockTestManager.GetMockTest_TrueFalses_Count(studentID, courseID, subjectID, chapterID, false).ToString();
                if (lblAvailTrueFalse.Text == "0")
                    lblAvailTrueFalse.ForeColor = System.Drawing.Color.Red;
                else
                    lblAvailTrueFalse.ForeColor = System.Drawing.Color.Green;
                lblAvailDrCr.Text = STD_MockTestManager.GetMockTest_TrueFalses_Count(studentID, courseID, subjectID, chapterID, true).ToString();
                if (lblAvailDrCr.Text == "0")
                    lblAvailDrCr.ForeColor = System.Drawing.Color.Red;
                else
                    lblAvailDrCr.ForeColor = System.Drawing.Color.Green;
                lblAvailFillBlanks.Text = STD_MockTestManager.GetMockTest_FillInTheBlanks_Count(studentID, courseID, subjectID, chapterID).ToString();
                if (lblAvailFillBlanks.Text == "0")
                    lblAvailFillBlanks.ForeColor = System.Drawing.Color.Red;
                else
                    lblAvailFillBlanks.ForeColor = System.Drawing.Color.Green;
                lblAvailMCQ.Text = STD_MockTestManager.GetMockTest_MCQ_Count(studentID, courseID, subjectID, chapterID).ToString();
                if (lblAvailMCQ.Text == "0")
                    lblAvailMCQ.ForeColor = System.Drawing.Color.Red;
                else
                    lblAvailMCQ.ForeColor = System.Drawing.Color.Green;
                //lblAvailComprehension.Text = STD_MockTestManager.GetMockTest_Comprehension_Count(studentID, courseID, subjectID, chapterID).ToString();
                //if (lblAvailComprehension.Text == "0")
                //    lblAvailComprehension.ForeColor = System.Drawing.Color.Red;
                //else
                //    lblAvailComprehension.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
            }
        }
    }

    protected void ddlChapters_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlChapters = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlChapters.NamingContainer;

        string studentID = Profile.card_id;

        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        int chapterID = Convert.ToInt32(ddlChapters.SelectedValue);
        Label lblAvailTrueFalse = (Label)row.FindControl("lblAvailTrueFalse");
        Label lblAvailDrCr = (Label)row.FindControl("lblAvailDrCr");
        Label lblAvailFillBlanks = (Label)row.FindControl("lblAvailFillBlanks");
        Label lblAvailMCQ = (Label)row.FindControl("lblAvailMCQ");
        //Label lblAvailComprehension = (Label)row.FindControl("lblAvailComprehension");
        try
        {
            lblAvailTrueFalse.Text = STD_MockTestManager.GetMockTest_TrueFalses_Count(studentID, courseID, subjectID, chapterID, false).ToString();
            if (lblAvailTrueFalse.Text == "0")
                lblAvailTrueFalse.ForeColor = System.Drawing.Color.Red;
            else
                lblAvailTrueFalse.ForeColor = System.Drawing.Color.Green;
            lblAvailDrCr.Text = STD_MockTestManager.GetMockTest_TrueFalses_Count(studentID, courseID, subjectID, chapterID, true).ToString();
            if (lblAvailDrCr.Text == "0")
                lblAvailDrCr.ForeColor = System.Drawing.Color.Red;
            else
                lblAvailDrCr.ForeColor = System.Drawing.Color.Green;
            lblAvailFillBlanks.Text = STD_MockTestManager.GetMockTest_FillInTheBlanks_Count(studentID, courseID, subjectID, chapterID).ToString();
            if (lblAvailFillBlanks.Text == "0")
                lblAvailFillBlanks.ForeColor = System.Drawing.Color.Red;
            else
                lblAvailFillBlanks.ForeColor = System.Drawing.Color.Green;
            lblAvailMCQ.Text = STD_MockTestManager.GetMockTest_MCQ_Count(studentID, courseID, subjectID, chapterID).ToString();
            if (lblAvailMCQ.Text == "0")
                lblAvailMCQ.ForeColor = System.Drawing.Color.Red;
            else
                lblAvailMCQ.ForeColor = System.Drawing.Color.Green;
            //lblAvailComprehension.Text = STD_MockTestManager.GetMockTest_Comprehension_Count(studentID, courseID, subjectID, chapterID).ToString();
            //if (lblAvailComprehension.Text == "0")
            //    lblAvailComprehension.ForeColor = System.Drawing.Color.Red;
            //else
            //    lblAvailComprehension.ForeColor = System.Drawing.Color.Green;
        }
        catch (Exception ex)
        {
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

            dr[0] = "0";
            dt.Rows.Add(dr);

            gvQuestionDistribution.DataSource = dt;
            gvQuestionDistribution.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    #endregion

    #region Begin Exam

    protected void btnGenerateQuiz_Click(object sender, EventArgs e)
    {
        try
        {
            string studentID = Profile.card_id;
            int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
            int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);

            List<Quiz_TrueFalse> trueFalseQuestions = new List<Quiz_TrueFalse>();
            List<Quiz_TrueFalse> drCrQuestions = new List<Quiz_TrueFalse>();
            List<Quiz_FillInTheBlanks> fillInTheBlanks = new List<Quiz_FillInTheBlanks>();
            List<Quiz_MultipleQuestion> multipleQuestion = new List<Quiz_MultipleQuestion>();
            //List<Quiz_Comprehension> comprehensions = new List<Quiz_Comprehension>();

            #region Load Questions from Distribution
            foreach (GridViewRow row in gvQuestionDistribution.Rows)
            {
                DropDownList ddlChapters = (DropDownList)row.FindControl("ddlChapters");
                TextBox txtTrueFalse = (TextBox)row.FindControl("txtTrueFalse");
                TextBox txtDrCr = (TextBox)row.FindControl("txtDrCr");
                TextBox txtFillInTheBlank = (TextBox)row.FindControl("txtFillInTheBlank");
                TextBox txtMCQ = (TextBox)row.FindControl("txtMCQ");
                TextBox txtComprehension = (TextBox)row.FindControl("txtComprehension");
                int chapterID = Convert.ToInt32(ddlChapters.SelectedValue);

                if (txtTrueFalse.Text.Length > 0)
                {
                    trueFalseQuestions.AddRange(STD_MockTestManager.GetMockTest_TrueFalses(studentID, courseID, subjectID, chapterID, false, Convert.ToInt32(txtTrueFalse.Text)));
                }

                if (txtDrCr.Text.Length > 0)
                {
                    drCrQuestions.AddRange(STD_MockTestManager.GetMockTest_TrueFalses(studentID, courseID, subjectID, chapterID, true, Convert.ToInt32(txtDrCr.Text)));
                }

                if (txtFillInTheBlank.Text.Length > 0)
                {
                    fillInTheBlanks.AddRange(STD_MockTestManager.GetMockTest_FillInTheBlanks(studentID, courseID, subjectID, chapterID, Convert.ToInt32(txtFillInTheBlank.Text)));
                }

                if (txtMCQ.Text.Length > 0)
                {
                    multipleQuestion.AddRange(STD_MockTestManager.GetMockTest_MCQ(studentID, courseID, subjectID, chapterID, Convert.ToInt32(txtMCQ.Text)));
                }

                //if (txtComprehension.Text.Length > 0)
                //{
                //    comprehensions.AddRange(STD_MockTestManager.GetMockTest_Comprehension(studentID, courseID, subjectID, chapterID, Convert.ToInt32(txtComprehension.Text)));
                //}
            }
            #endregion

            List<ExamQuestion> questions = new List<ExamQuestion>();

            if (trueFalseQuestions.Count > 0 || drCrQuestions.Count > 0 || fillInTheBlanks.Count > 0 || multipleQuestion.Count > 0)
            {
                //phExamHeader.Visible = true;
                phActions.Visible = true;

                #region True False Questions
                foreach (Quiz_TrueFalse tfQ in trueFalseQuestions)
                {
                    ExamQuestion eq = new ExamQuestion();
                    eq.QuestionType = (int)Enums.QuestionTypes.TrueFalse;
                    eq.QuestionNo = tfQ.TrueFalseID;
                    eq.ComprehensionID = tfQ.ComprehensionID;
                    questions.Add(eq);

                    StudentExamQuestion seq = new StudentExamQuestion(0, eq.QuestionNo, eq.QuestionType, studentID, 1, "", DateTime.Now, "", DateTime.Now);
                    StudentExamQuestionManager.InsertStudentExamQuestion(seq);
                }
                #endregion

                #region Dr/ Cr Questions

                foreach (Quiz_TrueFalse drcrQ in drCrQuestions)
                {
                    ExamQuestion eq = new ExamQuestion();
                    eq.QuestionType = (int)Enums.QuestionTypes.DrCr;
                    eq.QuestionNo = drcrQ.TrueFalseID;
                    eq.ComprehensionID = drcrQ.ComprehensionID;
                    questions.Add(eq);

                    StudentExamQuestion seq = new StudentExamQuestion(0, eq.QuestionNo, eq.QuestionType, studentID, 1, "", DateTime.Now, "", DateTime.Now);
                    StudentExamQuestionManager.InsertStudentExamQuestion(seq);
                }
                #endregion

                #region Multiple Choice Questions
                foreach (Quiz_MultipleQuestion mcq in multipleQuestion)
                {
                    ExamQuestion eq = new ExamQuestion();
                    eq.QuestionType = (int)Enums.QuestionTypes.MCQ;
                    eq.QuestionNo = mcq.MultipleQustionID;
                    eq.ComprehensionID = mcq.ComprehensionID;
                    questions.Add(eq);

                    StudentExamQuestion seq = new StudentExamQuestion(0, eq.QuestionNo, eq.QuestionType, studentID, 1, "", DateTime.Now, "", DateTime.Now);
                    StudentExamQuestionManager.InsertStudentExamQuestion(seq);
                }
                #endregion

                #region Fill In The Blanks
                foreach (Quiz_FillInTheBlanks fitb in fillInTheBlanks)
                {
                    ExamQuestion eq = new ExamQuestion();
                    eq.QuestionType = (int)Enums.QuestionTypes.FillInTheBlanks;
                    eq.QuestionNo = fitb.FillInTheBlanksID;
                    eq.ComprehensionID = fitb.ComprehensionID;
                    questions.Add(eq);

                    StudentExamQuestion seq = new StudentExamQuestion(0, eq.QuestionNo, eq.QuestionType, studentID, 1, "", DateTime.Now, "", DateTime.Now);
                    StudentExamQuestionManager.InsertStudentExamQuestion(seq);
                }
                #endregion

                Session["questions"] = questions;
                Session["totalQuestion"] = questions.Count;
                _loadQuestionList();
                Session["questionNo"] = 1;
                _loadQuestion(0);
                btnSubmit.Visible = true;
                //clkExamTime.Enabled = true;
                Session["startTime"] = DateTime.Now;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            int questionNo = Convert.ToInt32(Session["questionNo"].ToString());
            int totalQuestion = Convert.ToInt32(Session["totalQuestion"].ToString());
            _evaluateQuestion(questionNo - 1);
            if (questionNo > 1)
            {
                questionNo -= 1;
                _loadQuestion(questionNo - 1);
            }

            Session["questionNo"] = questionNo;
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            int questionNo = Convert.ToInt32(Session["questionNo"].ToString());
            int totalQuestion = Convert.ToInt32(Session["totalQuestion"].ToString());
            _evaluateQuestion(questionNo - 1);
            if (questionNo < totalQuestion)
            {
                _loadQuestion(questionNo);
                questionNo += 1;
            }

            Session["questionNo"] = questionNo;
        }
        catch (Exception ex)
        {
        }
    }

    protected void ddlQuestionNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int questionNo = Convert.ToInt32(Session["questionNo"].ToString());
            int index = ddlQuestionNo.SelectedIndex - 1;
            if (index >= 0)
            {
                questionNo = index + 1;
                _loadQuestion(index);

                //upQuestions.Update();
            }

            Session["questionNo"] = questionNo;
        }
        catch (Exception ex)
        {
        }
    }

    private void _loadQuestionList()
    {
        try
        {
            List<ExamQuestion> questions = new List<ExamQuestion>();
            questions = (List<ExamQuestion>)Session["questions"];
            int itemCount = questions.Count;
            ddlQuestionNo.Items.Clear();
            for (int i = 0; i < itemCount; i++)
            {
                ddlQuestionNo.Items.Add(new ListItem("Question No- " + (i + 1).ToString(), (i + 1).ToString()));
            }
            ddlQuestionNo.Items.Insert(0, new ListItem("...Select Question...", "0"));

            //ddlQuestionNo.SelectedValue = questionNo.ToString();
            //ddlQuestionNo_SelectedIndexChanged(new object(), new EventArgs());
        }
        catch (Exception ex)
        {
        }
    }

    private void _loadQuestion(int index)
    {
        try
        {
            _hideAll();
            List<ExamQuestion> questions = (List<ExamQuestion>)Session["questions"];
            ExamQuestion sQuestion = new ExamQuestion();
            sQuestion = (questions[index]);

            if (sQuestion.ComprehensionID > 0)
            {
                Quiz_Comprehension com = Quiz_ComprehensionManager.GetQuiz_ComprehensionByComprehensionID(sQuestion.ComprehensionID);
                lblComprehensionPara.Text = com.Comprehension;
                phComprehension.Visible = true;
            }

            if (sQuestion.QuestionType == (int)Enums.QuestionTypes.TrueFalse)
            {
                Quiz_TrueFalse tfQuestion = Quiz_TrueFalseManager.GetQuiz_TrueFalseByTrueFalseID(sQuestion.QuestionNo);
                lblTrueFalseQuestionTitle.Text = tfQuestion.QuestionTitle;
                hfTrueFalse.Value = tfQuestion.IsTrue.ToString();
                lblQuestionNo1.Text = (index + 1).ToString();
                phTrueFalse.Visible = true;

                //rblTrueFalse.Enabled = !sQuestion.IsAnswered;
                rblTrueFalse.SelectedValue = sQuestion.Answer;
            }

            else if (sQuestion.QuestionType == (int)Enums.QuestionTypes.DrCr)
            {
                Quiz_TrueFalse tfQuestion = Quiz_TrueFalseManager.GetQuiz_TrueFalseByTrueFalseID(sQuestion.QuestionNo);
                lblDrCrQuestionTitle.Text = tfQuestion.QuestionTitle;
                hfDrCr.Value = tfQuestion.IsTrue.ToString();
                lblQuestionNo2.Text = (index + 1).ToString();
                phDrCr.Visible = true;

                //rblDrCr.Enabled = !sQuestion.IsAnswered;
                rblDrCr.SelectedValue = sQuestion.Answer;
            }

            else if (sQuestion.QuestionType == (int)Enums.QuestionTypes.MCQ)
            {
                lblMCQNo.Text = (index + 1).ToString();
                Quiz_MultipleQuestion mcq = Quiz_MultipleQuestionManager.GetQuiz_MultipleQuestionByMultipleQustionID(sQuestion.QuestionNo);
                lblMcqTitle.Text = mcq.MultipleQuestionName;
                gvMultipleQUestionsAnswer.DataSource = Quiz_MultipleQuestionDetailsManager.GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID(sQuestion.QuestionNo);
                gvMultipleQUestionsAnswer.DataBind();

                phMCQ.Visible = true;

                if (sQuestion.IsAnswered)
                {
                    string[] answers = sQuestion.Answer.Split(',');

                    for (int i = 0; i < gvMultipleQUestionsAnswer.Rows.Count; i++)
                    {
                        GridViewRow row = gvMultipleQUestionsAnswer.Rows[i];
                        CheckBox cbTrueFalse = (CheckBox)row.FindControl("cbTrueFalse");
                        //cbTrueFalse.Enabled = false;
                        cbTrueFalse.Checked = bool.Parse(answers[i]);
                    }
                }
            }

            else if (sQuestion.QuestionType == (int)Enums.QuestionTypes.FillInTheBlanks)
            {
                phFillInTheBlanks.Visible = true;

                lblFillInTheBlankNo.Text = (index + 1).ToString();
                Quiz_FillInTheBlanks fitb = Quiz_FillInTheBlanksManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(sQuestion.QuestionNo);
                lblfillInTheBlankTitle.Text = fitb.Question;

                gvFillIntheBlanksDetails.DataSource = Quiz_FillInTheBlanksDetailsManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(sQuestion.QuestionNo);
                gvFillIntheBlanksDetails.DataBind();

                if (sQuestion.IsAnswered)
                {
                    string[] answers = sQuestion.Answer.Split(new string[] { "[#&#]" }, StringSplitOptions.None);

                    for (int i = 0; i < gvFillIntheBlanksDetails.Rows.Count; i++)
                    {
                        TextBox txtAnswer = (TextBox)gvFillIntheBlanksDetails.Rows[i].FindControl("txtAnswer");
                        txtAnswer.Text = answers[i];
                        //txtAnswer.Enabled = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void _evaluateQuestion(int index)
    {
        try
        {
            List<ExamQuestion> questions = (List<ExamQuestion>)Session["questions"];
            ExamQuestion eq = questions[index];

            eq.IsAnswered = true;

            #region True / False Questions
            if (eq.QuestionType == (int)Enums.QuestionTypes.TrueFalse)
            {
                if (hfTrueFalse.Value == rblTrueFalse.SelectedValue)
                {
                    eq.ObtainedMark = 1;
                }
                eq.Answer = rblTrueFalse.SelectedValue;
            }
            #endregion

            #region Dr / Cr Questions
            else if (eq.QuestionType == (int)Enums.QuestionTypes.DrCr)
            {
                if (hfDrCr.Value == rblDrCr.SelectedValue)
                {
                    eq.ObtainedMark = 1;
                }
                eq.Answer = rblDrCr.SelectedValue;
            }
            #endregion

            #region Multiple Choice Questions
            else if (eq.QuestionType == (int)Enums.QuestionTypes.MCQ)
            {
                bool isTrue = true;
                string answer = string.Empty;
                foreach (GridViewRow rowAns in gvMultipleQUestionsAnswer.Rows)
                {
                    HiddenField hfIsAnswer = (HiddenField)rowAns.FindControl("hfIsAnswer");
                    CheckBox cbTrueFalse = (CheckBox)rowAns.FindControl("cbTrueFalse");

                    if (answer.Length == 0)
                        answer = cbTrueFalse.Checked.ToString();
                    else
                        answer += "," + cbTrueFalse.Checked.ToString();

                    if (bool.Parse(hfIsAnswer.Value) != cbTrueFalse.Checked)
                        isTrue = false;
                }
                if (isTrue)
                    eq.ObtainedMark = 1;

                eq.OutOfMark = 1;
                eq.Answer = answer;
            }
            #endregion

            #region Fill In The Blanks Quesions
            else if (eq.QuestionType == (int)Enums.QuestionTypes.FillInTheBlanks)
            {
                int q = 0, a = 0;
                string answer = string.Empty;
                foreach (GridViewRow row in gvFillIntheBlanksDetails.Rows)
                {
                    q++;
                    HiddenField hfAnswer = (HiddenField)row.FindControl("hfAnswer");
                    TextBox txtAnswer = (TextBox)row.FindControl("txtAnswer");
                    if (q == 1)
                    {
                        answer = txtAnswer.Text;
                    }
                    else
                        answer += "[#&#]" + txtAnswer.Text;
                    if (_isMatching(hfAnswer.Value, txtAnswer.Text))
                        a++;
                }
                eq.ObtainedMark = a;
                eq.OutOfMark = q;
                eq.Answer = answer;
            }
            #endregion

            questions[index] = eq;

            Session["questions"] = questions;
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvMultipleQUestionsAnswer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                Label lblSerial = (Label)e.Row.FindControl("lblSerial");
                lblSerial.Text = FormatNumberToWord(lblSerial.Text);
            }
            catch (Exception ex)
            {
            }
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

    private bool _isMatching(string text1, string text2)
    {
        bool isEqual = false;
        decimal number1, number2;
        try
        {
            if (text1.ToLower().Equals(text2.ToLower()))
                isEqual = true;
            else if (decimal.TryParse(text1, out number1) && decimal.TryParse(text2, out number2))
            {
                if (number1 == number2)
                    isEqual = true;
            }

            return isEqual;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    private void _hideAll()
    {
        try
        {
            phComprehension.Visible = false;

            phTrueFalse.Visible = false;
            rblTrueFalse.SelectedIndex = -1;
            phDrCr.Visible = false;
            rblDrCr.SelectedIndex = -1;

            phMCQ.Visible = false;
            phFillInTheBlanks.Visible = false;
        }
        catch (Exception ex)
        {
        }
    }

    #endregion

    #region Begin Exam Evaluation
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int q = 0, a = 0;
            List<ExamQuestion> questions = (List<ExamQuestion>)Session["questions"];
            foreach (ExamQuestion eq in questions)
            {
                q += eq.OutOfMark;
                a += eq.ObtainedMark;
            }

            lblTotalQuestion.Text = q.ToString();
            lblCorrectAnswer.Text = a.ToString();
            decimal accuracy = (decimal)a / (decimal)q * 100;
            lblAccuracy.Text = accuracy.ToString("0.00") + "%";
            _hideAll();
            //clkExamTime.Enabled = false;
            ddlQuestionNo.Enabled = false;
            phActions.Visible = false;
            phResult.Visible = true;
        }
        catch (Exception ex)
        {
        }
    }
    #endregion
}