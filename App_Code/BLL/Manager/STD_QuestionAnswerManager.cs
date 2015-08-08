using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_QuestionAnswerManager
{
	public STD_QuestionAnswerManager()
	{
	}

    public static DataSet  GetAllSTD_QuestionAnswers()
    {
       DataSet sTD_QuestionAnswers = new DataSet();
        SqlSTD_QuestionAnswerProvider sqlSTD_QuestionAnswerProvider = new SqlSTD_QuestionAnswerProvider();
        sTD_QuestionAnswers = sqlSTD_QuestionAnswerProvider.GetAllSTD_QuestionAnswers();
        return sTD_QuestionAnswers;
    }

	public static void sTD_QuestionAnswersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_QuestionAnswerPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_QuestionAnswerProvider sqlSTD_QuestionAnswerProvider = new SqlSTD_QuestionAnswerProvider();
		DataSet ds =  sqlSTD_QuestionAnswerProvider.GetSTD_QuestionAnswerPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_QuestionAnswersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_QuestionAnswer()
    {
       DataSet sTD_QuestionAnswers = new DataSet();
        SqlSTD_QuestionAnswerProvider sqlSTD_QuestionAnswerProvider = new SqlSTD_QuestionAnswerProvider();
        sTD_QuestionAnswers = sqlSTD_QuestionAnswerProvider.GetDropDownListAllSTD_QuestionAnswer();
        return sTD_QuestionAnswers;
    }

    public static DataSet   GetAllSTD_QuestionAnswersWithRelation()
    {
       DataSet sTD_QuestionAnswers = new DataSet();
        SqlSTD_QuestionAnswerProvider sqlSTD_QuestionAnswerProvider = new SqlSTD_QuestionAnswerProvider();
        sTD_QuestionAnswers = sqlSTD_QuestionAnswerProvider.GetAllSTD_QuestionAnswers();
        return sTD_QuestionAnswers;
    }


    public static STD_QuestionAnswer GetSTD_QuestionByQuestionID(int QuestionID)
    {
        STD_QuestionAnswer sTD_QuestionAnswer = new STD_QuestionAnswer();
        SqlSTD_QuestionAnswerProvider sqlSTD_QuestionAnswerProvider = new SqlSTD_QuestionAnswerProvider();
        sTD_QuestionAnswer = sqlSTD_QuestionAnswerProvider.GetSTD_QuestionAnswerByQuestionID(QuestionID);
        return sTD_QuestionAnswer;
    }


    public static STD_QuestionAnswer GetSTD_QuestionAnswerByQuestionAnswerID(int QuestionAnswerID)
    {
        STD_QuestionAnswer sTD_QuestionAnswer = new STD_QuestionAnswer();
        SqlSTD_QuestionAnswerProvider sqlSTD_QuestionAnswerProvider = new SqlSTD_QuestionAnswerProvider();
        sTD_QuestionAnswer = sqlSTD_QuestionAnswerProvider.GetSTD_QuestionAnswerByQuestionAnswerID(QuestionAnswerID);
        return sTD_QuestionAnswer;
    }


    public static int InsertSTD_QuestionAnswer(STD_QuestionAnswer sTD_QuestionAnswer)
    {
        SqlSTD_QuestionAnswerProvider sqlSTD_QuestionAnswerProvider = new SqlSTD_QuestionAnswerProvider();
        return sqlSTD_QuestionAnswerProvider.InsertSTD_QuestionAnswer(sTD_QuestionAnswer);
    }


    public static bool UpdateSTD_QuestionAnswer(STD_QuestionAnswer sTD_QuestionAnswer)
    {
        SqlSTD_QuestionAnswerProvider sqlSTD_QuestionAnswerProvider = new SqlSTD_QuestionAnswerProvider();
        return sqlSTD_QuestionAnswerProvider.UpdateSTD_QuestionAnswer(sTD_QuestionAnswer);
    }

    public static bool DeleteSTD_QuestionAnswer(int sTD_QuestionAnswerID)
    {
        SqlSTD_QuestionAnswerProvider sqlSTD_QuestionAnswerProvider = new SqlSTD_QuestionAnswerProvider();
        return sqlSTD_QuestionAnswerProvider.DeleteSTD_QuestionAnswer(sTD_QuestionAnswerID);
    }
}

