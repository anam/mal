using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_YearProvider:DataAccessObject
{
	public SqlHR_YearProvider()
    {
    }


    public DataSet  GetAllHR_Years()
    {
        DataSet HR_Years = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_Years", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Years);
            myadapter.Dispose();
            connection.Close();

            return HR_Years;
        }
    }
	public DataSet GetHR_YearPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_YearPageWise", connection))
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


    public DataSet  GetDropDownListAllHR_Year()
    {
        DataSet HR_Years = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_Years", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_Years);
            myadapter.Dispose();
            connection.Close();

            return HR_Years;
        }
    }

    public DataSet   GetAllHR_LeaveRulesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_LeaveRulesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_Year> GetHR_YearsFromReader(IDataReader reader)
    {
        List<HR_Year> hR_Years = new List<HR_Year>();

        while (reader.Read())
        {
            hR_Years.Add(GetHR_YearFromReader(reader));
        }
        return hR_Years;
    }

    public HR_Year GetHR_YearFromReader(IDataReader reader)
    {
        try
        {
            HR_Year hR_Year = new HR_Year
                (

                     DataAccessObject.IsNULL<int>(reader["YearID"]),
                     DataAccessObject.IsNULL<DateTime>(reader["YearStart"]),
                     DataAccessObject.IsNULL<DateTime>(reader["YearEnd"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_Year;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_Year  GetHR_YearByYearID(int  yearID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_YearByYearID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@YearID", SqlDbType.Int).Value = yearID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_YearFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_Year(HR_Year hR_Year)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_Year", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@YearID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@YearStart", SqlDbType.DateTime).Value = hR_Year.YearStart;
            cmd.Parameters.Add("@YearEnd", SqlDbType.DateTime).Value = hR_Year.YearEnd;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_Year.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_Year.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Year.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Year.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@YearID"].Value;
        }
    }

    public bool UpdateHR_Year(HR_Year hR_Year)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_Year", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@YearID", SqlDbType.Int).Value = hR_Year.YearID;
            cmd.Parameters.Add("@YearStart", SqlDbType.DateTime).Value = hR_Year.YearStart;
            cmd.Parameters.Add("@YearEnd", SqlDbType.DateTime).Value = hR_Year.YearEnd;
            cmd.Parameters.Add("@YearEnd", SqlDbType.DateTime).Value = hR_Year.YearEnd;
            cmd.Parameters.Add("@YearEnd", SqlDbType.DateTime).Value = hR_Year.YearEnd;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_Year.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_Year.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_Year(int yearID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_Year", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@YearID", SqlDbType.Int).Value = yearID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

