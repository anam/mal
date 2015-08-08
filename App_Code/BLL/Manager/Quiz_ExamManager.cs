using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_ExamManager
{
	public Quiz_ExamManager()
	{
	}

    public static DataSet  GetAllQuiz_Exams()
    {
       DataSet quiz_Exams = new DataSet();
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        quiz_Exams = sqlQuiz_ExamProvider.GetAllQuiz_Exams();
        return quiz_Exams;
    }

	public static void quiz_ExamsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadQuiz_ExamPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
		DataSet ds =  sqlQuiz_ExamProvider.GetQuiz_ExamPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_ExamsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static DataSet GetDropDownListAllQuiz_Exam(int courseID, int subjectID, int chapterID)
    {
       DataSet quiz_Exams = new DataSet();
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        quiz_Exams = sqlQuiz_ExamProvider.GetDropDownLisAllQuiz_Exam(courseID, subjectID, chapterID);
        return quiz_Exams;
    }


    public static Quiz_Exam GetHR_CourseByCourseID(int CourseID)
    {
        Quiz_Exam quiz_Exam = new Quiz_Exam();
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        quiz_Exam = sqlQuiz_ExamProvider.GetQuiz_ExamByCourseID(CourseID);
        return quiz_Exam;
    }


    public static DataSet GetHR_SubjectBySubjectID(int SubjectID)
    {
        DataSet quiz_Exam = new DataSet();
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        quiz_Exam = sqlQuiz_ExamProvider.GetQuiz_ExamBySubjectID(SubjectID);
        return quiz_Exam;
    }


    public static Quiz_Exam GetHR_ChapterByChapterID(int ChapterID)
    {
        Quiz_Exam quiz_Exam = new Quiz_Exam();
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        quiz_Exam = sqlQuiz_ExamProvider.GetQuiz_ExamByChapterID(ChapterID);
        return quiz_Exam;
    }


    public static Quiz_Exam GetQuiz_ExamByExamID(int ExamID)
    {
        Quiz_Exam quiz_Exam = new Quiz_Exam();
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        quiz_Exam = sqlQuiz_ExamProvider.GetQuiz_ExamByExamID(ExamID);
        return quiz_Exam;
    }


    public static DataSet GetQuiz_ExamByExamIDDataset(int ExamID)
    {
        DataSet quiz_Exam = new DataSet();
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        quiz_Exam = sqlQuiz_ExamProvider.GetQuiz_ExamByExamIDDatabase(ExamID);
        return quiz_Exam;
    }


    public static int InsertQuiz_Exam(Quiz_Exam quiz_Exam)
    {
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        return sqlQuiz_ExamProvider.InsertQuiz_Exam(quiz_Exam);
    }


    public static bool UpdateQuiz_Exam(Quiz_Exam quiz_Exam)
    {
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        return sqlQuiz_ExamProvider.UpdateQuiz_Exam(quiz_Exam);
    }

    public static bool DeleteQuiz_Exam(int quiz_ExamID)
    {
        SqlQuiz_ExamProvider sqlQuiz_ExamProvider = new SqlQuiz_ExamProvider();
        return sqlQuiz_ExamProvider.DeleteQuiz_Exam(quiz_ExamID);
    }
}

