using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ChildrenInfoProvider:DataAccessObject
{
	public SqlHR_ChildrenInfoProvider()
    {
    }


    public DataSet  GetAllHR_ChildrenInfos()
    {
        DataSet HR_ChildrenInfos = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ChildrenInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ChildrenInfos);
            myadapter.Dispose();
            connection.Close();

            return HR_ChildrenInfos;
        }
    }
	public DataSet GetHR_ChildrenInfoPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_ChildrenInfoPageWise", connection))
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


    public HR_ChildrenInfo  GetHR_ChildrenInfoByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ChildrenInfoByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ChildrenInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllHR_ChildrenInfo()
    {
        DataSet HR_ChildrenInfos = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_ChildrenInfo", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ChildrenInfos);
            myadapter.Dispose();
            connection.Close();

            return HR_ChildrenInfos;
        }
    }

    public DataSet   GetAllHR_ChildrenInfosWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ChildrenInfosWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_ChildrenInfo> GetHR_ChildrenInfosFromReader(IDataReader reader)
    {
        List<HR_ChildrenInfo> hR_ChildrenInfos = new List<HR_ChildrenInfo>();

        while (reader.Read())
        {
            hR_ChildrenInfos.Add(GetHR_ChildrenInfoFromReader(reader));
        }
        return hR_ChildrenInfos;
    }

    public HR_ChildrenInfo GetHR_ChildrenInfoFromReader(IDataReader reader)
    {
        try
        {
            HR_ChildrenInfo hR_ChildrenInfo = new HR_ChildrenInfo
                (

                     DataAccessObject.IsNULL<int>(reader["ChildrenInfoID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["ChildrenInfoName"]),
                     DataAccessObject.IsNULL<string>(reader["ChildrenDateOfBirth"]),
                     DataAccessObject.IsNULL<string>(reader["Sex"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_ChildrenInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_ChildrenInfo  GetHR_ChildrenInfoByChildrenInfoID(int  childrenInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ChildrenInfoByChildrenInfoID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ChildrenInfoID", SqlDbType.Int).Value = childrenInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_ChildrenInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_ChildrenInfo(HR_ChildrenInfo hR_ChildrenInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_ChildrenInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChildrenInfoID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ChildrenInfo.EmployeeID;
            cmd.Parameters.Add("@ChildrenInfoName", SqlDbType.NVarChar).Value = hR_ChildrenInfo.ChildrenInfoName;
            cmd.Parameters.Add("@ChildrenDateOfBirth", SqlDbType.NVarChar).Value = hR_ChildrenInfo.ChildrenDateOfBirth;
            cmd.Parameters.Add("@Sex", SqlDbType.NVarChar).Value = hR_ChildrenInfo.Sex;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ChildrenInfo.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ChildrenInfo.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ChildrenInfo.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ChildrenInfo.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ChildrenInfoID"].Value;
        }
    }

    public bool UpdateHR_ChildrenInfo(HR_ChildrenInfo hR_ChildrenInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_ChildrenInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChildrenInfoID", SqlDbType.Int).Value = hR_ChildrenInfo.ChildrenInfoID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_ChildrenInfo.EmployeeID;
            cmd.Parameters.Add("@ChildrenInfoName", SqlDbType.NVarChar).Value = hR_ChildrenInfo.ChildrenInfoName;
            cmd.Parameters.Add("@ChildrenDateOfBirth", SqlDbType.NVarChar).Value = hR_ChildrenInfo.ChildrenDateOfBirth;
            cmd.Parameters.Add("@Sex", SqlDbType.NVarChar).Value = hR_ChildrenInfo.Sex;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ChildrenInfo.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ChildrenInfo.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_ChildrenInfo(int childrenInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_ChildrenInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChildrenInfoID", SqlDbType.Int).Value = childrenInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<HR_ChildrenInfo> GetHR_ChildrenInfosByEmployeeID(string employeeID)
    {
        List<HR_ChildrenInfo> HR_ChildrenInfos = new List<HR_ChildrenInfo>();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ChildrenInfoByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetHR_ChildrenInfosFromReader(reader);
        }
    }
}

