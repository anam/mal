using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_ExamQuestionDetailsProvider:DataAccessObject
{
	public SqlQuiz_ExamQuestionDetailsProvider()
    {
    }


    public DataSet  GetAllQuiz_ExamQuestionDetailss()
    {
        DataSet Quiz_ExamQuestionDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_ExamQuestionDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_ExamQuestionDetailss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_ExamQuestionDetailss;
        }
    }
	public DataSet GetQuiz_ExamQuestionDetailsPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_ExamQuestionDetailsPageWise", connection))
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


    public List<Quiz_ExamQuestionDetails>  GetQuiz_ExamQuestionDetailsByExamID(int  examID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamQuestionDetailsByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.NVarChar).Value = examID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            
            return GetQuiz_ExamQuestionDetailssFromReader(reader);
        }
    }

    public DataSet GetQuiz_ExamQuestionDetailsByQuestionID(int questionNo, int questionType)
    {
      
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_ExamQuestionDetailsByQuestionID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@QuestionNo", questionNo);
                command.Parameters.AddWithValue("@QuestionType", questionType);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public DataSet  GetDropDownLisAllQuiz_ExamQuestionDetails()
    {
        DataSet Quiz_ExamQuestionDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_ExamQuestionDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_ExamQuestionDetailss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_ExamQuestionDetailss;
        }
    }

    public DataSet   GetAllQuiz_ExamQuestionDetailssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_ExamQuestionDetailssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public List<Quiz_ExamQuestionDetails> GetQuiz_ExamQuestionDetailssFromReader(IDataReader reader)
    {
        List<Quiz_ExamQuestionDetails> quiz_ExamQuestionDetailss = new List<Quiz_ExamQuestionDetails>();

        while (reader.Read())
        {
            quiz_ExamQuestionDetailss.Add(GetQuiz_ExamQuestionDetailsFromReader(reader));
        }
        return quiz_ExamQuestionDetailss;
    }

    public Quiz_ExamQuestionDetails GetQuiz_ExamQuestionDetailsFromReader(IDataReader reader)
    {
        try
        {
            Quiz_ExamQuestionDetails quiz_ExamQuestionDetails = new Quiz_ExamQuestionDetails
                (

                     DataAccessObject.IsNULL<int>(reader["ExamQuestionDetailsID"]),
                     DataAccessObject.IsNULL<int>(reader["ExamID"]),
                     DataAccessObject.IsNULL<int>(reader["QuestionType"]),
                     DataAccessObject.IsNULL<int>(reader["QuestionNo"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return quiz_ExamQuestionDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_ExamQuestionDetails  GetQuiz_ExamQuestionDetailsByExamQuestionDetailsID(int  examQuestionDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_ExamQuestionDetailsByExamQuestionDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamQuestionDetailsID", SqlDbType.Int).Value = examQuestionDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_ExamQuestionDetailsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertQuiz_ExamQuestionDetails(Quiz_ExamQuestionDetails quiz_ExamQuestionDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_ExamQuestionDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamQuestionDetailsID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = quiz_ExamQuestionDetails.ExamID;
            cmd.Parameters.Add("@QuestionType", SqlDbType.Int).Value = quiz_ExamQuestionDetails.QuestionType;
            cmd.Parameters.Add("@QuestionNo", SqlDbType.Int).Value = quiz_ExamQuestionDetails.QuestionNo;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_ExamQuestionDetails.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_ExamQuestionDetails.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_ExamQuestionDetails.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_ExamQuestionDetails.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamQuestionDetailsID"].Value;
        }
    }

    public bool UpdateQuiz_ExamQuestionDetails(Quiz_ExamQuestionDetails quiz_ExamQuestionDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_ExamQuestionDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamQuestionDetailsID", SqlDbType.Int).Value = quiz_ExamQuestionDetails.ExamQuestionDetailsID;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = quiz_ExamQuestionDetails.ExamID;
            cmd.Parameters.Add("@QuestionType", SqlDbType.Int).Value = quiz_ExamQuestionDetails.QuestionType;
            cmd.Parameters.Add("@QuestionNo", SqlDbType.Int).Value = quiz_ExamQuestionDetails.QuestionNo;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_ExamQuestionDetails.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_ExamQuestionDetails.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_ExamQuestionDetails(int examQuestionDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_ExamQuestionDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamQuestionDetailsID", SqlDbType.Int).Value = examQuestionDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
    public bool DeleteQuiz_ExamQuestionDetails(Quiz_ExamQuestionDetails quiz_ExamQuestionDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_ExamQuestionDetailsByExam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = quiz_ExamQuestionDetails.ExamID;
            cmd.Parameters.Add("@QuestionNo", SqlDbType.Int).Value = quiz_ExamQuestionDetails.QuestionNo;
            cmd.Parameters.Add("@QuestionType", SqlDbType.Int).Value = quiz_ExamQuestionDetails.QuestionType;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

}

