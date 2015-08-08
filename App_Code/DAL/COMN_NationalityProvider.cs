using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_NationalityProvider:DataAccessObject
{
	public SqlCOMN_NationalityProvider()
    {
    }


    public DataSet  GetAllCOMN_Nationalities()
    {
        DataSet COMN_Nationalities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_Nationalities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Nationalities);
            myadapter.Dispose();
            connection.Close();

            return COMN_Nationalities;
        }
    }
	public DataSet GetCOMN_NationalityPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_NationalityPageWise", connection))
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


    public DataSet  GetDropDownListAllCOMN_Nationality()
    {
        DataSet COMN_Nationalities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_Nationalities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Nationalities);
            myadapter.Dispose();
            connection.Close();

            return COMN_Nationalities;
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
    public List<COMN_Nationality> GetCOMN_NationalitiesFromReader(IDataReader reader)
    {
        List<COMN_Nationality> cOMN_Nationalities = new List<COMN_Nationality>();

        while (reader.Read())
        {
            cOMN_Nationalities.Add(GetCOMN_NationalityFromReader(reader));
        }
        return cOMN_Nationalities;
    }

    public COMN_Nationality GetCOMN_NationalityFromReader(IDataReader reader)
    {
        try
        {
            COMN_Nationality cOMN_Nationality = new COMN_Nationality
                (

                     DataAccessObject.IsNULL<int>(reader["NationalityID"]),
                     DataAccessObject.IsNULL<string>(reader["NationalityName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return cOMN_Nationality;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_Nationality  GetCOMN_NationalityByNationalityID(int  nationalityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_NationalityByNationalityID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@NationalityID", SqlDbType.Int).Value = nationalityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_NationalityFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_Nationality(COMN_Nationality cOMN_Nationality)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_Nationality", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NationalityID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@NationalityName", SqlDbType.NVarChar).Value = cOMN_Nationality.NationalityName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_Nationality.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_Nationality.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_Nationality.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_Nationality.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@NationalityID"].Value;
        }
    }

    public bool UpdateCOMN_Nationality(COMN_Nationality cOMN_Nationality)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_Nationality", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NationalityID", SqlDbType.Int).Value = cOMN_Nationality.NationalityID;
            cmd.Parameters.Add("@NationalityName", SqlDbType.NVarChar).Value = cOMN_Nationality.NationalityName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_Nationality.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_Nationality.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_Nationality(int nationalityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_Nationality", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NationalityID", SqlDbType.Int).Value = nationalityID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

