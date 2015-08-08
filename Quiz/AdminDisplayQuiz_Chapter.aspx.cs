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
 

public partial class AdminDisplayQuiz_Chapter : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
       Quiz_ChapterManager.LoadQuiz_ChapterPage(gvQuiz_Chapter, rptPager, 1, ddlPageSize);
      }
    }
     protected void PageSize_Changed(object sender, EventArgs e)
    {
   Quiz_ChapterManager.LoadQuiz_ChapterPage(gvQuiz_Chapter,rptPager, 1, ddlPageSize);
 }
  protected void Page_Changed(object sender, EventArgs e)
    {
       int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
    Quiz_ChapterManager.LoadQuiz_ChapterPage(gvQuiz_Chapter, rptPager, pageIndex, ddlPageSize);
   }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminQuiz_Chapter.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminQuiz_Chapter.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = Quiz_ChapterManager.DeleteQuiz_Chapter(Convert.ToInt32(linkButton.CommandArgument));
       Quiz_ChapterManager.LoadQuiz_ChapterPage(gvQuiz_Chapter, rptPager, 1, ddlPageSize);
  	}

    protected void gvQuiz_Chapter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfCourseID = (HiddenField)e.Row.FindControl("hfCourseID");
                Label lblCourseName = (Label)e.Row.FindControl("lblCourseName");
                lblCourseName.Text = STD_CourseManager.GetSTD_CourseByCourseID(Convert.ToInt32(hfCourseID.Value)).CourseName;

                HiddenField hfSubjectID = (HiddenField)e.Row.FindControl("hfSubjectID");
                Label lblSubjectName = (Label)e.Row.FindControl("lblSubjectName");
                lblSubjectName.Text = STD_SubjectManager.GetSTD_SubjectBySubjectID(Convert.ToInt32(hfSubjectID.Value)).SubjectName;
            }
        }
        catch (Exception ex)
        {
        }
    }
}

