using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlACC_CheckProvider:DataAccessObject
{
	public SqlACC_CheckProvider()
    {
    }


    public DataSet  GetAllACC_Checks()
    {
        DataSet ACC_Checks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_Checks", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Checks);
            myadapter.Dispose();
            connection.Close();

            return ACC_Checks;
        }
    }
	public DataSet GetACC_CheckPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_CheckPageWise", connection))
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

    public DataSet GetACC_CheckPageWiseByRowStatus(int pageIndex, int PageSize, out int recordCount, int rowStatusID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_CheckPageWiseByRowStatus", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
                command.Parameters.AddWithValue("@RowStatusID", rowStatusID);
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
    public ACC_Check  GetACC_CheckByBankID(int  bankID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_CheckByBankID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BankID", SqlDbType.NVarChar).Value = bankID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_CheckFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public ACC_Check  GetACC_CheckByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_CheckByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetACC_CheckFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllACC_Check()
    {
        DataSet ACC_Checks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllACC_Check", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Checks);
            myadapter.Dispose();
            connection.Close();

            return ACC_Checks;
        }
    }

    public DataSet   GetAllACC_ChecksWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllACC_ChecksWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<ACC_Check> GetACC_ChecksFromReader(IDataReader reader)
    {
        List<ACC_Check> aCC_Checks = new List<ACC_Check>();

        while (reader.Read())
        {
            aCC_Checks.Add(GetACC_CheckFromReader(reader));
        }
        return aCC_Checks;
    }

    public ACC_Check GetACC_CheckFromReader(IDataReader reader)
    {
        try
        {
            ACC_Check aCC_Check = new ACC_Check
                (

                     DataAccessObject.IsNULL<int>(reader["CheckID"]),
                     DataAccessObject.IsNULL<string>(reader["CheckNo"]),
                     DataAccessObject.IsNULL<string>(reader["BankAccountNo"]),
                     DataAccessObject.IsNULL<int>(reader["BankID"]),
                     DataAccessObject.IsNULL<string>(reader["BranchNOtherDetails"]),
                     DataAccessObject.IsNULL<string>(reader["Remarks"]),
                     DataAccessObject.IsNULL<bool>(reader["IsCashCheck"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return aCC_Check;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ACC_Check GetACC_CheckByCheckID(int checkID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetACC_CheckByCheckID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CheckID", SqlDbType.Int).Value = checkID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetACC_CheckFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public DataSet  GetACC_CheckByCheckID(int  checkID,bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetACC_CheckByCheckID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CheckID", checkID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public int CheckBounchByCheckID(ACC_Check aCC_Check)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ACC_CheckBounchByCheckID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CheckID", SqlDbType.Int).Value = aCC_Check.CheckID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Check.AddedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JournalMasterID"].Value;
        }
    }

    public int CheckTransactinoCompletedByCheckID(ACC_Check aCC_Check)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("ACC_CheckTransactinoCompletedByCheckID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JournalMasterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CheckID", SqlDbType.Int).Value = aCC_Check.CheckID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Check.AddedBy;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = aCC_Check.ExtraField1;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JournalMasterID"].Value;
        }
    }

    public int InsertACC_Check(ACC_Check aCC_Check)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertACC_Check", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CheckID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CheckNo", SqlDbType.NVarChar).Value = aCC_Check.CheckNo;
            cmd.Parameters.Add("@BankAccountNo", SqlDbType.NVarChar).Value = aCC_Check.BankAccountNo;
            cmd.Parameters.Add("@BankID", SqlDbType.Int).Value = aCC_Check.BankID;
            cmd.Parameters.Add("@BranchNOtherDetails", SqlDbType.NText).Value = aCC_Check.BranchNOtherDetails;
            cmd.Parameters.Add("@Remarks", SqlDbType.NText).Value = aCC_Check.Remarks;
            cmd.Parameters.Add("@IsCashCheck", SqlDbType.Bit).Value = aCC_Check.IsCashCheck;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = aCC_Check.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = aCC_Check.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = aCC_Check.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = aCC_Check.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = aCC_Check.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = aCC_Check.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = aCC_Check.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Check.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Check.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Check.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CheckID"].Value;
        }
    }

    public bool UpdateACC_Check(ACC_Check aCC_Check)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateACC_Check", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CheckID", SqlDbType.Int).Value = aCC_Check.CheckID;
            cmd.Parameters.Add("@CheckNo", SqlDbType.NVarChar).Value = aCC_Check.CheckNo;
            cmd.Parameters.Add("@BankAccountNo", SqlDbType.NVarChar).Value = aCC_Check.BankAccountNo;
            cmd.Parameters.Add("@BankID", SqlDbType.Int).Value = aCC_Check.BankID;
            cmd.Parameters.Add("@BranchNOtherDetails", SqlDbType.NText).Value = aCC_Check.BranchNOtherDetails;
            cmd.Parameters.Add("@Remarks", SqlDbType.NText).Value = aCC_Check.Remarks;
            cmd.Parameters.Add("@IsCashCheck", SqlDbType.Bit).Value = aCC_Check.IsCashCheck;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = aCC_Check.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = aCC_Check.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = aCC_Check.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = aCC_Check.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = aCC_Check.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = aCC_Check.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = aCC_Check.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = aCC_Check.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteACC_Check(int checkID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteACC_Check", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CheckID", SqlDbType.Int).Value = checkID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet SearchACC_Checks(string whomUserID, string whoUserID, string checkNo, int bankID, string checkDate,int RowStatusID)
    {
        DataSet ACC_Checks = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SearchACC_Checks", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@WhomUserID", SqlDbType.NVarChar).Value = whomUserID;
            command.Parameters.Add("@WhoUserID", SqlDbType.NVarChar).Value = whoUserID;
            command.Parameters.Add("@CheckNo", SqlDbType.NVarChar).Value = checkNo;
            command.Parameters.Add("@BankID", SqlDbType.Int).Value = bankID;
            command.Parameters.Add("@CheckDate", SqlDbType.NVarChar).Value = checkDate;
            command.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = RowStatusID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ACC_Checks);
            myadapter.Dispose();
            connection.Close();

            return ACC_Checks;
        }
    }
}

