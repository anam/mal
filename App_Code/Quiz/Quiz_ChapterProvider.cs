using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_ChapterProvider:DataAccessObject
{
	public SqlQuiz_ChapterProvider()
    {
    }


    public DataSet  GetAllQuiz_Chapters()
    {
        DataSet Quiz_Chapters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_Chapters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_Chapters);
            myadapter.Dispose();
            connection.Close();

            return Quiz_Chapters;
        }
    }
	public DataSet GetQuiz_ChapterPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_ChapterPageWise", connection))
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


    public Quiz_Chapter  GetQuiz_ChapterBySubjectID(int  subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ChapterBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ChapterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_Chapter  GetQuiz_ChapterByCourseID(int  courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ChapterByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ChapterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetDropDownLisAllQuiz_Chapter(int courseID, int subjectID)
    {
        DataSet Quiz_Chapters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_Chapter", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@subjectID", SqlDbType.Int).Value = subjectID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_Chapters);
            myadapter.Dispose();
            connection.Close();

            return Quiz_Chapters;
        }
    }
    public List<Quiz_Chapter> GetQuiz_ChaptersFromReader(IDataReader reader)
    {
        List<Quiz_Chapter> quiz_Chapters = new List<Quiz_Chapter>();

        while (reader.Read())
        {
            quiz_Chapters.Add(GetQuiz_ChapterFromReader(reader));
        }
        return quiz_Chapters;
    }

    public Quiz_Chapter GetQuiz_ChapterFromReader(IDataReader reader)
    {
        try
        {
            Quiz_Chapter quiz_Chapter = new Quiz_Chapter
                (

                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<string>(reader["ChapterName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return quiz_Chapter;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_Chapter  GetQuiz_ChapterByChapterID(int  chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ChapterByChapterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ChapterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertQuiz_Chapter(Quiz_Chapter quiz_Chapter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_Chapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_Chapter.SubjectID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_Chapter.CourseID;
            cmd.Parameters.Add("@ChapterName", SqlDbType.NVarChar).Value = quiz_Chapter.ChapterName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_Chapter.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_Chapter.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_Chapter.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_Chapter.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ChapterID"].Value;
        }
    }

    public bool UpdateQuiz_Chapter(Quiz_Chapter quiz_Chapter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_Chapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_Chapter.ChapterID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_Chapter.SubjectID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_Chapter.CourseID;
            cmd.Parameters.Add("@ChapterName", SqlDbType.NVarChar).Value = quiz_Chapter.ChapterName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_Chapter.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_Chapter.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_Chapter(int chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_Chapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

