using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlQuiz_FillInTheBlanksDetailsProvider:DataAccessObject
{
	public SqlQuiz_FillInTheBlanksDetailsProvider()
    {
    }


    public DataSet  GetAllQuiz_FillInTheBlanksDetailss()
    {
        DataSet Quiz_FillInTheBlanksDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_FillInTheBlanksDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_FillInTheBlanksDetailss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_FillInTheBlanksDetailss;
        }
    }
	public DataSet GetQuiz_FillInTheBlanksDetailsPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksDetailsPageWise", connection))
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
    public DataSet GetQuiz_FillInTheBlanksByFillInTheBlanksID(int fillInTheBlanksID)
    {
        DataSet Quiz_FillInTheBlanksDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_FillInTheBlanksByFillInTheBlanksID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FillInTheBlanksID", SqlDbType.NVarChar).Value = fillInTheBlanksID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_FillInTheBlanksDetailss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_FillInTheBlanksDetailss;
        }
    }
    
    //public Quiz_FillInTheBlanksDetails  GetQuiz_FillInTheBlanksDetailsByFillInTheBlanksID(int  fillInTheBlanksID)
    //{
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksDetailsByFillInTheBlanksID", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@FillInTheBlanksID", SqlDbType.NVarChar).Value = fillInTheBlanksID;
    //        connection.Open();
    //        IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
    //        if (reader.Read())
    //        {
    //        return GetQuiz_FillInTheBlanksDetailsFromReader(reader);
    //         }
    //        else
    //        {
    //        return null;
    //        }
    //    }
    //}

    public DataSet  GetDropDownLisAllQuiz_FillInTheBlanksDetails()
    {
        DataSet Quiz_FillInTheBlanksDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllQuiz_FillInTheBlanksDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(Quiz_FillInTheBlanksDetailss);
            myadapter.Dispose();
            connection.Close();

            return Quiz_FillInTheBlanksDetailss;
        }
    }

    public DataSet   GetAllQuiz_FillInTheBlanksDetailssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_FillInTheBlanksDetailssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<Quiz_FillInTheBlanksDetails> GetQuiz_FillInTheBlanksDetailssFromReader(IDataReader reader)
    {
        List<Quiz_FillInTheBlanksDetails> quiz_FillInTheBlanksDetailss = new List<Quiz_FillInTheBlanksDetails>();

        while (reader.Read())
        {
            quiz_FillInTheBlanksDetailss.Add(GetQuiz_FillInTheBlanksDetailsFromReader(reader));
        }
        return quiz_FillInTheBlanksDetailss;
    }

    public Quiz_FillInTheBlanksDetails GetQuiz_FillInTheBlanksDetailsFromReader(IDataReader reader)
    {
        try
        {
            Quiz_FillInTheBlanksDetails quiz_FillInTheBlanksDetails = new Quiz_FillInTheBlanksDetails
                (

                     DataAccessObject.IsNULL<int>(reader["FillInTheBlanksDetailsID"]),
                     DataAccessObject.IsNULL<int>(reader["FillInTheBlanksID"]),
                     DataAccessObject.IsNULL<int>(reader["QuestionSl"]),
                     DataAccessObject.IsNULL<string>(reader["Answer"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return quiz_FillInTheBlanksDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Quiz_FillInTheBlanksDetails  GetQuiz_FillInTheBlanksDetailsByFillInTheBlanksDetailsID(int  fillInTheBlanksDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetQuiz_FillInTheBlanksDetailsByFillInTheBlanksDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FillInTheBlanksDetailsID", SqlDbType.Int).Value = fillInTheBlanksDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetQuiz_FillInTheBlanksDetailsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertQuiz_FillInTheBlanksDetails(Quiz_FillInTheBlanksDetails quiz_FillInTheBlanksDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertQuiz_FillInTheBlanksDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FillInTheBlanksDetailsID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@FillInTheBlanksID", SqlDbType.Int).Value = quiz_FillInTheBlanksDetails.FillInTheBlanksID;
            cmd.Parameters.Add("@QuestionSl", SqlDbType.Int).Value = quiz_FillInTheBlanksDetails.QuestionSl;
            cmd.Parameters.Add("@Answer", SqlDbType.NVarChar).Value = quiz_FillInTheBlanksDetails.Answer;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = quiz_FillInTheBlanksDetails.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = quiz_FillInTheBlanksDetails.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_FillInTheBlanksDetails.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_FillInTheBlanksDetails.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FillInTheBlanksDetailsID"].Value;
        }
    }

    public bool UpdateQuiz_FillInTheBlanksDetails(Quiz_FillInTheBlanksDetails quiz_FillInTheBlanksDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateQuiz_FillInTheBlanksDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FillInTheBlanksDetailsID", SqlDbType.Int).Value = quiz_FillInTheBlanksDetails.FillInTheBlanksDetailsID;
            cmd.Parameters.Add("@FillInTheBlanksID", SqlDbType.Int).Value = quiz_FillInTheBlanksDetails.FillInTheBlanksID;
            cmd.Parameters.Add("@QuestionSl", SqlDbType.Int).Value = quiz_FillInTheBlanksDetails.QuestionSl;
            cmd.Parameters.Add("@Answer", SqlDbType.NVarChar).Value = quiz_FillInTheBlanksDetails.Answer;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = quiz_FillInTheBlanksDetails.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = quiz_FillInTheBlanksDetails.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteQuiz_FillInTheBlanksDetails(int fillInTheBlanksDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteQuiz_FillInTheBlanksDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FillInTheBlanksDetailsID", SqlDbType.Int).Value = fillInTheBlanksDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

