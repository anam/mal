using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ExamInfoProvider:DataAccessObject
{
	public SqlSTD_ExamInfoProvider()
    {
    }


    public DataSet  GetAllSTD_ExamInfos()
    {
        DataSet STD_ExamInfos = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamInfos);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamInfos;
        }
    }
	public DataSet GetSTD_ExamInfoPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ExamInfoPageWise", connection))
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


    public STD_ExamInfo  GetSTD_ExamInfoByCampusID(int  campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamInfo  GetSTD_ExamInfoByBatchID(int  batchID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoByBatchID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BatchID", SqlDbType.NVarChar).Value = batchID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamInfo  GetSTD_ExamInfoBySemesterID(int  semesterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoBySemesterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SemesterID", SqlDbType.NVarChar).Value = semesterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamInfo  GetSTD_ExamInfoBySubjectTeacherID(string  subjectTeacherID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoBySubjectTeacherID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SubjectTeacherID", SqlDbType.NVarChar).Value = subjectTeacherID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamInfo  GetSTD_ExamInfoByExamTypeID(int  examTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoByExamTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamTypeID", SqlDbType.NVarChar).Value = examTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ExamInfo  GetSTD_ExamInfoByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_ExamInfo()
    {
        DataSet STD_ExamInfos = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ExamInfo", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ExamInfos);
            myadapter.Dispose();
            connection.Close();

            return STD_ExamInfos;
        }
    }

    public DataSet   GetAllSTD_ExamInfosWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ExamInfosWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ExamInfo> GetSTD_ExamInfosFromReader(IDataReader reader)
    {
        List<STD_ExamInfo> sTD_ExamInfos = new List<STD_ExamInfo>();

        while (reader.Read())
        {
            sTD_ExamInfos.Add(GetSTD_ExamInfoFromReader(reader));
        }
        return sTD_ExamInfos;
    }

    public STD_ExamInfo GetSTD_ExamInfoFromReader(IDataReader reader)
    {
        try
        {
            STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo
                (

                     DataAccessObject.IsNULL<int>(reader["ExamInfoID"]),
                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<int>(reader["BatchID"]),
                     DataAccessObject.IsNULL<int>(reader["SemesterID"]),
                     DataAccessObject.IsNULL<string>(reader["SubjectTeacherID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["ExamTypeID"]),
                     DataAccessObject.IsNULL<string>(reader["ExamInfoName"]),
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
             return sTD_ExamInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ExamInfo  GetSTD_ExamInfoByExamInfoID(int  examInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ExamInfoByExamInfoID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamInfoID", SqlDbType.Int).Value = examInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ExamInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ExamInfo(STD_ExamInfo sTD_ExamInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ExamInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamInfoID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = sTD_ExamInfo.CampusID;
            cmd.Parameters.Add("@BatchID", SqlDbType.Int).Value = sTD_ExamInfo.BatchID;
            cmd.Parameters.Add("@SemesterID", SqlDbType.Int).Value = sTD_ExamInfo.SemesterID;
            cmd.Parameters.Add("@SubjectTeacherID", SqlDbType.NVarChar).Value = sTD_ExamInfo.SubjectTeacherID;
            cmd.Parameters.Add("@ExamTypeID", SqlDbType.Int).Value = sTD_ExamInfo.ExamTypeID;
            cmd.Parameters.Add("@ExamInfoName", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExamInfoName;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ExamInfo.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ExamInfo.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamInfo.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_ExamInfo.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ExamInfo.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamInfoID"].Value;
        }
    }

    public bool UpdateSTD_ExamInfo(STD_ExamInfo sTD_ExamInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ExamInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamInfoID", SqlDbType.Int).Value = sTD_ExamInfo.ExamInfoID;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = sTD_ExamInfo.CampusID;
            cmd.Parameters.Add("@BatchID", SqlDbType.Int).Value = sTD_ExamInfo.BatchID;
            cmd.Parameters.Add("@SemesterID", SqlDbType.Int).Value = sTD_ExamInfo.SemesterID;
            cmd.Parameters.Add("@SubjectTeacherID", SqlDbType.NVarChar).Value = sTD_ExamInfo.SubjectTeacherID;
            cmd.Parameters.Add("@ExamTypeID", SqlDbType.Int).Value = sTD_ExamInfo.ExamTypeID;
            cmd.Parameters.Add("@ExamInfoName", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExamInfoName;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ExamInfo.ExtraField5;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ExamInfo.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = sTD_ExamInfo.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_ExamInfo.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ExamInfo(int examInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ExamInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamInfoID", SqlDbType.Int).Value = examInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

