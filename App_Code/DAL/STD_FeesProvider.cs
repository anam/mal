using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_FeesProvider:DataAccessObject
{
	public SqlSTD_FeesProvider()
    {
    }


    public DataSet  GetAllSTD_Feess()
    {
        DataSet STD_Feess = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Feess", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Feess);
            myadapter.Dispose();
            connection.Close();

            return STD_Feess;
        }
    }
	public DataSet GetSTD_FeesPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesPageWise", connection))
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


    public DataSet GetSTD_FeesPageWiseByStudentID(int pageIndex, int PageSize, out int recordCount, string StudentID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesPageWiseByStudentID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", StudentID);
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

    public DataSet GetSTD_FeesPageWiseByStudentIDisPaid(int pageIndex, int PageSize, out int recordCount, string StudentID, bool isPaid)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesPageWiseByStudentIDisPaid", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IsPaid", isPaid);
                command.Parameters.AddWithValue("@StudentID", StudentID);
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

    public STD_Fees  GetSTD_FeesByFeesTypeID(int  feesTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesByFeesTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FeesTypeID", SqlDbType.NVarChar).Value = feesTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int GetStdCalculateSemesterFee()
    {
        int result = 0;
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetStdCalculateSemesterFee", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            result = command.ExecuteNonQuery();
        }

        return result;
    }


    public STD_Fees GetSTD_FeesByStudentID(string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_FeesFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet  GetSTD_FeesByStudentID(string  studentID, bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesByStudentID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", studentID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }

    }



    public DataSet GetSTD_FeesByStudentID(string studentID,int courseID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesByStudentIDnCourseID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@CourseID", courseID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public DataSet GetSTD_FeesListByStudentID(string studentID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesListByStudentID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", studentID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetSTD_FeesListByFeesMasterID(string feesMasterID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesListByFeesMasterID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FeesMasterID", feesMasterID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }



    public DataSet GetSTD_FeesListByStudentCode(string studentCode)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesListByStudentCode", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentCode", studentCode);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetAllSTD_FeesList()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetAllSTD_FeesList", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    //public DataSet GetAllSTD_FeesList_NotPaid()
    //{
    //    DataSet ds = new DataSet();
    //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //    {
    //        using (SqlCommand command = new SqlCommand("GetAllSTD_FeesList_NotPaid", connection))
    //        {
    //            command.CommandType = CommandType.StoredProcedure;
    //            connection.Open();
    //            SqlDataAdapter myadapter = new SqlDataAdapter(command);
    //            myadapter.Fill(ds);
    //            myadapter.Dispose();
    //            connection.Close();
    //            return ds;
    //        }
    //    }
    //}


    public DataSet GetAllSTD_FeesList_NotPaid(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetAllSTD_FeesList_NotPaid", connection))
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

    public STD_Fees  GetSTD_FeesByCourseID(int  courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_Fees  GetSTD_FeesByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_Fees()
    {
        DataSet STD_Feess = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Fees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Feess);
            myadapter.Dispose();
            connection.Close();

            return STD_Feess;
        }
    }

    public DataSet   GetAllSTD_FeessWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_FeessWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Fees> GetSTD_FeessFromReader(IDataReader reader)
    {
        List<STD_Fees> sTD_Feess = new List<STD_Fees>();

        while (reader.Read())
        {
            sTD_Feess.Add(GetSTD_FeesFromReader(reader));
        }
        return sTD_Feess;
    }

    public STD_Fees GetSTD_FeesFromReader(IDataReader reader)
    {
        try
        {
            STD_Fees sTD_Fees = new STD_Fees
                (

                     DataAccessObject.IsNULL<int>(reader["FeesID"]),
                     DataAccessObject.IsNULL<string>(reader["FeesName"]),
                     DataAccessObject.IsNULL<decimal>(reader["Amount"]),
                     DataAccessObject.IsNULL<int>(reader["FeesTypeID"]),
                     DataAccessObject.IsNULL<DateTime>(reader["SubmissionDate"]),
                     DataAccessObject.IsNULL<string>(reader["SubmitedDate"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"]),
                     DataAccessObject.IsNULL<string>(reader["Remarks"]),
                     DataAccessObject.IsNULL<bool>(reader["IsPaid"])
                );
             return sTD_Fees;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Fees  GetSTD_FeesByFeesID(int  feesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesByFeesID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FeesID", SqlDbType.Int).Value = feesID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Fees(STD_Fees sTD_Fees)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Fees", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@FeesName", SqlDbType.NVarChar).Value = sTD_Fees.FeesName;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = sTD_Fees.Amount;
            cmd.Parameters.Add("@FeesTypeID", SqlDbType.Int).Value = sTD_Fees.FeesTypeID;
            cmd.Parameters.Add("@SubmissionDate", SqlDbType.DateTime).Value = sTD_Fees.SubmissionDate;
            cmd.Parameters.Add("@SubmitedDate", SqlDbType.NVarChar).Value = sTD_Fees.SubmitedDate;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_Fees.StudentID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Fees.CourseID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Fees.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Fees.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Fees.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Fees.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Fees.RowStatusID;
            cmd.Parameters.Add("@Remarks", SqlDbType.NText).Value = sTD_Fees.Remarks;
            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = sTD_Fees.IsPaid;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FeesID"].Value;
        }
    }

    public bool UpdateSTD_Fees(STD_Fees sTD_Fees)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Fees", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesID", SqlDbType.Int).Value = sTD_Fees.FeesID;
            cmd.Parameters.Add("@FeesName", SqlDbType.NVarChar).Value = sTD_Fees.FeesName;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = sTD_Fees.Amount;
            cmd.Parameters.Add("@FeesTypeID", SqlDbType.Int).Value = sTD_Fees.FeesTypeID;
            cmd.Parameters.Add("@SubmissionDate", SqlDbType.DateTime).Value = sTD_Fees.SubmissionDate;
            cmd.Parameters.Add("@SubmitedDate", SqlDbType.NVarChar).Value = sTD_Fees.SubmitedDate;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_Fees.StudentID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Fees.CourseID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Fees.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Fees.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Fees.RowStatusID;
            cmd.Parameters.Add("@Remarks", SqlDbType.NText).Value = sTD_Fees.Remarks;
            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = sTD_Fees.IsPaid;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Fees(int feesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Fees", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesID", SqlDbType.Int).Value = feesID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public bool DeleteSTD_FeesFeesMasterID(int feesID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_FeesFeesMasterID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesMasterID", SqlDbType.NVarChar).Value = feesID.ToString();
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetSTD_SemesterFeeByStudentID(string studentID)
    {
        DataSet STD_Feess = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_SemesterFeeByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Feess);
            myadapter.Dispose();
            connection.Close();

            return STD_Feess;
        }
    }

    public DataSet GetSTD_FeesInstallmentByFeesMasterID(string feesmasterID)
    {
        DataSet STD_Feess = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesInstallmentByFeesMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FeesMasterID", SqlDbType.NVarChar).Value = feesmasterID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Feess);
            myadapter.Dispose();
            connection.Close();
            return STD_Feess;
        }
    }

}

