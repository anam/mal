using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlINV_IteamProvider:DataAccessObject
{
	public SqlINV_IteamProvider()
    {
    }


    public DataSet  GetAllINV_Iteams()
    {
        DataSet INV_Iteams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_Iteams", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Iteams);
            myadapter.Dispose();
            connection.Close();

            return INV_Iteams;
        }
    }
	public DataSet GetINV_IteamPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_IteamPageWise", connection))
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

    public DataSet GetINV_IteamBySearchSQLString(string searchSQLString)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_IteamSearchPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SearchString", SqlDbType.NVarChar).Value = searchSQLString;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetINV_IteamStockPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_IteamStockPageWise", connection))
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
    public INV_Iteam  GetINV_IteamByCampusID(int  campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IteamByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_IteamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllINV_Iteam()
    {
        DataSet INV_Iteams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllINV_Iteams", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Iteams);
            myadapter.Dispose();
            connection.Close();

            return INV_Iteams;
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
    public List<INV_Iteam> GetINV_IteamsFromReader(IDataReader reader)
    {
        List<INV_Iteam> iNV_Iteams = new List<INV_Iteam>();

        while (reader.Read())
        {
            iNV_Iteams.Add(GetINV_IteamFromReader(reader));
        }
        return iNV_Iteams;
    }

    public INV_Iteam GetINV_IteamFromReader(IDataReader reader)
    {
        try
        {
            INV_Iteam iNV_Iteam = new INV_Iteam
                (

                     DataAccessObject.IsNULL<int>(reader["IteamID"]),
                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<string>(reader["IteamCode"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<int>(reader["IteamSubCategoryID"]),
                     DataAccessObject.IsNULL<decimal>(reader["Price"]),
                     DataAccessObject.IsNULL<decimal>(reader["Quantity"]),
                     DataAccessObject.IsNULL<string>(reader["Unit"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
            iNV_Iteam.IteamCategoryID = DataAccessObject.IsNULL<int>(reader["IteamCategoryID"]);
             return iNV_Iteam;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public INV_Iteam  GetINV_IteamByIteamID(int  iteamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IteamByIteamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IteamID", SqlDbType.Int).Value = iteamID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_IteamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertINV_Iteam(INV_Iteam iNV_Iteam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertINV_Iteam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IteamID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_Iteam.CampusID;
            cmd.Parameters.Add("@IteamCode", SqlDbType.NVarChar).Value = iNV_Iteam.IteamCode;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = iNV_Iteam.Description;
            cmd.Parameters.Add("@IteamSubCategoryID", SqlDbType.Int).Value = iNV_Iteam.IteamSubCategoryID;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = iNV_Iteam.Price;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_Iteam.Quantity;
            cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = iNV_Iteam.Unit;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = iNV_Iteam.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = iNV_Iteam.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_Iteam.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_Iteam.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@IteamID"].Value;
        }
    }

    public bool UpdateINV_Iteam(INV_Iteam iNV_Iteam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateINV_Iteam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IteamID", SqlDbType.Int).Value = iNV_Iteam.IteamID;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_Iteam.CampusID;
            cmd.Parameters.Add("@IteamCode", SqlDbType.NVarChar).Value = iNV_Iteam.IteamCode;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = iNV_Iteam.Description;
            cmd.Parameters.Add("@IteamSubCategoryID", SqlDbType.Int).Value = iNV_Iteam.IteamSubCategoryID;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = iNV_Iteam.Price;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_Iteam.Quantity;
            cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = iNV_Iteam.Unit;
            //cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = iNV_Iteam.Unit;
            //cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = iNV_Iteam.Unit;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_Iteam.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_Iteam.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteINV_Iteam(int iteamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteINV_Iteam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IteamID", SqlDbType.Int).Value = iteamID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

