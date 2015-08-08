using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassSubjectProvider:DataAccessObject
{
	public SqlSTD_ClassSubjectProvider()
    {
    }


    public DataSet  GetAllSTD_ClassSubjects()
    {
        DataSet STD_ClassSubjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassSubjects", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjects);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjects;
        }
    }
	public DataSet GetSTD_ClassSubjectPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectPageWise", connection))
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


    public DataSet GetSTD_ClassSubjectBySubjectID(int subjectID,bool isDataset)
    {

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectBySubjectID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SubjectID", subjectID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }


    }

    public STD_ClassSubject GetSTD_ClassSubjectBySubjectID(int subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectBySubjectIDnClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SubjectID", subjectID);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_ClassSubjectFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public STD_ClassSubject GetSTD_ClassSubjectBySubjectIDnClassID(int subjectID,int classID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectBySubjectIDnClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SubjectID", subjectID);
            command.Parameters.AddWithValue("@ClassID", classID);
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public List<STD_ClassSubject> GetSTD_ClassSubjectByClassID(int classID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectByClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetSTD_ClassSubjectsFromReader(reader);
        }

    }

    public DataSet GetSTD_ClassSubjectByClassID(int classID,bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectByClassID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassID", classID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }

    }

    public DataSet GetSTD_ClassSubjectByClassIDTeacherAdd(int classID, bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectByClassIDTeacherAdd", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassID", classID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }

    }


    public DataSet GetSTD_ClassSubjectByClassIDnStudentID(int classID, string studentID, bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectByClassIDnStudentID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassID", classID);
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

    public DataSet GetSTD_ClassSubjectEmployeeByClassID(int classID, bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeByClassID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassID", classID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }

    }

    public DataSet GetSTD_ClassSubjectStudentByClassID(int classID, bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectStudentByClassID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassID", classID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }

    }

    public DataSet  GetDropDownListAllSTD_ClassSubject()
    {
        DataSet STD_ClassSubjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassSubjects", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjects);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjects;
        }
    }

    public DataSet GetDropDownListAllSTD_ClassSubject_NotFinished()
    {
        DataSet STD_ClassSubjects = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassSubjects_NotFinished", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjects);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjects;
        }
    }

    public DataSet   GetAllSTD_ClassSubjectsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassSubjectsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ClassSubject> GetSTD_ClassSubjectsFromReader(IDataReader reader)
    {
        List<STD_ClassSubject> sTD_ClassSubjects = new List<STD_ClassSubject>();

        while (reader.Read())
        {
            sTD_ClassSubjects.Add(GetSTD_ClassSubjectFromReader(reader));
        }
        return sTD_ClassSubjects;
    }

    public STD_ClassSubject GetSTD_ClassSubjectFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject
                (

                     DataAccessObject.IsNULL<int>(reader["ClassSubjectID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassSubjectName"]),
                     DataAccessObject.IsNULL<int>(reader["SubjectID"]),
                     DataAccessObject.IsNULL<int>(reader["ClassID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
            try
            {
                sTD_ClassSubject.SubjectName = DataAccessObject.IsNULL<string>(reader["SubjectName"].ToString());
            }
            catch (Exception ex)
            {
            }

            try
            {
                sTD_ClassSubject.ExtraField1 = DataAccessObject.IsNULL<string>(reader["ExtraField1"].ToString());
            }
            catch (Exception ex)
            {
            }

            try
            {
                sTD_ClassSubject.ExtraField2 = DataAccessObject.IsNULL<string>(reader["ExtraField2"].ToString());
            }
            catch (Exception ex)
            {
            }

            try
            {
                sTD_ClassSubject.ExtraField3 = DataAccessObject.IsNULL<string>(reader["ExtraField3"].ToString());
            }
            catch (Exception ex)
            {
            }

            try
            {
                sTD_ClassSubject.ExtraField4 = DataAccessObject.IsNULL<string>(reader["ExtraField4"].ToString());
            }
            catch (Exception ex)
            {
            }

            try
            {
                sTD_ClassSubject.ExtraField5 = DataAccessObject.IsNULL<string>(reader["ExtraField5"].ToString());
            }
            catch (Exception ex)
            {
            }
            try
            {
                sTD_ClassSubject.RowStatusID = int.Parse(reader["RowStatusID"].ToString());
            }
            catch (Exception ex)
            {
            }

             return sTD_ClassSubject;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ClassSubject  GetSTD_ClassSubjectByClassSubjectID(int  classSubjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectByClassSubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = classSubjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ClassSubject(STD_ClassSubject sTD_ClassSubject)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassSubject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassSubjectName", SqlDbType.NVarChar).Value = sTD_ClassSubject.ClassSubjectName;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_ClassSubject.SubjectID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_ClassSubject.ClassID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassSubject.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassSubject.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassSubject.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassSubject.UpdateDate;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField1 == null ? "" : sTD_ClassSubject.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField2 == null ? "" : sTD_ClassSubject.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField3 == null ? "" : sTD_ClassSubject.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField4 == null ? "" : sTD_ClassSubject.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField5 == null ? "" : sTD_ClassSubject.ExtraField5;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassSubjectID"].Value;
        }
    }

    public bool UpdateSTD_ClassSubject(STD_ClassSubject sTD_ClassSubject)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassSubject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_ClassSubject.ClassSubjectID;
            cmd.Parameters.Add("@ClassSubjectName", SqlDbType.NVarChar).Value = sTD_ClassSubject.ClassSubjectName;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = sTD_ClassSubject.SubjectID;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_ClassSubject.ClassID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassSubject.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassSubject.UpdateDate;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField1 == null ? "" : sTD_ClassSubject.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField2 == null ? "" : sTD_ClassSubject.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField3 == null ? "" : sTD_ClassSubject.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField4 == null ? "" : sTD_ClassSubject.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_ClassSubject.ExtraField5 == null ? "" : sTD_ClassSubject.ExtraField5;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ClassSubject(int classSubjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = classSubjectID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool CloseSTD_ClassSubject(int classSubjectID,string updatedBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CloseSTD_ClassSubject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = classSubjectID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = updatedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public bool UndoCloseSTD_ClassSubject(int classSubjectID, string updatedBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UndoCloseSTD_ClassSubject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = classSubjectID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = updatedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public bool DeleteSTD_ClassSubjectByClassID(int classID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectByClassID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteSTD_ClassSubjectByClassIDnSubjectID(int classID,int subjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectByClassIDnSubjectID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

