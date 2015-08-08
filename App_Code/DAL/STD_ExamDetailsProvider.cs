using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ExamDetailsProvider:DataAccessObject
{
	public SqlSTD_ExamDetailsProvider()
    {
    }


    public DataSet  GetAllSTD_ExamDetailss()
    {
        DataSet STD_ExamDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamDetailss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailss);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailss;
        }
    }
	public DataSet GetSTD_ExamDetailsPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ExamDetailsPageWise", connection))
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


    public STD_ExamDetails  GetSTD_ExamDetailsByExamID(int  examID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.NVarChar).Value = examID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamDetailsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamDetails  GetSTD_ExamDetailsByExamTypeID(int  examTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsByExamTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamTypeID", SqlDbType.NVarChar).Value = examTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamDetailsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamDetails  GetSTD_ExamDetailsByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamDetailsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_ExamDetails()
    {
        DataSet STD_ExamDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ExamDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailss);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailss;
        }
    }

    public DataSet   GetAllSTD_ExamDetailssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamDetailssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ExamDetails> GetSTD_ExamDetailssFromReader(IDataReader reader)
    {
        List<STD_ExamDetails> sTD_ExamDetailss = new List<STD_ExamDetails>();

        while (reader.Read())
        {
            sTD_ExamDetailss.Add(GetSTD_ExamDetailsFromReader(reader));
        }
        return sTD_ExamDetailss;
    }

    public STD_ExamDetails GetSTD_ExamDetailsFromReader(IDataReader reader)
    {
        try
        {
            STD_ExamDetails sTD_ExamDetails = new STD_ExamDetails
                (

                     DataAccessObject.IsNULL<int>(reader["ExamDetailsID"]),
                     DataAccessObject.IsNULL<int>(reader["ExamID"]),
                     DataAccessObject.IsNULL<int>(reader["ExamTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["ExamDetailsName"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"]),
                     DataAccessObject.IsNULL<decimal>(reader["TotalMarks"])
                );
             return sTD_ExamDetails;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ExamDetails  GetSTD_ExamDetailsByExamDetailsID(int  examDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsByExamDetailsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamDetailsID", SqlDbType.Int).Value = examDetailsID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamDetailsFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ExamDetails(STD_ExamDetails sTD_ExamDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ExamDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamDetailsID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = sTD_ExamDetails.ExamID;
            cmd.Parameters.Add("@ExamTypeID", SqlDbType.Int).Value = sTD_ExamDetails.ExamTypeID;
            cmd.Parameters.Add("@ExamDetailsName", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExamDetailsName;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ExamDetails.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ExamDetails.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamDetails.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_ExamDetails.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ExamDetails.RowStatusID;
            cmd.Parameters.Add("@TotalMarks", SqlDbType.Decimal).Value = sTD_ExamDetails.TotalMarks;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamDetailsID"].Value;
        }
    }

    public bool UpdateSTD_ExamDetails(STD_ExamDetails sTD_ExamDetails)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ExamDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamDetailsID", SqlDbType.Int).Value = sTD_ExamDetails.ExamDetailsID;
            cmd.Parameters.Add("@ExamID", SqlDbType.Int).Value = sTD_ExamDetails.ExamID;
            cmd.Parameters.Add("@ExamTypeID", SqlDbType.Int).Value = sTD_ExamDetails.ExamTypeID;
            cmd.Parameters.Add("@ExamDetailsName", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExamDetailsName;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ExamDetails.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamDetails.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_ExamDetails.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ExamDetails.RowStatusID;
            cmd.Parameters.Add("@TotalMarks", SqlDbType.Decimal).Value = sTD_ExamDetails.TotalMarks;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ExamDetails(int examDetailsID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ExamDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamDetailsID", SqlDbType.Int).Value = examDetailsID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public DataSet GetSTD_ExamDetailsMarksByExamID(int examID)
    {
        DataSet STD_ExamDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsMarksByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailss);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailss;
        }
    }

    public DataSet GetSTD_ExamDetailByExamID(int examID)
    {
        DataSet STD_ExamDetailss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamDetailsByExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamID", SqlDbType.Int).Value = examID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamDetailss);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamDetailss;
        }
    }
}

