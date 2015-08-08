using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_ReligionProvider:DataAccessObject
{
	public SqlCOMN_ReligionProvider()
    {
    }


    public DataSet  GetAllCOMN_Religions()
    {
        DataSet COMN_Religions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_Religions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Religions);
            myadapter.Dispose();
            connection.Close();

            return COMN_Religions;
        }
    }
	public DataSet GetCOMN_ReligionPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_ReligionPageWise", connection))
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


    public DataSet  GetDropDownListAllCOMN_Religion()
    {
        DataSet COMN_Religions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_Religions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_Religions);
            myadapter.Dispose();
            connection.Close();

            return COMN_Religions;
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
    public List<COMN_Religion> GetCOMN_ReligionsFromReader(IDataReader reader)
    {
        List<COMN_Religion> cOMN_Religions = new List<COMN_Religion>();

        while (reader.Read())
        {
            cOMN_Religions.Add(GetCOMN_ReligionFromReader(reader));
        }
        return cOMN_Religions;
    }

    public COMN_Religion GetCOMN_ReligionFromReader(IDataReader reader)
    {
        try
        {
            COMN_Religion cOMN_Religion = new COMN_Religion
                (

                     DataAccessObject.IsNULL<int>(reader["ReligionID"]),
                     DataAccessObject.IsNULL<string>(reader["ReligionName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return cOMN_Religion;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_Religion  GetCOMN_ReligionByReligionID(int  religionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_ReligionByReligionID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReligionID", SqlDbType.Int).Value = religionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_ReligionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_Religion(COMN_Religion cOMN_Religion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_Religion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReligionName", SqlDbType.NVarChar).Value = cOMN_Religion.ReligionName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_Religion.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_Religion.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_Religion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_Religion.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ReligionID"].Value;
        }
    }

    public bool UpdateCOMN_Religion(COMN_Religion cOMN_Religion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_Religion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Value = cOMN_Religion.ReligionID;
            cmd.Parameters.Add("@ReligionName", SqlDbType.NVarChar).Value = cOMN_Religion.ReligionName;
            
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_Religion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_Religion.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_Religion(int religionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_Religion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Value = religionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

