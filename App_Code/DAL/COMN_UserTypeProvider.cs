using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_UserTypeProvider:DataAccessObject
{
	public SqlCOMN_UserTypeProvider()
    {
    }


    public DataSet  GetAllCOMN_UserTypes()
    {
        DataSet COMN_UserTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_UserTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_UserTypes);
            myadapter.Dispose();
            connection.Close();

            return COMN_UserTypes;
        }
    }
	public DataSet GetCOMN_UserTypePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_UserTypePageWise", connection))
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


    public COMN_UserType  GetCOMN_UserTypeByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_UserTypeByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_UserTypeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllCOMN_UserType()
    {
        DataSet COMN_UserTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_UserType", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_UserTypes);
            myadapter.Dispose();
            connection.Close();

            return COMN_UserTypes;
        }
    }
    public List<COMN_UserType> GetCOMN_UserTypesFromReader(IDataReader reader)
    {
        List<COMN_UserType> cOMN_UserTypes = new List<COMN_UserType>();

        while (reader.Read())
        {
            cOMN_UserTypes.Add(GetCOMN_UserTypeFromReader(reader));
        }
        return cOMN_UserTypes;
    }

    public COMN_UserType GetCOMN_UserTypeFromReader(IDataReader reader)
    {
        try
        {
            COMN_UserType cOMN_UserType = new COMN_UserType
                (

                     DataAccessObject.IsNULL<int>(reader["UserTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["UserTypeName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return cOMN_UserType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_UserType  GetCOMN_UserTypeByUserTypeID(int  userTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_UserTypeByUserTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserTypeID", SqlDbType.Int).Value = userTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_UserTypeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_UserType(COMN_UserType cOMN_UserType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_UserType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UserTypeName", SqlDbType.NVarChar).Value = cOMN_UserType.UserTypeName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_UserType.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_UserType.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_UserType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_UserType.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cOMN_UserType.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@UserTypeID"].Value;
        }
    }

    public bool UpdateCOMN_UserType(COMN_UserType cOMN_UserType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_UserType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserTypeID", SqlDbType.Int).Value = cOMN_UserType.UserTypeID;
            cmd.Parameters.Add("@UserTypeName", SqlDbType.NVarChar).Value = cOMN_UserType.UserTypeName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_UserType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_UserType.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cOMN_UserType.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_UserType(int userTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_UserType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserTypeID", SqlDbType.Int).Value = userTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

