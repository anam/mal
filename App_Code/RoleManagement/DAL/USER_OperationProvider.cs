using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlUSER_OperationProvider:DataAccessObject
{
	public SqlUSER_OperationProvider()
    {
    }


    public DataSet  GetAllUSER_Operations()
    {
        DataSet USER_Operations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_Operations", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Operations);
            myadapter.Dispose();
            connection.Close();

            return USER_Operations;
        }
    }
	public DataSet GetUSER_OperationPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetUSER_OperationPageWise", connection))
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


    public USER_Operation  GetUSER_OperationByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_OperationByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_OperationFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllUSER_Operation()
    {
        DataSet USER_Operations = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllUSER_Operation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Operations);
            myadapter.Dispose();
            connection.Close();

            return USER_Operations;
        }
    }

    public DataSet   GetAllUSER_MenusWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_MenusWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<USER_Operation> GetUSER_OperationsFromReader(IDataReader reader)
    {
        List<USER_Operation> uSER_Operations = new List<USER_Operation>();

        while (reader.Read())
        {
            uSER_Operations.Add(GetUSER_OperationFromReader(reader));
        }
        return uSER_Operations;
    }

    public USER_Operation GetUSER_OperationFromReader(IDataReader reader)
    {
        try
        {
            USER_Operation uSER_Operation = new USER_Operation
                (

                     DataAccessObject.IsNULL<int>(reader["OperationID"]),
                     DataAccessObject.IsNULL<string>(reader["OperationName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return uSER_Operation;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public USER_Operation  GetUSER_OperationByOperationID(int  operationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_OperationByOperationID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OperationID", SqlDbType.Int).Value = operationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_OperationFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertUSER_Operation(USER_Operation uSER_Operation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertUSER_Operation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OperationID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OperationName", SqlDbType.NVarChar).Value = uSER_Operation.OperationName;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = uSER_Operation.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSER_Operation.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSER_Operation.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Operation.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Operation.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Operation.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@OperationID"].Value;
        }
    }

    public bool UpdateUSER_Operation(USER_Operation uSER_Operation)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateUSER_Operation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OperationID", SqlDbType.Int).Value = uSER_Operation.OperationID;
            cmd.Parameters.Add("@OperationName", SqlDbType.NVarChar).Value = uSER_Operation.OperationName;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = uSER_Operation.Description;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Operation.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Operation.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Operation.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteUSER_Operation(int operationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteUSER_Operation", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OperationID", SqlDbType.Int).Value = operationID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

