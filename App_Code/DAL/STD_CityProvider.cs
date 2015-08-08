using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_CityProvider:DataAccessObject
{
	public SqlSTD_CityProvider()
    {
    }


    public DataSet  GetAllSTD_Cities()
    {
        DataSet STD_Cities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Cities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Cities);
            myadapter.Dispose();
            connection.Close();

            return STD_Cities;
        }
    }
	public DataSet GetSTD_CityPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_CityPageWise", connection))
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


    public STD_City  GetSTD_CityByCountryID(int  countryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CityByCountryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CountryID", SqlDbType.NVarChar).Value = countryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_CityFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_City()
    {
        DataSet STD_Cities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Cities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Cities);
            myadapter.Dispose();
            connection.Close();

            return STD_Cities;
        }
    }

    public DataSet   GetAllSTD_CitiesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_CitiesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_City> GetSTD_CitiesFromReader(IDataReader reader)
    {
        List<STD_City> sTD_Cities = new List<STD_City>();

        while (reader.Read())
        {
            sTD_Cities.Add(GetSTD_CityFromReader(reader));
        }
        return sTD_Cities;
    }

    public STD_City GetSTD_CityFromReader(IDataReader reader)
    {
        try
        {
            STD_City sTD_City = new STD_City
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
             return sTD_City;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_City  GetSTD_CityByCityID(int  cityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CityByCityID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CityID", SqlDbType.Int).Value = cityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_CityFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_City(STD_City sTD_City)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_City", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = sTD_City.CityName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_City.Description;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = sTD_City.CountryID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_City.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_City.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_City.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_City.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CityID"].Value;
        }
    }

    public bool UpdateSTD_City(STD_City sTD_City)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_City", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = sTD_City.CityID;
            cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = sTD_City.CityName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_City.Description;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = sTD_City.CountryID;
            //cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = sTD_City.CountryID;
            //cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = sTD_City.CountryID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_City.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_City.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_City(int cityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_City", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = cityID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

