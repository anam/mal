using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlINV_IteamSubCategoryProvider:DataAccessObject
{
	public SqlINV_IteamSubCategoryProvider()
    {
    }


    public DataSet  GetAllINV_IteamSubCategories()
    {
        DataSet INV_IteamSubCategories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_IteamSubCategories", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_IteamSubCategories);
            myadapter.Dispose();
            connection.Close();

            return INV_IteamSubCategories;
        }
    }
	public DataSet GetINV_IteamSubCategoryPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_IteamSubCategoryPageWise", connection))
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


    public INV_IteamSubCategory  GetINV_IteamSubCategoryByIteamCategoryID(int  iteamCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IteamSubCategoryByIteamCategoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IteamCategoryID", SqlDbType.NVarChar).Value = iteamCategoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_IteamSubCategoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetINV_IteamSubCategoryByIteamCategoryID(int iteamCategoryID, bool isDataset)
    {

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_IteamSubCategoryByIteamCategoryID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IteamCategoryID", iteamCategoryID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet  GetDropDownListAllINV_IteamSubCategory()
    {
        DataSet INV_IteamSubCategories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllINV_IteamSubCategorys", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_IteamSubCategories);
            myadapter.Dispose();
            connection.Close();

            return INV_IteamSubCategories;
        }
    }

    public DataSet   GetAllINV_IteamSubCategoriesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_IteamSubCategoriesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<INV_IteamSubCategory> GetINV_IteamSubCategoriesFromReader(IDataReader reader)
    {
        List<INV_IteamSubCategory> iNV_IteamSubCategories = new List<INV_IteamSubCategory>();

        while (reader.Read())
        {
            iNV_IteamSubCategories.Add(GetINV_IteamSubCategoryFromReader(reader));
        }
        return iNV_IteamSubCategories;
    }

    public INV_IteamSubCategory GetINV_IteamSubCategoryFromReader(IDataReader reader)
    {
        try
        {
            INV_IteamSubCategory iNV_IteamSubCategory = new INV_IteamSubCategory
                (

                     DataAccessObject.IsNULL<int>(reader["IteamSubCategoryID"]),
                     DataAccessObject.IsNULL<string>(reader["IteamSubCategoryName"]),
                     DataAccessObject.IsNULL<int>(reader["IteamCategoryID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
             return iNV_IteamSubCategory;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public INV_IteamSubCategory  GetINV_IteamSubCategoryByIteamSubCategoryID(int  iteamSubCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IteamSubCategoryByIteamSubCategoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IteamSubCategoryID", SqlDbType.Int).Value = iteamSubCategoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_IteamSubCategoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertINV_IteamSubCategory(INV_IteamSubCategory iNV_IteamSubCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertINV_IteamSubCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IteamSubCategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IteamSubCategoryName", SqlDbType.NVarChar).Value = iNV_IteamSubCategory.IteamSubCategoryName;
            cmd.Parameters.Add("@IteamCategoryID", SqlDbType.Int).Value = iNV_IteamSubCategory.IteamCategoryID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = iNV_IteamSubCategory.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = iNV_IteamSubCategory.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_IteamSubCategory.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_IteamSubCategory.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@IteamSubCategoryID"].Value;
        }
    }

    public bool UpdateINV_IteamSubCategory(INV_IteamSubCategory iNV_IteamSubCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateINV_IteamSubCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IteamSubCategoryID", SqlDbType.Int).Value = iNV_IteamSubCategory.IteamSubCategoryID;
            cmd.Parameters.Add("@IteamSubCategoryName", SqlDbType.NVarChar).Value = iNV_IteamSubCategory.IteamSubCategoryName;
            cmd.Parameters.Add("@IteamCategoryID", SqlDbType.Int).Value = iNV_IteamSubCategory.IteamCategoryID;
            //cmd.Parameters.Add("@IteamCategoryID", SqlDbType.Int).Value = iNV_IteamSubCategory.IteamCategoryID;
            //cmd.Parameters.Add("@IteamCategoryID", SqlDbType.Int).Value = iNV_IteamSubCategory.IteamCategoryID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_IteamSubCategory.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_IteamSubCategory.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteINV_IteamSubCategory(int iteamSubCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteINV_IteamSubCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IteamSubCategoryID", SqlDbType.Int).Value = iteamSubCategoryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

