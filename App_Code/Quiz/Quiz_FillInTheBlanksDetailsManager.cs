using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_FillInTheBlanksDetailsManager
{
	public Quiz_FillInTheBlanksDetailsManager()
	{
	}

    public static DataSet  GetAllQuiz_FillInTheBlanksDetailss()
    {
       DataSet quiz_FillInTheBlanksDetailss = new DataSet();
        SqlQuiz_FillInTheBlanksDetailsProvider sqlQuiz_FillInTheBlanksDetailsProvider = new SqlQuiz_FillInTheBlanksDetailsProvider();
        quiz_FillInTheBlanksDetailss = sqlQuiz_FillInTheBlanksDetailsProvider.GetAllQuiz_FillInTheBlanksDetailss();
        return quiz_FillInTheBlanksDetailss;
    }

	public static void quiz_FillInTheBlanksDetailssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadQuiz_FillInTheBlanksDetailsPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_FillInTheBlanksDetailsProvider sqlQuiz_FillInTheBlanksDetailsProvider = new SqlQuiz_FillInTheBlanksDetailsProvider();
		DataSet ds =  sqlQuiz_FillInTheBlanksDetailsProvider.GetQuiz_FillInTheBlanksDetailsPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_FillInTheBlanksDetailssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllQuiz_FillInTheBlanksDetails()
    {
       DataSet quiz_FillInTheBlanksDetailss = new DataSet();
        SqlQuiz_FillInTheBlanksDetailsProvider sqlQuiz_FillInTheBlanksDetailsProvider = new SqlQuiz_FillInTheBlanksDetailsProvider();
        quiz_FillInTheBlanksDetailss = sqlQuiz_FillInTheBlanksDetailsProvider.GetDropDownLisAllQuiz_FillInTheBlanksDetails();
        return quiz_FillInTheBlanksDetailss;
    }

    public static DataSet   GetAllQuiz_FillInTheBlanksDetailssWithRelation()
    {
       DataSet quiz_FillInTheBlanksDetailss = new DataSet();
        SqlQuiz_FillInTheBlanksDetailsProvider sqlQuiz_FillInTheBlanksDetailsProvider = new SqlQuiz_FillInTheBlanksDetailsProvider();
        quiz_FillInTheBlanksDetailss = sqlQuiz_FillInTheBlanksDetailsProvider.GetAllQuiz_FillInTheBlanksDetailss();
        return quiz_FillInTheBlanksDetailss;
    }

    public static DataSet GetQuiz_FillInTheBlanksByFillInTheBlanksID(int ID)
    {
        DataSet quiz_FillInTheBlanksDetailss = new DataSet();
        SqlQuiz_FillInTheBlanksDetailsProvider sqlQuiz_FillInTheBlanksDetailsProvider = new SqlQuiz_FillInTheBlanksDetailsProvider();
        quiz_FillInTheBlanksDetailss = sqlQuiz_FillInTheBlanksDetailsProvider.GetQuiz_FillInTheBlanksByFillInTheBlanksID(ID);
        return quiz_FillInTheBlanksDetailss;
    }
    


    public static Quiz_FillInTheBlanksDetails GetQuiz_FillInTheBlanksDetailsByFillInTheBlanksDetailsID(int FillInTheBlanksDetailsID)
    {
        Quiz_FillInTheBlanksDetails quiz_FillInTheBlanksDetails = new Quiz_FillInTheBlanksDetails();
        SqlQuiz_FillInTheBlanksDetailsProvider sqlQuiz_FillInTheBlanksDetailsProvider = new SqlQuiz_FillInTheBlanksDetailsProvider();
        quiz_FillInTheBlanksDetails = sqlQuiz_FillInTheBlanksDetailsProvider.GetQuiz_FillInTheBlanksDetailsByFillInTheBlanksDetailsID(FillInTheBlanksDetailsID);
        return quiz_FillInTheBlanksDetails;
    }


    public static int InsertQuiz_FillInTheBlanksDetails(Quiz_FillInTheBlanksDetails quiz_FillInTheBlanksDetails)
    {
        SqlQuiz_FillInTheBlanksDetailsProvider sqlQuiz_FillInTheBlanksDetailsProvider = new SqlQuiz_FillInTheBlanksDetailsProvider();
        return sqlQuiz_FillInTheBlanksDetailsProvider.InsertQuiz_FillInTheBlanksDetails(quiz_FillInTheBlanksDetails);
    }


    public static bool UpdateQuiz_FillInTheBlanksDetails(Quiz_FillInTheBlanksDetails quiz_FillInTheBlanksDetails)
    {
        SqlQuiz_FillInTheBlanksDetailsProvider sqlQuiz_FillInTheBlanksDetailsProvider = new SqlQuiz_FillInTheBlanksDetailsProvider();
        return sqlQuiz_FillInTheBlanksDetailsProvider.UpdateQuiz_FillInTheBlanksDetails(quiz_FillInTheBlanksDetails);
    }

    public static bool DeleteQuiz_FillInTheBlanksDetails(int quiz_FillInTheBlanksDetailsID)
    {
        SqlQuiz_FillInTheBlanksDetailsProvider sqlQuiz_FillInTheBlanksDetailsProvider = new SqlQuiz_FillInTheBlanksDetailsProvider();
        return sqlQuiz_FillInTheBlanksDetailsProvider.DeleteQuiz_FillInTheBlanksDetails(quiz_FillInTheBlanksDetailsID);
    }
}

