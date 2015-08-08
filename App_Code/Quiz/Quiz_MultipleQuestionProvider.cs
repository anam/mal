using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_MultipleQuestionProvider:DataAccessObject
{
	public SqlQuiz_MultipleQuestionProvider()
    {
    }


    public DataSet  GetAllQuiz_MultipleQuestions()
    {
        DataSet Quiz_MultipleQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_MultipleQuestions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_MultipleQuestions);
            myadapter.Dispose();
            connection.Close();

            return Quiz_MultipleQuestions;
        }
    }

    public List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsRandomly(int courseID, int subjectID, int chapterID, int count)
    {
        //DataSet Quiz_MultipleQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionRandomly", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            //SqlDataAdapter myadapter = new SqlDataAdapter(command);
            //myadapter.Fill(Quiz_MultipleQuestions);
            //myadapter.Dispose();
            //connection.Close();

            //return Quiz_MultipleQuestions;
            return GetQuiz_MultipleQuestionsFromReader(reader);
        }
    }

    public List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsRandomlyTable(int courseID, int subjectID, int chapterID, int count)
    {
        DataSet Quiz_MultipleQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionRandomly", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            //IDataReader reader = command.ExecuteReader();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_MultipleQuestions);
            myadapter.Dispose();
            connection.Close();

            //return Quiz_MultipleQuestions;
            return GetQuiz_MultipleQuestionsFromReaderTable(Quiz_MultipleQuestions);
        }
    }
    public List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsByExamID(int courseID, int subjectID, int chapterID, int count,int examID)
    {
        //DataSet Quiz_MultipleQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            //SqlDataAdapter myadapter = new SqlDataAdapter(command);
            //myadapter.Fill(Quiz_MultipleQuestions);
            //myadapter.Dispose();
            //connection.Close();

            //return Quiz_MultipleQuestions;
            return GetQuiz_MultipleQuestionsFromReader(reader);
        }
    }

    public List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsByExamIDTable(int courseID, int subjectID, int chapterID, int count, int examID)
    {
        DataSet Quiz_MultipleQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            //IDataReader reader = command.ExecuteReader();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_MultipleQuestions);
            myadapter.Dispose();
            connection.Close();

            //return Quiz_MultipleQuestions;
            return GetQuiz_MultipleQuestionsFromReaderTable(Quiz_MultipleQuestions);
        }
    }

    public List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsNotByExamID(int courseID, int subjectID, int chapterID, int count, int examID)
    {
        //DataSet Quiz_MultipleQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionNotByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            //SqlDataAdapter myadapter = new SqlDataAdapter(command);
            //myadapter.Fill(Quiz_MultipleQuestions);
            //myadapter.Dispose();
            //connection.Close();

            //return Quiz_MultipleQuestions;
            return GetQuiz_MultipleQuestionsFromReader(reader);
        }
    }

    public List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsNotByExamIDTable(int courseID, int subjectID, int chapterID, int count, int examID)
    {
        DataSet Quiz_MultipleQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionNotByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            //IDataReader reader = command.ExecuteReader();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_MultipleQuestions);
            myadapter.Dispose();
            connection.Close();

            //return Quiz_MultipleQuestions;
            return GetQuiz_MultipleQuestionsFromReaderTable(Quiz_MultipleQuestions);
        }
    }


    public DataSet GetQuiz_MultipleQuestionByComprehensionID(int comprehensionID)
    {
        DataSet Quiz_MultipleQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionByComprehensionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ComprehensionID", SqlDbType.NVarChar).Value = comprehensionID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_MultipleQuestions);
            myadapter.Dispose();
            connection.Close();

            return Quiz_MultipleQuestions;
        }       
    }

    public List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionListByComprehensionID(int comprehensionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionByComprehensionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ComprehensionID", SqlDbType.NVarChar).Value = comprehensionID;
            connection.Open();

            IDataReader reader = command.ExecuteReader();
            return GetQuiz_MultipleQuestionsFromReader(reader);
        }

    }

	public DataSet GetQuiz_MultipleQuestionPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionPageWise", connection))
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

    public DataSet GetQuiz_MultipleQuestionPageWiseByChapterID(string AnswerString, int chapterID, int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionPageWiseByChapterID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AnswerString", AnswerString);
                command.Parameters.AddWithValue("@ChapterID", chapterID);
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
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

    public Quiz_MultipleQuestion  GetQuiz_MultipleQuestionByCourseID(int  courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_MultipleQuestionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_MultipleQuestion  GetQuiz_MultipleQuestionBySubjectID(int  subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_MultipleQuestionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_MultipleQuestion  GetQuiz_MultipleQuestionByChapterID(int  chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionByChapterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChapterID", SqlDbType.NVarChar).Value = chapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_MultipleQuestionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllQuiz_MultipleQuestion()
    {
        DataSet Quiz_MultipleQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_MultipleQuestion", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_MultipleQuestions);
            myadapter.Dispose();
            connection.Close();

            return Quiz_MultipleQuestions;
        }
    }

    public DataSet   GetAllQuiz_MultipleQuestionsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_MultipleQuestionsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsFromReaderTable(DataSet ds)
    {
        List<Quiz_MultipleQuestion> quiz_MultipleQuestions = new List<Quiz_MultipleQuestion>();
        foreach (DataRow item in ds.Tables[0].Rows)
        {
            quiz_MultipleQuestions.Add(GetQuiz_MultipleQuestionFromReaderTable(item));
            int questionNo = 1;
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                if (dr["MultipleQustionID"].ToString() == quiz_MultipleQuestions[quiz_MultipleQuestions.Count - 1].MultipleQustionID.ToString())
                {
                    quiz_MultipleQuestions[quiz_MultipleQuestions.Count - 1].AnswerString += (questionNo++).ToString() + " --> " + dr["QuestionTitle"].ToString() + (bool.Parse(dr["IsAnswer"].ToString()) ? " <b>(ANSWER)</b> ":"") + "<br/>";
                }
            }
        }
        return quiz_MultipleQuestions;
    }

    public Quiz_MultipleQuestion GetQuiz_MultipleQuestionFromReaderTable(DataRow reader)
    {
        try
        {
            Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion
                (

                     DataAccessObject.IsNULL<int>(reader["MultipleQustionID"]),
                     DataAccessObject.IsNULL<int>(reader["ComprehensionID"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<string>(reader["MultipleQuestionName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
            return quiz_MultipleQuestion;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<Quiz_MultipleQuestion> GetQuiz_MultipleQuestionsFromReader(IDataReader reader)
    {
        List<Quiz_MultipleQuestion> quiz_MultipleQuestions = new List<Quiz_MultipleQuestion>();

        while (reader.Read())
        {
            quiz_MultipleQuestions.Add(GetQuiz_MultipleQuestionFromReader(reader));
        }
        return quiz_MultipleQuestions;
    }

    public Quiz_MultipleQuestion GetQuiz_MultipleQuestionFromReader(IDataReader reader)
    {
        try
        {
            Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion
                (

                     DataAccessObject.IsNULL<int>(reader["MultipleQustionID"]),
                     DataAccessObject.IsNULL<int>(reader["ComprehensionID"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<string>(reader["MultipleQuestionName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return quiz_MultipleQuestion;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_MultipleQuestion  GetQuiz_MultipleQuestionByMultipleQustionID(int  multipleQustionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionByMultipleQustionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MultipleQustionID", SqlDbType.Int).Value = multipleQustionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_MultipleQuestionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertQuiz_MultipleQuestion(Quiz_MultipleQuestion quiz_MultipleQuestion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_MultipleQuestion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MultipleQustionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = quiz_MultipleQuestion.ComprehensionID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_MultipleQuestion.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_MultipleQuestion.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_MultipleQuestion.ChapterID;
            cmd.Parameters.Add("@MultipleQuestionName", SqlDbType.NText).Value = quiz_MultipleQuestion.MultipleQuestionName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_MultipleQuestion.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_MultipleQuestion.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_MultipleQuestion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_MultipleQuestion.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MultipleQustionID"].Value;
        }
    }

    public bool UpdateQuiz_MultipleQuestion(Quiz_MultipleQuestion quiz_MultipleQuestion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_MultipleQuestion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MultipleQustionID", SqlDbType.Int).Value = quiz_MultipleQuestion.MultipleQustionID;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = quiz_MultipleQuestion.ComprehensionID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_MultipleQuestion.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_MultipleQuestion.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_MultipleQuestion.ChapterID;
            cmd.Parameters.Add("@MultipleQuestionName", SqlDbType.NText).Value = quiz_MultipleQuestion.MultipleQuestionName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_MultipleQuestion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_MultipleQuestion.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_MultipleQuestion(int multipleQustionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_MultipleQuestion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MultipleQustionID", SqlDbType.Int).Value = multipleQustionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

