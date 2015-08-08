using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassSubjectEmployeeProvider:DataAccessObject
{
	public SqlSTD_ClassSubjectEmployeeProvider()
    {
    }


    public DataSet  GetAllSTD_ClassSubjectEmployees()
    {
        DataSet STD_ClassSubjectEmployees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassSubjectEmployees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjectEmployees);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjectEmployees;
        }
    }
	public DataSet GetSTD_ClassSubjectEmployeePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeePageWise", connection))
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


    public STD_ClassSubjectEmployee  GetSTD_ClassSubjectEmployeeByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectEmployeeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public STD_ClassSubjectEmployee  GetSTD_ClassSubjectEmployeeByClassSubjectID(int  classSubjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeByClassSubjectID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectID", SqlDbType.NVarChar).Value = classSubjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectEmployeeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetSTD_ClassSubjectEmployeeByClassSubjectID(int classSubjectID,bool isdataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeByClassSubjectID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassSubjectID", classSubjectID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_ClassSubjectEmployee()
    {
        DataSet STD_ClassSubjectEmployees = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassSubjectEmployees", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassSubjectEmployees);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassSubjectEmployees;
        }
    }

    public DataSet   GetAllSTD_QuestionAnswersWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_QuestionAnswersWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ClassSubjectEmployee> GetSTD_ClassSubjectEmployeesFromReader(IDataReader reader)
    {
        List<STD_ClassSubjectEmployee> sTD_ClassSubjectEmployees = new List<STD_ClassSubjectEmployee>();

        while (reader.Read())
        {
            sTD_ClassSubjectEmployees.Add(GetSTD_ClassSubjectEmployeeFromReader(reader));
        }
        return sTD_ClassSubjectEmployees;
    }

    public STD_ClassSubjectEmployee GetSTD_ClassSubjectEmployeeFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee
                (

                     DataAccessObject.IsNULL<int>(reader["ClassSubjectEmployeeID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassSubjectEmployeeName"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["ClassSubjectID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_ClassSubjectEmployee;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ClassSubjectEmployee  GetSTD_ClassSubjectEmployeeByClassSubjectEmployeeID(int  classSubjectEmployeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassSubjectEmployeeByClassSubjectEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassSubjectEmployeeID", SqlDbType.Int).Value = classSubjectEmployeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassSubjectEmployeeFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ClassSubjectEmployee(STD_ClassSubjectEmployee sTD_ClassSubjectEmployee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassSubjectEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectEmployeeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassSubjectEmployeeName", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployee.ClassSubjectEmployeeName;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployee.EmployeeID;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_ClassSubjectEmployee.ClassSubjectID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployee.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassSubjectEmployee.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployee.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassSubjectEmployee.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassSubjectEmployeeID"].Value;
        }
    }

    public bool UpdateSTD_ClassSubjectEmployee(STD_ClassSubjectEmployee sTD_ClassSubjectEmployee)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassSubjectEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectEmployeeID", SqlDbType.Int).Value = sTD_ClassSubjectEmployee.ClassSubjectEmployeeID;
            cmd.Parameters.Add("@ClassSubjectEmployeeName", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployee.ClassSubjectEmployeeName;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployee.EmployeeID;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_ClassSubjectEmployee.ClassSubjectID;
            //cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_ClassSubjectEmployee.ClassSubjectID;
            //cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = sTD_ClassSubjectEmployee.ClassSubjectID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassSubjectEmployee.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassSubjectEmployee.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ClassSubjectEmployee(int classSubjectEmployeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectEmployee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectEmployeeID", SqlDbType.Int).Value = classSubjectEmployeeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteSTD_ClassSubjectEmployeeByClassSubjectID(int classSubjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectEmployeeByClassSubjectID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassSubjectID", SqlDbType.Int).Value = classSubjectID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteSTD_ClassSubjectEmployeeByClassID(int ClassID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassSubjectEmployeeByClassID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = ClassID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

