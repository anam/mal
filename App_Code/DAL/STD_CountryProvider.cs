using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_CountryProvider:DataAccessObject
{
	public SqlSTD_CountryProvider()
    {
    }


    public DataSet  GetAllSTD_Countries()
    {
        DataSet STD_Countries = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Countries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Countries);
            myadapter.Dispose();
            connection.Close();

            return STD_Countries;
        }
    }
	public DataSet GetSTD_CountryPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_CountryPageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_Country()
    {
        DataSet STD_Countries = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Countries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Countries);
            myadapter.Dispose();
            connection.Close();

            return STD_Countries;
        }
    }

    public DataSet   GetAllSTD_ContactsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ContactsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Country> GetSTD_CountriesFromReader(IDataReader reader)
    {
        List<STD_Country> sTD_Countries = new List<STD_Country>();

        while (reader.Read())
        {
            sTD_Countries.Add(GetSTD_CountryFromReader(reader));
        }
        return sTD_Countries;
    }

    public STD_Country GetSTD_CountryFromReader(IDataReader reader)
    {
        try
        {
            STD_Country sTD_Country = new STD_Country
                (

                     DataAccessObject.IsNULL<int>(reader["CountryID"]),
                     DataAccessObject.IsNULL<string>(reader["CountryName"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_Country;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Country  GetSTD_CountryByCountryID(int  countryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CountryByCountryID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CountryID", SqlDbType.Int).Value = countryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_CountryFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Country(STD_Country sTD_Country)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Country", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = sTD_Country.CountryName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Country.Description;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Country.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Country.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Country.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Country.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CountryID"].Value;
        }
    }

    public bool UpdateSTD_Country(STD_Country sTD_Country)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Country", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = sTD_Country.CountryID;
            cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = sTD_Country.CountryName;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Country.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Country.Description;
            //cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Country.Description;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Country.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Country.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Country(int countryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Country", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = countryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

