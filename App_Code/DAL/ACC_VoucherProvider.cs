using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_VoucherProvider : DataAccessObject
{
    public SqlACC_VoucherProvider()
    {
    }


    public DataSet GetAllACC_Vouchers()
    {
        DataSet ACC_Vouchers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_Vouchers", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Vouchers);
            myadapter.Dispose();
            connection.Close();

            return ACC_Vouchers;
        }
    }
    public DataSet GetACC_VoucherPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_VoucherPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
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


    public ACC_Voucher GetACC_VoucherByHeadID(int headID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_VoucherByHeadID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HeadID", SqlDbType.NVarChar).Value = headID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetACC_VoucherFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public ACC_Voucher GetACC_VoucherByRowStatusID(int rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_VoucherByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetACC_VoucherFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetDropDownLisAllACC_Voucher()
    {
        DataSet ACC_Vouchers = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_Voucher", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Vouchers);
            myadapter.Dispose();
            connection.Close();

            return ACC_Vouchers;
        }
    }

    public DataSet GetAllACC_VouchersWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_VouchersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_Voucher> GetACC_VouchersFromReader(IDataReader reader)
    {
        List<ACC_Voucher> aCC_Vouchers = new List<ACC_Voucher>();

        while (reader.Read())
        {
            aCC_Vouchers.Add(GetACC_VoucherFromReader(reader));
        }
        return aCC_Vouchers;
    }

    public ACC_Voucher GetACC_VoucherFromReader(IDataReader reader)
    {
        try
        {
            ACC_Voucher aCC_Voucher = new ACC_Voucher
            (

            DataAccessObject.IsNULL<int>(reader["VoucherID"]),
            DataAccessObject.IsNULL<string>(reader["VoucherNo"]),
            DataAccessObject.IsNULL<int>(reader["HeadID"]),
            DataAccessObject.IsNULL<string>(reader["DebitOrCredit"]),
            DataAccessObject.IsNULL<string>(reader["FromTo"]),
            DataAccessObject.IsNULL<decimal>(reader["Amount"]),
            DataAccessObject.IsNULL<string>(reader["OnAccountOf"]),
            DataAccessObject.IsNULL<string>(reader["InWord"]),
            DataAccessObject.IsNULL<bool>(reader["IsApproved"]),
            DataAccessObject.IsNULL<DateTime>(reader["ApprovalDate"]),
            DataAccessObject.IsNULL<DateTime>(reader["VoucherDate"]),
            DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
            DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
            DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
            DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
            DataAccessObject.IsNULL<int>(reader["RowStatusID"]),
            DataAccessObject.IsNULL<string>(reader["Remarks"])
            );
            return aCC_Voucher;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ACC_Voucher GetACC_VoucherByVoucherID(int voucherID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_VoucherByVoucherID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@VoucherID", SqlDbType.Int).Value = voucherID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetACC_VoucherFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertACC_Voucher(ACC_Voucher aCC_Voucher)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_Voucher", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@VoucherNo", SqlDbType.NVarChar).Value = aCC_Voucher.VoucherNo;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_Voucher.HeadID;
            cmd.Parameters.Add("@DebitOrCredit", SqlDbType.NVarChar).Value = aCC_Voucher.DebitOrCredit;
            cmd.Parameters.Add("@FromTo", SqlDbType.NVarChar).Value = aCC_Voucher.FromTo;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Voucher.Amount;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Voucher.Amount;
            cmd.Parameters.Add("@OnAccountOf", SqlDbType.NVarChar).Value = aCC_Voucher.OnAccountOf;
            cmd.Parameters.Add("@InWord", SqlDbType.NText).Value = aCC_Voucher.InWord;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = aCC_Voucher.IsApproved;
            cmd.Parameters.Add("@ApprovalDate", SqlDbType.DateTime).Value = aCC_Voucher.ApprovalDate;
            cmd.Parameters.Add("@VoucherDate", SqlDbType.DateTime).Value = aCC_Voucher.VoucherDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Voucher.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Voucher.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Voucher.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Voucher.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Voucher.RowStatusID;
            cmd.Parameters.Add("@Remarks", SqlDbType.NText).Value = aCC_Voucher.Remarks;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@VoucherID"].Value;
        }
    }

    public bool UpdateACC_Voucher(ACC_Voucher aCC_Voucher)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_Voucher", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = aCC_Voucher.VoucherID;
            cmd.Parameters.Add("@VoucherNo", SqlDbType.NVarChar).Value = aCC_Voucher.VoucherNo;
            cmd.Parameters.Add("@HeadID", SqlDbType.Int).Value = aCC_Voucher.HeadID;
            cmd.Parameters.Add("@DebitOrCredit", SqlDbType.NVarChar).Value = aCC_Voucher.DebitOrCredit;
            cmd.Parameters.Add("@FromTo", SqlDbType.NVarChar).Value = aCC_Voucher.FromTo;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = aCC_Voucher.Amount;
            cmd.Parameters.Add("@OnAccountOf", SqlDbType.NVarChar).Value = aCC_Voucher.OnAccountOf;
            cmd.Parameters.Add("@InWord", SqlDbType.NText).Value = aCC_Voucher.InWord;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = aCC_Voucher.IsApproved;
            cmd.Parameters.Add("@ApprovalDate", SqlDbType.DateTime).Value = aCC_Voucher.ApprovalDate;
            cmd.Parameters.Add("@VoucherDate", SqlDbType.DateTime).Value = aCC_Voucher.VoucherDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Voucher.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Voucher.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Voucher.RowStatusID;
            cmd.Parameters.Add("@Remarks", SqlDbType.NText).Value = aCC_Voucher.Remarks;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_Voucher(int voucherID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_Voucher", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = voucherID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}
