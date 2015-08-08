using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_BoardUniversityProvider:DataAccessObject
{
	public SqlSTD_BoardUniversityProvider()
    {
    }


    public DataSet  GetAllSTD_BoardUniversities()
    {
        DataSet STD_BoardUniversities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_BoardUniversities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_BoardUniversities);
            myadapter.Dispose();
            connection.Close();

            return STD_BoardUniversities;
        }
    }
	public DataSet GetSTD_BoardUniversityPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_BoardUniversityPageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_BoardUniversity()
    {
        DataSet STD_BoardUniversities = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_BoardUniversities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_BoardUniversities);
            myadapter.Dispose();
            connection.Close();

            return STD_BoardUniversities;
        }
    }

    public DataSet   GetAllLIB_BookIssuesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLIB_BookIssuesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_BoardUniversity> GetSTD_BoardUniversitiesFromReader(IDataReader reader)
    {
        List<STD_BoardUniversity> sTD_BoardUniversities = new List<STD_BoardUniversity>();

        while (reader.Read())
        {
            sTD_BoardUniversities.Add(GetSTD_BoardUniversityFromReader(reader));
        }
        return sTD_BoardUniversities;
    }

    public STD_BoardUniversity GetSTD_BoardUniversityFromReader(IDataReader reader)
    {
        try
        {
            STD_BoardUniversity sTD_BoardUniversity = new STD_BoardUniversity
                (

                     DataAccessObject.IsNULL<int>(reader["BoardUniversityID"]),
                     DataAccessObject.IsNULL<string>(reader["BoardUniversityName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return sTD_BoardUniversity;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_BoardUniversity  GetSTD_BoardUniversityByBoardUniversityID(int  boardUniversityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_BoardUniversityByBoardUniversityID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BoardUniversityID", SqlDbType.Int).Value = boardUniversityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_BoardUniversityFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_BoardUniversity(STD_BoardUniversity sTD_BoardUniversity)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_BoardUniversity", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BoardUniversityID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BoardUniversityName", SqlDbType.NVarChar).Value = sTD_BoardUniversity.BoardUniversityName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_BoardUniversity.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_BoardUniversity.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_BoardUniversity.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_BoardUniversity.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BoardUniversityID"].Value;
        }
    }

    public bool UpdateSTD_BoardUniversity(STD_BoardUniversity sTD_BoardUniversity)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_BoardUniversity", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BoardUniversityID", SqlDbType.Int).Value = sTD_BoardUniversity.BoardUniversityID;
            cmd.Parameters.Add("@BoardUniversityName", SqlDbType.NVarChar).Value = sTD_BoardUniversity.BoardUniversityName;
            //cmd.Parameters.Add("@BoardUniversityName", SqlDbType.NVarChar).Value = sTD_BoardUniversity.BoardUniversityName;
            //cmd.Parameters.Add("@BoardUniversityName", SqlDbType.NVarChar).Value = sTD_BoardUniversity.BoardUniversityName;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = sTD_BoardUniversity.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = sTD_BoardUniversity.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_BoardUniversity(int boardUniversityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_BoardUniversity", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BoardUniversityID", SqlDbType.Int).Value = boardUniversityID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

