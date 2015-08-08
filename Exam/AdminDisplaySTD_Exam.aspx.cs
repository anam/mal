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
 

public partial class AdminDisplaySTD_Exam : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
       STD_ExamManager.LoadSTD_ExamPage(gvSTD_Exam, rptPager, 1, ddlPageSize);
      }
    }
     protected void PageSize_Changed(object sender, EventArgs e)
    {
   STD_ExamManager.LoadSTD_ExamPage(gvSTD_Exam,rptPager, 1, ddlPageSize);
 }
  protected void Page_Changed(object sender, EventArgs e)
    {
       int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
    STD_ExamManager.LoadSTD_ExamPage(gvSTD_Exam, rptPager, pageIndex, ddlPageSize);
   }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminSTD_Exam.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminSTD_Exam.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
        STD_Exam exam = STD_ExamManager.GetSTD_ExamByExamID(Convert.ToInt32(linkButton.CommandArgument));
        exam.RowStatusID = 3;
        bool result = STD_ExamManager.UpdateSTD_Exam(exam);
        //bool result = STD_ExamManager.DeleteSTD_Exam(Convert.ToInt32(linkButton.CommandArgument));
       STD_ExamManager.LoadSTD_ExamPage(gvSTD_Exam, rptPager, 1, ddlPageSize);
  	}
}

