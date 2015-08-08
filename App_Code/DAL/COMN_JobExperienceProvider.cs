using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_JobExperienceProvider:DataAccessObject
{
	public SqlCOMN_JobExperienceProvider()
    {
    }


    public DataSet  GetAllCOMN_JobExperiences()
    {
        DataSet COMN_JobExperiences = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_JobExperiences", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_JobExperiences);
            myadapter.Dispose();
            connection.Close();

            return COMN_JobExperiences;
        }
    }
	public DataSet GetCOMN_JobExperiencePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_JobExperiencePageWise", connection))
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


    public COMN_JobExperience  GetCOMN_JobExperienceByUserID(string  userID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_JobExperienceByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_JobExperienceFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet GetCOMN_JobExperienceByUserID(string userID, bool isDataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("GetCOMN_JobExperienceByUserID", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }


    public COMN_JobExperience  GetCOMN_JobExperienceByDesignationID(int  designationID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_JobExperienceByDesignationID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DesignationID", SqlDbType.NVarChar).Value = designationID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_JobExperienceFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllCOMN_JobExperience()
    {
        DataSet COMN_JobExperiences = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_JobExperiences", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_JobExperiences);
            myadapter.Dispose();
            connection.Close();

            return COMN_JobExperiences;
        }
    }

    public DataSet   GetAllCOMN_CitiesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_CitiesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<COMN_JobExperience> GetCOMN_JobExperiencesFromReader(IDataReader reader)
    {
        List<COMN_JobExperience> cOMN_JobExperiences = new List<COMN_JobExperience>();

        while (reader.Read())
        {
            cOMN_JobExperiences.Add(GetCOMN_JobExperienceFromReader(reader));
        }
        return cOMN_JobExperiences;
    }

    public COMN_JobExperience GetCOMN_JobExperienceFromReader(IDataReader reader)
    {
        try
        {
            COMN_JobExperience cOMN_JobExperience = new COMN_JobExperience
                (

                     DataAccessObject.IsNULL<int>(reader["JobExperienceID"]),
                     DataAccessObject.IsNULL<string>(reader["UserID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["OrganizationName"]),
                     DataAccessObject.IsNULL<string>(reader["Designation"]),
                     DataAccessObject.IsNULL<string>(reader["NatureofWork"]),
                     DataAccessObject.IsNULL<DateTime>(reader["DateStart"]),
                     DataAccessObject.IsNULL<DateTime>(reader["DateEnds"]),
                     DataAccessObject.IsNULL<decimal>(reader["Duration"]),
                     DataAccessObject.IsNULL<string>(reader["ReasionForLeaving"]),
                     DataAccessObject.IsNULL<string>(reader["Contact"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
            try
            {
                cOMN_JobExperience.StudentName = DataAccessObject.IsNULL<string>(reader["StudentName"].ToString());
            }
            catch (Exception ex)
            {
            }
             return cOMN_JobExperience;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_JobExperience  GetCOMN_JobExperienceByJobExperienceID(int  jobExperienceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_JobExperienceByJobExperienceID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobExperienceID", SqlDbType.Int).Value = jobExperienceID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_JobExperienceFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_JobExperience(COMN_JobExperience cOMN_JobExperience)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_JobExperience", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobExperienceID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = cOMN_JobExperience.UserID;
            cmd.Parameters.Add("@OrganizationName", SqlDbType.NVarChar).Value = cOMN_JobExperience.OrganizationName;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = cOMN_JobExperience.Designation;
            cmd.Parameters.Add("@NatureofWork", SqlDbType.NText).Value = cOMN_JobExperience.NatureofWork;
            cmd.Parameters.Add("@DateStart", SqlDbType.DateTime).Value = cOMN_JobExperience.DateStart == DateTime.MinValue ? (object)DBNull.Value : cOMN_JobExperience.DateStart;
            cmd.Parameters.Add("@DateEnds", SqlDbType.DateTime).Value = cOMN_JobExperience.DateEnds == DateTime.MinValue ? (object)DBNull.Value : cOMN_JobExperience.DateEnds;
            cmd.Parameters.Add("@Duration", SqlDbType.Decimal).Value = cOMN_JobExperience.Duration;
            cmd.Parameters.Add("@ReasionForLeaving", SqlDbType.NText).Value = cOMN_JobExperience.ReasionForLeaving;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = cOMN_JobExperience.Contact;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_JobExperience.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_JobExperience.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_JobExperience.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = cOMN_JobExperience.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobExperienceID"].Value;
        }
    }

    public bool UpdateCOMN_JobExperience(COMN_JobExperience cOMN_JobExperience)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_JobExperience", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobExperienceID", SqlDbType.Int).Value = cOMN_JobExperience.JobExperienceID;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = cOMN_JobExperience.UserID;

            cmd.Parameters.Add("@OrganizationName", SqlDbType.NVarChar).Value = cOMN_JobExperience.OrganizationName;
            cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = cOMN_JobExperience.Designation;

            cmd.Parameters.Add("@NatureofWork", SqlDbType.NText).Value = cOMN_JobExperience.NatureofWork;
            cmd.Parameters.Add("@DateStart", SqlDbType.DateTime).Value = cOMN_JobExperience.DateStart;
            cmd.Parameters.Add("@DateEnds", SqlDbType.DateTime).Value = cOMN_JobExperience.DateEnds;
            cmd.Parameters.Add("@Duration", SqlDbType.Decimal).Value = cOMN_JobExperience.Duration;
            cmd.Parameters.Add("@ReasionForLeaving", SqlDbType.NText).Value = cOMN_JobExperience.ReasionForLeaving;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = cOMN_JobExperience.Contact;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cOMN_JobExperience.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = cOMN_JobExperience.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_JobExperience(int jobExperienceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_JobExperience", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobExperienceID", SqlDbType.Int).Value = jobExperienceID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteCOMN_JobExperienceByUserID(string userID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_JobExperienceByUserID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<COMN_JobExperience> GetCOMN_JobExperiencesByUserID(string userID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_JobExperienceByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCOMN_JobExperiencesFromReader(reader);

        }
    }

    public List<COMN_JobExperience> GetCOMN_JobExperiencesByEmpUserID(string userID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_JobExperienceByEmpUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCOMN_JobExperiencesFromReader(reader);

        }
    }
}

