using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlUSER_MenuProvider:DataAccessObject
{
	public SqlUSER_MenuProvider()
    {
    }


    public DataSet  GetAllUSER_Menus()
    {
        DataSet USER_Menus = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_Menus", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Menus);
            myadapter.Dispose();
            connection.Close();

            return USER_Menus;
        }
    }

	public DataSet GetUSER_MenuPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetUSER_MenuPageWise", connection))
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


    public USER_Menu  GetUSER_MenuByPageID(int  pageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_MenuByPageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PageID", SqlDbType.NVarChar).Value = pageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_MenuFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public List<USER_Menu> GetUSER_Menu_ByModuleID(int moduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("USER_Menu_GetByModuleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ModuleID", SqlDbType.NVarChar).Value = moduleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetUSER_MenusFromReader(reader);
        }
    }

    public USER_Menu  GetUSER_MenuByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_MenuByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_MenuFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllUSER_Menu()
    {
        DataSet USER_Menus = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllUSER_Menu", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Menus);
            myadapter.Dispose();
            connection.Close();

            return USER_Menus;
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
    public List<USER_Menu> GetUSER_MenusFromReader(IDataReader reader)
    {
        List<USER_Menu> uSER_Menus = new List<USER_Menu>();

        while (reader.Read())
        {
            uSER_Menus.Add(GetUSER_MenuFromReader(reader));
        }
        return uSER_Menus;
    }

    public USER_Menu GetUSER_MenuFromReader(IDataReader reader)
    {
        try
        {
            USER_Menu uSER_Menu = new USER_Menu
                (

                     DataAccessObject.IsNULL<int>(reader["MenuID"]),
                     DataAccessObject.IsNULL<int>(reader["ModuleID"]),
                     DataAccessObject.IsNULL<int>(reader["PageID"]),
                     DataAccessObject.IsNULL<string>(reader["MenuTitle"]),
                     DataAccessObject.IsNULL<int>(reader["ParentMenuID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return uSER_Menu;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public USER_Menu  GetUSER_MenuByMenuID(int  menuID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_MenuByMenuID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MenuID", SqlDbType.Int).Value = menuID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_MenuFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertUSER_Menu(USER_Menu uSER_Menu)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertUSER_Menu", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MenuID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = uSER_Menu.ModuleID;
            cmd.Parameters.Add("@PageID", SqlDbType.Int).Value = uSER_Menu.PageID;
            cmd.Parameters.Add("@MenuTitle", SqlDbType.NVarChar).Value = uSER_Menu.MenuTitle;
            cmd.Parameters.Add("@ParentMenuID", SqlDbType.Int).Value = uSER_Menu.ParentMenuID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSER_Menu.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSER_Menu.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Menu.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Menu.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Menu.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MenuID"].Value;
        }
    }

    public bool UpdateUSER_Menu(USER_Menu uSER_Menu)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateUSER_Menu", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = uSER_Menu.MenuID;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = uSER_Menu.ModuleID;
            cmd.Parameters.Add("@PageID", SqlDbType.Int).Value = uSER_Menu.PageID;
            cmd.Parameters.Add("@MenuTitle", SqlDbType.NVarChar).Value = uSER_Menu.MenuTitle;
            cmd.Parameters.Add("@ParentMenuID", SqlDbType.Int).Value = uSER_Menu.ParentMenuID;
            //cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSER_Menu.AddedBy;
            //cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSER_Menu.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Menu.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Menu.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Menu.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteUSER_Menu(int menuID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteUSER_Menu", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = menuID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

public class SqlDisplayMenuProvider : DataAccessObject
{
    public SqlDisplayMenuProvider()
    {
    }

    public List<DisplayMenu> GetDisplayMenuByModuleNRole(int moduleID, string roleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            //SqlCommand command = new SqlCommand("USER_MenuDisplay_GetByModuleNRole", connection);
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT um.MenuID,um.ParentMenuID, um.MenuTitle, up.PageTitle, up.PageURL, um.ModuleID FROM [USER_Menu] AS um"
                + " LEFT OUTER JOIN [USER_Page] AS up ON um.PageID=up.PageID WHERE ( (" + moduleID.ToString() + "=0 OR um.ModuleID = " + moduleID.ToString() + ") AND um.MenuID IN"
                + " (SELECT rwm.MenuID FROM USER_RoleWiseMenu AS rwm WHERE rwm.RoleID=(SELECT r.RoleId FROM aspnet_Roles AS r WHERE r.RoleName='" + roleID + "') AND rwm.RowStatusID=1))"
                +" ORDER BY um.ModuleID, up.PageID;";
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            //command.Parameters.Add("@ModuleID", SqlDbType.NVarChar).Value = moduleID;
            //command.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = roleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetDisplayMenusFromReader(reader);
        }
    }

    public List<DisplayMenu> GetDisplayMenusFromReader(IDataReader reader)
    {
        List<DisplayMenu> displayMenus = new List<DisplayMenu>();

        while (reader.Read())
        {
            displayMenus.Add(GetDisplayMenuFromReader(reader));
        }
        return displayMenus;
    }

    public DisplayMenu GetDisplayMenuFromReader(IDataReader reader)
    {
        try
        {
            DisplayMenu displayMenu = new DisplayMenu
                (
                     DataAccessObject.IsNULL<int>(reader["MenuID"]),
                     DataAccessObject.IsNULL<int>(reader["ParentMenuID"]),
                     DataAccessObject.IsNULL<string>(reader["MenuTitle"]),
                     DataAccessObject.IsNULL<string>(reader["PageTitle"]),
                     DataAccessObject.IsNULL<string>(reader["PageURL"]),
                     DataAccessObject.IsNULL<int>(reader["ModuleID"])
                );
            //if (displayMenu.PageURL == null || displayMenu.PageURL == "")
            //    displayMenu.PageURL = "javascript:void(0);";
            return displayMenu;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    
}

