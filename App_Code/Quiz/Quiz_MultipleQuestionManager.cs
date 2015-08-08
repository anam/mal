using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_MultipleQuestionManager
{
	public Quiz_MultipleQuestionManager()
	{
	}

    public static DataSet  GetAllQuiz_MultipleQuestions()
    {
       DataSet quiz_MultipleQuestions = new DataSet();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetAllQuiz_MultipleQuestions();
        return quiz_MultipleQuestions;
    }

    public static List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsRandomly(int courseID, int subjectID, int chapterID, int count)
    {
        List<Quiz_MultipleQuestion> quiz_MultipleQuestions = new List<Quiz_MultipleQuestion>();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionsRandomly(courseID,  subjectID,  chapterID,  count);
        return quiz_MultipleQuestions;
    }


    public static List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsRandomlyTable(int courseID, int subjectID, int chapterID, int count)
    {
        List<Quiz_MultipleQuestion> quiz_MultipleQuestions = new List<Quiz_MultipleQuestion>();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionsRandomlyTable(courseID, subjectID, chapterID, count);
        return quiz_MultipleQuestions;
    }

    public static List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsByExamID(int courseID, int subjectID, int chapterID, int count,int examID)
    {
        List<Quiz_MultipleQuestion> quiz_MultipleQuestions = new List<Quiz_MultipleQuestion>();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionsByExamID(courseID, subjectID, chapterID, count, examID);
        return quiz_MultipleQuestions;
    }

    public static List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsByExamIDTable(int courseID, int subjectID, int chapterID, int count, int examID)
    {
        List<Quiz_MultipleQuestion> quiz_MultipleQuestions = new List<Quiz_MultipleQuestion>();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionsByExamIDTable(courseID, subjectID, chapterID, count, examID);
        return quiz_MultipleQuestions;
    }


    public static List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsNotByExamID(int courseID, int subjectID, int chapterID, int count, int examID)
    {
        List<Quiz_MultipleQuestion> quiz_MultipleQuestions = new List<Quiz_MultipleQuestion>();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionsNotByExamID(courseID, subjectID, chapterID, count, examID);
        return quiz_MultipleQuestions;
    }

    public static List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsNotByExamIDTable(int courseID, int subjectID, int chapterID, int count, int examID)
    {
        List<Quiz_MultipleQuestion> quiz_MultipleQuestions = new List<Quiz_MultipleQuestion>();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionsNotByExamIDTable(courseID, subjectID, chapterID, count, examID);
        return quiz_MultipleQuestions;
    }


	public static void quiz_MultipleQuestionsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadQuiz_MultipleQuestionPage( System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
		DataSet ds =  sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_MultipleQuestionsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}
    public static void LoadQuiz_MultipleQuestionPageByChapterID(string AnswerString, int chapterID, System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        DataSet ds = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionPageWiseByChapterID( AnswerString,chapterID, pageIndex, PageSize, out recordCount);
        gv.DataSource = ds;
        gv.DataBind();
        quiz_MultipleQuestionsPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static DataSet  GetDropDownListAllQuiz_MultipleQuestion()
    {
       DataSet quiz_MultipleQuestions = new DataSet();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetDropDownLisAllQuiz_MultipleQuestion();
        return quiz_MultipleQuestions;
    }

    public static DataSet   GetAllQuiz_MultipleQuestionsWithRelation()
    {
       DataSet quiz_MultipleQuestions = new DataSet();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetAllQuiz_MultipleQuestions();
        return quiz_MultipleQuestions;
    }


    //public static Quiz_MultipleQuestion GetQuiz_ComprehensionByComprehensionID(int ComprehensionID)
    //{
    //    Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion();
    //    SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
    //    quiz_MultipleQuestion = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionByComprehensionID(ComprehensionID);
    //    return quiz_MultipleQuestion;
    //}

    public static DataSet GetQuiz_MultipleQuestionByComprehensionID(int ComprehensionID)
    {
        DataSet quiz_MultipleQuestions = new DataSet();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestions = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionByComprehensionID(ComprehensionID);
        return quiz_MultipleQuestions;
    }

    public static List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionListByComprehensionID(int comprehensionID)
    {
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        return sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionListByComprehensionID(comprehensionID);
    }
    public static Quiz_MultipleQuestion GetQuiz_CourseByCourseID(int CourseID)
    {
        Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestion = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionByCourseID(CourseID);
        return quiz_MultipleQuestion;
    }


    public static Quiz_MultipleQuestion GetQuiz_SubjectBySubjectID(int SubjectID)
    {
        Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestion = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionBySubjectID(SubjectID);
        return quiz_MultipleQuestion;
    }


    public static Quiz_MultipleQuestion GetQuiz_ChapterByChapterID(int ChapterID)
    {
        Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestion = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionByChapterID(ChapterID);
        return quiz_MultipleQuestion;
    }


    public static Quiz_MultipleQuestion GetQuiz_MultipleQuestionByMultipleQustionID(int MultipleQustionID)
    {
        Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion();
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        quiz_MultipleQuestion = sqlQuiz_MultipleQuestionProvider.GetQuiz_MultipleQuestionByMultipleQustionID(MultipleQustionID);
        return quiz_MultipleQuestion;
    }


    public static int InsertQuiz_MultipleQuestion(Quiz_MultipleQuestion quiz_MultipleQuestion)
    {
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        return sqlQuiz_MultipleQuestionProvider.InsertQuiz_MultipleQuestion(quiz_MultipleQuestion);
    }


    public static bool UpdateQuiz_MultipleQuestion(Quiz_MultipleQuestion quiz_MultipleQuestion)
    {
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        return sqlQuiz_MultipleQuestionProvider.UpdateQuiz_MultipleQuestion(quiz_MultipleQuestion);
    }

    public static bool DeleteQuiz_MultipleQuestion(int quiz_MultipleQuestionID)
    {
        SqlQuiz_MultipleQuestionProvider sqlQuiz_MultipleQuestionProvider = new SqlQuiz_MultipleQuestionProvider();
        return sqlQuiz_MultipleQuestionProvider.DeleteQuiz_MultipleQuestion(quiz_MultipleQuestionID);
    }
}

