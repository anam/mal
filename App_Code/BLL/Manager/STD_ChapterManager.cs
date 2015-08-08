using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class STD_ChapterManager
{
	public STD_ChapterManager()
	{
	}

    public static DataSet  GetAllSTD_Chapters()
    {
       DataSet sTD_Chapters = new DataSet();
        SqlSTD_ChapterProvider sqlSTD_ChapterProvider = new SqlSTD_ChapterProvider();
        sTD_Chapters = sqlSTD_ChapterProvider.GetAllSTD_Chapters();
        return sTD_Chapters;
    }

	public static void sTD_ChaptersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadSTD_ChapterPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlSTD_ChapterProvider sqlSTD_ChapterProvider = new SqlSTD_ChapterProvider();
		DataSet ds =  sqlSTD_ChapterProvider.GetSTD_ChapterPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 sTD_ChaptersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllSTD_Chapter()
    {
       DataSet sTD_Chapters = new DataSet();
        SqlSTD_ChapterProvider sqlSTD_ChapterProvider = new SqlSTD_ChapterProvider();
        sTD_Chapters = sqlSTD_ChapterProvider.GetDropDownListAllSTD_Chapter();
        return sTD_Chapters;
    }

    public static DataSet   GetAllSTD_ChaptersWithRelation()
    {
       DataSet sTD_Chapters = new DataSet();
        SqlSTD_ChapterProvider sqlSTD_ChapterProvider = new SqlSTD_ChapterProvider();
        sTD_Chapters = sqlSTD_ChapterProvider.GetAllSTD_Chapters();
        return sTD_Chapters;
    }


    public static STD_Chapter GetSTD_SubjectBySubjectID(int SubjectID)
    {
        STD_Chapter sTD_Chapter = new STD_Chapter();
        SqlSTD_ChapterProvider sqlSTD_ChapterProvider = new SqlSTD_ChapterProvider();
        sTD_Chapter = sqlSTD_ChapterProvider.GetSTD_ChapterBySubjectID(SubjectID);
        return sTD_Chapter;
    }


    public static STD_Chapter GetSTD_ChapterByChapterID(int ChapterID)
    {
        STD_Chapter sTD_Chapter = new STD_Chapter();
        SqlSTD_ChapterProvider sqlSTD_ChapterProvider = new SqlSTD_ChapterProvider();
        sTD_Chapter = sqlSTD_ChapterProvider.GetSTD_ChapterByChapterID(ChapterID);
        return sTD_Chapter;
    }


    public static int InsertSTD_Chapter(STD_Chapter sTD_Chapter)
    {
        SqlSTD_ChapterProvider sqlSTD_ChapterProvider = new SqlSTD_ChapterProvider();
        return sqlSTD_ChapterProvider.InsertSTD_Chapter(sTD_Chapter);
    }


    public static bool UpdateSTD_Chapter(STD_Chapter sTD_Chapter)
    {
        SqlSTD_ChapterProvider sqlSTD_ChapterProvider = new SqlSTD_ChapterProvider();
        return sqlSTD_ChapterProvider.UpdateSTD_Chapter(sTD_Chapter);
    }

    public static bool DeleteSTD_Chapter(int sTD_ChapterID)
    {
        SqlSTD_ChapterProvider sqlSTD_ChapterProvider = new SqlSTD_ChapterProvider();
        return sqlSTD_ChapterProvider.DeleteSTD_Chapter(sTD_ChapterID);
    }
}

