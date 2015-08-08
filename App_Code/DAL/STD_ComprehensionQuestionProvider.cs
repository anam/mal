using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ComprehensionQuestionProvider:DataAccessObject
{
	public SqlSTD_ComprehensionQuestionProvider()
    {
    }


    public DataSet  GetAllSTD_ComprehensionQuestions()
    {
        DataSet STD_ComprehensionQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ComprehensionQuestions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ComprehensionQuestions);
            myadapter.Dispose();
            connection.Close();

            return STD_ComprehensionQuestions;
        }
    }
	public DataSet GetSTD_ComprehensionQuestionPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ComprehensionQuestionPageWise", connection))
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


    public STD_ComprehensionQuestion  GetSTD_ComprehensionQuestionByQuestionID(int  questionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ComprehensionQuestionByQuestionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuestionID", SqlDbType.NVarChar).Value = questionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ComprehensionQuestionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ComprehensionQuestion  GetSTD_ComprehensionQuestionByComprehensionID(int  comprehensionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ComprehensionQuestionByComprehensionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ComprehensionID", SqlDbType.NVarChar).Value = comprehensionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ComprehensionQuestionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_ComprehensionQuestion()
    {
        DataSet STD_ComprehensionQuestions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ComprehensionQuestions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ComprehensionQuestions);
            myadapter.Dispose();
            connection.Close();

            return STD_ComprehensionQuestions;
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
    public List<STD_ComprehensionQuestion> GetSTD_ComprehensionQuestionsFromReader(IDataReader reader)
    {
        List<STD_ComprehensionQuestion> sTD_ComprehensionQuestions = new List<STD_ComprehensionQuestion>();

        while (reader.Read())
        {
            sTD_ComprehensionQuestions.Add(GetSTD_ComprehensionQuestionFromReader(reader));
        }
        return sTD_ComprehensionQuestions;
    }

    public STD_ComprehensionQuestion GetSTD_ComprehensionQuestionFromReader(IDataReader reader)
    {
        try
        {
            STD_ComprehensionQuestion sTD_ComprehensionQuestion = new STD_ComprehensionQuestion
                (

                     DataAccessObject.IsNULL<int>(reader["ComprehensionQuestionID"]),
                     DataAccessObject.IsNULL<int>(reader["QuestionID"]),
                     DataAccessObject.IsNULL<int>(reader["ComprehensionID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_ComprehensionQuestion;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ComprehensionQuestion  GetSTD_ComprehensionQuestionByComprehensionQuestionID(int  comprehensionQuestionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ComprehensionQuestionByComprehensionQuestionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ComprehensionQuestionID", SqlDbType.Int).Value = comprehensionQuestionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ComprehensionQuestionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ComprehensionQuestion(STD_ComprehensionQuestion sTD_ComprehensionQuestion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ComprehensionQuestion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComprehensionQuestionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = sTD_ComprehensionQuestion.QuestionID;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = sTD_ComprehensionQuestion.ComprehensionID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ComprehensionQuestion.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ComprehensionQuestion.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ComprehensionQuestion.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ComprehensionQuestion.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ComprehensionQuestionID"].Value;
        }
    }

    public bool UpdateSTD_ComprehensionQuestion(STD_ComprehensionQuestion sTD_ComprehensionQuestion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ComprehensionQuestion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComprehensionQuestionID", SqlDbType.Int).Value = sTD_ComprehensionQuestion.ComprehensionQuestionID;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = sTD_ComprehensionQuestion.QuestionID;
            cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = sTD_ComprehensionQuestion.ComprehensionID;
            //cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = sTD_ComprehensionQuestion.ComprehensionID;
            //cmd.Parameters.Add("@ComprehensionID", SqlDbType.Int).Value = sTD_ComprehensionQuestion.ComprehensionID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ComprehensionQuestion.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ComprehensionQuestion.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ComprehensionQuestion(int comprehensionQuestionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ComprehensionQuestion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComprehensionQuestionID", SqlDbType.Int).Value = comprehensionQuestionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

