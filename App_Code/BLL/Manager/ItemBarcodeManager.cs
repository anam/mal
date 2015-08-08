using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class ItemBarcodeManager
{
	public ItemBarcodeManager()
	{
	}

    public static List<ItemBarcode> GetAllItemBarcodes()
    {
        List<ItemBarcode> itemBarcodes = new List<ItemBarcode>();
        SqlItemBarcodeProvider sqlItemBarcodeProvider = new SqlItemBarcodeProvider();
        itemBarcodes = sqlItemBarcodeProvider.GetAllItemBarcodes();
        return itemBarcodes;
    }


    public static ItemBarcode GetItemBarcodeByID(int id)
    {
        ItemBarcode itemBarcode = new ItemBarcode();
        SqlItemBarcodeProvider sqlItemBarcodeProvider = new SqlItemBarcodeProvider();
        itemBarcode = sqlItemBarcodeProvider.GetItemBarcodeByID(id);
        return itemBarcode;
    }


    public static int InsertItemBarcode(ItemBarcode itemBarcode)
    {
        SqlItemBarcodeProvider sqlItemBarcodeProvider = new SqlItemBarcodeProvider();
        return sqlItemBarcodeProvider.InsertItemBarcode(itemBarcode);
    }


    public static bool UpdateItemBarcode(ItemBarcode itemBarcode)
    {
        SqlItemBarcodeProvider sqlItemBarcodeProvider = new SqlItemBarcodeProvider();
        return sqlItemBarcodeProvider.UpdateItemBarcode(itemBarcode);
    }

    public static bool DeleteItemBarcode(int itemBarcodeID)
    {
        SqlItemBarcodeProvider sqlItemBarcodeProvider = new SqlItemBarcodeProvider();
        return sqlItemBarcodeProvider.DeleteItemBarcode(itemBarcodeID);
    }
}
