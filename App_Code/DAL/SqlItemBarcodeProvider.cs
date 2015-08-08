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

public class SqlItemBarcodeProvider:DataAccessObject
{
	public SqlItemBarcodeProvider()
    {
    }


    public bool DeleteItemBarcode(int itemBarcodeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cuc_DeleteItemBarcode", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemBarcodeID", SqlDbType.Int).Value = itemBarcodeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<ItemBarcode> GetAllItemBarcodes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Cuc_GetAllItemBarcodes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetItemBarcodesFromReader(reader);
        }
    }
    public List<ItemBarcode> GetItemBarcodesFromReader(IDataReader reader)
    {
        List<ItemBarcode> itemBarcodes = new List<ItemBarcode>();

        while (reader.Read())
        {
            itemBarcodes.Add(GetItemBarcodeFromReader(reader));
        }
        return itemBarcodes;
    }

    public ItemBarcode GetItemBarcodeFromReader(IDataReader reader)
    {
        try
        {
            ItemBarcode itemBarcode = new ItemBarcode
                (
                    (int)reader["ItemBarcodeID"],
                    (int)reader["SubCategoryID"],
                    (int)reader["NoOfItem"],
                    reader["BarcodeText"].ToString(),
                    (DateTime)reader["AddedDate"]
                );

            try {
                itemBarcode.IteamDetails = reader["IteamCategoryName"].ToString() + " --> " + reader["IteamSubCategoryName"].ToString();
            }
            catch (Exception ex) { }
             return itemBarcode;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public ItemBarcode GetItemBarcodeByID(int itemBarcodeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("Cuc_GetItemBarcodeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ItemBarcodeID", SqlDbType.Int).Value = itemBarcodeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetItemBarcodeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertItemBarcode(ItemBarcode itemBarcode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cuc_InsertItemBarcode", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemBarcodeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SubCategoryID", SqlDbType.Int).Value = itemBarcode.SubCategoryID;
            cmd.Parameters.Add("@NoOfItem", SqlDbType.Int).Value = itemBarcode.NoOfItem;
            cmd.Parameters.Add("@BarcodeText", SqlDbType.NText).Value = itemBarcode.BarcodeText;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = itemBarcode.AddedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ItemBarcodeID"].Value;
        }
    }

    public bool UpdateItemBarcode(ItemBarcode itemBarcode)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("Cuc_UpdateItemBarcode", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemBarcodeID", SqlDbType.Int).Value = itemBarcode.ItemBarcodeID;
            cmd.Parameters.Add("@SubCategoryID", SqlDbType.Int).Value = itemBarcode.SubCategoryID;
            cmd.Parameters.Add("@NoOfItem", SqlDbType.Int).Value = itemBarcode.NoOfItem;
            cmd.Parameters.Add("@BarcodeText", SqlDbType.NText).Value = itemBarcode.BarcodeText;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = itemBarcode.AddedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
