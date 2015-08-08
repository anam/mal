using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Quiz_ExamResultPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["questions"] != null)
                _loadQuestions();
        }
    }

    private void _loadQuestions()
    {
        try
        {
            List<ExamQuestion> questions = (List<ExamQuestion>)Session["questions"];

            gvQuestions.DataSource = questions;
            gvQuestions.DataBind();

            List<Quiz_TrueFalse> tfQuestions = new List<Quiz_TrueFalse>();
            List<Quiz_TrueFalse> drcrQuestions = new List<Quiz_TrueFalse>();
            List<Quiz_FillInTheBlanks> fitbQuestions = new List<Quiz_FillInTheBlanks>();
            List<Quiz_MultipleQuestion> mcqQuestions = new List<Quiz_MultipleQuestion>();

            foreach (ExamQuestion eq in questions)
            {
                if (eq.QuestionType == (int)Enums.QuestionTypes.TrueFalse)
                {
                    Quiz_TrueFalse tf = Quiz_TrueFalseManager.GetQuiz_TrueFalseByTrueFalseID(eq.QuestionNo);
                    tf.stAnswer = eq.Answer;
                    tf.Serial = questions.IndexOf(eq) + 1;
                    tfQuestions.Add(tf);
                }

                else if (eq.QuestionType == (int)Enums.QuestionTypes.DrCr)
                {
                    Quiz_TrueFalse drcr = Quiz_TrueFalseManager.GetQuiz_TrueFalseByTrueFalseID(eq.QuestionNo);
                    drcr.stAnswer = eq.Answer;
                    drcr.Serial = questions.IndexOf(eq) + 1;
                    drcrQuestions.Add(drcr);
                }

                else if (eq.QuestionType == (int)Enums.QuestionTypes.FillInTheBlanks)
                {
                    Quiz_FillInTheBlanks fitb = Quiz_FillInTheBlanksManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(eq.QuestionNo);
                    fitb.stAnswer = eq.Answer;
                    fitb.Serial = questions.IndexOf(eq) + 1;
                    fitbQuestions.Add(fitb);
                }
                else if (eq.QuestionType == (int)Enums.QuestionTypes.MCQ)
                {
                    Quiz_MultipleQuestion mcq = Quiz_MultipleQuestionManager.GetQuiz_MultipleQuestionByMultipleQustionID(eq.QuestionNo);
                    mcq.stAnswer = eq.Answer;
                    mcq.Serial = questions.IndexOf(eq) + 1;
                    mcqQuestions.Add(mcq);
                }
            }

            gvQuiz_TrueFalse.DataSource = tfQuestions;
            gvQuiz_TrueFalse.DataBind();

            gvQuiz_gvDrCr.DataSource = drcrQuestions;
            gvQuiz_gvDrCr.DataBind();

            gvQuiz_FillInTheBlanks.DataSource = fitbQuestions;
            gvQuiz_FillInTheBlanks.DataBind();

            gvQuiz_MultipleQuestion.DataSource = mcqQuestions;
            gvQuiz_MultipleQuestion.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvQuiz_TrueFalse_DataBound(object sender, EventArgs e)
    {
        try
        {
            GridView gv = (GridView)sender;
            foreach (GridViewRow row in gv.Rows)
            {
                HiddenField hfTrueFalseAnswer = (HiddenField)row.FindControl("hfTrueFalseAnswer");
                HiddenField hfUserAnswer = (HiddenField)row.FindControl("hfUserAnswer");
                RadioButtonList rblTrueFalse = (RadioButtonList)row.FindControl("rblTrueFalse");
                Label lblCorrectAnswer=(Label)row.FindControl("lblCorrectAnswer");
                Image imgResult = (Image)row.FindControl("imgResult");

                rblTrueFalse.SelectedValue = hfUserAnswer.Value;

                if (hfTrueFalseAnswer.Value == hfUserAnswer.Value)
                    imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/tick_mark.png";
                else
                {
                    imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/crossmark2.png";
                    lblCorrectAnswer.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvQuiz_gvDrCr_DataBound(object sender, EventArgs e)
    {
        try
        {
            GridView gv = (GridView)sender;
            foreach (GridViewRow row in gv.Rows)
            {
                HiddenField hfDrCrAnswer = (HiddenField)row.FindControl("hfDrCrAnswer");
                HiddenField hfUserAnswer = (HiddenField)row.FindControl("hfUserAnswer");
                RadioButtonList rblDrCr = (RadioButtonList)row.FindControl("rblDrCr");
                Label lblCorrectAnswer = (Label)row.FindControl("lblCorrectAnswer");
                Image imgResult = (Image)row.FindControl("imgResult");

                rblDrCr.SelectedValue = hfUserAnswer.Value;

                if (hfDrCrAnswer.Value == hfUserAnswer.Value)
                    imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/tick_mark.png";
                else
                {
                    imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/crossmark2.png";
                    lblCorrectAnswer.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
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

    protected void gvFillIntheBlanksDetails_DataBound(object sender, EventArgs e)
    {
        try
        {
            GridView gv = (GridView)sender;
            GridViewRow pRow = (GridViewRow)gv.NamingContainer;
            HiddenField hfFilledAnswer = (HiddenField)pRow.FindControl("hfFilledAnswer");
            string[] strAnswers = hfFilledAnswer.Value.Split(new string[] { "[#&#]" }, StringSplitOptions.None);
            foreach (GridViewRow row in gv.Rows)
            {
                HiddenField hfAnswer = (HiddenField)row.FindControl("hfAnswer");
                TextBox txtAnswer = (TextBox)row.FindControl("txtAnswer");
                Label lblCorrectAnswer = (Label)row.FindControl("lblCorrectAnswer");
                Image imgResult = (Image)row.FindControl("imgResult");

                if (row.RowIndex < strAnswers.Length)
                    txtAnswer.Text = strAnswers[row.RowIndex];
                else
                    txtAnswer.Text = "";

                if (_isMatching (hfAnswer.Value,txtAnswer.Text))
                    imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/tick_mark.png";
                else
                {
                    imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/crossmark2.png";
                    lblCorrectAnswer.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
        }
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

    protected void gvMultipleQUestionsAnswer_DataBound(object sender, EventArgs e)
    {
        try
        {
            bool isCorrect = true;
            GridView gv = (GridView)sender;
            GridViewRow pRow = (GridViewRow)gv.NamingContainer;
            HiddenField hfUserAnswers = (HiddenField)pRow.FindControl("hfUserAnswers");
            Image imgResult = (Image)pRow.FindControl("imgResult");
            string[] strAnswers = hfUserAnswers.Value.Split(',');
            foreach (GridViewRow row in gv.Rows)
            {
                CheckBox cbTrueFalse = (CheckBox)row.FindControl("cbTrueFalse");
                HiddenField hfIsAnswer = (HiddenField)row.FindControl("hfIsAnswer");
                TextBox txtAnswer = (TextBox)row.FindControl("txtAnswer");
                Label lblCorrectAnswer=(Label)row.FindControl("lblCorrectAnswer");

                if (row.RowIndex < strAnswers.Length && strAnswers[row.RowIndex].Length > 0)
                {
                    cbTrueFalse.Checked = bool.Parse(strAnswers[row.RowIndex]);


                    if (!(hfIsAnswer.Value == strAnswers[row.RowIndex]))
                    {
                        isCorrect = false;
                        lblCorrectAnswer.Visible = true;
                    }
                }
                else
                {
                    isCorrect = false;
                    lblCorrectAnswer.Visible = true;
                }

            }
            if(isCorrect)
                imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/tick_mark.png";
            else
                imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/crossmark2.png";
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvQuestions_DataBound(object sender, EventArgs e)
    {

    }

    //imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/tick_mark.png";
    //imgResult.ImageUrl = "~/App_Themes/CoffeyGreen/images/crossmark2.png";
}