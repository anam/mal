using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_VoucherIteamProvider:DataAccessObject
{
	public SqlACC_VoucherIteamProvider()
    {
    }


    public DataSet  GetAllACC_VoucherIteams()
    {
        DataSet ACC_VoucherIteams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_VoucherIteams", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_VoucherIteams);
            myadapter.Dispose();
            connection.Close();

            return ACC_VoucherIteams;
        }
    }
	public DataSet GetACC_VoucherIteamPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_VoucherIteamPageWise", connection))
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


    public ACC_VoucherIteam  GetACC_VoucherIteamByVoucherID(int  voucherID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_VoucherIteamByVoucherID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VoucherID", SqlDbType.NVarChar).Value = voucherID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_VoucherIteamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_VoucherIteam  GetACC_VoucherIteamByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_VoucherIteamByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_VoucherIteamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_VoucherIteam()
    {
        DataSet ACC_VoucherIteams = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_VoucherIteam", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_VoucherIteams);
            myadapter.Dispose();
            connection.Close();

            return ACC_VoucherIteams;
        }
    }

    public DataSet   GetAllACC_VoucherIteamsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_VoucherIteamsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_VoucherIteam> GetACC_VoucherIteamsFromReader(IDataReader reader)
    {
        List<ACC_VoucherIteam> aCC_VoucherIteams = new List<ACC_VoucherIteam>();

        while (reader.Read())
        {
            aCC_VoucherIteams.Add(GetACC_VoucherIteamFromReader(reader));
        }
        return aCC_VoucherIteams;
    }

    public ACC_VoucherIteam GetACC_VoucherIteamFromReader(IDataReader reader)
    {
        try
        {
            ACC_VoucherIteam aCC_VoucherIteam = new ACC_VoucherIteam
                (

                     DataAccessObject.IsNULL<int>(reader["VoucherIteamID"]),
                     DataAccessObject.IsNULL<string>(reader["VoucherIteamName"]),
                     DataAccessObject.IsNULL<int>(reader["VoucherID"]),
                     DataAccessObject.IsNULL<string>(reader["IteamCode"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<decimal>(reader["UnitPrice"]),
                     DataAccessObject.IsNULL<decimal>(reader["Quantity"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_VoucherIteam;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_VoucherIteam  GetACC_VoucherIteamByVoucherIteamID(int  voucherIteamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_VoucherIteamByVoucherIteamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VoucherIteamID", SqlDbType.Int).Value = voucherIteamID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_VoucherIteamFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertACC_VoucherIteam(ACC_VoucherIteam aCC_VoucherIteam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_VoucherIteam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoucherIteamID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@VoucherIteamName", SqlDbType.NVarChar).Value = aCC_VoucherIteam.VoucherIteamName;
            cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = aCC_VoucherIteam.VoucherID;
            cmd.Parameters.Add("@IteamCode", SqlDbType.NVarChar).Value = aCC_VoucherIteam.IteamCode;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = aCC_VoucherIteam.Description;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = aCC_VoucherIteam.UnitPrice;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = aCC_VoucherIteam.Quantity;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_VoucherIteam.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_VoucherIteam.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_VoucherIteam.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_VoucherIteam.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_VoucherIteam.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@VoucherIteamID"].Value;
        }
    }

    public bool UpdateACC_VoucherIteam(ACC_VoucherIteam aCC_VoucherIteam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_VoucherIteam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoucherIteamID", SqlDbType.Int).Value = aCC_VoucherIteam.VoucherIteamID;
            cmd.Parameters.Add("@VoucherIteamName", SqlDbType.NVarChar).Value = aCC_VoucherIteam.VoucherIteamName;
            cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = aCC_VoucherIteam.VoucherID;
            cmd.Parameters.Add("@IteamCode", SqlDbType.NVarChar).Value = aCC_VoucherIteam.IteamCode;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = aCC_VoucherIteam.Description;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = aCC_VoucherIteam.UnitPrice;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = aCC_VoucherIteam.Quantity;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_VoucherIteam.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_VoucherIteam.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_VoucherIteam.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_VoucherIteam(int voucherIteamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_VoucherIteam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoucherIteamID", SqlDbType.Int).Value = voucherIteamID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

