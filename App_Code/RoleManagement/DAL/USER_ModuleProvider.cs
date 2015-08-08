using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlUSER_ModuleProvider:DataAccessObject
{
	public SqlUSER_ModuleProvider()
    {
    }


    public DataSet  GetAllUSER_Modules()
    {
        DataSet USER_Modules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_Modules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Modules);
            myadapter.Dispose();
            connection.Close();

            return USER_Modules;
        }
    }
	public DataSet GetUSER_ModulePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetUSER_ModulePageWise", connection))
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


    public USER_Module  GetUSER_ModuleByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_ModuleByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_ModuleFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllUSER_Module()
    {
        DataSet USER_Modules = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllUSER_Module", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Modules);
            myadapter.Dispose();
            connection.Close();

            return USER_Modules;
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
    public List<USER_Module> GetUSER_ModulesFromReader(IDataReader reader)
    {
        List<USER_Module> uSER_Modules = new List<USER_Module>();

        while (reader.Read())
        {
            uSER_Modules.Add(GetUSER_ModuleFromReader(reader));
        }
        return uSER_Modules;
    }

    public USER_Module GetUSER_ModuleFromReader(IDataReader reader)
    {
        try
        {
            USER_Module uSER_Module = new USER_Module
                (

                     DataAccessObject.IsNULL<int>(reader["ModuleID"]),
                     DataAccessObject.IsNULL<string>(reader["ModuleName"]),
                     DataAccessObject.IsNULL<string>(reader["DefaultURL"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return uSER_Module;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public USER_Module  GetUSER_ModuleByModuleID(int  moduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_ModuleByModuleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ModuleID", SqlDbType.Int).Value = moduleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_ModuleFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertUSER_Module(USER_Module uSER_Module)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertUSER_Module", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ModuleName", SqlDbType.NVarChar).Value = uSER_Module.ModuleName;
            cmd.Parameters.Add("@DefaultURL", SqlDbType.NVarChar).Value = uSER_Module.DefaultURL;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSER_Module.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSER_Module.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Module.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Module.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Module.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ModuleID"].Value;
        }
    }

    public bool UpdateUSER_Module(USER_Module uSER_Module)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateUSER_Module", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = uSER_Module.ModuleID;
            cmd.Parameters.Add("@ModuleName", SqlDbType.NVarChar).Value = uSER_Module.ModuleName;
            cmd.Parameters.Add("@DefaultURL", SqlDbType.NVarChar).Value = uSER_Module.DefaultURL;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Module.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Module.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Module.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteUSER_Module(int moduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteUSER_Module", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = moduleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

