using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_EducatinalBackgroundProvider:DataAccessObject
{
	public SqlHR_EducatinalBackgroundProvider()
    {
    }


    public DataSet  GetAllHR_EducatinalBackgrounds()
    {
        DataSet HR_EducatinalBackgrounds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EducatinalBackgrounds", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EducatinalBackgrounds);
            myadapter.Dispose();
            connection.Close();

            return HR_EducatinalBackgrounds;
        }
    }
	public DataSet GetHR_EducatinalBackgroundPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_EducatinalBackgroundPageWise", connection))
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


    public HR_EducatinalBackground  GetHR_EducatinalBackgroundByEmployeeID(string  employeeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EducatinalBackgroundByEmployeeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EducatinalBackgroundFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_EducatinalBackground  GetHR_EducatinalBackgroundByYearID(int  yearID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EducatinalBackgroundByYearID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@YearID", SqlDbType.NVarChar).Value = yearID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EducatinalBackgroundFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_EducatinalBackground  GetHR_EducatinalBackgroundByBoardUniversityID(int  boardUniversityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EducatinalBackgroundByBoardUniversityID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BoardUniversityID", SqlDbType.NVarChar).Value = boardUniversityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EducatinalBackgroundFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_EducatinalBackground  GetHR_EducatinalBackgroundByEducationGroupID(int  educationGroupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EducatinalBackgroundByEducationGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EducationGroupID", SqlDbType.NVarChar).Value = educationGroupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EducatinalBackgroundFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public HR_EducatinalBackground  GetHR_EducatinalBackgroundByReaultSystemID(int  reaultSystemID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EducatinalBackgroundByReaultSystemID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReaultSystemID", SqlDbType.NVarChar).Value = reaultSystemID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EducatinalBackgroundFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllHR_EducatinalBackground()
    {
        DataSet HR_EducatinalBackgrounds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_EducatinalBackgrounds", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_EducatinalBackgrounds);
            myadapter.Dispose();
            connection.Close();

            return HR_EducatinalBackgrounds;
        }
    }

    public DataSet   GetAllHR_EducatinalBackgroundsWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_EducatinalBackgroundsWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_EducatinalBackground> GetHR_EducatinalBackgroundsFromReader(IDataReader reader)
    {
        List<HR_EducatinalBackground> hR_EducatinalBackgrounds = new List<HR_EducatinalBackground>();

        while (reader.Read())
        {
            hR_EducatinalBackgrounds.Add(GetHR_EducatinalBackgroundFromReader(reader));
        }
        return hR_EducatinalBackgrounds;
    }

    public HR_EducatinalBackground GetHR_EducatinalBackgroundFromReader(IDataReader reader)
    {
        try
        {
            HR_EducatinalBackground hR_EducatinalBackground = new HR_EducatinalBackground
                (

                     DataAccessObject.IsNULL<int>(reader["EducationalBacgroundID"]),
                     DataAccessObject.IsNULL<string>(reader["EmployeeID"].ToString()),
                     DataAccessObject.IsNULL<int>(reader["YearID"]),
                     DataAccessObject.IsNULL<int>(reader["BoardUniversityID"]),
                     DataAccessObject.IsNULL<int>(reader["EducationGroupID"]),
                     DataAccessObject.IsNULL<string>(reader["Major"]),
                     DataAccessObject.IsNULL<int>(reader["ReaultSystemID"]),
                     DataAccessObject.IsNULL<string>(reader["Degree"]),
                     DataAccessObject.IsNULL<string>(reader["Result"]),
                     DataAccessObject.IsNULL<decimal>(reader["Score"]),
                     DataAccessObject.IsNULL<int>(reader["OutOf"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_EducatinalBackground;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_EducatinalBackground  GetHR_EducatinalBackgroundByEducationalBacgroundID(int  educationalBacgroundID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_EducatinalBackgroundByEducationalBacgroundID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EducationalBacgroundID", SqlDbType.Int).Value = educationalBacgroundID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_EducatinalBackgroundFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_EducatinalBackground(HR_EducatinalBackground hR_EducatinalBackground)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_EducatinalBackground", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EducationalBacgroundID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_EducatinalBackground.EmployeeID;
            cmd.Parameters.Add("@YearID", SqlDbType.Int).Value = hR_EducatinalBackground.YearID;
            cmd.Parameters.Add("@BoardUniversityID", SqlDbType.Int).Value = hR_EducatinalBackground.BoardUniversityID;
            cmd.Parameters.Add("@EducationGroupID", SqlDbType.Int).Value = hR_EducatinalBackground.EducationGroupID;
            cmd.Parameters.Add("@Major", SqlDbType.NVarChar).Value = hR_EducatinalBackground.Major;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = hR_EducatinalBackground.ReaultSystemID;
            cmd.Parameters.Add("@Degree", SqlDbType.NVarChar).Value = hR_EducatinalBackground.Degree;
            cmd.Parameters.Add("@Result", SqlDbType.NVarChar).Value = hR_EducatinalBackground.Result;
            cmd.Parameters.Add("@Score", SqlDbType.Decimal).Value = hR_EducatinalBackground.Score;
            cmd.Parameters.Add("@OutOf", SqlDbType.Int).Value = hR_EducatinalBackground.OutOf;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_EducatinalBackground.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_EducatinalBackground.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EducatinalBackground.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EducatinalBackground.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EducationalBacgroundID"].Value;
        }
    }

    public bool UpdateHR_EducatinalBackground(HR_EducatinalBackground hR_EducatinalBackground)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_EducatinalBackground", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EducationalBacgroundID", SqlDbType.Int).Value = hR_EducatinalBackground.EducationalBacgroundID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = hR_EducatinalBackground.EmployeeID;
            cmd.Parameters.Add("@YearID", SqlDbType.Int).Value = hR_EducatinalBackground.YearID;
            cmd.Parameters.Add("@BoardUniversityID", SqlDbType.Int).Value = hR_EducatinalBackground.BoardUniversityID;
            cmd.Parameters.Add("@EducationGroupID", SqlDbType.Int).Value = hR_EducatinalBackground.EducationGroupID;
            cmd.Parameters.Add("@Major", SqlDbType.NVarChar).Value = hR_EducatinalBackground.Major;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = hR_EducatinalBackground.ReaultSystemID;
            cmd.Parameters.Add("@Degree", SqlDbType.NVarChar).Value = hR_EducatinalBackground.Degree;
            cmd.Parameters.Add("@Result", SqlDbType.NVarChar).Value = hR_EducatinalBackground.Result;
            cmd.Parameters.Add("@Score", SqlDbType.Decimal).Value = hR_EducatinalBackground.Score;
            cmd.Parameters.Add("@OutOf", SqlDbType.Int).Value = hR_EducatinalBackground.OutOf;
            cmd.Parameters.Add("@OutOf", SqlDbType.Int).Value = hR_EducatinalBackground.OutOf;
            cmd.Parameters.Add("@OutOf", SqlDbType.Int).Value = hR_EducatinalBackground.OutOf;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_EducatinalBackground.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_EducatinalBackground.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_EducatinalBackground(int educationalBacgroundID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_EducatinalBackground", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EducationalBacgroundID", SqlDbType.Int).Value = educationalBacgroundID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

