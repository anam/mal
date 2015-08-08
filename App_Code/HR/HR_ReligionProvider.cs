using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ReligionProvider:DataAccessObject
{
	public SqlHR_ReligionProvider()
    {
    }


    public DataSet  GetAllHR_Religions()
    {
        DataSet HR_Religions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_Religions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Religions);
            myadapter.Dispose();
            connection.Close();

            return HR_Religions;
        }
    }
	public DataSet GetHR_ReligionPageWise(int pageIndex, int PageSize, out int recordCount)
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
   

    public DataSet  GetDropDownListAllHR_Religion()
    {
        DataSet HR_Religions = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_Religions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Religions);
            myadapter.Dispose();
            connection.Close();

            return HR_Religions;
        }
    }

    public DataSet   GetAllHR_LeaveRulesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_LeaveRulesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_Religion> GetHR_ReligionsFromReader(IDataReader reader)
    {
        List<HR_Religion> hR_Religions = new List<HR_Religion>();

        while (reader.Read())
        {
            hR_Religions.Add(GetHR_ReligionFromReader(reader));
        }
        return hR_Religions;
    }

    public HR_Religion GetHR_ReligionFromReader(IDataReader reader)
    {
        try
        {
            HR_Religion hR_Religion = new HR_Religion
                (

                     DataAccessObject.IsNULL<int>(reader["ReligionID"]),
                     DataAccessObject.IsNULL<string>(reader["ReligionName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_Religion;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Religion  GetHR_ReligionByReligionID(int  religionID)
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
            return GetHR_ReligionFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_Religion(HR_Religion hR_Religion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_Religion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReligionName", SqlDbType.NVarChar).Value = hR_Religion.ReligionName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Religion.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Religion.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Religion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Religion.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ReligionID"].Value;
        }
    }

    public bool UpdateHR_Religion(HR_Religion hR_Religion)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_Religion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReligionID", SqlDbType.Int).Value = hR_Religion.ReligionID;
            cmd.Parameters.Add("@ReligionName", SqlDbType.NVarChar).Value = hR_Religion.ReligionName;
            cmd.Parameters.Add("@ReligionName", SqlDbType.NVarChar).Value = hR_Religion.ReligionName;
            cmd.Parameters.Add("@ReligionName", SqlDbType.NVarChar).Value = hR_Religion.ReligionName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Religion.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Religion.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Religion(int religionID)
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

