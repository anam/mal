using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_RankProvider:DataAccessObject
{
	public SqlHR_RankProvider()
    {
    }


    public DataSet  GetAllHR_Ranks()
    {
        DataSet HR_Ranks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Ranks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Ranks);
            myadapter.Dispose();
            connection.Close();

            return HR_Ranks;
        }
    }
	public DataSet GetHR_RankPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_RankPageWise", connection))
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


    public DataSet  GetDropDownLisAllHR_Rank()
    {
        DataSet HR_Ranks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Rank", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Ranks);
            myadapter.Dispose();
            connection.Close();

            return HR_Ranks;
        }
    }
    public List<HR_Rank> GetHR_RanksFromReader(IDataReader reader)
    {
        List<HR_Rank> hR_Ranks = new List<HR_Rank>();

        while (reader.Read())
        {
            hR_Ranks.Add(GetHR_RankFromReader(reader));
        }
        return hR_Ranks;
    }

    public HR_Rank GetHR_RankFromReader(IDataReader reader)
    {
        try
        {
            HR_Rank hR_Rank = new HR_Rank
                (

                     DataAccessObject.IsNULL<int>(reader["RankID"]),
                     DataAccessObject.IsNULL<string>(reader["RankName"]),
                     DataAccessObject.IsNULL<int>(reader["SeniorityLevel"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return hR_Rank;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Rank  GetHR_RankByRankID(int  rankID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_RankByRankID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RankID", SqlDbType.Int).Value = rankID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_RankFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_Rank(HR_Rank hR_Rank)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Rank", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RankID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RankName", SqlDbType.NVarChar).Value = hR_Rank.RankName;
            cmd.Parameters.Add("@SeniorityLevel", SqlDbType.Int).Value = hR_Rank.SeniorityLevel;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Rank.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Rank.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_Rank.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = hR_Rank.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@RankID"].Value;
        }
    }

    public bool UpdateHR_Rank(HR_Rank hR_Rank)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Rank", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RankID", SqlDbType.Int).Value = hR_Rank.RankID;
            cmd.Parameters.Add("@RankName", SqlDbType.NVarChar).Value = hR_Rank.RankName;
            cmd.Parameters.Add("@SeniorityLevel", SqlDbType.Int).Value = hR_Rank.SeniorityLevel;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = hR_Rank.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = hR_Rank.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Rank(int rankID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Rank", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RankID", SqlDbType.Int).Value = rankID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

