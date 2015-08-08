using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_EmployerTypeProvider:DataAccessObject
{
	public SqlHR_EmployerTypeProvider()
    {
    }


    public DataSet  GetAllHR_EmployerTypes()
    {
        DataSet HR_EmployerTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployerTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployerTypes);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployerTypes;
        }
    }
	public DataSet GetHR_EmployerTypePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_EmployerTypePageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_EmployerType()
    {
        DataSet HR_EmployerTypes = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_EmployerType", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployerTypes);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployerTypes;
        }
    }
    public List<HR_EmployerType> GetHR_EmployerTypesFromReader(IDataReader reader)
    {
        List<HR_EmployerType> hR_EmployerTypes = new List<HR_EmployerType>();

        while (reader.Read())
        {
            hR_EmployerTypes.Add(GetHR_EmployerTypeFromReader(reader));
        }
        return hR_EmployerTypes;
    }

    public HR_EmployerType GetHR_EmployerTypeFromReader(IDataReader reader)
    {
        try
        {
            HR_EmployerType hR_EmployerType = new HR_EmployerType
                (

                     DataAccessObject.IsNULL<int>(reader["EmployerType"]),
                     DataAccessObject.IsNULL<string>(reader["EmployerTypeName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return hR_EmployerType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_EmployerType  GetHR_EmployerTypeByEmployerType(int  employerType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployerTypeByEmployerType", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployerType", SqlDbType.Int).Value = employerType;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployerTypeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_EmployerType(HR_EmployerType hR_EmployerType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_EmployerType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployerType", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployerTypeName", SqlDbType.NVarChar).Value = hR_EmployerType.EmployerTypeName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_EmployerType.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_EmployerType.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_EmployerType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = hR_EmployerType.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmployerType"].Value;
        }
    }

    public bool UpdateHR_EmployerType(HR_EmployerType hR_EmployerType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EmployerType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployerType", SqlDbType.Int).Value = hR_EmployerType.EmployerType;
            cmd.Parameters.Add("@EmployerTypeName", SqlDbType.NVarChar).Value = hR_EmployerType.EmployerTypeName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_EmployerType.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = hR_EmployerType.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_EmployerType(int employerType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployerType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployerType", SqlDbType.Int).Value = employerType;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

