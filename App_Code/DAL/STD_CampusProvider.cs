using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

public class SqlSTD_CampusProvider:DataAccessObject
{
	public SqlSTD_CampusProvider()
    {
    }


    public DataSet  GetAllSTD_Campuss()
    {
        DataSet STD_Campuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_Campuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Campuss);
            myadapter.Dispose();
            connection.Close();

            return STD_Campuss;
        }
    }
	public DataSet GetSTD_CampusPageWise(int pageIndex, int PageSize, out int recordCount)
    {
    DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("GetSTD_CampusPageWise", connection))
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


    public STD_Campus  GetSTD_CampusByCityID(int  cityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CampusByCityID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CityID", SqlDbType.NVarChar).Value = cityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_CampusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public DataSet  GetDropDownListAllSTD_Campus()
    {
        DataSet STD_Campuss = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetDropDownListAllSTD_Campuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(STD_Campuss);
            myadapter.Dispose();
            connection.Close();

            return STD_Campuss;
        }
    }

    public DataSet   GetAllSTD_CampussWithRelation()
    {
       DataSet ds = new DataSet();
       using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllSTD_CampussWithRelation", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
    public List<STD_Campus> GetSTD_CampussFromReader(IDataReader reader)
    {
        List<STD_Campus> sTD_Campuss = new List<STD_Campus>();

        while (reader.Read())
        {
            sTD_Campuss.Add(GetSTD_CampusFromReader(reader));
        }
        return sTD_Campuss;
    }

    public STD_Campus GetSTD_CampusFromReader(IDataReader reader)
    {
        try
        {
            STD_Campus sTD_Campus = new STD_Campus
                (

                     DataAccessObject.IsNULL<int>(reader["CampusID"]),
                     DataAccessObject.IsNULL<string>(reader["CampusName"]),
                     DataAccessObject.IsNULL<string>(reader["Address"]),
                     DataAccessObject.IsNULL<string>(reader["Description"]),
                     DataAccessObject.IsNULL<int>(reader["CityID"]),
                     DataAccessObject.IsNULL<string>(reader["AddedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["AddedDate"]),
                     DataAccessObject.IsNULL<string>(reader["UpdatedBy"].ToString()),
                     DataAccessObject.IsNULL<DateTime>(reader["UpdateDate"])
                );
             return sTD_Campus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public STD_Campus  GetSTD_CampusByCampusID(int  campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetSTD_CampusByCampusID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CampusID", SqlDbType.Int).Value = campusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
            return GetSTD_CampusFromReader(reader);
             }
            else
            {
            return null;
            }
        }
    }

    public int InsertSTD_Campus(STD_Campus sTD_Campus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertSTD_Campus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CampusName", SqlDbType.NVarChar).Value = sTD_Campus.CampusName;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = sTD_Campus.Address;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Campus.Description;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = sTD_Campus.CityID;
            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = sTD_Campus.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = sTD_Campus.AddedDate;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Campus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Campus.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CampusID"].Value;
        }
    }

    public bool UpdateSTD_Campus(STD_Campus sTD_Campus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateSTD_Campus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = sTD_Campus.CampusID;
            cmd.Parameters.Add("@CampusName", SqlDbType.NVarChar).Value = sTD_Campus.CampusName;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = sTD_Campus.Address;
            cmd.Parameters.Add("@Description", SqlDbType.NText).Value = sTD_Campus.Description;
            cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = sTD_Campus.CityID;
            //cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = sTD_Campus.CityID;
            //cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = sTD_Campus.CityID;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar).Value = sTD_Campus.UpdatedBy;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = sTD_Campus.UpdateDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool DeleteSTD_Campus(int campusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteSTD_Campus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CampusID", SqlDbType.Int).Value = campusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

