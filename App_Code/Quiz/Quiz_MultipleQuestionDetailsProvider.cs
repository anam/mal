using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_MultipleQuestionDetailsProvider:DataAccessObject
{
	public SqlQuiz_MultipleQuestionDetailsProvider()
    {
    }


    public DataSet  GetAllQuiz_MultipleQuestionDetailss()
    {
        DataSet Quiz_MultipleQuestionDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_MultipleQuestionDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_MultipleQuestionDetailss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_MultipleQuestionDetailss;
        }
    }
	public DataSet GetQuiz_MultipleQuestionDetailsPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionDetailsPageWise", connection))
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


    public DataSet GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID(int multipleQustionID)
    {
        DataSet Quiz_MultipleQuestionDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID", connection);
            command.Parameters.AddWithValue("@multipleQustionID", multipleQustionID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_MultipleQuestionDetailss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_MultipleQuestionDetailss;
        }
    }
    public Quiz_MultipleQuestionDetails  GetQuiz_MultipleQuestionDetailsByMultipleQustionID(int  multipleQustionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionDetailsByMultipleQustionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MultipleQustionID", SqlDbType.NVarChar).Value = multipleQustionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_MultipleQuestionDetailsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllQuiz_MultipleQuestionDetails()
    {
        DataSet Quiz_MultipleQuestionDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_MultipleQuestionDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_MultipleQuestionDetailss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_MultipleQuestionDetailss;
        }
    }

    public DataSet   GetAllQuiz_MultipleQuestionDetailssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_MultipleQuestionDetailssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<Quiz_MultipleQuestionDetails> GetQuiz_MultipleQuestionDetailssFromReader(IDataReader reader)
    {
        List<Quiz_MultipleQuestionDetails> quiz_MultipleQuestionDetailss = new List<Quiz_MultipleQuestionDetails>();

        while (reader.Read())
        {
            quiz_MultipleQuestionDetailss.Add(GetQuiz_MultipleQuestionDetailsFromReader(reader));
        }
        return quiz_MultipleQuestionDetailss;
    }

    public Quiz_MultipleQuestionDetails GetQuiz_MultipleQuestionDetailsFromReader(IDataReader reader)
    {
        try
        {
            Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails = new Quiz_MultipleQuestionDetails
                (

                     DataAccessObject.IsNULL<int>(reader["MultipleQuestionDetailsID"]),
                     DataAccessObject.IsNULL<int>(reader["MultipleQustionID"]),
                     DataAccessObject.IsNULL<string>(reader["QuestionTitle"]),
                     DataAccessObject.IsNULL<bool>(reader["IsAnswer"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return quiz_MultipleQuestionDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_MultipleQuestionDetails  GetQuiz_MultipleQuestionDetailsByMultipleQuestionDetailsID(int  multipleQuestionDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_MultipleQuestionDetailsByMultipleQuestionDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MultipleQuestionDetailsID", SqlDbType.Int).Value = multipleQuestionDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_MultipleQuestionDetailsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertQuiz_MultipleQuestionDetails(Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_MultipleQuestionDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MultipleQuestionDetailsID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MultipleQustionID", SqlDbType.Int).Value = quiz_MultipleQuestionDetails.MultipleQustionID;
            cmd.Parameters.Add("@QuestionTitle", SqlDbType.NText).Value = quiz_MultipleQuestionDetails.QuestionTitle;
            cmd.Parameters.Add("@IsAnswer", SqlDbType.Bit).Value = quiz_MultipleQuestionDetails.IsAnswer;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_MultipleQuestionDetails.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_MultipleQuestionDetails.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_MultipleQuestionDetails.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_MultipleQuestionDetails.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MultipleQuestionDetailsID"].Value;
        }
    }

    public bool UpdateQuiz_MultipleQuestionDetails(Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_MultipleQuestionDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MultipleQuestionDetailsID", SqlDbType.Int).Value = quiz_MultipleQuestionDetails.MultipleQuestionDetailsID;
            cmd.Parameters.Add("@MultipleQustionID", SqlDbType.Int).Value = quiz_MultipleQuestionDetails.MultipleQustionID;
            cmd.Parameters.Add("@QuestionTitle", SqlDbType.NText).Value = quiz_MultipleQuestionDetails.QuestionTitle;
            cmd.Parameters.Add("@IsAnswer", SqlDbType.Bit).Value = quiz_MultipleQuestionDetails.IsAnswer;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_MultipleQuestionDetails.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_MultipleQuestionDetails.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_MultipleQuestionDetails(int multipleQuestionDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_MultipleQuestionDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MultipleQuestionDetailsID", SqlDbType.Int).Value = multipleQuestionDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

