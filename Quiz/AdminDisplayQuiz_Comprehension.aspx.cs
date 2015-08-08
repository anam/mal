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
 

public partial class AdminDisplayQuiz_Comprehension : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Quiz_ComprehensionManager.LoadQuiz_ComprehensionPage(gvQuiz_Comprehension, rptPager, 1, ddlPageSize);
        }
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        Quiz_ComprehensionManager.LoadQuiz_ComprehensionPage(gvQuiz_Comprehension,rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        Quiz_ComprehensionManager.LoadQuiz_ComprehensionPage(gvQuiz_Comprehension, rptPager, pageIndex, ddlPageSize);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminQuiz_Comprehension.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminQuiz_Comprehension.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = Quiz_ComprehensionManager.DeleteQuiz_Comprehension(Convert.ToInt32(linkButton.CommandArgument));
       Quiz_ComprehensionManager.LoadQuiz_ComprehensionPage(gvQuiz_Comprehension, rptPager, 1, ddlPageSize);
  	}
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

            DataSet dsDrCr =  Quiz_TrueFalseManager.GetQuiz_DrCrByComprehensionID(int.Parse(lblComprehensionID.Text));
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
            Label lblAnswerValue = (Label)e.Row.FindControl("lblAnswerValue");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnswerValue.Text == "True" ? "True" : "False";
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

    //gvQuiz_TrueFalse_RowDataBound
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
}

