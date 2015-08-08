using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlINV_IteamCategoryProvider:DataAccessObject
{
	public SqlINV_IteamCategoryProvider()
    {
    }


    public DataSet  GetAllINV_IteamCategories()
    {
        DataSet INV_IteamCategories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_IteamCategories", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_IteamCategories);
            myadapter.Dispose();
            connection.Close();

            return INV_IteamCategories;
        }
    }
	public DataSet GetINV_IteamCategoryPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_IteamCategoryPageWise", connection))
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


    public DataSet  GetDropDownListAllINV_IteamCategory()
    {
        DataSet INV_IteamCategories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllINV_IteamCategorys", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_IteamCategories);
            myadapter.Dispose();
            connection.Close();

            return INV_IteamCategories;
        }
    }

    public DataSet   GetAllINV_IteamsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_IteamsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<INV_IteamCategory> GetINV_IteamCategoriesFromReader(IDataReader reader)
    {
        List<INV_IteamCategory> iNV_IteamCategories = new List<INV_IteamCategory>();

        while (reader.Read())
        {
            iNV_IteamCategories.Add(GetINV_IteamCategoryFromReader(reader));
        }
        return iNV_IteamCategories;
    }

    public INV_IteamCategory GetINV_IteamCategoryFromReader(IDataReader reader)
    {
        try
        {
            INV_IteamCategory iNV_IteamCategory = new INV_IteamCategory
                (

                     DataAccessObject.IsNULL<int>(reader["IteamCategoryID"]),
                     DataAccessObject.IsNULL<string>(reader["IteamCategoryName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
             return iNV_IteamCategory;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public INV_IteamCategory  GetINV_IteamCategoryByIteamCategoryID(int  iteamCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IteamCategoryByIteamCategoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IteamCategoryID", SqlDbType.Int).Value = iteamCategoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_IteamCategoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertINV_IteamCategory(INV_IteamCategory iNV_IteamCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertINV_IteamCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IteamCategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IteamCategoryName", SqlDbType.NVarChar).Value = iNV_IteamCategory.IteamCategoryName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = iNV_IteamCategory.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = iNV_IteamCategory.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_IteamCategory.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_IteamCategory.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@IteamCategoryID"].Value;
        }
    }

    public bool UpdateINV_IteamCategory(INV_IteamCategory iNV_IteamCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateINV_IteamCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IteamCategoryID", SqlDbType.Int).Value = iNV_IteamCategory.IteamCategoryID;
            cmd.Parameters.Add("@IteamCategoryName", SqlDbType.NVarChar).Value = iNV_IteamCategory.IteamCategoryName;
            //cmd.Parameters.Add("@IteamCategoryName", SqlDbType.NVarChar).Value = iNV_IteamCategory.IteamCategoryName;
            //cmd.Parameters.Add("@IteamCategoryName", SqlDbType.NVarChar).Value = iNV_IteamCategory.IteamCategoryName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_IteamCategory.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_IteamCategory.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteINV_IteamCategory(int iteamCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteINV_IteamCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IteamCategoryID", SqlDbType.Int).Value = iteamCategoryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

