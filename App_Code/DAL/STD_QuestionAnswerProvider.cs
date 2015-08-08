using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_QuestionAnswerProvider:DataAccessObject
{
	public SqlSTD_QuestionAnswerProvider()
    {
    }


    public DataSet  GetAllSTD_QuestionAnswers()
    {
        DataSet STD_QuestionAnswers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_QuestionAnswers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_QuestionAnswers);
            myadapter.Dispose();
            connection.Close();

            return STD_QuestionAnswers;
        }
    }
	public DataSet GetSTD_QuestionAnswerPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_QuestionAnswerPageWise", connection))
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


    public STD_QuestionAnswer  GetSTD_QuestionAnswerByQuestionID(int  questionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_QuestionAnswerByQuestionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuestionID", SqlDbType.NVarChar).Value = questionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_QuestionAnswerFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_QuestionAnswer()
    {
        DataSet STD_QuestionAnswers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_QuestionAnswers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_QuestionAnswers);
            myadapter.Dispose();
            connection.Close();

            return STD_QuestionAnswers;
        }
    }

    public DataSet   GetAllSTD_QuestionAnswersWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_QuestionAnswersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_QuestionAnswer> GetSTD_QuestionAnswersFromReader(IDataReader reader)
    {
        List<STD_QuestionAnswer> sTD_QuestionAnswers = new List<STD_QuestionAnswer>();

        while (reader.Read())
        {
            sTD_QuestionAnswers.Add(GetSTD_QuestionAnswerFromReader(reader));
        }
        return sTD_QuestionAnswers;
    }

    public STD_QuestionAnswer GetSTD_QuestionAnswerFromReader(IDataReader reader)
    {
        try
        {
            STD_QuestionAnswer sTD_QuestionAnswer = new STD_QuestionAnswer
                (

                     DataAccessObject.IsNULL<int>(reader["QuestionAnswerID"]),
                     DataAccessObject.IsNULL<int>(reader["QuestionID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<bool>(reader["IsCorrectQuestionAnswer"]),
                     DataAccessObject.IsNULL<string>(reader["Description"])
                );
             return sTD_QuestionAnswer;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_QuestionAnswer  GetSTD_QuestionAnswerByQuestionAnswerID(int  questionAnswerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_QuestionAnswerByQuestionAnswerID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuestionAnswerID", SqlDbType.Int).Value = questionAnswerID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_QuestionAnswerFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_QuestionAnswer(STD_QuestionAnswer sTD_QuestionAnswer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_QuestionAnswer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionAnswerID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = sTD_QuestionAnswer.QuestionID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_QuestionAnswer.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_QuestionAnswer.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_QuestionAnswer.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_QuestionAnswer.UpdateDate;
            cmd.Parameters.Add("@IsCorrectQuestionAnswer", SqlDbType.Bit).Value = sTD_QuestionAnswer.IsCorrectQuestionAnswer;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_QuestionAnswer.Description;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@QuestionAnswerID"].Value;
        }
    }

    public bool UpdateSTD_QuestionAnswer(STD_QuestionAnswer sTD_QuestionAnswer)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_QuestionAnswer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionAnswerID", SqlDbType.Int).Value = sTD_QuestionAnswer.QuestionAnswerID;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = sTD_QuestionAnswer.QuestionID;
            //cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = sTD_QuestionAnswer.QuestionID;
            //cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = sTD_QuestionAnswer.QuestionID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_QuestionAnswer.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_QuestionAnswer.UpdateDate;
            cmd.Parameters.Add("@IsCorrectQuestionAnswer", SqlDbType.Bit).Value = sTD_QuestionAnswer.IsCorrectQuestionAnswer;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_QuestionAnswer.Description;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_QuestionAnswer(int questionAnswerID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_QuestionAnswer", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionAnswerID", SqlDbType.Int).Value = questionAnswerID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

