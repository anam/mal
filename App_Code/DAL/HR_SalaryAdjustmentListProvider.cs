using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlHR_SalaryAdjustmentListProvider : DataAccessObject
{
    public SqlHR_SalaryAdjustmentListProvider()
    {
    }

    public DataSet GetAllSalaryAdjustmentLists()
    {
        DataSet SalaryAdjustmentLists = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllHR_SalaryAdjustmentLists", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(SalaryAdjustmentLists);
            myadapter.Dispose();
            connection.Close();

            return SalaryAdjustmentLists;
        }
    }

    public DataSet GetSalaryAdjustmentListBySalaryAdjustmentGroupID(int salaryAdjustmentGroupID)
    {
        DataSet SalaryAdjustmentLists = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryAdjustmentListBySalaryAdjustmentGroupID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.Int).Value = salaryAdjustmentGroupID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(SalaryAdjustmentLists);
            myadapter.Dispose();
            connection.Close();

            return SalaryAdjustmentLists;
        }
    }

    public DataSet GetSalaryAdjustmentListPageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetHR_SalaryAdjustmentListPageWise", connection))
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


    public DataSet GetDropDownLisAllSalaryAdjustmentList()
    {
        DataSet SalaryAdjustmentLists = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllHR_SalaryAdjustmentList", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(SalaryAdjustmentLists);
            myadapter.Dispose();
            connection.Close();

            return SalaryAdjustmentLists;
        }
    }

    public DataSet GetAllQuiz_TrueFalsesWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllQuiz_TrueFalsesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<HR_SalaryAdjustmentList> GetSalaryAdjustmentListsFromReader(IDataReader reader)
    {
        List<HR_SalaryAdjustmentList> salaryAdjustmentLists = new List<HR_SalaryAdjustmentList>();

        while (reader.Read())
        {
            salaryAdjustmentLists.Add(GetSalaryAdjustmentListFromReader(reader));
        }
        return salaryAdjustmentLists;
    }

    public HR_SalaryAdjustmentList GetSalaryAdjustmentListFromReader(IDataReader reader)
    {
        try
        {
            HR_SalaryAdjustmentList salaryAdjustmentList = new HR_SalaryAdjustmentList
            (

            DataAccessObject.IsNULL<int>(reader["SalaryAdjustmentListID"]),
            DataAccessObject.IsNULL<int>(reader["SalaryAdjustmentGroupID"]),
            DataAccessObject.IsNULL<string>(reader["Name"]),
            DataAccessObject.IsNULL<decimal>(reader["Value"]),
            DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
            DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
            DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
            DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
            );
            return salaryAdjustmentList;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public HR_SalaryAdjustmentList GetSalaryAdjustmentListBySalaryAdjustmentListID(int salaryAdjustmentListID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetHR_SalaryAdjustmentListBySalaryAdjustmentListID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryAdjustmentListID", SqlDbType.Int).Value = salaryAdjustmentListID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSalaryAdjustmentListFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertSalaryAdjustmentList(HR_SalaryAdjustmentList salaryAdjustmentList)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertHR_SalaryAdjustmentList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryAdjustmentListID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.NVarChar).Value = salaryAdjustmentList.SalaryAdjustmentGroupID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = salaryAdjustmentList.Name;
            cmd.Parameters.Add("@Value", SqlDbType.Decimal).Value = salaryAdjustmentList.Value;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = salaryAdjustmentList.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = salaryAdjustmentList.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = salaryAdjustmentList.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = salaryAdjustmentList.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryAdjustmentListID"].Value;
        }
    }

    public bool UpdateSalaryAdjustmentList(HR_SalaryAdjustmentList salaryAdjustmentList)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateHR_SalaryAdjustmentList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryAdjustmentListID", SqlDbType.Int).Value = salaryAdjustmentList.SalaryAdjustmentListID;
            cmd.Parameters.Add("@SalaryAdjustmentGroupID", SqlDbType.NVarChar).Value = salaryAdjustmentList.SalaryAdjustmentGroupID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = salaryAdjustmentList.Name;
            cmd.Parameters.Add("@Value", SqlDbType.Decimal).Value = salaryAdjustmentList.Value;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = salaryAdjustmentList.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = salaryAdjustmentList.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSalaryAdjustmentList(int salaryAdjustmentListID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSalaryAdjustmentList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryAdjustmentListID", SqlDbType.Int).Value = salaryAdjustmentListID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

