using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_QuestionChapterManager
{
	public STD_QuestionChapterManager()
	{
	}

    public static DataSet  GetAllSTD_QuestionChapters()
    {
       DataSet sTD_QuestionChapters = new DataSet();
        SqlSTD_QuestionChapterProvider sqlSTD_QuestionChapterProvider = new SqlSTD_QuestionChapterProvider();
        sTD_QuestionChapters = sqlSTD_QuestionChapterProvider.GetAllSTD_QuestionChapters();
        return sTD_QuestionChapters;
    }

	public static void sTD_QuestionChaptersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_QuestionChapterPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_QuestionChapterProvider sqlSTD_QuestionChapterProvider = new SqlSTD_QuestionChapterProvider();
		DataSet ds =  sqlSTD_QuestionChapterProvider.GetSTD_QuestionChapterPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_QuestionChaptersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_QuestionChapter()
    {
       DataSet sTD_QuestionChapters = new DataSet();
        SqlSTD_QuestionChapterProvider sqlSTD_QuestionChapterProvider = new SqlSTD_QuestionChapterProvider();
        sTD_QuestionChapters = sqlSTD_QuestionChapterProvider.GetDropDownListAllSTD_QuestionChapter();
        return sTD_QuestionChapters;
    }


    public static STD_QuestionChapter GetSTD_QuestionByQuestionID(int QuestionID)
    {
        STD_QuestionChapter sTD_QuestionChapter = new STD_QuestionChapter();
        SqlSTD_QuestionChapterProvider sqlSTD_QuestionChapterProvider = new SqlSTD_QuestionChapterProvider();
        sTD_QuestionChapter = sqlSTD_QuestionChapterProvider.GetSTD_QuestionChapterByQuestionID(QuestionID);
        return sTD_QuestionChapter;
    }


    public static STD_QuestionChapter GetSTD_ChapterByChapterID(int ChapterID)
    {
        STD_QuestionChapter sTD_QuestionChapter = new STD_QuestionChapter();
        SqlSTD_QuestionChapterProvider sqlSTD_QuestionChapterProvider = new SqlSTD_QuestionChapterProvider();
        sTD_QuestionChapter = sqlSTD_QuestionChapterProvider.GetSTD_QuestionChapterByChapterID(ChapterID);
        return sTD_QuestionChapter;
    }


    public static STD_QuestionChapter GetSTD_QuestionChapterByQuestion_ChapterID(int Question_ChapterID)
    {
        STD_QuestionChapter sTD_QuestionChapter = new STD_QuestionChapter();
        SqlSTD_QuestionChapterProvider sqlSTD_QuestionChapterProvider = new SqlSTD_QuestionChapterProvider();
        sTD_QuestionChapter = sqlSTD_QuestionChapterProvider.GetSTD_QuestionChapterByQuestion_ChapterID(Question_ChapterID);
        return sTD_QuestionChapter;
    }


    public static int InsertSTD_QuestionChapter(STD_QuestionChapter sTD_QuestionChapter)
    {
        SqlSTD_QuestionChapterProvider sqlSTD_QuestionChapterProvider = new SqlSTD_QuestionChapterProvider();
        return sqlSTD_QuestionChapterProvider.InsertSTD_QuestionChapter(sTD_QuestionChapter);
    }


    public static bool UpdateSTD_QuestionChapter(STD_QuestionChapter sTD_QuestionChapter)
    {
        SqlSTD_QuestionChapterProvider sqlSTD_QuestionChapterProvider = new SqlSTD_QuestionChapterProvider();
        return sqlSTD_QuestionChapterProvider.UpdateSTD_QuestionChapter(sTD_QuestionChapter);
    }

    public static bool DeleteSTD_QuestionChapter(int sTD_QuestionChapterID)
    {
        SqlSTD_QuestionChapterProvider sqlSTD_QuestionChapterProvider = new SqlSTD_QuestionChapterProvider();
        return sqlSTD_QuestionChapterProvider.DeleteSTD_QuestionChapter(sTD_QuestionChapterID);
    }
}

