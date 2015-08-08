using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLIB_SubCategoryProvider:DataAccessObject
{
	public SqlLIB_SubCategoryProvider()
    {
    }


    public DataSet  GetAllLIB_SubCategories()
    {
        DataSet LIB_SubCategories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_SubCategories", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_SubCategories);
            myadapter.Dispose();
            connection.Close();

            return LIB_SubCategories;
        }
    }
	public DataSet GetLIB_SubCategoryPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetLIB_SubCategoryPageWise", connection))
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


    public LIB_SubCategory  GetLIB_SubCategoryByCategoryID(int  categoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_SubCategoryByCategoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CategoryID", SqlDbType.NVarChar).Value = categoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetLIB_SubCategoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetDropDownLisAllLIB_SubCategory()//CategoryID
    {
        DataSet LIB_SubCategories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllLIB_SubCategory", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_SubCategories);
            myadapter.Dispose();
            connection.Close();

            return LIB_SubCategories;
        }
    }
    public DataSet GetDropDownLisAllLIB_SubCategory(int CategoryID)//CategoryID
    {
        DataSet LIB_SubCategories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_SubCategoryByCategoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CategoryID", SqlDbType.NVarChar).Value = CategoryID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_SubCategories);
            myadapter.Dispose();
            connection.Close();

            return LIB_SubCategories;
        }
    }

    public DataSet   GetAllLIB_SubCategoriesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_SubCategoriesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<LIB_SubCategory> GetLIB_SubCategoriesFromReader(IDataReader reader)
    {
        List<LIB_SubCategory> lIB_SubCategories = new List<LIB_SubCategory>();

        while (reader.Read())
        {
            lIB_SubCategories.Add(GetLIB_SubCategoryFromReader(reader));
        }
        return lIB_SubCategories;
    }

    public LIB_SubCategory GetLIB_SubCategoryFromReader(IDataReader reader)
    {
        try
        {
            LIB_SubCategory lIB_SubCategory = new LIB_SubCategory
                (

                     DataAccessObject.IsNULL<int>(reader["SubCategoryID"]),
                     DataAccessObject.IsNULL<string>(reader["SubCategoryName"]),
                     DataAccessObject.IsNULL<int>(reader["CategoryID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return lIB_SubCategory;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public LIB_SubCategory  GetLIB_SubCategoryBySubCategoryID(int  subCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_SubCategoryBySubCategoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubCategoryID", SqlDbType.Int).Value = subCategoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetLIB_SubCategoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertLIB_SubCategory(LIB_SubCategory lIB_SubCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLIB_SubCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubCategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SubCategoryName", SqlDbType.NVarChar).Value = lIB_SubCategory.SubCategoryName;
            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = lIB_SubCategory.CategoryID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = lIB_SubCategory.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = lIB_SubCategory.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_SubCategory.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_SubCategory.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SubCategoryID"].Value;
        }
    }

    public bool UpdateLIB_SubCategory(LIB_SubCategory lIB_SubCategory)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLIB_SubCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubCategoryID", SqlDbType.Int).Value = lIB_SubCategory.SubCategoryID;
            cmd.Parameters.Add("@SubCategoryName", SqlDbType.NVarChar).Value = lIB_SubCategory.SubCategoryName;
            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = lIB_SubCategory.CategoryID;
            //cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = lIB_SubCategory.CategoryID;
            //cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = lIB_SubCategory.CategoryID;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_SubCategory.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_SubCategory.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteLIB_SubCategory(int subCategoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLIB_SubCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SubCategoryID", SqlDbType.Int).Value = subCategoryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

