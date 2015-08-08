using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassProvider : DataAccessObject
{
    public SqlSTD_ClassProvider()
    {
    }


    public DataSet GetAllSTD_Classs()
    {
        DataSet STD_Classs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Classs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Classs);
            myadapter.Dispose();
            connection.Close();

            return STD_Classs;
        }
    }
    public DataSet GetSTD_ClassPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassPageWise", connection))
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

    public DataSet GetSTD_ClassPageWiseSearch(int pageIndex, int PageSize, out int recordCount, string SearchText)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassPageWiseSearch", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
                command.Parameters.AddWithValue("@SearchText", SearchText);
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

    public DataSet GetSTD_ClassPageWiseByClass(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassPageWiseByClass", connection))
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

    public DataSet GetSTD_ClassStudentPageWiseByClass(int pageIndex, int PageSize, out int recordCount)
    {

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassStudentPageWiseByClass", connection))
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


    public DataSet GetSTD_ClassPageWiseByClassTeacher(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassPageWiseByClassTeacher", connection))
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


    public DataSet GetSTD_ClassPageWiseByClassStudent(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassPageWiseByClassStudent", connection))
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

    
    

    public STD_Class GetSTD_ClassByCourseID(int courseID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassByCourseID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CourseID", SqlDbType.NVarChar).Value = courseID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_ClassFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public STD_Class GetSTD_ClassByClassTypeID(int classTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassByClassTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassTypeID", SqlDbType.NVarChar).Value = classTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_ClassFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public STD_Class GetSTD_ClassByClassStatusID(int classStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassByClassStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassStatusID", SqlDbType.NVarChar).Value = classStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_ClassFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetDropDownListAllSTD_Class()
    {
        DataSet STD_Classs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Class", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Classs);
            myadapter.Dispose();
            connection.Close();

            return STD_Classs;
        }
    }

    public DataSet GetDropDownListAllSTD_ClassWithHistory()
    {
        DataSet STD_Classs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassWithHistory", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Classs);
            myadapter.Dispose();
            connection.Close();

            return STD_Classs;
        }
    }

    public DataSet GetDropDownListAllSTD_ClassStudent()
    {
        DataSet STD_Classs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Classs);
            myadapter.Dispose();
            connection.Close();

            return STD_Classs;
        }
    }


    public DataSet GetAllSTD_ClasssWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClasssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Class> GetSTD_ClasssFromReader(IDataReader reader)
    {
        List<STD_Class> sTD_Classs = new List<STD_Class>();

        while (reader.Read())
        {
            sTD_Classs.Add(GetSTD_ClassFromReader(reader));
        }
        return sTD_Classs;
    }

    public STD_Class GetSTD_ClassFromReader(IDataReader reader)
    {
        try
        {
            STD_Class sTD_Class = new STD_Class
                (

                     DataAccessObject.IsNULL<int>(reader["ClassID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassName"]),
                     DataAccessObject.IsNULL<int>(reader["CourseID"]),
                     DataAccessObject.IsNULL<int>(reader["ClassTypeID"]),
                     DataAccessObject.IsNULL<int>(reader["ClassStatusID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                    
                );
            try
            {
                sTD_Class.CourseName = DataAccessObject.IsNULL<string>(reader["CourseName"]);
                sTD_Class.ClassTypeName = DataAccessObject.IsNULL<string>(reader["ClassTypeName"]);
                sTD_Class.ClassStatusName = DataAccessObject.IsNULL<string>(reader["ClassStatusName"]);
            }
            catch (Exception ex)
            { }
            try
            {
                sTD_Class.RowStatusID = int.Parse(reader["RowStatusID"].ToString());
            }
            catch (Exception ex)
            { }

            return sTD_Class;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<STD_Class> GetSTD_ClasssFromReader1(IDataReader reader)
    {
        List<STD_Class> sTD_Classs = new List<STD_Class>();

        while (reader.Read())
        {
            sTD_Classs.Add(GetSTD_ClassFromReader1(reader));
        }
        return sTD_Classs;
    }

    public STD_Class GetSTD_ClassFromReader1(IDataReader reader)
    {
        try
        {
            STD_Class sTD_Class = new STD_Class
                (                   
                     DataAccessObject.IsNULL<string>(reader["ClassName"]),
                     DataAccessObject.IsNULL<string>(reader["CourseName"]),
                     DataAccessObject.IsNULL<string>(reader["SubjectName"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeName"])                    
                );
            try
            {
                sTD_Class.ClassID =DataAccessObject.IsNULL<int>(reader["ClassID"]);
            }
            catch (Exception ex)
            {  
            }

            try
            {
                sTD_Class.CourseID = DataAccessObject.IsNULL<int>(reader["CourseID"]);
            }
            catch (Exception ex)
            {  
            }

            try
            {
                sTD_Class.SubjectID = DataAccessObject.IsNULL<int>(reader["SubjectID"]);
            }
            catch (Exception ex)
            {  
            }


            try
            {
                sTD_Class.EmployeeID = (DataAccessObject.IsNULL<Guid>(reader["EmployeeID"])).ToString();
            }
            catch (Exception ex)
            {  
            }

            return sTD_Class;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public STD_Class GetSTD_ClassByClassID(int classID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassByClassID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_ClassFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public DataSet GetSTD_ClassByStudentID(string studentID)
    {

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassByStudentID", connection))
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

    public int InsertSTD_Class(STD_Class sTD_Class)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Class", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = sTD_Class.ClassName;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Class.CourseID;
            cmd.Parameters.Add("@ClassTypeID", SqlDbType.Int).Value = sTD_Class.ClassTypeID;
            cmd.Parameters.Add("@ClassStatusID", SqlDbType.Int).Value = sTD_Class.ClassStatusID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Class.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Class.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Class.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Class.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassID"].Value;
        }
    }

    public bool UpdateSTD_Class(STD_Class sTD_Class)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Class", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = sTD_Class.ClassID;
            cmd.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = sTD_Class.ClassName;
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = sTD_Class.CourseID;
            cmd.Parameters.Add("@ClassTypeID", SqlDbType.Int).Value = sTD_Class.ClassTypeID;
            cmd.Parameters.Add("@ClassStatusID", SqlDbType.Int).Value = sTD_Class.ClassStatusID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Class.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Class.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Class.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Class.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Class(int classID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Class", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool HistorySTD_Class(int classID,string updatedBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HistorySTD_Class", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = updatedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public bool UndoCloseSTD_Class(int classID, string updatedBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UndoCloseSTD_Class", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = updatedBy;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }


    public STD_Class GetSTD_BasicInfoForStudentsAttentdant(int classID,int subjectID, string employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_BasicInfoForStudentsAttentdant", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassID", SqlDbType.Int).Value = classID;
            command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectID;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_ClassFromReader1(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public List<STD_Class> GetSTD_BasicInfoForStudentsAttentdantByStudentID(string studentID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_BasicInfoForStudentsAttentdantByStudentID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentID", SqlDbType.NVarChar).Value = studentID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);
            return GetSTD_ClasssFromReader1(reader);
            
        }
    }
}

