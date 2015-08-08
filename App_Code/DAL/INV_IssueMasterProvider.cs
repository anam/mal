using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlINV_IssueMasterProvider:DataAccessObject
{
	public SqlINV_IssueMasterProvider()
    {
    }


    public DataSet  GetAllINV_IssueMasters()
    {
        DataSet INV_IssueMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_IssueMasters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_IssueMasters);
            myadapter.Dispose();
            connection.Close();

            return INV_IssueMasters;
        }
    }

    public DataSet GetINV_IssueMasterPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_IssueMasterPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
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


    public INV_IssueMaster GetINV_IssueMasterByCampusID(int campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IssueMasterByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetINV_IssueMasterFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public INV_IssueMaster GetINV_IssueMasterByStoreID(int storeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IssueMasterByStoreID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StoreID", SqlDbType.NVarChar).Value = storeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetINV_IssueMasterFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet  GetDropDownListAllINV_IssueMaster()
    {
        DataSet INV_IssueMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllINV_IssueMasters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_IssueMasters);
            myadapter.Dispose();
            connection.Close();

            return INV_IssueMasters;
        }
    }

    public DataSet GetAllINV_IssueMastersWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_IssueMastersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public List<INV_IssueMaster> GetINV_IssueMastersFromReader(IDataReader reader)
    {
        List<INV_IssueMaster> iNV_IssueMasters = new List<INV_IssueMaster>();

        while (reader.Read())
        {
            iNV_IssueMasters.Add(GetINV_IssueMasterFromReader(reader));
        }
        return iNV_IssueMasters;
    }

    public INV_IssueMaster GetINV_IssueMasterFromReader(IDataReader reader)
    {
        try
        {
            INV_IssueMaster iNV_IssueMaster = new INV_IssueMaster
                (
                     DataAccessObject.IsNULL<int>(reader["IssueMasterID"]),
                     DataAccessObject.IsNULL<string>(reader["IssueMasterName"]),
                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<int>(reader["StoreID"]),
                     DataAccessObject.IsNULL<string>(reader["ProductionCode"]),
                     DataAccessObject.IsNULL<decimal>(reader["Quantity"]),
                     DataAccessObject.IsNULL<DateTime>(reader["IssueDate"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
            return iNV_IssueMaster;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public INV_IssueMaster GetINV_IssueMasterByIssueMasterID(int issueMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IssueMasterByIssueMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IssueMasterID", SqlDbType.Int).Value = issueMasterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetINV_IssueMasterFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertINV_IssueMaster(INV_IssueMaster iNV_IssueMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertINV_IssueMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IssueMasterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IssueMasterName", SqlDbType.NVarChar).Value = iNV_IssueMaster.IssueMasterName;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_IssueMaster.CampusID;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = iNV_IssueMaster.StoreID;
            cmd.Parameters.Add("@ProductionCode", SqlDbType.NVarChar).Value = iNV_IssueMaster.ProductionCode;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_IssueMaster.Quantity;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = iNV_IssueMaster.IssueDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = iNV_IssueMaster.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = iNV_IssueMaster.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_IssueMaster.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_IssueMaster.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@IssueMasterID"].Value;
        }
    }

    public bool UpdateINV_IssueMaster(INV_IssueMaster iNV_IssueMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateINV_IssueMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IssueMasterID", SqlDbType.Int).Value = iNV_IssueMaster.IssueMasterID;
            cmd.Parameters.Add("@IssueMasterName", SqlDbType.NVarChar).Value = iNV_IssueMaster.IssueMasterName;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_IssueMaster.CampusID;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = iNV_IssueMaster.StoreID;
            cmd.Parameters.Add("@ProductionCode", SqlDbType.NVarChar).Value = iNV_IssueMaster.ProductionCode;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_IssueMaster.Quantity;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = iNV_IssueMaster.IssueDate;
            //cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = iNV_IssueMaster.IssueDate;
            //cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = iNV_IssueMaster.IssueDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_IssueMaster.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_IssueMaster.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteINV_IssueMaster(int issueMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteINV_IssueMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IssueMasterID", SqlDbType.Int).Value = issueMasterID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

