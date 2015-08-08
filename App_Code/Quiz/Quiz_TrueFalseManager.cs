using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_TrueFalseManager
{
	public Quiz_TrueFalseManager()
	{
	}

    public static DataSet  GetAllQuiz_TrueFalses()
    {
       DataSet quiz_TrueFalses = new DataSet();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalses = sqlQuiz_TrueFalseProvider.GetAllQuiz_TrueFalses();
        return quiz_TrueFalses;
    }

    public static List<Quiz_TrueFalse> GetQuiz_TrueFalsesRandomly(int courseID, int subjectID, int chapterID, bool isDrCr, int count)
    {
        //DataSet quiz_TrueFalses = new DataSet();
        List<Quiz_TrueFalse> quiz_TrueFalses = new List<Quiz_TrueFalse>();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalses = sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalsesRandomly(courseID, subjectID, chapterID, isDrCr, count);
        return quiz_TrueFalses;
    }


    public static List<Quiz_TrueFalse> GetQuiz_TrueFalsesByExamID(int courseID, int subjectID, int chapterID, bool isDrCr, int count,int examID)
    {
        //DataSet quiz_TrueFalses = new DataSet();
        List<Quiz_TrueFalse> quiz_TrueFalses = new List<Quiz_TrueFalse>();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalses = sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalsesByExamID(courseID, subjectID, chapterID, isDrCr, count, examID);
        return quiz_TrueFalses;
    }

    public static List<Quiz_TrueFalse> GetQuiz_TrueFalsesNotByExamID(int courseID, int subjectID, int chapterID, bool isDrCr, int count, int examID)
    {
        //DataSet quiz_TrueFalses = new DataSet();
        List<Quiz_TrueFalse> quiz_TrueFalses = new List<Quiz_TrueFalse>();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalses = sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalsesNotByExamID(courseID, subjectID, chapterID, isDrCr, count, examID);
        return quiz_TrueFalses;
    }

    public static DataSet GetQuiz_TrueFalseByComprehensionID(int ComprehensionID)
    {
       DataSet quiz_TrueFalses = new DataSet();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalses = sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalseByComprehensionID(ComprehensionID);
        return quiz_TrueFalses;
    }

    public static List<Quiz_TrueFalse> GetQuiz_TrueFalseListByComprehensionID(int ComprehensionID)
    {
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        return sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalseListByComprehensionID(ComprehensionID);
    }

    public static DataSet GetQuiz_DrCrByComprehensionID(int ComprehensionID)
    {
       DataSet quiz_TrueFalses = new DataSet();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalses = sqlQuiz_TrueFalseProvider.GetQuiz_DrCrByComprehensionID(ComprehensionID);
        return quiz_TrueFalses;
    }

    public static List<Quiz_TrueFalse> GetQuiz_DrCrListByComprehensionID(int ComprehensionID)
    {
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        return sqlQuiz_TrueFalseProvider.GetQuiz_DrCrListByComprehensionID(ComprehensionID);
    }

	public static void quiz_TrueFalsesPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
    public static void LoadQuiz_TrueFalsePage(System.Web.UI.WebControls.GridView gv, bool isDrCr, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize, int courseID, int subjectID, int chapterID)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
		DataSet ds =  sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalsePageWise(isDrCr,pageIndex, PageSize, out recordCount, courseID, subjectID, chapterID);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_TrueFalsesPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet  GetDropDownListAllQuiz_TrueFalse()
    {
       DataSet quiz_TrueFalses = new DataSet();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalses = sqlQuiz_TrueFalseProvider.GetDropDownLisAllQuiz_TrueFalse();
        return quiz_TrueFalses;
    }

    public static DataSet   GetAllQuiz_TrueFalsesWithRelation()
    {
       DataSet quiz_TrueFalses = new DataSet();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalses = sqlQuiz_TrueFalseProvider.GetAllQuiz_TrueFalses();
        return quiz_TrueFalses;
    }


  


    public static Quiz_TrueFalse GetQuiz_CourseByCourseID(int CourseID)
    {
        Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalse = sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalseByCourseID(CourseID);
        return quiz_TrueFalse;
    }


    public static Quiz_TrueFalse GetQuiz_SubjectBySubjectID(int SubjectID)
    {
        Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalse = sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalseBySubjectID(SubjectID);
        return quiz_TrueFalse;
    }


    public static Quiz_TrueFalse GetQuiz_ChapterByChapterID(int ChapterID)
    {
        Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalse = sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalseByChapterID(ChapterID);
        return quiz_TrueFalse;
    }


    public static Quiz_TrueFalse GetQuiz_TrueFalseByTrueFalseID(int TrueFalseID)
    {
        Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse();
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        quiz_TrueFalse = sqlQuiz_TrueFalseProvider.GetQuiz_TrueFalseByTrueFalseID(TrueFalseID);
        return quiz_TrueFalse;
    }


    public static int InsertQuiz_TrueFalse(Quiz_TrueFalse quiz_TrueFalse)
    {
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        return sqlQuiz_TrueFalseProvider.InsertQuiz_TrueFalse(quiz_TrueFalse);
    }


    public static bool UpdateQuiz_TrueFalse(Quiz_TrueFalse quiz_TrueFalse)
    {
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        return sqlQuiz_TrueFalseProvider.UpdateQuiz_TrueFalse(quiz_TrueFalse);
    }

    public static bool DeleteQuiz_TrueFalse(int quiz_TrueFalseID)
    {
        SqlQuiz_TrueFalseProvider sqlQuiz_TrueFalseProvider = new SqlQuiz_TrueFalseProvider();
        return sqlQuiz_TrueFalseProvider.DeleteQuiz_TrueFalse(quiz_TrueFalseID);
    }
}

