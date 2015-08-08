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

public partial class AdminINV_IssueMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadINV_IssueMasterData();
            CampusIDLoad();
            StoreIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showINV_IssueMasterData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            INV_IssueMaster iNV_IssueMaster = new INV_IssueMaster();
            //	iNV_IssueMaster.IssueMasterID=  int.Parse(ddlIssueMasterID.SelectedValue);
            iNV_IssueMaster.IssueMasterName = txtIssueMasterName.Text;
            iNV_IssueMaster.CampusID = int.Parse(ddlCampusID.SelectedValue);
            iNV_IssueMaster.StoreID = int.Parse(ddlStoreID.SelectedValue);
            iNV_IssueMaster.ProductionCode = txtProductionCode.Text;
            iNV_IssueMaster.Quantity = decimal.Parse(txtQuantity.Text);
            iNV_IssueMaster.IssueDate = DateTime.Parse(txtIssueDate.Text);
            iNV_IssueMaster.AddedBy = Profile.card_id;
            iNV_IssueMaster.AddedDate = DateTime.Now;
            iNV_IssueMaster.UpdatedBy = Profile.card_id;
            iNV_IssueMaster.UpdatedDate = DateTime.Now;
            int resutl = INV_IssueMasterManager.InsertINV_IssueMaster(iNV_IssueMaster);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayINV_IssueMaster.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            INV_IssueMaster iNV_IssueMaster = new INV_IssueMaster();
            iNV_IssueMaster.IssueMasterID = int.Parse(Request.QueryString["ID"].ToString());
            iNV_IssueMaster.IssueMasterName = txtIssueMasterName.Text;
            iNV_IssueMaster.CampusID = int.Parse(ddlCampusID.SelectedValue);
            iNV_IssueMaster.StoreID = int.Parse(ddlStoreID.SelectedValue);
            iNV_IssueMaster.ProductionCode = txtProductionCode.Text;
            iNV_IssueMaster.Quantity = decimal.Parse(txtQuantity.Text);
            iNV_IssueMaster.IssueDate = DateTime.Parse(txtIssueDate.Text);
            iNV_IssueMaster.AddedBy = Profile.card_id;
            iNV_IssueMaster.AddedDate = DateTime.Now;
            iNV_IssueMaster.UpdatedBy = Profile.card_id;
            iNV_IssueMaster.UpdatedDate = DateTime.Now;
            bool resutl = INV_IssueMasterManager.UpdateINV_IssueMaster(iNV_IssueMaster);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayINV_IssueMaster.aspx");
    }

    private void showINV_IssueMasterData()
    {
        INV_IssueMaster iNV_IssueMaster = new INV_IssueMaster();
        iNV_IssueMaster = INV_IssueMasterManager.GetINV_IssueMasterByIssueMasterID(Int32.Parse(Request.QueryString["ID"]));
        txtIssueMasterName.Text = iNV_IssueMaster.IssueMasterName.ToString();
        ddlCampusID.SelectedValue = iNV_IssueMaster.CampusID.ToString();
        ddlStoreID.SelectedValue = iNV_IssueMaster.StoreID.ToString();
        txtProductionCode.Text = iNV_IssueMaster.ProductionCode.ToString();
        txtQuantity.Text = iNV_IssueMaster.Quantity.ToString();
        txtIssueDate.Text = iNV_IssueMaster.IssueDate.ToString();
        string txtUpdatedBy_Text = iNV_IssueMaster.UpdatedBy.ToString();
        string txtUpdatedDate_Text = iNV_IssueMaster.UpdatedDate.ToString();
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

