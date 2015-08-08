 using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System;
public class SqlINV_MRRInfoProvider:DataAccessObject
{
	public SqlINV_MRRInfoProvider()
    {
    }

    public DataSet  GetAllINV_MRRInfos()
    {
        DataSet INV_MRRInfos = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_MRRInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_MRRInfos);
            myadapter.Dispose();
            connection.Close();

            return INV_MRRInfos;
        }
    }

    public DataSet GetAllINV_MRRInfos1(string desc1,string desc2)
    {
        DataSet INV_MRRInfos = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_MRRInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Desc1", desc2);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_MRRInfos);
            myadapter.Dispose();
            connection.Close();

            return INV_MRRInfos;
        }
    }//GetAllINV_Items    GetAllINV_IssueNo  GetAllINV_InvoiseNo
    public DataSet GetAllINV_IssueNo(string desc1)
    {
        DataSet INV_MRRInfos = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_IssueNo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Desc1", desc1);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_MRRInfos);
            myadapter.Dispose();
            connection.Close();

            return INV_MRRInfos;
        }
    }

    public DataSet GetAllINV_InvoiseNo(string desc1)
    {
        DataSet INV_MRRInfos = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_InvoiseNo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Desc1", desc1);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_MRRInfos);
            myadapter.Dispose();
            connection.Close();
            
            return INV_MRRInfos;
        }
    }

    public DataSet GetAllINV_Items(string desc1)
    {
        DataSet INV_Items = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(desc1, connection);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@Desc1", desc2);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Items);
            myadapter.Dispose();
            connection.Close();

            return INV_Items;
        }
    }

	public DataSet GetINV_MRRInfoPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_MRRInfoPageWise", connection))
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
                recordCount = System.Convert.ToInt32(command.Parameters["@RecordCount"].Value);
                return ds;
            }
        }
    }

    public DataSet GetINV_MRRInfoBySearchString(string searchSQLString)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_MRRInfoBySearchString", connection))
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

    public INV_MRRInfo  GetINV_MRRInfoByCampusID(int  campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_MRRInfoByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_MRRInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public INV_MRRInfo  GetINV_MRRInfoByMRRInfoMasterID(int  mRRInfoMasterID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_MRRInfoByMRRInfoMasterID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MRRInfoMasterID", SqlDbType.NVarChar).Value = mRRInfoMasterID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_MRRInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public INV_MRRInfo  GetINV_MRRInfoByIteamID(int  iteamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_MRRInfoByIteamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IteamID", SqlDbType.NVarChar).Value = iteamID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_MRRInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public INV_MRRInfo  GetINV_MRRInfoByTagID(string  tagID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_MRRInfoByTagID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TagID", SqlDbType.NVarChar).Value = tagID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_MRRInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public INV_MRRInfo  GetINV_MRRInfoByStoreID(int  storeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_MRRInfoByStoreID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StoreID", SqlDbType.NVarChar).Value = storeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_MRRInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllINV_MRRInfo()
    {
        DataSet INV_MRRInfos = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllINV_MRRInfos", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_MRRInfos);
            myadapter.Dispose();
            connection.Close();

            return INV_MRRInfos;
        }
    }

    public DataSet GetAllINV_MRRInfosWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_MRRInfosWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    /// <summary>
    ///    Data set for MRR reports 
    /// </summary>
    /// <returns></returns>
    public DataSet GetAllINV_MRRInfosByMRRID(string MRRInfoID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_MRRInfosByMRRID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MRRInfoID", SqlDbType.Int).Value =Convert.ToUInt32(MRRInfoID);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    //GetAllINV_MRRReportsDateWise(string storProcedure,string txtFromDate,string txtToDate)
    public DataSet GetAllINV_MRRReportsDateWise(string storProcedure, string txtFromDate, string txtToDate)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand(storProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtFromDate);
            command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtToDate);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }

    public List<INV_MRRInfo> GetINV_MRRInfosFromReader(IDataReader reader)
    {
        List<INV_MRRInfo> iNV_MRRInfos = new List<INV_MRRInfo>();

        while (reader.Read())
        {
            iNV_MRRInfos.Add(GetINV_MRRInfoFromReader(reader));
        }
        return iNV_MRRInfos;
    }

    public INV_MRRInfo GetINV_MRRInfoFromReader(IDataReader reader)
    {
        try
        {
            INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo
                (

                     DataAccessObject.IsNULL<int>(reader["MRRInfoID"]),
                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<int>(reader["MRRInfoMasterID"]),
                     DataAccessObject.IsNULL<string>(reader["MRRCode"]),
                     DataAccessObject.IsNULL<int>(reader["IteamID"]),
                     DataAccessObject.IsNULL<string>(reader["TagID"]),
                     DataAccessObject.IsNULL<decimal>(reader["Quantity"]),
                     DataAccessObject.IsNULL<decimal>(reader["MRRAmount"]),
                     DataAccessObject.IsNULL<decimal>(reader["SaleAmount"]),
                     DataAccessObject.IsNULL<DateTime>(reader["MRRDate"]),
                     DataAccessObject.IsNULL<int>(reader["StoreID"])
                );
             return iNV_MRRInfo;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public INV_MRRInfo  GetINV_MRRInfoByMRRInfoID(int  mRRInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_MRRInfoByMRRInfoID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MRRInfoID", SqlDbType.Int).Value = mRRInfoID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_MRRInfoFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertINV_MRRInfo(INV_MRRInfo iNV_MRRInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertINV_MRRInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRRInfoID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_MRRInfo.CampusID;
            cmd.Parameters.Add("@MRRInfoMasterID", SqlDbType.Int).Value = iNV_MRRInfo.MRRInfoMasterID;
            cmd.Parameters.Add("@MRRCode", SqlDbType.NVarChar).Value = iNV_MRRInfo.MRRCode;
            cmd.Parameters.Add("@IteamID", SqlDbType.Int).Value = iNV_MRRInfo.IteamID;
            cmd.Parameters.Add("@TagID", SqlDbType.NVarChar).Value = iNV_MRRInfo.TagID;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_MRRInfo.Quantity;
            cmd.Parameters.Add("@MRRAmount", SqlDbType.Decimal).Value = iNV_MRRInfo.MRRAmount;
            cmd.Parameters.Add("@SaleAmount", SqlDbType.Decimal).Value = iNV_MRRInfo.SaleAmount;
            cmd.Parameters.Add("@MRRDate", SqlDbType.DateTime).Value = iNV_MRRInfo.MRRDate;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = iNV_MRRInfo.StoreID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MRRInfoID"].Value;
        }
    }

    public bool UpdateINV_MRRInfo(INV_MRRInfo iNV_MRRInfo)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateINV_MRRInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRRInfoID", SqlDbType.Int).Value = iNV_MRRInfo.MRRInfoID;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_MRRInfo.CampusID;
            cmd.Parameters.Add("@MRRInfoMasterID", SqlDbType.Int).Value = iNV_MRRInfo.MRRInfoMasterID;
            cmd.Parameters.Add("@MRRCode", SqlDbType.NVarChar).Value = iNV_MRRInfo.MRRCode;
            cmd.Parameters.Add("@IteamID", SqlDbType.Int).Value = iNV_MRRInfo.IteamID;
            cmd.Parameters.Add("@TagID", SqlDbType.NVarChar).Value = iNV_MRRInfo.TagID;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_MRRInfo.Quantity;
            cmd.Parameters.Add("@MRRAmount", SqlDbType.Decimal).Value = iNV_MRRInfo.MRRAmount;
            cmd.Parameters.Add("@SaleAmount", SqlDbType.Decimal).Value = iNV_MRRInfo.SaleAmount;
            cmd.Parameters.Add("@MRRDate", SqlDbType.DateTime).Value = iNV_MRRInfo.MRRDate;
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = iNV_MRRInfo.StoreID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteINV_MRRInfo(int mRRInfoID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteINV_MRRInfo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRRInfoID", SqlDbType.Int).Value = mRRInfoID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
    //------------------------------FinalUpdateMrrMaster------------
    public int FinalUpdateMrrMaster(string spname, string desc1, string desc2, string desc3, string Campusid)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(spname, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MRRInfoMasterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MRRInfoMasterName", SqlDbType.NVarChar).Value = "MRR Master";
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = Convert.ToInt32(Campusid);
            cmd.Parameters.Add("@MRRCode", SqlDbType.NVarChar).Value = desc1;
            cmd.Parameters.Add("@MRRDate", SqlDbType.DateTime).Value =Convert.ToDateTime(desc3);
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value =Convert.ToInt32(desc2);
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            //return (result == 1);
            return (int)cmd.Parameters["@MRRInfoMasterID"].Value;
        }
    }
    //InsertIssueMaster(string spname, string issueno, string storeid, string procod, string proqty, string issuedate)
    //  ---------  Insert Issue Master  ------------
    public int InsertIssueMaster(string spname, string issueno, string storeid, string masterName, string proqty, string issuedate,string CampusId)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(spname, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IssueMasterID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IssueMasterName", SqlDbType.NVarChar).Value = masterName;
            cmd.Parameters.Add("@IssueCode", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = Convert.ToInt32(CampusId);
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = Convert.ToInt32(storeid);
            cmd.Parameters.Add("@ProductionCode", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value =Convert.ToDecimal(proqty);
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = Convert.ToDateTime(issuedate);
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = Convert.ToDateTime(issuedate);
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = Convert.ToDateTime(issuedate);
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@IssueMasterID"].Value;
        }
    }

    //------------------------------------ MRR Details ----------------------------  FinalUpdateMRRDetails(spname, mrrno, sircode, tagid, mrrqty, mrramt, salamt, mrrdate, storeid);

    public int FinalUpdateMRRDetails(string spname, string mrrno,string mrrMasterID,string CampusID, string sircode, string tagid, string mrrqty, string mrramt, string salamt, string mrrdate, string storeid)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(spname, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MRRInfoID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MRRInfoMasterID", SqlDbType.Int).Value = Convert.ToInt32(mrrMasterID);
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value =Convert.ToInt32(CampusID);
            cmd.Parameters.Add("@MRRCode", SqlDbType.NVarChar).Value = mrrno;
            cmd.Parameters.Add("@IteamID", SqlDbType.Int).Value = Convert.ToInt32(sircode);//Convert.ToInt32(sircode);
            cmd.Parameters.Add("@TagID", SqlDbType.NVarChar).Value = tagid;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(mrrqty);
            cmd.Parameters.Add("@MRRAmount", SqlDbType.Decimal).Value =Convert.ToDecimal(mrramt);
            cmd.Parameters.Add("@SaleAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(salamt);
            cmd.Parameters.Add("@MRRDate", SqlDbType.DateTime).Value = Convert.ToDateTime(mrrdate);
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = Convert.ToInt32(storeid);
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@MRRInfoID"].Value;
        }
    }
    //InsertIssueDetails(string spname, string CampusId, string IssueMasterId, string storeid, string issueno, string itemcod, string tagid, string itemqty, string issdate1)

    public int InsertIssueDetails(string spname, string CampusId, string IssueMasterId, string storeid, string issueno, string itemcod, string tagid, string itemqty, string issdate1)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(spname, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@IssueID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@IssueCode", SqlDbType.NVarChar).Value = issueno;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = Convert.ToInt32(CampusId);
            cmd.Parameters.Add("@IssueMasterID", SqlDbType.Int).Value = Convert.ToInt32(IssueMasterId);
            cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = Convert.ToInt32(storeid);
            cmd.Parameters.Add("@ProductionCode", SqlDbType.NVarChar).Value = "00";
            cmd.Parameters.Add("@IteamCode", SqlDbType.NVarChar).Value = itemcod;
            cmd.Parameters.Add("@TagID", SqlDbType.NVarChar).Value = tagid;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value =Convert.ToDecimal(itemqty);
            cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = Convert.ToDateTime(issdate1);
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.Now;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@IssueID"].Value;
        }
    }
           

    //public  DataSet DataRelation(string procedure, string CallType, string TblName, string desc1,
    //       string desc2, string desc3, string desc4, string desc5, string desc6, string desc7, string desc8)
    //{//frmControlcode,frmCodeBooks,
    //    //SqlUserProvider sqlUserProvider = new SqlUserProvider();
    //    try
    //    {

    //        string SQL = procedure;
    //        SqlCommand cmd = new SqlCommand();
    //        cmd.CommandText = SQL;
    //        cmd.CommandType = CommandType.StoredProcedure;

    //        //cmd.Parameters.Add(new SqlParameter("@CallType", CallType));
    //        //cmd.Parameters.Add(new SqlParameter("@TblName", TblName));
    //        cmd.Parameters.Add(new SqlParameter("@Desc1", desc1));
    //        cmd.Parameters.Add(new SqlParameter("@Desc2", desc2));
    //        cmd.Parameters.Add(new SqlParameter("@Desc3", desc3));
    //        cmd.Parameters.Add(new SqlParameter("@Desc4", desc4));
    //        cmd.Parameters.Add(new SqlParameter("@Desc5", desc5));
    //        cmd.Parameters.Add(new SqlParameter("@Desc6", desc6));
    //        cmd.Parameters.Add(new SqlParameter("@Desc7", desc7));

    //        DataSet result = GetDataSet(cmd);

    //        if (result == null)  //_result==false
    //        {
    //            //this.SetError(_dataAccess.ErrorObject);
    //            return null;
    //        }
    //        return result;
    //    }
    //    catch (Exception exp)
    //    {
    //        //this.SetError(exp);
    //        return null;
    //    }// try
    //}

    

    //public static  DataSet GetDataSet(SqlCommand Cmd)
    //{
    //    try
    //    {
    //        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlDataAdapter adp = new SqlDataAdapter();
    //            adp.SelectCommand = Cmd;
    //            Cmd.Connection = connection;
    //            DataSet ds = new DataSet();
    //            adp.Fill(ds);
    //            return ds;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //this.SetError(ex);
    //        return null;
    //    }
    //}


}

