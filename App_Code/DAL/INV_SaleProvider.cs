using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlINV_SaleProvider:DataAccessObject
{
	public SqlINV_SaleProvider()
    {
    }


    public DataSet  GetAllINV_Sales()
    {
        DataSet INV_Sales = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_Sales", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Sales);
            myadapter.Dispose();
            connection.Close();

            return INV_Sales;
        }
    }
    //GetAllINV_TakaInWord(string InvoiseNo)
    public DataSet GetAllINV_TakaInWord(string InvoiseNo)
    {
        DataSet INV_Sales = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_TakaInWord", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@InvoiseNO", InvoiseNo);
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Sales);
            myadapter.Dispose();
            connection.Close();

            return INV_Sales;
        }
    }
	public DataSet GetINV_SalePageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetINV_SalePageWise", connection))
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


    public INV_Sale  GetINV_SaleByCampusID(int  campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_SaleByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.NVarChar).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_SaleFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public INV_Sale  GetINV_SaleByIteamID(int  iteamID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_SaleByIteamID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IteamID", SqlDbType.NVarChar).Value = iteamID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_SaleFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllINV_Sale()
    {
        DataSet INV_Sales = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllINV_Sales", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(INV_Sales);
            myadapter.Dispose();
            connection.Close();

            return INV_Sales;
        }
    }

    public DataSet   GetAllINV_SalesWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllINV_SalesWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<INV_Sale> GetINV_SalesFromReader(IDataReader reader)
    {
        List<INV_Sale> iNV_Sales = new List<INV_Sale>();

        while (reader.Read())
        {
            iNV_Sales.Add(GetINV_SaleFromReader(reader));
        }
        return iNV_Sales;
    }

    public INV_Sale GetINV_SaleFromReader(IDataReader reader)
    {
        try
        {
            INV_Sale iNV_Sale = new INV_Sale
                (

                     DataAccessObject.IsNULL<int>(reader["SaleID"]),
                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<string>(reader["InvoiceNo"]),
                     DataAccessObject.IsNULL<int>(reader["IteamID"]),
                     DataAccessObject.IsNULL<decimal>(reader["Quantity"]),
                     DataAccessObject.IsNULL<int>(reader["Warrenty"]),
                     DataAccessObject.IsNULL<decimal>(reader["UnitPrice"]),
                     DataAccessObject.IsNULL<DateTime>(reader["SaleDate"]),
                     DataAccessObject.IsNULL<string>(reader["Remark"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdatedDate"])
                );
             return iNV_Sale;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public INV_Sale  GetINV_SaleBySaleID(int  saleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetINV_SaleBySaleID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SaleID", SqlDbType.Int).Value = saleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetINV_SaleFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertINV_Sale(INV_Sale iNV_Sale)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertINV_Sale", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_Sale.CampusID;
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = iNV_Sale.InvoiceNo;
            cmd.Parameters.Add("@IteamID", SqlDbType.Int).Value = iNV_Sale.IteamID;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_Sale.Quantity;
            cmd.Parameters.Add("@Warrenty", SqlDbType.Int).Value = iNV_Sale.Warrenty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = iNV_Sale.UnitPrice;
            cmd.Parameters.Add("@SaleDate", SqlDbType.DateTime).Value = iNV_Sale.SaleDate;
            cmd.Parameters.Add("@Remark", SqlDbType.NText).Value = iNV_Sale.Remark;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = iNV_Sale.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = iNV_Sale.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_Sale.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_Sale.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SaleID"].Value;
        }
    }  //InsertINV_SaleInsert

    public int InsertINV_SaleInsert(string stprose, string Invoice, string SIRCODE, string TAGID, string WARRENTY, string QUANTITY, string UNITPRICE, string InvDate, string invCampus, string remarks)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(stprose, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value =Convert.ToInt32(invCampus);
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = Invoice;
            cmd.Parameters.Add("@IteamID", SqlDbType.Int).Value = Convert.ToInt32(SIRCODE);
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value =Convert.ToDecimal(QUANTITY);
            cmd.Parameters.Add("@Warrenty", SqlDbType.Int).Value =Convert.ToInt32(WARRENTY);
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(UNITPRICE);
            cmd.Parameters.Add("@SaleDate", SqlDbType.DateTime).Value =Convert.ToDateTime(InvDate);
            cmd.Parameters.Add("@Remark", SqlDbType.NText).Value = remarks;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.Now;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SaleID"].Value;
        }
    }


    public bool UpdateINV_Sale(INV_Sale iNV_Sale)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateINV_Sale", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleID", SqlDbType.Int).Value = iNV_Sale.SaleID;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = iNV_Sale.CampusID;
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = iNV_Sale.InvoiceNo;
            cmd.Parameters.Add("@IteamID", SqlDbType.Int).Value = iNV_Sale.IteamID;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = iNV_Sale.Quantity;
            cmd.Parameters.Add("@Warrenty", SqlDbType.Int).Value = iNV_Sale.Warrenty;
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = iNV_Sale.UnitPrice;
            cmd.Parameters.Add("@SaleDate", SqlDbType.DateTime).Value = iNV_Sale.SaleDate;
            cmd.Parameters.Add("@Remark", SqlDbType.NText).Value = iNV_Sale.Remark;
            //cmd.Parameters.Add("@Remark", SqlDbType.NText).Value = iNV_Sale.Remark;
            //cmd.Parameters.Add("@Remark", SqlDbType.NText).Value = iNV_Sale.Remark;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = iNV_Sale.UpdatedBy;
            cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = iNV_Sale.UpdatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteINV_Sale(int saleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteINV_Sale", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SaleID", SqlDbType.Int).Value = saleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

