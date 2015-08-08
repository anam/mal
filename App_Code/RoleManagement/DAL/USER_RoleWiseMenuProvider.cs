using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlUSER_RoleWiseMenuProvider:DataAccessObject
{
	public SqlUSER_RoleWiseMenuProvider()
    {
    }


    public DataSet  GetAllUSER_RoleWiseMenus()
    {
        DataSet USER_RoleWiseMenus = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_RoleWiseMenus", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_RoleWiseMenus);
            myadapter.Dispose();
            connection.Close();

            return USER_RoleWiseMenus;
        }
    }
	public DataSet GetUSER_RoleWiseMenuPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetUSER_RoleWiseMenuPageWise", connection))
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


    public USER_RoleWiseMenu  GetUSER_RoleWiseMenuByMenuID(int  menuID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RoleWiseMenuByMenuID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MenuID", SqlDbType.NVarChar).Value = menuID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_RoleWiseMenuFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public List<USER_RoleWiseMenu> GetUSER_RoleWiseMenuByRoleID(string  roleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RoleWiseMenuByRoleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = roleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            
            return GetUSER_RoleWiseMenusFromReader(reader);
            
        }
    }

    public USER_RoleWiseMenu  GetUSER_RoleWiseMenuByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RoleWiseMenuByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_RoleWiseMenuFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllUSER_RoleWiseMenu()
    {
        DataSet USER_RoleWiseMenus = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllUSER_RoleWiseMenu", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_RoleWiseMenus);
            myadapter.Dispose();
            connection.Close();

            return USER_RoleWiseMenus;
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
    public List<USER_RoleWiseMenu> GetUSER_RoleWiseMenusFromReader(IDataReader reader)
    {
        List<USER_RoleWiseMenu> uSER_RoleWiseMenus = new List<USER_RoleWiseMenu>();

        while (reader.Read())
        {
            uSER_RoleWiseMenus.Add(GetUSER_RoleWiseMenuFromReader(reader));
        }
        return uSER_RoleWiseMenus;
    }

    public USER_RoleWiseMenu GetUSER_RoleWiseMenuFromReader(IDataReader reader)
    {
        try
        {
            USER_RoleWiseMenu uSER_RoleWiseMenu = new USER_RoleWiseMenu
                (

                     DataAccessObject.IsNULL<int>(reader["ID"]),
                     DataAccessObject.IsNULL<int>(reader["MenuID"]),
                     DataAccessObject.IsNULL<string>(reader["RoleID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return uSER_RoleWiseMenu;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public USER_RoleWiseMenu  GetUSER_RoleWiseMenuByID(int  iD)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_RoleWiseMenuByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ID", SqlDbType.Int).Value = iD;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_RoleWiseMenuFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertUSER_RoleWiseMenu(USER_RoleWiseMenu uSER_RoleWiseMenu)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertUSER_RoleWiseMenu", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = uSER_RoleWiseMenu.MenuID;
            cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = uSER_RoleWiseMenu.RoleID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSER_RoleWiseMenu.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSER_RoleWiseMenu.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_RoleWiseMenu.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_RoleWiseMenu.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_RoleWiseMenu.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateUSER_RoleWiseMenu(USER_RoleWiseMenu uSER_RoleWiseMenu)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateUSER_RoleWiseMenu", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = uSER_RoleWiseMenu.ID;
            cmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = uSER_RoleWiseMenu.MenuID;
            cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = uSER_RoleWiseMenu.RoleID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_RoleWiseMenu.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_RoleWiseMenu.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_RoleWiseMenu.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteUSER_RoleWiseMenu(int iD)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteUSER_RoleWiseMenu", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = iD;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

