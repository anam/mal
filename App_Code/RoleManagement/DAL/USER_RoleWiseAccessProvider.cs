using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlUSER_RoleWiseAccessProvider:DataAccessObject
{
	public SqlUSER_RoleWiseAccessProvider()
    {
    }


    public DataSet  GetAllUSER_RoleWiseAccesss()
    {
        DataSet USER_RoleWiseAccesss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_RoleWiseAccesss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_RoleWiseAccesss);
            myadapter.Dispose();
            connection.Close();

            return USER_RoleWiseAccesss;
        }
    }
	public DataSet GetUSER_RoleWiseAccessPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetUSER_RoleWiseAccessPageWise", connection))
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


    public USER_RoleWiseAccess  GetUSER_RoleWiseAccessByPageID(int  pageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RoleWiseAccessByPageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PageID", SqlDbType.NVarChar).Value = pageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_RoleWiseAccessFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public List<USER_RoleWiseAccess>  GetUSER_RoleWiseAccessesByRoleID(string  roleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RoleWiseAccessByRoleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = roleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetUSER_RoleWiseAccesssFromReader(reader);
        }
    }
    
    public USER_RoleWiseAccess  GetUSER_RoleWiseAccessByOperationID(int  operationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RoleWiseAccessByOperationID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OperationID", SqlDbType.NVarChar).Value = operationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_RoleWiseAccessFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public USER_RoleWiseAccess  GetUSER_RoleWiseAccessByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RoleWiseAccessByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_RoleWiseAccessFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllUSER_RoleWiseAccess()
    {
        DataSet USER_RoleWiseAccesss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllUSER_RoleWiseAccess", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_RoleWiseAccesss);
            myadapter.Dispose();
            connection.Close();

            return USER_RoleWiseAccesss;
        }
    }

    public DataSet   GetAllUSER_PagesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_PagesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<USER_RoleWiseAccess> GetUSER_RoleWiseAccesssFromReader(IDataReader reader)
    {
        List<USER_RoleWiseAccess> uSER_RoleWiseAccesss = new List<USER_RoleWiseAccess>();

        while (reader.Read())
        {
            uSER_RoleWiseAccesss.Add(GetUSER_RoleWiseAccessFromReader(reader));
        }
        return uSER_RoleWiseAccesss;
    }

    public USER_RoleWiseAccess GetUSER_RoleWiseAccessFromReader(IDataReader reader)
    {
        try
        {
            USER_RoleWiseAccess uSER_RoleWiseAccess = new USER_RoleWiseAccess
                (

                     DataAccessObject.IsNULL<int>(reader["ID"]),
                     DataAccessObject.IsNULL<int>(reader["PageID"]),
                     DataAccessObject.IsNULL<string>(reader["RoleID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["OperationID"]),
                     DataAccessObject.IsNULL<bool>(reader["Access"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return uSER_RoleWiseAccess;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public USER_RoleWiseAccess  GetUSER_RoleWiseAccessByID(int  iD)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RoleWiseAccessByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.Int).Value = iD;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_RoleWiseAccessFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertUSER_RoleWiseAccess(USER_RoleWiseAccess uSER_RoleWiseAccess)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertUSER_RoleWiseAccess", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PageID", SqlDbType.Int).Value = uSER_RoleWiseAccess.PageID;
            cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = uSER_RoleWiseAccess.RoleID;
            cmd.Parameters.Add("@OperationID", SqlDbType.Int).Value = uSER_RoleWiseAccess.OperationID;
            cmd.Parameters.Add("@Access", SqlDbType.Bit).Value = uSER_RoleWiseAccess.Access;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSER_RoleWiseAccess.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSER_RoleWiseAccess.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_RoleWiseAccess.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_RoleWiseAccess.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_RoleWiseAccess.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateUSER_RoleWiseAccess(USER_RoleWiseAccess uSER_RoleWiseAccess)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateUSER_RoleWiseAccess", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = uSER_RoleWiseAccess.ID;
            cmd.Parameters.Add("@PageID", SqlDbType.Int).Value = uSER_RoleWiseAccess.PageID;
            cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = uSER_RoleWiseAccess.RoleID;
            cmd.Parameters.Add("@OperationID", SqlDbType.Int).Value = uSER_RoleWiseAccess.OperationID;
            cmd.Parameters.Add("@Access", SqlDbType.Bit).Value = uSER_RoleWiseAccess.Access;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_RoleWiseAccess.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_RoleWiseAccess.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_RoleWiseAccess.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteUSER_RoleWiseAccess(int iD)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteUSER_RoleWiseAccess", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = iD;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

