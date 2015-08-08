using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_EmployeeRankProvider:DataAccessObject
{
	public SqlHR_EmployeeRankProvider()
    {
    }


    public DataSet  GetAllHR_EmployeeRanks()
    {
        DataSet HR_EmployeeRanks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EmployeeRanks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeRanks);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeeRanks;
        }
    }
	public DataSet GetHR_EmployeeRankPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_EmployeeRankPageWise", connection))
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


    public DataSet  GetDropDownListAllHR_EmployeeRank()
    {
        DataSet HR_EmployeeRanks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_EmployeeRanks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EmployeeRanks);
            myadapter.Dispose();
            connection.Close();

            return HR_EmployeeRanks;
        }
    }

    public DataSet   GetAllHR_LeaveRulesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LeaveRulesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_EmployeeRank> GetHR_EmployeeRanksFromReader(IDataReader reader)
    {
        List<HR_EmployeeRank> hR_EmployeeRanks = new List<HR_EmployeeRank>();

        while (reader.Read())
        {
            hR_EmployeeRanks.Add(GetHR_EmployeeRankFromReader(reader));
        }
        return hR_EmployeeRanks;
    }

    public HR_EmployeeRank GetHR_EmployeeRankFromReader(IDataReader reader)
    {
        try
        {
            HR_EmployeeRank hR_EmployeeRank = new HR_EmployeeRank
                (

                     DataAccessObject.IsNULL<int>(reader["EmployeeRankID"]),
                     DataAccessObject.IsNULL<string>(reader["RankName"]),
                     DataAccessObject.IsNULL<int>(reader["SeniorityLevel"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_EmployeeRank;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_EmployeeRank  GetHR_EmployeeRankByEmployeeRankID(int  employeeRankID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EmployeeRankByEmployeeRankID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeRankID", SqlDbType.Int).Value = employeeRankID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EmployeeRankFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_EmployeeRank(HR_EmployeeRank hR_EmployeeRank)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_EmployeeRank", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeRankID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RankName", SqlDbType.NVarChar).Value = hR_EmployeeRank.RankName;
            cmd.Parameters.Add("@SeniorityLevel", SqlDbType.Int).Value = hR_EmployeeRank.SeniorityLevel;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_EmployeeRank.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_EmployeeRank.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EmployeeRank.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EmployeeRank.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmployeeRankID"].Value;
        }
    }

    public bool UpdateHR_EmployeeRank(HR_EmployeeRank hR_EmployeeRank)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EmployeeRank", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeRankID", SqlDbType.Int).Value = hR_EmployeeRank.EmployeeRankID;
            cmd.Parameters.Add("@RankName", SqlDbType.NVarChar).Value = hR_EmployeeRank.RankName;
            cmd.Parameters.Add("@SeniorityLevel", SqlDbType.Int).Value = hR_EmployeeRank.SeniorityLevel;
            cmd.Parameters.Add("@SeniorityLevel", SqlDbType.Int).Value = hR_EmployeeRank.SeniorityLevel;
            cmd.Parameters.Add("@SeniorityLevel", SqlDbType.Int).Value = hR_EmployeeRank.SeniorityLevel;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EmployeeRank.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EmployeeRank.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_EmployeeRank(int employeeRankID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EmployeeRank", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeRankID", SqlDbType.Int).Value = employeeRankID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

