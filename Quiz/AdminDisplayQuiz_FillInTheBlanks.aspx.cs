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
 

public partial class AdminDisplayQuiz_FillInTheBlanks : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadCourse();
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

    private void loadData()
    {
        Quiz_FillInTheBlanksManager.LoadQuiz_FillInTheBlanksPageByChapterID(txtAnswerText.Text,int.Parse(ddlChapterID.SelectedValue),gvQuiz_FillInTheBlanks, rptPager, 1, ddlPageSize);
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
       Quiz_FillInTheBlanksManager.LoadQuiz_FillInTheBlanksPageByChapterID(txtAnswerText.Text,int.Parse(ddlChapterID.SelectedValue), gvQuiz_FillInTheBlanks,rptPager, 1, ddlPageSize);
    }
  protected void Page_Changed(object sender, EventArgs e)
    {
       int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
    Quiz_FillInTheBlanksManager.LoadQuiz_FillInTheBlanksPageByChapterID(txtAnswerText.Text,int.Parse(ddlChapterID.SelectedValue),gvQuiz_FillInTheBlanks, rptPager, pageIndex, ddlPageSize);
   }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminQuiz_FillInTheBlanks.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminQuiz_FillInTheBlanks.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = Quiz_FillInTheBlanksManager.DeleteQuiz_FillInTheBlanks(Convert.ToInt32(linkButton.CommandArgument));
       Quiz_FillInTheBlanksManager.LoadQuiz_FillInTheBlanksPageByChapterID(txtAnswerText.Text,int.Parse(ddlChapterID.SelectedValue),gvQuiz_FillInTheBlanks, rptPager, 1, ddlPageSize);
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

 
