using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_CampusProvider:DataAccessObject
{
	public SqlCOMN_CampusProvider()
    {
    }


    public DataSet  GetAllCOMN_Campuss()
    {
        DataSet COMN_Campuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_Campuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Campuss);
            myadapter.Dispose();
            connection.Close();

            return COMN_Campuss;
        }
    }
	public DataSet GetCOMN_CampusPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_CampusPageWise", connection))
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


    public COMN_Campus  GetCOMN_CampusByCityID(int  cityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_CampusByCityID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CityID", SqlDbType.NVarChar).Value = cityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_CampusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllCOMN_Campus()
    {
        DataSet COMN_Campuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_Campuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Campuss);
            myadapter.Dispose();
            connection.Close();

            return COMN_Campuss;
        }
    }

    public DataSet   GetAllCOMN_CampussWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_CampussWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<COMN_Campus> GetCOMN_CampussFromReader(IDataReader reader)
    {
        List<COMN_Campus> cOMN_Campuss = new List<COMN_Campus>();

        while (reader.Read())
        {
            cOMN_Campuss.Add(GetCOMN_CampusFromReader(reader));
        }
        return cOMN_Campuss;
    }

    public COMN_Campus GetCOMN_CampusFromReader(IDataReader reader)
    {
        try
        {
            COMN_Campus cOMN_Campus = new COMN_Campus
                (

                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<string>(reader["CampusName"]),
                     DataAccessObject.IsNULL<string>(reader["Address"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<int>(reader["CityID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return cOMN_Campus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_Campus  GetCOMN_CampusByCampusID(int  campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_CampusByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.Int).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_CampusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_Campus(COMN_Campus cOMN_Campus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_Campus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CampusName", SqlDbType.NVarChar).Value = cOMN_Campus.CampusName;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = cOMN_Campus.Address;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = cOMN_Campus.Description;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cOMN_Campus.CityID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_Campus.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_Campus.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_Campus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_Campus.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CampusID"].Value;
        }
    }

    public bool UpdateCOMN_Campus(COMN_Campus cOMN_Campus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_Campus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = cOMN_Campus.CampusID;
            cmd.Parameters.Add("@CampusName", SqlDbType.NVarChar).Value = cOMN_Campus.CampusName;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = cOMN_Campus.Address;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = cOMN_Campus.Description;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cOMN_Campus.CityID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_Campus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_Campus.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_Campus(int campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_Campus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = campusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

