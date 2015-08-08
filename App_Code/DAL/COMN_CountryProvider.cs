using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_CountryProvider:DataAccessObject
{
	public SqlCOMN_CountryProvider()
    {
    }


    public DataSet  GetAllCOMN_Countries()
    {
        DataSet COMN_Countries = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_Countries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Countries);
            myadapter.Dispose();
            connection.Close();

            return COMN_Countries;
        }
    }
	public DataSet GetCOMN_CountryPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_CountryPageWise", connection))
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


    public DataSet  GetDropDownListAllCOMN_Country()
    {
        DataSet COMN_Countries = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_Countrys", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Countries);
            myadapter.Dispose();
            connection.Close();

            return COMN_Countries;
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
    public List<COMN_Country> GetCOMN_CountriesFromReader(IDataReader reader)
    {
        List<COMN_Country> cOMN_Countries = new List<COMN_Country>();

        while (reader.Read())
        {
            cOMN_Countries.Add(GetCOMN_CountryFromReader(reader));
        }
        return cOMN_Countries;
    }

    public COMN_Country GetCOMN_CountryFromReader(IDataReader reader)
    {
        try
        {
            COMN_Country cOMN_Country = new COMN_Country
                (

                     DataAccessObject.IsNULL<int>(reader["CountryID"]),
                     DataAccessObject.IsNULL<string>(reader["CountryName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return cOMN_Country;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_Country  GetCOMN_CountryByCountryID(int  countryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_CountryByCountryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CountryID", SqlDbType.Int).Value = countryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_CountryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_Country(COMN_Country cOMN_Country)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_Country", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = cOMN_Country.CountryName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = cOMN_Country.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_Country.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_Country.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_Country.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_Country.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CountryID"].Value;
        }
    }

    public bool UpdateCOMN_Country(COMN_Country cOMN_Country)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_Country", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = cOMN_Country.CountryID;
            cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = cOMN_Country.CountryName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = cOMN_Country.Description;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_Country.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = cOMN_Country.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_Country(int countryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_Country", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = countryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

