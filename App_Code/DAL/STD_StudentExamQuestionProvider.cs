using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlStudentExamQuestionProvider:DataAccessObject
{
	public SqlStudentExamQuestionProvider()
    {
    }

    public bool DeleteStudentExamQuestion(int studentExamQuestionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_StudentExamQuestion_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentExamQuestionID", SqlDbType.Int).Value = studentExamQuestionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<StudentExamQuestion> GetAllStudentExamQuestions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_StudentExamQuestion_GetAll", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetStudentExamQuestionsFromReader(reader);
        }
    }

    public List<StudentExamQuestion> GetStudentExamQuestionsFromReader(IDataReader reader)
    {
        List<StudentExamQuestion> studentExamQuestions = new List<StudentExamQuestion>();

        while (reader.Read())
        {
            studentExamQuestions.Add(GetStudentExamQuestionFromReader(reader));
        }
        return studentExamQuestions;
    }

    public StudentExamQuestion GetStudentExamQuestionFromReader(IDataReader reader)
    {
        try
        {
            StudentExamQuestion studentExamQuestion = new StudentExamQuestion
                (
                    (int)reader["StudentExamQuestionID"],
                    (int)reader["QuestionID"],
                    (int)reader["QuestionTypeID"],
                    reader["StudentID"].ToString(),
                    (int)reader["ExamID"],
                    reader["AddedBy"].ToString(),
                    (DateTime)reader["AddedDate"],
                    reader["ModifiedBy"].ToString(),
                    (DateTime)reader["ModifiedDate"]
                );
             return studentExamQuestion;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public StudentExamQuestion GetStudentExamQuestionByID(int studentExamQuestionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_StudentExamQuestion_GetByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentExamQuestionID", SqlDbType.Int).Value = studentExamQuestionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetStudentExamQuestionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertStudentExamQuestion(StudentExamQuestion studentExamQuestion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_StudentExamQuestion_Insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentExamQuestionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = studentExamQuestion.QuestionID;
            cmd.Parameters.Add("@QuestionTypeID", SqlDbType.Int).Value = studentExamQuestion.QuestionTypeID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentExamQuestion.StudentID;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = studentExamQuestion.ExamID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = studentExamQuestion.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = studentExamQuestion.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = studentExamQuestion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = studentExamQuestion.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@StudentExamQuestionID"].Value;
        }
    }

    public bool UpdateStudentExamQuestion(StudentExamQuestion studentExamQuestion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_StudentExamQuestion_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentExamQuestionID", SqlDbType.Int).Value = studentExamQuestion.StudentExamQuestionID;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = studentExamQuestion.QuestionID;
            cmd.Parameters.Add("@QuestionTypeID", SqlDbType.Int).Value = studentExamQuestion.QuestionTypeID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentExamQuestion.StudentID;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = studentExamQuestion.ExamID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = studentExamQuestion.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = studentExamQuestion.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = studentExamQuestion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = studentExamQuestion.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
