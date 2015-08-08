using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class Quiz_ExamStudentManager
{
	public Quiz_ExamStudentManager()
	{
	}

    public static DataSet  GetAllQuiz_ExamStudents()
    {
       DataSet quiz_ExamStudents = new DataSet();
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        quiz_ExamStudents = sqlQuiz_ExamStudentProvider.GetAllQuiz_ExamStudents();
        return quiz_ExamStudents;
    }

	public static void quiz_ExamStudentsPaggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
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
 	public static void LoadQuiz_ExamStudentPage(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize)
	{
		int recordCount=0;
		int PageSize =  int.Parse(ddlPageSize.SelectedValue);
		SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
		DataSet ds =  sqlQuiz_ExamStudentProvider.GetQuiz_ExamStudentPageWise(pageIndex, PageSize, out recordCount);
		gv.DataSource = ds;
		gv.DataBind();
		 quiz_ExamStudentsPaggination(rptPager,recordCount, pageIndex, PageSize);
	}

    public static void LoadQuiz_ExamStudentPageByStudent(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.Repeater rptPager, int pageIndex, DropDownList ddlPageSize,string StudentID)
    {
        int recordCount = 0;
        int PageSize = int.Parse(ddlPageSize.SelectedValue);
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        DataSet ds = sqlQuiz_ExamStudentProvider.GetQuiz_ExamStudentPageWiseByStudent(pageIndex, PageSize, out recordCount, StudentID);
        gv.DataSource = ds;
        gv.DataBind();
        quiz_ExamStudentsPaggination(rptPager, recordCount, pageIndex, PageSize);
    }

    public static DataSet  GetDropDownListAllQuiz_ExamStudent()
    {
       DataSet quiz_ExamStudents = new DataSet();
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        quiz_ExamStudents = sqlQuiz_ExamStudentProvider.GetDropDownLisAllQuiz_ExamStudent();
        return quiz_ExamStudents;
    }


    public static Quiz_ExamStudent GetQuiz_StudentByStudentID(string StudentID)
    {
        Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent();
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        quiz_ExamStudent = sqlQuiz_ExamStudentProvider.GetQuiz_ExamStudentByStudentID(StudentID);
        return quiz_ExamStudent;
    }


    public static Quiz_ExamStudent GetQuiz_ClassSubjectByClassSubjectID(int ClassSubjectID)
    {
        Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent();
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        quiz_ExamStudent = sqlQuiz_ExamStudentProvider.GetQuiz_ExamStudentByClassSubjectID(ClassSubjectID);
        return quiz_ExamStudent;
    }


    public static Quiz_ExamStudent GetQuiz_STDExamDetailsBySTDExamDetailsID(int STDExamDetailsID)
    {
        Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent();
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        quiz_ExamStudent = sqlQuiz_ExamStudentProvider.GetQuiz_ExamStudentBySTDExamDetailsID(STDExamDetailsID);
        return quiz_ExamStudent;
    }


    public static Quiz_ExamStudent GetQuiz_QuizExamByQuizExamID(int QuizExamID)
    {
        Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent();
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        quiz_ExamStudent = sqlQuiz_ExamStudentProvider.GetQuiz_ExamStudentByQuizExamID(QuizExamID);
        return quiz_ExamStudent;
    }


    public static Quiz_ExamStudent GetQuiz_RowStatusByRowStatusID(int RowStatusID)
    {
        Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent();
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        quiz_ExamStudent = sqlQuiz_ExamStudentProvider.GetQuiz_ExamStudentByRowStatusID(RowStatusID);
        return quiz_ExamStudent;
    }


    public static Quiz_ExamStudent GetQuiz_ExamStudentByExamStudentID(int ExamStudentID)
    {
        Quiz_ExamStudent quiz_ExamStudent = new Quiz_ExamStudent();
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        quiz_ExamStudent = sqlQuiz_ExamStudentProvider.GetQuiz_ExamStudentByExamStudentID(ExamStudentID);
        return quiz_ExamStudent;
    }


    public static int InsertQuiz_ExamStudent(Quiz_ExamStudent quiz_ExamStudent)
    {
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        return sqlQuiz_ExamStudentProvider.InsertQuiz_ExamStudent(quiz_ExamStudent);
    }


    public static bool UpdateQuiz_ExamStudent(Quiz_ExamStudent quiz_ExamStudent)
    {
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        return sqlQuiz_ExamStudentProvider.UpdateQuiz_ExamStudent(quiz_ExamStudent);
    }

    public static bool DeleteQuiz_ExamStudent(int quiz_ExamStudentID)
    {
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        return sqlQuiz_ExamStudentProvider.DeleteQuiz_ExamStudent(quiz_ExamStudentID);
    }

    public static bool RowStatusQuiz_ExamStudent(int quiz_ExamStudentID, int rowStatusID)
    {
        SqlQuiz_ExamStudentProvider sqlQuiz_ExamStudentProvider = new SqlQuiz_ExamStudentProvider();
        return sqlQuiz_ExamStudentProvider.RowStatusChangeQuiz_ExamStudent(quiz_ExamStudentID, rowStatusID);
    }
}

