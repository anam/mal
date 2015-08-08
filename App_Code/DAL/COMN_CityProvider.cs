using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_CityProvider:DataAccessObject
{
	public SqlCOMN_CityProvider()
    {
    }


    public DataSet  GetAllCOMN_Cities()
    {
        DataSet COMN_Cities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_Cities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Cities);
            myadapter.Dispose();
            connection.Close();

            return COMN_Cities;
        }
    }
	public DataSet GetCOMN_CityPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_CityPageWise", connection))
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


    public COMN_City  GetCOMN_CityByCountryID(int  countryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_CityByCountryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CountryID", SqlDbType.NVarChar).Value = countryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_CityFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllCOMN_City()
    {
        DataSet COMN_Cities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_Citys", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Cities);
            myadapter.Dispose();
            connection.Close();

            return COMN_Cities;
        }
    }

    public DataSet   GetAllCOMN_CitiesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_CitiesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<COMN_City> GetCOMN_CitiesFromReader(IDataReader reader)
    {
        List<COMN_City> cOMN_Cities = new List<COMN_City>();

        while (reader.Read())
        {
            cOMN_Cities.Add(GetCOMN_CityFromReader(reader));
        }
        return cOMN_Cities;
    }

    public COMN_City GetCOMN_CityFromReader(IDataReader reader)
    {
        try
        {
            COMN_City cOMN_City = new COMN_City
                (

                     DataAccessObject.IsNULL<int>(reader["CityID"]),
                     DataAccessObject.IsNULL<string>(reader["CityName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<int>(reader["CountryID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return cOMN_City;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_City  GetCOMN_CityByCityID(int  cityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_CityByCityID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CityID", SqlDbType.Int).Value = cityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_CityFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_City(COMN_City cOMN_City)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_City", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = cOMN_City.CityName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = cOMN_City.Description;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = cOMN_City.CountryID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_City.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_City.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_City.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_City.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CityID"].Value;
        }
    }

    public bool UpdateCOMN_City(COMN_City cOMN_City)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_City", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cOMN_City.CityID;
            cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = cOMN_City.CityName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = cOMN_City.Description;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = cOMN_City.CountryID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_City.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_City.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_City(int cityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_City", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cityID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

