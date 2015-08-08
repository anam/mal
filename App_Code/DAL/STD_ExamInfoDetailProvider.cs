using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ExamInfoDetailProvider:DataAccessObject
{
	public SqlSTD_ExamInfoDetailProvider()
    {
    }


    public DataSet  GetAllSTD_ExamInfoDetails()
    {
        DataSet STD_ExamInfoDetails = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamInfoDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamInfoDetails);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamInfoDetails;
        }
    }
	public DataSet GetSTD_ExamInfoDetailPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ExamInfoDetailPageWise", connection))
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


    public STD_ExamInfoDetail  GetSTD_ExamInfoDetailByExamInfoID(int  examInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoDetailByExamInfoID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamInfoID", SqlDbType.NVarChar).Value = examInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoDetailFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamInfoDetail  GetSTD_ExamInfoDetailByStudentID(string  studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoDetailByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoDetailFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamInfoDetail  GetSTD_ExamInfoDetailBySubjectID(int  subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoDetailBySubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectID", SqlDbType.NVarChar).Value = subjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoDetailFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamInfoDetail  GetSTD_ExamInfoDetailByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoDetailByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoDetailFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_ExamInfoDetail()
    {
        DataSet STD_ExamInfoDetails = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ExamInfoDetail", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamInfoDetails);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamInfoDetails;
        }
    }

    public DataSet   GetAllSTD_ExamInfoDetailsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamInfoDetailsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ExamInfoDetail> GetSTD_ExamInfoDetailsFromReader(IDataReader reader)
    {
        List<STD_ExamInfoDetail> sTD_ExamInfoDetails = new List<STD_ExamInfoDetail>();

        while (reader.Read())
        {
            sTD_ExamInfoDetails.Add(GetSTD_ExamInfoDetailFromReader(reader));
        }
        return sTD_ExamInfoDetails;
    }

    public STD_ExamInfoDetail GetSTD_ExamInfoDetailFromReader(IDataReader reader)
    {
        try
        {
            STD_ExamInfoDetail sTD_ExamInfoDetail = new STD_ExamInfoDetail
                (

                     DataAccessObject.IsNULL<int>(reader["ExamInfoDetailID"]),
                     DataAccessObject.IsNULL<int>(reader["ExamInfoID"]),
                     DataAccessObject.IsNULL<string>(reader["StudentID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<string>(reader["ExamStartTime"]),
                     DataAccessObject.IsNULL<int>(reader["ExamDuration"]),
                     DataAccessObject.IsNULL<DateTime>(reader["ExamDate"]),
                     DataAccessObject.IsNULL<int>(reader["ExamMarks"]),
                     DataAccessObject.IsNULL<float>(reader["ObtainMarks"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );
             return sTD_ExamInfoDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ExamInfoDetail  GetSTD_ExamInfoDetailByExamInfoDetailID(int  examInfoDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoDetailByExamInfoDetailID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamInfoDetailID", SqlDbType.Int).Value = examInfoDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoDetailFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ExamInfoDetail(STD_ExamInfoDetail sTD_ExamInfoDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ExamInfoDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamInfoDetailID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExamInfoID", SqlDbType.Int).Value = sTD_ExamInfoDetail.ExamInfoID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.StudentID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_ExamInfoDetail.SubjectID;
            cmd.Parameters.Add("@ExamStartTime", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExamStartTime;
            cmd.Parameters.Add("@ExamDuration", SqlDbType.Int).Value = sTD_ExamInfoDetail.ExamDuration;
            cmd.Parameters.Add("@ExamDate", SqlDbType.DateTime).Value = sTD_ExamInfoDetail.ExamDate;
            cmd.Parameters.Add("@ExamMarks", SqlDbType.Int).Value = sTD_ExamInfoDetail.ExamMarks;
            cmd.Parameters.Add("@ObtainMarks", SqlDbType.Float).Value = sTD_ExamInfoDetail.ObtainMarks;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ExamInfoDetail.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_ExamInfoDetail.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ExamInfoDetail.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamInfoDetailID"].Value;
        }
    }

    public bool UpdateSTD_ExamInfoDetail(STD_ExamInfoDetail sTD_ExamInfoDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ExamInfoDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamInfoDetailID", SqlDbType.Int).Value = sTD_ExamInfoDetail.ExamInfoDetailID;
            cmd.Parameters.Add("@ExamInfoID", SqlDbType.Int).Value = sTD_ExamInfoDetail.ExamInfoID;
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.StudentID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_ExamInfoDetail.SubjectID;
            cmd.Parameters.Add("@ExamStartTime", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExamStartTime;
            cmd.Parameters.Add("@ExamDuration", SqlDbType.Int).Value = sTD_ExamInfoDetail.ExamDuration;
            cmd.Parameters.Add("@ExamDate", SqlDbType.DateTime).Value = sTD_ExamInfoDetail.ExamDate;
            cmd.Parameters.Add("@ExamMarks", SqlDbType.Int).Value = sTD_ExamInfoDetail.ExamMarks;
            cmd.Parameters.Add("@ObtainMarks", SqlDbType.Float).Value = sTD_ExamInfoDetail.ObtainMarks;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamInfoDetail.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_ExamInfoDetail.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ExamInfoDetail.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ExamInfoDetail(int examInfoDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ExamInfoDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamInfoDetailID", SqlDbType.Int).Value = examInfoDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

