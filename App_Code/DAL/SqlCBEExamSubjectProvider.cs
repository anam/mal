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

public class SqlCBEExamSubjectProvider:DataAccessObject
{
	public SqlCBEExamSubjectProvider()
    {
    }


    public bool DeleteCBEExamSubject(int cBEExamSubjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Islamicfinancebd_CUCDB_DeleteCBEExamSubject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CBEExamSubjectID", SqlDbType.Int).Value = cBEExamSubjectID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<STD_CBEExamSubject> GetAllCBEExamSubjects()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Islamicfinancebd_CUCDB_GetAllCBEExamSubjects", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCBEExamSubjectsFromReader(reader);
        }
    }

    public List<STD_CBEExamSubject> GetSTD_CBEExamSubjectByCBEExamID(int cBEExamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CBEExamSubjectByCBEExamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CBEExamID", SqlDbType.Int).Value = cBEExamID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetCBEExamSubjectsFromReader(reader);
        }
    }


    public List<STD_CBEExamSubject> GetCBEExamSubjectsFromReader(IDataReader reader)
    {
        List<STD_CBEExamSubject> cBEExamSubjects = new List<STD_CBEExamSubject>();

        while (reader.Read())
        {
            cBEExamSubjects.Add(GetCBEExamSubjectFromReader(reader));
        }
        return cBEExamSubjects;
    }

    public STD_CBEExamSubject GetCBEExamSubjectFromReader(IDataReader reader)
    {
        try
        {
            STD_CBEExamSubject cBEExamSubject = new STD_CBEExamSubject
                (
                    (int)reader["ExamSubjectID"],
                    (int)reader["CBEExamID"],
                    reader["SubjectTitle"].ToString(),
                    reader["SubjectCode"].ToString(),
                    reader["TaxOrPaperVariant"].ToString(),
                    (Decimal)reader["Fees"],
                    (DateTime)reader["ExamDate"],
                    reader["AddedBy"].ToString(),
                    (DateTime)reader["AddedDate"],
                    reader["UpdatedBy"].ToString(),
                    (DateTime)reader["UpdatedDate"],
                    (int)reader["RowStatusID"]
                );

            try
            {
                cBEExamSubject.FeesDescription = reader["FeesDescription"].ToString();
            }
            catch (Exception ex)
            {
            }

             return cBEExamSubject;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_CBEExamSubject GetCBEExamSubjectByID(int cBEExamSubjectID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CBEExamSubjectByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ExamSubjectID", SqlDbType.Int).Value = cBEExamSubjectID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetCBEExamSubjectFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertCBEExamSubject(STD_CBEExamSubject cBEExamSubject)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_CBEExamSubject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExamSubjectID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CBEExamID", SqlDbType.Int).Value = cBEExamSubject.CBEExamID;
            cmd.Parameters.Add("@SubjectTitle", SqlDbType.NVarChar).Value = cBEExamSubject.SubjectTitle;
            cmd.Parameters.Add("@SubjectCode", SqlDbType.NVarChar).Value = cBEExamSubject.SubjectCode;
            cmd.Parameters.Add("@TaxOrPaperVariant", SqlDbType.NVarChar).Value = cBEExamSubject.TaxOrPaperVariant;
            cmd.Parameters.Add("@Fees", SqlDbType.Decimal).Value = cBEExamSubject.Fees;
            cmd.Parameters.Add("@ExamDate", SqlDbType.DateTime).Value = cBEExamSubject.ExamDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = cBEExamSubject.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cBEExamSubject.AddedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = cBEExamSubject.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = cBEExamSubject.UpdatedDate.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()));
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cBEExamSubject.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ExamSubjectID"].Value;
        }
    }

    public bool UpdateCBEExamSubject(STD_CBEExamSubject cBEExamSubject)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Islamicfinancebd_CUCDB_UpdateCBEExamSubject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CBEExamSubjectID", SqlDbType.Int).Value = cBEExamSubject.CBEExamSubjectID;
            cmd.Parameters.Add("@CBEExamID", SqlDbType.Int).Value = cBEExamSubject.CBEExamID;
            cmd.Parameters.Add("@SubjectTitle", SqlDbType.NVarChar).Value = cBEExamSubject.SubjectTitle;
            cmd.Parameters.Add("@SubjectCode", SqlDbType.NVarChar).Value = cBEExamSubject.SubjectCode;
            cmd.Parameters.Add("@TaxOrPaperVariant", SqlDbType.NVarChar).Value = cBEExamSubject.TaxOrPaperVariant;
            cmd.Parameters.Add("@Fees", SqlDbType.Decimal).Value = cBEExamSubject.Fees;
            cmd.Parameters.Add("@ExamDate", SqlDbType.DateTime).Value = cBEExamSubject.ExamDate;
            cmd.Parameters.Add("@AddedBy", SqlDbType.UniqueIdentifier).Value = cBEExamSubject.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = cBEExamSubject.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = cBEExamSubject.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = cBEExamSubject.UpdatedDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = cBEExamSubject.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
