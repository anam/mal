using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_QuestionChapterProvider:DataAccessObject
{
	public SqlSTD_QuestionChapterProvider()
    {
    }


    public DataSet  GetAllSTD_QuestionChapters()
    {
        DataSet STD_QuestionChapters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_QuestionChapters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_QuestionChapters);
            myadapter.Dispose();
            connection.Close();

            return STD_QuestionChapters;
        }
    }
	public DataSet GetSTD_QuestionChapterPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_QuestionChapterPageWise", connection))
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


    public STD_QuestionChapter  GetSTD_QuestionChapterByQuestionID(int  questionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_QuestionChapterByQuestionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuestionID", SqlDbType.NVarChar).Value = questionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_QuestionChapterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_QuestionChapter  GetSTD_QuestionChapterByChapterID(int  chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_QuestionChapterByChapterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChapterID", SqlDbType.NVarChar).Value = chapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_QuestionChapterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_QuestionChapter()
    {
        DataSet STD_QuestionChapters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_QuestionChapters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_QuestionChapters);
            myadapter.Dispose();
            connection.Close();

            return STD_QuestionChapters;
        }
    }

    public DataSet   GetAllSTD_SubjectsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_SubjectsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_QuestionChapter> GetSTD_QuestionChaptersFromReader(IDataReader reader)
    {
        List<STD_QuestionChapter> sTD_QuestionChapters = new List<STD_QuestionChapter>();

        while (reader.Read())
        {
            sTD_QuestionChapters.Add(GetSTD_QuestionChapterFromReader(reader));
        }
        return sTD_QuestionChapters;
    }

    public STD_QuestionChapter GetSTD_QuestionChapterFromReader(IDataReader reader)
    {
        try
        {
            STD_QuestionChapter sTD_QuestionChapter = new STD_QuestionChapter
                (

                     DataAccessObject.IsNULL<int>(reader["Question_ChapterID"]),
                     DataAccessObject.IsNULL<int>(reader["QuestionID"]),
                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_QuestionChapter;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_QuestionChapter  GetSTD_QuestionChapterByQuestion_ChapterID(int  question_ChapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_QuestionChapterByQuestion_ChapterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Question_ChapterID", SqlDbType.Int).Value = question_ChapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_QuestionChapterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_QuestionChapter(STD_QuestionChapter sTD_QuestionChapter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_QuestionChapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Question_ChapterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = sTD_QuestionChapter.QuestionID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = sTD_QuestionChapter.ChapterID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_QuestionChapter.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_QuestionChapter.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_QuestionChapter.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_QuestionChapter.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Question_ChapterID"].Value;
        }
    }

    public bool UpdateSTD_QuestionChapter(STD_QuestionChapter sTD_QuestionChapter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_QuestionChapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Question_ChapterID", SqlDbType.Int).Value = sTD_QuestionChapter.Question_ChapterID;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = sTD_QuestionChapter.QuestionID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = sTD_QuestionChapter.ChapterID;
            //cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = sTD_QuestionChapter.ChapterID;
            //cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = sTD_QuestionChapter.ChapterID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_QuestionChapter.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_QuestionChapter.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_QuestionChapter(int question_ChapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_QuestionChapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Question_ChapterID", SqlDbType.Int).Value = question_ChapterID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

