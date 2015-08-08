using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_OpeningBalanceProvider:DataAccessObject
{
	public SqlACC_OpeningBalanceProvider()
    {
    }


    public DataSet  GetAllACC_OpeningBalances()
    {
        DataSet ACC_OpeningBalances = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_OpeningBalances", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_OpeningBalances);
            myadapter.Dispose();
            connection.Close();

            return ACC_OpeningBalances;
        }
    }
	public DataSet GetACC_OpeningBalancePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_OpeningBalancePageWise", connection))
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


    public ACC_OpeningBalance  GetACC_OpeningBalanceByHeadID(int  headID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_OpeningBalanceByHeadID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HeadID", SqlDbType.NVarChar).Value = headID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_OpeningBalanceFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_OpeningBalance  GetACC_OpeningBalanceByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_OpeningBalanceByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_OpeningBalanceFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_OpeningBalance()
    {
        DataSet ACC_OpeningBalances = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_OpeningBalance", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_OpeningBalances);
            myadapter.Dispose();
            connection.Close();

            return ACC_OpeningBalances;
        }
    }

    public DataSet   GetAllACC_OpeningBalancesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_OpeningBalancesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_OpeningBalance> GetACC_OpeningBalancesFromReader(IDataReader reader)
    {
        List<ACC_OpeningBalance> aCC_OpeningBalances = new List<ACC_OpeningBalance>();

        while (reader.Read())
        {
            aCC_OpeningBalances.Add(GetACC_OpeningBalanceFromReader(reader));
        }
        return aCC_OpeningBalances;
    }

    public ACC_OpeningBalance GetACC_OpeningBalanceFromReader(IDataReader reader)
    {
        try
        {
            ACC_OpeningBalance aCC_OpeningBalance = new ACC_OpeningBalance
                (

                     DataAccessObject.IsNULL<int>(reader["OpeningBalanceID"]),
                     DataAccessObject.IsNULL<string>(reader["OpeningBalanceName"]),
                     DataAccessObject.IsNULL<decimal>(reader["Amount"]),
                     DataAccessObject.IsNULL<bool>(reader["IsUsed"]),
                     DataAccessObject.IsNULL<int>(reader["HeadID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_OpeningBalance;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_OpeningBalance  GetACC_OpeningBalanceByOpeningBalanceID(int  openingBalanceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_OpeningBalanceByOpeningBalanceID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OpeningBalanceID", SqlDbType.Int).Value = openingBalanceID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_OpeningBalanceFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_OpeningBalance(ACC_OpeningBalance aCC_OpeningBalance)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_OpeningBalance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OpeningBalanceID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@OpeningBalanceName", SqlDbType.NVarChar).Value = aCC_OpeningBalance.OpeningBalanceName;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_OpeningBalance.Amount;
            cmd.Parameters.Add("@IsUsed", SqlDbType.Bit).Value = aCC_OpeningBalance.IsUsed;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_OpeningBalance.HeadID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_OpeningBalance.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_OpeningBalance.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_OpeningBalance.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_OpeningBalance.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_OpeningBalance.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@OpeningBalanceID"].Value;
        }
    }

    public bool UpdateACC_OpeningBalance(ACC_OpeningBalance aCC_OpeningBalance)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_OpeningBalance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OpeningBalanceID", SqlDbType.Int).Value = aCC_OpeningBalance.OpeningBalanceID;
            cmd.Parameters.Add("@OpeningBalanceName", SqlDbType.NVarChar).Value = aCC_OpeningBalance.OpeningBalanceName;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_OpeningBalance.Amount;
            cmd.Parameters.Add("@IsUsed", SqlDbType.Bit).Value = aCC_OpeningBalance.IsUsed;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_OpeningBalance.HeadID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_OpeningBalance.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_OpeningBalance.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_OpeningBalance.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_OpeningBalance(int openingBalanceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_OpeningBalance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OpeningBalanceID", SqlDbType.Int).Value = openingBalanceID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

