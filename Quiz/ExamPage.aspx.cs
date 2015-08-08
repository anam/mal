using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Quiz_ExamPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<ExamQuestion> questions = new List<ExamQuestion>();
        int questionNo = 0;
        if (!IsPostBack)
        {
            if (Request.QueryString["ExamID"] != null)
            {
                _loadExamNames(int.Parse(Request.QueryString["ExamID"]));
                divExam.Visible = false;
            }
            else
            {
                ChapterIDLoad(0, 0);
                _loadExamNames(0, 0, 0);
                _loadCourse();
                _loadSubject(0);
            }
        }



        if (questions.Count > 0 && questionNo > 0)
        {
            ////_loadQuestion(questionNo - 1);
            //phExamHeader.Visible = true;
            //_loadQuestionList();
            //phActions.Visible = true;
        }
    }

    private void ChapterIDLoad(int courseID, int subjectID)
    {
        try
        {
            DataSet ds = Quiz_ChapterManager.GetDropDownListAllQuiz_Chapter(courseID, subjectID);
            ddlChapterID.DataValueField = "ChapterID";
            ddlChapterID.DataTextField = "ChapterName";
            ddlChapterID.DataSource = ds.Tables[0];
            ddlChapterID.DataBind();
            //ddlChapterID.Items.Insert(0, new ListItem("...Select Chapter...", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void _loadExamNames(int courseID, int subjectID, int chapterID)
    {
        try
        {
            //DataSet examSet = Quiz_ExamManager.GetDropDownListAllQuiz_Exam(courseID, subjectID, chapterID);
            DataSet examSet = Quiz_ExamManager.GetHR_SubjectBySubjectID(subjectID);
            
            ddlExamNames.DataValueField = "ExamID";
            ddlExamNames.DataTextField = "ExamName";
            ddlExamNames.DataSource = examSet;
            ddlExamNames.DataBind();

            ddlExamNames.Items.Insert(0, new ListItem("...Select Exam...", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void _loadExamNames(int ExamID)
    {
        try
        {
            //DataSet examSet = Quiz_ExamManager.GetDropDownListAllQuiz_Exam(courseID, subjectID, chapterID);
            DataSet examSet = Quiz_ExamManager.GetQuiz_ExamByExamIDDataset(ExamID);

            ddlExamNames.DataValueField = "ExamID";
            ddlExamNames.DataTextField = "ExamName";
            ddlExamNames.DataSource = examSet;
            ddlExamNames.DataBind();

        }
        catch (Exception ex)
        {
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
        ChapterIDLoad(courseID, subjectID);
        _loadExamNames(0, subjectID, 0);
    }

    protected void ddlChapterID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
            int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
            int chapterID = Convert.ToInt32(ddlChapterID.SelectedValue);

            _loadExamNames(courseID, subjectID, chapterID);
        }
        catch (Exception ex)
        {
        }
    }

    protected void ddlExamNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Quiz_Exam exam = Quiz_ExamManager.GetQuiz_ExamByExamID(Convert.ToInt32(ddlExamNames.SelectedValue));
            lblExamName.Text = exam.ExamName;
            lblExamHour.Text = (exam.ExamTimeDuration / 60).ToString() + ":" + (exam.ExamTimeDuration % 60).ToString("00") + ":00";
            Session["examTime"] = exam.ExamTimeDuration;
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        try
        {
            btnStart.Visible = false;
            List<ExamQuestion> questions = new List<ExamQuestion>();

            int examID = Convert.ToInt32(ddlExamNames.SelectedValue);
            List<Quiz_ExamQuestionDetails> questionDetails = Quiz_ExamQuestionDetailsManager.GetQuiz_ExamQuestiondetailsByExamID(examID);
            if (questionDetails.Count > 0)
            {
                phExamHeader.Visible = true;
                phActions.Visible = true;
                foreach (Quiz_ExamQuestionDetails eqd in questionDetails)
                {
                    if (eqd.QuestionType == (int)Enums.QuestionTypes.Comprehension)
                    {
                        #region True False Questions
                        List<Quiz_TrueFalse> tfQuestions = Quiz_TrueFalseManager.GetQuiz_TrueFalseListByComprehensionID(eqd.QuestionNo);
                        foreach (Quiz_TrueFalse tfq in tfQuestions)
                        {
                            ExamQuestion eq = new ExamQuestion();
                            eq.QuestionType = (int)Enums.QuestionTypes.TrueFalse;
                            eq.QuestionNo = tfq.TrueFalseID;
                            eq.ComprehensionID = tfq.ComprehensionID;
                            questions.Add(eq);
                        }
                        #endregion

                        #region Dr/ Cr Questions
                        List<Quiz_TrueFalse> drcrQuestions = Quiz_TrueFalseManager.GetQuiz_DrCrListByComprehensionID(eqd.QuestionNo);
                        foreach (Quiz_TrueFalse drcrQ in drcrQuestions)
                        {
                            ExamQuestion eq = new ExamQuestion();
                            eq.QuestionType = (int)Enums.QuestionTypes.DrCr;
                            eq.QuestionNo = drcrQ.TrueFalseID;
                            eq.ComprehensionID = drcrQ.ComprehensionID;
                            questions.Add(eq);
                        }
                        #endregion

                        #region Multiple Choice Questions
                        List<Quiz_MultipleQuestion> mcqQuestions = Quiz_MultipleQuestionManager.GetQuiz_MultipleQuestionListByComprehensionID(eqd.QuestionNo);
                        foreach (Quiz_MultipleQuestion mcq in mcqQuestions)
                        {
                            ExamQuestion eq = new ExamQuestion();
                            eq.QuestionType = (int)Enums.QuestionTypes.FillInTheBlanks;
                            eq.QuestionNo = mcq.MultipleQustionID;
                            eq.ComprehensionID = mcq.ComprehensionID;
                            questions.Add(eq);
                        }
                        #endregion

                        #region Fill In The Blanks
                        List<Quiz_FillInTheBlanks> fitbQuestions = Quiz_FillInTheBlanksManager.GetQuiz_FillInTheBlankListByComprehensionID(eqd.QuestionNo);
                        foreach (Quiz_FillInTheBlanks fitb in fitbQuestions)
                        {
                            ExamQuestion eq = new ExamQuestion();
                            eq.QuestionType = (int)Enums.QuestionTypes.FillInTheBlanks;
                            eq.QuestionNo = fitb.FillInTheBlanksID;
                            eq.ComprehensionID = fitb.ComprehensionID;
                            questions.Add(eq);
                        }
                        #endregion

                    }
                    else
                    {
                        ExamQuestion eq = new ExamQuestion();
                        eq.QuestionType = eqd.QuestionType;
                        eq.QuestionNo = eqd.QuestionNo;
                        eq.ComprehensionID = 0;
                        questions.Add(eq);
                    }
                }

                Session["questions"] = questions;
                Session["totalQuestion"] = questions.Count;
                _loadQuestionList();
                Session["questionNo"] = 1;
                _loadQuestion(0);
                btnSubmit.Visible = true;
                clkExamTime.Enabled = true;
                Session["startTime"] = DateTime.Now;

                
            }
            else
            {
                phExamHeader.Visible = false;
                phActions.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void clkExamTime_Tick(object sender, EventArgs e)
    {
        try
        {
            TimeSpan examTime = new TimeSpan(0, Convert.ToInt32(Session["examTime"].ToString()), 0);
            TimeSpan timeSpent = DateTime.Now.Subtract(Convert.ToDateTime(Session["startTime"].ToString()));

            TimeSpan timeLeft = examTime.Subtract(timeSpent);
            lblExamHour.Text = "<h1>" + timeLeft.Hours.ToString("00") + ":" + timeLeft.Minutes.ToString("00") + ":" + timeLeft.Seconds.ToString("00") + "</h1>";
            if (timeLeft.TotalSeconds <= 0)
            {
                clkExamTime.Enabled = false;
                //btnSubmit_Click(sender, new EventArgs());
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
            clkExamTime.Enabled = false;
            ddlQuestionNo.Enabled = false;
            phActions.Visible = false;
            phResult.Visible = true;
            if (Request.QueryString["ExamID"] != null)
            {
                btnSubmit.Visible = false;
            }
            
            if (Request.QueryString["StudentID"] != null)
            {
                //insert Exam Details
                STD_ExamDetailsStudent sTD_ExamDetailsStudent = new STD_ExamDetailsStudent();
                sTD_ExamDetailsStudent.ExamDetailsStudentName = "Exam Student";
                sTD_ExamDetailsStudent.ExamDetailsID = int.Parse(Request.QueryString["ExamDetailsID"]);
                sTD_ExamDetailsStudent.StudentID = Request.QueryString["StudentID"];
                sTD_ExamDetailsStudent.ObtainedMark = decimal.Parse(lblCorrectAnswer.Text);

                sTD_ExamDetailsStudent.ExtraField1 = "";
                sTD_ExamDetailsStudent.ExtraField2 = "";
                sTD_ExamDetailsStudent.ExtraField3 = "";
                sTD_ExamDetailsStudent.ExtraField4 = "";
                sTD_ExamDetailsStudent.ExtraField5 = "";
                sTD_ExamDetailsStudent.AddedBy = Profile.card_id;
                sTD_ExamDetailsStudent.AddedDate = DateTime.Now;
                sTD_ExamDetailsStudent.UpdatedBy = Profile.card_id;
                sTD_ExamDetailsStudent.UpdatedDate = DateTime.Now;
                sTD_ExamDetailsStudent.RowStatusID = 1;
                int resutl = STD_ExamDetailsStudentManager.InsertSTD_ExamDetailsStudent(sTD_ExamDetailsStudent);

                bool result = Quiz_ExamStudentManager.RowStatusQuiz_ExamStudent(Convert.ToInt32(Request.QueryString["ExamStudentID"]),13);//13=Exam Given
            }
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
}