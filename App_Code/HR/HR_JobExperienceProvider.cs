using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_JobExperienceProvider:DataAccessObject
{
	public SqlHR_JobExperienceProvider()
    {
    }


    public DataSet  GetAllHR_JobExperiences()
    {
        DataSet HR_JobExperiences = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_JobExperiences", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobExperiences);
            myadapter.Dispose();
            connection.Close();

            return HR_JobExperiences;
        }
    }

    //

    public DataSet GetHR_JobExperienceByEmployeeID(string EmployeeID)
    {
        DataSet HR_JobExperiences = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_JobExperienceByEmployeeID", connection);
            command.Parameters.AddWithValue("@UserID", EmployeeID);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobExperiences);
            myadapter.Dispose();
            connection.Close();

            return HR_JobExperiences;
        }
    }
	public DataSet GetHR_JobExperiencePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_JobExperiencePageWise", connection))
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




    public DataSet  GetDropDownLisAllHR_JobExperience()
    {
        DataSet HR_JobExperiences = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_JobExperience", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_JobExperiences);
            myadapter.Dispose();
            connection.Close();

            return HR_JobExperiences;
        }
    }

    public DataSet   GetAllHR_JobExperiencesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_JobExperiencesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_JobExperience> GetHR_JobExperiencesFromReader(IDataReader reader)
    {
        List<HR_JobExperience> hR_JobExperiences = new List<HR_JobExperience>();

        while (reader.Read())
        {
            hR_JobExperiences.Add(GetHR_JobExperienceFromReader(reader));
        }
        return hR_JobExperiences;
    }

    public HR_JobExperience GetHR_JobExperienceFromReader(IDataReader reader)
    {
        try
        {
            HR_JobExperience hR_JobExperience = new HR_JobExperience
                (

                     DataAccessObject.IsNULL<int>(reader["JobExperienceID"]),
                     DataAccessObject.IsNULL<string>(reader["userID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["Organization"]),
                     DataAccessObject.IsNULL<string>(reader["Position"]),
                     DataAccessObject.IsNULL<string>(reader["NatureofWork"]),
                     DataAccessObject.IsNULL<DateTime>(reader["YearStart"]),
                     DataAccessObject.IsNULL<DateTime>(reader["YearEnd"]),
                     DataAccessObject.IsNULL<string>(reader["ReasonForLeaving"]),
                     DataAccessObject.IsNULL<string>(reader["ContactPerson"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
             return hR_JobExperience;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public HR_JobExperience  GetHR_JobExperienceByJobExperienceID(int  jobExperienceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_JobExperienceByJobExperienceID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobExperienceID", SqlDbType.Int).Value = jobExperienceID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetHR_JobExperienceFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertHR_JobExperience(HR_JobExperience hR_JobExperience)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_JobExperience", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobExperienceID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@userID", SqlDbType.NVarChar).Value = hR_JobExperience.userID;
            cmd.Parameters.Add("@OrganizationName", SqlDbType.NVarChar).Value = hR_JobExperience.Organization;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = hR_JobExperience.Position;
            cmd.Parameters.Add("@NatureofWork", SqlDbType.NVarChar).Value = hR_JobExperience.NatureofWork;
            cmd.Parameters.Add("@DateStart", SqlDbType.DateTime).Value = hR_JobExperience.YearStart;
            cmd.Parameters.Add("@DateEnds", SqlDbType.DateTime).Value = hR_JobExperience.YearEnd;
            cmd.Parameters.Add("@Duration", SqlDbType.Decimal).Value = 0.00;
            cmd.Parameters.Add("@ReasionForLeaving", SqlDbType.NVarChar).Value = hR_JobExperience.ReasonForLeaving;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = hR_JobExperience.ContactPerson;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_JobExperience.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_JobExperience.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_JobExperience.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_JobExperience.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobExperienceID"].Value;
        }
    }

    public bool UpdateHR_JobExperience(HR_JobExperience hR_JobExperience)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_JobExperience", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobExperienceID", SqlDbType.Int).Value = hR_JobExperience.JobExperienceID;
            cmd.Parameters.Add("@userID", SqlDbType.NVarChar).Value = hR_JobExperience.userID;
            cmd.Parameters.Add("@OrganizationName", SqlDbType.NVarChar).Value = hR_JobExperience.Organization;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = hR_JobExperience.Position;
            cmd.Parameters.Add("@NatureofWork", SqlDbType.NVarChar).Value = hR_JobExperience.NatureofWork;
            cmd.Parameters.Add("@DateStart", SqlDbType.DateTime).Value = hR_JobExperience.YearStart;
            cmd.Parameters.Add("@DateEnds", SqlDbType.DateTime).Value = hR_JobExperience.YearEnd;
            cmd.Parameters.Add("@Duration", SqlDbType.Decimal).Value = 0.00;
            cmd.Parameters.Add("@ReasionForLeaving", SqlDbType.NVarChar).Value = hR_JobExperience.ReasonForLeaving;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = hR_JobExperience.ContactPerson;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_JobExperience.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_JobExperience.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_JobExperience(int jobExperienceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_JobExperience", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobExperienceID", SqlDbType.Int).Value = jobExperienceID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

