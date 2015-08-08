using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlRoleWiseModuleProvider:DataAccessObject
{
	public SqlRoleWiseModuleProvider()
    {
    }


    public bool DeleteRoleWiseModule(int roleWiseModuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("USER_RoleWiseModule_Delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleWiseModuleID", SqlDbType.Int).Value = roleWiseModuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<RoleWiseModule> GetAllRoleWiseModules()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("USER_RoleWiseModule_GetAll", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRoleWiseModulesFromReader(reader);
        }
    }

    public List<RoleWiseModule> GETRoleWiseModulesByRoleID(string roleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("USER_RoleWiseModule_GetByRoleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = roleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetRoleWiseModulesFromReader(reader);
        }
    }

    public List<RoleWiseModule> GetRoleWiseModulesFromReader(IDataReader reader)
    {
        List<RoleWiseModule> roleWiseModules = new List<RoleWiseModule>();

        while (reader.Read())
        {
            roleWiseModules.Add(GetRoleWiseModuleFromReader(reader));
        }
        return roleWiseModules;
    }

    public RoleWiseModule GetRoleWiseModuleFromReader(IDataReader reader)
    {
        try
        {
            RoleWiseModule roleWiseModule = new RoleWiseModule
                (
                    (int)reader["RoleWiseModuleID"],
                    (int)reader["ModuleID"],
                    reader["RoleID"].ToString(),
                    reader["AddedBy"].ToString(),
                    (DateTime)reader["AddedDate"],
                    reader["UpdatedBy"].ToString(),
                    (DateTime)reader["UpdatedDate"],
                    (int)reader["RowStatusID"]
                );
             return roleWiseModule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public RoleWiseModule GetRoleWiseModuleByID(int roleWiseModuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("USER_RoleWiseModule_GetByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoleWiseModuleID", SqlDbType.Int).Value = roleWiseModuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetRoleWiseModuleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertRoleWiseModule(RoleWiseModule roleWiseModule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("USER_RoleWiseModule_Insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleWiseModuleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = roleWiseModule.ModuleID;
            cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = roleWiseModule.RoleID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = roleWiseModule.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = roleWiseModule.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = roleWiseModule.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = roleWiseModule.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = roleWiseModule.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RoleWiseModuleID"].Value;
        }
    }

    public bool UpdateRoleWiseModule(RoleWiseModule roleWiseModule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("USER_RoleWiseModule_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleWiseModuleID", SqlDbType.Int).Value = roleWiseModule.RoleWiseModuleID;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = roleWiseModule.ModuleID;
            cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = roleWiseModule.RoleID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = roleWiseModule.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = roleWiseModule.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = roleWiseModule.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = roleWiseModule.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = roleWiseModule.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
