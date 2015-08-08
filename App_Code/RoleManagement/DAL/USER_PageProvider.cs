using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlUSER_PageProvider:DataAccessObject
{
	public SqlUSER_PageProvider()
    {
    }


    public DataSet  GetAllUSER_Pages()
    {
        DataSet USER_Pages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllUSER_Pages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Pages);
            myadapter.Dispose();
            connection.Close();

            return USER_Pages;
        }
    }

	public DataSet GetUSER_PagePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetUSER_PagePageWise", connection))
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

    public List<USER_Page>  GetUSER_PagesByModuleID(int  moduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_PageByModuleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ModuleID", SqlDbType.NVarChar).Value = moduleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            
            return GetUSER_PagesFromReader(reader);
        }
    }

    public USER_Page  GetUSER_PageByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_PageByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_PageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllUSER_Page()
    {
        DataSet USER_Pages = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllUSER_Page", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(USER_Pages);
            myadapter.Dispose();
            connection.Close();

            return USER_Pages;
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

    public List<USER_Page> GetUSER_PagesFromReader(IDataReader reader)
    {
        List<USER_Page> uSER_Pages = new List<USER_Page>();

        while (reader.Read())
        {
            uSER_Pages.Add(GetUSER_PageFromReader(reader));
        }
        return uSER_Pages;
    }

    public USER_Page GetUSER_PageFromReader(IDataReader reader)
    {
        try
        {
            USER_Page uSER_Page = new USER_Page
                (

                     DataAccessObject.IsNULL<int>(reader["PageID"]),
                     DataAccessObject.IsNULL<string>(reader["PageTitle"]),
                     DataAccessObject.IsNULL<string>(reader["PageURL"]),
                     DataAccessObject.IsNULL<int>(reader["ModuleID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"]),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return uSER_Page;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public USER_Page  GetUSER_PageByPageID(int  pageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_PageByPageID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PageID", SqlDbType.Int).Value = pageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetUSER_PageFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public USER_Page GetUSER_PageByPageTitle(string pageTitle)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetUSER_PageByPageTitle", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PageTitle", SqlDbType.NVarChar).Value = pageTitle;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetUSER_PageFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertUSER_Page(USER_Page uSER_Page)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertUSER_Page", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar).Value = uSER_Page.PageTitle;
            cmd.Parameters.Add("@PageURL", SqlDbType.NVarChar).Value = uSER_Page.PageURL;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = uSER_Page.ModuleID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = uSER_Page.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = uSER_Page.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Page.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Page.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Page.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PageID"].Value;
        }
    }

    public bool UpdateUSER_Page(USER_Page uSER_Page)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateUSER_Page", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageID", SqlDbType.Int).Value = uSER_Page.PageID;
            cmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar).Value = uSER_Page.PageTitle;
            cmd.Parameters.Add("@PageURL", SqlDbType.NVarChar).Value = uSER_Page.PageURL;
            cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = uSER_Page.ModuleID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = uSER_Page.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = uSER_Page.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = uSER_Page.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteUSER_Page(int pageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteUSER_Page", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageID", SqlDbType.Int).Value = pageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

