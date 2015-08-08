using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for STD_MockTestProvider
/// </summary>
public class STD_MockTestProvider : DataAccessObject
{
	public STD_MockTestProvider()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public List<Quiz_Comprehension> GetMockTest_Comprehension(string studentID, int courseID, int subjectID, int chapterID, int count)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMockTest_Comprehension", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            IDataReader reader = command.ExecuteReader();

            SqlQuiz_ComprehensionProvider comprehensionProvider = new SqlQuiz_ComprehensionProvider();
            return comprehensionProvider.GetQuiz_ComprehensionsFromReader(reader);
        }
    }

    public int GetMockTest_Comprehension_Count(string studentID, int courseID, int subjectID, int chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMockTest_Comprehension_Count", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            connection.Open();
            int count=(int)command.ExecuteScalar();
            return count;
        }
    }

    public List<Quiz_FillInTheBlanks> GetMockTest_FillInTheBlanks(string studentID, int courseID, int subjectID, int chapterID, int count)
    {   
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMockTest_FillInTheBlank", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            IDataReader reader = command.ExecuteReader();

            SqlQuiz_FillInTheBlanksProvider fillInTheBanksProvider = new SqlQuiz_FillInTheBlanksProvider();
            return fillInTheBanksProvider.GetQuiz_FillInTheBlankssFromReader(reader);
        }
    }

    public int GetMockTest_FillInTheBlanks_Count(string studentID, int courseID, int subjectID, int chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMockTest_FillInTheBlank_Count", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            connection.Open();

            return (int)command.ExecuteScalar();
        }
    }

    public List<Quiz_MultipleQuestion> GetMockTest_MCQ(string studentID, int courseID, int subjectID, int chapterID, int count)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMockTest_MCQ", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            SqlQuiz_MultipleQuestionProvider mcqProvider = new SqlQuiz_MultipleQuestionProvider();
            return mcqProvider.GetQuiz_MultipleQuestionsFromReader(reader);
        }
    }

    public int GetMockTest_MCQ_Count(string studentID, int courseID, int subjectID, int chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMockTest_MCQ_Count", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            connection.Open();

            return (int)command.ExecuteScalar();
        }
    }

    public List<Quiz_TrueFalse> GetMockTest_TrueFalses(string studentID, int courseID, int subjectID, int chapterID, bool isDrCr, int count)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMockTest_TrueFalse", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@IsDrCr", SqlDbType.Bit).Value = isDrCr;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            SqlQuiz_TrueFalseProvider trueFalseProvider = new SqlQuiz_TrueFalseProvider();
            return trueFalseProvider.GetQuiz_TrueFalsesFromReader(reader);
        }
    }

    public int GetMockTest_TrueFalses_Count(string studentID, int courseID, int subjectID, int chapterID, bool isDrCr)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetMockTest_TrueFalse_Count", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@IsDrCr", SqlDbType.Bit).Value = isDrCr;
            connection.Open();

            int count =(int) command.ExecuteScalar();
            return count;
        }
    }
}