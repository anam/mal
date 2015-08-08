using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_QuestionProvider:DataAccessObject
{
	public SqlSTD_QuestionProvider()
    {
    }


    public DataSet  GetAllSTD_Questions()
    {
        DataSet STD_Questions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Questions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Questions);
            myadapter.Dispose();
            connection.Close();

            return STD_Questions;
        }
    }
	public DataSet GetSTD_QuestionPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_QuestionPageWise", connection))
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


    public STD_Question  GetSTD_QuestionByQuestionTypeID(int  questionTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_QuestionByQuestionTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuestionTypeID", SqlDbType.NVarChar).Value = questionTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_QuestionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_Question()
    {
        DataSet STD_Questions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Questions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Questions);
            myadapter.Dispose();
            connection.Close();

            return STD_Questions;
        }
    }

    public DataSet   GetAllSTD_QuestionsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_QuestionsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Question> GetSTD_QuestionsFromReader(IDataReader reader)
    {
        List<STD_Question> sTD_Questions = new List<STD_Question>();

        while (reader.Read())
        {
            sTD_Questions.Add(GetSTD_QuestionFromReader(reader));
        }
        return sTD_Questions;
    }

    public STD_Question GetSTD_QuestionFromReader(IDataReader reader)
    {
        try
        {
            STD_Question sTD_Question = new STD_Question
                (

                     DataAccessObject.IsNULL<int>(reader["QuestionID"]),
                     DataAccessObject.IsNULL<int>(reader["QuestionTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<int>(reader["Mark"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_Question;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Question  GetSTD_QuestionByQuestionID(int  questionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_QuestionByQuestionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuestionID", SqlDbType.Int).Value = questionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_QuestionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Question(STD_Question sTD_Question)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Question", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@QuestionTypeID", SqlDbType.Int).Value = sTD_Question.QuestionTypeID;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Question.Description;
            cmd.Parameters.Add("@Mark", SqlDbType.Int).Value = sTD_Question.Mark;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Question.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Question.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Question.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Question.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@QuestionID"].Value;
        }
    }

    public bool UpdateSTD_Question(STD_Question sTD_Question)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Question", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = sTD_Question.QuestionID;
            cmd.Parameters.Add("@QuestionTypeID", SqlDbType.Int).Value = sTD_Question.QuestionTypeID;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Question.Description;
            cmd.Parameters.Add("@Mark", SqlDbType.Int).Value = sTD_Question.Mark;
            //cmd.Parameters.Add("@Mark", SqlDbType.Int).Value = sTD_Question.Mark;
            //cmd.Parameters.Add("@Mark", SqlDbType.Int).Value = sTD_Question.Mark;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Question.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Question.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Question(int questionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Question", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionID", SqlDbType.Int).Value = questionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

