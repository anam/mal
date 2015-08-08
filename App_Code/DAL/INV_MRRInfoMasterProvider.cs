using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlINV_MRRInfoMasterProvider:DataAccessObject
{
	public SqlINV_MRRInfoMasterProvider()
    {
    }


    public DataSet  GetAllINV_MRRInfoMasters()
    {
        DataSet INV_MRRInfoMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_MRRInfoMasters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_MRRInfoMasters);
            myadapter.Dispose();
            connection.Close();

            return INV_MRRInfoMasters;
        }
    }
	public DataSet GetINV_MRRInfoMasterPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_MRRInfoMasterPageWise", connection))
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


    public INV_MRRInfoMaster  GetINV_MRRInfoMasterByCampusID(int  campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_MRRInfoMasterByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_MRRInfoMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public INV_MRRInfoMaster  GetINV_MRRInfoMasterByStoreID(int  storeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_MRRInfoMasterByStoreID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StoreID", SqlDbType.NVarChar).Value = storeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_MRRInfoMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllINV_MRRInfoMaster()
    {
        DataSet INV_MRRInfoMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllINV_MRRInfoMasters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_MRRInfoMasters);
            myadapter.Dispose();
            connection.Close();

            return INV_MRRInfoMasters;
        }
    }

    public DataSet   GetAllINV_MRRInfoMastersWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_MRRInfoMastersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<INV_MRRInfoMaster> GetINV_MRRInfoMastersFromReader(IDataReader reader)
    {
        List<INV_MRRInfoMaster> iNV_MRRInfoMasters = new List<INV_MRRInfoMaster>();

        while (reader.Read())
        {
            iNV_MRRInfoMasters.Add(GetINV_MRRInfoMasterFromReader(reader));
        }
        return iNV_MRRInfoMasters;
    }

    public INV_MRRInfoMaster GetINV_MRRInfoMasterFromReader(IDataReader reader)
    {
        try
        {
            INV_MRRInfoMaster iNV_MRRInfoMaster = new INV_MRRInfoMaster
                (

                     DataAccessObject.IsNULL<int>(reader["MRRInfoMasterID"]),
                     DataAccessObject.IsNULL<string>(reader["MRRInfoMasterName"]),
                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<string>(reader["MRRCode"]),
                     DataAccessObject.IsNULL<DateTime>(reader["MRRDate"]),
                     DataAccessObject.IsNULL<int>(reader["StoreID"])
                );
             return iNV_MRRInfoMaster;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public INV_MRRInfoMaster  GetINV_MRRInfoMasterByMRRInfoMasterID(int  mRRInfoMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_MRRInfoMasterByMRRInfoMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MRRInfoMasterID", SqlDbType.Int).Value = mRRInfoMasterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_MRRInfoMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertINV_MRRInfoMaster(INV_MRRInfoMaster iNV_MRRInfoMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertINV_MRRInfoMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRRInfoMasterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MRRInfoMasterName", SqlDbType.NVarChar).Value = iNV_MRRInfoMaster.MRRInfoMasterName;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_MRRInfoMaster.CampusID;
            cmd.Parameters.Add("@MRRCode", SqlDbType.NVarChar).Value = iNV_MRRInfoMaster.MRRCode;
            cmd.Parameters.Add("@MRRDate", SqlDbType.DateTime).Value = iNV_MRRInfoMaster.MRRDate;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = iNV_MRRInfoMaster.StoreID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MRRInfoMasterID"].Value;
        }
    }

    public bool UpdateINV_MRRInfoMaster(INV_MRRInfoMaster iNV_MRRInfoMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateINV_MRRInfoMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRRInfoMasterID", SqlDbType.Int).Value = iNV_MRRInfoMaster.MRRInfoMasterID;
            cmd.Parameters.Add("@MRRInfoMasterName", SqlDbType.NVarChar).Value = iNV_MRRInfoMaster.MRRInfoMasterName;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_MRRInfoMaster.CampusID;
            cmd.Parameters.Add("@MRRCode", SqlDbType.NVarChar).Value = iNV_MRRInfoMaster.MRRCode;
            cmd.Parameters.Add("@MRRDate", SqlDbType.DateTime).Value = iNV_MRRInfoMaster.MRRDate;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = iNV_MRRInfoMaster.StoreID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteINV_MRRInfoMaster(int mRRInfoMasterID)
    {

        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteINV_MRRInfoMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRRInfoMasterID", SqlDbType.Int).Value = mRRInfoMasterID;
            connection.Open();
            int result = 0;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return (result == 1);

        }
       
    }
}

