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
public partial class AdminINV_MRRInfoMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadINV_MRRInfoMasterData();
            CampusIDLoad();
            StoreIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showINV_MRRInfoMasterData();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            INV_MRRInfoMaster iNV_MRRInfoMaster = new INV_MRRInfoMaster();
            //	iNV_MRRInfoMaster.MRRInfoMasterID=  int.Parse(ddlMRRInfoMasterID.SelectedValue);
            iNV_MRRInfoMaster.MRRInfoMasterName = txtMRRInfoMasterName.Text;
            iNV_MRRInfoMaster.CampusID = int.Parse(ddlCampusID.SelectedValue);
            iNV_MRRInfoMaster.MRRCode = txtMRRCode.Text;
            iNV_MRRInfoMaster.MRRDate = DateTime.Parse(txtMRRDate.Text);
            iNV_MRRInfoMaster.StoreID = int.Parse(ddlStoreID.SelectedValue);
            int resutl = INV_MRRInfoMasterManager.InsertINV_MRRInfoMaster(iNV_MRRInfoMaster);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayINV_MRRInfoMaster.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            INV_MRRInfoMaster iNV_MRRInfoMaster = new INV_MRRInfoMaster();
            iNV_MRRInfoMaster.MRRInfoMasterID = int.Parse(Request.QueryString["ID"].ToString());
            iNV_MRRInfoMaster.MRRInfoMasterName = txtMRRInfoMasterName.Text;
            iNV_MRRInfoMaster.CampusID = int.Parse(ddlCampusID.SelectedValue);
            iNV_MRRInfoMaster.MRRCode = txtMRRCode.Text;
            iNV_MRRInfoMaster.MRRDate = DateTime.Parse(txtMRRDate.Text);
            iNV_MRRInfoMaster.StoreID = int.Parse(ddlStoreID.SelectedValue);
            bool resutl = INV_MRRInfoMasterManager.UpdateINV_MRRInfoMaster(iNV_MRRInfoMaster);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayINV_MRRInfoMaster.aspx");
    }
    private void showINV_MRRInfoMasterData()
    {
        INV_MRRInfoMaster iNV_MRRInfoMaster = new INV_MRRInfoMaster();
        iNV_MRRInfoMaster = INV_MRRInfoMasterManager.GetINV_MRRInfoMasterByMRRInfoMasterID(Int32.Parse(Request.QueryString["ID"]));
        txtMRRInfoMasterName.Text = iNV_MRRInfoMaster.MRRInfoMasterName.ToString();
        ddlCampusID.SelectedValue = iNV_MRRInfoMaster.CampusID.ToString();
        txtMRRCode.Text = iNV_MRRInfoMaster.MRRCode.ToString();
        txtMRRDate.Text = iNV_MRRInfoMaster.MRRDate.ToString("dd MMM yyyy");
        ddlStoreID.SelectedValue = iNV_MRRInfoMaster.StoreID.ToString();
    }

    private void CampusIDLoad()
    {
        try
        {
            DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
            ddlCampusID.DataValueField = "CampusID";
            ddlCampusID.DataTextField = "CampusName";
            ddlCampusID.DataSource = ds.Tables[0];
            ddlCampusID.DataBind();
            ddlCampusID.Items.Insert(0, new ListItem("Select Campus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
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

