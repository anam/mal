using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_ComprehensionManager
{
	public Quiz_ComprehensionManager()
	{
	}

    public static DataSet  GetAllQuiz_Comprehensions()
    {
       DataSet quiz_Comprehensions = new DataSet();
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        quiz_Comprehensions = sqlQuiz_ComprehensionProvider.GetAllQuiz_Comprehensions();
        return quiz_Comprehensions;
    }

	public static void quiz_ComprehensionsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadQuiz_ComprehensionPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
		DataSet ds =  sqlQuiz_ComprehensionProvider.GetQuiz_ComprehensionPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_ComprehensionsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static List<Quiz_Comprehension> GetQuiz_ComprehensionsRandomly(int courseID, int subjectID, int chapterID, int count)
    {
        List<Quiz_Comprehension> comprehensions = new List<Quiz_Comprehension>();
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        comprehensions = sqlQuiz_ComprehensionProvider.GetQuiz_ComprehensionsRandomly(courseID, subjectID, chapterID, count);
        return comprehensions;
    }

    public static DataSet  GetDropDownListAllQuiz_Comprehension()
    {
       DataSet quiz_Comprehensions = new DataSet();
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        quiz_Comprehensions = sqlQuiz_ComprehensionProvider.GetDropDownLisAllQuiz_Comprehension();
        return quiz_Comprehensions;
    }

    public static DataSet   GetAllQuiz_ComprehensionsWithRelation()
    {
       DataSet quiz_Comprehensions = new DataSet();
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        quiz_Comprehensions = sqlQuiz_ComprehensionProvider.GetAllQuiz_Comprehensions();
        return quiz_Comprehensions;
    }


    public static Quiz_Comprehension GetQuiz_CourseByCourseID(int CourseID)
    {
        Quiz_Comprehension quiz_Comprehension = new Quiz_Comprehension();
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        quiz_Comprehension = sqlQuiz_ComprehensionProvider.GetQuiz_ComprehensionByCourseID(CourseID);
        return quiz_Comprehension;
    }


    public static Quiz_Comprehension GetQuiz_SubjectBySubjectID(int SubjectID)
    {
        Quiz_Comprehension quiz_Comprehension = new Quiz_Comprehension();
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        quiz_Comprehension = sqlQuiz_ComprehensionProvider.GetQuiz_ComprehensionBySubjectID(SubjectID);
        return quiz_Comprehension;
    }


    public static Quiz_Comprehension GetQuiz_ChapterByChapterID(int ChapterID)
    {
        Quiz_Comprehension quiz_Comprehension = new Quiz_Comprehension();
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        quiz_Comprehension = sqlQuiz_ComprehensionProvider.GetQuiz_ComprehensionByChapterID(ChapterID);
        return quiz_Comprehension;
    }


    public static Quiz_Comprehension GetQuiz_ComprehensionByComprehensionID(int ComprehensionID)
    {
        Quiz_Comprehension quiz_Comprehension = new Quiz_Comprehension();
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        quiz_Comprehension = sqlQuiz_ComprehensionProvider.GetQuiz_ComprehensionByComprehensionID(ComprehensionID);
        return quiz_Comprehension;
    }


    public static int InsertQuiz_Comprehension(Quiz_Comprehension quiz_Comprehension)
    {
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        return sqlQuiz_ComprehensionProvider.InsertQuiz_Comprehension(quiz_Comprehension);
    }


    public static bool UpdateQuiz_Comprehension(Quiz_Comprehension quiz_Comprehension)
    {
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        return sqlQuiz_ComprehensionProvider.UpdateQuiz_Comprehension(quiz_Comprehension);
    }

    public static bool DeleteQuiz_Comprehension(int quiz_ComprehensionID)
    {
        SqlQuiz_ComprehensionProvider sqlQuiz_ComprehensionProvider = new SqlQuiz_ComprehensionProvider();
        return sqlQuiz_ComprehensionProvider.DeleteQuiz_Comprehension(quiz_ComprehensionID);
    }
}

