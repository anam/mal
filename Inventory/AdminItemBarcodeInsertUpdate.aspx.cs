using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AdminItemBarcodeInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loadSubCategory();
            if (Request.QueryString["itemBarcodeID"] != null)
            {
                int itemBarcodeID = Int32.Parse(Request.QueryString["itemBarcodeID"]);
                if (itemBarcodeID == 0)
                {
                    
                }
                else
                {
                   
                    showItemBarcodeData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //ddlSubCategory.SelectedIndex = 0;
        //txtNoOfItem.Text = "";
        //txtBarcodeText.Text = "";
    }
    private void showItemBarcodeData()
    {
        ItemBarcode itemBarcode = new ItemBarcode();
        itemBarcode = ItemBarcodeManager.GetItemBarcodeByID(Int32.Parse(Request.QueryString["itemBarcodeID"]));

        lblSubCategory.Text = itemBarcode.IteamDetails;
        txtNoOfItem.Text = itemBarcode.NoOfItem.ToString();
        txtBarcodeText.Text = itemBarcode.BarcodeText;
    }
    
}
