using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_HeadProvider:DataAccessObject
{
	public SqlACC_HeadProvider()
    {
    }


    public DataSet  GetAllACC_Heads()
    {
        DataSet ACC_Heads = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_Heads", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Heads);
            myadapter.Dispose();
            connection.Close();

            return ACC_Heads;
        }
    }
	public DataSet GetACC_HeadPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_HeadPageWise", connection))
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


    public ACC_Head  GetACC_HeadByAccountID(int  accountID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_HeadByAccountID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AccountID", SqlDbType.NVarChar).Value = accountID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_HeadFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_Head  GetACC_HeadByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_HeadByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_HeadFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_Head()
    {
        DataSet ACC_Heads = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_Head", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Heads);
            myadapter.Dispose();
            connection.Close();

            return ACC_Heads;
        }
    }

    public DataSet   GetAllACC_HeadsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_HeadsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_Head> GetACC_HeadsFromReader(IDataReader reader)
    {
        List<ACC_Head> aCC_Heads = new List<ACC_Head>();

        while (reader.Read())
        {
            aCC_Heads.Add(GetACC_HeadFromReader(reader));
        }
        return aCC_Heads;
    }

    public ACC_Head GetACC_HeadFromReader(IDataReader reader)
    {
        try
        {
            ACC_Head aCC_Head = new ACC_Head
                (

                     DataAccessObject.IsNULL<int>(reader["HeadID"]),
                     DataAccessObject.IsNULL<string>(reader["HeadName"]),
                     DataAccessObject.IsNULL<string>(reader["HeadCode"]),
                     DataAccessObject.IsNULL<int>(reader["AccountID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_Head;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_Head  GetACC_HeadByHeadID(int  headID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_HeadByHeadID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HeadID", SqlDbType.Int).Value = headID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_HeadFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_Head(ACC_Head aCC_Head)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_Head", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@HeadName", SqlDbType.NVarChar).Value = aCC_Head.HeadName;
            cmd.Parameters.Add("@HeadCode", SqlDbType.NVarChar).Value = aCC_Head.HeadCode;
            cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = aCC_Head.AccountID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Head.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Head.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Head.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Head.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Head.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@HeadID"].Value;
        }
    }

    public bool UpdateACC_Head(ACC_Head aCC_Head)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_Head", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_Head.HeadID;
            cmd.Parameters.Add("@HeadName", SqlDbType.NVarChar).Value = aCC_Head.HeadName;
            cmd.Parameters.Add("@HeadCode", SqlDbType.NVarChar).Value = aCC_Head.HeadCode;
            cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = aCC_Head.AccountID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Head.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Head.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Head.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_Head(int headID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_Head", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = headID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

