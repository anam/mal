using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_MultipleQuestionDetailsManager
{
	public Quiz_MultipleQuestionDetailsManager()
	{
	}

    public static DataSet  GetAllQuiz_MultipleQuestionDetailss()
    {
       DataSet quiz_MultipleQuestionDetailss = new DataSet();
        SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
        quiz_MultipleQuestionDetailss = sqlQuiz_MultipleQuestionDetailsProvider.GetAllQuiz_MultipleQuestionDetailss();
        return quiz_MultipleQuestionDetailss;
    }

	public static void quiz_MultipleQuestionDetailssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadQuiz_MultipleQuestionDetailsPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
		DataSet ds =  sqlQuiz_MultipleQuestionDetailsProvider.GetQuiz_MultipleQuestionDetailsPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_MultipleQuestionDetailssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllQuiz_MultipleQuestionDetails()
    {
       DataSet quiz_MultipleQuestionDetailss = new DataSet();
        SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
        quiz_MultipleQuestionDetailss = sqlQuiz_MultipleQuestionDetailsProvider.GetDropDownLisAllQuiz_MultipleQuestionDetails();
        return quiz_MultipleQuestionDetailss;
    }

    public static DataSet   GetAllQuiz_MultipleQuestionDetailssWithRelation()
    {
       DataSet quiz_MultipleQuestionDetailss = new DataSet();
        SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
        quiz_MultipleQuestionDetailss = sqlQuiz_MultipleQuestionDetailsProvider.GetAllQuiz_MultipleQuestionDetailss();
        return quiz_MultipleQuestionDetailss;
    }


    public static Quiz_MultipleQuestionDetails GetQuiz_MultipleQustionByMultipleQustionID(int MultipleQustionID)
    {
        Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails = new Quiz_MultipleQuestionDetails();
        SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
        quiz_MultipleQuestionDetails = sqlQuiz_MultipleQuestionDetailsProvider.GetQuiz_MultipleQuestionDetailsByMultipleQustionID(MultipleQustionID);
        return quiz_MultipleQuestionDetails;
    }

    public static DataSet GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID(int MultipleQustionID)
    {
       DataSet quiz_MultipleQuestionDetailss = new DataSet();
        SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
        quiz_MultipleQuestionDetailss = sqlQuiz_MultipleQuestionDetailsProvider.GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID(MultipleQustionID);
        return quiz_MultipleQuestionDetailss;
    }
    public static Quiz_MultipleQuestionDetails GetQuiz_MultipleQuestionDetailsByMultipleQuestionDetailsID(int MultipleQuestionDetailsID)
    {
        Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails = new Quiz_MultipleQuestionDetails();
        SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
        quiz_MultipleQuestionDetails = sqlQuiz_MultipleQuestionDetailsProvider.GetQuiz_MultipleQuestionDetailsByMultipleQuestionDetailsID(MultipleQuestionDetailsID);
        return quiz_MultipleQuestionDetails;
    }


    public static int InsertQuiz_MultipleQuestionDetails(Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails)
    {
        SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
        return sqlQuiz_MultipleQuestionDetailsProvider.InsertQuiz_MultipleQuestionDetails(quiz_MultipleQuestionDetails);
    }


    public static bool UpdateQuiz_MultipleQuestionDetails(Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails)
    {
        SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
        return sqlQuiz_MultipleQuestionDetailsProvider.UpdateQuiz_MultipleQuestionDetails(quiz_MultipleQuestionDetails);
    }

    public static bool DeleteQuiz_MultipleQuestionDetails(int quiz_MultipleQuestionDetailsID)
    {
        SqlQuiz_MultipleQuestionDetailsProvider sqlQuiz_MultipleQuestionDetailsProvider = new SqlQuiz_MultipleQuestionDetailsProvider();
        return sqlQuiz_MultipleQuestionDetailsProvider.DeleteQuiz_MultipleQuestionDetails(quiz_MultipleQuestionDetailsID);
    }
}

