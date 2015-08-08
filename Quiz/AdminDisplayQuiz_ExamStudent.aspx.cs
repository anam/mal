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
 

public partial class AdminDisplayQuiz_ExamStudent : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
       Quiz_ExamStudentManager.LoadQuiz_ExamStudentPageByStudent(gvQuiz_ExamStudent, rptPager, 1, ddlPageSize,Profile.card_id);
      }
    }
     protected void PageSize_Changed(object sender, EventArgs e)
    {
        Quiz_ExamStudentManager.LoadQuiz_ExamStudentPageByStudent(gvQuiz_ExamStudent, rptPager, 1, ddlPageSize, Profile.card_id);
 }
  protected void Page_Changed(object sender, EventArgs e)
    {
       int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
       Quiz_ExamStudentManager.LoadQuiz_ExamStudentPageByStudent(gvQuiz_ExamStudent, rptPager, pageIndex, ddlPageSize, Profile.card_id);
   }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminQuiz_ExamStudent.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminQuiz_ExamStudent.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = Quiz_ExamStudentManager.DeleteQuiz_ExamStudent(Convert.ToInt32(linkButton.CommandArgument));
        Quiz_ExamStudentManager.LoadQuiz_ExamStudentPageByStudent(gvQuiz_ExamStudent, rptPager, 1, ddlPageSize, Profile.card_id);
  	}
}

