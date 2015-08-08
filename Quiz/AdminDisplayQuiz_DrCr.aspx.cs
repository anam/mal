using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Quiz_AdminDisplayQuiz_DrCr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadCourse();
            _loadSubject(0);
            ChapterIDLoad(0, 0);

            Quiz_TrueFalseManager.LoadQuiz_TrueFalsePage(gvQuiz_TrueFalse, true, rptPager, 1, ddlPageSize, 0, 0, 0);
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

        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        int chapterID = Convert.ToInt32(ddlChapterID.SelectedValue);
        Quiz_TrueFalseManager.LoadQuiz_TrueFalsePage(gvQuiz_TrueFalse, true, rptPager, 1, ddlPageSize, courseID, subjectID, chapterID);
    }

    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        ChapterIDLoad(courseID, subjectID);

        int chapterID = Convert.ToInt32(ddlChapterID.SelectedValue);
        Quiz_TrueFalseManager.LoadQuiz_TrueFalsePage(gvQuiz_TrueFalse, true, rptPager, 1, ddlPageSize, courseID, subjectID, chapterID);
    }

    protected void ddlChapterID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
            int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
            int chapterID = Convert.ToInt32(ddlChapterID.SelectedValue);
            Quiz_TrueFalseManager.LoadQuiz_TrueFalsePage(gvQuiz_TrueFalse, true, rptPager, 1, ddlPageSize, courseID, subjectID, chapterID);
        }
        catch (Exception ex)
        {
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        int chapterID = Convert.ToInt32(ddlChapterID.SelectedValue);
        Quiz_TrueFalseManager.LoadQuiz_TrueFalsePage(gvQuiz_TrueFalse, true, rptPager, 1, ddlPageSize, courseID, subjectID, chapterID);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        int chapterID = Convert.ToInt32(ddlChapterID.SelectedValue);
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        Quiz_TrueFalseManager.LoadQuiz_TrueFalsePage(gvQuiz_TrueFalse, true, rptPager, pageIndex, ddlPageSize, courseID, subjectID, chapterID);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminQuiz_TrueFalse.aspx?ID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminQuiz_TrueFalse.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        int chapterID = Convert.ToInt32(ddlChapterID.SelectedValue);
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = Quiz_TrueFalseManager.DeleteQuiz_TrueFalse(Convert.ToInt32(linkButton.CommandArgument));
        Quiz_TrueFalseManager.LoadQuiz_TrueFalsePage(gvQuiz_TrueFalse, true, rptPager, 1, ddlPageSize, courseID, subjectID, chapterID);
    }

    protected void gvQuiz_TrueFalse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int comprehensionID = Convert.ToInt32(((HiddenField)e.Row.FindControl("hfComprehensionID")).Value);
                Label lblQuestionType = (Label)e.Row.FindControl("lblQuestionType");
                lblQuestionType.Text = comprehensionID > 0 ? "Comprehension" : "Non-Comprehension";

                HiddenField hfCourseID = (HiddenField)e.Row.FindControl("hfCourseID");
                Label lblCourseName = (Label)e.Row.FindControl("lblCourseName");
                lblCourseName.Text = STD_CourseManager.GetSTD_CourseByCourseID(Convert.ToInt32(hfCourseID.Value)).CourseName;

                HiddenField hfSubjectID = (HiddenField)e.Row.FindControl("hfSubjectID");
                Label lblSubjectName = (Label)e.Row.FindControl("lblSubjectName");
                lblSubjectName.Text = STD_SubjectManager.GetSTD_SubjectBySubjectID(Convert.ToInt32(hfSubjectID.Value)).SubjectName;

                HiddenField hfChapterID = (HiddenField)e.Row.FindControl("hfChapterID");
                Label lblChapterName = (Label)e.Row.FindControl("lblChapterName");
                lblChapterName.Text = Quiz_ChapterManager.GetQuiz_ChapterByChapterID(Convert.ToInt32(hfChapterID.Value)).ChapterName;
            }
        }
        catch (Exception ex)
        {
        }
    }
}