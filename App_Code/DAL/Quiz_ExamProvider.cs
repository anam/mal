using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_ExamProvider:DataAccessObject
{
	public SqlQuiz_ExamProvider()
    {
    }


    public DataSet  GetAllQuiz_Exams()
    {
        DataSet Quiz_Exams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_Exams", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_Exams);
            myadapter.Dispose();
            connection.Close();

            return Quiz_Exams;
        }
    }
	public DataSet GetQuiz_ExamPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_ExamPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize",  PageSize );
                command.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                command.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                recordCount = Convert.ToInt32(command.Parameters["@RecordCount"].Value);
                return ds;
            }
        }
    }


    public Quiz_Exam  GetQuiz_ExamByCourseID(int  courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamFromReader(reader);
             }
            else
            {
            return null;
            }
        }

        

    }

    public DataSet  GetQuiz_ExamBySubjectID(int  subjectID)
    {
       

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_ExamBySubjectID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SubjectID", subjectID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public Quiz_Exam  GetQuiz_ExamByChapterID(int  chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamByChapterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChapterID", SqlDbType.NVarChar).Value = chapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetDropDownLisAllQuiz_Exam(int courseID, int subjectID, int chapterID)
    {
        DataSet Quiz_Exams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_Exam", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@subjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@chapterID", SqlDbType.Int).Value = chapterID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_Exams);
            myadapter.Dispose();
            connection.Close();

            return Quiz_Exams;
        }
    }

    public DataSet   GetAllQuiz_TrueFalsesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_TrueFalsesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<Quiz_Exam> GetQuiz_ExamsFromReader(IDataReader reader)
    {
        List<Quiz_Exam> quiz_Exams = new List<Quiz_Exam>();

        while (reader.Read())
        {
            quiz_Exams.Add(GetQuiz_ExamFromReader(reader));
        }
        return quiz_Exams;
    }

    public Quiz_Exam GetQuiz_ExamFromReader(IDataReader reader)
    {
        try
        {
            Quiz_Exam quiz_Exam = new Quiz_Exam
                (

                     DataAccessObject.IsNULL<int>(reader["ExamID"]),
                     DataAccessObject.IsNULL<string>(reader["ExamName"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<int>(reader["ExamTimeDuration"]),
                     DataAccessObject.IsNULL<DateTime>(reader["ExamStartTime"]),
                     DataAccessObject.IsNULL<bool>(reader["IsRetake"]),
                     DataAccessObject.IsNULL<bool>(reader["IsActive"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return quiz_Exam;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_Exam  GetQuiz_ExamByExamID(int  examID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetQuiz_ExamByExamIDDatabase(int examID)
    {
       
        DataSet Quiz_Exams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_Exams);
            myadapter.Dispose();
            connection.Close();

            return Quiz_Exams;
        }

    }

    public int InsertQuiz_Exam(Quiz_Exam quiz_Exam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_Exam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExamName", SqlDbType.NVarChar).Value = quiz_Exam.ExamName;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_Exam.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_Exam.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_Exam.ChapterID;
            cmd.Parameters.Add("@ExamTimeDuration", SqlDbType.Int).Value = quiz_Exam.ExamTimeDuration;
            cmd.Parameters.Add("@ExamStartTime", SqlDbType.DateTime).Value = quiz_Exam.ExamStartTime;
            cmd.Parameters.Add("@IsRetake", SqlDbType.Bit).Value = quiz_Exam.IsRetake;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = quiz_Exam.IsActive;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_Exam.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_Exam.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_Exam.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_Exam.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamID"].Value;
        }
    }

    public bool UpdateQuiz_Exam(Quiz_Exam quiz_Exam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_Exam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = quiz_Exam.ExamID;
            cmd.Parameters.Add("@ExamName", SqlDbType.NVarChar).Value = quiz_Exam.ExamName;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_Exam.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_Exam.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_Exam.ChapterID;
            cmd.Parameters.Add("@ExamTimeDuration", SqlDbType.Int).Value = quiz_Exam.ExamTimeDuration;
            cmd.Parameters.Add("@ExamStartTime", SqlDbType.DateTime).Value = quiz_Exam.ExamStartTime;
            cmd.Parameters.Add("@IsRetake", SqlDbType.Bit).Value = quiz_Exam.IsRetake;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = quiz_Exam.IsActive;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_Exam.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_Exam.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_Exam(int examID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_Exam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

