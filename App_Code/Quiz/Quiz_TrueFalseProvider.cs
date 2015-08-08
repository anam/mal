using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_TrueFalseProvider:DataAccessObject
{
	public SqlQuiz_TrueFalseProvider()
    {
    }


    public DataSet  GetAllQuiz_TrueFalses()
    {
        DataSet Quiz_TrueFalses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_TrueFalses", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_TrueFalses);
            myadapter.Dispose();
            connection.Close();

            return Quiz_TrueFalses;
        }
    }

    public List<Quiz_TrueFalse> GetQuiz_TrueFalsesRandomly(int courseID, int subjectID, int chapterID, bool isDrCr, int count)
    {
        //DataSet Quiz_TrueFalses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_TrueFalseRandomly", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@IsDrCr", SqlDbType.Bit).Value = isDrCr;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            connection.Open();
            //SqlDataAdapter myadapter = new SqlDataAdapter(command);
            //myadapter.Fill(Quiz_TrueFalses);
            //myadapter.Dispose();
            //connection.Close();

            //return Quiz_TrueFalses;
            IDataReader reader = command.ExecuteReader();
            return GetQuiz_TrueFalsesFromReader(reader);
        }
    }

    

    public List<Quiz_TrueFalse> GetQuiz_TrueFalsesByExamID(int courseID, int subjectID, int chapterID, bool isDrCr, int count,int examID)
    {
        //DataSet Quiz_TrueFalses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_TrueFalseByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@IsDrCr", SqlDbType.Bit).Value = isDrCr;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            //SqlDataAdapter myadapter = new SqlDataAdapter(command);
            //myadapter.Fill(Quiz_TrueFalses);
            //myadapter.Dispose();
            //connection.Close();

            //return Quiz_TrueFalses;
            IDataReader reader = command.ExecuteReader();
            return GetQuiz_TrueFalsesFromReader(reader);
        }
    }

    public List<Quiz_TrueFalse> GetQuiz_TrueFalsesNotByExamID(int courseID, int subjectID, int chapterID, bool isDrCr, int count, int examID)
    {
        //DataSet Quiz_TrueFalses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_TrueFalseNotByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
            command.Parameters.Add("@IsDrCr", SqlDbType.Bit).Value = isDrCr;
            command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            //SqlDataAdapter myadapter = new SqlDataAdapter(command);
            //myadapter.Fill(Quiz_TrueFalses);
            //myadapter.Dispose();
            //connection.Close();

            //return Quiz_TrueFalses;
            IDataReader reader = command.ExecuteReader();
            return GetQuiz_TrueFalsesFromReader(reader);
        }
    }


    //public List<Quiz_TrueFalse> GetQuiz_TrueFalsesNotByExamID(int courseID, int subjectID, int chapterID, bool isDrCr, int count, int examID)
    //{
    //    //DataSet Quiz_TrueFalses = new DataSet();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetQuiz_TrueFalseNotByExamID", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseID;
    //        command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
    //        command.Parameters.Add("@ChapterID", SqlDbType.Int).Value = chapterID;
    //        command.Parameters.Add("@IsDrCr", SqlDbType.Bit).Value = isDrCr;
    //        command.Parameters.Add("@Count", SqlDbType.Int).Value = count;
    //        command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
    //        connection.Open();
    //        //SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //        //myadapter.Fill(Quiz_TrueFalses);
    //        //myadapter.Dispose();
    //        //connection.Close();

    //        //return Quiz_TrueFalses;
    //        IDataReader reader = command.ExecuteReader();
    //        return GetQuiz_TrueFalsesFromReader(reader);
    //    }
    //}
    ////

    public DataSet GetQuiz_TrueFalseByComprehensionID(int ComprehensionID)
    {
        DataSet Quiz_TrueFalses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_TrueFalseByComprehensionID", connection);
            command.Parameters.AddWithValue("@ComprehensionID", ComprehensionID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_TrueFalses);
            myadapter.Dispose();
            connection.Close();

            return Quiz_TrueFalses;
        }
    }

    public List<Quiz_TrueFalse> GetQuiz_TrueFalseListByComprehensionID(int ComprehensionID)
    {
        DataSet Quiz_TrueFalses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_TrueFalseByComprehensionID", connection);
            command.Parameters.AddWithValue("@ComprehensionID", ComprehensionID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader();

            return GetQuiz_TrueFalsesFromReader(reader);
        }
    }

    public DataSet GetQuiz_DrCrByComprehensionID(int ComprehensionID)
    {
        DataSet Quiz_TrueFalses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_DrCrByComprehensionID", connection);
            command.Parameters.AddWithValue("@ComprehensionID", ComprehensionID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_TrueFalses);
            myadapter.Dispose();
            connection.Close();

            return Quiz_TrueFalses;
        }
    }

    public List<Quiz_TrueFalse> GetQuiz_DrCrListByComprehensionID(int ComprehensionID)
    {   
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_DrCrByComprehensionID", connection);
            command.Parameters.AddWithValue("@ComprehensionID", ComprehensionID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();

            IDataReader reader = command.ExecuteReader();
            return GetQuiz_TrueFalsesFromReader(reader);
        }
    }
    
    public DataSet GetQuiz_ByComprehensionID(int ComprehensionID)
    {
        DataSet Quiz_TrueFalses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_DrCrByComprehensionID", connection);
            command.Parameters.AddWithValue("@ComprehensionID", ComprehensionID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_TrueFalses);
            myadapter.Dispose();
            connection.Close();

            return Quiz_TrueFalses;
        }
    }

    public DataSet GetQuiz_TrueFalsePageWise(bool isDrCr, int pageIndex, int PageSize, out int recordCount, int courseID, int subjectID, int chapterID)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_TrueFalsePageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IsDrCr", isDrCr);
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize",  PageSize );
                command.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                command.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                command.Parameters.Add("@courseID", SqlDbType.Int).Value = courseID;
                command.Parameters.Add("@subjectID", SqlDbType.Int).Value = subjectID;
                command.Parameters.Add("@chapterID", SqlDbType.Int).Value = chapterID;
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

    public Quiz_TrueFalse  GetQuiz_TrueFalseByCourseID(int  courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_TrueFalseByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_TrueFalseFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_TrueFalse  GetQuiz_TrueFalseBySubjectID(int  subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_TrueFalseBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_TrueFalseFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public Quiz_TrueFalse  GetQuiz_TrueFalseByChapterID(int  chapterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_TrueFalseByChapterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChapterID", SqlDbType.NVarChar).Value = chapterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_TrueFalseFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllQuiz_TrueFalse()
    {
        DataSet Quiz_TrueFalses = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_TrueFalse", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_TrueFalses);
            myadapter.Dispose();
            connection.Close();

            return Quiz_TrueFalses;
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

    public List<Quiz_TrueFalse> GetQuiz_TrueFalsesFromReader(IDataReader reader)
    {
        List<Quiz_TrueFalse> quiz_TrueFalses = new List<Quiz_TrueFalse>();

        while (reader.Read())
        {
            quiz_TrueFalses.Add(GetQuiz_TrueFalseFromReader(reader));
        }
        return quiz_TrueFalses;
    }

    public Quiz_TrueFalse GetQuiz_TrueFalseFromReader(IDataReader reader)
    {
        try
        {
            Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse
                (

                     DataAccessObject.IsNULL<int>(reader["TrueFalseID"]),
                     DataAccessObject.IsNULL<int>(reader["ComprehensionID"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["ChapterID"]),
                     DataAccessObject.IsNULL<string>(reader["QuestionTitle"]),
                     DataAccessObject.IsNULL<bool>(reader["IsDrCr"]),
                     DataAccessObject.IsNULL<bool>(reader["IsTrue"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return quiz_TrueFalse;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_TrueFalse  GetQuiz_TrueFalseByTrueFalseID(int  trueFalseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_TrueFalseByTrueFalseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TrueFalseID", SqlDbType.Int).Value = trueFalseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_TrueFalseFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertQuiz_TrueFalse(Quiz_TrueFalse quiz_TrueFalse)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_TrueFalse", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TrueFalseID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = quiz_TrueFalse.ComprehensionID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_TrueFalse.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_TrueFalse.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_TrueFalse.ChapterID;
            cmd.Parameters.Add("@QuestionTitle", SqlDbType.NVarChar).Value = quiz_TrueFalse.QuestionTitle;
            cmd.Parameters.Add("@IsDrCr", SqlDbType.Bit).Value = quiz_TrueFalse.IsDrCr;
            cmd.Parameters.Add("@IsTrue", SqlDbType.Bit).Value = quiz_TrueFalse.IsTrue;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_TrueFalse.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_TrueFalse.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_TrueFalse.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_TrueFalse.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@TrueFalseID"].Value;
        }
    }

    public bool UpdateQuiz_TrueFalse(Quiz_TrueFalse quiz_TrueFalse)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_TrueFalse", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TrueFalseID", SqlDbType.Int).Value = quiz_TrueFalse.TrueFalseID;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = quiz_TrueFalse.ComprehensionID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = quiz_TrueFalse.CourseID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = quiz_TrueFalse.SubjectID;
            cmd.Parameters.Add("@ChapterID", SqlDbType.Int).Value = quiz_TrueFalse.ChapterID;
            cmd.Parameters.Add("@QuestionTitle", SqlDbType.NVarChar).Value = quiz_TrueFalse.QuestionTitle;
            cmd.Parameters.Add("@IsDrCr", SqlDbType.Bit).Value = quiz_TrueFalse.IsDrCr;
            cmd.Parameters.Add("@IsTrue", SqlDbType.Bit).Value = quiz_TrueFalse.IsTrue;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_TrueFalse.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_TrueFalse.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_TrueFalse(int trueFalseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_TrueFalse", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TrueFalseID", SqlDbType.Int).Value = trueFalseID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

