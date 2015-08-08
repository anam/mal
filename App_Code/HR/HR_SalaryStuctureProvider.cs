using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_SalaryStuctureProvider:DataAccessObject
{
	public SqlHR_SalaryStuctureProvider()
    {
    }


    public DataSet  GetAllHR_SalaryStuctures()
    {
        DataSet HR_SalaryStuctures = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryStuctures", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryStuctures);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryStuctures;
        }
    }
	public DataSet GetHR_SalaryStucturePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_SalaryStucturePageWise", connection))
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


    public HR_SalaryStucture  GetHR_SalaryStuctureByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryStuctureByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryStuctureFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_SalaryStucture()
    {
        DataSet HR_SalaryStuctures = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_SalaryStuctures", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_SalaryStuctures);
            myadapter.Dispose();
            connection.Close();

            return HR_SalaryStuctures;
        }
    }

    public DataSet   GetAllHR_SalaryStucturesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryStucturesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_SalaryStucture> GetHR_SalaryStucturesFromReader(IDataReader reader)
    {
        List<HR_SalaryStucture> hR_SalaryStuctures = new List<HR_SalaryStucture>();

        while (reader.Read())
        {
            hR_SalaryStuctures.Add(GetHR_SalaryStuctureFromReader(reader));
        }
        return hR_SalaryStuctures;
    }

    public HR_SalaryStucture GetHR_SalaryStuctureFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryStucture hR_SalaryStucture = new HR_SalaryStucture
                (

                     DataAccessObject.IsNULL<int>(reader["SalaryStructureID"]),
                     DataAccessObject.IsNULL<string>(reader["SalaryStuctureName"]),
                     DataAccessObject.IsNULL<decimal>(reader["Basic"]),
                     DataAccessObject.IsNULL<decimal>(reader["HouseRent"]),
                     DataAccessObject.IsNULL<decimal>(reader["Others"]),
                     DataAccessObject.IsNULL<decimal>(reader["Total"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_SalaryStucture;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryStucture  GetHR_SalaryStuctureBySalaryStructureID(int  salaryStructureID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryStuctureBySalaryStructureID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryStructureID", SqlDbType.Int).Value = salaryStructureID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_SalaryStuctureFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_SalaryStucture(HR_SalaryStucture hR_SalaryStucture)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryStucture", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryStructureID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalaryStuctureName", SqlDbType.NVarChar).Value = hR_SalaryStucture.SalaryStuctureName;
            cmd.Parameters.Add("@Basic", SqlDbType.Decimal).Value = hR_SalaryStucture.Basic;
            cmd.Parameters.Add("@HouseRent", SqlDbType.Decimal).Value = hR_SalaryStucture.HouseRent;
            cmd.Parameters.Add("@Others", SqlDbType.Decimal).Value = hR_SalaryStucture.Others;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = hR_SalaryStucture.Total;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryStucture.EmployeeID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_SalaryStucture.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_SalaryStucture.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryStucture.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryStucture.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryStructureID"].Value;
        }
    }

    public bool UpdateHR_SalaryStucture(HR_SalaryStucture hR_SalaryStucture)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryStucture", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryStructureID", SqlDbType.Int).Value = hR_SalaryStucture.SalaryStructureID;
            cmd.Parameters.Add("@SalaryStuctureName", SqlDbType.NVarChar).Value = hR_SalaryStucture.SalaryStuctureName;
            cmd.Parameters.Add("@Basic", SqlDbType.Decimal).Value = hR_SalaryStucture.Basic;
            cmd.Parameters.Add("@HouseRent", SqlDbType.Decimal).Value = hR_SalaryStucture.HouseRent;
            cmd.Parameters.Add("@Others", SqlDbType.Decimal).Value = hR_SalaryStucture.Others;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = hR_SalaryStucture.Total;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryStucture.EmployeeID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryStucture.EmployeeID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_SalaryStucture.EmployeeID;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_SalaryStucture.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_SalaryStucture.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_SalaryStucture(int salaryStructureID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_SalaryStucture", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryStructureID", SqlDbType.Int).Value = salaryStructureID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

