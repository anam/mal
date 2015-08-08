using System;
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

public class ItemBarcode
{
    public ItemBarcode()
    {
    }

    public ItemBarcode
        (
        int itemBarcodeID, 
        int subCategoryID, 
        int noOfItem, 
        string barcodeText, 
        DateTime addedDate
        )
    {
        this.ItemBarcodeID = itemBarcodeID;
        this.SubCategoryID = subCategoryID;
        this.NoOfItem = noOfItem;
        this.BarcodeText = barcodeText;
        this.AddedDate = addedDate;
    }


    private int _itemBarcodeID;
    public int ItemBarcodeID
    {
        get { return _itemBarcodeID; }
        set { _itemBarcodeID = value; }
    }

    private int _subCategoryID;
    public int SubCategoryID
    {
        get { return _subCategoryID; }
        set { _subCategoryID = value; }
    }

    private int _noOfItem;
    public int NoOfItem
    {
        get { return _noOfItem; }
        set { _noOfItem = value; }
    }

    private string _barcodeText;
    public string BarcodeText
    {
        get { return _barcodeText; }
        set { _barcodeText = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    public string IteamDetails
    {
        get;
        set;
    }
}
