using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlCBEExamProvider:DataAccessObject
{
	public SqlCBEExamProvider()
    {
    }


    public bool DeleteCBEExam(int cBEExamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_CBEExam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CBEExamID", SqlDbType.Int).Value = cBEExamID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<STD_CBEExam> GetAllCBEExams()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_CBEExams", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCBEExamsFromReader(reader);
        }
    }
    public List<STD_CBEExam> GetCBEExamsFromReader(IDataReader reader)
    {
        List<STD_CBEExam> cBEExams = new List<STD_CBEExam>();

        while (reader.Read())
        {
            cBEExams.Add(GetCBEExamFromReader(reader));
        }
        return cBEExams;
    }

    public STD_CBEExam GetCBEExamFromReader(IDataReader reader)
    {
        try
        {
            STD_CBEExam cBEExam = new STD_CBEExam
                (
                    (int)reader["CBEExamID"],
                    reader["CandidateName"].ToString(),
                    (DateTime)reader["DOB"],
                    reader["Gender"].ToString(),
                    reader["RegiNo"].ToString(),
                    reader["InstituteName"].ToString(),
                    reader["Tel"].ToString(),
                    reader["Mobile"].ToString(),
                    reader["Email"].ToString(),
                    reader["FeesDescription"].ToString(),
                    reader["AddedBy"].ToString(),
                    (DateTime)reader["AddedDate"],
                    reader["UpdatedBy"].ToString(),
                    (DateTime)reader["UpdatedDate"],
                    (int)reader["RowStatusID"]
                );
            try
            {
                cBEExam.SubjectTitle = reader["SubjectTitle"].ToString();
                cBEExam.Fees = (Decimal)reader["Fees"];
            }
            catch (Exception ex)
            {
            }

             return cBEExam;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_CBEExam GetCBEExamByID(int cBEExamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CBEExamByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CBEExamID", SqlDbType.Int).Value = cBEExamID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetCBEExamFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertCBEExam(STD_CBEExam cBEExam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_CBEExam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CBEExamID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CandidateName", SqlDbType.NVarChar).Value = cBEExam.CandidateName;
            cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = cBEExam.DOB;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = cBEExam.Gender;
            cmd.Parameters.Add("@RegiNo", SqlDbType.NVarChar).Value = cBEExam.RegiNo;
            cmd.Parameters.Add("@InstituteName", SqlDbType.NVarChar).Value = cBEExam.InstituteName;
            cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = cBEExam.Tel;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = cBEExam.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = cBEExam.Email;
            cmd.Parameters.Add("@FeesDescription", SqlDbType.NVarChar).Value = cBEExam.FeesDescription;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cBEExam.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cBEExam.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cBEExam.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = cBEExam.UpdatedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cBEExam.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CBEExamID"].Value;
        }
    }

    public bool UpdateCBEExam(STD_CBEExam cBEExam)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_CBEExam", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CBEExamID", SqlDbType.Int).Value = cBEExam.CBEExamID;
            cmd.Parameters.Add("@CandidateName", SqlDbType.NVarChar).Value = cBEExam.CandidateName;
            cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = cBEExam.DOB;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = cBEExam.Gender;
            cmd.Parameters.Add("@RegiNo", SqlDbType.NVarChar).Value = cBEExam.RegiNo;
            cmd.Parameters.Add("@InstituteName", SqlDbType.NVarChar).Value = cBEExam.InstituteName;
            cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = cBEExam.Tel;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = cBEExam.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = cBEExam.Email;
            cmd.Parameters.Add("@FeesDescription", SqlDbType.NVarChar).Value = cBEExam.FeesDescription;
            cmd.Parameters.Add("@AddedBy", SqlDbType.UniqueIdentifier).Value = cBEExam.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cBEExam.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = cBEExam.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = cBEExam.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cBEExam.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public List<STD_CBEExam> SearchAllCBEExams(string name, string subject, DateTime startDate, DateTime endDate)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SearchSTD_CBEExam", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
            command.Parameters.Add("@SubjectTitle", SqlDbType.NVarChar).Value = subject;
            command.Parameters.Add("@FromDate", SqlDbType.NVarChar).Value = startDate;
            command.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = endDate;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCBEExamsFromReader(reader);
        }
    }
}
