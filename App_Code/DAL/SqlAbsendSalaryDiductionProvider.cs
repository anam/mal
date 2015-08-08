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

public class SqlAbsendSalaryDiductionProvider:DataAccessObject
{
	public SqlAbsendSalaryDiductionProvider()
    {
    }


    public bool DeleteAbsendSalaryDiduction(int absendSalaryDiductionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_DeleteAbsendSalaryDiduction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AbsendSalaryDiductionID", SqlDbType.Int).Value = absendSalaryDiductionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<AbsendSalaryDiduction> GetAllAbsendSalaryDiductions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_GetAllAbsendSalaryDiductions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAbsendSalaryDiductionsFromReader(reader);
        }
    }


    public List<AbsendSalaryDiduction> GetAllAbsendSalaryDiductionsBySalaryOfMonth( string SalaryOfMonth)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_GetAllAbsendSalaryDiductionsBySalaryOfMonth", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryOfMonth", SqlDbType.NVarChar).Value = SalaryOfMonth;

            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetAbsendSalaryDiductionsFromReader(reader);
        }
    }

    public List<AbsendSalaryDiduction> GetAbsendSalaryDiductionsFromReader(IDataReader reader)
    {
        List<AbsendSalaryDiduction> absendSalaryDiductions = new List<AbsendSalaryDiduction>();

        while (reader.Read())
        {
            absendSalaryDiductions.Add(GetAbsendSalaryDiductionFromReader(reader));
        }
        return absendSalaryDiductions;
    }

    public AbsendSalaryDiduction GetAbsendSalaryDiductionFromReader(IDataReader reader)
    {
        try
        {
            AbsendSalaryDiduction absendSalaryDiduction = new AbsendSalaryDiduction
                (
                    (int)reader["AbsendSalaryDiductionID"],
                    reader["EmployeeID"].ToString(),
                    reader["SalaryOfMonth"].ToString(),
                    (int)reader["NoOfDays"],
                    (decimal)reader["TotalSalary"],
                    (decimal)reader["SalaryDeduction"],
                    reader["AddedBy"].ToString(),
                    (DateTime)reader["AddedDate"],
                    reader["UpdatedBy"].ToString(),
                    (DateTime)reader["UpdateDate"],
                    (int)reader["RowStatusID"]
                );
            try
            {
                absendSalaryDiduction.EmployeeName = reader["EmployeeName"].ToString();
                absendSalaryDiduction.EmployeeNo = reader["EmployeeNo"].ToString();
            }
            catch (Exception ex)
            { }

             return absendSalaryDiduction;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public AbsendSalaryDiduction GetAbsendSalaryDiductionByID(int absendSalaryDiductionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("CUC_GetAbsendSalaryDiductionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AbsendSalaryDiductionID", SqlDbType.Int).Value = absendSalaryDiductionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetAbsendSalaryDiductionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertAbsendSalaryDiduction(AbsendSalaryDiduction absendSalaryDiduction)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_InsertAbsendSalaryDiduction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AbsendSalaryDiductionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = absendSalaryDiduction.EmployeeID;
            cmd.Parameters.Add("@SalaryOfMonth", SqlDbType.NVarChar).Value = absendSalaryDiduction.SalaryOfMonth;
            cmd.Parameters.Add("@NoOfDays", SqlDbType.Int).Value = absendSalaryDiduction.NoOfDays;
            cmd.Parameters.Add("@TotalSalary", SqlDbType.Decimal).Value = absendSalaryDiduction.TotalSalary;
            cmd.Parameters.Add("@SalaryDeduction", SqlDbType.Decimal).Value = absendSalaryDiduction.SalaryDeduction;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = absendSalaryDiduction.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = absendSalaryDiduction.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = absendSalaryDiduction.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = absendSalaryDiduction.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = absendSalaryDiduction.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AbsendSalaryDiductionID"].Value;
        }
    }

    public bool UpdateAbsendSalaryDiduction(AbsendSalaryDiduction absendSalaryDiduction)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("CUC_UpdateAbsendSalaryDiduction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AbsendSalaryDiductionID", SqlDbType.Int).Value = absendSalaryDiduction.AbsendSalaryDiductionID;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = absendSalaryDiduction.EmployeeID;
            cmd.Parameters.Add("@SalaryOfMonth", SqlDbType.NVarChar).Value = absendSalaryDiduction.SalaryOfMonth;
            cmd.Parameters.Add("@NoOfDays", SqlDbType.Int).Value = absendSalaryDiduction.NoOfDays;
            cmd.Parameters.Add("@TotalSalary", SqlDbType.Decimal).Value = absendSalaryDiduction.TotalSalary;
            cmd.Parameters.Add("@SalaryDeduction", SqlDbType.Decimal).Value = absendSalaryDiduction.SalaryDeduction;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = absendSalaryDiduction.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = absendSalaryDiduction.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = absendSalaryDiduction.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = absendSalaryDiduction.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = absendSalaryDiduction.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
