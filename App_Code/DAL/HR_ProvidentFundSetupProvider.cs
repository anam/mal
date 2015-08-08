using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_ProvidentFundSetupProvider : DataAccessObject
{
    public SqlHR_ProvidentFundSetupProvider()
    {
    }


    public DataSet GetAllHR_ProvidentFundSetups()
    {
        DataSet HR_ProvidentFundSetups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ProvidentFundSetups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentFundSetups);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentFundSetups;
        }
    }

    public DataSet GetHR_ProvidentFundSetupPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_ProvidentFundSetupPageWise", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PageIndex", pageIndex);
                command.Parameters.AddWithValue("@PageSize", PageSize);
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

    public HR_ProvidentFundSetup GetHR_ProvidentFundSetupByFundTypeID(int fundTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentFundSetupByFundTypeID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FundTypeID", SqlDbType.NVarChar).Value = fundTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_ProvidentFundSetupFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetDropDownLisAllHR_ProvidentFundSetup()
    {
        DataSet HR_ProvidentFundSetups = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_ProvidentFundSetup", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(HR_ProvidentFundSetups);
            myadapter.Dispose();
            connection.Close();

            return HR_ProvidentFundSetups;
        }
    }

    public List<HR_ProvidentFundSetup> GetHR_ProvidentFundSetupsFromReader(IDataReader reader)
    {
        List<HR_ProvidentFundSetup> hR_ProvidentFundSetups = new List<HR_ProvidentFundSetup>();

        while (reader.Read())
        {
            hR_ProvidentFundSetups.Add(GetHR_ProvidentFundSetupFromReader(reader));
        }
        return hR_ProvidentFundSetups;
    }

    public HR_ProvidentFundSetup GetHR_ProvidentFundSetupFromReader(IDataReader reader)
    {
        try
        {
            HR_ProvidentFundSetup hR_ProvidentFundSetup = new HR_ProvidentFundSetup
                (
                     DataAccessObject.IsNULL<int>(reader["ProvidentFundSetupID"]),
                     DataAccessObject.IsNULL<int>(reader["ServiceLenStartYear"]),
                     DataAccessObject.IsNULL<int>(reader["ServiceLenEndYear"]),
                     DataAccessObject.IsNULL<int>(reader["FundTypeID"]),
                     DataAccessObject.IsNULL<double>(reader["FundPercentForEmp"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["ModifiedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["ModifiedDate"])
                );
            return hR_ProvidentFundSetup;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public HR_ProvidentFundSetup GetHR_ProvidentFundSetupByProvidentFundSetupID(int providentFundSetupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_ProvidentFundSetupByProvidentFundSetupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProvidentFundSetupID", SqlDbType.Int).Value = providentFundSetupID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetHR_ProvidentFundSetupFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public List<HR_ProvidentFundSetup> GetHR_ProvidentFundSetupColl()
    {
        List<HR_ProvidentFundSetup> HR_ProvidentFundSetups = new List<HR_ProvidentFundSetup>();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_ProvidentFundSetups", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                HR_ProvidentFundSetup providentFundSetup= GetHR_ProvidentFundSetupFromReader(reader);
                HR_ProvidentFundSetups.Add(providentFundSetup);
            }
            connection.Close();

            return HR_ProvidentFundSetups;
        }
    }

    public int InsertHR_ProvidentFundSetup(HR_ProvidentFundSetup hR_ProvidentFundSetup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_ProvidentFundSetup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentFundSetupID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ServiceLenStartYear", SqlDbType.Int).Value = hR_ProvidentFundSetup.ServiceLenStartYear;
            cmd.Parameters.Add("@ServiceLenEndYear", SqlDbType.Int).Value = hR_ProvidentFundSetup.ServiceLenEndYear;
            cmd.Parameters.Add("@FundTypeID", SqlDbType.Int).Value = hR_ProvidentFundSetup.FundTypeID;
            cmd.Parameters.Add("@FundPercentForEmp", SqlDbType.Float).Value = hR_ProvidentFundSetup.FundPercentForEmp;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = string.Empty; // hR_ProvidentFundSetup.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = string.Empty; // hR_ProvidentFundSetup.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = string.Empty; // hR_ProvidentFundSetup.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = string.Empty; //hR_ProvidentFundSetup.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = string.Empty; // hR_ProvidentFundSetup.ExtraField5;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = hR_ProvidentFundSetup.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = hR_ProvidentFundSetup.AddedDate;
            connection.Open();
            
            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProvidentFundSetupID"].Value;
        }
    }

    public bool UpdateHR_ProvidentFundSetup(HR_ProvidentFundSetup hR_ProvidentFundSetup)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_ProvidentFundSetup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentFundSetupID", SqlDbType.Int).Value = hR_ProvidentFundSetup.ProvidentFundSetupID;
            cmd.Parameters.Add("@ServiceLenStartYear", SqlDbType.Int).Value = hR_ProvidentFundSetup.ServiceLenStartYear;
            cmd.Parameters.Add("@ServiceLenEndYear", SqlDbType.Int).Value = hR_ProvidentFundSetup.ServiceLenEndYear;
            cmd.Parameters.Add("@FundTypeID", SqlDbType.Int).Value = hR_ProvidentFundSetup.FundTypeID;
            cmd.Parameters.Add("@FundPercentForEmp", SqlDbType.Float).Value = hR_ProvidentFundSetup.FundPercentForEmp;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = string.Empty; //hR_ProvidentFundSetup.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = string.Empty; //hR_ProvidentFundSetup.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = string.Empty; //hR_ProvidentFundSetup.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = string.Empty; //hR_ProvidentFundSetup.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = string.Empty; //hR_ProvidentFundSetup.ExtraField5;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = hR_ProvidentFundSetup.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = hR_ProvidentFundSetup.ModifiedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteHR_ProvidentFundSetup(int providentFundSetupID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteHR_ProvidentFundSetup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProvidentFundSetupID", SqlDbType.Int).Value = providentFundSetupID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

