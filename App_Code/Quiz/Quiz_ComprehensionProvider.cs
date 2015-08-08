using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_ComprehensionProvider:DataAccessObject
{
	public SqlQuiz_ComprehensionProvider()
    {
    }


    public DataSet  GetAllQuiz_Comprehensions()
    {
        DataSet Quiz_Comprehensions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_Comprehensions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_Comprehensions);
            myadapter.Dispose();
            connection.Close();

            return Quiz_Comprehensions;
        }
    }
	public DataSet GetQuiz_ComprehensionPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_ComprehensionPageWise", connection))
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

    public List<Quiz_Comprehension> GetQuiz_ComprehensionsRandomly(int courseID, int subjectID, int chapterID, int count)
    {   
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ComprehensionsRandomly", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            
            return GetQuiz_ComprehensionsFromReader(reader);
        }
    }

    public Quiz_Comprehension  GetQuiz_ComprehensionByCourseID(int  courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ComprehensionByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ComprehensionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_Comprehension  GetQuiz_ComprehensionBySubjectID(int  subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ComprehensionBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ComprehensionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_Comprehension  GetQuiz_ComprehensionByChapterID(int  chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ComprehensionByChapterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChapterID", SqlDbType.NVarChar).Value = chapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ComprehensionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllQuiz_Comprehension()
    {
        DataSet Quiz_Comprehensions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_Comprehension", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_Comprehensions);
            myadapter.Dispose();
            connection.Close();

            return Quiz_Comprehensions;
        }
    }

    public DataSet   GetAllQuiz_ComprehensionsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_ComprehensionsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<Quiz_Comprehension> GetQuiz_ComprehensionsFromReader(IDataReader reader)
    {
        List<Quiz_Comprehension> quiz_Comprehensions = new List<Quiz_Comprehension>();

        while (reader.Read())
        {
            quiz_Comprehensions.Add(GetQuiz_ComprehensionFromReader(reader));
        }
        return quiz_Comprehensions;
    }

    public Quiz_Comprehension GetQuiz_ComprehensionFromReader(IDataReader reader)
    {
        try
        {
            Quiz_Comprehension quiz_Comprehension = new Quiz_Comprehension
                (

                     DataAccessObject.IsNULL<int>(reader["ComprehensionID"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<string>(reader["Comprehension"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return quiz_Comprehension;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_Comprehension  GetQuiz_ComprehensionByComprehensionID(int  comprehensionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ComprehensionByComprehensionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = comprehensionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ComprehensionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertQuiz_Comprehension(Quiz_Comprehension quiz_Comprehension)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_Comprehension", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_Comprehension.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_Comprehension.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_Comprehension.ChapterID;
            cmd.Parameters.Add("@Comprehension", SqlDbType.NText).Value = quiz_Comprehension.Comprehension;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_Comprehension.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_Comprehension.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_Comprehension.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_Comprehension.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ComprehensionID"].Value;
        }
    }

    public bool UpdateQuiz_Comprehension(Quiz_Comprehension quiz_Comprehension)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_Comprehension", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = quiz_Comprehension.ComprehensionID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_Comprehension.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_Comprehension.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_Comprehension.ChapterID;
            cmd.Parameters.Add("@Comprehension", SqlDbType.NText).Value = quiz_Comprehension.Comprehension;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_Comprehension.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_Comprehension.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_Comprehension(int comprehensionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_Comprehension", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = comprehensionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

