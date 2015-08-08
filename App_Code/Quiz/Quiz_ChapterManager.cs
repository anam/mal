using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_ChapterManager
{
	public Quiz_ChapterManager()
	{
	}

    public static DataSet  GetAllQuiz_Chapters()
    {
       DataSet quiz_Chapters = new DataSet();
        SqlQuiz_ChapterProvider sqlQuiz_ChapterProvider = new SqlQuiz_ChapterProvider();
        quiz_Chapters = sqlQuiz_ChapterProvider.GetAllQuiz_Chapters();
        return quiz_Chapters;
    }

	public static void quiz_ChaptersPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadQuiz_ChapterPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_ChapterProvider sqlQuiz_ChapterProvider = new SqlQuiz_ChapterProvider();
		DataSet ds =  sqlQuiz_ChapterProvider.GetQuiz_ChapterPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_ChaptersPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllQuiz_Chapter(int courseID, int subjectID)
    {
       DataSet quiz_Chapters = new DataSet();
        SqlQuiz_ChapterProvider sqlQuiz_ChapterProvider = new SqlQuiz_ChapterProvider();
        quiz_Chapters = sqlQuiz_ChapterProvider.GetDropDownLisAllQuiz_Chapter(courseID, subjectID);
        return quiz_Chapters;
    }


    public static Quiz_Chapter GetQuiz_SubjectBySubjectID(int SubjectID)
    {
        Quiz_Chapter quiz_Chapter = new Quiz_Chapter();
        SqlQuiz_ChapterProvider sqlQuiz_ChapterProvider = new SqlQuiz_ChapterProvider();
        quiz_Chapter = sqlQuiz_ChapterProvider.GetQuiz_ChapterBySubjectID(SubjectID);
        return quiz_Chapter;
    }


    public static Quiz_Chapter GetQuiz_CourseByCourseID(int CourseID)
    {
        Quiz_Chapter quiz_Chapter = new Quiz_Chapter();
        SqlQuiz_ChapterProvider sqlQuiz_ChapterProvider = new SqlQuiz_ChapterProvider();
        quiz_Chapter = sqlQuiz_ChapterProvider.GetQuiz_ChapterByCourseID(CourseID);
        return quiz_Chapter;
    }


    public static Quiz_Chapter GetQuiz_ChapterByChapterID(int ChapterID)
    {
        Quiz_Chapter quiz_Chapter = new Quiz_Chapter();
        SqlQuiz_ChapterProvider sqlQuiz_ChapterProvider = new SqlQuiz_ChapterProvider();
        quiz_Chapter = sqlQuiz_ChapterProvider.GetQuiz_ChapterByChapterID(ChapterID);
        return quiz_Chapter;
    }


    public static int InsertQuiz_Chapter(Quiz_Chapter quiz_Chapter)
    {
        SqlQuiz_ChapterProvider sqlQuiz_ChapterProvider = new SqlQuiz_ChapterProvider();
        return sqlQuiz_ChapterProvider.InsertQuiz_Chapter(quiz_Chapter);
    }


    public static bool UpdateQuiz_Chapter(Quiz_Chapter quiz_Chapter)
    {
        SqlQuiz_ChapterProvider sqlQuiz_ChapterProvider = new SqlQuiz_ChapterProvider();
        return sqlQuiz_ChapterProvider.UpdateQuiz_Chapter(quiz_Chapter);
    }

    public static bool DeleteQuiz_Chapter(int quiz_ChapterID)
    {
        SqlQuiz_ChapterProvider sqlQuiz_ChapterProvider = new SqlQuiz_ChapterProvider();
        return sqlQuiz_ChapterProvider.DeleteQuiz_Chapter(quiz_ChapterID);
    }
}

