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

public partial class AdminINV_MRRInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadINV_MRRInfoData();
            CampusIDLoad();
            MRRInfoMasterIDLoad();
            IteamIDLoad();
            TagIDLoad();
            StoreIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                h3Header.InnerText = "Edit MRR Information";
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showINV_MRRInfoData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo();
            //iNV_MRRInfo.MRRInfoID=  int.Parse(ddlMRRInfoID.SelectedValue);
            //iNV_MRRInfo.MRRInfoMasterID = int.Parse(ddlMRRInfoMasterID.SelectedValue);
            iNV_MRRInfo.MRRCode = txtMRRCode.Text;
            iNV_MRRInfo.IteamID = int.Parse(ddlIteamID.SelectedValue);
            iNV_MRRInfo.TagID = "0";
            iNV_MRRInfo.Quantity = decimal.Parse(txtQuantity.Text);
            iNV_MRRInfo.MRRAmount = decimal.Parse(txtMRRAmount.Text);
            iNV_MRRInfo.SaleAmount = decimal.Parse(txtSaleAmount.Text);
            iNV_MRRInfo.MRRDate = DateTime.Parse(txtMRRDate.Text);
            iNV_MRRInfo.StoreID = int.Parse(ddlStoreID.SelectedValue);
            INV_Store store = INV_StoreManager.GetINV_StoreByStoreID(iNV_MRRInfo.StoreID);
            if (store != null)
            {
                iNV_MRRInfo.CampusID = store.CampusID;// int.Parse(ddlCampusID.SelectedValue);
            }
            int resutl = INV_MRRInfoManager.InsertINV_MRRInfo(iNV_MRRInfo);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayINV_MRRInfo.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo();
            iNV_MRRInfo.MRRInfoID = int.Parse(Request.QueryString["ID"].ToString());
            iNV_MRRInfo.CampusID = 0;// int.Parse(ddlCampusID.SelectedValue);
            iNV_MRRInfo.MRRInfoMasterID = 0;// int.Parse(ddlMRRInfoMasterID.SelectedValue);
            iNV_MRRInfo.MRRCode = txtMRRCode.Text;
            iNV_MRRInfo.IteamID = int.Parse(ddlIteamID.SelectedValue);
            iNV_MRRInfo.TagID = "0";// ddlTagID.SelectedValue;
            iNV_MRRInfo.Quantity = decimal.Parse(txtQuantity.Text);
            iNV_MRRInfo.MRRAmount = decimal.Parse(txtMRRAmount.Text);
            iNV_MRRInfo.SaleAmount = decimal.Parse(txtSaleAmount.Text);
            iNV_MRRInfo.MRRDate = DateTime.Parse(txtMRRDate.Text);
            iNV_MRRInfo.StoreID = int.Parse(ddlStoreID.SelectedValue);
             INV_Store store = INV_StoreManager.GetINV_StoreByStoreID(iNV_MRRInfo.StoreID);
             if (store != null)
             {
                 iNV_MRRInfo.CampusID = store.CampusID;
             }
            bool resutl = INV_MRRInfoManager.UpdateINV_MRRInfo(iNV_MRRInfo);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayINV_MRRInfo.aspx");
    }

    private void showINV_MRRInfoData()
    {
        INV_MRRInfo iNV_MRRInfo = new INV_MRRInfo();
        iNV_MRRInfo = INV_MRRInfoManager.GetINV_MRRInfoByMRRInfoID(Int32.Parse(Request.QueryString["ID"]));
        //ddlCampusID.SelectedValue = iNV_MRRInfo.CampusID.ToString();
        //ddlMRRInfoMasterID.SelectedValue = iNV_MRRInfo.MRRInfoMasterID.ToString();
        txtMRRCode.Text = iNV_MRRInfo.MRRCode.ToString();
        txtMRRCode.ReadOnly = true;
        ddlIteamID.SelectedValue = iNV_MRRInfo.IteamID.ToString();
       // ddlTagID.SelectedValue = iNV_MRRInfo.TagID.ToString();
        string[] qntArray = iNV_MRRInfo.Quantity.ToString().Split('.');
        txtQuantity.Text = qntArray.Length > 0 ? qntArray[0] : "0";
        txtMRRAmount.Text = iNV_MRRInfo.MRRAmount.ToString("N");
        txtSaleAmount.Text = iNV_MRRInfo.SaleAmount.ToString("N");
        txtMRRDate.Text = iNV_MRRInfo.MRRDate.ToString("dd MMM yyyy");
        ddlStoreID.SelectedValue = iNV_MRRInfo.StoreID.ToString();
    }

    private void CampusIDLoad()
    {
        try
        {
            //DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
            //ddlCampusID.DataValueField = "CampusID";
            //ddlCampusID.DataTextField = "CampusName";
            //ddlCampusID.DataSource = ds.Tables[0];
            //ddlCampusID.DataBind();
            //ddlCampusID.Items.Insert(0, new ListItem("Select Campus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void MRRInfoMasterIDLoad()
    {
        try
        {
            //DataSet ds = INV_MRRInfoMasterManager.GetDropDownListAllINV_MRRInfoMaster();
            //ddlMRRInfoMasterID.DataValueField = "MRRInfoMasterID";
            //ddlMRRInfoMasterID.DataTextField = "MRRInfoMasterName";
            //ddlMRRInfoMasterID.DataSource = ds.Tables[0];
            //ddlMRRInfoMasterID.DataBind();
            //ddlMRRInfoMasterID.Items.Insert(0, new ListItem("Select MRRInfoMaster >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void IteamIDLoad()
    {
        try
        {
            DataSet ds = INV_IteamManager.GetDropDownListAllINV_Iteam();
            ddlIteamID.DataValueField = "IteamID";
            ddlIteamID.DataTextField = "Description";
            ddlIteamID.DataSource = ds.Tables[0];
            ddlIteamID.DataBind();
            ddlIteamID.Items.Insert(0, new ListItem("Select Iteam >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void TagIDLoad()
    {
        //try {
        //DataSet ds = INV_TagManager.GetDropDownListAllINV_Tag();
        //ddlTagID.DataValueField = "TagID";
        //ddlTagID.DataTextField = "TagName";
        //ddlTagID.DataSource = ds.Tables[0];
        //ddlTagID.DataBind();
        //ddlTagID.Items.Insert(0, new ListItem("Select Tag >>", "0"));
        //}
        //catch (Exception ex) {
        //ex.Message.ToString();
        //}
    }

    private void StoreIDLoad()
    {
        try
        {
            DataSet ds = INV_StoreManager.GetDropDownListAllINV_Store();
            ddlStoreID.DataValueField = "StoreID";
            ddlStoreID.DataTextField = "StoreName";
            ddlStoreID.DataSource = ds.Tables[0];
            ddlStoreID.DataBind();
            ddlStoreID.Items.Insert(0, new ListItem("Select Store >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

