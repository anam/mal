using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlLIB_CategoryProvider:DataAccessObject
{
	public SqlLIB_CategoryProvider()
    {
    }


    public DataSet  GetAllLIB_Categories()
    {
        DataSet LIB_Categories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_Categories", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Categories);
            myadapter.Dispose();
            connection.Close();

            return LIB_Categories;
        }
    }
	public DataSet GetLIB_CategoryPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetLIB_CategoryPageWise", connection))
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


    public DataSet  GetDropDownLisAllLIB_Category()
    {
        DataSet LIB_Categories = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllLIB_Category", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(LIB_Categories);
            myadapter.Dispose();
            connection.Close();

            return LIB_Categories;
        }
    }

    public DataSet   GetAllLIB_BooksWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_BooksWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<LIB_Category> GetLIB_CategoriesFromReader(IDataReader reader)
    {
        List<LIB_Category> lIB_Categories = new List<LIB_Category>();

        while (reader.Read())
        {
            lIB_Categories.Add(GetLIB_CategoryFromReader(reader));
        }
        return lIB_Categories;
    }

    public LIB_Category GetLIB_CategoryFromReader(IDataReader reader)
    {
        try
        {
            LIB_Category lIB_Category = new LIB_Category
                (

                     DataAccessObject.IsNULL<int>(reader["CategoryID"]),
                     DataAccessObject.IsNULL<string>(reader["CategoryName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return lIB_Category;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public LIB_Category  GetLIB_CategoryByCategoryID(int  categoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLIB_CategoryByCategoryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetLIB_CategoryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertLIB_Category(LIB_Category lIB_Category)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLIB_Category", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = lIB_Category.CategoryName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = lIB_Category.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = lIB_Category.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_Category.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_Category.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CategoryID"].Value;
        }
    }

    public bool UpdateLIB_Category(LIB_Category lIB_Category)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLIB_Category", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = lIB_Category.CategoryID;
            cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = lIB_Category.CategoryName;
            //cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = lIB_Category.CategoryName;
            //cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = lIB_Category.CategoryName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = lIB_Category.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = lIB_Category.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteLIB_Category(int categoryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLIB_Category", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

