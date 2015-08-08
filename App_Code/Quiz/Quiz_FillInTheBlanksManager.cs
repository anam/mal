using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_FillInTheBlanksManager
{
	public Quiz_FillInTheBlanksManager()
	{
	}

    public static DataSet  GetAllQuiz_FillInTheBlankss()
    {
       DataSet quiz_FillInTheBlankss = new DataSet();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetAllQuiz_FillInTheBlankss();
        return quiz_FillInTheBlankss;
    }

    public static List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksRandomly(int courseID, int subjectID, int chapterID, int count)
    {
        List<Quiz_FillInTheBlanks> quiz_FillInTheBlankss = new List<Quiz_FillInTheBlanks>();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksRandomly(courseID, subjectID, chapterID, count);
        return quiz_FillInTheBlankss;
    }


    public static List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksRandomlyTable(int courseID, int subjectID, int chapterID, int count)
    {
        List<Quiz_FillInTheBlanks> quiz_FillInTheBlankss = new List<Quiz_FillInTheBlanks>();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksRandomlyTable(courseID, subjectID, chapterID, count);
        return quiz_FillInTheBlankss;
    }

    public static List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksByExamID(int courseID, int subjectID, int chapterID, int count,int examID)
    {
        List<Quiz_FillInTheBlanks> quiz_FillInTheBlankss = new List<Quiz_FillInTheBlanks>();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksByExamID(courseID, subjectID, chapterID, count,examID);
        return quiz_FillInTheBlankss;
    }

    public static List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksByExamIDTable(int courseID, int subjectID, int chapterID, int count, int examID)
    {
        List<Quiz_FillInTheBlanks> quiz_FillInTheBlankss = new List<Quiz_FillInTheBlanks>();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksByExamIDTable(courseID, subjectID, chapterID, count, examID);
        return quiz_FillInTheBlankss;
    }


    public static List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksNotByExamID(int courseID, int subjectID, int chapterID, int count, int examID)
    {
        List<Quiz_FillInTheBlanks> quiz_FillInTheBlankss = new List<Quiz_FillInTheBlanks>();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksNotByExamID(courseID, subjectID, chapterID, count, examID);
        return quiz_FillInTheBlankss;
    }

    public static List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksNotByExamIDTable(int courseID, int subjectID, int chapterID, int count, int examID)
    {
        List<Quiz_FillInTheBlanks> quiz_FillInTheBlankss = new List<Quiz_FillInTheBlanks>();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksNotByExamIDTable(courseID, subjectID, chapterID, count, examID);
        return quiz_FillInTheBlankss;
    }

    public static DataSet GetQuiz_FillInTheBlanksByComprehensionID(int ComprehensionID)
    {
       DataSet quiz_FillInTheBlankss = new DataSet();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksByComprehensionID(ComprehensionID);
        return quiz_FillInTheBlankss;
    }

    public static List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlankListByComprehensionID(int ComprehensionID)
    {
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        return sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlankListByComprehensionID(ComprehensionID);
    }
    
	public static void quiz_FillInTheBlankssPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadQuiz_FillInTheBlanksPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
		DataSet ds =  sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_FillInTheBlankssPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static void LoadQuiz_FillInTheBlanksPageByChapterID(string answerString, int chapterID, System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        DataSet ds = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksPageWiseByChapterID(answerString,chapterID, pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        quiz_FillInTheBlankssPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static DataSet  GetDropDownListAllQuiz_FillInTheBlanks()
    {
       DataSet quiz_FillInTheBlankss = new DataSet();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetDropDownLisAllQuiz_FillInTheBlanks();
        return quiz_FillInTheBlankss;
    }

    public static DataSet   GetAllQuiz_FillInTheBlankssWithRelation()
    {
       DataSet quiz_FillInTheBlankss = new DataSet();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlankss = sqlQuiz_FillInTheBlanksProvider.GetAllQuiz_FillInTheBlankss();
        return quiz_FillInTheBlankss;
    }


   

    public static Quiz_FillInTheBlanks GetQuiz_CourseByCourseID(int CourseID)
    {
        Quiz_FillInTheBlanks quiz_FillInTheBlanks = new Quiz_FillInTheBlanks();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlanks = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksByCourseID(CourseID);
        return quiz_FillInTheBlanks;
    }


    public static Quiz_FillInTheBlanks GetQuiz_SubjectBySubjectID(int SubjectID)
    {
        Quiz_FillInTheBlanks quiz_FillInTheBlanks = new Quiz_FillInTheBlanks();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlanks = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksBySubjectID(SubjectID);
        return quiz_FillInTheBlanks;
    }


    public static Quiz_FillInTheBlanks GetQuiz_ChapterByChapterID(int ChapterID)
    {
        Quiz_FillInTheBlanks quiz_FillInTheBlanks = new Quiz_FillInTheBlanks();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlanks = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksByChapterID(ChapterID);
        return quiz_FillInTheBlanks;
    }


    public static Quiz_FillInTheBlanks GetQuiz_FillInTheBlanksByFillInTheBlanksID(int FillInTheBlanksID)
    {
        Quiz_FillInTheBlanks quiz_FillInTheBlanks = new Quiz_FillInTheBlanks();
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        quiz_FillInTheBlanks = sqlQuiz_FillInTheBlanksProvider.GetQuiz_FillInTheBlanksByFillInTheBlanksID(FillInTheBlanksID);
        return quiz_FillInTheBlanks;
    }


    public static int InsertQuiz_FillInTheBlanks(Quiz_FillInTheBlanks quiz_FillInTheBlanks)
    {
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        return sqlQuiz_FillInTheBlanksProvider.InsertQuiz_FillInTheBlanks(quiz_FillInTheBlanks);
    }


    public static bool UpdateQuiz_FillInTheBlanks(Quiz_FillInTheBlanks quiz_FillInTheBlanks)
    {
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        return sqlQuiz_FillInTheBlanksProvider.UpdateQuiz_FillInTheBlanks(quiz_FillInTheBlanks);
    }

    public static bool DeleteQuiz_FillInTheBlanks(int quiz_FillInTheBlanksID)
    {
        SqlQuiz_FillInTheBlanksProvider sqlQuiz_FillInTheBlanksProvider = new SqlQuiz_FillInTheBlanksProvider();
        return sqlQuiz_FillInTheBlanksProvider.DeleteQuiz_FillInTheBlanks(quiz_FillInTheBlanksID);
    }
}

