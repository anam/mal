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
public partial class AdminINV_Issue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CampusIDLoad();
            IssueMasterIDLoad();
            StoreIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showINV_IssueData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            INV_Issue iNV_Issue = new INV_Issue();
            //	iNV_Issue.IssueID=  int.Parse(ddlIssueID.SelectedValue);
            iNV_Issue.CampusID = int.Parse(ddlCampusID.SelectedValue);
            iNV_Issue.IssueMasterID = int.Parse(ddlIssueMasterID.SelectedValue);
            iNV_Issue.StoreID = int.Parse(ddlStoreID.SelectedValue);
            iNV_Issue.ProductionCode = txtProductionCode.Text;
            iNV_Issue.Quantity = decimal.Parse(txtQuantity.Text);
            iNV_Issue.IssueDate = DateTime.Parse(txtIssueDate.Text);
            iNV_Issue.AddedBy = Profile.card_id;
            iNV_Issue.AddedDate = DateTime.Now;
            iNV_Issue.UpdatedBy = Profile.card_id;
            iNV_Issue.UpdatedDate = DateTime.Now;
            int resutl = INV_IssueManager.InsertINV_Issue(iNV_Issue);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayINV_Issue.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            INV_Issue iNV_Issue = new INV_Issue();
            iNV_Issue.IssueID = int.Parse(Request.QueryString["ID"].ToString());
            iNV_Issue.CampusID = int.Parse(ddlCampusID.SelectedValue);
            iNV_Issue.IssueMasterID = int.Parse(ddlIssueMasterID.SelectedValue);
            iNV_Issue.StoreID = int.Parse(ddlStoreID.SelectedValue);
            iNV_Issue.ProductionCode = txtProductionCode.Text;
            iNV_Issue.Quantity = decimal.Parse(txtQuantity.Text);
            iNV_Issue.IssueDate = DateTime.Parse(txtIssueDate.Text);
            iNV_Issue.AddedBy = Profile.card_id;
            iNV_Issue.AddedDate = DateTime.Now;
            iNV_Issue.UpdatedBy = Profile.card_id;
            iNV_Issue.UpdatedDate = DateTime.Now;
            bool resutl = INV_IssueManager.UpdateINV_Issue(iNV_Issue);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplayINV_Issue.aspx");
    }

    private void showINV_IssueData()
    {
        INV_Issue iNV_Issue = new INV_Issue();
        iNV_Issue = INV_IssueManager.GetINV_IssueByIssueID(Int32.Parse(Request.QueryString["ID"]));
        ddlCampusID.SelectedValue = iNV_Issue.CampusID.ToString();
        ddlIssueMasterID.SelectedValue = iNV_Issue.IssueMasterID.ToString();
        ddlStoreID.SelectedValue = iNV_Issue.StoreID.ToString();
        txtProductionCode.Text = iNV_Issue.ProductionCode.ToString();
        txtQuantity.Text = iNV_Issue.Quantity.ToString();
        txtIssueDate.Text = iNV_Issue.IssueDate.ToString("dd MMM yyyy");
        string txtUpdatedBy_Text = iNV_Issue.UpdatedBy.ToString();
        string txtUpdatedDate_Text = iNV_Issue.UpdatedDate.ToString();
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

    private void IssueMasterIDLoad()
    {
        try
        {
            DataSet ds = INV_IssueMasterManager.GetDropDownListAllINV_IssueMaster();
            ddlIssueMasterID.DataValueField = "IssueMasterID";
            ddlIssueMasterID.DataTextField = "IssueMasterName";
            ddlIssueMasterID.DataSource = ds.Tables[0];
            ddlIssueMasterID.DataBind();
            ddlIssueMasterID.Items.Insert(0, new ListItem("Select IssueMaster >>", "0"));
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

