using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_FillInTheBlanksProvider:DataAccessObject
{
	public SqlQuiz_FillInTheBlanksProvider()
    {
    }


    public DataSet  GetAllQuiz_FillInTheBlankss()
    {
        DataSet Quiz_FillInTheBlankss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_FillInTheBlankss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_FillInTheBlankss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_FillInTheBlankss;
        }
    }

    public List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksRandomly(int courseID, int subjectID, int chapterID, int count)
    {
        //DataSet Quiz_FillInTheBlankss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksRandomly", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            //SqlDataAdapter myadapter = new SqlDataAdapter(command);
            //myadapter.Fill(Quiz_FillInTheBlankss);
            //myadapter.Dispose();
            connection.Close();

            //return Quiz_FillInTheBlankss;
            return GetQuiz_FillInTheBlankssFromReader(reader);
        }
    }

    public List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksRandomlyTable(int courseID, int subjectID, int chapterID, int count)
    {
        DataSet Quiz_FillInTheBlankss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksRandomly", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            //IDataReader reader = command.ExecuteReader();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_FillInTheBlankss);
            myadapter.Dispose();
            connection.Close();

            //return Quiz_FillInTheBlankss;
            return GetQuiz_FillInTheBlankssFromReaderTable(Quiz_FillInTheBlankss);
        }
    }

    public List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksByExamID(int courseID, int subjectID, int chapterID, int count, int ExamID)
    {
        //DataSet Quiz_FillInTheBlankss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = ExamID;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            //SqlDataAdapter myadapter = new SqlDataAdapter(command);
            //myadapter.Fill(Quiz_FillInTheBlankss);
            //myadapter.Dispose();
            connection.Close();

            //return Quiz_FillInTheBlankss;
            return GetQuiz_FillInTheBlankssFromReader(reader);
        }
    }

    public List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksByExamIDTable(int courseID, int subjectID, int chapterID, int count, int ExamID)
    {
        DataSet Quiz_FillInTheBlankss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = ExamID;
            connection.Open();
            //IDataReader reader = command.ExecuteReader();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_FillInTheBlankss);
            myadapter.Dispose();
            connection.Close();

            //return Quiz_FillInTheBlankss;
            return GetQuiz_FillInTheBlankssFromReaderTable(Quiz_FillInTheBlankss);
        }
    }


    public List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksNotByExamID(int courseID, int subjectID, int chapterID, int count, int ExamID)
    {
        //DataSet Quiz_FillInTheBlankss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksNotByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = ExamID;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            //SqlDataAdapter myadapter = new SqlDataAdapter(command);
            //myadapter.Fill(Quiz_FillInTheBlankss);
            //myadapter.Dispose();
            connection.Close();

            //return Quiz_FillInTheBlankss;
            return GetQuiz_FillInTheBlankssFromReader(reader);
        }
    }

    public List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlanksNotByExamIDTable(int courseID, int subjectID, int chapterID, int count, int ExamID)
    {
        DataSet Quiz_FillInTheBlankss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksNotByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = ExamID;
            connection.Open();
            //IDataReader reader = command.ExecuteReader();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_FillInTheBlankss);
            myadapter.Dispose();
            connection.Close();

            //return Quiz_FillInTheBlankss;
            return GetQuiz_FillInTheBlankssFromReaderTable(Quiz_FillInTheBlankss);
        }
    }

    public DataSet GetQuiz_FillInTheBlanksByComprehensionID(int ComprehensionID )
    {
        DataSet Quiz_FillInTheBlankss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksByComprehensionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ComprehensionID", ComprehensionID);
            //ComprehensionID
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_FillInTheBlankss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_FillInTheBlankss;
        }
    }

    public List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlankListByComprehensionID(int ComprehensionID)
    {   
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksByComprehensionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ComprehensionID", ComprehensionID);
            //ComprehensionID
            connection.Open();

            IDataReader reader = command.ExecuteReader();

            return GetQuiz_FillInTheBlankssFromReader(reader);
        }
    }
    
	public DataSet GetQuiz_FillInTheBlanksPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksPageWise", connection))
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

    public DataSet GetQuiz_FillInTheBlanksPageWiseByChapterID(string answerString, int chapterID, int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksPageWiseByChapterID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AnswerString", answerString);
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

   

    public Quiz_FillInTheBlanks  GetQuiz_FillInTheBlanksByCourseID(int  courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_FillInTheBlanksFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_FillInTheBlanks  GetQuiz_FillInTheBlanksBySubjectID(int  subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_FillInTheBlanksFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_FillInTheBlanks  GetQuiz_FillInTheBlanksByChapterID(int  chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksByChapterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChapterID", SqlDbType.NVarChar).Value = chapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_FillInTheBlanksFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllQuiz_FillInTheBlanks()
    {
        DataSet Quiz_FillInTheBlankss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_FillInTheBlanks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_FillInTheBlankss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_FillInTheBlankss;
        }
    }

    public DataSet   GetAllQuiz_FillInTheBlankssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_FillInTheBlankssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlankssFromReaderTable(DataSet ds)
    {
        List<Quiz_FillInTheBlanks> quiz_FillInTheBlankss = new List<Quiz_FillInTheBlanks>();
        foreach (DataRow item in ds.Tables[0].Rows)
        {
            quiz_FillInTheBlankss.Add(GetQuiz_FillInTheBlanksFromReaderTable(item));

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                if (dr["FillInTheBlanksID"].ToString() == quiz_FillInTheBlankss[quiz_FillInTheBlankss.Count - 1].FillInTheBlanksID.ToString())
                {
                    quiz_FillInTheBlankss[quiz_FillInTheBlankss.Count - 1].AnswerString += dr["QuestionSl"].ToString() +" --> "+ dr["Answer"].ToString() + "<br/>";
                }
            }
        }
        return quiz_FillInTheBlankss;
    }

    public Quiz_FillInTheBlanks GetQuiz_FillInTheBlanksFromReaderTable(DataRow reader)
    {
        try
        {
            Quiz_FillInTheBlanks quiz_FillInTheBlanks = new Quiz_FillInTheBlanks
                (

                     DataAccessObject.IsNULL<int>(reader["FillInTheBlanksID"]),
                     DataAccessObject.IsNULL<int>(reader["ComprehensionID"]),
                     DataAccessObject.IsNULL<string>(reader["Question"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
            return quiz_FillInTheBlanks;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<Quiz_FillInTheBlanks> GetQuiz_FillInTheBlankssFromReader(IDataReader reader)
    {
        List<Quiz_FillInTheBlanks> quiz_FillInTheBlankss = new List<Quiz_FillInTheBlanks>();

        while (reader.Read())
        {
            quiz_FillInTheBlankss.Add(GetQuiz_FillInTheBlanksFromReader(reader));
        }
        return quiz_FillInTheBlankss;
    }

    public Quiz_FillInTheBlanks GetQuiz_FillInTheBlanksFromReader(IDataReader reader)
    {
        try
        {
            Quiz_FillInTheBlanks quiz_FillInTheBlanks = new Quiz_FillInTheBlanks
                (

                     DataAccessObject.IsNULL<int>(reader["FillInTheBlanksID"]),
                     DataAccessObject.IsNULL<int>(reader["ComprehensionID"]),
                     DataAccessObject.IsNULL<string>(reader["Question"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return quiz_FillInTheBlanks;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_FillInTheBlanks  GetQuiz_FillInTheBlanksByFillInTheBlanksID(int  fillInTheBlanksID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksByFillInTheBlanksID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FillInTheBlanksID", SqlDbType.Int).Value = fillInTheBlanksID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_FillInTheBlanksFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertQuiz_FillInTheBlanks(Quiz_FillInTheBlanks quiz_FillInTheBlanks)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_FillInTheBlanks", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FillInTheBlanksID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = quiz_FillInTheBlanks.ComprehensionID;
            cmd.Parameters.Add("@Question", SqlDbType.NText).Value = quiz_FillInTheBlanks.Question;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_FillInTheBlanks.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_FillInTheBlanks.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_FillInTheBlanks.ChapterID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_FillInTheBlanks.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_FillInTheBlanks.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_FillInTheBlanks.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_FillInTheBlanks.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FillInTheBlanksID"].Value;
        }
    }

    public bool UpdateQuiz_FillInTheBlanks(Quiz_FillInTheBlanks quiz_FillInTheBlanks)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_FillInTheBlanks", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FillInTheBlanksID", SqlDbType.Int).Value = quiz_FillInTheBlanks.FillInTheBlanksID;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = quiz_FillInTheBlanks.ComprehensionID;
            cmd.Parameters.Add("@Question", SqlDbType.NText).Value = quiz_FillInTheBlanks.Question;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_FillInTheBlanks.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_FillInTheBlanks.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_FillInTheBlanks.ChapterID;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_FillInTheBlanks.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_FillInTheBlanks.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_FillInTheBlanks(int fillInTheBlanksID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_FillInTheBlanks", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FillInTheBlanksID", SqlDbType.Int).Value = fillInTheBlanksID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

