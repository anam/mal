using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_ClassDayProvider:DataAccessObject
{
	public SqlSTD_ClassDayProvider()
    {
    }


    public DataSet  GetAllSTD_ClassDaies()
    {
        DataSet STD_ClassDaies = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClassDaies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassDaies);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassDaies;
        }
    }
	public DataSet GetSTD_ClassDayPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_ClassDayPageWise", connection))
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


    public DataSet  GetDropDownListAllSTD_ClassDay()
    {
        DataSet STD_ClassDaies = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_ClassDay", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_ClassDaies);
            myadapter.Dispose();
            connection.Close();

            return STD_ClassDaies;
        }
    }

    public DataSet   GetAllSTD_ClasssWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_ClasssWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_ClassDay> GetSTD_ClassDaiesFromReader(IDataReader reader)
    {
        List<STD_ClassDay> sTD_ClassDaies = new List<STD_ClassDay>();

        while (reader.Read())
        {
            sTD_ClassDaies.Add(GetSTD_ClassDayFromReader(reader));
        }
        return sTD_ClassDaies;
    }

    public STD_ClassDay GetSTD_ClassDayFromReader(IDataReader reader)
    {
        try
        {
            STD_ClassDay sTD_ClassDay = new STD_ClassDay
                (

                     DataAccessObject.IsNULL<int>(reader["ClassDayID"]),
                     DataAccessObject.IsNULL<string>(reader["ClassDayName"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_ClassDay;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_ClassDay  GetSTD_ClassDayByClassDayID(int  classDayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_ClassDayByClassDayID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ClassDayID", SqlDbType.Int).Value = classDayID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_ClassDayFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_ClassDay(STD_ClassDay sTD_ClassDay)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_ClassDay", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassDayID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ClassDayName", SqlDbType.NVarChar).Value = sTD_ClassDay.ClassDayName;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_ClassDay.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_ClassDay.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassDay.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassDay.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ClassDayID"].Value;
        }
    }

    public bool UpdateSTD_ClassDay(STD_ClassDay sTD_ClassDay)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_ClassDay", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassDayID", SqlDbType.Int).Value = sTD_ClassDay.ClassDayID;
            cmd.Parameters.Add("@ClassDayName", SqlDbType.NVarChar).Value = sTD_ClassDay.ClassDayName;
            //cmd.Parameters.Add("@ClassDayName", SqlDbType.NVarChar).Value = sTD_ClassDay.ClassDayName;
            //cmd.Parameters.Add("@ClassDayName", SqlDbType.NVarChar).Value = sTD_ClassDay.ClassDayName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_ClassDay.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_ClassDay.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_ClassDay(int classDayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_ClassDay", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClassDayID", SqlDbType.Int).Value = classDayID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

