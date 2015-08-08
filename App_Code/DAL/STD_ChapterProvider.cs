using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ChapterProvider:DataAccessObject
{
	public SqlSTD_ChapterProvider()
    {
    }


    public DataSet  GetAllSTD_Chapters()
    {
        DataSet STD_Chapters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Chapters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Chapters);
            myadapter.Dispose();
            connection.Close();

            return STD_Chapters;
        }
    }
	public DataSet GetSTD_ChapterPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ChapterPageWise", connection))
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


    public STD_Chapter  GetSTD_ChapterBySubjectID(int  subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ChapterBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ChapterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_Chapter()
    {
        DataSet STD_Chapters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Chapters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Chapters);
            myadapter.Dispose();
            connection.Close();

            return STD_Chapters;
        }
    }

    public DataSet   GetAllSTD_ChaptersWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ChaptersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Chapter> GetSTD_ChaptersFromReader(IDataReader reader)
    {
        List<STD_Chapter> sTD_Chapters = new List<STD_Chapter>();

        while (reader.Read())
        {
            sTD_Chapters.Add(GetSTD_ChapterFromReader(reader));
        }
        return sTD_Chapters;
    }

    public STD_Chapter GetSTD_ChapterFromReader(IDataReader reader)
    {
        try
        {
            STD_Chapter sTD_Chapter = new STD_Chapter
                (

                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<string>(reader["ChapterName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_Chapter;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Chapter  GetSTD_ChapterByChapterID(int  chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ChapterByChapterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ChapterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Chapter(STD_Chapter sTD_Chapter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Chapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_Chapter.SubjectID;
            cmd.Parameters.Add("@ChapterName", SqlDbType.NVarChar).Value = sTD_Chapter.ChapterName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Chapter.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Chapter.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Chapter.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Chapter.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Chapter.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ChapterID"].Value;
        }
    }

    public bool UpdateSTD_Chapter(STD_Chapter sTD_Chapter)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Chapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = sTD_Chapter.ChapterID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_Chapter.SubjectID;
            cmd.Parameters.Add("@ChapterName", SqlDbType.NVarChar).Value = sTD_Chapter.ChapterName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Chapter.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Chapter.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Chapter.Description;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Chapter.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Chapter.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Chapter(int chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Chapter", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

