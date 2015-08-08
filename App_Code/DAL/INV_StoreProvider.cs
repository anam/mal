using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlINV_StoreProvider:DataAccessObject
{
	public SqlINV_StoreProvider()
    {
    }


    public DataSet  GetAllINV_Stores()
    {
        DataSet INV_Stores = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_Stores", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Stores);
            myadapter.Dispose();
            connection.Close();

            return INV_Stores;
        }
    }
	public DataSet GetINV_StorePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_StorePageWise", connection))
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


    public INV_Store  GetINV_StoreByCampusID(int  campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_StoreByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_StoreFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllINV_Store()
    {
        DataSet INV_Stores = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllINV_Stores", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Stores);
            myadapter.Dispose();
            connection.Close();

            return INV_Stores;
        }
    }

    public DataSet   GetAllINV_StoresWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_StoresWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<INV_Store> GetINV_StoresFromReader(IDataReader reader)
    {
        List<INV_Store> iNV_Stores = new List<INV_Store>();

        while (reader.Read())
        {
            iNV_Stores.Add(GetINV_StoreFromReader(reader));
        }
        return iNV_Stores;
    }

    public INV_Store GetINV_StoreFromReader(IDataReader reader)
    {
        try
        {
            INV_Store iNV_Store = new INV_Store
                (

                     DataAccessObject.IsNULL<int>(reader["StoreID"]),
                     DataAccessObject.IsNULL<string>(reader["StoreName"]),
                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
             return iNV_Store;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public INV_Store  GetINV_StoreByStoreID(int  storeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_StoreByStoreID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StoreID", SqlDbType.Int).Value = storeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_StoreFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertINV_Store(INV_Store iNV_Store)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertINV_Store", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = iNV_Store.StoreName;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_Store.CampusID;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = iNV_Store.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = iNV_Store.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = iNV_Store.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_Store.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_Store.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@StoreID"].Value;
        }
    }

    public bool UpdateINV_Store(INV_Store iNV_Store)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateINV_Store", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = iNV_Store.StoreID;
            cmd.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = iNV_Store.StoreName;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_Store.CampusID;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = iNV_Store.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = iNV_Store.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = iNV_Store.Description;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_Store.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_Store.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteINV_Store(int storeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteINV_Store", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = storeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

