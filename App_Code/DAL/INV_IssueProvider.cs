using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlINV_IssueProvider : DataAccessObject
{
    public SqlINV_IssueProvider()
    {
    }


    public DataSet GetAllINV_Issues()
    {
        DataSet INV_Issues = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_Issues", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Issues);
            myadapter.Dispose();
            connection.Close();

            return INV_Issues;
        }
    }
    /// <summary>
    /// GetAllINV_IssuesCheckAvlqty
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="PageSize"></param>
    /// <param name="recordCount"></param>
    /// <returns></returns>
    public DataSet GetAllINV_IssuesCheckAvlqty(int ItemID, int CampusID, int StoreID)
    {
        DataSet INV_Issues = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_IssuesCheckAvlqty", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;
            command.Parameters.Add("@CampusID", SqlDbType.Int).Value = CampusID;
            command.Parameters.Add("@StoreID", SqlDbType.Int).Value = StoreID;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Issues);
            myadapter.Dispose();
            connection.Close();

            return INV_Issues;
        }
    }

    public DataSet GetINV_IssuePageWise(int pageIndex, int PageSize, out int recordCount)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_IssuePageWise", connection))
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

    public DataSet GetINV_IssueBySerachString(string searchSQLString)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_IssueBySearchString", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SearchString", SqlDbType.NVarChar).Value = searchSQLString;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public INV_Issue GetINV_IssueByCampusID(int campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IssueByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetINV_IssueFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public INV_Issue GetINV_IssueByIssueMasterID(int issueMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IssueByIssueMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IssueMasterID", SqlDbType.NVarChar).Value = issueMasterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetINV_IssueFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public INV_Issue GetINV_IssueByStoreID(int storeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IssueByStoreID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StoreID", SqlDbType.NVarChar).Value = storeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetINV_IssueFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public DataSet GetDropDownListAllINV_Issue()
    {
        DataSet INV_Issues = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllINV_Issues", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Issues);
            myadapter.Dispose();
            connection.Close();

            return INV_Issues;
        }
    }

    public DataSet GetAllINV_IssuesWithRelation()
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_IssuesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public List<INV_Issue> GetINV_IssuesFromReader(IDataReader reader)
    {
        List<INV_Issue> iNV_Issues = new List<INV_Issue>();

        while (reader.Read())
        {
            iNV_Issues.Add(GetINV_IssueFromReader(reader));
        }
        return iNV_Issues;
    }

    public INV_Issue GetINV_IssueFromReader(IDataReader reader)
    {
        try
        {
            INV_Issue iNV_Issue = new INV_Issue
                (
                     DataAccessObject.IsNULL<int>(reader["IssueID"]),
                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<int>(reader["IssueMasterID"]),
                     DataAccessObject.IsNULL<int>(reader["StoreID"]),
                     DataAccessObject.IsNULL<string>(reader["ProductionCode"]),
                     DataAccessObject.IsNULL<decimal>(reader["Quantity"]),
                     DataAccessObject.IsNULL<DateTime>(reader["IssueDate"]),

                     DataAccessObject.IsNULL<string>(reader["IssueCode"]),
                     DataAccessObject.IsNULL<string>(reader["TagID"]),
                     DataAccessObject.IsNULL<int>(reader["IteamCode"]),

                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
            return iNV_Issue;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public INV_Issue GetINV_IssueByIssueID(int issueID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_IssueByIssueID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IssueID", SqlDbType.Int).Value = issueID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetINV_IssueFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertINV_Issue(INV_Issue iNV_Issue)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertINV_Issue", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IssueID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_Issue.CampusID;
            cmd.Parameters.Add("@IssueMasterID", SqlDbType.Int).Value = iNV_Issue.IssueMasterID;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = iNV_Issue.StoreID;
            cmd.Parameters.Add("@ProductionCode", SqlDbType.NVarChar).Value = iNV_Issue.ProductionCode;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_Issue.Quantity;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = iNV_Issue.IssueDate;

            cmd.Parameters.Add("@IssueCode", SqlDbType.NVarChar).Value = iNV_Issue.IssueNo;
            cmd.Parameters.Add("@TagID", SqlDbType.NVarChar).Value = iNV_Issue.TagID;
            cmd.Parameters.Add("@IteamCode", SqlDbType.Int).Value = iNV_Issue.ItemID;

            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = iNV_Issue.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = iNV_Issue.AddedDate;
            //cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_Issue.UpdatedBy;
            //cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_Issue.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@IssueID"].Value;
        }
    }

    public bool UpdateINV_Issue(INV_Issue iNV_Issue)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateINV_Issue", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IssueID", SqlDbType.Int).Value = iNV_Issue.IssueID;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_Issue.CampusID;
            cmd.Parameters.Add("@IssueMasterID", SqlDbType.Int).Value = iNV_Issue.IssueMasterID;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = iNV_Issue.StoreID;
            cmd.Parameters.Add("@ProductionCode", SqlDbType.NVarChar).Value = iNV_Issue.ProductionCode;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_Issue.Quantity;
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = iNV_Issue.IssueDate;

            cmd.Parameters.Add("@IssueCode", SqlDbType.NVarChar).Value = iNV_Issue.IssueNo;
            cmd.Parameters.Add("@TagID", SqlDbType.NVarChar).Value = iNV_Issue.TagID;
            cmd.Parameters.Add("@IteamCode", SqlDbType.Int).Value = iNV_Issue.ItemID;

            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_Issue.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_Issue.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteINV_Issue(int issueID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteINV_Issue", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IssueID", SqlDbType.Int).Value = issueID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

