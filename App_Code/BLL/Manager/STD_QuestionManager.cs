using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_QuestionManager
{
	public STD_QuestionManager()
	{
	}

    public static DataSet  GetAllSTD_Questions()
    {
       DataSet sTD_Questions = new DataSet();
        SqlSTD_QuestionProvider sqlSTD_QuestionProvider = new SqlSTD_QuestionProvider();
        sTD_Questions = sqlSTD_QuestionProvider.GetAllSTD_Questions();
        return sTD_Questions;
    }

	public static void sTD_QuestionsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_QuestionPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_QuestionProvider sqlSTD_QuestionProvider = new SqlSTD_QuestionProvider();
		DataSet ds =  sqlSTD_QuestionProvider.GetSTD_QuestionPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_QuestionsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Question()
    {
       DataSet sTD_Questions = new DataSet();
        SqlSTD_QuestionProvider sqlSTD_QuestionProvider = new SqlSTD_QuestionProvider();
        sTD_Questions = sqlSTD_QuestionProvider.GetDropDownListAllSTD_Question();
        return sTD_Questions;
    }

    public static DataSet   GetAllSTD_QuestionsWithRelation()
    {
       DataSet sTD_Questions = new DataSet();
        SqlSTD_QuestionProvider sqlSTD_QuestionProvider = new SqlSTD_QuestionProvider();
        sTD_Questions = sqlSTD_QuestionProvider.GetAllSTD_Questions();
        return sTD_Questions;
    }


    public static STD_Question GetSTD_QuestionTypeByQuestionTypeID(int QuestionTypeID)
    {
        STD_Question sTD_Question = new STD_Question();
        SqlSTD_QuestionProvider sqlSTD_QuestionProvider = new SqlSTD_QuestionProvider();
        sTD_Question = sqlSTD_QuestionProvider.GetSTD_QuestionByQuestionTypeID(QuestionTypeID);
        return sTD_Question;
    }


    public static STD_Question GetSTD_QuestionByQuestionID(int QuestionID)
    {
        STD_Question sTD_Question = new STD_Question();
        SqlSTD_QuestionProvider sqlSTD_QuestionProvider = new SqlSTD_QuestionProvider();
        sTD_Question = sqlSTD_QuestionProvider.GetSTD_QuestionByQuestionID(QuestionID);
        return sTD_Question;
    }


    public static int InsertSTD_Question(STD_Question sTD_Question)
    {
        SqlSTD_QuestionProvider sqlSTD_QuestionProvider = new SqlSTD_QuestionProvider();
        return sqlSTD_QuestionProvider.InsertSTD_Question(sTD_Question);
    }


    public static bool UpdateSTD_Question(STD_Question sTD_Question)
    {
        SqlSTD_QuestionProvider sqlSTD_QuestionProvider = new SqlSTD_QuestionProvider();
        return sqlSTD_QuestionProvider.UpdateSTD_Question(sTD_Question);
    }

    public static bool DeleteSTD_Question(int sTD_QuestionID)
    {
        SqlSTD_QuestionProvider sqlSTD_QuestionProvider = new SqlSTD_QuestionProvider();
        return sqlSTD_QuestionProvider.DeleteSTD_Question(sTD_QuestionID);
    }
}

