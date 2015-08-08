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
 

public partial class AdminDisplayQuiz_MultipleQuestion : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
        _loadCourse();
       
      }
    }

    private void loadData()
    {
        Quiz_MultipleQuestionManager.LoadQuiz_MultipleQuestionPageByChapterID(txtAnswerText.Text, int.Parse(ddlChapterID.SelectedValue), gvQuiz_MultipleQuestion, rptPager, 1, ddlPageSize);
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

    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        ChapterIDLoad(courseID, subjectID);
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
     protected void PageSize_Changed(object sender, EventArgs e)
    {
        Quiz_MultipleQuestionManager.LoadQuiz_MultipleQuestionPageByChapterID(txtAnswerText.Text,int.Parse(ddlChapterID.SelectedValue), gvQuiz_MultipleQuestion, rptPager, 1, ddlPageSize);
 }
  protected void Page_Changed(object sender, EventArgs e)
    {
       int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
       Quiz_MultipleQuestionManager.LoadQuiz_MultipleQuestionPageByChapterID(txtAnswerText.Text,int.Parse(ddlChapterID.SelectedValue), gvQuiz_MultipleQuestion, rptPager, pageIndex, ddlPageSize);
   }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminQuiz_MultipleQuestion.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminQuiz_MultipleQuestion.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = Quiz_MultipleQuestionManager.DeleteQuiz_MultipleQuestion(Convert.ToInt32(linkButton.CommandArgument));
        Quiz_MultipleQuestionManager.LoadQuiz_MultipleQuestionPageByChapterID(txtAnswerText.Text,int.Parse(ddlChapterID.SelectedValue), gvQuiz_MultipleQuestion, rptPager, 1, ddlPageSize);
  	}
    protected void gvQuiz_MultipleQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label   lblMultipleQustionID = (Label)e.Row.FindControl("lblMultipleQustionID");
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
    public  static  string    FormatNumberToWord(string number)

    {
        string value = string.Empty;
        switch (number)
        {
            case "1":
               value=  "a";
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
                break   ;
            case "7":
                value= "g";
                break;
            case "8":
                value=  "h";
                break;
            case "9":
                value=  "i";
                break;

        }
        return value;
    }
    protected void gvMultipleQUestionsAnswer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAnswerValue = (Label)e.Row.FindControl("lblAnswerValue");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnswerValue.Text == "True" ? "True" : "False";
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            lblSerial.Text = FormatNumberToWord(lblSerial.Text);
        }
    }
    protected void ddlChapterID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChapterID.SelectedIndex != 0)
        {
            loadData();
        }
    }

    protected void txtAnswerText_TextChanged(object sender, EventArgs e)
    {
        if (ddlChapterID.SelectedIndex != 0)
        {
            loadData();
        }
    }
}

