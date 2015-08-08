using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_BatchProvider:DataAccessObject
{
	public SqlSTD_BatchProvider()
    {
    }


    public DataSet  GetAllSTD_Batchs()
    {
        DataSet STD_Batchs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Batchs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Batchs);
            myadapter.Dispose();
            connection.Close();

            return STD_Batchs;
        }
    }
	public DataSet GetSTD_BatchPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_BatchPageWise", connection))
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


    public STD_Batch  GetSTD_BatchByRowStatusID(int  rowStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_BatchByRowStatusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@RowStatusID", SqlDbType.NVarChar).Value = rowStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_BatchFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownLisAllSTD_Batch()
    {
        DataSet STD_Batchs = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Batch", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Batchs);
            myadapter.Dispose();
            connection.Close();

            return STD_Batchs;
        }
    }

    public DataSet   GetAllSTD_FeessWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_FeessWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Batch> GetSTD_BatchsFromReader(IDataReader reader)
    {
        List<STD_Batch> sTD_Batchs = new List<STD_Batch>();

        while (reader.Read())
        {
            sTD_Batchs.Add(GetSTD_BatchFromReader(reader));
        }
        return sTD_Batchs;
    }

    public STD_Batch GetSTD_BatchFromReader(IDataReader reader)
    {
        try
        {
            STD_Batch sTD_Batch = new STD_Batch
                (

                     DataAccessObject.IsNULL<int>(reader["BatchID"]),
                     DataAccessObject.IsNULL<string>(reader["BatchName"]),
                    
                     DataAccessObject.IsNULL<int>(reader["Year"]),
                     DataAccessObject.IsNULL<int>(reader["ID"]),
                     DataAccessObject.IsNULL<string>(reader["BatchCode"]),

                     DataAccessObject.IsNULL<string>(reader["ExtraField1"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField2"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField3"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField4"]),
                     DataAccessObject.IsNULL<string>(reader["ExtraField5"]),

                      DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"]),
                     DataAccessObject.IsNULL<int>(reader["RowStatusID"])
                );           
             return sTD_Batch;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public List<STD_Batch> GetSTD_BatchsFromReader1(IDataReader reader)
    {
        List<STD_Batch> sTD_Batchs = new List<STD_Batch>();

        while (reader.Read())
        {
            sTD_Batchs.Add(GetSTD_BatchFromReader1(reader));
        }
        return sTD_Batchs;
    }

    public STD_Batch GetSTD_BatchFromReader1(IDataReader reader)
    {
        try
        {
            STD_Batch sTD_Batch = new STD_Batch
                (

                     DataAccessObject.IsNULL<int>(reader["MaxID"])
                );
            
            return sTD_Batch;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public STD_Batch  GetSTD_BatchByBatchID(int  BatchID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_BatchByBatchID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BatchID", SqlDbType.Int).Value = BatchID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_BatchFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Batch(STD_Batch sTD_Batch)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Batch", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BatchID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BatchName", SqlDbType.NVarChar).Value = sTD_Batch.BatchName;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = sTD_Batch.Year;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = sTD_Batch.ID;
            cmd.Parameters.Add("@BatchCode", SqlDbType.NVarChar).Value = sTD_Batch.BatchCode;

            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField5;

            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Batch.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Batch.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Batch.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Batch.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Batch.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BatchID"].Value;
        }
    }

    public bool UpdateSTD_Batch(STD_Batch sTD_Batch)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Batch", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BatchID", SqlDbType.Int).Value = sTD_Batch.BatchID;
            cmd.Parameters.Add("@BatchName", SqlDbType.NVarChar).Value = sTD_Batch.BatchName;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = sTD_Batch.Year;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = sTD_Batch.ID;
            cmd.Parameters.Add("@BatchCode", SqlDbType.NVarChar).Value = sTD_Batch.BatchCode;

            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = sTD_Batch.ExtraField5;

            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Batch.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Batch.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Batch.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Batch.UpdateDate;
            cmd.Parameters.Add("@RowStatusID", SqlDbType.Int).Value = sTD_Batch.RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Batch(int BatchID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Batch", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BatchID", SqlDbType.Int).Value = BatchID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public STD_Batch GetSTD_BatchMaxIDByYear(int year)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_BatchMaxIDByYear", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Year", SqlDbType.Int).Value = year ;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                return GetSTD_BatchFromReader1(reader);
            }
            else
            {
                return null;
            }
        }
    }


    public DataSet GetAllSTD_BatchMaxIDByYear(int year)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetAllSTD_BatchMaxIDByYear", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Year", year);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }

    public DataSet GetAllSTD_BatchMaxIDByYearnID(int year,int ID)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetAllSTD_BatchMaxIDByYearnID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Year", year);
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();
                return ds;
            }
        }
    }
}

