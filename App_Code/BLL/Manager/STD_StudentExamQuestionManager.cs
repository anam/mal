using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class StudentExamQuestionManager
{
	public StudentExamQuestionManager()
	{
	}

    public static List<StudentExamQuestion> GetAllStudentExamQuestions()
    {
        List<StudentExamQuestion> studentExamQuestions = new List<StudentExamQuestion>();
        SqlStudentExamQuestionProvider sqlStudentExamQuestionProvider = new SqlStudentExamQuestionProvider();
        studentExamQuestions = sqlStudentExamQuestionProvider.GetAllStudentExamQuestions();
        return studentExamQuestions;
    }


    public static StudentExamQuestion GetStudentExamQuestionByID(int id)
    {
        StudentExamQuestion studentExamQuestion = new StudentExamQuestion();
        SqlStudentExamQuestionProvider sqlStudentExamQuestionProvider = new SqlStudentExamQuestionProvider();
        studentExamQuestion = sqlStudentExamQuestionProvider.GetStudentExamQuestionByID(id);
        return studentExamQuestion;
    }


    public static int InsertStudentExamQuestion(StudentExamQuestion studentExamQuestion)
    {
        SqlStudentExamQuestionProvider sqlStudentExamQuestionProvider = new SqlStudentExamQuestionProvider();
        return sqlStudentExamQuestionProvider.InsertStudentExamQuestion(studentExamQuestion);
    }


    public static bool UpdateStudentExamQuestion(StudentExamQuestion studentExamQuestion)
    {
        SqlStudentExamQuestionProvider sqlStudentExamQuestionProvider = new SqlStudentExamQuestionProvider();
        return sqlStudentExamQuestionProvider.UpdateStudentExamQuestion(studentExamQuestion);
    }

    public static bool DeleteStudentExamQuestion(int studentExamQuestionID)
    {
        SqlStudentExamQuestionProvider sqlStudentExamQuestionProvider = new SqlStudentExamQuestionProvider();
        return sqlStudentExamQuestionProvider.DeleteStudentExamQuestion(studentExamQuestionID);
    }
}
