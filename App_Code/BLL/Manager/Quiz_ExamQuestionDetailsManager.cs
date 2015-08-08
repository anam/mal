using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_ExamQuestionDetailsManager
{
	public Quiz_ExamQuestionDetailsManager()
	{
	}

    public static DataSet  GetAllQuiz_ExamQuestionDetailss()
    {
       DataSet quiz_ExamQuestionDetailss = new DataSet();
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        quiz_ExamQuestionDetailss = sqlQuiz_ExamQuestionDetailsProvider.GetAllQuiz_ExamQuestionDetailss();
        return quiz_ExamQuestionDetailss;
    }

	public static void quiz_ExamQuestionDetailssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadQuiz_ExamQuestionDetailsPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
		DataSet ds =  sqlQuiz_ExamQuestionDetailsProvider.GetQuiz_ExamQuestionDetailsPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_ExamQuestionDetailssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllQuiz_ExamQuestionDetails()
    {
       DataSet quiz_ExamQuestionDetailss = new DataSet();
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        quiz_ExamQuestionDetailss = sqlQuiz_ExamQuestionDetailsProvider.GetDropDownLisAllQuiz_ExamQuestionDetails();
        return quiz_ExamQuestionDetailss;
    }

    public static DataSet   GetAllQuiz_ExamQuestionDetailssWithRelation()
    {
       DataSet quiz_ExamQuestionDetailss = new DataSet();
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        quiz_ExamQuestionDetailss = sqlQuiz_ExamQuestionDetailsProvider.GetAllQuiz_ExamQuestionDetailss();
        return quiz_ExamQuestionDetailss;
    }


    public static List<Quiz_ExamQuestionDetails> GetQuiz_ExamQuestiondetailsByExamID(int ExamID)
    {
        List<Quiz_ExamQuestionDetails> quiz_ExamQuestionDetails = new List<Quiz_ExamQuestionDetails>();
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        quiz_ExamQuestionDetails = sqlQuiz_ExamQuestionDetailsProvider.GetQuiz_ExamQuestionDetailsByExamID(ExamID);
        return quiz_ExamQuestionDetails;
    }

    public static DataSet GetQuiz_ExamQuestiondetailsByQuestionID(int questionNo,int questionType)
    {
        DataSet quiz_ExamQuestionDetails = new DataSet();
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        quiz_ExamQuestionDetails = sqlQuiz_ExamQuestionDetailsProvider.GetQuiz_ExamQuestionDetailsByQuestionID(questionNo,questionType);
        return quiz_ExamQuestionDetails;
    }

    public static Quiz_ExamQuestionDetails GetQuiz_ExamQuestionDetailsByExamQuestionDetailsID(int ExamQuestionDetailsID)
    {
        Quiz_ExamQuestionDetails quiz_ExamQuestionDetails = new Quiz_ExamQuestionDetails();
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        quiz_ExamQuestionDetails = sqlQuiz_ExamQuestionDetailsProvider.GetQuiz_ExamQuestionDetailsByExamQuestionDetailsID(ExamQuestionDetailsID);
        return quiz_ExamQuestionDetails;
    }


    public static int InsertQuiz_ExamQuestionDetails(Quiz_ExamQuestionDetails quiz_ExamQuestionDetails)
    {
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        return sqlQuiz_ExamQuestionDetailsProvider.InsertQuiz_ExamQuestionDetails(quiz_ExamQuestionDetails);
    }


    public static bool UpdateQuiz_ExamQuestionDetails(Quiz_ExamQuestionDetails quiz_ExamQuestionDetails)
    {
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        return sqlQuiz_ExamQuestionDetailsProvider.UpdateQuiz_ExamQuestionDetails(quiz_ExamQuestionDetails);
    }

    public static bool DeleteQuiz_ExamQuestionDetails(int quiz_ExamQuestionDetailsID)
    {
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        return sqlQuiz_ExamQuestionDetailsProvider.DeleteQuiz_ExamQuestionDetails(quiz_ExamQuestionDetailsID);
    }

    public static bool DeleteQuiz_ExamQuestionDetails(Quiz_ExamQuestionDetails quiz_ExamQuestionDetails)
    {
        SqlQuiz_ExamQuestionDetailsProvider sqlQuiz_ExamQuestionDetailsProvider = new SqlQuiz_ExamQuestionDetailsProvider();
        return sqlQuiz_ExamQuestionDetailsProvider.DeleteQuiz_ExamQuestionDetails(quiz_ExamQuestionDetails);
    }
}

