using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_QuestionTypeProvider:DataAccessObject
{
	public SqlSTD_QuestionTypeProvider()
    {
    }


    public DataSet  GetAllSTD_QuestionTypes()
    {
        DataSet STD_QuestionTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_QuestionTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_QuestionTypes);
            myadapter.Dispose();
            connection.Close();

            return STD_QuestionTypes;
        }
    }
	public DataSet GetSTD_QuestionTypePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_QuestionTypePageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_QuestionType()
    {
        DataSet STD_QuestionTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_QuestionTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_QuestionTypes);
            myadapter.Dispose();
            connection.Close();

            return STD_QuestionTypes;
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
    public List<STD_QuestionType> GetSTD_QuestionTypesFromReader(IDataReader reader)
    {
        List<STD_QuestionType> sTD_QuestionTypes = new List<STD_QuestionType>();

        while (reader.Read())
        {
            sTD_QuestionTypes.Add(GetSTD_QuestionTypeFromReader(reader));
        }
        return sTD_QuestionTypes;
    }

    public STD_QuestionType GetSTD_QuestionTypeFromReader(IDataReader reader)
    {
        try
        {
            STD_QuestionType sTD_QuestionType = new STD_QuestionType
                (

                     DataAccessObject.IsNULL<int>(reader["QuestionTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["QuestionTypeName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_QuestionType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_QuestionType  GetSTD_QuestionTypeByQuestionTypeID(int  questionTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_QuestionTypeByQuestionTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuestionTypeID", SqlDbType.Int).Value = questionTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_QuestionTypeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_QuestionType(STD_QuestionType sTD_QuestionType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_QuestionType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@QuestionTypeName", SqlDbType.NVarChar).Value = sTD_QuestionType.QuestionTypeName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_QuestionType.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_QuestionType.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_QuestionType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_QuestionType.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@QuestionTypeID"].Value;
        }
    }

    public bool UpdateSTD_QuestionType(STD_QuestionType sTD_QuestionType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_QuestionType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionTypeID", SqlDbType.Int).Value = sTD_QuestionType.QuestionTypeID;
            cmd.Parameters.Add("@QuestionTypeName", SqlDbType.NVarChar).Value = sTD_QuestionType.QuestionTypeName;
            //cmd.Parameters.Add("@QuestionTypeName", SqlDbType.NVarChar).Value = sTD_QuestionType.QuestionTypeName;
            //cmd.Parameters.Add("@QuestionTypeName", SqlDbType.NVarChar).Value = sTD_QuestionType.QuestionTypeName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_QuestionType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_QuestionType.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_QuestionType(int questionTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_QuestionType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuestionTypeID", SqlDbType.Int).Value = questionTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

