using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ComprehensionQuestionManager
{
	public STD_ComprehensionQuestionManager()
	{
	}

    public static DataSet  GetAllSTD_ComprehensionQuestions()
    {
       DataSet sTD_ComprehensionQuestions = new DataSet();
        SqlSTD_ComprehensionQuestionProvider sqlSTD_ComprehensionQuestionProvider = new SqlSTD_ComprehensionQuestionProvider();
        sTD_ComprehensionQuestions = sqlSTD_ComprehensionQuestionProvider.GetAllSTD_ComprehensionQuestions();
        return sTD_ComprehensionQuestions;
    }

	public static void sTD_ComprehensionQuestionsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
		{
		double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
		int pageCount = (int)Math.Ceiling(dblPageCount);
		List<ListItem> pages = new List<ListItem>();
		if (pageCount > 0)
		{
 		pages.Add(new ListItem("First", "1", currentPage > 1));
		for (int i = 1; i <= pageCount; i++)
		{
		 pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
		}
		pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
		}
		rptPager.DataSource = pages;
		rptPager.DataBind();
		}
 	public static void LoadSTD_ComprehensionQuestionPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ComprehensionQuestionProvider sqlSTD_ComprehensionQuestionProvider = new SqlSTD_ComprehensionQuestionProvider();
		DataSet ds =  sqlSTD_ComprehensionQuestionProvider.GetSTD_ComprehensionQuestionPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ComprehensionQuestionsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_ComprehensionQuestion()
    {
       DataSet sTD_ComprehensionQuestions = new DataSet();
        SqlSTD_ComprehensionQuestionProvider sqlSTD_ComprehensionQuestionProvider = new SqlSTD_ComprehensionQuestionProvider();
        sTD_ComprehensionQuestions = sqlSTD_ComprehensionQuestionProvider.GetDropDownListAllSTD_ComprehensionQuestion();
        return sTD_ComprehensionQuestions;
    }


    public static STD_ComprehensionQuestion GetSTD_QuestionByQuestionID(int QuestionID)
    {
        STD_ComprehensionQuestion sTD_ComprehensionQuestion = new STD_ComprehensionQuestion();
        SqlSTD_ComprehensionQuestionProvider sqlSTD_ComprehensionQuestionProvider = new SqlSTD_ComprehensionQuestionProvider();
        sTD_ComprehensionQuestion = sqlSTD_ComprehensionQuestionProvider.GetSTD_ComprehensionQuestionByQuestionID(QuestionID);
        return sTD_ComprehensionQuestion;
    }


    public static STD_ComprehensionQuestion GetSTD_ComprehensionByComprehensionID(int ComprehensionID)
    {
        STD_ComprehensionQuestion sTD_ComprehensionQuestion = new STD_ComprehensionQuestion();
        SqlSTD_ComprehensionQuestionProvider sqlSTD_ComprehensionQuestionProvider = new SqlSTD_ComprehensionQuestionProvider();
        sTD_ComprehensionQuestion = sqlSTD_ComprehensionQuestionProvider.GetSTD_ComprehensionQuestionByComprehensionID(ComprehensionID);
        return sTD_ComprehensionQuestion;
    }


    public static STD_ComprehensionQuestion GetSTD_ComprehensionQuestionByComprehensionQuestionID(int ComprehensionQuestionID)
    {
        STD_ComprehensionQuestion sTD_ComprehensionQuestion = new STD_ComprehensionQuestion();
        SqlSTD_ComprehensionQuestionProvider sqlSTD_ComprehensionQuestionProvider = new SqlSTD_ComprehensionQuestionProvider();
        sTD_ComprehensionQuestion = sqlSTD_ComprehensionQuestionProvider.GetSTD_ComprehensionQuestionByComprehensionQuestionID(ComprehensionQuestionID);
        return sTD_ComprehensionQuestion;
    }


    public static int InsertSTD_ComprehensionQuestion(STD_ComprehensionQuestion sTD_ComprehensionQuestion)
    {
        SqlSTD_ComprehensionQuestionProvider sqlSTD_ComprehensionQuestionProvider = new SqlSTD_ComprehensionQuestionProvider();
        return sqlSTD_ComprehensionQuestionProvider.InsertSTD_ComprehensionQuestion(sTD_ComprehensionQuestion);
    }


    public static bool UpdateSTD_ComprehensionQuestion(STD_ComprehensionQuestion sTD_ComprehensionQuestion)
    {
        SqlSTD_ComprehensionQuestionProvider sqlSTD_ComprehensionQuestionProvider = new SqlSTD_ComprehensionQuestionProvider();
        return sqlSTD_ComprehensionQuestionProvider.UpdateSTD_ComprehensionQuestion(sTD_ComprehensionQuestion);
    }

    public static bool DeleteSTD_ComprehensionQuestion(int sTD_ComprehensionQuestionID)
    {
        SqlSTD_ComprehensionQuestionProvider sqlSTD_ComprehensionQuestionProvider = new SqlSTD_ComprehensionQuestionProvider();
        return sqlSTD_ComprehensionQuestionProvider.DeleteSTD_ComprehensionQuestion(sTD_ComprehensionQuestionID);
    }
}

