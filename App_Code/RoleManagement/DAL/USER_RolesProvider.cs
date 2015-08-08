using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlUSER_RolesProvider:DataAccessObject
{
	public SqlUSER_RolesProvider()
    {
    }


    public DataSet  GetAllUSER_Roless()
    {
        DataSet USER_Roless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_Roless", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Roless);
            myadapter.Dispose();
            connection.Close();

            return USER_Roless;
        }
    }
	public DataSet GetUSER_RolesPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetUSER_RolesPageWise", connection))
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


    public USER_Roles  GetUSER_RolesByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RolesByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_RolesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllUSER_Roles()
    {
        DataSet USER_Roless = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllUSER_Roles", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Roless);
            myadapter.Dispose();
            connection.Close();

            return USER_Roless;
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
    public List<USER_Roles> GetUSER_RolessFromReader(IDataReader reader)
    {
        List<USER_Roles> uSER_Roless = new List<USER_Roles>();

        while (reader.Read())
        {
            uSER_Roless.Add(GetUSER_RolesFromReader(reader));
        }
        return uSER_Roless;
    }

    public USER_Roles GetUSER_RolesFromReader(IDataReader reader)
    {
        try
        {
            USER_Roles uSER_Roles = new USER_Roles
                (

                     DataAccessObject.IsNULL<int>(reader["RoleID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return uSER_Roles;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public USER_Roles  GetUSER_RolesByRoleID(int  roleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RolesByRoleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_RolesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertUSER_Roles(USER_Roles uSER_Roles)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertUSER_Roles", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSER_Roles.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSER_Roles.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Roles.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Roles.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Roles.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RoleID"].Value;
        }
    }

    public bool UpdateUSER_Roles(USER_Roles uSER_Roles)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateUSER_Roles", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = uSER_Roles.RoleID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Roles.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Roles.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Roles.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteUSER_Roles(int roleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteUSER_Roles", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = roleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

