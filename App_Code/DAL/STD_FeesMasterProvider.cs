using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_FeesMasterProvider:DataAccessObject
{
	public SqlSTD_FeesMasterProvider()
    {
    }


    public DataSet  GetAllSTD_FeesMasters()
    {
        DataSet STD_FeesMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_FeesMasters", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_FeesMasters);
            myadapter.Dispose();
            connection.Close();

            return STD_FeesMasters;
        }
    }

    public DataSet GetAllSTD_FeesMastersByFeesTypeID()
    {
        DataSet STD_FeesMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_FeesMastersByFeesTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_FeesMasters);
            myadapter.Dispose();
            connection.Close();

            return STD_FeesMasters;
        }
    }


	public DataSet GetSTD_FeesMasterPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesMasterPageWise", connection))
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


    public STD_FeesMaster  GetSTD_FeesMasterByFeesTypeID(int  feesTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesMasterByFeesTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FeesTypeID", SqlDbType.NVarChar).Value = feesTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_FeesMaster  GetSTD_FeesMasterByStudentID(string  studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesMasterByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetSTD_FeesMasterByStudentID(string studentID,bool isDataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesMasterByStudentID", connection))
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


    public DataSet GetSTD_FeesMasterByStudentIDnCourseIDnFeesTypeID(string studentID, int courseID, int feesTypeID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesMasterByStudentIDnCourseIDnFeesTypeID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@CourseID", courseID);
                command.Parameters.AddWithValue("@FeesTypeID", feesTypeID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public STD_FeesMaster  GetSTD_FeesMasterByCourseID(int  courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesMasterByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_FeesMaster  GetSTD_FeesMasterByPaymentStatusID(int  paymentStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesMasterByPaymentStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PaymentStatusID", SqlDbType.NVarChar).Value = paymentStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_FeesMaster  GetSTD_FeesMasterByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesMasterByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_FeesMaster()
    {
        DataSet STD_FeesMasters = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_FeesMaster", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_FeesMasters);
            myadapter.Dispose();
            connection.Close();

            return STD_FeesMasters;
        }
    }

    public DataSet   GetAllSTD_FeesMastersWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_FeesMastersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_FeesMaster> GetSTD_FeesMastersFromReader(IDataReader reader)
    {
        List<STD_FeesMaster> sTD_FeesMasters = new List<STD_FeesMaster>();

        while (reader.Read())
        {
            sTD_FeesMasters.Add(GetSTD_FeesMasterFromReader(reader));
        }
        return sTD_FeesMasters;
    }

    public STD_FeesMaster GetSTD_FeesMasterFromReader(IDataReader reader)
    {
        try
        {
            STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster
                (

                     DataAccessObject.IsNULL<int>(reader["FeesMasterID"]),
                     DataAccessObject.IsNULL<string>(reader["FeesMasterName"]),
                     DataAccessObject.IsNULL<decimal>(reader["TotalPayment"]),
                     DataAccessObject.IsNULL<decimal>(reader["Discount"]),
                     DataAccessObject.IsNULL<decimal>(reader["TotalPaymentNeedtoPay"]),
                     DataAccessObject.IsNULL<int>(reader["FeesTypeID"]),
                     DataAccessObject.IsNULL<DateTime>(reader["SubmissionDate"]),
                     DataAccessObject.IsNULL<string>(reader["SubmitedDate"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<string>(reader["Remarks"]),
                     DataAccessObject.IsNULL<bool>(reader["IsPaid"]),
                     DataAccessObject.IsNULL<int>(reader["PaymentStatusID"]),
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
             return sTD_FeesMaster;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_FeesMaster  GetSTD_FeesMasterByFeesMasterID(int  feesMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_FeesMasterByFeesMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FeesMasterID", SqlDbType.Int).Value = feesMasterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_FeesMasterFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    

    public int InsertSTD_FeesMaster(STD_FeesMaster sTD_FeesMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_FeesMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesMasterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@FeesMasterName", SqlDbType.NVarChar).Value = sTD_FeesMaster.FeesMasterName;
            cmd.Parameters.Add("@TotalPayment", SqlDbType.Decimal).Value = sTD_FeesMaster.TotalPayment;
            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = sTD_FeesMaster.Discount;
            cmd.Parameters.Add("@TotalPaymentNeedtoPay", SqlDbType.Decimal).Value = sTD_FeesMaster.TotalPaymentNeedtoPay;
            cmd.Parameters.Add("@FeesTypeID", SqlDbType.Int).Value = sTD_FeesMaster.FeesTypeID;
            cmd.Parameters.Add("@SubmissionDate", SqlDbType.DateTime).Value = sTD_FeesMaster.SubmissionDate;
            cmd.Parameters.Add("@SubmitedDate", SqlDbType.NVarChar).Value = sTD_FeesMaster.SubmitedDate;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_FeesMaster.StudentID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_FeesMaster.CourseID;
            cmd.Parameters.Add("@Remarks", SqlDbType.NText).Value = sTD_FeesMaster.Remarks;
            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = sTD_FeesMaster.IsPaid;
            cmd.Parameters.Add("@PaymentStatusID", SqlDbType.Int).Value = sTD_FeesMaster.PaymentStatusID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_FeesMaster.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_FeesMaster.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_FeesMaster.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_FeesMaster.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_FeesMaster.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@FeesMasterID"].Value;
        }
    }

    public bool UpdateSTD_FeesMaster(STD_FeesMaster sTD_FeesMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_FeesMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesMasterID", SqlDbType.Int).Value = sTD_FeesMaster.FeesMasterID;
            cmd.Parameters.Add("@FeesMasterName", SqlDbType.NVarChar).Value = sTD_FeesMaster.FeesMasterName;
            cmd.Parameters.Add("@TotalPayment", SqlDbType.Decimal).Value = sTD_FeesMaster.TotalPayment;
            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = sTD_FeesMaster.Discount;
            cmd.Parameters.Add("@TotalPaymentNeedtoPay", SqlDbType.Decimal).Value = sTD_FeesMaster.TotalPaymentNeedtoPay;
            cmd.Parameters.Add("@FeesTypeID", SqlDbType.Int).Value = sTD_FeesMaster.FeesTypeID;
            cmd.Parameters.Add("@SubmissionDate", SqlDbType.DateTime).Value = sTD_FeesMaster.SubmissionDate;
            cmd.Parameters.Add("@SubmitedDate", SqlDbType.NVarChar).Value = sTD_FeesMaster.SubmitedDate;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_FeesMaster.StudentID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_FeesMaster.CourseID;
            cmd.Parameters.Add("@Remarks", SqlDbType.NText).Value = sTD_FeesMaster.Remarks;
            cmd.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = sTD_FeesMaster.IsPaid;
            cmd.Parameters.Add("@PaymentStatusID", SqlDbType.Int).Value = sTD_FeesMaster.PaymentStatusID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_FeesMaster.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_FeesMaster.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_FeesMaster.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool UpdateSTD_FeesMasterFeesAdjustment(STD_FeesMaster sTD_FeesMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_FeesMasterFeesAdjustment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesMasterID", SqlDbType.Int).Value = sTD_FeesMaster.FeesMasterID;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_FeesMaster.CourseID;
            cmd.Parameters.Add("@TotalPayment", SqlDbType.Decimal).Value = sTD_FeesMaster.TotalPayment;
            cmd.Parameters.Add("@TotalPaymentNeedtoPay", SqlDbType.Decimal).Value = sTD_FeesMaster.TotalPaymentNeedtoPay;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField2;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_FeesMaster.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_FeesMaster.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool UpdateSTD_FeesMasterForJournalDelete(STD_FeesMaster sTD_FeesMaster)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_FeesMasterForJournalDelete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesMasterID", SqlDbType.Int).Value = sTD_FeesMaster.FeesMasterID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_FeesMaster.ExtraField2;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_FeesMaster.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_FeesMaster.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }


    public bool DeleteSTD_FeesMaster(int feesMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_FeesMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeesMasterID", SqlDbType.Int).Value = feesMasterID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }

    }
    public bool RefundSTD_FeesMaster(string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("RefundSTD_FeesMaster", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
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

    public DataSet GetSTD_FeesAmountByFeesMasterID(string feesMasterID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_FeesAmountByFeesMasterID", connection))
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
}

