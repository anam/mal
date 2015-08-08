using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlCOMN_EducatinalBackgroundProvider:DataAccessObject
{
	public SqlCOMN_EducatinalBackgroundProvider()
    {
    }


    public DataSet  GetAllCOMN_EducatinalBackgrounds()
    {
        DataSet COMN_EducatinalBackgrounds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_EducatinalBackgrounds", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_EducatinalBackgrounds);
            myadapter.Dispose();
            connection.Close();

            return COMN_EducatinalBackgrounds;
        }
    }
    public DataSet GetAllCOMN_EducatinalBackgroundsEmployerID(string employerID)
    {
        DataSet COMN_EducatinalBackgrounds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllCOMN_EducatinalBackgroundsEmployerID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployerID", employerID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_EducatinalBackgrounds);
            myadapter.Dispose();
            connection.Close();

            return COMN_EducatinalBackgrounds;
        }
    }
    
	public DataSet GetCOMN_EducatinalBackgroundPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetCOMN_EducatinalBackgroundPageWise", connection))
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


    public COMN_EducatinalBackground GetCOMN_EducatinalBackgroundByUserID(string userID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_EducatinalBackgroundByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetCOMN_EducatinalBackgroundFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }
    
    public DataSet  GetCOMN_EducatinalBackgroundByUserID(string  userID,bool isDataset)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("GetCOMN_EducatinalBackgroundByUserID", connection))
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

    public COMN_EducatinalBackground  GetCOMN_EducatinalBackgroundByReaultSystemID(int  reaultSystemID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_EducatinalBackgroundByReaultSystemID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ReaultSystemID", SqlDbType.NVarChar).Value = reaultSystemID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_EducatinalBackgroundFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllCOMN_EducatinalBackground()
    {
        DataSet COMN_EducatinalBackgrounds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllCOMN_EducatinalBackgrounds", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(COMN_EducatinalBackgrounds);
            myadapter.Dispose();
            connection.Close();

            return COMN_EducatinalBackgrounds;
        }
    }
    public List<COMN_EducatinalBackground> GetCOMN_EducatinalBackgroundsFromReader(IDataReader reader)
    {
        List<COMN_EducatinalBackground> cOMN_EducatinalBackgrounds = new List<COMN_EducatinalBackground>();

        while (reader.Read())
        {
            cOMN_EducatinalBackgrounds.Add(GetCOMN_EducatinalBackgroundFromReader(reader));
        }
        return cOMN_EducatinalBackgrounds;
    }

    public COMN_EducatinalBackground GetCOMN_EducatinalBackgroundFromReader(IDataReader reader)
    {
        try
        {
            COMN_EducatinalBackground cOMN_EducatinalBackground = new COMN_EducatinalBackground
                (

                     DataAccessObject.IsNULL<int>(reader["EducationalBacgroundID"]),
                     DataAccessObject.IsNULL<string>(reader["UserID"].ToString()),
                     DataAccessObject.IsNULL<string>(reader["Year"]),
                     DataAccessObject.IsNULL<string>(reader["BoardUniversity"]),
                     DataAccessObject.IsNULL<string>(reader["EducationGroup"]),
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
            try
            {
                cOMN_EducatinalBackground.ReaultSystemName = DataAccessObject.IsNULL<string>(reader["ReaultSystemName"].ToString());
                cOMN_EducatinalBackground.StudentName = DataAccessObject.IsNULL<string>(reader["StudentName"].ToString());
            }
            catch (Exception ex)
            {
            }
             return cOMN_EducatinalBackground;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public COMN_EducatinalBackground  GetCOMN_EducatinalBackgroundByEducationalBacgroundID(int  educationalBacgroundID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetCOMN_EducatinalBackgroundByEducationalBacgroundID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EducationalBacgroundID", SqlDbType.Int).Value = educationalBacgroundID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetCOMN_EducatinalBackgroundFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertCOMN_EducatinalBackground(COMN_EducatinalBackground cOMN_EducatinalBackground)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertCOMN_EducatinalBackground", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EducationalBacgroundID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.UserID;
            cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.Year;
            cmd.Parameters.Add("@BoardUniversity", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.BoardUniversity;
            cmd.Parameters.Add("@EducationGroup", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.EducationGroup;
            cmd.Parameters.Add("@Major", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.Major;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = cOMN_EducatinalBackground.ReaultSystemID;
            cmd.Parameters.Add("@Degree", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.Degree;
            cmd.Parameters.Add("@Result", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.Result;
            cmd.Parameters.Add("@Score", SqlDbType.Decimal).Value = cOMN_EducatinalBackground.Score;
            cmd.Parameters.Add("@OutOf", SqlDbType.Int).Value = cOMN_EducatinalBackground.OutOf;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cOMN_EducatinalBackground.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_EducatinalBackground.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EducationalBacgroundID"].Value;
        }
    }

    public bool UpdateCOMN_EducatinalBackground(COMN_EducatinalBackground cOMN_EducatinalBackground)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateCOMN_EducatinalBackground", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EducationalBacgroundID", SqlDbType.Int).Value = cOMN_EducatinalBackground.EducationalBacgroundID;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.UserID;
            cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.Year;
            cmd.Parameters.Add("@BoardUniversity", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.BoardUniversity;
            cmd.Parameters.Add("@EducationGroup", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.EducationGroup;
            cmd.Parameters.Add("@Major", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.Major;
            cmd.Parameters.Add("@ReaultSystemID", SqlDbType.Int).Value = cOMN_EducatinalBackground.ReaultSystemID;
            cmd.Parameters.Add("@Degree", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.Degree;
            cmd.Parameters.Add("@Result", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.Result;
            cmd.Parameters.Add("@Score", SqlDbType.Decimal).Value = cOMN_EducatinalBackground.Score;
            cmd.Parameters.Add("@OutOf", SqlDbType.Int).Value = cOMN_EducatinalBackground.OutOf;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = cOMN_EducatinalBackground.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = cOMN_EducatinalBackground.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteCOMN_EducatinalBackground(int educationalBacgroundID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_EducatinalBackground", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EducationalBacgroundID", SqlDbType.Int).Value = educationalBacgroundID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public bool DeleteCOMN_EducatinalBackgroundByUserID(string userID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteCOMN_EducatinalBackgroundByUserID", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<COMN_EducatinalBackground> GetCOMN_EducatinalBackgroundsByUserID(string userID)
    {

        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("GetCOMN_EducatinalBackgroundByUserID", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
                connection.Open();
                IDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                return GetCOMN_EducatinalBackgroundsFromReader(reader);
            }
        }
    }

    public List<COMN_EducatinalBackground> GetCOMN_EducatinalBackgroundsByEmpUserID(string userID)
    {

        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("GetCOMN_EducatinalBackgroundsByEmpUserID", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
                connection.Open();
                IDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                return GetCOMN_EducatinalBackgroundsFromReader(reader);
            }
        }
    }

    
}

